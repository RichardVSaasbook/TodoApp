using System;
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
        /// <param name="item">The Item to remove.</param>
        /// <returns>True if the removal was successful.</returns>
        public bool RemoveItem(Item item)
        {
            db.Items.Remove(item);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Update an item.
        /// </summary>
        /// <param name="item">The Item to update.</param>
        /// <returns>True if the update was successful.</returns>
        public bool UpdateItem(Item item)
        {
            item.UpdatedDate = DateTime.Now;
            var entry = db.Entry(item);
            entry.State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Marks an item complete.
        /// </summary>
        /// <param name="item">The Item to mark as complete.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool MarkItemComplete(Item item)
        {
            item.IsComplete = true;
            return UpdateItem(item);
        }

        /// <summary>
        /// Marks an item incomplete.
        /// </summary>
        /// <param name="item">The Item to mark as incomplete.</param>
        /// <returns>True if the operation was successful.</returns>
        public bool MarkItemIncomplete(Item item)
        {
            item.IsComplete = false;
            return UpdateItem(item);
        }

        /// <summary>
        /// List all of the todo Items.
        /// </summary>
        /// <returns>The List of Items.</returns>
        public List<Item> ListItems()
        {
            return db.Items.ToList();
        }

        /// <summary>
        /// List all of the completed todo Items.
        /// </summary>
        /// <returns>The List of completed Items.</returns>
        public List<Item> ListCompletedItems()
        {
            return db.Items.Where(i => i.IsComplete).ToList();
        }

        /// <summary>
        /// List all of the incompleted todo Items.
        /// </summary>
        /// <returns>The List of incompleted Items.</returns>
        public List<Item> ListIncompletedItems()
        {
            return db.Items.Where(i => !i.IsComplete).ToList();
        }
    }
}
