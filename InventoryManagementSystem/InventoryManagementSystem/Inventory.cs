using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    // This class manages the collection of items in the inventory
    public class Inventory
    {
        // List to store items in the inventory
        private List<Item> items = new List<Item>();

        // Method to add a new item to the inventory
        public void AddItem(Item item)
        {
            // Adds the provided item to the list
            items.Add(item);
            // Confirms that the item has been added
            Console.WriteLine("Item added successfully.");
        }

        // Method to display all items in the inventory
        public void DisplayAllItems()
        {
            // Inform the user that these are the inventory items
            Console.WriteLine("Inventory Items:");
            // Loop through each item in the list and display its details
            foreach (var item in items)
            {
                item.Display();
            }
        }

        // Method to find an item by its ID
        public Item FindItemById(int id)
        {
            // Use the Find method to locate the item with the given ID
            return items.Find(item => item.ID == id);
        }

        // Method to find items by their name
        public List<Item> FindItemsByName(string name)
        {
            // Use the FindAll method to locate items with the given name
            return items.FindAll(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to update an item's information
        public void UpdateItem(int id, string name, decimal price, int quantity)
        {
            // Find the item by its ID
            Item item = FindItemById(id);
            // Check if the item exists
            if (item != null)
            {
                // Update the item's properties with the new values
                item.Name = name;
                item.Price = price;
                item.Quantity = quantity;
                // Confirms that the item has been updated
                Console.WriteLine("Item updated successfully.");
            }
            else
            {
                // Inform the user that the item was not found
                Console.WriteLine("Item not found.");
            }
        }

        // Method to delete an item from the inventory
        public void DeleteItem(int id)
        {
            // Find the item by its ID
            Item item = FindItemById(id);
            // Check if the item exists
            if (item != null)
            {
                // Remove the item from the list
                items.Remove(item);
                // Confirms that the item has been deleted
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                // Inform the user that the item was not found
                Console.WriteLine("Item not found.");
            }
        }
        // Method to sort items by ID
        public void SortItemsById()
        {
            items.Sort((x, y) => x.ID.CompareTo(y.ID));
            Console.WriteLine("Items sorted by ID.");
        }
    }

}
