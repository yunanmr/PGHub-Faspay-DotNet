namespace PGHub.Entity
{
    public class Payment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string prefix { get; set; }
        public string merchant_id { get; set; }
    }
}
