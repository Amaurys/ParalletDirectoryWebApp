using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParalletDirectoryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ViewBag.Folders = _context.Folders.ToList().OrderBy(x => x.Folderid)
                .Select(x => new
                {
                    Folderid = x.Folderid,
                    Location = x.Location + "/" + x.Name
                });
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
        public ActionResult Edit(int id)
        {
            var folders = _context.Folders.ToList();

            ViewBag.Folders = folders.Select(a => new
            {
                Folderid = a.Folderid,
                Location = a.Location
            }).Where(b => b.Folderid == id).Union(
                folders.OrderBy(x => x.Folderid)
                .Select(x => new
                {
                    Folderid = x.Folderid,
                    Location = x.Location + "/" + x.Name
                }).Where(y => y.Folderid != id)
                );

            var model = _context.Folders.Find(id);
            return View(model);
        }

        // POST: FolderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Folder model)
        {


            _context.Update(model);
            _context.SaveChanges();

            return View();
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
