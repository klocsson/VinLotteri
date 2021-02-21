using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using VinLotteri.Models;
using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class TicketsListViewModel : ViewModelBase
    {
        string? name;
        int numberOfTickets;

        private Ticket selectedItem;
        
        public TicketsListViewModel(IDatabase db)
        {
            Tickets = new ObservableCollection<Ticket>(db.GetTickets());
            var addEnabled = this.WhenAnyValue(
                t => t.Name,
                t => t.NumberOfTickets,
                (s, i) => !string.IsNullOrWhiteSpace(s) && 
                           !string.IsNullOrWhiteSpace(i.ToString()) && i > 0);
            
            AddTicket = ReactiveCommand.Create(
                () =>
                {
                    var ticket = new Ticket {Name = Name, NrOfTickets = NumberOfTickets};
                    Tickets.Add(ticket);
                    db.AddTicket(ticket);
                }, 
                addEnabled);
            
            DeleteTicket = ReactiveCommand.Create(
                () =>
                {
                    db.DeleteTicket(SelectedItem);
                    Tickets.Remove(SelectedItem);
                });
        }

        public Ticket SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
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
        
        public ReactiveCommand<Unit, Unit> AddTicket { get; }
        public ReactiveCommand<Unit, Unit> DeleteTicket { get; }
    }
}