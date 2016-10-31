﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.DataAccess
{
    /// <summary>
    /// Data Access for the Item table.
    /// </summary>
    public class ItemData
    {
        private TodoAppDbEntities db;

        /// <summary>
        /// Create a new Item data access object.
        /// </summary>
        public ItemData()
        {
            db = new TodoAppDbEntities();
        }

        /// <summary>
        /// Gets the last created item.
        /// </summary>
        /// <returns>The Item if the Id is valid, null otherwise.</returns>
        public Item GetLastItem()
        {
            return db.Items.OrderByDescending(i => i.CreationDate).First();
        }

        /// <summary>
        /// Add an Item to the Todo database.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>True if the addition was successful.</returns>
        public bool AddItem(Item item)
        {
            db.Items.Add(item);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool RemoveItem(Item item)
        {
            db.Items.Remove(item);
            return db.SaveChanges() > 0;
        }
    }
}
