using System;
namespace CinnamonCinemas.Interface
{
    public interface ISeatAllocatorService
    {

        public List<string> AllocateSeats(int noOfSeats);
    }
}

