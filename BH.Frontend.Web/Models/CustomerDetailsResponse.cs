namespace BH.Frontend.Web.Models
{
    public class CustomerDetailsResponse
    {
        public Customer Customer { get; set; }

        public List<AccountDetailsResponse> Accounts { get; set; }
    }
}
