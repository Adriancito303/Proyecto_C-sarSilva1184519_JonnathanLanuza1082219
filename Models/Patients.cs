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
        public string LastName { get; set; }
        public int DPI { get; set; }
        public string town { get; set; }
        public string Department { get; set; }
        [Display(Name = "Select your status")]
        public string Priority { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
