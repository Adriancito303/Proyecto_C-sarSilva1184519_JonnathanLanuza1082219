﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models.Data
{
    public class Singleton
    {
        //Instancia única
        private readonly static Singleton MCInstance = new Singleton();
        public List<PRY> MClientsList;
        public List<PRY> SecondMClientsList;

        //Constructor
        private Singleton()
        {
            MClientsList = new List<PRY>();
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
