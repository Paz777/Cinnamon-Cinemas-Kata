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
            seats1[0].Should().Be("A1");
            seats1[1].Should().Be("A2");
            seats1[2].Should().Be("A3");
        }

        [Test]
        public void Given_Seats_Already_Allocated_Then_Three_Seats_Seat_Allocation_Service_Allocates_Correct_Seats()
        {
            seatAllocationLinearService1.AllocateSeats(5);
            seats1 = seatAllocationLinearService1.AllocateSeats(3);
            seats1[0].Should().Be("B1");
            seats1[1].Should().Be("B2");
            seats1[2].Should().Be("B3");
        }

        [Test]
        public void Given_All_Seats_Already_Allocated_Seat_Allocation_Service_Should_Throw_Exception()
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(15);
            var ex = Assert.Throws<SeatAllocationException>(() => seatAllocationLinearService1.AllocateSeats(5));
            ex.Message.Should().Be("All seats have been taken - no seats allocated");
        }

        [Test]
        public void Given_Seats_Already_Allocated_Then_Zero_Seats_Seat_Allocation_Service_Should_Return_Empty_Seat_List()
        {
            seatAllocationLinearService1.AllocateSeats(10);
            seats1 = seatAllocationLinearService1.AllocateSeats(0);
            seats1.Count.Should().Be(0);
        }

        [Test]
        public void Given_All_Seats_Already_Allocated_Then_Zero_Seats_Seat_Allocation_Service_Should_Return_Empty_Seat_List()
        {
            seatAllocationLinearService1.AllocateSeats(15);
            seats1 = seatAllocationLinearService1.AllocateSeats(0);
            seats1.Count.Should().Be(0);
        }

        [Test]
        public void Given_Minus_Seats__Seat_Allocation_Service_Should_Return_Empty_Seat_List()
        {
            seats1 = seatAllocationLinearService1.AllocateSeats(-4);
            seats1.Count.Should().Be(0);
        }
    }
}

