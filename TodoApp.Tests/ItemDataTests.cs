using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DataAccess;
using Xunit;

namespace TodoApp.Tests
{
    /// <summary>
    /// Test class for ItemData data access object.
    /// </summary>
    public class ItemDataTests
    {
        /// <summary>
        /// Ensure that adding an item works.
        /// </summary>
        [Fact]
        public void Test_AddItem()
        {
            ItemData data = new ItemData();

            bool actual = data.AddItem(new Item { Description = "Make dinner.", CreationDate = DateTime.Now, UpdatedDate = DateTime.Now });

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that removing an item works.
        /// </summary>
        [Fact]
        public void Test_RemoveItem()
        {
            ItemData data = new ItemData();
            Item item = data.GetLastItem();

            bool actual = data.RemoveItem(item);

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that updating an item works.
        /// </summary>
        [Fact]
        public void Test_UpdateItem()
        {
            ItemData data = new ItemData();
            Item item = data.GetLastItem();
            item.Description = "Mow the lawn.";

            bool actual = data.UpdateItem(item);

            Assert.True(actual);
        }
    }
}
