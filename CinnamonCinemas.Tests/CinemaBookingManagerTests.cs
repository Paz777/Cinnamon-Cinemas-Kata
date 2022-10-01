using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Tests;

public class CinemaBookingManagerTests
{
    CinemaBookingManager cinemaBookingManager1;

    [SetUp]
    public void Setup()
    {
        cinemaBookingManager1 = new CinemaBookingManager();
    }

    [Test]
    public void Given_A_Customer_And_Movie_Showing_Book_The_No_Of_Tickets_And_Allocate_Seats()
    {
        Customer customer1 = new Customer("Billie");
        ISeatAllocationService seatAllocation1 = new SeatAllocationLinearService();
        Movie movie1 = new Movie("The Matrix", new DateTime(2022, 9, 30, 9, 0, 0), seatAllocation1);
        int noOfTickets = 3;
        cinemaBookingManager1.MakeABooking(customer1, movie1, noOfTickets);
        List<string> bookings = cinemaBookingManager1.GetBookings;
        bookings[0].Should().Be("Billie has booked for The Matrix showing 30/9/2022 for 9:00 am seats A1, A2, A3");
    }

}