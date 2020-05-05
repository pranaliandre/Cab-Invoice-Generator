///--------------------------------------------------------------------
///   Class:       CabInvoiceGeneratorTest
///   Description: Test for cabInvoiceGeneratorTest
///   Author:      Pranali Andre                Date: 3/5/2020
///--------------------------------------------------------------------
using NUnit.Framework;
using cabInvoiceGenerator;
using System;
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
        /// UC-1 Test case for calculate fare for journey
        /// </summary>
        [Test]
        public void GivenDistance_ShouldReturnTotalFare()
        {

            double distance = 2.0;
            int time = 5;
            double totalFare = invoiceGenerator.CalculateFare("normal", distance, time);
            Assert.AreEqual(expected: 25, totalFare, delta: 0.0);
        }
        /// <summary>
        /// UC-2: Test case to calculate aggregate fare for multiple Rides
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnCalculateAggregateTotal()
        {
            Ride[] ride = {
                 new Ride("normal",2.0,5),
                new Ride("normal",0.1,1)
            };
            double totalFare = invoiceGenerator.CalculateFare(ride);
            Assert.AreEqual(30, totalFare,delta: 0.0);
        }

        /// <summary>
        /// UC-3: Test case to calculate total fare, no. of rides ,average
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_whenTakeMultipleRides_ReturnEnhancedInVoice()
        {
            Ride[] rides = {
                new Ride("normal",2.0,5),
                new Ride("normal",0.1,1),
            };
            double totalFare = invoiceGenerator.CalculateFare(rides);
            int totalRides = invoiceGenerator.numberOfRides;
            double averageFare = Math.Round(invoiceGenerator.Average, 2);
            Assert.AreEqual(60, totalFare,delta:0.0);
            Assert.AreEqual(2, totalRides,delta:0.0);
            Assert.AreEqual(30, averageFare,delta:0.0);
        }
        /// <summary>
        /// UC-4: Test case to give userId and calculate total fare of normal ride.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "aryan.andre@gmail.com";
            Ride[] ride = {
                new Ride("normal",2.0,5),
                new Ride("normal",0.1,1),
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            double totalFare = invoiceGenerator.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(90, totalFare,0.0);
        }
        /// <summary>
        /// UC-5: Test case for 2 categories of rides normal and premium and calculate the total fare
        /// </summary>
        [Test]
        public void GivenUserId_whenNormalandPremiumJourney_ReturnTotalFare()
        {
            string userId = "kimaya.andre@gmail.com";
            Ride[] ride = {
                new Ride("premium",2.0,5),
                new Ride("normal",0.1,1),
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, ride);
            double totalFare = invoiceGenerator.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(135,totalFare,delta:0.0);
        }
    }
}