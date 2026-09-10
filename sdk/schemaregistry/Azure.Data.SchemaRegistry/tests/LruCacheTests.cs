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
            Assert.That(cache.Count, Is.EqualTo(10));
            Assert.That(cache.TotalLength, Is.EqualTo(20));

            for (int i = 0; i < 10; i++)
            {
                Assert.That(cache.TryGet(i.ToString(), out _), Is.False);
            }

            for (int i = 11; i < 20; i++)
            {
                Assert.That(cache.TryGet(i.ToString(), out var value), Is.True);
                Assert.That(value, Is.EqualTo(i));
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
            Assert.That(cache.TryGet("1", out _), Is.True);
            // 4 is added to head of list, which evicts 2, the least recently used item
            cache.AddOrUpdate("4", 4, 1);
            // 2 should be evicted
            Assert.That(cache.TryGet("2", out _), Is.False);
            // 5 is moved to head of list
            cache.AddOrUpdate("5", 4, 1);
            // 3 should be evicted
            Assert.That(cache.TryGet("3", out _), Is.False);
        }

        [Test]
        public void CanUpdateExistingValue()
        {
            var cache = new LruCache<string, int>(10);

            cache.AddOrUpdate("1", 1, 1);
            cache.TryGet("1", out int val);
            Assert.That(val, Is.EqualTo(1));
            Assert.That(cache.TotalLength, Is.EqualTo(1));
            cache.AddOrUpdate("1", 10, 2);
            Assert.That(cache.TotalLength, Is.EqualTo(2));
            cache.TryGet("1", out val);
            Assert.That(val, Is.EqualTo(10));
        }
    }
}
