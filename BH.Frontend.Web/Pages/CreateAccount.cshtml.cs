using BH.Frontend.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BH.Frontend.Web.Pages
{
    public class CreateAccountModel : PageModel
    {
        public bool IsSuccess { get; set; }

        [FromQuery]
        public Guid Id { get; set; }

        [BindProperty]
        public AccountRequest AccountRequest { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"https://app-bhdemo-be.azurewebsites.net/api/Account/");

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(this.AccountRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("", data);
            if (response.IsSuccessStatusCode)
            {
                this.IsSuccess = true;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
