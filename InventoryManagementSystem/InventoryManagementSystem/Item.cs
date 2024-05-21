using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    // This class represents an item in the inventory
    public class Item
    {
        // Properties for item attributes: ID, Name, Price, and Quantity
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Constructor to initialize an item with provided ID, Name, Price, and Quantity
        public Item(int id, string name, decimal price, int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // Method to display the details of the item
        public void Display()
        {
            // Prints the item details
            Console.WriteLine($"ID: {ID}, Name: {Name}, Price: {Price:C}, Quantity: {Quantity}");
        }
    }
}
