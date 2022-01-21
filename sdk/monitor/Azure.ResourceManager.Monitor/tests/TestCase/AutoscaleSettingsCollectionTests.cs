// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using Azure.ResourceManager.Resources;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class AutoscaleSettingsCollectionTests : MonitorTestBase
    {
        public AutoscaleSettingsCollectionTests(bool isAsync)
           : base(isAsync)
        {
        }
        private async Task<AutoscaleSettingCollection> GetAutoscaleSettingsCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetAutoscaleSettings();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetAutoscaleSettingsCollectionAsync();
            var name = Recording.GenerateAssetName("testAutoscaleSettings");
            var input = ResourceDataHelper.GetBasicAutoscaleSettingData("eastus2");
            var lro = await container.CreateOrUpdateAsync(true, name, input);
            var autoscaleSetting = lro.Value;
            Assert.AreEqual(name, autoscaleSetting.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetAutoscaleSettingsCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testAutoscaleSettings-");
            var input = ResourceDataHelper.GetBasicAutoscaleSettingData("eastus");
            var lro = await collection.CreateOrUpdateAsync(true, actionGroupName, input);
            AutoscaleSetting autoscaleSetting1 = lro.Value;
            AutoscaleSetting autoscaleSetting2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertAutoscaleSetting(autoscaleSetting1.Data, autoscaleSetting2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetAutoscaleSettingsCollectionAsync();
            var input = ResourceDataHelper.GetBasicAutoscaleSettingData("eastus");
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testAutoscaleSettings-"), input);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testAutoscaleSettings-"), input);
            int count = 0;
            await foreach (var autoscaleSetting in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
