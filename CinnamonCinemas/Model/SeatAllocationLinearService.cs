using CinnamonCinemas.Exceptions;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class SeatAllocationLinearService : ISeatAllocationService
    {
        Stack<string> seatsToBeAllocated = new();
        private int noSeatsAvailable = 0;

        public SeatAllocationLinearService() 
        {
            SetUpSeatsToAllocate();
        }

        private void SetUpSeatsToAllocate()
        {
            List<string> rows = new List<string>() { "C", "B", "A" };
            List<int> seatNos = new List<int>() { 5, 4, 3, 2, 1 };
            rows.ForEach(row => seatNos.ForEach(seatNo => seatsToBeAllocated.Push(row + seatNo)));
        }

        public List<string> AllocateSeats(int noOfSeats)
        {
            if (noOfSeats == 0)
                throw new SeatAllocationException("It is not possible to allocate 0 seats - input error");

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

