using Microsoft.EntityFrameworkCore;

namespace HOTMVC4.Models
{
    public class AppointmentsAppContext : DbContext
    {
        public AppointmentsAppContext(DbContextOptions<AppointmentsAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                               new Customer
                               {
                                   CustomerId = 1,
                                   Username = "JohnDoe",
                                   PhoneNumber = "(555) 555-5555"
                               },
                                              new Customer
                                              {
                                                  CustomerId = 2,
                                                  Username = "JaneDoe",
                                                  PhoneNumber = "(555) 555-5556"
                                              }
                                                         );
            modelBuilder.Entity<Appointment>().HasData(new Appointment { AppointmentId = 1, dateTime = Convert.ToDateTime("3:00pm 3/16/2024"), CustomerId = 1 });
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
