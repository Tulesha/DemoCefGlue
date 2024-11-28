using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using DemoCefGlue.Views;
using System.Threading.Tasks;

namespace DemoCefGlue.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private async Task Click(Window window)
    {
        var cefGlueWindow = new CefGlueWindow();
        await cefGlueWindow.ShowDialog(window);
    }
}
