using System;
using System.Linq.Expressions;

namespace SpaceExplorer
{
    public class GameEngine
    {
        Inventory backpack = new Inventory();
        Map GameMap = new Map();        
        Item item = new Item("thing");
       
        
        
        public void GameLoop() //Main Loop
        {
            bool Exit = false;
            string[] Getinput;
            string line;

            do
            {
                MainMenu();
                line = Console.ReadLine();
                Getinput = line.Split();
                if(Getinput[0] != "close")
                {
                    Console.WriteLine("Invalid Command");
                    Console.WriteLine(" ");
                }
            }while(Getinput[0]!= "close");
            
            Console.Clear();

            backpack.LoadBackpack();

            if (GameMap.WasExplored() == false)
            {
                GameMap.eXamine();  
            }

            do
            {
                line = Console.ReadLine();
                Getinput = line.Split();
                switch (Getinput[0])
                {
                    case "north":
                    case "n":
                        GameMap.Move(-1, 0);
                        break;
                    case "south":
                    case "s":
                        GameMap.Move(1, 0);
                        break;
                    case "east":
                    case "e":
                        GameMap.Move(0, 1);
                        break;
                    case "west":
                    case "w":
                        GameMap.Move(0, -1);
                        break;
                    case "End":
                        Exit = true;
                        break;
                    case "examine":
                    case "x":
                        GameMap.eXamine();
                        break;
                    case "map":
                    case "m":
                        GameMap.ShowMap();
                        break;
                    case "inventory":
                    case "i":
                        backpack.ListInventory();
                        break;
                    case "drop":
                        GameMap.CurrentRoom.inventory.GetItem(backpack.DropItem(Getinput[1]));
                        break;
                    case "pickup":
                        backpack.GetItem(GameMap.CurrentRoom.inventory.DropItem(Getinput[1]));
                        break;
                    case "search":
                        GameMap.CurrentRoom.search();
                        break;
                    case "control":
                    case "help":
                    case "controls":
                        MainMenu(); //Main Menu at start
                        break;
                    case "close":
                        Console.Clear();
                        break;
                        
                   
                    
                    default:
                        Console.WriteLine("Invalid Command");
                        Console.WriteLine(" ");
                        break;
                    }
            } while (Exit != true);
        }

        void MainMenu()//Show menu and controls
        {
            string Menuline;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:MenuText.txt");
            Menuline = file.ReadLine();
            while (Menuline.Equals("end") == false)
            {
                Console.WriteLine(Menuline);
                Menuline = file.ReadLine();    
            }
        }

        private void debugOut(string message) //Debug messages
        {
            //Console.WriteLine(message);
        }
    }
}