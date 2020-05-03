///--------------------------------------------------------------------
///   Class:       InvoiceSummary
///   Description: Class for calculating aggregate 
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
namespace cabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public double TotalFare { get; set; }
        public int TotalNumberOfRides { get; set; }
        public double AggregateFarePerRide { get; set; }
        /// <summary>
        /// Method for calculating aggragate for multiple rides
        /// </summary>
        public void CalculateAggreagateFare()
        {
            AggregateFarePerRide = TotalFare + TotalNumberOfRides;
        }
    }
}