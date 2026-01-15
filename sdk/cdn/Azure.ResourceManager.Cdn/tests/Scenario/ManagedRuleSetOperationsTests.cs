// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Core;

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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            await foreach (var tempManagedRuleSetDefinition in subscription.GetManagedRuleSetsAsync())
            {
                count++;
                Assert.That(new ResourceType("Microsoft.Cdn/CdnWebApplicationFirewallManagedRuleSets"), Is.EqualTo(tempManagedRuleSetDefinition.ResourceType));
            }
            Assert.That(count, Is.EqualTo(1));
        }
    }
}
