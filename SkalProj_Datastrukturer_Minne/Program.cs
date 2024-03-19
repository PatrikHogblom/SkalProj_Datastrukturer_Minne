using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;

/*
 Namn: Patrik Högblom
 Datum: 2024-03-19
 */

//Svar till frågorna: 
/*

Teori och fakta:

1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion:

Svar: 

Stacken är en Last-In First-Out(LIFO) datastruktur. Ett exempel på hur stacken fungerar är att är om du lägger 
3 böcker i en låda, för att komma åt första boken som är längst ner i lådan så behöver du flytta de 2 övre böckerna 
först. Stacken är självunderhållande och därmed minnet rensas när metoden har exekverats klart.

Heap används för lagra dynamiskt allokerade objekt, när en objekt skapas så skapas en pekare/referens till objektet i stacken. 
Heap datastrukturen efterliknas med att ha en hög med kläder utspritt och är tillängligt på en gång med enkel åtkomst, dvs lätt och fort att
komma åt dess objekt om vi vet vad vi vill komma åt. Från skillnad stacken så är inte heapen självunderhållande och därmed kommer heapminnet inte 
rensas när efter metoden har exekverats klart och därmed behöver oroa sig för "Garbage Collection". 

2.Vad är Value Types respektive Reference Types och vad skiljer dem åt? 

Svar: 

Value Types: Lagras på stacken, exempel på värdestyper är: int, bool, byte, char, decimal, double, long, float, enum, short, struct och mera.

Reference Typer: Själva objektet/datan av referenstyperna lagras i heapen, medan referensen till typerna sparas i stacken som i sin tur pekar 
mot objektet som finns i heapen. Exempel på referenstyper är class, interface, object, delegate, string

3. Följande metoder (se bild \Ovning4_SkalProj\teoriOchFaktaFråga3.png) genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför? 

ReturnValue():

1. denna metod först lägger till värdetypen x i stacken, dvs x = 3
2. därefter så lägger den till värdetypen y överst i stacken, här har vi y = x och därmed så får vi y = 3
3. nu ändrar metoden värdet genom tilldela y = 4
4. sist så returnerar vi värdestypen x som har värdet 3.

ReturnValue2():
1. Ni skapar först klassobjektet Myint x, detta leder til vi lägger till en referens till x i stacken samt objektvärdet i heap, x.MyValue = 3
2. Nu skapar vi klassobjektet Myint y, detta leder till vi lägger en referens till y överst i stacken över x refererensen samt lägger till objektet y i heapen
3. Då vi använder y = x, så betyder att y och x kommer att peka på samma objekt, därmed blir minnesobjektet samma och därmed y.MyValue = x.MyValue = 3
4. Nu tilldelar vi värdet y.MyValue = 4, då objektet y och x pekar på samma minnesobjekt så innebär om vi gör ändringar i y.MyValue så kommer x.MyValue att ändras, 
   dvs y.MyValue = x.MyValue = 4
5. sist så returnerar vi objektvärdet 4 från x.MyValue

Övning 1: 

1. Simulera följande kö på papper: 
    a.       ICA öppnar och kön till kassan är tom 
    b.      Kalle ställer sig i kön 
    c.       Greta ställer sig i kön 
    d.      Kalle blir expedierad och lämnar kön 
    e.      Stina ställer sig i kön 
    f.      Greta blir expedierad och lämnar kön 
    g.       Olle ställer sig i kön 
    h.      … 

svar: se sida 1 på Ovning4_SkalProj\PappersPresentation_övning4.pdf.

2. Implementera metoden ExamineQueue. Metoden ska simulera hur en kö fungerar genom att tillåta användaren att ställa element i kön (enqueue) och ta bort element 
ur kön (dequeue). Använd Queue-klassen till hjälp för att implementera metoden. Simulera sedan ICA-kön med hjälp av ditt program. 

Svar: Se ExamineQueue() på rad 296

Övning 3:

1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. 
   svar:  se sida 3 på Ovning4_SkalProj\PappersPresentation_övning4.pdf
   
   Varför är det inte så smart att använda en stack i det här fallet?
   svar: Det är inte smart att använda stacken likt ICA-kön då Kalle/första elementet måste vänta tills alla element har lämnat innan han kan lämna  stacken. 
   Genom att använda stack metoden kan göra att kalle blir fast på ICA tills stängning då det inte kommer några nya kunder.

2. Implementera en ReverseText-metod som läser in en sträng från användaren och med hjälp av en stack vänder ordning på tecken följden för att sedan skriva ut den 
   omvända strängen till användaren.

   svar: se rad 359 för implemenationen av ExamineStack() samt rad 431 för implementationen av ReverseText

Övning 4: 
1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad sträng på papper. Du ska använda dig av någon eller några av de datastrukturer vi 
   precis gått igenom. Vilken datastruktur använder du?

   svar: se sida 4 och 5 på Ovning4_SkalProj\PappersPresentation_övning4.pdf för hur lösningen gås igenom, Jag använder mig av stack datastrukturen för lösa denna uppgift.

2. Implementera funktionaliteten i metoden CheckParentheses. Låt programmet läsa in en sträng från användaren och returnera ett svar som reflekterar huruvida 
   strängen är välformad eller ej. 

   svar: se rad 454 för implementationen av CheckParentheses()

Övning 5: 
1. Illustrera förloppen för RecursiveOdd(1), RecursiveOdd(3) och RecursiveOdd(5) på papper för att förstå den rekursiva loopen.
   svar: se sida 6 på Ovning4_SkalProj\PappersPresentation_övning4.pdf för illustration

2. Skriv en RecursiveEven(int n) metod som rekursivt beräknar det n:te jämna talet.
   svar: se rad 196 för implemenation av RescursiveEven()

3. Implementera en rekursiv funktion för att beräkna tal i fibonaccisekvensen: (f(n) = f(n-1) + f(n-2))
   svar: se rad 187 för implementation av RecursiveFibonacci()

 */


namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        private static List<string> list = new List<string>();
        private static Queue<string> queue = new Queue<string>();
        private static Stack<string> stack = new Stack<string>();

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
                    + "\n5. RecursiveEven"
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
                        CheckParentheses();
                        break;
                    case '5':
                        Console.WriteLine("Which n:th even number do you want, input: ");
                        int resultEven;
                        int resultFibonacci;
                        if (int.TryParse(Console.ReadLine(), out int n))
                        {
                            resultEven = RecursiveEven(n);
                            resultFibonacci = RecursiveFibonacci(n);
                            Console.WriteLine($"The {n}:th even number is {resultEven}");
                            Console.WriteLine($"The Fibonacci sequence of n is {resultFibonacci}");

                        }
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        private static int RecursiveFibonacci(int n)
        {
            if(n <= 1)
            {
                return n;
            }
            return RecursiveFibonacci(n-1) + RecursiveFibonacci(n-2);
        }

        private static int RecursiveEven(int n)
        {
           if(n == 1)
           {
                return 2;
           }
           return RecursiveEven(n-1) + 2;
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

            //Implementera en ReverseText - metod som läser in en sträng från användaren och
            //med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
            //omvända strängen till användaren.

            bool programRun = true;
            do
            {
                //Implementera en ReverseText - metod som läser in en sträng från användaren
                Console.WriteLine("This method reverse your input with help of a stack and then pushes your reversed input into a new stack");
                Console.WriteLine("\n0: Exit\n+: To push your input in a reversed word,input (+ or +Adam) \n-: to Pop/remove the  reversed word from the stack");
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
                            stack.Push(reverseText(textInput));
                        }
                        else
                        {
                            stack.Push(reverseText(value));
                        }
                        //Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
                        PrintStack();

                        break;
                    //'-': Remove the at the front from the queue
                    case '-':
                        stack.Pop();
                        PrintStack();
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

        private static void PrintStack()
        {
            int i = stack.Count;
            Console.WriteLine("------------Stack----------");
            foreach (var item in stack)
            {
                Console.WriteLine($"{i--}: {item}");
            }
            Console.WriteLine("---------------------------");
        }
        /// <summary>
        /// Reverses the input string text using a stack and returns the reversed word 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>reversedWord</returns>
        private static string reverseText(string input)
        {
            //Use with help of a stack to reverse the order of the string
            Stack myStack = new Stack();
            foreach (var letter in input)
            {
                myStack.Push(letter);
            }

            var reversedWord = "";
            while (myStack.Count > 0) 
            {
                reversedWord += myStack.Pop();
            }

            //Print the reversed string
            Console.WriteLine($"reversed textinput: {reversedWord}");

            return reversedWord;
        }
        /// <summary>
        /// Reads in a string from the user and uses a stack to see paratheses are correctlty formatted or not
        /// </summary>
        static void CheckParentheses()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Stack<char> stackStarterParantheis = new Stack<char>();
            Console.WriteLine("input: ");

            string input = Console.ReadLine();

            //checks if the parathesis are correctly formated
            bool validFormat = true;

            //loop through each letter in the string input
            foreach (char letter in input)
            {
                //if the letter is either {,[,( then add push them to a stack
                if (letter == '{' || letter == '[' || letter == '(' )
                {
                    stackStarterParantheis.Push(letter);
                }
                //if the letter is },],) then check the top of the stack and see if it matches with current letter,
                //if so then pop the top stack value and go to next value and if the letter doesnt match then validFormat is set to false  
                else if(letter == '}' || letter == ']' || letter == ')')
                {
                    char topElement = stackStarterParantheis.Peek();
                    if ((topElement == '(' && letter == ')') || (topElement == '{' && letter == '}') || (topElement == '[' && letter == ']'))
                    {
                        stackStarterParantheis.Pop();
                    }
                    else
                    {
                        validFormat = false;
                    }
                }
            }

            Console.WriteLine($"The format is: {(validFormat == true ? "Correctly Formatted\n" : "Incorrectly Formatted\n")}");

        }

    }
}

