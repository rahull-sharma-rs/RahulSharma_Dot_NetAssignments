using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a predefined user for authentication
            User user = new User("rahul", "rahul@123");

            bool authenticated = false;

            while (!authenticated)
            {
                // Prompt the user for username and password
                Console.WriteLine("Welcome to the Inventory Management System");
                Console.Write("Enter Username: ");
                string inputUsername = Console.ReadLine();
                Console.Write("Enter Password: ");
                string inputPassword = Console.ReadLine();

                // Validate the user's credentials
                if (user.ValidateCredentials(inputUsername, inputPassword))
                {
                    // Authentication successful, proceed with inventory management
                    Console.WriteLine("Login successful!");
                    authenticated = true;
                }
                else
                {
                    // Inform the user if the credentials are invalid
                    Console.WriteLine("Invalid username or password. Access denied.");
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("0. Exit");

                    // Prompt the user to select an option
                    Console.Write("Select an option: ");
                    string input = Console.ReadLine();
                    int option;

                    // Validate if the input is an integer
                    if (int.TryParse(input, out option))
                    {
                        if (option == 0)
                        {
                            // Exit the application if the user chooses to exit
                            return;
                        }
                        // Otherwise, loop again to try authentication
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }

            // Create an instance of the Inventory class
            Inventory inventory = new Inventory();

            // Loop until the user decides to exit
            while (true)
            {
                // Display the menu options to the user
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Find Item by ID");
                Console.WriteLine("4. Find Items by Name");
                Console.WriteLine("5. Update Item");
                Console.WriteLine("6. Delete Item");
                Console.WriteLine("7. Sort Items by ID");
                Console.WriteLine("0. Exit");
                // Prompt the user to select an option
                Console.Write("Select an option: ");
                // Read the user's input
                string input = Console.ReadLine();
                int option;

                // Validate if the input is an integer
                if (!int.TryParse(input, out option))
                {
                    // Inform the user if the input is invalid
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                // Perform the corresponding action based on the user's selection
                switch (option)
                {
                    case 1:
                        // Call method to add a new item
                        AddNewItem(inventory);
                        break;
                    case 2:
                        // Call method to display all items
                        inventory.DisplayAllItems();
                        break;
                    case 3:
                        // Call method to find an item by ID
                        FindItem(inventory);
                        break;
                    case 4:
                        // Call method to find items by name
                        FindItemsByName(inventory);
                        break;
                    case 5:
                        // Call method to update an item
                        UpdateExistingItem(inventory);
                        break;
                    case 6:
                        // Call method to delete an item
                        DeleteExistingItem(inventory);
                        break;
                    case 7:
                        // Call method to sort items by ID
                        inventory.SortItemsById();
                        break;
                    case 0:
                        // Exit the application
                        return;
                    default:
                        // Inform the user if the option is invalid
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            }
        }

        // Method to add a new item to the inventory
        static void AddNewItem(Inventory inventory)
        {
            // Prompt the user to enter item details
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            // Create a new item instance with the provided details
            Item item = new Item(id, name, price, quantity);
            // Add the new item to the inventory
            inventory.AddItem(item);
        }

        // Method to find an item in the inventory by its ID
        static void FindItem(Inventory inventory)
        {
            // Prompt the user to enter the item ID
            Console.Write("Enter Item ID to find: ");
            int id = int.Parse(Console.ReadLine());
            // Find the item in the inventory
            Item item = inventory.FindItemById(id);
            // Check if the item was found
            if (item != null)
            {
                // Display the item details
                item.Display();
            }
            else
            {
                // Inform the user if the item was not found
                Console.WriteLine("Item not found.");
            }
        }

        // Method to update an existing item in the inventory
        static void UpdateExistingItem(Inventory inventory)
        {
            // Prompt the user to enter the item ID
            Console.Write("Enter Item ID to update: ");
            int id = int.Parse(Console.ReadLine());
            // Prompt the user to enter the new item details
            Console.Write("Enter new Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Item Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter new Item Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            // Update the item in the inventory
            inventory.UpdateItem(id, name, price, quantity);
        }

        // Method to delete an existing item from the inventory
        static void DeleteExistingItem(Inventory inventory)
        {
            // Prompt the user to enter the item ID
            Console.Write("Enter Item ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            // Delete the item from the inventory
            inventory.DeleteItem(id);
        }

        static void FindItemsByName(Inventory inventory)
        {
            // Prompt the user to enter the item name
            Console.Write("Enter Item Name to find: ");
            string name = Console.ReadLine();
            // Find the items in the inventory
            List<Item> items = inventory.FindItemsByName(name);
            // Check if any items were found
            if (items.Count > 0)
            {
                // Display the found item details
                Console.WriteLine("Found Items:");
                foreach (var item in items)
                {
                    item.Display();
                }
            }
            else
            {
                // Inform the user if no items were found
                Console.WriteLine("No items found with the given name.");
            }
        }

    }
}

