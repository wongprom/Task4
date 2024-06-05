using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program.
        /// </summary>
        /// <param name="args"></param>
        /// 
        # region Frågor som ska besvaras
        /*
            1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dessa grundläggande funktion.
                SVAR: Minnet är uppdelat i en stack och heap. 
                    Stacken är som staplade skolådor. För att komma åt nedre lådor måste man först lyfta bor de övre. 
                    Stacken har koll på vilka metoder och anrop som körs. Efter att metoden/anropet körts kastas den från minnet, alltså är stacken självunderhållande.
                    


                    Heapen, där ligger allting huller om buller, men är lätt åtkomligt om du vet vad du vill ha.
                    Heapen är inte självunderhållande, utan behöver oroa sig för garbage Collection.

            2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
                SVAR: Value Types är: bool, byte, char, decimal, double, enum, float, int, long, sbyte, short, struct, uint, ulong, ushort. Value Types lagras där den deklareras, anitngen på stacken eller heapen. 
                    
                    Reference Types ärver från System.Objects : class, interface, object, delegate och string.  Reference Types lagras alltid på heapen. En Reference Type försvinner inte från minnet efter att den körts.


            3. Följande metoder genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?
                SVAR: ReturnValue() är x och y Value Types.
                    ReturnValue2() är x och y Reference Types. Efter y = x; blir y en kopia av x instansen där både x och y pekar på samma "hink".

        */
        # endregion svar
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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             * 
             * 2.När ökar listans kapacitet?
             *  SVAR: Den ökar när kapaciteten är full.
             * 3. Med hur mycket ökar kapaciteten?
             *  SVAR: med 4.
             * 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
             *  Svar: Kapaciteten ligger på 4 från början
             * 5. Minskar kapaciteten när elementet tas bort ur listan?
             *  SVAR: Nej.
             * 6. När är det då fördelaktigt att använda en egendefinerad array istället för en lista?
             *  SVAR: När man vet från början hur stor arrayn ska vara.
            */

            List<string> theList = new List<string>();
            Console.WriteLine("Type ex '+Adam' to add Adam to list.");
            Console.WriteLine("Type ex'-Adam' to remove Adam from list.");
            Console.WriteLine("Type '0' to exit Examine a List.");

            bool isContinue = true;
            while (isContinue)
            {
                string input = Console.ReadLine()!;
                char nav = input.ToCharArray()[0];
                string value = input.Substring(1);
               

                switch (nav)
                {
                    case '+':
                        Console.Clear();
                        theList.Add(value);
                        Console.WriteLine($"{value} is added to list");
                        Console.WriteLine($"Count: {theList.Count}.");
                        Console.WriteLine($"Capacity: {theList.Capacity}.");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"{value} is Removed from list");
                        Console.WriteLine($"Count: {theList.Count}.");
                        Console.WriteLine($"Capacity: {theList.Capacity}.");
                        break;  
                    case '0':
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Use '+' to add or '-' to remove. '0' to exit Examine a List");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Queue<string> queue = new Queue<string>();
            Console.WriteLine("Type ex '+Adam' to queue Adam.");
            Console.WriteLine("Type ex '-' to remove person first in queue. ");
            Console.WriteLine("Type '0' to exit Examine a List.");

            bool isContinue = true;

            while (isContinue)
            {

                string input = Console.ReadLine()!;
                char nav = input.ToCharArray()[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        Console.Clear();
                        queue.Enqueue(value);
                        Console.WriteLine($"{value} has ben queued.");
                        Console.WriteLine();
                        Console.WriteLine($"Queue line: ");
                        foreach (string person in queue) Console.WriteLine(person);
                        break;
                    case '-':
                        if (queue.Count > 0)
                        {
                            Console.Clear();
                            string dequeuedItem = queue.Dequeue();
                            Console.WriteLine($"{dequeuedItem} has been dequeued.");
                            Console.WriteLine();
                            Console.WriteLine($"Queue line: "); 
                            foreach (string person in queue) Console.WriteLine(person);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty. Cannot dequeue.");
                        }
                        break;
                    case '0':
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command. Use '+' to add or '-' to remove. '0' to exit Examine a List");
                        break;
                }
            }
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

