using System.Reactive;
using ReactiveUI;
using VinLotteri.Services;

namespace VinLotteri.ViewModels
{
    public class DrawingViewModel : ViewModelBase
    {
        int numberOfPrizes;
        private IDatabase db;
        
        public DrawingViewModel(IDatabase db, IRandom randomService)
        {
            this.db = db;
            Draw = ReactiveCommand.Create(draw);
        }
        
        public int NumberOfPrizes
        {
            get => NumberOfPrizes;
            set => this.RaiseAndSetIfChanged(ref numberOfPrizes, value);
        }
        
        public ReactiveCommand<Unit, Unit> Draw { get; }

        private void draw()
        {
            
        }
    }
}