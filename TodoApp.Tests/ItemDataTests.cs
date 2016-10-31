﻿using System;
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
    }
}