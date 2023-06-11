///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           Operator.cs
// Description:         Class to associate operators with a mathematical precedence so that we can correctly convert expressions.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 8, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Stacks
{
    /// <summary>
    /// Identifies each operator with a mathematical precedence that will determine order in calculations
    /// </summary>
    class Operator
    {
        /// <summary>
        /// Property to assign and get precedence values for operators to determine order in algebra
        /// </summary>
        public int Precedence { get; set; }

        /// <summary>
        /// Property to assign and get the symbol associated with the operator and its function
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Less-than operator to use on our operator symbols so we can appropriately compare and determine correct order of precedence
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <(Operator lhs, Operator rhs)
        {
            return lhs.Precedence < rhs.Precedence; 
        }

        /// <summary>
        /// Greater-than operator to use on our operator symbols so we can appropriately compare and determine correct order of precedence
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator >(Operator lhs, Operator rhs)
        {
            return lhs.Precedence > rhs.Precedence;
        }

        /// <summary>
        /// Default constructor for Operator objects that is created with default values
        /// </summary>
        public Operator()
        {
            this.Symbol = "&";
            this.Precedence = -2;
        }

        /// <summary>
        /// Parameterized constructor to take a string parameter and create an operator of equal precedence/order
        /// </summary>
        /// <param name="op"></param>
        public Operator(string op)
        {
            this.Symbol = op;

            switch (op)
            {
                case "=":
                    this.Precedence = 1;
                    break;
                case "+":
                    this.Precedence = 2;
                    break;
                case "-":
                    this.Precedence = 2;
                    break;
                case "*":
                    this.Precedence = 3;
                    break;
                case "/":
                    this.Precedence = 3;
                    break;
                case "(":
                    this.Precedence = 4;
                    break;
                case ")":
                    this.Precedence = 4;
                    break;
                default:
                    this.Precedence = 0;
                    break;
            }
        }
    }
}
