using System.Collections.Generic;
using VinLotteri.Models;

namespace VinLotteri.Services
{
    public class Database
    {
        public IEnumerable<Ticket> GetTickets() => new[]
        {
            new Ticket { Name = "Michal", NrOfTickets = 5},
            new Ticket { Name = "Gard", NrOfTickets = 3},
        };
    }
}