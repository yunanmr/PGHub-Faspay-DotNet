using Microsoft.AspNetCore.Mvc;
using PGHub.DataAccess;
using PGHub.Utils;
using PGHub.Entity;
using System.Linq;

namespace PGHub.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InquiryController : ControllerBase
    {
        private readonly PostgreSqlContext _context;

        public InquiryController(PostgreSqlContext context)
        {
            _context = context;
        }

        [HttpGet("{va_number}/{signature}.{type?}")]
        public IActionResult Get(string va_number, string signature, string type, string trx_uid = null, string amount = null)
        {

            if (va_number == null || signature == null || type == null)
                return Ok(new InquiryResponse("Bad Request", "01"));
            string sign = DiggestUtils.sha1(DiggestUtils.md5("bot33608p@ssw0rd" + va_number));
            if (sign != signature)
                return Ok(new InquiryResponse("Bad Request", "01"));

            var entity = _context.transactions.Where(i => i.va_number == va_number).Where(i => i.payment_status_code == "0").FirstOrDefault();
            if (entity == null)
                return Ok(new InquiryResponse("Not Found", "01"));

            if (type == "inquiry")
                return Ok(new InquiryResponse("VA Static Response", "00", entity.va_number, entity.bill_total, entity.cust_name));

            if (type == "payment")
            {
                var entity1 = _context.transactions.Where(i => i.va_number == va_number).Where(i => i.payment_status_code == "0").Where(i => i.trx_id == trx_uid).FirstOrDefault();
                if (entity1 == null)
                    return Ok(new InquiryResponse("Not Found", "01"));
                return Ok(new InquiryResponse("VA Static Response", "00", entity1.va_number, entity1.bill_total, entity1.cust_name));
            }

            return Ok(new InquiryResponse("Bad Request", "01"));
        }

    }
}
