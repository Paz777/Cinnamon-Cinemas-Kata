using CinnamonCinemas.Model;
using NUnit.Framework;
using FluentAssertions;

namespace CinnamonCinemas.Tests
{
    public class SeatAllocationServiceTests
    {
        private SeatAllocationLinearService seatAllocationLinearService1;
        private List<string> seats1;
        [SetUp]
        public void Setup()
        {
            seatAllocationLinearService1 = new();
            seats1 = new();
        }

        [Test]
        public void Given_No_Of_Seats_Seat_Allocation_Service_Allocates_Correct_Seats()
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(3);
            seats1[0].Should().Be("A1");
            seats1[1].Should().Be("A2");
            seats1[2].Should().Be("A3");
        }
    }
}

