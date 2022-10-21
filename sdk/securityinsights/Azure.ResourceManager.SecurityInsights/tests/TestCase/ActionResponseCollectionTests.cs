// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class ActionResponseCollectionTests : SecurityInsightsManagementTestBase
    {
        public ActionResponseCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ActionResponseCollection> GetActionResponseCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = resourceGroup.GetSecurityInsightsAlertRules(workspaceName);
            var alertRulesName = Recording.GenerateAssetName("testAlertRule-");
            var input = ResourceDataHelpers.GetSecurityInsightsAlertRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRulesName, input);
            var alertRules = lro.Value;
            return alertRules.GetActionResponses();
        }

        [TestCase]
        [RecordedTest]
        public async Task ActionResponseApiTests()
        {
            //1.CreateorUpdate
            var collection = await GetActionResponseCollectionAsync();
            var name = Recording.GenerateAssetName("TestActionResponse-");
            var name2 = Recording.GenerateAssetName("TestActionResponse-");
            var name3 = Recording.GenerateAssetName("TestActionResponse-");
            var input = ResourceDataHelpers.GetActionResponseData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            ActionResponseResource response1 = lro.Value;
            Assert.AreEqual(name, response1.Data.Name);
            //2.Get
            ActionResponseResource response2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertActionResponseData(response1.Data, response2.Data);
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
