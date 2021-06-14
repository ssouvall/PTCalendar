using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calendar.Data;
using Calendar.Models;
using Calendar.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Calendar.Controllers
{
    [Authorize]
    public class VisitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visit.ToListAsync());
        }

        // GET: Visits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var visit = await _context.Visit
                .FirstOrDefaultAsync(m => m.Id == id);
            Patient patient = await _context.Patient.FirstOrDefaultAsync(p => p.Id == visit.PatientId);
            if (visit == null)
            {
                return NotFound();
            }


            VisitDetailsViewModel model = new()
            {
                Visit = visit,
                Patient = patient

            };

            return View(model);
        }

        // GET: Visits/Create

        [Authorize(Roles = "PhysicalTherapist")]
        public IActionResult Create()
        {

            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName");

            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,VisitType,Date,Start,End,Subjective,Objective,Assessment,Plan")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visit);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Patients", new { id = visit.PatientId });
            }
            return View(visit);
        }

        // GET: Visits/Edit/5
        [Authorize(Roles = "PhysicalTherapist")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit.FindAsync(id);
            int patientId = visit.PatientId;
            if (visit == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName", patientId);
            return View(visit);
        }
        [Authorize(Roles = "PhysicalTherapist")]
        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,VisitType,Date,Start,End,Subjective,Objective,Assessment,Plan")] Visit visit)
        {
            if (id != visit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Patients", new { id = visit.PatientId });
            }
            return View(visit);
        }
        [Authorize(Roles = "PhysicalTherapist")]
        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }
        [Authorize(Roles = "PhysicalTherapist")]
        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visit = await _context.Visit.FindAsync(id);
            int patientId = (await _context.Patient.FirstOrDefaultAsync(p => p.Id == visit.PatientId)).Id;
            _context.Visit.Remove(visit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Patients", new { id = patientId });
        }

        private bool VisitExists(int id)
        {
            return _context.Visit.Any(e => e.Id == id);
        }
    }
}
