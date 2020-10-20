using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceExplorer
{
    public class Inventory
    {
        public List<Item> inventoryList;


        public Inventory() //Constructer
        {
            inventoryList = new List<Item>();
        }

        public void Add(Item item) //Add the item to the inventory list
        {
            if (item.ItemName.Length != 0)
            {
                inventoryList.Add(item);
            }

            debugOut("Added to inventory: " + item.ItemName);
        }

        public void search() //See if an item is in the rooms inventory list
        {
            if (inventoryList.Count == 0)
            {
                Console.WriteLine("You search around the ground and find nothing");
            }
            else
            {
              Console.WriteLine("You search around the ground and find " + inventoryList.Count + " items:");
              ListInventory();  
            }   
        }

        public void ListInventory() //Function to list player's inventory
        {
            foreach (Item myItem in inventoryList)
            {
                Console.WriteLine(myItem.GetItemName());
            }
            Console.WriteLine(" ");
        }

        public void addArray(string[] array) //Add array for inventory
        {
            foreach (string itemname in array)
            {
                Add(new Item(itemname));
            } 
        }

        public Item DropItem(string itemName) //Drop item in room, or room "drops" item to player
        {
            Item item = inventoryList.First(x => x.ItemName == itemName);
            inventoryList.Remove(item);
            return item;
        }

        public void GetItem(Item itemName) //Puts item in room's or player's inventory
        {
           inventoryList.Add(itemName); 
        }

        public void LoadBackpack() //Loads backpack from text file
        {
            string[] pack;
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:Backpack.txt");
            line = file.ReadLine();
            while (line.Equals("end") == false)
            {
                pack = line.Split();
                addArray(pack);
                line = file.ReadLine();  
            }
        }

        private void debugOut(string message) //Debug messages
        {
            //Console.WriteLine(message);
        }
    }
}