// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class StaticRuleTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(1f)]
        [TestCase(1d)]
        [TestCase("1d")]
        [TestCase(true)]
        [Parallelizable(ParallelScope.All)]
        public void RouterRuleAcceptsValueInConstructor(object input)
        {
            Assert.DoesNotThrow(() =>
            {
                var rule = new StaticRouterRule(new RouterValue(input));
                Assert.AreEqual(input, rule.Value.Value);
            });
        }
    }
}
