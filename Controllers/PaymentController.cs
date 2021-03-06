using Microsoft.AspNetCore.Mvc;
using FluentVal_Task.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FluentVal_Task.Controllers
{
    [ApiController]
    [Route("card")]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly FluentContext _context;
        public PaymentController(FluentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPayment()
        {
            var pa = _context.Payments;
            return Ok(new {message = "success retrieve data", status = true, data = pa});
        }

        [HttpPost]
        public IActionResult PostPayment(ReqPay payment)
        {
            _context.Payments.Add(payment.data.attributes);
            _context.SaveChanges();
            return Ok(payment);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var pa = _context.Payments.First(i => i.Id == id);
            return Ok(pa);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, ReqPay payment)
        {
            var pa = _context.Payments.First(i => i.Id == id);
            pa.NameOnCard = payment.data.attributes.NameOnCard;

            _context.Payments.Update(pa);
            _context.SaveChanges();
            return Ok(pa);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var pa = _context.Payments.First(i => i.Id == id);
            _context.Payments.Remove(pa);
            _context.SaveChanges();
            return Ok(pa);
        }
    }

    public class ReqPay
    {
        public Pay data { get; set; }
    }

    public class Pay
    {
        public Payment attributes { get; set; }
    }
}