///--------------------------------------------------------------------
///   Class:       CabInvoiceGenerator
///   Description: class for calculate total fare of car
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using System;

namespace cabInvoiceGenerator
{
    public class CabInvoiceGenerator
    {
        /// <summary>
        /// constant variable
        /// </summary>
        public static int COST_PER_TIME = 1;
        public static double MINIMUM_COST_PER_KILOMETER = 10;
        /// <summary>
        /// variable
        /// </summary>
        public static double minimumFare = 5;
        public static double totalFare = 0;
        public static int numberOfRides = 0;

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
        public InvoiceSummary CalculateFare(string userId)
        {
            
            InvoiceSummary invoiceSummary = new InvoiceSummary();
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }
            if (RideRepository.userAccount.ContainsKey(userId))
            {
                foreach (Ride ride in RideRepository.userAccount[userId])
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                    numberOfRides++;
                }
                invoiceSummary.TotalNumberOfRides = numberOfRides;
                invoiceSummary.TotalFare = totalFare;
                invoiceSummary.CalculateAggreagateFare();
                return invoiceSummary;
            }
            else
            {
                throw new InvalidInputException(InvalidInputException.InvoiceGeneratorException.INVALIDUSERID, "user Id is wrong");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator");
        }
    }
}
