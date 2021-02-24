using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinLotteri.Services
{
    public interface IDrawingService
    {
        
        public Task<List<int>> getShufflingOrder(int @from, int to, int size, bool replacement = false);
        
        public Task<List<int>> getWinners(int @from, int to, bool replacement = false);
        
    }
}