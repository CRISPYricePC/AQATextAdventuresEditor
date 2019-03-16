﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonGameMaker
{
    /// <summary>
    /// Sometimes reffered to as room, contains items and characters
    /// </summary>
    public class Place
    {
        public string Description;
        /// <summary>
        /// The ID stored in the rooms list
        /// </summary>
        public int id;
        /// <summary>
        /// Determines whether the user is able to go in the specified direction
        /// </summary>
        public int North, East, South, West, Up, Down;
        /// <summary>
        /// The ID of the door store in the specified direction. If there is no door, it is -1
        /// </summary>
        public int NorthDoor, SouthDoor, EastDoor, WestDoor, UpDoor, DownDoor;

        public Place()
        {
            NorthDoor = -1;
            SouthDoor = -1;
            EastDoor = -1;
            WestDoor = -1;
            UpDoor = -1;
            DownDoor = -1;

            Description = "An empty room";
        }

        public Place(int[] idList)
        {
            new Place();

            id = Saves.FindFreeID(1, 1999, idList);
        }

        public List<Item> GetItems(List<Item> allItems)
        {
            List<Item> placeItems = new List<Item>();
            foreach (Item item in allItems)
            {
                if (item.Location == id)
                {
                    placeItems.Add(item);
                }
            }
            return placeItems;
        }

        public int AddItem(int itemid, string name, string description, List<string> status, List<string> commands, List<string[]> results)
        {
            Item newItem = new Item();

            if (itemid == -1)
            {
                int[] idList = Saves.Items.GetIDs();
                newItem.ID = Saves.FindFreeID(2001, 9999, idList);
            }
            else newItem.ID = itemid;
            newItem.Name = name;
            newItem.Description = description;
            newItem.Location = id;
            newItem.OverWriteStatus(status);
            newItem.OverWriteCommands(commands);
            newItem.OverWriteResults(results);

            Saves.Items.Add(newItem);

            return newItem.ID;
        }

        public void AddDoor(string name, string description, LocationDirection direction, Place placeToJoinWith)
        {
            int[] idList = Saves.Items.GetIDs();
            int thisSideId = Saves.FindFreeID(2000, 9999, idList);
            int otherSideId = thisSideId + 10000;
        }
    }
}
