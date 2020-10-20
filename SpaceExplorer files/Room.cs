using System;

namespace SpaceExplorer
{
    public class Room 
    {
        private string description;
        private bool isRoom;
        private bool explored;
        public Inventory inventory;

        public Room(string myDescription, bool myIsRoom) //Constructer
        {
            description = myDescription;
            isRoom = myIsRoom;
            explored = false;
            inventory = new Inventory();
        }

        public bool WasExplored() //Check to see if it was explored
        {
            return explored;
        }  
        
        public void SetIsRoom(bool NewIsRoom)  //Set a valid room as a room
        {
            isRoom = NewIsRoom;
        }

        public bool GetIsRoom() //See if it is a room
        {
            return isRoom;
        }

        public void describe() //Load descriptions
        {
            Console.WriteLine(description);
            explored = true;
        }

        public void search() //Fuction to search for items
        {
            inventory.search();
        }

        public void SetDescription(string words) //Set the description of the room
        {
            description = words;
        }

        public bool Look() //Look for paths ahead 
        {
            if(isRoom == false)
                explored = true;

            return isRoom;
        }

        private void debugOut(string message) //Debug messages
        {
            //Console.Write(message);
        }
    }
}