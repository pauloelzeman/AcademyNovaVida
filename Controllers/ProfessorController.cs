using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademyNovaVida.Data;
using AcademyNovaVida.Models;
using AspNetCoreGeneratedDocument;

namespace AcademyNovaVida.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ApplicationContext _context;

        public ProfessorController(ApplicationContext context)
        {
            _context = context;
        }

        // Ação para a página de lista de alunos do professor
        public IActionResult Listar(int id)
        {
            // Buscar os alunos do professor
            var alunos = _context.Aluno.Where(a => a.ProfessorId == id).ToList();

            if (alunos == null) return NotFound();
            return View(alunos);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Id,Nome")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                // Redireciona para o Index do HomeController
                return RedirectToAction("Index", "Home");
            }
            return View(professor);
        }
             
        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.Id == id);
        }
    }
}
