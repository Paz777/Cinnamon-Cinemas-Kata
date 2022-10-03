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
            if (noOfTickets > 3)
            {
                throw new Exception("Can not book more than 3 seats - no booking made");
            }
            List<string> seats = movie.BookSeats(3);
            customer.AllocateTickets(seats);
            GetBookings.Add($"{customer.Name} has booked for {movie.Title} showing {movie.Showing.ToString("dd/M/yyyy")} " +
                $"for {movie.Showing.ToString("h:mm tt")} seats {customer.Tickets}");
        }
    }
}

