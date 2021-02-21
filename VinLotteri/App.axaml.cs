using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using VinLotteri.Services;
using VinLotteri.ViewModels;
using VinLotteri.Views;

namespace VinLotteri
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var db = new Database();
                var random = new RandomOrg();
                
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(db, random),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}