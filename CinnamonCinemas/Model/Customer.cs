using System;
namespace CinnamonCinemas.Model
{
    public class Customer
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}

