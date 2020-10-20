using System;

namespace SpaceExplorer
{
    public class Item
    {
        public string ItemName;
        private bool IsEquipt;
        private bool Weapon;
        private bool Win;
        private int Uses;
        public Inventory inventory;

        public Item(string NameofItem) //Constructer
        {
            ItemName = NameofItem;
            Uses = 0;
            IsEquipt = false;
            Weapon = false;
            Win = false;
            
        }

        public bool GetisWeapon() //Check if it's a weapon
        {
            return Weapon;
        }

        public bool GetEquipt() //Check if it's equipt
        {
            return IsEquipt;
        }

        public string GetItemName() //Get the item name
        {
            return ItemName;
        }

        public void SetIsWeapon(bool Wep) //Set it as a weapon
        {
            Weapon = Wep;
        }

        public void SetEquipt(bool toEquipt) //Set it as equipt to player
        {
            IsEquipt = toEquipt;
        }

        public void SetIsWin(bool isWin) //Set as a win 
        {
            isWin = Win;
        }

        public bool GetWin()//See if it's a win item
        {
            return Win;
        }

        //*********************************************
        //Child Class
        //*********************************************

        public class NotPickup : Item
        {
            private bool Enemy = false;
            private bool Interact = false;

            public NotPickup(string thing) : base(thing) //Constructor
            {
            }

            public bool GetIsEnemy()//See if it's an Enemy
            {
                return Enemy;
            }

            public bool IsInteract()//See if it's interactable
            {
                return Interact;
            }

            public void SetIsEnemy(bool isEnemy)//Set as Enemy
            {
                Enemy = isEnemy;
            }

            public void SetInteract(bool isInteract)//Set as interactable
            {
                Interact = isInteract;
            }
        }
    } 
}