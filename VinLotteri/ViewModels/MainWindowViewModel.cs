using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IDatabase db, IDrawingService drawingServiceService)
        {
            TicketsList = new TicketsListViewModel(db);
            Drawing = new DrawingViewModel(db, drawingServiceService);
        }

        public TicketsListViewModel TicketsList { get; }
        
        public DrawingViewModel Drawing { get; }
    }
}