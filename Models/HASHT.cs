using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models
{
    public class HASHT
    {
        public List<Patients>[] array;
        public List<Patients> Papv;
        public int Fhash(string Name, string LastName)
        {
            //Modificar para recibir valor
            int Code = (Name.Length * LastName.Length);
            Code %= 100;
            return Code;
        }
        //a
        public HASHT(int Cant)
        {
            array = new List<Patients>[Cant];
            for (int i = 0; i < Cant; i++)
            {
                array[i] = new List<Patients>();
            }
        }
    }
}
