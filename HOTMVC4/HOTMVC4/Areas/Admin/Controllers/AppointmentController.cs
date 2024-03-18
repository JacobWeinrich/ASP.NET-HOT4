using HOTMVC4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOTMVC4.Areas.Admin.Controllers
{
 
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentsAppContext _context;

        public AppointmentController(AppointmentsAppContext context)
        {
            _context = context;
        }

        [Route("admin/appointments")]
        public IActionResult Index()
        {
            List<Appointment> appointments = _context.Appointments.Include(c => c.Customer).OrderBy(a => a.dateTime).Where(t => t.dateTime > DateTime.Now).ToList();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Appointment appointment = _context.Appointments.Include(c => c.Customer).FirstOrDefault(a => a.AppointmentId == id)!;

            if (appointment == null)
            {
                TempData["message"] = "Appointment not found";
                return RedirectToAction("Index", "Appointment");
            } else
            {
                return View(appointment);
            }

        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                TempData["message"] = $"Appointment Id: {appointment.AppointmentId} Updated";
                return RedirectToAction("Index", "Appointment");
            }
            return View(appointment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Appointment appointment = _context.Appointments.Include(c => c.Customer).FirstOrDefault(a => a.AppointmentId == id)!;
            if (appointment == null)
            {
                TempData["message"] = "Appointment not found";
                return RedirectToAction("Index", "Appointment");
            } else
            {
                return View(appointment);
            }
        }

        [HttpPost]
        public IActionResult Delete(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            TempData["message"] = $"Appointment Id: {appointment.AppointmentId} Deleted";
            return RedirectToAction("Index", "Appointment");
        }
    }
}
