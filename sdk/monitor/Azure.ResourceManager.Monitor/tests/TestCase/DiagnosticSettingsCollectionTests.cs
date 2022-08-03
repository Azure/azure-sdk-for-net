// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Models;
using Azure.ResourceManager.Monitor.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class DiagnosticSettingsCollectionTests : MonitorTestBase
    {
        public DiagnosticSettingsCollectionTests(bool isAsync)
           : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<DiagnosticSettingCollection> GetDiagnosticSettingsCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDiagnosticSettings();
        }

        [RecordedTest]
        public async Task CreateOrUpdate_NewSignature()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var collection = Client.GetDiagnosticSettings(resourceGroup.Id);

            var name = Recording.GenerateAssetName("testDiagnosticSettings-");
            var input = new DiagnosticSettingData()
            {
                //ServiceBusRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testservicebusRG-9432/providers/Microsoft.ServiceBus/namespaces/testnamespacemgmt7892/AuthorizationRules/testfordiagnostic",
                //EventHubAuthorizationRuleId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/Default-EventHub-1375/providers/Microsoft.EventHub/namespaces/sdk-eventhub-Namespace-8280/eventhubs/testfordiagnosticsetting/authorizationRules/testfordiagonst",
                //EventHubName = "myeventhub",
                //WorkspaceId = "/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/default-eventhub-1375/providers/microsoft.operationalinsights/workspaces/myworkspace",
                LogAnalyticsDestinationType = "Dedicated",
                Metrics =
                {
                    new MetricSettings(true)
                {
                    Category = "WorkflowMetrics",
                    RetentionPolicy = new RetentionPolicy(false, 0),
                }
                },
                Logs =
                {
                    new LogSettings(true)
                {
                    Category = "Alert",
                    RetentionPolicy= new RetentionPolicy(false, 0)
                }
                }
            };
            try
            {
                var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
                var setting = lro.Value;
            }
            catch { }
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
