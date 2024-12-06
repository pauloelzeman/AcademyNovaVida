using System.ComponentModel.DataAnnotations;

namespace AcademyNovaVida.Models
{
    public class Professor
    {
        [Key] // Define como chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do professor é obrigatório.")] // Campo obrigatório
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")] // Tamanho máximo
        public string Nome { get; set; }

        // Relação um-para-muitos com Alunos
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
