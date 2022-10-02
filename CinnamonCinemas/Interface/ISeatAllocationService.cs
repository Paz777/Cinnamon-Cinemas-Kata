namespace CinnamonCinemas.Interface
{
    public interface ISeatAllocationService
    {

        public List<string> AllocateSeats(int noOfSeats);
    }
}

