using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IDatabase db, IRandom randomService)
        {
            TicketsList = new TicketsListViewModel(db);
            Drawing = new DrawingViewModel(db, randomService);
        }

        public TicketsListViewModel TicketsList { get; }
        
        public DrawingViewModel Drawing { get; }
    }
}