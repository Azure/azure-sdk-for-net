#pragma warning disable SA1636
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
#pragma warning restore SA1636

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Primitives
{
    public class ValueStopwatchTests
    {
        [Test]
        public void IsActiveIsFalseForDefaultValueStopwatch()
        {
            Assert.False(default(ValueStopwatch).IsActive);
        }

        [Test]
        public void IsActiveIsTrueWhenValueStopwatchStartedWithStartNew()
        {
            Assert.True(ValueStopwatch.StartNew().IsActive);
        }

        [Test]
        public void GetElapsedTimeThrowsIfValueStopwatchIsDefaultValue()
        {
            var stopwatch = default(ValueStopwatch);
            Assert.Throws<InvalidOperationException>(() => stopwatch.GetElapsedTime());
        }

        [Test]
        public async Task GetElapsedTimeReturnsTimeElapsedSinceStart()
        {
            var stopwatch = ValueStopwatch.StartNew();
            await Task.Delay(200);
            Assert.True(stopwatch.GetElapsedTime().TotalMilliseconds > 0);
        }
    }
}
