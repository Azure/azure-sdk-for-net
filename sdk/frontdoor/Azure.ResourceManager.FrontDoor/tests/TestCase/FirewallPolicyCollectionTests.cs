// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.FrontDoor.Models;
using Azure.ResourceManager.FrontDoor.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.FrontDoor.Tests.TestCase
{
    public class FirewallPolicyCollectionTests : FrontDoorManagementTestBase
    {
        public FirewallPolicyCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FrontDoorWebApplicationFirewallPolicyCollection> GetFirewallCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetFrontDoorWebApplicationFirewallPolicies();
        }

        [TestCase]
        [RecordedTest]
        public async Task WafLogScurbbing()
        {
            var collection = await GetFirewallCollectionAsync();
            var name = Recording.GenerateAssetName("TestFrontDoor");
            var input = ResourceDataHelpers.GetPolicyData(DefaultLocation);
            input.PolicySettings.EnabledState = PolicyEnabledState.Enabled;
            input.PolicySettings.ScrubbingRules.Add(new WebApplicationFirewallScrubbingRules(ScrubbingRuleEntryMatchVariable.RequestUri, ScrubbingRuleEntryMatchOperator.EqualsAny));
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
        }

        [TestCase]
        [RecordedTest]
        public async Task FirewallApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetFirewallCollectionAsync();
            var name = Recording.GenerateAssetName("TestFrontDoor");
            var name2 = Recording.GenerateAssetName("TestFrontDoor");
            var name3 = Recording.GenerateAssetName("TestFrontDoor");
            var input = ResourceDataHelpers.GetPolicyData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            FrontDoorWebApplicationFirewallPolicyResource firewall1 = lro.Value;
            Assert.AreEqual(name, firewall1.Data.Name);
            //2.Get
            FrontDoorWebApplicationFirewallPolicyResource firewall2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertPolicy(firewall1.Data, firewall2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
