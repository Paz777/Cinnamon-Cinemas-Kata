using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class Movie
    {
        public string Title { get; private set; }
        public DateTime Showing { get; private set; }
        public List<string> Seats { get; private set; }

        public Movie(string title, DateTime showing)
        {
            Title = title;
            Showing = showing;
            Seats = new List<string>();
        }

        public Movie(string title, DateTime showing, ISeatAllocatorService seatAllocatorService)
        {
            Title = title;
            Showing = showing;
            Seats = new List<string>();
        }

        public List<string> BookSeats(int noOfSeats)
        {
            Seats.Add("A1");
            Seats.Add("A2");
            Seats.Add("A3");
            return Seats;
        }
    }
}

