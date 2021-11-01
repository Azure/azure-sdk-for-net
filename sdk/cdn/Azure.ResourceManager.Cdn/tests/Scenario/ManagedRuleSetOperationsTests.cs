// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class ManagedRuleSetOperationsTests : CdnManagementTestBase
    {
        public ManagedRuleSetOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            int count = 0;
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            await foreach (var tempManagedRuleSetDefinition in subscription.GetManagedRuleSetsAsync())
            {
                count++;
                Assert.AreEqual(tempManagedRuleSetDefinition.Type, new ResourceType("Microsoft.Cdn/CdnWebApplicationFirewallManagedRuleSets"));
            }
            Assert.AreEqual(count, 1);
        }
    }
}
