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
    public class AppointmentCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AppointmentComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AppointmentComment.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AppointmentComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentComment = await _context.AppointmentComment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentComment == null)
            {
                return NotFound();
            }

            return View(appointmentComment);
        }

        // GET: AppointmentComments/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AppointmentComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Comment,Created,AppointmentId,UserId")] AppointmentComment appointmentComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", appointmentComment.UserId);
            return View(appointmentComment);
        }

        // GET: AppointmentComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentComment = await _context.AppointmentComment.FindAsync(id);
            if (appointmentComment == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", appointmentComment.UserId);
            return View(appointmentComment);
        }

        // POST: AppointmentComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,Created,AppointmentId,UserId")] AppointmentComment appointmentComment)
        {
            if (id != appointmentComment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentCommentExists(appointmentComment.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", appointmentComment.UserId);
            return View(appointmentComment);
        }

        // GET: AppointmentComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentComment = await _context.AppointmentComment
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentComment == null)
            {
                return NotFound();
            }

            return View(appointmentComment);
        }

        // POST: AppointmentComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentComment = await _context.AppointmentComment.FindAsync(id);
            _context.AppointmentComment.Remove(appointmentComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentCommentExists(int id)
        {
            return _context.AppointmentComment.Any(e => e.Id == id);
        }
    }
}
