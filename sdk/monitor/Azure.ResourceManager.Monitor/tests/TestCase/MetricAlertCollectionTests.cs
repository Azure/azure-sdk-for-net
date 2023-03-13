// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class MetricAlertCollectionTests : MonitorTestBase
    {
        public MetricAlertCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        #region storage account
        public async Task<string> GetStorageAccountId()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var storageCeollection = resourceGroup.GetStorageAccounts();
            string accountName = Recording.GenerateAssetName("metrictests");
            var storageContent = ResourceDataHelper.GetContent();
            var storageAccount = await storageCeollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, storageContent);
            string storageAccountId;
            if (Mode == RecordedTestMode.Playback)
            {
                storageAccountId = $"/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/{resourceGroup.Id.Name}/providers/Microsoft.Storage/storageAccounts/{accountName}";
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    storageAccountId = storageAccount.Value.Data.Id;
                }
            }
            return storageAccountId;
        }
        #endregion

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync().ConfigureAwait(false);
            var metricAlertCollection = resourceGroup.GetMetricAlerts();
            var actionGroupCollection = resourceGroup.GetActionGroups();

            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroupData = ResourceDataHelper.GetBasicActionGroupData("Global");
            var actionGroup = (await actionGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, actionGroupData).ConfigureAwait(false)).Value;

            string storageAccountId = await GetStorageAccountId();
            var metricAlertData = ResourceDataHelper.GetBasicMetricAlertData("global", actionGroup, storageAccountId);
            var metricAlertName = Recording.GenerateAssetName("testMetricAlert");
            var metricAlert = (await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, metricAlertName, metricAlertData)).Value;
            Assert.AreEqual(metricAlertName, metricAlert.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync().ConfigureAwait(false);
            var metricAlertCollection = resourceGroup.GetMetricAlerts();
            var actionGroupCollection = resourceGroup.GetActionGroups();

            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroupData = ResourceDataHelper.GetBasicActionGroupData("Global");
            var actionGroup = (await actionGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, actionGroupData).ConfigureAwait(false)).Value;

            string storageAccountId = await GetStorageAccountId();
            var metricAlertData = ResourceDataHelper.GetBasicMetricAlertData("global", actionGroup, storageAccountId);
            var metricAlertName = Recording.GenerateAssetName("testMetricAlert");
            var alert1 = (await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, metricAlertName, metricAlertData)).Value;
            MetricAlertResource alert2 = await metricAlertCollection.GetAsync(metricAlertName);
            ResourceDataHelper.AssertMetricAlert(alert1.Data, alert2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync().ConfigureAwait(false);
            var metricAlertCollection = resourceGroup.GetMetricAlerts();
            var actionGroupCollection = resourceGroup.GetActionGroups();

            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroupData = ResourceDataHelper.GetBasicActionGroupData("Global");
            var actionGroup = (await actionGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, actionGroupData).ConfigureAwait(false)).Value;

            string storageAccountId = await GetStorageAccountId();
            var metricAlertData = ResourceDataHelper.GetBasicMetricAlertData("global", actionGroup, storageAccountId);
            _ = await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testMetricAlert-"), metricAlertData);
            _ = await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testMetricAlert-"), metricAlertData);

            Assert.GreaterOrEqual(metricAlertCollection.GetAllAsync().ToEnumerableAsync().Result.Count, 2);
        }
    }
}
