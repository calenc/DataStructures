///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           SplashScreen.cs
// Description:         Class to handle the events for the SplashScreen and create it for display.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 8, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Project_3___Stacks
{
    /// <summary>
    /// Handles the events and builds the components of the SplashScreen
    /// </summary>
    public partial class SplashScreen : Form
    {
        /// <summary>
        /// Constructor to create the SplashScreen object
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            this.label2.Text = String.Format("Version {0}", AssemblyVersion);
            this.label1.Text = AssemblyTitle;
        }

        /// <summary>
        /// Tick event for our timer so the splash screen can close itself after the interval elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gives us the application version from the Assembly info, copied from VS generated code in AboutBox
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Gives us the application title of the project from Assembly info, copied from VS generated code in AboutBox
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
    }
}
