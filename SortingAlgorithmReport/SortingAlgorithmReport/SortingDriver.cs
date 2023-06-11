////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  Project:        Profiling Report
//  File Name:      SortingDriver.cs
//  Description:    Short program to test different sorting algorithms to establish trends in performance
//  Course:         CSCI 2210-002 Data Structures
//  Author:         Calen Cummings, cummingscc@etsu.edu
//  Created:        Monday, November 1, 2021
//  Copyright:      Calen Cummings, 2021
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmReport
{
    /// <summary>
    /// Driver class for the sorting algorithms to be run on the test data.
    /// </summary>
    class SortingDriver
    {
        /// <summary>
        /// Main method that will run the sorting algorithms on the test data. In conjuction with an execution profiler, we will 
        /// use the data to establish trends and patterns.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Random R = new Random();
            int N = 100;
            List<int> randList = new List<int>(N);

            for (int i = 0; i < N; i++)
            {
                randList.Add(R.Next(1000000));  // maximum of 1,000,000 allowed to make sure we don't run out of memory space by allowing extremely large integers
            }

            SinkSort(randList);     // so we can test the algorithms on sorted data
            //randList.Reverse();   // used to test the algorithms on a set of data in reversed order
            //InsertionSort(randList, 0, (int)(0.9 * (randList.Count)) - 1);    // used to test the algorithms on data that is 90% ordered, 10% random




            // list that will be used to perform the sinking sort algorithm on the data set
            List<int> sinkingList = new List<int>(randList);

            // list that will be used to perform the selection sort algorithm on the data set
            List<int> selectingList = new List<int>(randList);

            // list that will be used to perform the insertion sort algorithm on the data set
            List<int> insertingList = new List<int>(randList);

            // list that will be used to perform the merge sort algorithm on the data set
            List<int> mergingList = new List<int>(randList);

            // list that will be used to perform the quick sort algorithm on the data set
            List<int> quicksortOrigList = new List<int>(randList);

            // list that will be used to perform the quick sort (median of three) algorithm on the data set
            List<int> quicksortMedThreeList = new List<int>(randList);

            // list that will be used to perform the shell sort method algorithm on the data set
            List<int> shellList = new List<int>(randList);

            // list that will be used to perfom the counting sort algorithm on the data set
            List<int> countingList = new List<int>(randList);

            // list that will be used to perform the radix (base 10) sort algorithm on the data set
            List<int> radixList = new List<int>(randList);

            SinkSort(sinkingList);                                      // Begin calling sorting methods on thier respective list so we can monitor their performance
            SelectionSort(selectingList, selectingList.Count);
            InsertionSort(insertingList);
            MergeSort(mergingList);
            OriginalQuickSort(quicksortOrigList);
            QuickMedianOfThreeSort(quicksortMedThreeList);
            ShellSort(shellList);
            CountingSort(countingList);
            Radix10LSDSort(radixList);

            //Console.WriteLine("The Lists were sorted by their appropriate method!");
            //Console.ReadKey();
        }

        /// <summary>
        /// Insertion sort method to use insertion sort on the data set.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void InsertionSort(List<int> list)
        {
            int temp, j;
            for (int i = 1; i < list.Count; i++)
            {
                temp = list[i];                                 // Value to be inserted

                for (j = i; j > 0 && temp < list[j - 1]; j--)   // Find location of value to be inserted
                {
                    list[j] = list[j - 1];                      // Move items down to make room for it
                }

                list[j] = temp;                                 // Insert new value
            }
        }

        /// <summary>
        /// Insertion sort algorithm that accepts parameters for a start and end.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private static void InsertionSort(List<int> list, int start, int end)
        {
            int temp, j;
            for (int i = start + 1; i <= end; i++)
            {
                temp = list[i];

                for (j = i; j > start && temp < list[j - 1]; j--)
                {
                    list[j] = list[j - 1];
                }

                list[j] = temp;
            }
        }

        /// <summary>
        /// Sinking sort algorithm to perform a sinking sort on the data set
        /// </summary>
        /// <param name="list">The list.</param>
        private static void SinkSort(List<int> list)
        {
            bool sorted = false;
            int pass = 0;

            while (!sorted && (pass < list.Count))
            {
                pass++;
                sorted = true;                          // assume sorted until proven wrong

                for (int i = 0; i < (list.Count - pass); i++)
                {
                    if (list[i] > list[i + 1])          // if out of order
                    {
                        Swap(list, i, i + 1);           // exchange
                        sorted = false;                 // found something out of order
                    }
                }
            }
        }

        /// <summary>
        /// Swaps the specified list. Needed for implementation in other methods.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        private static void Swap(List<int> list, int n, int m)
        {
            int temp = list[n];
            list[n] = list[m];
            list[m] = temp;
        }

        /// <summary>
        /// Selection sort algorithm that will allow us to use selection sort on the data set.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="n">The n.</param>
        private static void SelectionSort(List<int> list, int n)
        {
            if (n <= 1)
                return;

            int max = Max(list, n);
            if (list[max] != list[n - 1])
                Swap(list, max, n - 1);

            SelectionSort(list, n - 1);
        }

        /// <summary>
        /// Determines the maximum of the parameters. To be used in other sorting algorithms.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        private static int Max(List<int> list, int n)
        {
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                if (list[max] < list[i])
                    max = i;
            }

            return max;
        }

        /// <summary>
        /// Stub method to provide a shorter call to the quick sort method.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void OriginalQuickSort(List<int> list)
        {
            QuickSort(list, 0, list.Count - 1);
        }

        /// <summary>
        /// Quick sort algorithm to perform a quick sort on the data set.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private static void QuickSort(List<int> list, int start, int end)
        {
            int left = start;
            int right = end;

            if (left >= right)
                return;

            // Partition into left and right subsets
            while (left < right)
            {
                while (list[left] <= list[right] && left < right)
                    right--;        // burn candle from right

                if (left < right)   // exchange if needed
                    Swap(list, left, right);

                while (list[left] <= list[right] && left < right)
                    left++;         // burn candle from left

                if (left < right)   // exchange if needed
                    Swap(list, left, right);
            }

            QuickSort(list, start, left - 1);   // Recursively sort "left" partition
            QuickSort(list, right + 1, end);    // Recursively sort "right" partition
        }

        /// <summary>
        /// Quick call to the median of three sorting method.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void QuickMedianOfThreeSort(List<int> list)
        {
            QuickMedOfThreeSortParam(list, 0, list.Count - 1);
        }

        /// <summary>
        /// Quick sort algorithm with the median of three method of selection for the pivot.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        private static void QuickMedOfThreeSortParam(List<int> list, int start, int end)
        {
            const int cutoff = 10;      // Point at which we switch to Insertion sort

            if (start + cutoff > end)
                InsertionSort(list, start, end);

            else
            {
                int middle = (start + end) / 2;     // Find the median of three for pivot
                if (list[middle] < list[start])     // by sorting them and pivot is in the middle position
                    Swap(list, start, middle);
                if (list[end] < list[start])
                    Swap(list, start, end);
                if (list[end] < list[middle])
                    Swap(list, middle, end);

                // Place pivot at position (end - 1) since we know that list[end] >= list[middle]
                int pivot = list[middle];
                Swap(list, middle, end - 1);

                // Begin partitioning
                int left, right;
                for (left = start, right = end - 1; ;)
                {
                    while (list[++left] < pivot)
                        ;
                    while (pivot < list[--right])
                        ;
                    if (left < right)
                        Swap(list, left, right);
                    else
                        break;
                }

                // Restore pivot
                Swap(list, left, end - 1);

                QuickMedOfThreeSortParam(list, start, left - 1);     // Recursively sort left subset
                QuickMedOfThreeSortParam(list, left + 1, end);       // Recursively sort right subset
            }
        }

        /// <summary>
        /// Shell sort algorithm that uses gaps in conjunction with the insertion sort algorithm on a data set.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void ShellSort(List<int> list)
        {
            // start with gap of N/2; divide by 2.2 each time until it reaches 1 or 0
            for (int gap = list.Count / 2; gap > 0; gap = (gap == 2 ? 1 : (int)(gap / 2.2)))
            {
                // Sort a subset by insertion
                InsertionSort(list);
            }
        }

        /// <summary>
        /// MergeSort algorithm for performing a merge sort on a data set.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        private static List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)    // is there only 1 item in the list?
                return list;

            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            // Create left and right sublists of about half the size of the list
            int middle = list.Count / 2;
            for (int i = 0; i < middle; i++)
                left.Add(list[i]);
            for (int i = middle; i < list.Count; i++)
                right.Add(list[i]);

            // Recursively apply the MergeSort to each "half"
            left = MergeSort(left);
            right = MergeSort(right);

            // if all in right >= all in left, append right at end of left
            // to save time/steps in next recursion
            if (left[left.Count - 1] <= right[0])
                return append(left, right);

            // Now merge the two, maintaining sorted order
            result = merge(left, right);
            return result;
        }

        /// <summary>
        /// Merge method to be used within the MergeSort algorithm.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private static List<int> merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            // Add smaller of tops of two list to result as long as
            // both lists contain more values
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] < right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);   // Discard
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);  // Discard
                }
            }

            // One of the two sublists is now empty
            // Add rest of left, if any
            while (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }

            // Add rest of right, if any
            while (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }

            return result;
        }

        /// <summary>
        /// Append method to be used as part of the MergeSort algorithm.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private static List<int> append(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(left);
            foreach (int x in right)
                result.Add(x);
            return result;
        }

        /// <summary>
        /// Perform a Radix (base 10) sort using the least significant digit approach.
        /// </summary>
        /// <param name="list">The list to be sorted.</param>
        /// <returns>Sorted List</returns>
        private static List<int> Radix10LSDSort(List<int> list)
        {
            List<List<int>> bin = new List<List<int>>(10);  // 10 bins

            for (int i = 0; i < 10; i++)                    // Populate the Bins with new Lists<int>
                bin.Add(new List<int>(list.Count));         // of capacity list.Count

            int numDigits = list.Max().ToString().Length;   // Find the number of digits in the largest number

            // Starting with the rightmost digit, copy the data into the proper bins;
            // then, copy the data back to the list; repeat for each digit to the left;
            // finally, the result is sorted
            for (int j = 0; j < numDigits; j++)
            {
                for (int n = 0; n < list.Count; n++)        // Fill bins from the list based on digit j in each
                    bin[Digit(list[n], j)].Add(list[n]);    // item in the list; j is positions from rightmost
                                                            // position

                CopyToResult(bin, list);                    // Replace list from bins 0-9, one bin at a time

                // Prepare (clear) bins for next pass - the one after incrementing j (position)
                for (int i = 0; i < 10; i++)
                {
                    bin[i].Clear();
                }
            }

            // When last pass completed, return the sorted list
            return list;
        }

        /// <summary>
        /// Copies the values of each bin back into the list, one
        /// bin at a time from bin 0 to bin 9
        /// </summary>
        /// <param name="bin">The list of bins.</param>
        /// <param name="result">The list of integers.</param>
        private static void CopyToResult(List<List<int>> bin, List<int> result)
        {
            result.Clear();
            for (int i = 0; i < 10; i++)
                foreach (int j in bin[i])
                    result.Add(j);
        }

        /// <summary>
        /// Get the digit of value currently in digitPosition where the
        /// positions are numbered from right to left. That is, digit
        /// position 0 is the rightmost digit (the 1's position),
        /// position 1 is the 10's digit,
        /// position 2 is the 100's digit, and so forth.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="digitPosition">The digit position.</param>
        /// <returns>The designated digit of value</returns>
        private static int Digit(int value, int digitPosition)
        {
            return (value / (int)Math.Pow(10, digitPosition) % 10); // get digit
        }

        /// <summary>
        /// Counting the sort implementation.
        /// </summary>
        /// <param name="list">The list of non-negative integers to be sorted.</param>
        /// <returns>Sorted list</returns>
        private static List<int> CountingSort(List<int> list)
        {
            List<int> newList = new List<int>(list);

            int max = list.Max();                    // Find the max value in list
            int[] counts = new int[max + 1];         // Create array of counts of the proper size

            for (int i = 0; i < list.Count; i++)     // Initialize all positions in the counts array to 0's
                counts[i] = 0;

            for (int j = 0; j < list.Count; j++)     // Count occurences
                counts[list[j]]++;

            for (int j = 1; j <= max; j++)           // Add sum of counts of previous items to each item
                counts[j] += counts[j - 1];

            for (int j = 0; j < newList.Count; j++)  // Place the items from list into newList in proper places
            {
                newList[counts[list[j]] - 1] = list[j];
                counts[list[j]]--;                   // After placing an item in new list, reduce its count
            }

            return newList;
        }
    }
}
