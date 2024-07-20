using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task.Models;

namespace task.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Complaints/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complaints/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                _context.Complaints.Add(complaint);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaint);
        }

        // GET: Complaints
        public ActionResult Index(string searchString)
        {
            var complaints = from c in _context.Complaints
                             select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                complaints = complaints.Where(s => s.CustomerName.Contains(searchString));
            }

            return View(complaints.ToList());
        }
        // GET: Complaints/Edit/5
        public ActionResult Edit(int id)
        {
            var complaint = _context.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(complaint).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaint);
        }
    }
}