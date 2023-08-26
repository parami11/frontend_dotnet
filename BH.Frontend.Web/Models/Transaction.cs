namespace BH.Frontend.Web.Models
{
    public class Transaction
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public Guid AccountId { get; set; }

        public TransactionType TransactionType { get; set; }

        public double Amount { get; set; }

        
    }
}
