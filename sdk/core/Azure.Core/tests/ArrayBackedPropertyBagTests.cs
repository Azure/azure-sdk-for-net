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
            ArrayBackedPropertyBagPool<int, int> target = new();
            for (int i = 0; i < count; i++)
            {
                target.Add(i, i);
                Assert.True(target.TryGetValue(i, out int value));
                Assert.AreEqual(i, value);
            }
        }

        private struct T1
        {
            public int Value { get; set; }
        }

        private struct T2
        {
            public int Value { get; set; }
        }

        private struct T3
        {
            public int Value { get; set; }
        }

        private struct T4
        {
            public int Value { get; set; }
        }

        private struct T5
        {
            public int Value { get; set; }
        }

        [Test]
        public void NoDupeTest()
        {
            int readLoops = 1000;
            using HttpMessage message = new HttpMessage(new MockRequest(), new ResponseClassifier());
            var t3 = new T3() { Value = 1234 };
            message.SetProperty(typeof(T1), new T1() { Value = 1234 });
            message.SetProperty(typeof(T2), new T2() { Value = 1234 });
            message.SetProperty(typeof(T3), new T3() { Value = 1234 });
            message.SetProperty(typeof(T4), new T4() { Value = 1234 });
            message.SetProperty(typeof(T5), new T5() { Value = 1234 });
            for (int i = 0; i < readLoops; i++)
            {
                t3.Value = i;
                message.SetProperty(typeof(T3), i);
            }
            for (int i = 0; i < readLoops; i++)
            {
                message.TryGetProperty(typeof(T4), out var val4);
            }
            // ArrayBackedPropertyBagPool<int, int> target = new();
            // for (int i = 0; i < 5; i++)
            // {
            //     target.Add(i, i);
            //     Assert.True(target.TryGetValue(i, out int value));
            //     Assert.AreEqual(i, value);
            // }
            // for (int i = 0; i < readLoops; i++)
            // {
            //     target.Add(3, i);
            // }
            // for (int i = 0; i < readLoops; i++)
            // {
            //     target.TryGetValue(4, out var val4);
            // }
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DuplicateKeysFetchLastAddedItem(int count)
        {
            ArrayBackedPropertyBagPool<int, int> target = new();
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
            ArrayBackedPropertyBagPool<string, int> target = new();
            Assert.Throws<ArgumentNullException>(() => target.Add(null, 1));
        }

        [Test]
        public void TryGetValueThrowsWithNullKey()
        {
            ArrayBackedPropertyBagPool<string, int> target = new();
            Assert.Throws<ArgumentNullException>(() => target.TryGetValue(null, out _));
        }

        [Test]
        public void TryGetValueReturnsFalseWhenKeyNotExists()
        {
            ArrayBackedPropertyBagPool<string, int> target = new();
            target.Add("exists", 1);

            Assert.False(target.TryGetValue("does not exist", out _));
        }
    }
}
