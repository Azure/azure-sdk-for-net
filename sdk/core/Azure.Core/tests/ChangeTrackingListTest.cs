// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ChangeTrackingListTest
    {
        [Test]
        public void UndefinedByDefault()
        {
            var list = new ChangeTrackingList<string>();
            Assert.True(list.IsUndefined);
        }

        [Test]
        public void ReadOperationsDontChange()
        {
            var list = new ChangeTrackingList<string>();
            _ = list.Count;
            _ = list.IsReadOnly;
            _ = list.Contains("a");
            _ = list.IndexOf("a");
            _ = list.Remove("a");

            foreach (var kvp in list)
            {
            }

            list.CopyTo(new string[5], 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[0]);

            Assert.True(list.IsUndefined);
        }

        [Test]
        public void CanAddElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.AreEqual("a", list[0]);
            Assert.False(list.IsUndefined);
        }

        [Test]
        public void CanInsertElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Insert(0, "a");

            Assert.AreEqual("a", list[0]);
            Assert.False(list.IsUndefined);
        }

        [Test]
        public void ContainsWorks()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.True(list.Contains("a"));
        }

        [Test]
        public void CanEnumerateItems()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.AreEqual(new[] { "a" },list.ToArray());
        }

        [Test]
        public void RemoveElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");
            list.Remove("a");

            Assert.AreEqual(0, list.Count);
            Assert.False(list.IsUndefined);
        }

        [Test]
        public void ClearResetsUndefined()
        {
            var list = new ChangeTrackingList<string>();
            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.False(list.IsUndefined);
        }
    }
}
