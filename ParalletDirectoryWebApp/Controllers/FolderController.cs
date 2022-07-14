using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParalletDirectoryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParalletDirectoryWebApp.Controllers
{
    public class FolderController : Controller
    {
        private readonly ParallelContext _context;

        public FolderController(ParallelContext context)
        {
            _context = context;
        }

        // GET: FolderController
        public ActionResult Index()
        {
            var model = _context.Folders.ToList();
            return View(model);
        }
        //s
        // GET: FolderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FolderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FolderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Folder model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        // GET: FolderController/Edit/5
        public ActionResult Edit(Folder model)
        {
            _context.Update(model);
            _context.SaveChanges();

            return View();
        }

        // POST: FolderController/Edit/5
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

        // GET: FolderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FolderController/Delete/5
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
