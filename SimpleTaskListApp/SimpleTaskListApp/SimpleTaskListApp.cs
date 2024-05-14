using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskListApp
{
    internal class SimpleTaskListApp
    {
        // My TODO list should:
        // - allow us to exit
        // - allow us to add items to our TODO list
        // - allow us to view what's in the list
        // - allow us to remove items from our TODO list
        // - allow us to update items from our TODO list


        // Declaring todoListItems as a static field so that it's accessible to all methods
        static List<string> todoListItems = new List<string>();

        // The entry point of the program
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to the TODO list!");

            // Main loop to display options and handle user input
            while (true)
            {
                // Displaying options to the user
                Console.WriteLine("Here are the options you can select:");
                Console.WriteLine("0 - exit");
                Console.WriteLine("1 - view TODO list");
                Console.WriteLine("2 - add to TODO list");
                Console.WriteLine("3 - remove from TODO list");
                Console.WriteLine("4 - update TODO list");

                // Reading user input
                string userInput = Console.ReadLine();
                int optionId;
                // Parsing user input to integer
                // int.TryParse: Converts the string representation of a number to its 32-bit signed integer equivalent.
                // Also this method returns a Boolean value indicating whether the conversion succeeded or failed.
                // userInput: The string that represents the number you want to convert and optionId is just store the value.
                bool optionParseResult = int.TryParse(userInput, out optionId);
                if (!optionParseResult)
                {
                    // Inform the user if input is not an integer
                    Console.WriteLine("Input was not an integer!");
                    continue;
                }

                // Call appropriate method based on user input
                switch (optionId)
                {
                    case 0:
                        Exit(); // Exit the program
                        break;
                    case 1:
                        ViewTask(); // View TODO list
                        break;
                    case 2:
                        AddTask(); // Add to TODO list
                        break;
                    case 3:
                        RemoveTask(); // Remove from TODO list
                        break;
                    case 4:
                        UpdateTask(); // Update TODO list
                        break;
                    default:
                        Console.WriteLine("That option is not valid!"); // Inform the user of invalid input
                        break;
                }
            }
        }

        // Method to add a task to the TODO list
        static void AddTask()
        {
            Console.WriteLine("Please enter your TODO list item and then press enter:");
            string newTodoListItem = Console.ReadLine();
            todoListItems.Add(newTodoListItem);
            Console.WriteLine("Your task is Successfully added!!");
        }

        // Method to remove a task from the TODO list
        static void RemoveTask()
        {   //first we will list all the task index so that user can choose
            Console.WriteLine("Your TODO list index are:");
            for (int i = 0; i < todoListItems.Count; i++)
            {
                string item = todoListItems[i];
                Console.WriteLine("\t" + i + " - " + item);
            }
            Console.WriteLine("Please enter the index of the TODO list item to remove and then press enter:");

            string userInputForRemoveIndex = Console.ReadLine();
            int removeIndex;
            bool removeIndexParseResult = int.TryParse(userInputForRemoveIndex, out removeIndex);
            if (!removeIndexParseResult)
            {
                // Inform the user if input is not an integer
                Console.WriteLine("Input was not an integer!");
                return;
            }

            if (removeIndex < 0 || removeIndex >= todoListItems.Count)
            {
                // Inform the user if input is out of range
                Console.WriteLine("Input must be non-negative and less than the size of the collection!");
                return;
            }

            // Removing the task from the list
            todoListItems.RemoveAt(removeIndex);
            Console.WriteLine("Your task is Successfully removed!!");

        }

        // Method to update a task in the TODO list
        static void UpdateTask()
        {   //first we will list all the task index so that user can choose
            Console.WriteLine("Your TODO list index are:");
            for (int i = 0; i < todoListItems.Count; i++)
            {
                string item = todoListItems[i];
                Console.WriteLine("\t" + i + " - " + item);
            }

            Console.WriteLine("Please enter the index of the TODO list item to update and then press enter:");
            string userInputForUpdateIndex = Console.ReadLine();
            int updateIndex;
            bool updateIndexParseResult = int.TryParse(userInputForUpdateIndex, out updateIndex);
            if (!updateIndexParseResult)
            {
                // Inform the user if input is not an integer
                Console.WriteLine("Input was not an integer!");
                return;
            }

            if (updateIndex < 0 || updateIndex >= todoListItems.Count)
            {
                // Inform the user if input is out of range
                Console.WriteLine("Input must be non-negative and less than the size of the collection!");
                return;
            }

            Console.WriteLine("Please enter the new description for the TODO list item:");
            string newDescription = Console.ReadLine();

            todoListItems[updateIndex] = newDescription;
            Console.WriteLine("Your task is Successfully updated!!");
        }

        // Method to view all tasks in the TODO list
        static void ViewTask()
        {
            Console.WriteLine("Your TODO list:");
            for (int i = 0; i < todoListItems.Count; i++)
            {
                string item = todoListItems[i];
                Console.WriteLine("\t" + i + " - " + item);
            }
        }

        // Method to exit the program
        static void Exit()
        {
            Console.WriteLine("Thanks for using the TODO list! Bye!");
            Environment.Exit(0);
        }



    }
}
    

