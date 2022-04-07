using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageProject.Model
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Range(1, 100)]
        public int Status { get; set; }
        public int Priority { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
    }
}
