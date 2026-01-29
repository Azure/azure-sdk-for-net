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
            Assert.That(list.IsUndefined, Is.True);
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

            Assert.That(list.IsUndefined, Is.True);
        }

        [Test]
        public void CanAddElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.That(list[0], Is.EqualTo("a"));
            Assert.That(list.IsUndefined, Is.False);
        }

        [Test]
        public void CanInsertElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Insert(0, "a");

            Assert.That(list[0], Is.EqualTo("a"));
            Assert.That(list.IsUndefined, Is.False);
        }

        [Test]
        public void ContainsWorks()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.That(list.Contains("a"), Is.True);
        }

        [Test]
        public void CanEnumerateItems()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");

            Assert.That(list.ToArray(), Is.EqualTo(new[] { "a" }));
        }

        [Test]
        public void RemoveElement()
        {
            var list = new ChangeTrackingList<string>();
            list.Add("a");
            list.Remove("a");

            Assert.That(list.Count, Is.EqualTo(0));
            Assert.That(list.IsUndefined, Is.False);
        }

        [Test]
        public void ClearResetsUndefined()
        {
            var list = new ChangeTrackingList<string>();
            list.Clear();

            Assert.That(list.Count, Is.EqualTo(0));
            Assert.That(list.IsUndefined, Is.False);
        }
    }
}
