using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Model
{
    public class Movie
    {
        public string Title { get; private set; }
        public DateTime Showing { get; private set; }
        public List<string> Seats { get; private set; }
        private ISeatAllocatorService seatAllocatorService;

        public Movie(string title, DateTime showing, ISeatAllocatorService allocatorService)
        {
            Title = title;
            Showing = showing;
            seatAllocatorService = allocatorService;
            Seats = new List<string>();
        }

        public List<string> BookSeats(int noOfSeats)
        {
            Seats.AddRange(seatAllocatorService.AllocateSeats(noOfSeats));
            return Seats;
        }
            
    }
}

