using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models.Data
{
    public class Singleton
    {
        //Instancia única
        private readonly static Singleton MCInstance = new Singleton();
        public List<Patients> MClientsList;
        public List<Patients> MCsecondList;
        public List<Patients> MCthirdList;

        //Constructor
        private Singleton()
        {
            MClientsList = new List<Patients>();
            MCsecondList = new List<Patients>();
            MCthirdList = new List<Patients>();
        }

        //método de obtencion de la instancia única
        public static Singleton Instance
        {
            get
            {
                return MCInstance;
            }
        }
    }
}
