using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        private static List<string> list = new List<string>();
        private static Queue<string> queue = new Queue<string>();

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {

            //Loop this method untill the user inputs something to exit to main menue.
            bool programRun = true;
            
            do
            {
                //Create a switch statement with cases '+' and '-'
                Console.WriteLine("Input +/- or +Adam/-Adam: ");
                string input = Console.ReadLine();
                char nav = input[0];//is the + or -
                string value = input.Substring(1);
                switch (nav)
                {
                    //'+': Add the rest of the input to the list(The user could write + Adam and "Adam" would be added to the list)
                    case '+':
                        AddToList(value);
                        PrintListCountAndCapacity();
                        break;
                    //'-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                    case '-':
                        RemoveFromList(value);
                        PrintListCountAndCapacity();
                        break;
                    case '0':
                        programRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please input + or -");
                        break;
                }

            } while (programRun);
        }

        private static void PrintListCountAndCapacity()
        {
            Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
        }

        private static void RemoveFromList(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Write the text you want to input inside the list: ");
                string textInput = Console.ReadLine();
                list.Remove(textInput);
                messageAdded(textInput);
            }
            else
            {
                Console.WriteLine(value);
                list.Remove(value);
                messageAdded(value);
            }
        }


        private static void AddToList(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Write the text you want to input inside the list: ");
                string textInput = Console.ReadLine();
                list.Add(textInput);
                messageRemoved(textInput);
            }
            else
            {
                list.Add(value);
                messageRemoved(value);
            }
        }

        private static void messageAdded(string value)
        {
            Console.WriteLine($"\"{value}\" were removed from the list");
        }

        private static void messageRemoved(string value)
        {
            Console.WriteLine($"\"{value}\" were added to the list");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            //Loop this method untill the user inputs something to exit to main menue.
            bool programRun = true;
            do
            {
                Console.WriteLine("\n0: Exit\n+: To enqueue a person (+ or +Adam) \n-: to deueue a person from queue");
                string input = Console.ReadLine();
                char nav = input[0];//is the + or -
                string value = input.Substring(1);
                //Create a switch with cases to enqueue items or dequeue items
                switch (nav)
                {
                    //'+': Add a person to the queue
                    case '+':
                        if (string.IsNullOrWhiteSpace(value))
                        {
                            Console.WriteLine("Input the name of person you want put on inside the queue: ");
                            string textInput = Console.ReadLine();
                            queue.Enqueue(textInput);

                        }
                        else
                        {
                            queue.Enqueue(value);
                        }
                        //Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
                        PrintQueue();

                        break;
                    //'-': Remove the at the front from the queue
                    case '-':
                        queue.Dequeue();
                        PrintQueue();
                        break;
                    case '0':
                        programRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please input + or -");
                        break;
                }


            } while (programRun);


        }

        private static void PrintQueue()
        {
            int i = 0;
            Console.WriteLine("-----------Queue-----------");
            foreach (var item in queue)
            {
                Console.WriteLine($"{++i}: {item}"); ;
            }
            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
    }
}

