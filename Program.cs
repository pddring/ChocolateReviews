using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateReviews
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = @"C:\tmp\Reviews.mdf";

            // Check if database file exists in the tmp folder
            if(!File.Exists(filename))
            {
                Console.WriteLine($"Database not found at {filename}: copying a fresh version");
                
                // create the tmp folder if it doesn't exist
                if(!Directory.Exists(@"C:\tmp"))
                {
                    Directory.CreateDirectory(@"C:\tmp");
                }

                // if it doesn't, copy it
                File.Copy("Reviews.mdf", filename);
            }

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\tmp\Reviews.mdf;Integrated Security=True";
            connection.Open();
            Console.WriteLine("Hooray! We have a database!");
            connection.Close();




            Console.WriteLine(@"
 _____ _                    ______           _               
/  __ \ |                   | ___ \         (_)              
| /  \/ |__   ___   ___ ___ | |_/ /_____   ___  _____      __
| |   | '_ \ / _ \ / __/ _ \|    // _ \ \ / / |/ _ \ \ /\ / /
| \__/\ | | | (_) | (_| (_) | |\ \  __/\ V /| |  __/\ V  V / 
 \____/_| |_|\___/ \___\___/\_| \_\___| \_/ |_|\___| \_/\_/  
                                                             
                                                             ");
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
                Console.WriteLine("5) Show all users");
                Console.WriteLine("6) Add user");
                Console.WriteLine("7) Edit user");
                Console.WriteLine("8) Delete user");
                Console.WriteLine("Q) Quit");

                string userInput = Console.ReadLine().ToLower();
                string sql;
                switch(userInput)
                {
                    case "1":
                        Console.WriteLine("Showing all reviews:");
                        sql = "SELECT * FROM Reviews";

                        // adapted from: https://stackoverflow.com/questions/21709305/how-to-directly-execute-sql-query-in-c
                        connection.Open(); 
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataReader r = cmd.ExecuteReader();
                        while(r.Read())
                        {
                            Review existingReview = new Review(r);

                            Console.WriteLine(existingReview);
                        }
                        connection.Close(); 
                        break;
                    case "2":
                        Console.WriteLine("Adding new review:");
                        Review newReview = new Review(
                            -1,
                            ValidatedInput.ReadInt("Enter chocolate bar ID:"),
                            ValidatedInput.ReadInt("User ID:"),
                            ValidatedInput.ReadInt("Review score:"),
                            ValidatedInput.ReadString("Enter review:", 0, 255)
                            );
                        connection.Open();
                        /// TODO: fix db table so it auto increments the ID using IDENTITY(1,1)
                        sql = $"INSERT INTO Reviews (ChocolateBarID, UserID, Score, Comment) VALUES ({newReview.ChocolateBarID}, {newReview.UserID}, {newReview.Score}, '{newReview.Comment}')";
                        SqlCommand addCommand = new SqlCommand(sql, connection);
                        addCommand.ExecuteNonQuery();
                        connection.Close();
                        break;
                    case "3":
                        Console.WriteLine("Which review would you like to update? (enter ID):");
                        break;
                    case "4":
                        Console.WriteLine("Which review would you like to delete? (enter ID):");
                        break;
                    case "5":
                        Console.WriteLine("Show all users");
                        break;
                    case "6":
                        Console.WriteLine("Please enter the new user's first name:");
                        break;
                    case "7":
                        Console.WriteLine("Which user do you want to edit? (enter ID):");
                        break;
                    case "8":
                        Console.WriteLine("Which user would you like to delete? (enter ID):");
                        break;

                    case "q":
                        running = false;
                        break;
                }
            }
        }
    }
}
