using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(Database db)
        {
            TicketsList = new TicketsListViewModel(db.GetTickets());
        }

        public TicketsListViewModel TicketsList { get; }
    }
}