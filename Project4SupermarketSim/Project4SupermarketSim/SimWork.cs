///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 4 - Supermarket Simulation
// File Name:           SimWork.cs
// Description:         Borderless window that opens to display the simulation at work and then closes once the data is processed.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Thursday, December 2, 2021
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
using System.Windows.Forms;

namespace Project4SupermarketSim
{
    /// <summary>
    /// Windows form to display the simulation at work
    /// </summary>
    public partial class SimWork : Form
    {
        /// <summary>
        /// Creates the SimWork window and displays the text to show the simulation at work.
        /// </summary>
        public SimWork()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Tick event for the form to automatically close so we can update the text with each loop of the simulation iteration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Disposes of the window upon closing so that we do not hold on to useless data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Tick event to auto close the form after a certain interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
