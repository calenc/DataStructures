///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 2 - Personal Library
// File Name:           Person.cs
// Description:         Class that creates and manipulates Person objects, representing people like authors or owners.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Saturday, October 16, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructuresProject2
{
    /// <summary>
    /// Creates and provides methods for Person objects, which we use to represent authors or owners.
    /// </summary>
    class Person
    {
        /// <summary>
        /// Constructor for a Owner/person to be easily created from a delimited text file.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="strAddress">The string address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
        public Person(string name, string strAddress, string city, string state, string zipCode, string id, string phoneNumber, string email)
        {
            this.Name = name;
            this.StreetAddress = strAddress;
            this.City = city;
            this.State = state;
            this.ZipCode = zipCode;
            this.ID = id;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = email;
        }

        /// <summary>
        /// Property to interact with a Person's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Propery to interact with a Person's address
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Property to interact with a Person's city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Property to interact with a Person's state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Property to interact with a Person's zip code
        /// </summary>
        public string ZipCode 
        {


            get
            {
                return ZipCode;
            }

            set 
            {

                Regex zipPattern = new Regex(@"^\d{5}$"); // format of #####, a five digit zip code

                Match zipMatch = zipPattern.Match(value);

                if (zipMatch.Success)   // if the input for the zip code is formatted correctly, the value is saved. Otherwise, zip code remains unchanged
                    ZipCode = value;
                else
                    ZipCode = "Invalid";
            } 
        }

        /// <summary>
        /// Property to interact with a Person's ID
        /// </summary>
        public string ID 
        {
            get { return ID; }
            set 
            {
                try
                {
                    Regex idPattern = new Regex(@"^E0{2}\d{6}$");    // format of "E00######", leading E followed by exactly 2 zeros and then any combination of 6 digits

                    Match idMatch = idPattern.Match(value);

                    if (idMatch.Success)    // if the ID input is in the correct format, the value is saved. Otherwise, ID remains unchanged
                        ID = value;
                    else
                        ID = "Invalid";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            } 
        }

        /// <summary>
        /// Property to interact with a Person's phone number
        /// </summary>
        public string PhoneNumber 
        {
            get { return PhoneNumber; }
            set 
            {
                try
                {
                    Regex phonePattern = new Regex(@"^\(\d{3}\) \d{3}-\d{4}$");     // format of ###-###-####, standard phone number format

                    Match phoneMatch = phonePattern.Match(value);

                    if (phoneMatch.Success)     // if the phone number input is in the correct format, the value is saved. Otherwise, phone number remains unchanged
                        PhoneNumber = value;
                    else
                        PhoneNumber = "Invalid";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            } 
        }

        /// <summary>
        /// Property to interact with a Person's email address
        /// </summary>
        public string EmailAddress 
        {
            get { return EmailAddress; }
            set 
            {
                try
                {
                    Regex emailPattern = new Regex(@"^\w+@\w+\.[a-z]{3}$");      // format of ******@*********.$$$, with any amount of word characters or digits before the '@'
                                                                                 // and after it, but the address must end with a 3 letter domain (.com, .wed, .edu, etc)
                    Match emailMatch = emailPattern.Match(value);

                    if (emailMatch.Success)     // if the email input is in the correct format, the value is saved. Otherwise, email is unchanged
                        EmailAddress = value;
                    else
                        EmailAddress = "Invalid";
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            } 
        }
    }
}
