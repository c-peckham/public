using System;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;

namespace SpaceExplorer
{
    public class Map
    {
        private int CurrentX = 0;
        private int CurrentY = 0;
        private int MaxX;// = 8;
        private int MaxY;// = 8;
        //check below  
        public Item items = new Item("thing");
        public Item.NotPickup nopick = new Item.NotPickup("thing");
       
        //check above
        public Room CurrentRoom;

        private Room[,] Rooms;// = new Room[1, 1];

        public Map() //Constructer
        {
            LoadMap();
           
            CurrentX = 0;
            CurrentY = 0;
        }

        public void Move(int TranslateY, int TranslateX) //Change Player location
        {
            int newY = CurrentY + TranslateY;
            int newX = CurrentX + TranslateX;


            if (newX < 0 || newY < 0 || newX >= MaxX || newY >= MaxY)
            {
                Console.WriteLine("That way is unsafe. There is a cliff.");
               
            }
            else if ((Rooms[newY, newX].GetIsRoom() == false))
            {
                Console.WriteLine("You can't go that way there is a wall there");
            }
            else
            {
                CurrentX = newX;
                CurrentY = newY;
                if (WasExplored() == false)
                {
                    eXamine();
                }
            }

            CurrentRoom = Rooms[CurrentY, CurrentX];
        }

        public bool WasExplored() //Mark as explored or not
        {
            return Rooms[CurrentY, CurrentX].WasExplored();
        }

        public void eXamine() //Examine way forward
        {
            debugOut("Examining");
            Rooms[CurrentY, CurrentX].describe();
            

            debugOut("CurrentY = " + CurrentY + ", CurrentX = " + CurrentX);
            
            glance(CurrentY -1, CurrentX , "North");
            glance(CurrentY +1, CurrentX, "South");
            glance(CurrentY , CurrentX -1, "West");
            glance(CurrentY , CurrentX +1, "East");
            Console.WriteLine(" ");
            
        }

        public void GenerateMap() //Load room array
        {
         
            
            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    Rooms[i, j] = new Room(" ", false);
                }
            }

         }

        public void LoadMap() //Load the map to game
        {
           string line;
           // int count = 0;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:RoomText.txt");

            line = file.ReadLine(); //Reads map size
            
            string[] mapSize = line.Split();
            int.TryParse(mapSize[0], out MaxY);
            int.TryParse(mapSize[1], out MaxX);
  
            Rooms = new Room[MaxY, MaxX];
            GenerateMap();
            for (int down=0; down < MaxY; down++)
            {
                line = file.ReadLine(); //Reads single line of map array
                char[] RoomWalls = line.ToCharArray();

                for (int right=0; right < MaxX; right++)
                {
                    if (RoomWalls[right]== '0')
                    {
                        Rooms[down,right].SetIsRoom(false);
                    }
                    else if (RoomWalls[right] == '1')
                    {
                        Rooms[down,right].SetIsRoom(true);
                    }
                    else
                    {
                        Console.WriteLine("Can not set room");
                    }
                }
            }

            debugOut("Map built:");
            ShowMap();

            debugOut("Map is shown. Reading descriptions.");

            string[] RoomDescribeCoordinates;
            int CoorY;
            int CoorX;

            string[] RoomInventory;
            string[] ItemType;

            while(line.Equals("end") == false)
            {
                line = file.ReadLine(); //Reads room coordinates
                if (line.Equals("end"))
                {
                    debugOut("end found");
                }
                else
                {
                    debugOut("end not found");
                }

                if (line.Equals("end") == false)
                {
                    RoomDescribeCoordinates = line.Split(); //Splits coordinates
                    int.TryParse(RoomDescribeCoordinates[0], out CoorY);
                    int.TryParse(RoomDescribeCoordinates[1], out CoorX);

                    debugOut("Read line: " + line);
                    debugOut("Y=" + RoomDescribeCoordinates[0] + ", X=" + RoomDescribeCoordinates[1]);

                    if (Rooms[CoorY, CoorX].GetIsRoom())
                    {
                        line = file.ReadLine(); //Reads room description

                        if (line.Equals("end") == false)
                        {
                            Rooms[CoorY, CoorX].SetDescription(line);
                            debugOut("Read line: " + line);

                            line = file.ReadLine(); //Reads room items
                          
                            if (line.Equals("end") == false)
                            {
                                RoomInventory = line.Split();
                               
                                Rooms[CoorY, CoorX].inventory.addArray(RoomInventory);

                                debugOut("Loaded Room inventory");

                                
                            }
                        }
                    }
                }
            }
            debugOut("MaxY = " + MaxY + ", MaxX = " + MaxX);
            file.Close();
            debugOut("file closed");
            CurrentRoom = Rooms[0, 0];
        }

        public void ShowMap()
        {
            bool explored;
            for (int i = 0; i < MaxY; i++)
            {
                for (int j = 0; j < MaxX; j++)
                {
                    explored = Rooms[i, j].WasExplored();

                    if (Rooms[i, j].GetIsRoom())
                    {
                        if (i == CurrentY && j == CurrentX)
                        {
                            Console.Write(" * ");
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                    }
                    else 
                    {
                        if (explored) { Console.Write("XXX");}
                        else { Console.Write("   ");}
                    }
                 }
                Console.Write("\n");
            }
        }
    
        private void glance(int y, int x, string direction) //Display ways that are clear and not
        {
            if (x < 0 || x >= MaxX || y < 0 || y >= MaxY)
            { 
                Console.WriteLine("There is a cliff to the " + direction); 
            }
            else if (Rooms[y, x].Look() == false)
            {
                Console.WriteLine("There is a wall to the " + direction);
            }
            else
            {
                Console.WriteLine("The way to the " + direction + " is clear");
            }
            
            debugOut(" y is " + y + "x is " + x);
        }

        private void debugOut(string message) //Debug message
        {
          //Console.WriteLine(message);
        }
    }  
}