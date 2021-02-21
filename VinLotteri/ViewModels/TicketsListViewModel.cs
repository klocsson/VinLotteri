using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using VinLotteri.Models;

namespace VinLotteri.ViewModels
{
    public class TicketsListViewModel : ViewModelBase
    {
        string name;
        int numberOfTickets;
        
        public TicketsListViewModel(IEnumerable<Ticket> tickets)
        {
            Tickets = new ObservableCollection<Ticket>(tickets);
            var addEnabled = this.WhenAnyValue(
                t => t.Name,
                t => t.NumberOfTickets,
                (s, i) => !string.IsNullOrWhiteSpace(s) && 
                           !string.IsNullOrWhiteSpace(i.ToString()) && i > 0);
            
            AddTicket = ReactiveCommand.Create(
                () => new Ticket { Name = Name, NrOfTickets = NumberOfTickets}, 
                addEnabled);
        }

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public int NumberOfTickets
        {
            get => numberOfTickets;
            set => this.RaiseAndSetIfChanged(ref numberOfTickets, value);
        }

        public ObservableCollection<Ticket> Tickets { get; }
        
        public ReactiveCommand<Unit, Ticket> AddTicket { get; }
    }
}