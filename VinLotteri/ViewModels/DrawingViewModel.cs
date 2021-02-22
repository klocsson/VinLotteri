using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class DrawingViewModel : ViewModelBase
    {
        private List<int> shuffleOrder;
        private List<int> winners;

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

        public ReactiveCommand<Unit, Unit> Draw { get; }
 
        private async void draw()
        {
            IsVisible = false;
            var tickets = db.GetTickets().ToList();
            await generateProgress();
            IsVisible = true;
            shuffleOrder = await randomService.getRandomNumbers(1, 10, 5);
        }

        private async Task generateProgress()
        {
            for (int i = 1; i <= 100; i++)
            {
                Progress = i;
                await Task.Delay(15);
            }
        }
    }
}