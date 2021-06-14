using Calendar.Data;
using Calendar.Models;
using Calendar.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using JsonResult = System.Web.Mvc.JsonResult;

namespace Calendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
                               ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CalendarData()
        {
            List<Event> events = await _context.Event.ToListAsync();


            HomeIndexViewModel model = new();
            List<EventData> temp = new();
            

            foreach (var item in events)
            {
                Patient Patient = await _context.Patient.FirstOrDefaultAsync(p => p.Id == item.PatientId);

                if (item.PatientId != 0)
                {
                    EventData eventData = new()
                    {
                        id = item.Id.ToString(),
                        title = Patient.FullName,
                        type = item.Type,
                        start = $"{item.Date.ToString("yyyy-MM-dd")}T{item.Start.TimeOfDay}",
                        end = $"{item.End.ToString("yyyy-MM-dd")}T{item.End.TimeOfDay}",
                    };
                    temp.Add(eventData);
                }
                else
                {
                    EventData eventData = new()
                    {
                        id = item.Id.ToString(),
                        title = item.Name,
                        start = $"{item.Date.ToString("yyyy-MM-dd")}T{item.Start.TimeOfDay}",
                        end = $"{item.End.ToString("yyyy-MM-dd")}T{item.End.TimeOfDay}",
                    };
                    temp.Add(eventData);
                }

            }

            model.events = temp.ToArray();


            return Json(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
