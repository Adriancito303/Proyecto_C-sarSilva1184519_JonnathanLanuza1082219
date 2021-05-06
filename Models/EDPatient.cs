using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models
{
    public class EDPatient
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
