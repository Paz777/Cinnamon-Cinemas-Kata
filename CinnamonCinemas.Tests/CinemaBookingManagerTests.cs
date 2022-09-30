using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Tests;

public class CinemaBookingManagerTests
{
    CinemaBookingManager cinemaBookingManager;

    [SetUp]
    public void Setup()
    {
        cinemaBookingManager = new CinemaBookingManager();
    }

    [Test]
    public void Given_A_Customer_And_Movie_Showing_Book_The_No_Of_Tickets_And_Allocate_Seats()
    {
        Customer customer = new Customer("Billie");
        Movie movie = new Movie("The Matrix", new DateTime(2022, 9, 30, 09, 0, 0));
        int noOfTickets = 3;
        cinemaBookingManager.MakeABooking(customer, movie, noOfTickets);
        List<string> bookings = cinemaBookingManager.GetBookings;
        bookings[0].Should().Be("Billie has booked for The Matrix showing 30/9/2022 for 9:00 am seats A1, A2, A3");
    }

}