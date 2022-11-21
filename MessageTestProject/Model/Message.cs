namespace MessageTestProject.Model
{
    public class Message
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string? Ticker { get; set; }
        public string? ISIN { get; set; }
        public string? CompanyName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}
