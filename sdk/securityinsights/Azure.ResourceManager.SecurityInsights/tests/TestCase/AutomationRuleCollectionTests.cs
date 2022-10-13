// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class AutomationRuleCollectionTests : SecurityInsightsManagementTestBase
    {
        public AutomationRuleCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<AutomationRuleCollection> GetAutomationRuleCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAutomationRules(workspaceName);
        }

        [TestCase]
        public async Task AutomationRuleCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetAutomationRuleCollectionAsync();
            var name = Recording.GenerateAssetName("AutomationRules-");
            var name2 = Recording.GenerateAssetName("AutomationRules-");
            var name3 = Recording.GenerateAssetName("AutomationRules-");
            var input = ResourceDataHelpers.GetAutomationRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationRuleResource automation1 = lro.Value;
            Assert.AreEqual(name, automation1.Data.Name);
            //2.Get
            AutomationRuleResource automation2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertAutomationRuleData(automation1.Data, automation2.Data);
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
