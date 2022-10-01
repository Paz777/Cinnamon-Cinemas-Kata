using System;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class SeatAllocatorLinearService : ISeatAllocatorService
    {
        Stack<string> seatsToBeAllocated = new Stack<string>();

        public SeatAllocatorLinearService() 
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
            //seatsToBeAllocated.Push("C5");
            //seatsToBeAllocated.Push("C4");
            //seatsToBeAllocated.Push("C3");
            //seatsToBeAllocated.Push("C2");
            //seatsToBeAllocated.Push("C1");
            //seatsToBeAllocated.Push("B5");
            //seatsToBeAllocated.Push("B4");
            //seatsToBeAllocated.Push("B3");
            //seatsToBeAllocated.Push("B2");
            //seatsToBeAllocated.Push("B1");
            //seatsToBeAllocated.Push("A5");
            //seatsToBeAllocated.Push("A4");
            //seatsToBeAllocated.Push("A3");
            //seatsToBeAllocated.Push("A2");
            //seatsToBeAllocated.Push("A1");
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

