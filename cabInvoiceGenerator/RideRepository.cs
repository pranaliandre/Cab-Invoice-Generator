///--------------------------------------------------------------------
///   Class:       UserAccount
///   Description: Class for ddRides 
///   Author:      Pranali Andre                   Date: 3/5/2020
///--------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace cabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = new Dictionary<string, List<Ride>>();

        /// <summary>
        /// constructor for user rides
        /// </summary>
        public RideRepository() { }
        /// <summary>
        /// Method to add rides
        /// </summary>
        /// <param name="userID"> User Id </param>
        /// <param name="rides"> Rides </param>
        /// <returns> AddRides </returns>
        public void AddRides(string userId, Ride[] rides)
        {
            bool ListOfRide = userRides.ContainsKey(userId);
            //if rideList is false
            if (ListOfRide == false)
            {
                //create list
                List<Ride> list = new List<Ride>();
                //add rides
                list.AddRange(rides);
                //add userId and Rides
                userRides.Add(userId, list);
            }
        }
        /// <summary>
        /// Method to get rides of user
        /// </summary>
        /// <param name="userID"> UserID </param>
        /// <returns> GetRides </returns>
        public Ride[] GetRides(string userId)
        {
            return userRides[userId].ToArray();
        }
    }
}