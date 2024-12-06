using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyNovaVida.Models
{
    public class Aluno
    {
        [Key] // Define como chave primária
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")] // Campo obrigatório
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")] // Tamanho máximo
        public string Nome { get; set; }

        [Required(ErrorMessage = "A mensalidade é obrigatória.")] // Campo obrigatório
        [Range(0, double.MaxValue, ErrorMessage = "A mensalidade deve ser um valor positivo.")]
        [Column(TypeName = "decimal(18,2)")] // Define o tipo no banco de dados
        public decimal Mensalidade { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")] // Campo obrigatório
        [DataType(DataType.Date)] // Indica que é um campo de data
        public DateTime DataVencimento { get; set; }

        // Chave estrangeira para o Professor
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }

        // Navegação para a classe Professor
        public Professor Professor { get; set; }
    }
}
