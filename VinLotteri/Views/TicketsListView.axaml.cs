using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Tickets.Views
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