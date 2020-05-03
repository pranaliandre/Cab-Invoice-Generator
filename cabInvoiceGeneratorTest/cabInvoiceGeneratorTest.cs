///--------------------------------------------------------------------
///   Class:       CabInvoiceGeneratorTest
///   Description: Test for cabInvoiceGeneratorTest
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using NUnit.Framework;
using cabInvoiceGenerator;
using System.Collections.Generic;

namespace cabInvoiceGeneratorTest
{
    public class Tests
    {
        CabInvoiceGenerator invoiceGenerator = null; 
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new CabInvoiceGenerator();
        }
        /// <summary>
        /// Test case for calculate fare for journey
        /// </summary>
        [Test]
        public void GivenDistance_ShouldReturnTotalFare()
        {
            
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance,time);
            Assert.AreEqual(expected:25, fare, delta: 0.0);
        }
        /// <summary>
        /// Test case for given multiple rides  should return fare 
        /// </summary>
        [Test]
        public void MultipleRides_ShouldReturnFareSummary()
        {
            double expected = 60;
            string userId = "sanjivali@315";
            Ride firstRide = new Ride(2.0, 5);
            Ride secondRide = new Ride(0.1, 1);
            List<Ride> rides = new List<Ride> { firstRide, secondRide };
            RideRepository.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(userId);
            Assert.AreEqual(expected, invoiceSummary.TotalFare,0.0);

        }
        /// <summary>
        /// Test case for given multiple rides should return fare summary 
        /// </summary>
        [Test]
        public void MultipleRides_ShouldReturnFareSummary_InvoiceSummary()
        {
            string userId = "kimaya@276";
            Ride firstRide = new Ride(2.0, 5);
            Ride secondRide = new Ride(0.1, 1);
            List<Ride> rides = new List<Ride> { firstRide, secondRide };
            RideRepository.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(userId);
            InvoiceSummary expected = new InvoiceSummary
            { 
                TotalNumberOfRides = 2,
                TotalFare = 30,
                AggregateFarePerRide = 33,
            };
            object.Equals(expected, invoiceSummary);
        }
        /// <summary>
        /// Test case for Given a user id, the Invoice Service gets the List of rides from the RideRepository and returns the Invoice. 
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "aryan@158";
            Ride firstRide = new Ride(2.0, 5);
            Ride secondRide = new Ride(0.1, 1);
            List<Ride> rides = new List<Ride> { firstRide, secondRide };
            RideRepository.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(userId);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 30,
                AggregateFarePerRide= 33,
            };
            Assert.AreEqual(expected.TotalFare, invoiceSummary.TotalFare);
        }
    }
}