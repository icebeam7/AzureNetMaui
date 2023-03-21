using AzureNetMaui.ViewModels;

namespace AzureNetMaui.Views;

public partial class CustomerListView : ContentPage
{
	public CustomerListView(CustomerListViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}