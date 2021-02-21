using System.Collections.Generic;

namespace VinLotteri.Services
{
    public interface IRandom
    {
        List<int> getRandomNumbers(int from, int to, int size);
    }
}