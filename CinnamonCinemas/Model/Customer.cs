using System;

namespace CinnamonCinemas.Model
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Tickets { get; private set; }

        public Customer(string name)
        {
            Name = name;
            Tickets = string.Empty;
        }

        public void AllocateTickets(List<string> seats)
            => Tickets = string.Join(", ", seats);
    }
}

