using BH.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BH.Frontend.Web.Pages
{
    public class DetailsModel : PageModel
    {
        [FromQuery]
        public Guid ID { get; set; }

        public CustomerDetailsResponse CustomerDetails { get; set; }

        public async void OnGet()
        {
            this.CustomerDetails = await GetCustomerDetailsAsync(this.ID);
        }

        private async Task<CustomerDetailsResponse> GetCustomerDetailsAsync(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://app-bhdemo-be.azurewebsites.net/api/Customer/{id}");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string resultContentString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerDetailsResponse>(resultContentString);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }
    }
}
