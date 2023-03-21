using System.Net.Http.Json;

using AzureNetMaui.Models;

namespace AzureNetMaui.Services
{
    public class CompanyApiService
    {
        HttpClient httpClient;

        public CompanyApiService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var response = await httpClient.GetAsync("https://customersapilb7.azurewebsites.net/api/customers");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Customer>>();

            return default;
        }
    }
}
