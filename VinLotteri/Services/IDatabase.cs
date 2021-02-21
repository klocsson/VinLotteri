using System.Collections.Generic;
using VinLotteri.Models;

namespace VinLotteri.Services
{
    public interface IDatabase
    {
        IEnumerable<Ticket> GetTickets();
        void AddTicket(Ticket ticket);
    }
}