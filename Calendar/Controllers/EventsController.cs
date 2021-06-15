using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calendar.Data;
using Calendar.Models;
using Microsoft.AspNetCore.Authorization;
using Calendar.Models.ViewModels;

namespace Calendar.Controllers
{   
   [Authorize] 
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        public int PatientId { get; set; }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            Patient Patient = await _context.Patient.FirstOrDefaultAsync(p => p.Id == @event.PatientId);
            
            if (@event == null)
            {
                return NotFound();
            }

            EventDetailsViewModel model = new()
            {
                Event = @event,
                Patient = Patient
            };

            return View(model);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName");
            TempData["Status"] = "";
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,PatientId,CalendarId,Name,Type,Description,Date,Start,End")] Event @event)
        {
            if (ModelState.IsValid)
            {

                //@event.Start = new DateTime(@event.Date.Date, @event.Start.TimeOfDay);
                @event.Start = new DateTime(@event.Date.Year, @event.Date.Month, @event.Date.Day, @event.Start.Hour, @event.Start.Minute, @event.Start.Second);

                //@event.End = new DateTimeOffset(@event.Date.Date,@event.End.TimeOfDay);
                @event.End = new DateTime(@event.Date.Year, @event.Date.Month, @event.Date.Day, @event.End.Hour, @event.End.Minute, @event.End.Second);


                // bool overlap = (event1.start < event2.end) && (event2.start < event1.end);
                var events =await  _context.Event.ToListAsync();

                bool overlap = events.Any(e => e.Start < @event.End && @event.Start < e.End);

                if (overlap == false && @event.Start >= DateTime.Now)
                {
                    if(@event.Type == "0")
                    {
                        @event.Type = "Initial Evaluation";
                    }
                    else if(@event.Type == "1")
                    {
                        @event.Type = "Follow-Up";
                    }
                    _context.Add(@event);
                    await _context.SaveChangesAsync();
                    TempData["Status"] = "Success";
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName");
            TempData["Status"] = "Fail";

            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            int? patientId = @event.PatientId;
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FullName", patientId);
            TempData["Status"] = "";
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,CalendarId,Name,Type,Description,Date,Start,End")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    @event.Start = new DateTime(@event.Date.Year, @event.Date.Month, @event.Date.Day, @event.Start.Hour, @event.Start.Minute, @event.Start.Second);

                    @event.End = new DateTime(@event.Date.Year, @event.Date.Month, @event.Date.Day, @event.End.Hour, @event.End.Minute, @event.End.Second);


                    var events = await _context.Event.Where(e => e.Id != @event.Id).ToListAsync();

                    bool overlap = events.Any(e => e.Start < @event.End && @event.Start < e.End);

                    if (overlap == false && @event.Start >= DateTime.Now)
                    {
                        if (@event.Type == "0")
                        {
                            @event.Type = "Initial Evaluation";
                        }
                        else if (@event.Type == "1")
                        {
                            @event.Type = "Follow-Up";
                        }
                        _context.Update(@event);
                        await _context.SaveChangesAsync();
                        TempData["Status"] = "Success";
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Status"] = "Fail";
                return View(@event);
            }
            TempData["Status"] = "Fail";
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
