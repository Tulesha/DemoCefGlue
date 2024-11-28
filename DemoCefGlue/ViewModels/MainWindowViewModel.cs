using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using DemoCefGlue.Views;

namespace DemoCefGlue.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    [RelayCommand]
    private void Click(Window window)
    {
        var cefGlueWindow = new CefGlueWindow();
        cefGlueWindow.ShowDialog(window);
    }
}