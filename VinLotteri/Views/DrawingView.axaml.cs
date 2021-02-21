using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VinLotteri.Views
{
    public class DrawingView : UserControl
    {
        public DrawingView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}