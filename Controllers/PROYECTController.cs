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
        public ActionResult Details()
        {
            return View(Singleton.Instance.MClientsList);
        }   
        public ActionResult VaccinatedList()
        {
            return View(Singleton.Instance.MClientsList);
        }
        public ActionResult Search(string Name, string LastName, int DPI)
        {
            Singleton.Instance.MClientsList.Clear();
            return View();
        }
        public ActionResult xVaccinated()
        {
            return View();
        }
        // GET: PROYECT/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PROYECT/Create
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PROYECT/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PROYECT/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
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
                //Singleton.Instance.MClientsList.Clear();
                //if ()
                //{

                //}
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
