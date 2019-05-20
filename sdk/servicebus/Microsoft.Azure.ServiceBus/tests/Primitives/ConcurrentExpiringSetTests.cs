// ----------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="ConcurrentExpiringSetTests.cs">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------

namespace Microsoft.Azure.ServiceBus.UnitTests.Primitives
{
    using Microsoft.Azure.ServiceBus.Primitives;
    using System;
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
    }
}