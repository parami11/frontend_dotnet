using BH.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BH.Frontend.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public List<Customer> Customers { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            this.Customers = await GetCustomersAsync();
        }

        private async Task<List<Customer>> GetCustomersAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://app-bhdemo-be.azurewebsites.net/api/Customer");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                string resultContentString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Customer>>(resultContentString).ToList();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return null;
        }
    }
}