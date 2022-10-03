using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class Movie
    {
        public string Title { get; private set; }
        public DateTime Showing { get; private set; }
        public List<string> Seats { get; private set; }
        private ISeatAllocationService seatAllocationService;

        public Movie(string title, DateTime showing, ISeatAllocationService seatAllocationService)
        {
            Title = title;
            Showing = showing;
            this.seatAllocationService = seatAllocationService;
            Seats = new List<string>();
        }

        public List<string> BookSeats(int noOfSeats)
        {
            return seatAllocationService.AllocateSeats(noOfSeats);
        }
            
    }
}

