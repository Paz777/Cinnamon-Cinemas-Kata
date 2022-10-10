# Cinnamon Cinemas Kata

## Cinnamon Cinemas Kata using TDD and C#

As part of the Tech Returners training programme, I am learning and utilising the skills of Test Driven Development and C# for the Cinnamon Cinemas Kata. Currently there is a test coverage of over 15 tests.

## Setting the Scene

There is a special task from Cinnamon Cinemas to develop a program to allocate seats to customers purchasing tickets for a movie theatre.

## Project Brief

The Cinnamon Cinemas Movie Theatre has 15 seats, arranged in 3 rows of 5

* Rows are assigned a letter from A to C
* Seats are assigned a number from 1 to 5

Acceptance Criteria and Assumptions

* Seats are allocated based on a random integer “number of seats” between 1 and 3
* It should allocate the required number of seats from the available seats starting from seat A1 and filling the auditorium from left to right, front to
back
* All of the seats are available for sale when the program starts
* The program should continue to allocate a random number of seats until it finds there are not enough seats left to complete the request
* Once there are not enough seats available to be allocated then the program can halt

## Project Setup

The solution has 2 projects. The main implementation is separated into model, interface and exception. The test project has been split into movie tests, customer tests, cinema booking manager tests and seat allocaiton service tests.

The Cinema Booking Manager class takes the customer, movie and the no of tickets to make the booking. Inputs are currently done through tests.

## Project Development

The project allowed me to develop my TDD skills and I wanted to implement my learning of dependancy injection and data structures. I created an interface called ISeatAllocationService which would allocate seats as per the requirements from A1 to C5 from a stack. If in the future a new seat allocation is needed like seat selection or persisting to a data store it could implement the interface.  

I choose to keep the project simple without creating a seat class and holding information in strings to start with.

Exceptions I implemented was SeatException.

## Updates To Implement

* Implement appropriate classes like Seat.
* Persist data in database.
* Implement a different Seat Allocation Service for seat selection.
* Implement a clearer folder structure seperating layers
