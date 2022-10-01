using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Tests
{
    public class MovieTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_A_Movie_That_Has_A_Booking_For_3_Seats_BookSeats_Method_Should_Allocate_Seats()
        {
            Movie movie1 = new Movie("The Matrix", new DateTime(2022, 9, 30, 9, 0, 0));
            List<string> seats = movie1.BookSeats(3);
            seats[0].Should().Be("A1");
            seats[1].Should().Be("A2");
            seats[2].Should().Be("A3");
        }

        [Test]
        public void Given_A_Movie_Which_Has_Seats_Booked_And_Then_A_Booking_For_2__New_Seats_BookSeats_Method_Should_Allocate_Seats()
        {
            ISeatAllocatorService seatAllocator = new SeatAllocatorLinearService();
            Movie movie1 = new Movie("The Matrix", new DateTime(2022, 9, 30, 9, 0, 0), seatAllocator);
            movie1.BookSeats(3);
            List<string> seats = movie1.BookSeats(2);
            seats[3].Should().Be("A4");
            seats[4].Should().Be("A5");
        }
    }
}

