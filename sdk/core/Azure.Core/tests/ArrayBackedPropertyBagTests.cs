// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ArrayBackedPropertyBagTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(1000)]
        public void AddAndGetItems(int count)
        {
            ArrayBackedPropertyBag<int, int> target = new();
            for (int i = 0; i < count; i++)
            {
                target.Add(i, i);
                Assert.True(target.TryGetValue(i, out int value));
                Assert.AreEqual(i, value);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DuplicateKeysFetchLastAddedItem(int count)
        {
            ArrayBackedPropertyBag<int, int> target = new();
            for (int i = 1; i <= count; i++)
            {
                target.Add(i, i);
                Assert.True(target.TryGetValue(i, out int value));
                Assert.AreEqual(i, value);
            }

            // add a duplicate key and set the value to the negative of its original value
            int lastKey = count;
            target.Add(lastKey, lastKey * -1);
            Assert.True(target.TryGetValue(lastKey, out int newValue));
            Assert.AreEqual(-lastKey, newValue);
        }

        [Test]
        public void AddThrowsWithNullKey()
        {
            ArrayBackedPropertyBag<string, int> target = new();
            Assert.Throws<ArgumentNullException>(() => target.Add(null, 1));
        }

        [Test]
        public void TryGetValueThrowsWithNullKey()
        {
            ArrayBackedPropertyBag<string, int> target = new();
            Assert.Throws<ArgumentNullException>(() => target.TryGetValue(null, out _));
        }

        [Test]
        public void TryGetValueReturnsFalseWhenKeyNotExists()
        {
            ArrayBackedPropertyBag<string, int> target = new();
            target.Add("exists", 1);

            Assert.False(target.TryGetValue("does not exist", out _));
        }
    }
}
