using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models
{
    public class percentagepatients
    {
        [Display(Name = "Unvaccinaded people")]
        public int nonVaccinated { get; set; }
        [Display(Name = "Vaccinaded people")]
        public int vaccinated { get; set; }
        [Display(Name = "Total vaccinaded people")]
        public int Tvac { get; set; }

        public int Perc(int vac, int nvac)
        {
            nonVaccinated = nvac;
            vaccinated = vac;
            Tvac = 0;
            if (nvac >= 0)
            {
                Tvac = vac / nvac;
                Tvac %= 100;
            }
            else if (nvac == 0)
            {
                Tvac = 100;
            }
            return Tvac;
        }
    }
}
