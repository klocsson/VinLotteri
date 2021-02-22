using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinLotteri.Services
{
    public interface IRandom
    {
        public Task<List<int>> getRandomNumbers(int @from, int to, int size, bool replacement = false);
        
    }
}