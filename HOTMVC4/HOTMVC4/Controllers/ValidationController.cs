using HOTMVC4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOTMVC4.Controllers
{
    public class ValidationController : Controller
    {
        private readonly AppointmentsAppContext _context;

        public ValidationController(AppointmentsAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CheckAppointmentDate(DateTime dateTime)
        {
            DateTime today = DateTime.Now;
            if (dateTime.Minute == 0)
            {
                if (dateTime.Day > today.Day)
                {
                    if (_context.Appointments.Any(a => a.dateTime == dateTime))
                    {
                        return Json("Appointment Time Already Taken");
                    }
                    else
                    {
                        return Json(true);
                    }
                } else
                {
                    return Json("Appointment Must be placed 1 day in advance!");
                }

            }
            else
            {
                return Json("Appointment Time must be on the Hour!");
            }
        }
    }
}
