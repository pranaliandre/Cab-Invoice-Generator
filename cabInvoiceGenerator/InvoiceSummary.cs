///--------------------------------------------------------------------
///   Class:       InvoiceSummary
///   Description: Class for calculating aggregate 
///   Author:      Pranali Andre                   Date: 1/5/2020
///--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

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
