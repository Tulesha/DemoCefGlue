using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Xilium.CefGlue.Avalonia;

namespace DemoCefGlue.Views;

public partial class CefGlueWindow : Window
{
    public CefGlueWindow()
    {
        InitializeComponent();
        
        var browser = new AvaloniaCefBrowser();
        browser.Address = "https://www.google.com";
        browserWrapper.Child = browser;
    }
}