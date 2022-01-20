// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Tests;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests.TestsCase
{
    public class DiagnosticSettingsCollectionTests : MonitorTestBase
    {
        public DiagnosticSettingsCollectionTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DiagnosticSettingsCollection> GetDiagnosticSettingsCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDiagnosticSettings();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetDiagnosticSettingsCollectionAsync();
            var name = Recording.GenerateAssetName("testDiagnosticSettings-");
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            var lro = await container.CreateOrUpdateAsync(true, name, input);
            var setting = lro.Value;
            Assert.AreEqual(name, setting.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var collection = await GetDiagnosticSettingsCollectionAsync();
            var actionGroupName = Recording.GenerateAssetName("testDiagnosticSettings-");
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            var lro = await collection.CreateOrUpdateAsync(true, actionGroupName, input);
            DiagnosticSettings setting1 = lro.Value;
            DiagnosticSettings setting2 = await collection.GetAsync(actionGroupName);
            ResourceDataHelper.AssertDiagnosticSetting(setting1.Data, setting2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var collection = await GetDiagnosticSettingsCollectionAsync();
            var input = ResourceDataHelper.GetBasicDiagnosticSettingsData();
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testDiagnosticSettings-"), input);
            _ = await collection.CreateOrUpdateAsync(true, Recording.GenerateAssetName("testDiagnosticSettings-"), input);
            int count = 0;
            await foreach (var setting in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
