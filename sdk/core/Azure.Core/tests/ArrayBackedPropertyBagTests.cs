// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ArrayBackedPropertyBagTests
    {
        [Test]
        [TestCase((ulong)1)]
        [TestCase((ulong)2)]
        [TestCase((ulong)3)]
        [TestCase((ulong)5)]
        [TestCase((ulong)20)]
        [TestCase((ulong)1000)]
        public void AddAndGetItems(ulong count)
        {
            ArrayBackedPropertyBag target = new();
            for (ulong i = 0; i < count; i++)
            {
                target.Set(i, i);
                Assert.True(target.TryGetValue(i, out object value));
                Assert.AreEqual(i, (ulong)value);
            }
        }

        [Test]
        public void NoDupeTest()
        {
            int readLoops = 1000;
            using HttpMessage message = new HttpMessage(new MockRequest(), ResponseClassifier.Shared);

            ArrayBackedPropertyBag target = new();
            for (ulong i = 0; i < 5; i++)
            {
                target.Set(i, i);
                Assert.True(target.TryGetValue(i, out object value));
                Assert.AreEqual(i, (ulong)value);
            }
            for (int i = 0; i < readLoops; i++)
            {
                target.Set(3, i);
            }
            for (int i = 0; i < readLoops; i++)
            {
                target.TryGetValue(4, out var val4);
            }
        }

        [Test]
        [TestCase((ulong)1)]
        [TestCase((ulong)2)]
        [TestCase((ulong)3)]
        public void DuplicateKeysFetchLastAddedItem(ulong count)
        {
            ArrayBackedPropertyBag target = new();
            for (ulong i = 1; i <= count; i++)
            {
                target.Set(i, i);
                Assert.True(target.TryGetValue(i, out object value));
                Assert.AreEqual(i, (ulong)value);
            }

            // add a duplicate key and set the value to the negative of its original value
            ulong lastKey = count;
            target.Set(lastKey, lastKey * 10L);
            Assert.True(target.TryGetValue(lastKey, out object newValue));
            Assert.AreEqual(lastKey * 10, (ulong)newValue);
        }

        [Test]
        public void TryGetValueReturnsFalseWhenKeyNotExists()
        {
            ArrayBackedPropertyBag target = new();
            target.Set(1, 1);

            Assert.False(target.TryGetValue(2, out _));
        }
    }
}
