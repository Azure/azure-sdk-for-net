// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Data.SchemaRegistry;

namespace Azure.Data.SchemaRegistry.Tests
{
    public class LruCacheTests
    {
        [Test]
        public void CacheCapacityRespected()
        {
            var cache = new LruCache<string, int>(10);
            for (int i = 0; i < 20; i++)
            {
                cache.AddOrUpdate(i.ToString(), i, i.ToString().Length);
            }
            Assert.AreEqual(10, cache.Count);
            Assert.AreEqual(20, cache.TotalLength);

            for (int i = 0; i < 10; i++)
            {
                Assert.IsFalse(cache.TryGet(i.ToString(), out _));
            }

            for (int i = 11; i < 20; i++)
            {
                Assert.IsTrue(cache.TryGet(i.ToString(), out var value));
                Assert.AreEqual(i, value);
            }
        }

        [Test]
        public void CacheEvictsLeastRecentlyAccessedItemFirst()
        {
            var cache = new LruCache<string, int>(3);

            cache.AddOrUpdate("1", 1, 1);
            cache.AddOrUpdate("2", 2, 1);
            cache.AddOrUpdate("3", 3, 1);
            // 1 is moved to head of list
            Assert.IsTrue(cache.TryGet("1", out _));
            // 4 is added to head of list, which evicts 2, the least recently used item
            cache.AddOrUpdate("4", 4, 1);
            // 2 should be evicted
            Assert.IsFalse(cache.TryGet("2", out _));
            // 5 is moved to head of list
            cache.AddOrUpdate("5", 4, 1);
            // 3 should be evicted
            Assert.IsFalse(cache.TryGet("3", out _));
        }

        [Test]
        public void CanUpdateExistingValue()
        {
            var cache = new LruCache<string, int>(10);

            cache.AddOrUpdate("1", 1, 1);
            cache.TryGet("1", out int val);
            Assert.AreEqual(1, val);
            Assert.AreEqual(1, cache.TotalLength);
            cache.AddOrUpdate("1", 10, 2);
            Assert.AreEqual(2, cache.TotalLength);
            cache.TryGet("1", out val);
            Assert.AreEqual(10, val);
        }
    }
}
