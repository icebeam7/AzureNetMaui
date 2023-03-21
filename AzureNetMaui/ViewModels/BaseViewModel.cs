using CommunityToolkit.Mvvm.ComponentModel;

namespace AzureNetMaui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;
    }
}
