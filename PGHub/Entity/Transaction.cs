namespace PGHub.Entity
{
    public class Transaction
    {
        public string trx_id { get; set; }
        public string va_number { get; set; }
        public string bill_no { get; set; }
        public string bill_date { get; set; }
        public string bill_expired { get; set; }
        public string bill_desc { get; set; }
        public string bill_currency { get; set; }
        public string bill_total { get; set; }
        public string cust_no { get; set; }
        public string email { get; set; }
        public string cust_name { get; set; }
        public string msisdn { get; set; }
        public string pay_type { get; set; }
        public string payment_channel { get; set; }
        public string terminal { get; set; }
        public string payment_reff { get; set; }
        public string payment_date { get; set; }
        public string payment_total { get; set; }
        public string payment_status_desc { get; set; }
        public string payment_status_code { get; set; }
        public string payment_channel_uid { get; set; }
        public string signature { get; set; }
        public string merchant_id { get; set; }
    }
}
