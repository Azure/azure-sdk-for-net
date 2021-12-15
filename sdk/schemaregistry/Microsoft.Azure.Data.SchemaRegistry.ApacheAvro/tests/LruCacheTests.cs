// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    public class LruCacheTests
    {
        [Test]
        public void AddToCache()
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

            // 11 is moved to head of list
            cache.AddOrUpdate("11", 11);
            // 10 should be evicted
            Assert.IsFalse(cache.TryGet("10", out _));
            // 1 is moved to head of list
            cache.AddOrUpdate("1",1);
            // 12 is moved to head of list
            cache.AddOrUpdate("12", 12);
            // 1 is moved to head of list
            Assert.IsTrue(cache.TryGet("1", out _));
            // 13 is moved to head of list
            cache.AddOrUpdate("13", 13);
            // 14 should be evicted
            Assert.IsFalse(cache.TryGet("14", out _));
        }
    }
}