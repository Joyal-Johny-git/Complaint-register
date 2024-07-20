using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task.Models;

namespace task.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Assignments/Edit/5
        public ActionResult Edit(int id)
        {
            var assignment = _context.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }

            // Fetch technicians based on work category
            var technicians = _context.Technicians
                .Where(t => t.WorkCategory == _context.Complaints
                    .Where(c => c.ComplaintID == assignment.ComplaintID)
                    .Select(c => c.WorkCategory)
                    .FirstOrDefault())
                .ToList();

            ViewBag.Technicians = new SelectList(technicians, "TechnicianID", "Name", assignment.TechnicianID);

            return View(assignment);
        }

        // POST: Assignments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(assignment).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Re-populate dropdown list in case of error
            var technicians = _context.Technicians
                .Where(t => t.WorkCategory == _context.Complaints
                    .Where(c => c.ComplaintID == assignment.ComplaintID)
                    .Select(c => c.WorkCategory)
                    .FirstOrDefault())
                .ToList();

            ViewBag.Technicians = new SelectList(technicians, "TechnicianID", "Name", assignment.TechnicianID);

            return View(assignment);
        }
    }
}