using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HOTMVC4.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Appointment Date is Required")]
        [Remote("CheckAppointmentDate", "Validation", areaName: "")]
        public DateTime dateTime { get; set; }

        [Required(ErrorMessage = "Customer is Required")]
        public int? CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;
    }
}
