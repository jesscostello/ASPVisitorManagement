using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPVisitorManagement.Models
{
    public class StaffNames
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required (ErrorMessage = "This is the error message")]
        public string Department { get; set; }
        public int VisitorCount { get; set; }
    }
}
