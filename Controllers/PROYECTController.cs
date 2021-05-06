using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models.Data;
using Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Controllers
{
    public class PROYECTController : Controller
    {
        // GET: PROYECT
        public ActionResult Index()
        {
            return View(Singleton.Instance.MClientsList);
        }

        // GET: PROYECT/Details/5
        //Detalles completos de la persona
        public ActionResult Details()
        {
            return View(Singleton.Instance.MClientsList);
        }
        //Abre vista de la lista de personas ya vacunados
        public ActionResult VaccinateL()
        {
            return View(Singleton.Instance.MCsecondList);
        }
        //Lista de por vacunar
        public ActionResult VaccinatedList()
        {
            return View(Singleton.Instance.MClientsList);
        }
        //Busqueda de personas en la lista de personas a ser vacunados
        public ActionResult Search(string Name, string LastName, int DPI)
        {
            //busqueda por medio de AVL(llamar clase AVL)
            Singleton.Instance.MClientsList.Clear();
            return View();
        }
        //Abre vista del porcentaje de las personas ya vacunadas
        public ActionResult xVaccinated()
        {
            return View();
        }
        public ActionResult Creategood()
        {
            return View();
        }
        //Crea lista de ya vacunados
        [HttpPost]
        public ActionResult Creategood(IFormCollection collection)
        {
            try
            {
                var pat = new Models.Patients
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    DPI = Convert.ToInt32(collection["DPI"]),
                    town = collection["town"],
                    Department = collection["Department"],
                    job = collection["job"],
                    age = Convert.ToInt32(collection["age"])
                };
                Singleton.Instance.MCsecondList.Add(pat);
                //HASH de personas vacunadas
                return RedirectToAction(nameof(VaccinatedList));
            }
            catch
            {
                return View();
            }
        }
        // GET: PROYECT/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PROYECT/Create
        //Crea lista de no vacunados 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var pat = new Models.Patients
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    DPI = Convert.ToInt32(collection["DPI"]),
                    town = collection["town"],
                    Department = collection["Department"],
                    job = collection["job"],
                    age = Convert.ToInt32(collection["age"])  
                };
                Singleton.Instance.MClientsList.Add(pat);
                //HASH de personas no vacunadas
                //Enviar codigo hash a AVL para ordenar
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PROYECT/Edit/5
        public ActionResult Edit(string Name)
        {
            return View();
        }

        // POST: PROYECT/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patients Namess)
        {
            try
            {
                var ptien = (from m in Singleton.Instance.MClientsList where m.Name == Namess.Name select m).First();
                if (!ModelState.IsValid)
                {
                    return View(ptien);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PROYECT/Delete/5
        public ActionResult Delete(string Name)
        {
            return View();
        }

        // POST: PROYECT/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string Name, IFormCollection collection)
        {
            try
            {
                var sr = Singleton.Instance.MClientsList.Find(c => c.Name == Name);
                Singleton.Instance.MClientsList.Remove(sr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
