namespace PGHub.Entity
{
    public class NotificationResponse
    {
        public string Response { get; protected set; }
        public string Trx_id { get; protected set; }
        public string Merchant_id { get; protected set; }
        public string Bill_no { get; protected set; }
        public string Response_code { get; protected set; }
        public string Response_desc { get; protected set; }
        public string Response_date { get; protected set; }

        public NotificationResponse(string response, string response_code, string response_desc, string response_date, string trx_id = null, string merchant_id = null, string bill_no = null)
        {
            Response = response;
            Trx_id = trx_id;
            Merchant_id = merchant_id;
            Bill_no = bill_no;
            Response_code = response_code;
            Response_desc = response_desc;
            Response_date = response_date;
        }

    }
}
