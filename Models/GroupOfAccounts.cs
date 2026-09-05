using System.ComponentModel.DataAnnotations;

namespace ApiMyBudget.Models
{
    public class GroupOfAccounts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GroupDescription { get; set; } = string.Empty;
        [Required]
        public string GroupInformation { get; set; } = string.Empty;

        // Navigation property for the related SubGroupOfAccounts entities.
        public ICollection<SubGroupOfAccounts> SubGroupsOfAccounts { get; set; } = new List<SubGroupOfAccounts>();
    }
}