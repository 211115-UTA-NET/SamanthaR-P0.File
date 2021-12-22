using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace P0Store
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            string connnectionString = File.ReadAllText("C:/Users/roder/Revature/BookDBConnectionString.txt");
            using SqlConnection connection = new(connnectionString); 
            //Fields
            
            int userStatueSelection;
            int userDesiredQty;
            string[] stores = {"Seattle", "Portland", "Sacramento"};
            int storeChoice = 0;
            string response;
            bool verifyCustomer = false;

            WriteLine("Welcome to the Garden Ceramics Store for Misfit Toys!");
        do{
            WriteLine("Are you a new customer? y/n?");
            response = ReadLine();
            string yesno = response.ToLower();
            if(yesno == "y")
            {
                
                WriteLine("Please enter your first name.");
                string firstName = ReadLine();
                WriteLine("Please enter your last name");
                string lastName = ReadLine();
                WriteLine("What is the first line of your address for shipping?");
                string shippingAddress= ReadLine();
                WriteLine("What is your city?");
                string shippingCity = ReadLine();
                WriteLine("What is your state?");
                string shippingState = ReadLine();
            
                connection.Open();
                string commandText1 = $"INSERT INTO Garden_Customer (Customer_First_Name, Customer_Last_Name, Shipping_Address, Shipping_City, Shipping_State) VALUES ('{firstName}', '{lastName}', '{shippingAddress}', '{shippingCity}', '{shippingState}');";
                using SqlCommand command1 = new(commandText1, connection);
                connection.Close();
                WriteLine($"It's nice to meet you, {firstName} {lastName}!");
                verifyCustomer = true;
                break; 
            } 
            else 
            {
                WriteLine("Let's look you up in our database. What is your first name?");
                string firstName = ReadLine();
                WriteLine("What is your last name?");
                string lastName = ReadLine();
                WriteLine("What is your city?");
                string shippingCity = ReadLine();
                connection.Open();
                string commandText2 = $"SELECT * FROM Garden_Customer WHERE Customer_First_Name = '{firstName}' AND Customer_Last_Name = '{lastName}' AND Shipping_City = '{shippingCity}';";
                WriteLine("Printing search results... \n-----------------------------------------");
                using SqlCommand command5 = new(commandText2, connection);
                using SqlDataReader reader2 = command5.ExecuteReader();
                reader2.Read();
                Write(reader2.GetString(1)+" "+reader2.GetString(2)+", "+reader2.GetString(3)+", "+reader2.GetString(4)+", "+reader2.GetString(5));
                connection.Close();
                WriteLine("----------------------------------------- \nDid we find you? y/n");
                string verifyCorrect = ReadLine();
                yesno = verifyCorrect.ToLower();
                if (yesno == "y")
                        verifyCustomer = true;
                else
                        WriteLine("You are a new customer. We will need to add you to our database.");
                }
        }while(!verifyCustomer);
            //while(verifyCustomer == false);
            
            WriteLine("\nWhat store are you making your order from today? \nPlease select from the following:\nFor Seattle, enter 1 \nFor Portland, enter 2 \nFor Sacramento, enter 3");
            
            while(storeChoice != null)
            {
                try{
                    storeChoice = Convert.ToInt32(ReadLine());
                    WriteLine($"You have selected {stores[storeChoice-1]}. Excellent choice!");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    WriteLine("Error: Options are from 1 to 3 \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Error: you did not enter a number. \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
            }
            

            // do {
            //     WriteLine("");
            // }while();
            
            using SqlConnection connection3 = new(connnectionString); 
            connection3.Open();
            string commandText = "SELECT * FROM Statue;";
            
            //then insert those variables into the appropriate information by columns of the customer table
 
            using SqlCommand command2 = new(commandText, connection3);
            //take this command and put it through this connection

            using SqlDataReader reader = command2.ExecuteReader();

            while (reader.Read()) //reads one row at a time, getting one value for each column, indexes at [0], you must know the type and the value that will come out of the database
            {
    
                int item_ID = reader.GetInt32(0);

                string style = reader.GetString(1);
    
                decimal price = reader.GetDecimal(2);

                Console.WriteLine($"Enter {item_ID} to select '{style}' for ${price}");
             }

            

            //decimal total = 0;
            userStatueSelection = Convert.ToInt32(ReadLine());
            int itemID = userStatueSelection;
            WriteLine($"You selected {itemID}. How many would you like to order?");
            connection.Close();
            //use a do-while loop -- so they can continue to shop if they want more items
            //have a readline for the user's desired option and quantity
            //want to take in a user option and quantity and create a statement that can 1. connection.open(), 2. reduce the inventory at the selected store by their quantity choice, 3. connection.close() 
            //total += qty*price
        //} (while the user's input != 1,2,3,4,or5)
            //
            /* connection.Open;
            
            
            Order thisOrder = new()
            string commandText = "SELECT  FROM ;";

            */
           
}}}