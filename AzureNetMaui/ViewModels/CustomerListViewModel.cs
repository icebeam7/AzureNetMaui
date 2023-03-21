using System.Collections.ObjectModel;

using AzureNetMaui.Models;
using AzureNetMaui.Services;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AzureNetMaui.ViewModels
{
    public partial class CustomerListViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; } = new();

        IConnectivity connectivity;
        CompanyApiService companyService;

        public CustomerListViewModel(CompanyApiService companyService, IConnectivity connectivity)
        {
            Title = "Customers List";
            this.connectivity = connectivity;
            this.companyService = companyService;
        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetCustomersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var customers = await companyService.GetCustomers();

                    if (Customers.Count != 0)
                        Customers.Clear();

                    foreach (var c in customers)
                        Customers.Add(c);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}
