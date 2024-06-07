using System;
using System.Collections.Generic;

namespace PlantNurseryInventoryManagement
{
    // Class to represent an inventory item
    class InventoryItem
    {
        public string ItemName { get; set; }
        public int QuantityInStock { get; set; }
        public double PricePerUnit { get; set; }

        // Constructor
        public InventoryItem(string itemName, int quantity, double price)
        {
            ItemName = itemName;
            QuantityInStock = quantity;
            PricePerUnit = price;
        }

        // Method to calculate the total value of the item in stock
        public double CalculateValue()
        {
            return QuantityInStock * PricePerUnit;
        }
    }

    // Class to represent the plant nursery
    class PlantNursery
    {
        // Properties
        public string Name { get; }
        public string Owner { get; }
        public string Address { get; }

        // List to hold inventory items
        private List<InventoryItem> inventory;

        // Constructor
        public PlantNursery(string name, string owner, string address)
        {
            Name = name;
            Owner = owner;
            Address = address;
            inventory = new List<InventoryItem>();
        }

        // Method to add a new item to the inventory
        public void AddItem(string itemName, int quantity, double price)
        {
            InventoryItem newItem = new InventoryItem(itemName, quantity, price);
            inventory.Add(newItem);
            Console.WriteLine("Item added successfully.");
        }

        // Method to display all items in the inventory
        public void DisplayAllItems()
        {
            Console.WriteLine("Inventory Items:");
            double totalValue = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                InventoryItem item = inventory[i];
                Console.WriteLine($"{i + 1}. {item.ItemName} - Quantity: {item.QuantityInStock}, Price per Unit: ${item.PricePerUnit}, Total Value: ${item.CalculateValue()}");
                totalValue += item.CalculateValue();
            }
            Console.WriteLine($"Total Inventory Value: ${totalValue}");
        }

        // Method to delete an individual item from the inventory
        public void DeleteItem(int index)
        {
            if (index >= 0 && index < inventory.Count)
            {
                inventory.RemoveAt(index);
                Console.WriteLine("Item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid item index.");
            }
        }

        // Method to clear the entire inventory
        public void ClearInventory()
        {
            inventory.Clear();
            Console.WriteLine("Inventory cleared successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize nursery and inventory
            PlantNursery myNursery = new PlantNursery("My Nursery", "John Doe", "123 Main St");
            myNursery.AddItem("Rose", 10, 5.99);
            myNursery.AddItem("Tomato Seeds", 50, 0.99);
            myNursery.AddItem("Garden Shovel", 20, 12.50);

            // Display nursery information
            Console.WriteLine($"Welcome to {myNursery.Name}!");
            Console.WriteLine($"Owner: {myNursery.Owner}");
            Console.WriteLine($"Address: {myNursery.Address}");

            // Menu loop
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a New Item to the Inventory");
                Console.WriteLine("2. Display All Items");
                Console.WriteLine("3. Delete an Individual Item from the Inventory");
                Console.WriteLine("4. Clear Inventory");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Item Name: ");
                            string? itemName = Console.ReadLine();
                            Console.Write("Enter Quantity in Stock: ");
                            int quantity;
                            if (int.TryParse(Console.ReadLine(), out quantity))
                            {
                                Console.Write("Enter Price per Unit: ");
                                double price;
                                if (double.TryParse(Console.ReadLine(), out price))
                                {
                                    myNursery.AddItem(itemName, quantity, price);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid price. Please enter a valid number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity. Please enter a valid number.");
                            }
                            break;
                        case 2:
                            myNursery.DisplayAllItems();
                            break;
                        case 3:
                            Console.Write("Enter the index of the item to delete: ");
                            int index;
                            if (int.TryParse(Console.ReadLine(), out index))
                            {
                                myNursery.DeleteItem(index - 1);
                            }
                            else
                            {
                                Console.WriteLine("Invalid index. Please enter a valid number.");
                            }
                            break;
                        case 4:
                            myNursery.ClearInventory();
                            break;
                        case 5:
                            exit = true;
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                }
            }
        }
    }
}