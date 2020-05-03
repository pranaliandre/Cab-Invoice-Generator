///--------------------------------------------------------------------
///   Class:       UsserAccount
///   Description: Class for addrides 
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace cabInvoiceGenerator
{
    public class RideRepository
    {
        public static Dictionary<string, List<Ride>> userAccount = new Dictionary<string, List<Ride>>();

        public static void AddRides(string distance, List<Ride> Rides)
        {
            try
            {
                if (userAccount.ContainsKey(distance))
                {
                    foreach (Ride ride in Rides)
                    {
                        userAccount[distance].Add(ride);
                    }
                }
                else
                {
                    userAccount.Add(distance, Rides);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}