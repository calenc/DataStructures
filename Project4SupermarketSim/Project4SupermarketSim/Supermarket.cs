///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 4 - Supermarket Simulation
// File Name:           Supermarket.cs
// Description:         Windows Form that will house a simulation program for a supermarket to determine the optimal number of checkout lanes.
// Course:              CSCI 2210-002 - Data Structures
// Author:              Calen Cummings, cummingscc@etsu.edu
// Created:             Monday, November 22, 2021
// Copyright:           Calen Cummings, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Project4SupermarketSim
{
    /// <summary>
    /// Partial class that initializes and builds the form for the program to display; includes event handlers and methods to use in simulation.
    /// </summary>
    public partial class Supermarket : Form
    {
        private DateTime openTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
        private int expCustomers = 600;          // Private field to hold the expected number of customers for the simulation.
        private int minRegisterTime = 120;       // Private field to hold the minimum register checkout time in SECONDS.
        private int checkoutLanes = 1;           // Private field to hold the desired/physical amount of checkout lines for the store simulation.
        private double hoursOpen = 16.00;           // Private field to hold the number of open hours; double to allow for half or quartile hours.
        private int expectedService = 345;       // Private field to hold the expected average service time in SECONDS.
        private TimeSpan totalRegTime;           // Private field to hold all the checkout times to later calculate the average.
        private TimeSpan avgRegisterTime;        // Private field to hold the actual average checkout time produced by the simulation.
        private int customersServed = 0;             // Private field to hold the number of customers helped within the simulation's runtime.
        private int maxLine;                     // Private field to hold the longest line length from the simulation.
        private bool beatGoal;                   // Private field to tell the user if the produced average wait time was shorter than expected/desired.
        private Random r = new Random();         // Private uniform random distribution generator to create entrance times for customers.
        private PriorityQueue<Event> PQ = new PriorityQueue<Event>();   // Priority queue that will handle events so that customers are processed at the register in order by arrival.
        private List<Queue<Customer>> openRegisters = new List<Queue<Customer>>();  // List of queues to represent our register lines

        /// <summary>
        /// Constructor to build the defined window for the program and provide functionality to the program for the user.
        /// </summary>
        public Supermarket()
        {
            InitializeComponent();
            this.Text = AssemblyTitle;
        }

        /// <summary>
        /// Method to generate all of our Customers and their associated events for the simulation. Partially taken from Lecture 13.
        /// </summary>
        private void GenerateShopperEvents()
        {
            totalRegTime = new TimeSpan(0, 0, 0);
            maxLine = 0;                // Start at zero to erase any previous simulation data.
            customersServed = 0;        // Start at zero to erase any previous simulation data.

            TimeSpan start;             // Starting point for customers entering the store.
            TimeSpan checkout;          // Stores the randomly generated time for being serviced at the register. 
            int businessHours = (int)(Math.Round(hoursOpen, 1) * 60);   // Round open hours down to one decimal point, multiply by 60 for minutes, and cast as integer.
                                                                        // This allows for users to specify a more precise amount of open hours in the program, without too much lost data in the conversion.
                                                                        // Worst case, allows customers to enter at most 3 minutes after close, which is not uncommon in retail.

            for (int customer = 1; customer <= expCustomers; customer++)
            {
                Customer current = new Customer(customer);

                // Random start time based on the amount of open hours.
                start = new TimeSpan(0, r.Next(businessHours), 0);
                // Random (negative expression) interval with a minimum determined by user input.
                checkout = new TimeSpan(0, (int)((minRegisterTime / 60) + NegExp((expectedService - minRegisterTime) / 60)), 0);

                current.AtRegister = checkout;
                totalRegTime += checkout;

                Event startLine = new Event(EVENTTYPE.ENTER, openTime.Add(start), current);  // Generate the enter event for the customers, but since they are not "at the register" yet, we wait to create the LEAVE events.

                current.CheckoutStart = startLine;
                PQ.Enqueue(startLine);
            }

            for (int lines = 1; lines <= checkoutLanes; lines++)        // Create all of our registers based on the specified amount.
            {
                Queue<Customer> register = new Queue<Customer>();
                openRegisters.Add(register);
            }

            int lineCheck = 0;      // Starting value for us to compare line lengths to so we can put customers in the shortest line
            int shortest = -1;      // Integer value to hold the index of the shortest line

            //List<string> simText = new List<string>();       // String list to hold the print lines for the simulation; to be passed on to a secondary form to fill a textbox.
            // Double the size of PQ because we only have enter events, but we need to have lines for both enter and leave events
            // for each customer.
            int lineCounter = 0;    // Line counter for the steps in the simulation.  

            while (PQ.Count > 0)
            {
                string str = (++lineCounter).ToString().PadLeft(3) + ". " + PQ.Peek().ToString();
                //simText.Add(str);

                if (PQ.Peek().Type == EVENTTYPE.ENTER)
                {
                    foreach (Queue<Customer> line in openRegisters)
                    {
                        if (line.Count <= lineCheck)    // Identify the shortest line, but if they are all the same, the customer gets in the last line.
                        {
                            lineCheck = line.Count;
                            shortest = openRegisters.IndexOf(line);
                        }
                    }

                    Customer temp = PQ.Peek().Person;

                    openRegisters[shortest].Enqueue(temp);

                    Event leaveRegister = new Event(EVENTTYPE.LEAVE, temp.CheckoutStart.Time.Add(temp.AtRegister), temp);   // Generate the leave event as the customer reaches the register, queue up the leave event.

                    PQ.Enqueue(leaveRegister);


                    PQ.Dequeue();

                    foreach (Queue<Customer> line in openRegisters)     // Check the count of every register so we can identify the max line length
                    {
                        if (line.Count > maxLine)
                        {
                            maxLine = line.Count;
                        }

                    }
                }
                else if (PQ.Peek().Type == EVENTTYPE.LEAVE)
                {
                    Customer temp = PQ.Peek().Person;

                    foreach (Queue<Customer> line in openRegisters)     // Find the related customer in their respective line and remove them from it.
                    {
                        if (line.Contains(temp))
                        {
                            line.Dequeue();
                        }
                    }

                    PQ.Dequeue();

                    customersServed++;

                    foreach (Queue<Customer> line in openRegisters)     // Check the count of every register so we can identify the max line length
                    {
                        if (line.Count > maxLine)
                        {
                            maxLine = line.Count;
                        }
                    }
                }

                try
                {
                    SimWork simScreen = new SimWork();      // Uses a borderless form window to show that the simulation is moving through the priority queue and events.
                    simScreen.textBox1.Text = str;
                    simScreen.Show();
                }
                catch (Exception)
                {
                    SimWork simScreen = new SimWork();
                    simScreen.textBox1.Text = str;
                    simScreen.Show();
                }
            }


            int seconds = (int)(totalRegTime.TotalSeconds / customersServed);       // Set all the text boxes in the Simulation Results panel of the program.
            avgRegisterTime = new TimeSpan(0, 0, seconds);
            this.AvgServiceBox.Text = avgRegisterTime.ToString();

            this.CustomersServedBox.Text = customersServed.ToString();

            this.MaxLineBox.Text = maxLine.ToString();

            beatGoal = avgRegisterTime.TotalSeconds < expectedService;
            this.BeatExpectBox.Text = beatGoal.ToString();

            return;
        }

        /// <summary>
        /// Negative distribution method so that we can create random time intervals for customers at the register.
        /// </summary>
        /// <param name="ExpectedValue"></param>
        /// <returns></returns>
        private double NegExp(double ExpectedValue)
        {
            return -ExpectedValue * Math.Log(r.NextDouble(), Math.E);
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

        /// <summary>
        /// Click event that will display the About box for the program, filled with data from AssemblyInfo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimAboutBox sab = new SimAboutBox();
            sab.Show();
        }

        /// <summary>
        /// Event to close the application whenever the menu option Exit is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Close event that displays a goodbye message box whenever the form is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodbyeMessage(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Thank you for using this simulator! Goodbye.");
        }

        /// <summary>
        /// Key press event handler to make sure only digits and at most one decimal are allowed in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoursOpenBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press event to make sure only digits are put into the text box field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpCustomersBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press event to make sure only digits are put into the text box field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckoutLinesBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))   // Only allow digit inputs.
            {
                e.Handled = true;
            }

            if (CheckoutLinesBox.Text == "" && e.KeyChar == '0')   // Except for zero, must have at least 1 line.
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press event to make sure only digits are put into the text box field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinServiceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))     // Only allow digit inputs.
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Key press event to make sure only digits are put into the text box field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesiredServiceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))     // Only allow digit inputs.
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Load event to fill all the Simulation Data fields with the default data the company wants us to test upon startup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supermarket_Load(object sender, EventArgs e)
        {
            this.HoursOpenBox.Text = hoursOpen.ToString();
            this.ExpCustomersBox.Text = expCustomers.ToString();
            this.CheckoutLinesBox.Text = checkoutLanes.ToString();
            this.MinServiceBox.Text = minRegisterTime.ToString();
            this.DesiredServiceBox.Text = expectedService.ToString();
        }

        /// <summary>
        /// Changes the local field to match input from the user so that when the simulation runs, it is using the correct data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoursOpenBox_TextChanged(object sender, EventArgs e)
        {
            if (this.HoursOpenBox.Text != "" && this.HoursOpenBox.Text != ".")  // Prevent errors being thrown by trying to parse the field if it is empty or begins with a decimal
                hoursOpen = double.Parse(this.HoursOpenBox.Text);
        }

        /// <summary>
        /// Changes the local field to match user input for the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpCustomersBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ExpCustomersBox.Text != "")    // Prevents errors being thrown from parsing an empty field.
                expCustomers = int.Parse(this.ExpCustomersBox.Text);
        }

        /// <summary>
        /// Changes the local field to match user input for the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckoutLinesBox_TextChanged(object sender, EventArgs e)
        {
            if (this.CheckoutLinesBox.Text != "")   // Prevents errors being thrown from parsing an empty field.
                checkoutLanes = int.Parse(this.CheckoutLinesBox.Text);
        }

        /// <summary>
        /// Changes the local field to match user input for the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinServiceBox_TextChanged(object sender, EventArgs e)
        {
            if (this.MinServiceBox.Text != "")      // Prevents errors being thrown from parsing an empty field.
                minRegisterTime = int.Parse(this.MinServiceBox.Text);
        }

        /// <summary>
        /// Changes the local field to match user input for the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesiredServiceBox_TextChanged(object sender, EventArgs e)
        {
            if (this.DesiredServiceBox.Text != "")  // Prevents errors being thrown from parsing an empty field.
                expectedService = int.Parse(this.DesiredServiceBox.Text);
        }

        /// <summary>
        /// Click event to clear all data in the Simulation Data panel so new input can be entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.HoursOpenBox.Clear();
            this.ExpCustomersBox.Clear();
            this.CheckoutLinesBox.Clear();
            this.MinServiceBox.Clear();
            this.DesiredServiceBox.Clear();
        }

        /// <summary>
        /// Click event to run the simulation when the button to run it is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GenerateShopperEvents();
        }

        /// <summary>
        /// Tick event to close a secondary window after the timer elapses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
