using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chocolate Bar Review admin console");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("==========");

            bool running = true;

            while (running)
            {
                // keep looping until the user presses Q or q
                Console.WriteLine("1) Show all reviews");
                Console.WriteLine("2) Add new review");
                Console.WriteLine("3) Update review");
                Console.WriteLine("4) Delete review");
                Console.WriteLine("Q) Quit");

                string userInput = Console.ReadLine().ToLower();
                switch(userInput)
                {
                    case "1":
                        Console.WriteLine("Showing all reviews:");
                        break;
                    case "2":
                        Console.WriteLine("Adding new review:");
                        break;
                    case "3":
                        Console.WriteLine("Which review would you like to update? (enter ID):");
                        break;
                    case "4":
                        Console.WriteLine("Which review would you like to delete? (enter ID):");
                        break;

                    case "q":
                        running = false;
                        break;
                }
            }
        }
    }
}
