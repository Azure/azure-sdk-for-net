// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class ActivityLogAlertCollectionTests : MonitorTestBase
    {
        public ActivityLogAlertCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }

        private async Task<ActivityLogAlertCollection> GetActivityLogAlertCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetActivityLogAlerts();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetActivityLogAlertCollectionAsync();
            var name = Recording.GenerateAssetName("testActivityLogAlert");
            var subID = DefaultSubscription.Id;
            var input = ResourceDataHelper.GetBasicActivityLogAlertData("global", subID);
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var alert = lro.Value;
            Assert.AreEqual(name, alert.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetActivityLogAlertCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testActivityLogAlert");
            var subID = DefaultSubscription.Id;
            var input = ResourceDataHelper.GetBasicActivityLogAlertData("global", subID);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, input);
            ActivityLogAlertResource alert1 = lro.Value;
            ActivityLogAlertResource alert2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertActivityLogAlert(alert1.Data, alert2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetActivityLogAlertCollectionAsync();
            var subID = DefaultSubscription.Id;
            var input = ResourceDataHelper.GetBasicActivityLogAlertData("global", subID);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testActivityLogAlert"), input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testActivityLogAlert"), input);
            int count = 0;
            await foreach (var activityLogAlert in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
