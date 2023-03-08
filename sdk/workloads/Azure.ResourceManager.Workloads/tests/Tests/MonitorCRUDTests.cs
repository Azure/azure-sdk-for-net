// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Workloads.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class MonitorCRUDTests : WorkloadsManagementTestBase
    {
        public MonitorCRUDTests(bool isAsync) : base(isAsync)
        { }

        private string _rgName;

        [TestCase]
        [RecordedTest]
        public async Task TestHAMonitorOperations()
        {
            _rgName ??= Recording.GenerateAssetName("netSdkTest-");
            const string filePath = "./payload/ams/createHaMonitorPayload.json";

            string resourceName = Recording.GenerateAssetName("haMonitor-");
            SapMonitorResource resource = await CreateMonitors(filePath, resourceName);
            await TestProvider(
                resource.Id, "promethueusHa", "./payload/ams/createPrometheusHaPayload.json");
            //Delete SAP monitor
            await resource.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestNonHAMonitorOperations()
        {
            _rgName ??= Recording.GenerateAssetName("netSdkTest-");
            const string filePath = "./payload/ams/createNonHaMonitorPayload.json";

            string resourceName = Recording.GenerateAssetName("nonHaMonitor-");
            SapMonitorResource resource = await CreateMonitors(filePath, resourceName);
            await TestProvider(
                resource.Id, "db2", "./payload/ams/createDb2Payload.json");
            await TestProvider(
                resource.Id, "hana", "./payload/ams/createHanaPayload.json");
            await TestProvider(
                resource.Id, "promethueusos", "./payload/ams/createOsPayload.json");
            await TestProvider(
                resource.Id, "netweaver", "./payload/ams/createNetWeaverPayload.json");
            await TestProvider(
                resource.Id, "sql", "./payload/ams/createSqlPayload.json");

            //Delete SAP monitor
            await resource.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<SapMonitorResource> CreateMonitors(string filePath, string resourceName)
        {
            Console.WriteLine("Starting Monitor Resource tests for " + resourceName);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                _rgName,
                AzureLocation.EastUS2);

            SapMonitorResource result = null;
            // Create SAP Monitor
            JsonDocument jsonElement = GetJsonElement(filePath);
            var sapMonitorData = SapMonitorData.DeserializeSapMonitorData(jsonElement.RootElement);
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = Recording.GenerateAssetName(resourceName + "mrg-")
            };

            Console.WriteLine("Creating resource with Payload " + await getObjectAsString(sapMonitorData));
            try
            {
                ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors()
                    .CreateOrUpdateAsync(
                        WaitUntil.Completed,
                        resourceName,
                        sapMonitorData);

                Assert.AreEqual(resourceName, resource.Value.Data.Name);
                Console.WriteLine("Created resource with Payload " + await getObjectAsString(resource.Value.Data));

                // Get SAP monitor
                Response<SapMonitorResource> monitor = await rg.GetSapMonitorAsync(resourceName);
                Assert.AreEqual(resourceName, monitor.Value.Data.Name);
                Console.WriteLine("Fetched resource with Payload " + await getObjectAsString(monitor.Value.Data));

                //Patch SAP Monitor
                var sapMonitorPatch = new SapMonitorPatch();
                sapMonitorPatch.Tags.Add("DateTime", "dotNetSdkTest");
                Console.WriteLine("Patching resource with Payload " + await getObjectAsString(sapMonitorPatch));
                monitor = await monitor.Value.UpdateAsync(sapMonitorPatch);
                Assert.AreEqual(resourceName, monitor.Value.Data.Name);
                Console.WriteLine("Patched resource with Payload " + await getObjectAsString(monitor.Value.Data));
                result = monitor.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating resource with Payload " + ex);
            }

            //List SAP Monitor
            Console.WriteLine("Listing all resources in RG " + rg.Id);

            AsyncPageable<SapMonitorResource> sapMonitorResources = rg.GetSapMonitors().GetAllAsync();
            IAsyncEnumerator<SapMonitorResource> asyncEnumerator = sapMonitorResources.GetAsyncEnumerator();
            while (await asyncEnumerator.MoveNextAsync())
            {
                Console.WriteLine("Fetched Monitor: " + await getObjectAsString(asyncEnumerator.Current.Data));
            }
            Console.WriteLine("Listed all resources");
            return result;
        }

        private async Task TestProvider(ResourceIdentifier monitorId, string providerType, string filePath)
        {
            Console.WriteLine("Starting Provider Resource tests for providerType" + providerType);

            // Create provider
            SapMonitorResource sapMonitorResource = Client.GetSapMonitorResource(monitorId);
            JsonDocument jsonElement = GetJsonElement(filePath);
            var sapProviderInstanceData =
                SapProviderInstanceData.DeserializeSapProviderInstanceData(jsonElement.RootElement);
            string providerName = Recording.GenerateAssetName(providerType);
            if (providerName.Length > 20)
                providerName = providerName.Substring(0, 20);

            SapProviderInstanceCollection providerInstanceCollection = sapMonitorResource
                .GetSapProviderInstances();
            Console.WriteLine("Creating resource with Payload " + await getObjectAsString(sapProviderInstanceData));
            try
            {
                ArmOperation<SapProviderInstanceResource> providerResource = await providerInstanceCollection
                    .CreateOrUpdateAsync(
                        WaitUntil.Completed,
                        providerName,
                        sapProviderInstanceData);
                Assert.AreEqual(providerName, providerResource.Value.Data.Name);
                Console.WriteLine("Created resource with Payload " + await getObjectAsString(providerResource.Value.Data));

                // Create provider
                Response<SapProviderInstanceResource> response =
                    await providerInstanceCollection.GetAsync(providerName);
                Assert.AreEqual(providerName, response.Value.Data.Name);
                Console.WriteLine("Fetched resource with Payload " + await getObjectAsString(response.Value.Data));

                // Delete SAP Hana provider
                Console.WriteLine("Deleting Provider Resource " + response.Value.Id);
                ArmOperation<ResourceManager.Models.OperationStatusResult> deleteResult =
                    await response.Value.DeleteAsync(WaitUntil.Completed);
                Console.WriteLine("Delete Provider Result status " + deleteResult.Value.Status);
                Console.WriteLine("Done Provider Resource Tests for providerType" + providerType);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating resource with Payload " + ex);
            }
        }
    }
}
