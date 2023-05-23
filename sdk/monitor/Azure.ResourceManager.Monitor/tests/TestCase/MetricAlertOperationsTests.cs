// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using Azure.ResourceManager.Storage;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class MetricAlertOperationsTests : MonitorTestBase
    {
        public MetricAlertOperationsTests(bool isAsync)
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
            string storageAccountId;
            if (Mode == RecordedTestMode.Playback)
            {
                storageAccountId = StorageAccountResource.CreateResourceIdentifier(resourceGroup.Id.SubscriptionId, resourceGroup.Id.Name, accountName).ToString();
                //storageAccountId = $"/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/{resourceGroup.Id.Name}/providers/Microsoft.Storage/storageAccounts/{accountName}";
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    var storageAccount = await storageCeollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, storageContent);
                    storageAccountId = storageAccount.Value.Data.Id;
                }
            }
            return storageAccountId;
        }
        #endregion
        private async Task<MetricAlertResource> CreateMetricAlertAsync(string alertName)
        {
            var resourceGroup = await CreateResourceGroupAsync().ConfigureAwait(false);
            var metricAlertCollection = resourceGroup.GetMetricAlerts();
            var actionGroupCollection = resourceGroup.GetActionGroups();

            var actionGroupName = Recording.GenerateAssetName("testActionGroup-");
            var actionGroupData = ResourceDataHelper.GetBasicActionGroupData("Global");
            var actionGroup = (await actionGroupCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, actionGroupData).ConfigureAwait(false)).Value;
            string storageAccountId = await GetStorageAccountId();
            var metricAlertData = ResourceDataHelper.GetBasicMetricAlertData("global", actionGroup, storageAccountId);
            var metricAlert = await metricAlertCollection.CreateOrUpdateAsync(WaitUntil.Completed, alertName, metricAlertData);
            return metricAlert.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            await alert.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var alertName = Recording.GenerateAssetName("testMetricAlert-");
            var alert = await CreateMetricAlertAsync(alertName);
            MetricAlertResource actionGroup2 = await alert.GetAsync();

            ResourceDataHelper.AssertMetricAlert(alert.Data, actionGroup2.Data);
        }
    }
}
