using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using VinLotteri.Models;
using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class DrawingViewModel : ViewModelBase
    {
        private List<int> shuffleOrder;
        private List<int> winners;
        private List<Ticket> tickets;
        private List<string> expandedTickets = new List<string>();
        private List<string> shuffledTickets = new List<string>();

        private string winingTicket;
        private string winner;

        private int progress;

        private IDatabase db;
        private IDrawingService drawingService;

        private bool isVisible;
        
        public DrawingViewModel(IDatabase db, IDrawingService drawingService)
        {
            this.db = db;
            this.drawingService = drawingService;
            Draw = ReactiveCommand.Create(draw);
        }

        public bool IsVisible
        {
            get => isVisible;
            set => this.RaiseAndSetIfChanged(ref isVisible, value);
        }
        
        public int Progress
        {
            get => progress;
            set => this.RaiseAndSetIfChanged(ref progress, value);
        }
        
        public string Winner
        {
            get => winner;
            set => this.RaiseAndSetIfChanged(ref winner, value);
        }

        public ReactiveCommand<Unit, Unit> Draw { get; }
 
        private async void draw()
        {
            IsVisible = false;
            
            var drawingTask = getDrawingData();
            await generateProgress();
            await drawingTask;

            if (winners.Count > 0)
            {
                winingTicket = shuffledTickets[winners.First()];
                winners.RemoveAt(0);
                Winner = winingTicket;
                
                IsVisible = true;
            }
        }
        
        private async Task getDrawingData()
        {
            if (shuffleOrder == null)
            {
                tickets = db.GetTickets().ToList();
                expandTickets(tickets);
                
                shuffleOrder = await drawingService.getShufflingOrder(0, expandedTickets.Count - 1, expandedTickets.Count);
                winners = await drawingService.getWinners(0, expandedTickets.Count - 1);
                foreach (var index in shuffleOrder)
                {
                    shuffledTickets.Add(expandedTickets[index]);
                }
            }
        }

        private void expandTickets(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                for (int i = 0; i < ticket.NrOfTickets; i++)
                {
                    expandedTickets.Add(ticket.Name);
                }
            }
        }

        private async Task generateProgress()
        {
            for (int i = 1; i <= 100; i++)
            {
                Progress = i;
                await Task.Delay(13);
            }
        }
    }
}