using System;
using CinnamonCinemas.Exceptions;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class SeatAllocationLinearService : ISeatAllocationService
    {
        Stack<string> seatsToBeAllocated = new Stack<string>();
        private int noSeatsAvailable = 0;

        public SeatAllocationLinearService() 
        {
            SetUpStack();
        }

        private void SetUpStack()
        {
            List<string> rows = new List<string>() { "C", "B", "A" };
            foreach (string row in rows)
            {
                for (int i = 5; i > 0; i--)
                {
                    seatsToBeAllocated.Push(row + i);
                }
            }
        }

        public List<string> AllocateSeats(int noOfSeats)
        {
            List<string> seats = new();
            for (int i = 0; i < noOfSeats; i++)
            {
                if (seatsToBeAllocated.Count == noSeatsAvailable)
                    throw new SeatAllocationException("All seats have been taken - no seats allocated");
                seats.Add(seatsToBeAllocated.Pop());
            }
            return seats;
        }
    }
}

