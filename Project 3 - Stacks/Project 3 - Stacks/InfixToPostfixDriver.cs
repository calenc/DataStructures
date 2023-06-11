///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           InfixToPostfixDriver.cs
// Description:         Driver class for the program to run and display.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 8, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_3___Stacks
{
    /// <summary>
    /// Driver class for the Windows Forms application to run and display
    /// </summary>
    static class InfixToPostfixDriver
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
            Application.Run(new InfixToPostfixForm());
        }
    }
}
