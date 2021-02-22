using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class DrawingViewModel : ViewModelBase
    {
        int numberOfPrizes;
        private List<int> shuffleOrder;
        private List<int> winners;
        private IDatabase db;
        private IRandom randomService;
        
        public DrawingViewModel(IDatabase db, IRandom randomService)
        {
            this.db = db;
            this.randomService = randomService;
            Draw = ReactiveCommand.Create(draw);
        }
        
        public int NumberOfPrizes
        {
            get => NumberOfPrizes;
            set => this.RaiseAndSetIfChanged(ref numberOfPrizes, value);
        }

        public ReactiveCommand<Unit, Unit> Draw { get; }

        private async void draw()
        {
            var tickets = db.GetTickets().ToList();
            shuffleOrder = await randomService.getRandomNumbers(1, tickets.Count, tickets.Count);
            
        }
    }
}