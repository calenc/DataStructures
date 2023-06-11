///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           InfixToPostfixForm.cs
// Description:         Creates the main window of our program and handles any events created within the form.
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
using System.IO;

namespace Project_3___Stacks
{
    /// <summary>
    /// Class to create the main window form of the program and handle events
    /// </summary>
    public partial class InfixToPostfixForm : Form
    {
        /// <summary>
        /// Initializes the form object
        /// </summary>
        public InfixToPostfixForm()
        {
            InitializeComponent();
            this.Text = AssemblyTitle;
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
        /// Click event for the Exit button to close the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Click event for the application to exit whenever Exit is selected from the File menu option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens the About Box for the program whenever the About menu option is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        /// <summary>
        /// Click event for the clear button to clear both text boxes on the screen, but not the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        /// <summary>
        /// Click event for the Input data file menu option, takes a text file and fills it into a list of string objects to be passed into the List Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inputInfixDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;  // clears the List Box between text files so that it is always displaying the currently loaded data


            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = Application.StartupPath + @".\.\TestData"; // Steps back two folders from the executable location to our project folder containing our text files
            dlg.Title = "Open a Text File";
            dlg.Filter = "text files|*.txt|all files|*.*";

            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("No file was selected. Returning...");

                return;             // if no file is selected, state this and then redirect the user back to the main window
            }

            StreamReader chosenRead = new StreamReader(dlg.FileName);

            List<string> fileList = new List<string>();

            while (chosenRead.Peek() != -1)
            {
                string line = chosenRead.ReadLine();
                fileList.Add(line);
            }

            this.listBox1.DataSource = fileList.ToArray();
        }

        /// <summary>
        /// Index change event so that we can display the correct info in the text boxes for the highlighted/selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox1.Text = String.Format ("{0}", listBox1.SelectedItem);
            this.textBox1.Focus();
            Postfix currentPostfix = new Postfix(listBox1.SelectedItem.ToString());
            this.textBox2.Text = currentPostfix.PostfixExpression;
        }

        /// <summary>
        /// Button click event for users to be able to enter their own expression in the Infix expression box and then evaluate its postfix equivalent in the second text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Postfix userInput = new Postfix(this.textBox1.Text);
            this.textBox2.Text = userInput.PostfixExpression;
        }
    }
}
