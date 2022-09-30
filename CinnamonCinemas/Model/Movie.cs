using System;
namespace CinnamonCinemas.Model
{
    public class Movie
    {
        public string Title { get; private set; }
        public DateTime Showing { get; private set; }

        public Movie(string title, DateTime showing)
        {
            Title = title;
            Showing = showing;
        }

        public List<string> BookSeats(int noOfSeats)
        {
            throw new NotImplementedException();
        }
    }
}

