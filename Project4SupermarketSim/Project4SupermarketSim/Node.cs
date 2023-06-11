///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 4 - Supermarket Simulation
// File Name:           Node.cs
// Description:         Class to define the nodes that we will be using to represent customers within the program's priority queue.
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
    /// Node class that we define for our priority queue to avoid using LinkedLists and LinkedListNodes. Copied from Powerpoint Lecture 13.
    /// </summary>
    class Node<T> where T : IComparable
    {
        // Properties
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="link"></param>
        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    } // End Node class
}
