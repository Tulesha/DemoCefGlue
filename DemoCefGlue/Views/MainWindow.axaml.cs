using Avalonia.Controls;
using Xilium.CefGlue.Avalonia;

namespace DemoCefGlue.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var browser = new AvaloniaCefBrowser();
        browser.Address = "https://www.google.com";
        browserWrapper.Child = browser;
    }
}