using System;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class SeatAllocationLinearService : ISeatAllocationService
    {
        Stack<string> seatsToBeAllocated = new Stack<string>();

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
            List<string> seats = new List<string>();
            for (int i = 0; i < noOfSeats; i++)
            {
                seats.Add(seatsToBeAllocated.Pop());
            }
            return seats;
        }
    }
}

