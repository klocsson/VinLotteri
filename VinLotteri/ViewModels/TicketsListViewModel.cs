using System.Collections.Generic;
using System.Collections.ObjectModel;
using VinLotteri.Models;

namespace VinLotteri.ViewModels
{
    public class TicketsListViewModel : ViewModelBase
    {
        public TicketsListViewModel(IEnumerable<Ticket> tickets)
        {
            Tickets = new ObservableCollection<Ticket>(tickets);
        }

        public ObservableCollection<Ticket> Tickets { get; }
    }
}