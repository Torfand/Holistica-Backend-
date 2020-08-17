using System;
using System.Collections.Generic;
using System.Text;

namespace Holistica.Core._3_Domain_Model
{
    public class Happening
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int CurrentParticipants { get; set; }
        public int MaxParticipants { get; set; }

        public Happening(int id, string name, DateTime date, int price, int currentParticipants, int maxParticipants)
        {
            Id = id;
            Name = name;
            Date = date;
            Price = price;
            CurrentParticipants = currentParticipants;
            MaxParticipants = maxParticipants;
        }
        public Happening()
        {
            
        }
    }
}
