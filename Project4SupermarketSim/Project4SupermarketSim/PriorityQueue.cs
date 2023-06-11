///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 4 - Supermarket Simulation
// File Name:           PriorityQueue.cs
// Description:         Defines the Priority queue for our simulation program.
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
    /// Interface for the program's Priority Queue, taken from Wiener's book (Powerpoint Lecture 13).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainer<T>
    {
        // Remove all objects from the container
        void Clear();
        // Returns true if container is empty
        bool IsEmpty();
        // Returns the number of entries in the container
        int Count { get; set; }
    }

    /// <summary>
    /// Interface for the program's Priority Queue, taken from Wiener's book (Powerpoint Lecture 13).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPriorityQueue<T> : IContainer<T> where T : IComparable
    {
        // Inserts item based on its priority
        void Enqueue(T item);

        // Removes first item in the queue
        void Dequeue();

        // Query
        T Peek();
    }

    /// <summary>
    /// Priority queue for the program so we can properly queue customers based on arrival time. Copied from Powerpoint Lecture 13.
    /// </summary>
    class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        // Fields and properties
        private Node<T> top;               // reference to the top of the PQ

        public int Count { get; set; }  // Number of items in the PQ

        /// <summary>
        /// Add an item to the PQ. Copied from Powerpoint Lecture 13.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = top;
                Node<T> previous = null;

                // Search for the first node in the linked structure that is smaller than item
                while (current != null && current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                // Have found the place to insert the new node
                Node<T> newNode = new Node<T>(item, current);

                // if there is a previous node, set it to link to the new node
                if (previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }
            }
            Count++; // Add 1 to the number of nodes in the PQ.
        }

        /// <summary>
        /// Dequeue method for our Priority queue. Copied from Powerpoint Lecture 13.
        /// </summary>
        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from empty queue.");
            }
            else
            {
                Node<T> oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null; // do this so the removed node can be garbage collected.
            }
        }

        /// <summary>
        /// Make the PQ empty. Copied from Powerpoint Lecture 13.
        /// </summary>
        public void Clear()
        {
            top = null; // Nodes will be garbage collected
            Count = 0;  // Count is now 0 since PQ is empty
        }

        /// <summary>
        /// Retrieve the top item on the PQ. Copied from Powerpoint Lecture 13.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }

        /// <summary>
        /// Asks whether the PQ is empty. Copied from Powerpoint Lecture 13.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Count == 0;
        }
    }

}
