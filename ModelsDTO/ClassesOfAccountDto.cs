// Classe que sera usada para persistir o objeto no banco de dados.
using System.ComponentModel.DataAnnotations;

namespace ApiMyBudget.ModelsDTO
{
    public class ClassesOfAccountDto
    {
        public int Id { get; set; }
        [Required]
        public string ClassCode { get; set; } = string.Empty;
        [Required]
        public string ClassDescription { get; set; } = string.Empty;
        [Required]
        // Foreign key for the SubGroupOfAccounts entity.
        public int SubGroupId { get; set; } = 0;
    }
}