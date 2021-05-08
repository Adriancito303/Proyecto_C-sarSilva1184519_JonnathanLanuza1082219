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
using System.Web;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Controllers
{
    #region LISTPRIORITYS
    //Priority 1 -> Health Personnel
    //Priority 2a -> Age over 70
    //Priority 2b -> Age between 51 and 70
    //Priority 3 -> Essential worker
    //Priority 4 -> Age between 18 and 50
    #endregion

    public class PROYECTController : Controller
    {
        #region EXTRAS
        public static int vac = 0;
        public static int nvac = 0;
        public percentagepatients patper = new percentagepatients();
        public List<Patients> busqueda = new List<Patients>();
        public Patients Fecha = new Patients();
        public List<Patients> simulacion = new List<Patients>();
        public List<Patients> register = new List<Patients>();
        public HASHT tableH = new HASHT(100);
        public HASHT2 tableH2 = new HASHT2(100);
        public List<Patients> mover = new List<Patients>();
        #endregion
        // GET: PROYECT
        //Modificar tamaño tabla 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult move()
        {
            return View();
        }
        #region Simulacion
        public ActionResult Simulation()
        {
            Singleton.Instance.MCsecondList.Clear();
            return View(Singleton.Instance.MClientsList);
        }
        #endregion
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
        //Busqueda de personas en la lista de personas a ser vacunados
        [HttpPost]
        public ActionResult Search(string Name, string LastName, int DPI, string Priority)
        {
            ViewData["SearchName"] = Name;
            ViewData["SearchLastName"] = LastName;
            ViewData["SearchDPI"] = DPI;
            ViewData["SearchPriority"] = Priority;
            busqueda = Singleton.Instance.MClientsList;
            #region Search
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
            else if (Priority != null)
            {
                for (int i = 0; i < busqueda.Count(); i++)
                {
                    if (busqueda[i].Priority == Priority)
                    {
                        Singleton.Instance.MCsecondList.Add(busqueda[i]);
                    }
                }
                return View(Singleton.Instance.MCsecondList);
            }
            else
            {
                return RedirectToAction(nameof(Simulation));
            }
            //busqueda por medio de AVL(llamar clase AVL)
            #endregion
        }
        //Abre vista del porcentaje de las personas ya vacunadas
        public ActionResult xVaccinated()
        {
            patper.nonVaccinated = nvac;
            patper.vaccinated = vac;
            int total = vac + nvac;
            if (nvac == 0)
            {
                patper.Tvac = 100;
            }
            else
            {
                patper.Tvac = ((vac*100) / total);
            }
            return View(patper);
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
                //string dpi = collection["DPI"].ToString();
                //if (dpi.Length != 13)
                //{
                //    ModelState.AddModelError("DPI", "Please enter 13-digit DPI number");
                //    return View("Create");
                //}
                var pat = new Models.Patients
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    DPI = Convert.ToInt32(collection["DPI"]),
                    town = collection["town"],
                    Department = collection["Department"],
                    Priority = collection["Priority"],
                    Date = Convert.ToDateTime(collection["Date"])
                };
                Singleton.Instance.MCsecondList.Add(pat);
                vac = vac + 1;
                //HASH de personas no vacunadas
                int Code = tableH2.Fhash(pat.Name, pat.LastName);
                tableH2.array[Code].Add(pat);
                #region envio
                //Enviar codigo hash a AVL para ordenar
                //AVLPatients.Add(pat.DPI);
                #endregion
                return RedirectToAction(nameof(VaccinateL));
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
                //validar dpi de 13 digitos
                //string dpi = collection["DPI"].ToString();
                //if (dpi.Length != 13)
                //{
                //    ModelState.AddModelError("DPI", "Please enter 13-digit DPI number");
                //    return View("Create");
                //}
                var pat = new Models.Patients
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    DPI = Convert.ToInt32(collection["DPI"]),
                    town = collection["town"],
                    Department = collection["Department"],
                    Priority = collection["Priority"],
                    Date = Convert.ToDateTime(collection["Date"])
                };
                Singleton.Instance.MClientsList.Add(pat);
                nvac = nvac + 1;
                //HASH de personas no vacunadas
                int Code = tableH.Fhash(pat.Name, pat.LastName);
                tableH.array[Code].Add(pat);
                #region envio
                //Enviar codigo hash a AVL para ordenar
                //AVLPatients.Add(pat.DPI);
                #endregion
                return RedirectToAction(nameof(Simulation));
            }
            catch
            {
                return View();
            }
        }

        // GET: PROYECT/Edit/5
        public ActionResult Edit(DateTime date)
        {
            var std = Singleton.Instance.MClientsList.Where(s => s.Date == date).FirstOrDefault();
            return View(std);
        }

        // POST: PROYECT/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patients std, IFormCollection collection)
        {
            try
            {
                var Date = std.Date;
                return RedirectToAction(nameof(Simulation));
            }
            catch
            {
                return View();
            }
        }

        // GET: PROYECT/Delete/5
        public ActionResult Delete(int Dpi)
        {
            return View();
        }

        // POST: PROYECT/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int dpi, IFormCollection collection)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    mover[i] = Singleton.Instance.MClientsList[i];
                    Singleton.Instance.MCsecondList.Add(Singleton.Instance.MClientsList[i]);
                    Singleton.Instance.MClientsList.Remove(mover[i]);
                }
                return View();
            }
            catch
            {
                return RedirectToAction(nameof(Simulation));
            }
        }
    }
}
