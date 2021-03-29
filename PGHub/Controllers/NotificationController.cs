using Microsoft.AspNetCore.Mvc;
using PGHub.DataAccess;
using PGHub.Utils;
using PGHub.Entity;
using System;
using System.Linq;

namespace PGHub.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class NotificationController : ControllerBase
    {
        private readonly PostgreSqlContext _context;

        public NotificationController(PostgreSqlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Edit([FromBody] Transaction transaction)
        {
            var entity = _context.transactions.FirstOrDefault(i => i.trx_id == transaction.trx_id);
            DateTime now = DateTime.Now;
            string sign = DiggestUtils.sha1(DiggestUtils.md5("bot33608p@ssw0rd" + transaction.bill_no + transaction.payment_status_code));
            Console.WriteLine(sign);
            if (transaction.signature != sign)
                return Ok(new NotificationResponse("Bad Request", "01", "Gagal", now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":")));
            if (entity == null)
                return Ok(new NotificationResponse("Not Found", "01", "Gagal", now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":")));
            if (ModelState.IsValid)
            {
                entity.signature = transaction.signature;
                entity.payment_channel_uid = transaction.payment_channel_uid;
                entity.payment_total = transaction.payment_total;
                entity.payment_reff = transaction.payment_reff;
                entity.payment_date = transaction.payment_date;
                entity.payment_status_code = transaction.payment_status_code;
                entity.payment_status_desc = transaction.payment_status_desc;
                _context.transactions.Update(entity);
                _context.SaveChanges();
                return Ok(new NotificationResponse("Payment Notification", "00", "Sukses", now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":"), entity.trx_id, entity.merchant_id, entity.bill_no));
            }

            return Ok(new NotificationResponse("Bad Request", "01", "Gagal", now.ToString("yyyy-MM-dd HH:mm:ss").Replace(".", ":")));
        }

    }
}
