// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.DoesNotThrow(() =>
            {
                var rule = new StaticRouterRule(new RouterValue(input));
                ClassicAssert.AreEqual(input, rule.Value.Value);
            });
        }
    }
}
