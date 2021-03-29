namespace PGHub.Entity
{
    public class InquiryResponse
    {
        public string Response { get; protected set; }
        public string Va_number { get; protected set; }
        public string Amount { get; protected set; }
        public string Cust_name { get; protected set; }
        public string Response_code { get; protected set; }

        public InquiryResponse(string response, string response_code, string va_number = null, string amount = null, string cust_name = null)
        {
            Response = response;
            Va_number = va_number;
            Amount = amount;
            Cust_name = cust_name;
            Response_code = response_code;
        }

    }
}
