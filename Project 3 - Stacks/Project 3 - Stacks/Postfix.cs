///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 
// Project:             Project 3 - Stacks
// File Name:           Postfix.cs
// Description:         Class that will be used to return a string in the postfix expression format.
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
    /// Postfix class to create all postfix expressions for the program. Uses a converter method to change an infix expression to postfix
    /// </summary>
    class Postfix
    {
        // private string field so we can set a postfix string to null and work on it internally
        private string StrOps;

        /// <summary>
        /// Property to return and/or set the infix expression
        /// </summary>
        public string InfixExpression { get; set; }

        /// <summary>
        /// Property to return and/or set the postfix expression
        /// </summary>
        public string PostfixExpression { get; set; }

        /// <summary>
        /// Uses the operator class to help convert an infix expression to postfix
        /// </summary>
        /// <returns></returns>
        private string Convert()
        {
            this.StrOps = null;

            string work = this.InfixExpression;
            string delims = "+-*/()=";

            List<string> workedExp = Tools.Tokenize(work, delims);

            Stack<Operator> operatorStack = new Stack<Operator>();

            foreach (string expPiece in workedExp)
            {
                Boolean opCheck = IsOperatorSymbol(expPiece);

                if (opCheck == false)
                {
                    this.StrOps += (expPiece + " ");
                }

                if (opCheck == true)
                {
                    Operator found = new Operator(expPiece);

                    switch (found.Symbol)
                    {
                        case "(":
                            operatorStack.Push(found);
                            break;
                        case ")":
                            int stop = 0;
                            while (operatorStack.Count > 0 && stop == 0)
                            {
                                try
                                {
                                    string checkSym = operatorStack.Peek().Symbol;  // check the symbol of the next operator in the stack

                                    if (checkSym != "(" && checkSym != ")") // print any operators except parenthesis to the string
                                        this.StrOps += (operatorStack.Pop().Symbol + " ");
                                    else
                                    {
                                        operatorStack.Pop();
                                        stop = 1;
                                    }
                                }
                                catch (Exception)
                                {
                                    // do nothing, continue on
                                    ;
                                }
                            }

                            if (operatorStack.Count == 0)  // if we go through the whole stack without finding an open parenthesis to match with, error in expression
                            {
                                this.PostfixExpression = "***** Error! A closed parenthesis was found without a corresponding open parenthesis; incorrect format. *****";
                                return this.PostfixExpression;
                            }
                            
                            break;
                        default:        // This while loop uses >= precedence so that order of operations can be maintained in the expression
                            while (operatorStack.Count > 0 && operatorStack.Peek().Precedence >= found.Precedence && operatorStack.Peek().Symbol != "(")
                            {
                                try
                                {
                                    StrOps += (operatorStack.Pop().Symbol + " ");
                                }
                                catch (Exception)
                                {
                                    // do nothing, continue on
                                    ;
                                }
                            }

                            operatorStack.Push(found);
                            
                            
                            break;
                    }

                }
            }

            int m = operatorStack.Count();

            for (int n = m; n > 0; n--)
            {
                if (operatorStack.Peek().Symbol != "(" && operatorStack.Peek().Symbol != ")")
                    this.StrOps += (operatorStack.Pop().Symbol + " ");
            }

            if (operatorStack.Count > 0)
            {
                this.PostfixExpression = "***** Error! Parenthesis left in the stack; incorrect expression format. *****";
                return this.PostfixExpression;
            }


            this.PostfixExpression = StrOps;
            
            return this.PostfixExpression;
        }

        /// <summary>
        /// Method to determine if a token from a list of string objects is an operator; if it is, we send it to a stack
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool IsOperatorSymbol(string token)
        {
            Operator check = new Operator(token);
            return (check.Precedence > 0);
        }

        /// <summary>
        /// Constructor method for a postfix expression with empty default values
        /// </summary>
        public Postfix()
        {
            this.InfixExpression = "";
            this.PostfixExpression = "";
        }

        /// <summary>
        /// Parameterized method that will take a string and print it as a postfix expression
        /// </summary>
        /// <param name="input"></param>
        public Postfix(string input)
        {
            this.InfixExpression = input;
            this.PostfixExpression = Convert();
        }
    }
}
