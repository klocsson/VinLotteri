using System;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
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
                IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                Console.WriteLine(Directory.GetCurrentDirectory());

                var apiKey = configuration["random_api_key"];
                var db = new Database();
                var random = new RandomOrg(apiKey);
                
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(db, random),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}