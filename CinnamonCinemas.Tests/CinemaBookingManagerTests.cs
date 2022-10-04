using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;
using CinnamonCinemas.Interface;

namespace CinnamonCinemas.Tests;

public class CinemaBookingManagerTests
{
    CinemaBookingManager cinemaBookingManager1;
    ISeatAllocationService seatAllocation1;

    [SetUp]
    public void Setup()
    {
        cinemaBookingManager1 = new CinemaBookingManager();
        seatAllocation1 = new SeatAllocationLinearService();
    }

    [Test]
    public void Given_A_Customer_And_Movie_Showing_Book_The_No_Of_Tickets_And_Allocate_Seats()
    {
        Customer customer1 = new Customer("Billie");
        Movie movie1 = new Movie("The Matrix", new DateTime(2022, 9, 30, 9, 0, 0), seatAllocation1);
        int noOfTickets = 3;
        cinemaBookingManager1.MakeABooking(customer1, movie1, noOfTickets);
        List<string> bookings = cinemaBookingManager1.BookingsMade;
        bookings[0].Should().Be("Billie has booked for The Matrix showing 30/9/2022 for 9:00 am seats A1, A2, A3");
    }

    [Test]
    public void Given_Two_Customers_And_Movie_Showing_Book_Multiple_Tickets_And_Allocate_Seats()
    {
        Customer customer1 = new Customer("Billie");
        Customer customer2 = new Customer("Jhonnie");
        Movie movie1 = new Movie("The Hunger Games", new DateTime(2022, 10, 03, 17, 0, 0), seatAllocation1);
        cinemaBookingManager1.MakeABooking(customer1, movie1, 3);
        cinemaBookingManager1.MakeABooking(customer1, movie1, 3);
        cinemaBookingManager1.MakeABooking(customer1, movie1, 3);
        cinemaBookingManager1.MakeABooking(customer2, movie1, 3);
        cinemaBookingManager1.MakeABooking(customer1, movie1, 3);
        List<string> bookings = cinemaBookingManager1.BookingsMade;
        bookings[0].Should().Be("Billie has booked for The Hunger Games showing 03/10/2022 for 5:00 pm seats A1, A2, A3");
        bookings[1].Should().Be("Billie has booked for The Hunger Games showing 03/10/2022 for 5:00 pm seats A4, A5, B1");
        bookings[2].Should().Be("Billie has booked for The Hunger Games showing 03/10/2022 for 5:00 pm seats B2, B3, B4");
        bookings[3].Should().Be("Jhonnie has booked for The Hunger Games showing 03/10/2022 for 5:00 pm seats B5, C1, C2");
        bookings[4].Should().Be("Billie has booked for The Hunger Games showing 03/10/2022 for 5:00 pm seats C3, C4, C5");
    }

}