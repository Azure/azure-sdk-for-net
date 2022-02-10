// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.ResourceManager.Internal;

namespace Azure.ResourceManager.Tests.Unit
{
    [Parallelizable]
    public class ExponentialPollingStrategyTests
    {
        [TestCase]
        public void PollingIntervalIsExponentialWithMax32Seconds()
        {
            var strategy = new ExponentialPollingStrategy();
            for (int i = 0, j = 1; i < 6; i++, j *=2)
            {
                Assert.AreEqual(j, strategy.PollingInterval.TotalSeconds);
            }

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(32, strategy.PollingInterval.TotalSeconds);
            }
        }
    }
}
