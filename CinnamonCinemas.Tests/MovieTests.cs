using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;
using CinnamonCinemas.Interface;
using CinnamonCinemas.Exceptions;

namespace CinnamonCinemas.Tests
{
    public class MovieTests
    {
        private ISeatAllocationService seatAllocationLinearService1;
        private Movie movie1;

        [SetUp]
        public void Setup()
        {
            seatAllocationLinearService1 = new SeatAllocationLinearService();
            movie1 = new Movie("The Matrix", new DateTime(2022, 9, 30, 9, 0, 0), seatAllocationLinearService1);
        }

        [Test]
        public void Given_A_Movie_That_Has_A_Booking_For_3_Seats_BookSeats_Method_Should_Allocate_Seats()
        {
            var seats1 = movie1.BookSeats(3);
            var expectedSeats = new List<string> { "A1", "A2", "A3" };
            seats1.Should().Equal(expectedSeats);
        }

        [Test]
        public void Given_A_Movie_Which_Has_Seats_Booked_And_Then_A_Booking_For_2_New_Seats_BookSeats_Method_Should_Allocate_Seats()
        {
            movie1.BookSeats(3);
            var seats1 = movie1.BookSeats(2);
            var expectedSeats = new List<string> { "A1", "A2", "A3", "A4", "A5" };
            seats1.Should().Equal(expectedSeats);
        }

        [Test]
        public void Given_A_Movie_With_All_Seats_Allocated_Then_BookSeats_Method_Should_Not_Book_More_Seats_But_Get_Exception()
        {
            movie1.BookSeats(15);
            movie1.Invoking(x => x.BookSeats(2))
                .Should().Throw<SeatAllocationException>()
                .WithMessage("All seats have been taken - no seats allocated");
        }

        [Test]
        public void Given_A_Movie_Which_Has_Seats_Booked_And_Then_A_Booking_For_No_Seats_BookSeats_Method_Should_Return_Correct_Allocated_Seats()
        {
            movie1.BookSeats(3);
            movie1.Invoking(x => x.BookSeats(0))
                .Should().Throw<SeatAllocationException>()
                .WithMessage("It is not possible to allocate 0 seats - input error");
        }
    }
}

