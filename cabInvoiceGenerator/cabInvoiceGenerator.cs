///--------------------------------------------------------------------
///   Class:       CabInvoiceGenerator
///   Description: class for calculate total fare of car
///   Author:      Pranali Andre                   Date: 1/5/2020
///--------------------------------------------------------------------
using System;

namespace cabInvoiceGenerator
{
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// constant variable
        /// </summary>
        private static int COST_PER_TIME = 1;
        private static double MINIMUM_COST_PER_KILOMETER = 10;
        /// <summary>
        /// variable
        /// </summary>
        private static double minimumFare = 5;

        /// <summary>
        /// Method to calculate total fare journey of car
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance,int time)
        {
            double totalFare=distance * MINIMUM_COST_PER_KILOMETER + time * COST_PER_TIME;
            if(totalFare< minimumFare)
            {
                return minimumFare;
            }
            return totalFare;
        }
        /// <summary>
        /// Method to given multiple rides and calculate the aggregate total   
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            int numberOfRides = 0;
            InvoiceSummary invoiceSummary = new InvoiceSummary();
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare( ride.distance, ride.time);
                numberOfRides++;
            }
            invoiceSummary.TotalFare = totalFare;
            invoiceSummary.TotalNumberOfRides = numberOfRides;
            invoiceSummary.CalculateAggreagateFare();
            return invoiceSummary;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator");
        }
    }
}
