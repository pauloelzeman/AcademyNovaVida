using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademyNovaVida.Data;
using AcademyNovaVida.Models;

namespace AcademyNovaVida.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ApplicationContext _context;
        private static DateTime _lastImportTime = DateTime.MinValue;

        public AlunoController(ApplicationContext context)
        {
            _context = context;
        }

        // Exibe a lista de alunos de um professor
        public IActionResult Listar(int professorId)
        {
            var alunos = _context.Aluno
                .Include(a => a.Professor) // Garante que o Professor está sendo carregado
                .Where(a => a.ProfessorId == professorId)
                .ToList();
            ViewData["ProfessorId"] = professorId;
            return View(alunos);
        }

        [HttpPost]
        public IActionResult Importar(IFormFile file, int professorId)
        {
            // Validações iniciais
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            var professor = _context.Professor.Find(professorId);
            if (professor == null)
                return NotFound("Professor não encontrado.");

            // Lógica de leitura do arquivo
            using var reader = new StreamReader(file.OpenReadStream());
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split("||");
                if (parts.Length != 3) continue;

                var aluno = new Aluno
                {
                    Nome = parts[0].Trim(),
                    Mensalidade = decimal.Parse(parts[1].Trim()),
                    DataVencimento = DateTime.Parse(parts[2].Trim()),
                    ProfessorId = professorId
                };
                _context.Aluno.Add(aluno);
            }
            _context.SaveChanges();

            return RedirectToAction("Listar", "Aluno", new {professorId});
        }

         //Alunos/Excluir
        [HttpDelete]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Aluno excluído com sucesso." });
        }
    }
}
