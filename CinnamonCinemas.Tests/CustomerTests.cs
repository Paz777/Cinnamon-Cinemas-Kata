using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas.Model;

namespace CinnamonCinemas.Tests
{
    public class CustomerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_A_Customer_With_A_List_Of_Seats_It_Should_Be_Allocated_To_Their_Tickets()
        {
            List<string> seats1 = new List<string>() { "A1", "A2", "A3" };
            Customer customer1 = new Customer("Billie");
            customer1.AllocateTickets(seats1);
            customer1.Tickets.Should().Be("A1, A2, A3");
        }

        [Test]
        public void Given_A_Customer_Has_Two_Seat_Lists_To_Allocate_It_Should_Be_Added_To_Their_Tickets()
        {
            List<string> seats1 = new List<string>() { "A1", "A2", "A3" };
            List<string> seats2 = new List<string>() { "A4", "A5", "B1" };
            Customer customer1 = new Customer("Billie");
            customer1.AllocateTickets(seats1);
            customer1.AllocateTickets(seats2);
            customer1.Tickets.Should().Be("A1, A2, A3, A4, A5, B1");
        }
    }
}

