using HOTMVC4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOTMVC4.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppointmentsAppContext _context;

        public CustomerController(AppointmentsAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult New()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult New(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("New", "Appointment", new { id = customer.CustomerId });
            } else
            {
                return RedirectToAction("New", "Customer");
            }
        }

        [HttpGet]
        public IActionResult Existing()
        {
            List<Customer> list;
            list = _context.Customers.ToList();

            return View(list);
        }
    }
}
