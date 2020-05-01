///--------------------------------------------------------------------
///   Class:       cabInvoiceGeneratorTest
///   Description: class for calculate total fare of car
///   Author:      Pranali Andre                   Date: 1/5/2020
///--------------------------------------------------------------------
using System;

namespace cabInvoiceGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class CabInvoiceGenerator
    {
        private static int COST_PER_TIME = 1;
        private static double MINIMUM_COST_PER_KILOMETER = 10;
        private static double minimumFare = 5;

        /// <summary>
        /// Method for calculate total fare journey of car
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double calculateArea(double distance,int time)
        {
            double totalFare=distance * MINIMUM_COST_PER_KILOMETER + time * COST_PER_TIME;
            if(totalFare< minimumFare)
            {
                return minimumFare;
            }
            return totalFare;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cab Invoice Generator");
        }
    }
}
