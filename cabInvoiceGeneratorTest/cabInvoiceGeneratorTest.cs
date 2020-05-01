///--------------------------------------------------------------------
///   Class:       cabInvoiceGeneratorTest
///   Description: Test for cabInvoiceGeneratorTest
///   Author:      Pranali Andre                   Date: 1/5/2020
///--------------------------------------------------------------------
using NUnit.Framework;
using cabInvoiceGenerator;
namespace cabInvoiceGeneratorTest
{
    public class Tests
    {
        CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
        [SetUp]
        public void Setup()
        {
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
        /// Test case for given multiple rides  should return fare summary 
        /// </summary>
        [Test]
        public void MultipleRides_ShouldReturnFareSummary()
        {
            Ride[] rides =
            {
                new Ride(2.0 ,5),
                new Ride(0.1, 1)
            };
            double fare = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(expected:30, fare,0.0);
        }
    }
}