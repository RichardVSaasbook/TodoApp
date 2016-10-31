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
        ItemData data;

        /// <summary>
        /// Create a new ItemDataTests.
        /// </summary>
        public ItemDataTests()
        {
            data = new ItemData();
        }

        /// <summary>
        /// Ensure that adding an item works.
        /// </summary>
        [Fact]
        public void Test_AddItem()
        {
            bool actual = data.AddItem(new Item { Description = "Make dinner.", CreationDate = DateTime.Now, UpdatedDate = DateTime.Now });

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that removing an item works.
        /// </summary>
        [Fact]
        public void Test_RemoveItem()
        {
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
            Item item = data.GetLastItem();
            item.Description = "Mow the lawn.";

            bool actual = data.UpdateItem(item);

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that we can mark an item as complete.
        /// </summary>
        [Fact]
        public void Test_MarkItemComplete()
        {
            Item item = data.GetLastItem();

            bool actual = data.MarkItemComplete(item);

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that we can mark an item as incomplete.
        /// </summary>
        [Fact]
        public void Test_MarkItemIncomplete()
        {
            Item item = data.GetLastItem();

            bool actual = data.MarkItemIncomplete(item);

            Assert.True(actual);
        }

        /// <summary>
        /// Ensure that we can list all of the Items.
        /// </summary>
        [Fact]
        public void Test_ListItems()
        {
            List<Item> actual = data.ListItems();

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        /// <summary>
        /// Ensure that we can list all of the completed Items.
        /// </summary>
        [Fact]
        public void Test_ListCompleteItems()
        {
            data.MarkItemComplete(data.GetLastItem());
            List<Item> actual = data.ListCompletedItems();

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }

        /// <summary>
        /// Ensure that we can list all of the incompleted Items.
        /// </summary>
        [Fact]
        public void Test_ListIncompleteItems()
        {
            data.MarkItemIncomplete(data.GetLastItem());
            List<Item> actual = data.ListIncompletedItems();

            Assert.NotNull(actual);
            Assert.NotEmpty(actual);
        }
    }
}
