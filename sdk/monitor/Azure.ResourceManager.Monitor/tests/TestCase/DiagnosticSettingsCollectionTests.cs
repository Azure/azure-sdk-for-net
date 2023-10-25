// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class DiagnosticSettingsCollectionTests : MonitorTestBase
    {
        public DiagnosticSettingsCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DiagnosticSettingCollection> GetDiagnosticSettingsCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return Client.GetDiagnosticSettings(DefaultSubscription.Id);
        }

        [Ignore("Need to Update cleanup")]
        [TestCase]
        public async Task CreateOrUpdate()
        {
            var container = await GetDiagnosticSettingsCollectionAsync();
            var name = Recording.GenerateAssetName("testDiagnosticSettings-");
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            var lro = await container.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            var setting = lro.Value;
            Assert.AreEqual(name, setting.Data.Name);
        }

        [Ignore("Need to Update cleanup")]
        [TestCase]
        public async Task Get()
        {
            var collection = await GetDiagnosticSettingsCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testDiagnosticSettings-");
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, actionGroupName, input);
            DiagnosticSettingResource setting1 = lro.Value;
            DiagnosticSettingResource setting2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertDiagnosticSetting(setting1.Data, setting2.Data);
        }

        [Ignore("Need to Update cleanup")]
        [TestCase]
        public async Task GetAll()
        {
            var collection = await GetDiagnosticSettingsCollectionAsync();
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDiagnosticSettings-"), input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testDiagnosticSettings-"), input);
            int count = 0;
            await foreach (var setting in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
