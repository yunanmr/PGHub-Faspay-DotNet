using Microsoft.AspNetCore.Mvc;
using PGHub.DataAccess;
using PGHub.Entity;
using System.Collections.Generic;

namespace PGHub.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PaymentController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public PaymentController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return _dataAccessProvider.GetPaymentRecords();
        }

        [HttpGet("{code}")]
        public Payment Details(string code)
        {
            return _dataAccessProvider.GetPaymentSingleRecord(code);
        }

    }
}
