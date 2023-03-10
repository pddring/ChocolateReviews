using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class ValidatedInput
    {
        /// <summary>
        /// Ask the user to enter a number.
        /// The user will be prompted repeatedly until they enter an integer
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <returns>Integer value intered by the user</returns>
        public static int ReadInt(string prompt)
        {
            // default value
            int value = 0;

            // show the prompt to the user
            Console.Write(prompt);

            // keep asking until they enter an integer
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a number");
            }

            // return the result
            return value;
        }

        /// <summary>
        /// Ask the user to enter a string 
        /// Input will be validated using a length check between a minimum and maximum length
        /// </summary>
        /// <param name="prompt">Prompt to display to the user</param>
        /// <param name="minLength">Minimum length (inclusive)</param>
        /// <param name="maxLength">Maximum length (inclusive)</param>
        /// <returns>Value that the user enters</returns>
        public static string ReadString(string prompt, int minLength, int maxLength)
        {
            string value = "";
            Console.Write(prompt);
            value = Console.ReadLine();

            // repeat until length check succeeds
            while (value.Length < minLength || value.Length > maxLength)
            {
                Console.Write(prompt);
                value = Console.ReadLine();
            }
            return value;
        }
    }
}
