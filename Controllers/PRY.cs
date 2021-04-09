using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_CésarSilva1184519_JonnathanLanuza1082219.Controllers
{
    public class PRY : Controller
    {
        // GET: PRY
        public ActionResult Index()
        {
            return View();
        }

        // GET: PRY/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PRY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRY/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PRY/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PRY/Edit/5
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

        // GET: PRY/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PRY/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
