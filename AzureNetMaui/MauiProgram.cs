namespace AzureNetMaui;

using AzureNetMaui.Views;
using AzureNetMaui.Services;
using AzureNetMaui.ViewModels;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<CompanyApiService>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<CustomerListViewModel>();
		builder.Services.AddTransient<CustomerListView>();

        return builder.Build();
	}
}
