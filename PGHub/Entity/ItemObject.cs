namespace PGHub.Entity
{
    public class ItemObject
    {
        public string Product { get; set; }
        public string Qty { get; set; }
        public string Amount { get; set; }
        public string Payment_plan { get; set; }
        public string Merchant_id { get; set; }
        public string Tenor { get; set; }
        public ItemObject(string product, string qty, string amount, string payment_plan, string merchant_id, string tenor)
        {
            Product = product;
            Qty = qty;
            Amount = amount;
            Payment_plan = payment_plan;
            Merchant_id = merchant_id;
            Tenor = tenor;
        }
    }
}
