using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyBudget.ModelsDTO
{
    public class ReadClassOfAccountsDTO
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