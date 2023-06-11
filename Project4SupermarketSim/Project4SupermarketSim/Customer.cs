///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 4 - Supermarket Simulation
// File Name:           Customer.cs
// Description:         Class to define and track individual customers within a supermarket for simulation purposes.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 22, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4SupermarketSim
{
    /// <summary>
    /// Defining class to create customers for a store simulation so we can track checkout times/traffic.
    /// </summary>
    class Customer
    {
        /// <summary>
        /// Property to access the ENTER event for a entering the checkout line.
        /// </summary>
        public Event CheckoutStart { get; set; }

        /// <summary>
        /// Property to access the LEAVE event for a customer leaving the checkout line/queue.
        /// </summary>
        public Event CheckoutLeave { get; set; }

        /// <summary>
        /// Property to access a customer number given to customers upon entrance so we can individually track customers.
        /// </summary>
        public int CustNumber { get; set; }

        /// <summary>
        /// Property to access each customer's checkout time, so we can accurately calculate the exit events as customers go through the line.
        /// </summary>
        public TimeSpan AtRegister { get; set; }

        /// <summary>
        /// Default constructor for Customers that provides default values.
        /// </summary>
        public Customer()
        {
            CheckoutStart = null;
            CheckoutLeave = null;
            CustNumber = 0;
            AtRegister = new TimeSpan(0, 0, 0);
        }

        /// <summary>
        /// Parameterized constructor to create a customer object with only an identifying number as the parameter.
        /// </summary>
        /// <param name="number"></param>
        public Customer(int number)
        {
            CheckoutStart = null;
            CheckoutLeave = null;
            CustNumber = number;
            AtRegister = new TimeSpan();
        }

        /// <summary>
        /// Fully parameterized constructor to create Customers from specific values.
        /// </summary>
        /// <param name="enter"></param>
        /// <param name="leave"></param>
        /// <param name="number"></param>
        public Customer(Event enter, Event leave, int number, TimeSpan purchase)
        {
            CheckoutStart = enter;
            CheckoutLeave = leave;
            CustNumber = number;
            AtRegister = purchase;
        }
    }
}
