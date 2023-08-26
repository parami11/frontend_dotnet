namespace BH.Frontend.Web.Models
{
    public class AccountDetailsResponse
    {
        public Account Account { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
