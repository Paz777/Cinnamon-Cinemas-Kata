using System;

namespace CinnamonCinemas.Model
{
    public class CinemaBookingManager
    {
        public List<string> GetBookings { get;}

        public CinemaBookingManager()
        {
            GetBookings = new List<string>();
        }

        public void MakeABooking(Customer customer, Movie movie, int noOfTickets)
        {
            List<string> seats = movie.BookSeats(3);
            customer.AllocateTickets(seats);
        }
    }
}

