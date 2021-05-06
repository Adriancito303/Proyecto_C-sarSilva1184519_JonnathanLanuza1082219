using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models
{
    public class Patients
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int DPI { get; set; }
        [Required]
        public string town { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display(Name = "Select your status (P)")]
        public string Priority { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
