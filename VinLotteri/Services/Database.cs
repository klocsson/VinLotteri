using System;
using System.Collections.Generic;
using LiteDB;
using VinLotteri.Models;

namespace VinLotteri.Services
{
    public class Database : IDatabase
    {
        public IEnumerable<Ticket> GetTickets()
        {
            using(var db = new LiteDatabase("vinLotteri.db"))
            {
                var tickets =  db.GetCollection<Ticket>("tickets");

                var today = DateTime.Now.Date.ToShortDateString();

                return tickets.Query()
                    .Where(t => t.PurchaseDate.Equals(today))
                    .OrderBy(t => t.Name)
                    .ToList();
            }
        }

        public void AddTicket(Ticket ticket)
        {
            using(var db = new LiteDatabase("vinLotteri.db"))
            {
                var tickets =  db.GetCollection<Ticket>("tickets");
                var today = DateTime.Now.Date.ToShortDateString();

                ticket.PurchaseDate = today;

                tickets.Insert(ticket);
            }
        }
        
        public void DeleteTicket(Ticket ticket)
        {
            using(var db = new LiteDatabase("vinLotteri.db"))
            {
                var tickets =  db.GetCollection<Ticket>("tickets");

                tickets.DeleteMany(t => t.Name == ticket.Name && t.NrOfTickets == ticket.NrOfTickets && t.PurchaseDate == ticket.PurchaseDate);
            }
        }
    }
}