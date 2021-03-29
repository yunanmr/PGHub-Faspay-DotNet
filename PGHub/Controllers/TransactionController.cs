using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PGHub.DataAccess;
using PGHub.Entity;
using PGHub.Utils;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PGHub.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;


        public TransactionController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                string sign = DiggestUtils.sha1(DiggestUtils.md5("bot33608p@ssw0rd" + transaction.bill_no));
                var client = new HttpClient();

                ItemObject[] item = new ItemObject[] { new ItemObject(transaction.bill_desc, "1", transaction.bill_total, "1", transaction.merchant_id, "00") };
                var data = new PostObject { merchant_id = "33608", bill_no = transaction.bill_no, bill_date = transaction.bill_date, bill_expired = transaction.bill_expired, bill_desc = transaction.bill_desc, bill_currency = transaction.bill_currency, bill_total = transaction.bill_total, cust_no = transaction.cust_no, cust_name = transaction.cust_name, payment_channel = transaction.payment_channel, pay_type = "1", msisdn = transaction.msisdn, email = transaction.email, terminal = "21", item = item, signature = sign };
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://dev.faspay.co.id/cvr/300011/10", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                var resp = JsonConvert.DeserializeObject<UrlResponse>(apiResponse);


                transaction.payment_status_code = "0";
                transaction.trx_id = resp.Trx_id;
                transaction.merchant_id = resp.Merchant_id;
                transaction.pay_type = data.pay_type;
                transaction.terminal = data.terminal;
                _dataAccessProvider.AddTransactionRecord(transaction);
                return Ok(transaction);
            }
            return BadRequest("Eror");
        }

        [HttpGet("{id}")]
        public Transaction Details(string id)
        {
            return _dataAccessProvider.GetTransactionSingleRecord(id);
        }
        public class UrlResponse
        {
            public string Response { get; set; }
            public string Trx_id { get; set; }
            public string Merchant_id { get; set; }
            public string Merchant { get; set; }
            public string Bill_no { get; set; }
            public object Bill_items { get; set; }
            public string Response_code { get; set; }
            public string Response_desc { get; set; }
            public string Redirect_url { get; set; }
            public object Response_error { get; set; }
        }
    }
}
