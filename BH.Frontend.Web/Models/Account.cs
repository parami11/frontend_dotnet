namespace BH.Frontend.Web.Models
{
    public class Account
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }

        public string AccountNumber { get; set; } = string.Empty;

        public double CurrentBalance { get; set; }
    }
}
