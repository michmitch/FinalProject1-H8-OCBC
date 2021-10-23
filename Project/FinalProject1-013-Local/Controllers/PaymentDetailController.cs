using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject1_013.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject1_013.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private PaymentDetailContext _context;

        public PaymentDetailController(PaymentDetailContext context)
        {
            this._context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<PaymentDetailItem>> GetAllPaymentDetails()
        {
            _context = HttpContext.RequestServices.GetService(typeof(PaymentDetailContext)) as PaymentDetailContext;
            return _context.GetAllPaymentDetails();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name ="Get")]
        public ActionResult<IEnumerable<PaymentDetailItem>> GetPaymentDetail(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(PaymentDetailContext)) as PaymentDetailContext;
            return _context.GetPaymentDetail(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<IEnumerable<PaymentDetailItem>> InsertPaymentDetail(PaymentDetailItem paymentDetail)
        {
            _context = HttpContext.RequestServices.GetService(typeof(PaymentDetailContext)) as PaymentDetailContext;
            // DateTime releasedateconvert = Convert.ToDateTime(releasedate);
            return _context.InsertPaymentDetail(paymentDetail);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<PaymentDetailItem>> UpdatePaymentDetail(string id, PaymentDetailItem paymentDetail)
        {
            _context = HttpContext.RequestServices.GetService(typeof(PaymentDetailContext)) as PaymentDetailContext;
            return _context.UpdatePaymentDetail(id, paymentDetail);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public string DeletePaymentDetail(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(PaymentDetailContext)) as PaymentDetailContext;
            return _context.DeletePaymentDetail(id);
        }
    }
}
