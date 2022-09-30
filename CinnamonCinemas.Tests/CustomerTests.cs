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
        public void Given_A_List_Of_Seats_It_Should_Be_Allocated_To_Customer()
        {
            List<string> seats = new List<string>() { "A1", "A2", "A3" };
            Customer customer1 = new Customer("Billie");
            customer1.AllocateTickets(seats);
            customer1.Tickets.Should().Be("A1, A2, A3");
        }
    }
}

