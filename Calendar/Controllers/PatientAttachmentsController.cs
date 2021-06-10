using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calendar.Data;
using Calendar.Models;

namespace Calendar.Controllers
{
    public class PatientAttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientAttachments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PatientAttachment.Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PatientAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientAttachment = await _context.PatientAttachment
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientAttachment == null)
            {
                return NotFound();
            }

            return View(patientAttachment);
        }

        // GET: PatientAttachments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PatientAttachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Created,TicketId,UserId,FileName,FileData,FileContentType")] PatientAttachment patientAttachment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientAttachment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", patientAttachment.UserId);
            return View(patientAttachment);
        }

        // GET: PatientAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientAttachment = await _context.PatientAttachment.FindAsync(id);
            if (patientAttachment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", patientAttachment.UserId);
            return View(patientAttachment);
        }

        // POST: PatientAttachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Created,TicketId,UserId,FileName,FileData,FileContentType")] PatientAttachment patientAttachment)
        {
            if (id != patientAttachment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientAttachment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientAttachmentExists(patientAttachment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", patientAttachment.UserId);
            return View(patientAttachment);
        }

        // GET: PatientAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientAttachment = await _context.PatientAttachment
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientAttachment == null)
            {
                return NotFound();
            }

            return View(patientAttachment);
        }

        // POST: PatientAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientAttachment = await _context.PatientAttachment.FindAsync(id);
            _context.PatientAttachment.Remove(patientAttachment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientAttachmentExists(int id)
        {
            return _context.PatientAttachment.Any(e => e.Id == id);
        }
    }
}
