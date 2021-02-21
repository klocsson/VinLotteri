using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IDatabase db)
        {
            TicketsList = new TicketsListViewModel(db);
        }

        public TicketsListViewModel TicketsList { get; }
    }
}