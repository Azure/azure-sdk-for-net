// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConcurrentExpiringSetTests.cs">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Microsoft.Azure.ServiceBus.UnitTests.Primitives
{
    using Microsoft.Azure.ServiceBus.Primitives;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class ConcurrentExpiringSetTests
    {
        [Fact]
        public void Contains_returns_true_for_valid_entry()
        {
            var set = new ConcurrentExpiringSet<string>();
            set.AddOrUpdate("testKey", DateTime.UtcNow + TimeSpan.FromSeconds(5));
            Assert.True(set.Contains("testKey"), "The set should return true for a valid entry.");
        }

        [Fact]
        public void Contains_returns_false_for_expired_entry()
        {
            var set = new ConcurrentExpiringSet<string>();
            set.AddOrUpdate("testKey", DateTime.UtcNow - TimeSpan.FromSeconds(5));
            Assert.False(set.Contains("testKey"), "The set should return false for an expired entry.");
        }

        [Fact]
        public void Contains_throws_after_close()
        {
            var set = new ConcurrentExpiringSet<string>();
            set.AddOrUpdate("testKey", DateTime.UtcNow + TimeSpan.FromSeconds(5));
            set.Close();

            Assert.Throws<ObjectDisposedException>(() => set.Contains("testKey"));
        }

        [Fact]
        public void AddOrUpdate_throws_after_close()
        {
            var set = new ConcurrentExpiringSet<string>();
            set.AddOrUpdate("testKey1", DateTime.UtcNow + TimeSpan.FromSeconds(5));
            set.Close();

            Assert.Throws<ObjectDisposedException>(() => set.AddOrUpdate("testKey2", DateTime.UtcNow - TimeSpan.FromSeconds(5)));
        }

        [Fact]
        public void Close_is_idempotent_and_thread_safe()
        {
            var set = new ConcurrentExpiringSet<string>();

            var ex = Record.Exception(() =>
            {
                set.Close();
                set.Close();
                Parallel.Invoke(() => set.Close(), () => set.Close());
            });

            Assert.Null(ex);
        }
    }
}