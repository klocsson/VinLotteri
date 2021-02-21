using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VinLotteri.Views
{
    public class TicketsListView : UserControl
    {
        public TicketsListView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}