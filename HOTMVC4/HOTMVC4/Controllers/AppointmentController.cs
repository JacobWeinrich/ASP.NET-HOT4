using HOTMVC4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOTMVC4.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentsAppContext _context;

        public AppointmentController(AppointmentsAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult New(int id)
        {
            Customer? customer = _context.Customers.Find(id);

            if (customer == null)
            {
                TempData["message"] = " Customer not found!";
                return RedirectToAction("Index", "Home");
            }

            Appointment appointment = new Appointment();
            appointment.CustomerId = id;
            appointment.Customer = customer;
            appointment.dateTime = Convert.ToDateTime($"{DateTime.Now.ToShortDateString()} 8:00am").AddDays(1);
            return View(appointment);
        }

        [HttpPost]
        public IActionResult New(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                TempData["message"] = "Appointment added!";
                return RedirectToAction("Index", "Home");
            } else
            {
                appointment.Customer = _context.Customers.Find(appointment.CustomerId)!;
                return View(appointment);
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Appointment> appointments = _context.Appointments.Include(c => c.Customer).OrderBy(a => a.dateTime).Where(t => t.dateTime > DateTime.Now).ToList();
            return View(appointments);
        }
    }
}
