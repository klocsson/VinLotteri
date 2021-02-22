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
        private List<Ticket> shuffledTickets = new List<Ticket>();

        private Ticket winingTicket;
        private string winner;

        private int progress;

        private IDatabase db;
        private IRandom randomService;

        private bool isVisible;
        
        public DrawingViewModel(IDatabase db, IRandom randomService)
        {
            this.db = db;
            this.randomService = randomService;
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
            await initDrawing();

            winingTicket = shuffledTickets[winners.First()];
            winners.RemoveAt(0);

            Winner = winingTicket.Name;
            IsVisible = false;

            await generateProgress();
            IsVisible = true;
        }

        private async Task initDrawing()
        {
            if (shuffleOrder == null)
            {
                tickets = db.GetTickets().ToList();
                shuffleOrder = await randomService.getRandomNumbers(0, tickets.Count - 1, tickets.Count);
                winners = await randomService.getRandomNumbers(0, tickets.Count - 1, 10);
                foreach (var index in shuffleOrder)
                {
                    shuffledTickets.Add(tickets[index]);
                }
            }
        }

        private async Task generateProgress()
        {
            for (int i = 1; i <= 100; i++)
            {
                Progress = i;
                await Task.Delay(10);
            }
        }
    }
}