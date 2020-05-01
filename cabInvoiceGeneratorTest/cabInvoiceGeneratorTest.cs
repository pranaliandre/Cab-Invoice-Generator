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
            CabInvoiceGenerator invoiceGenerator = new CabInvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.calculateArea(distance,time);
            Assert.AreEqual(expected:25, fare, delta: 0.0);
        }
    }
}