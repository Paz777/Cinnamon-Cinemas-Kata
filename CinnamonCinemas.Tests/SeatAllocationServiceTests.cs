using CinnamonCinemas.Model;
using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Exceptions;

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
        public void Given_Three_Seats_Seat_Allocation_Service_Allocates_Correct_Seats()
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(3);
            var expectedSeats = new List<string> { "A1", "A2", "A3" };
            seats1.Should().Equal(expectedSeats);
        }

        [Test]
        public void Given_Seats_Already_Allocated_Then_Three_Seats_Seat_Allocation_Service_Allocates_Correct_Seats()
        {
            seatAllocationLinearService1.AllocateSeats(5);
            seats1 = seatAllocationLinearService1.AllocateSeats(3);
            var expectedSeats = new List<string> { "B1", "B2", "B3" };
        }

        [Test]
        public void Given_All_Seats_Already_Allocated_Seat_Allocation_Service_Should_Throw_Exception()
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(15);
            seatAllocationLinearService1.Invoking(x => x.AllocateSeats(5))
                .Should().Throw<SeatAllocationException>()
                .WithMessage("All seats have been taken - no seats allocated");
        }

        [TestCase(0, TestName = "Given_Zero_Seats_Seat_Allocation_Service_Should_Return_Empty")]
        [TestCase(-4, TestName = "Given_Minus_Seats_Seat_Allocation_Service_Should_Return_Empty")]
        public void Zero_Seats_Seat_Allocation_Service_Tests(int noOfSeats)
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(noOfSeats);
            seats1.Should().BeEmpty();
        }

        [TestCase(10, 0, TestName = "Given_Some_Seats_Already_Allocated_Then_Zero_Seats_Seat_Allocation_Service_Should_Return_Empty")]
        [TestCase(15, 0, TestName = "Given_All_Seats_Already_Allocated_Then_Zero_Seats_Seat_Allocation_Service_Should_Return_Empty")]
        public void Some_Or_All_Seats_Allocated_Then_Zero_Seat_Allocation_Service_Tests(int seatsAllocated, int noSeatsToAllocate)
        {
            seatAllocationLinearService1.AllocateSeats(seatsAllocated);
            seats1 = seatAllocationLinearService1.AllocateSeats(noSeatsToAllocate);
            seats1.Should().BeEmpty();
        }
    }
}

