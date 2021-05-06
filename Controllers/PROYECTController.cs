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
    //Priority 1
    //Priority 2a
    //Priority 2b
    //Priority 3
    //Priority 4
    public class PROYECTController : Controller
    {
        // GET: PROYECT
        int vac = 0;
        int nvac = 0;
        public percentagepatients patper = new percentagepatients();
        public List<Patients> busqueda = new List<Patients>();
        public Patients Fecha = new Patients();
        //Modificar tamaño tabla hash
        public HASHT tableH = new HASHT(100);
        public ActionResult Index()
        {
            Singleton.Instance.MCsecondList.Clear();
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
        [HttpPost]
        public ActionResult Search(string Name, string LastName, int DPI)
        {
            ViewData["SearchName"] = Name;
            ViewData["SearchLastName"] = LastName;
            ViewData["SearchDPI"] = DPI;
            busqueda = Singleton.Instance.MClientsList;

            if (Name != null)
            {
                for (int i = 0; i < busqueda.Count(); i++)
                {
                    if (busqueda[i].Name == Name)
                    {
                        Singleton.Instance.MCsecondList.Add(busqueda[i]);
                    }
                }
                return View(Singleton.Instance.MCsecondList);
            }
            else if (LastName != null)
            {
                for (int i = 0; i < busqueda.Count(); i++)
                {
                    if (busqueda[i].LastName == LastName)
                    {
                        Singleton.Instance.MCsecondList.Add(busqueda[i]);
                    }
                }
                return View(Singleton.Instance.MCsecondList);
            }
            else if (DPI > 0)
            {
                for (int i = 0; i < busqueda.Count(); i++)
                {
                    if (busqueda[i].DPI == DPI)
                    {
                        Singleton.Instance.MCsecondList.Add(busqueda[i]);
                    }
                }
                return View(Singleton.Instance.MCsecondList);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            //busqueda por medio de AVL(llamar clase AVL)
        }
        //Abre vista del porcentaje de las personas ya vacunadas
        public ActionResult xVaccinated()
        {
            return View();
        }
        [HttpPost]
        public ActionResult xVaccinated(int vac, int nvac)
        {
            return View(patper.Perc(vac, nvac));
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
                    Priority = collection["job"]
                    //Date = collection["Date"].ToString("dd/MM/yyyy")
                };
                Singleton.Instance.MCsecondList.Add(pat);
                vac += 1;
                //HASH de personas vacunadas
                int Code = tableH.Fhash(pat.Name, pat.LastName);
                tableH.array[Code].Add(pat);
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
                    Priority = collection["job"]
                    //Date = collection["Date"].ToString("dd/MM/yyyy")
                };
                Singleton.Instance.MClientsList.Add(pat);
                nvac += 1;
                //HASH de personas no vacunadas
                int Code = tableH.Fhash(pat.Name, pat.LastName);
                tableH.array[Code].Add(pat);
                //Enviar codigo hash a AVL para ordenar
                //AVLPatients.Add(pat.DPI);--------------------------------------------------------------------
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
        public ActionResult Delete(int Dpi)
        {
            //var sr = Singleton.Instance.MClientsList.Find(c => c.Name == Name);
            //for (int i = 0; i < Singleton.Instance.MClientsList.Count(); i++)
            //{
            //    do
            //    {
            //        Singleton.Instance.MClientsList.Remove(sr);
            //    } while (Name == Singleton.Instance.MClientsList[i].Name);
            //}
            //return View("Search", Singleton.Instance.MClientsList);
            return View();
        }

        // POST: PROYECT/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int dpi, IFormCollection collection)
        {
            try
            {
                var st = Singleton.Instance.MClientsList.Find(x => x.DPI == dpi);
                Singleton.Instance.MClientsList.Remove(st);
                return View("Search", st);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
