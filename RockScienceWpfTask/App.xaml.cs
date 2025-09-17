using System.Windows;

namespace RockScienceWpfTask;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Optional: Setup dependency injection container here
        // var container = new Container();
        // container.RegisterSingleton<IDialogService, DialogService>();
    }
}

