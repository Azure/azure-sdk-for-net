// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class LruCacheTests
    {
        [Test]
        public void CacheCapacityRespected()
        {
            var cache = new LruCache<string, int>(10);
            for (int i = 0; i < 20; i++)
            {
                cache.AddOrUpdate(i.ToString(), i);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsFalse(cache.TryGet(i.ToString(), out _));
            }
        }
        [Test]
        public void CacheOrderingRespected()
        {
            var cache = new LruCache<string, int>(3);

            cache.AddOrUpdate("1", 1);
            cache.AddOrUpdate("2", 2);
            cache.AddOrUpdate("3", 3);
            // 1 is moved to head of list
            Assert.IsTrue(cache.TryGet("1", out _));
            cache.AddOrUpdate("4", 4);
            // 2 should be evicted
            Assert.IsFalse(cache.TryGet("2", out _));
            cache.AddOrUpdate("5", 4);
            // 3 should be evicted
            Assert.IsFalse(cache.TryGet("3", out _));
        }

        [Test]
        public void CanUpdateExistingValue()
        {
            var cache = new LruCache<string, int>(10);

            cache.AddOrUpdate("1", 1);
            cache.TryGet("1", out int val);
            Assert.AreEqual(1, val);
            cache.AddOrUpdate("1", 10);
            cache.TryGet("1", out val);
            Assert.AreEqual(10, val);
        }
    }
}