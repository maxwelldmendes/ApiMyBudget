using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyBudget.ModelsDTO
{
    public class CreateClassOfAccountDTO
    {
        public int SubGroupId { get; set; }
        public string ClassDescription { get; set; } = string.Empty;
        public string ClassCode { get; set; } = string.Empty;

    }
}