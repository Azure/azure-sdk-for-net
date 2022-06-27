// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class PhpWorkloadsCRUDTests : WorkloadsManagementTestBase
    {
        private const string TestResourceNamePrefix = "sdk-tests-dotNet-php-";
        public PhpWorkloadsCRUDTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [RecordedTest]
        [Test]
        public async Task TestPhpWorkloadsCRUDOperations()
        {
            Resources.SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            Resources.ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                TestResourceNamePrefix,
                Core.AzureLocation.EastUS);

            var resourceName = Recording.GenerateAssetName(TestResourceNamePrefix);
            string mrgName = Recording.GenerateAssetName(TestResourceNamePrefix + "mrg-");

            var resourceJson = File.ReadAllText(@"TestData\PhpWorkloads\PutPhpWorkload.json");
            PhpWorkloadResourceData resourceData =
                JsonConvert.DeserializeObject<PhpWorkloadResourceData>(resourceJson);

            resourceData.ManagedResourceGroupConfiguration = new Models.ManagedRGConfiguration()
            {
                Name = mrgName
            };

            resourceData.DatabaseProfile.ServerName = Recording.GenerateAssetName(TestResourceNamePrefix);
            resourceData.CacheProfile.Name = Recording.GenerateAssetName(TestResourceNamePrefix);

            // Create

            ArmOperation<PhpWorkloadResource> createdResource =
                await rg.GetPhpWorkloadResources().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    resourceName,
                    resourceData);

            Assert.IsTrue(createdResource.Value.Data.ProvisioningState ==
                Models.PhpWorkloadProvisioningState.Succeeded);

            Assert.AreEqual(resourceName, createdResource.Value.Data.Name);

            // Read
            Response<PhpWorkloadResource> getResource = await rg.GetPhpWorkloadResourceAsync(resourceName);
            Assert.IsNotNull(getResource);
            Assert.AreEqual(resourceName, getResource.Value.Data.Name);

            // Update
            var tagsToUpdate = new Dictionary<string, string>()
            {
                ["Test"] = "passed"
            };
            var updatePayloadJ = JObject.FromObject(getResource.Value.Data);
            updatePayloadJ.Merge(tagsToUpdate);
            PhpWorkloadResourceData updatePayload = updatePayloadJ.ToObject<PhpWorkloadResourceData>();
            ArmOperation<PhpWorkloadResource> updatedResource =
                await rg.GetPhpWorkloadResources().CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    resourceName,
                    updatePayload);

            Assert.IsTrue(createdResource.Value.Data.ProvisioningState ==
                Models.PhpWorkloadProvisioningState.Succeeded);

            Assert.AreEqual(resourceName, createdResource.Value.Data.Name);
            Assert.AreEqual(updatePayload.Tags.Count, updatedResource.Value.Data.Tags.Count);
            Assert.IsFalse(updatedResource.Value.Data.Tags.Except(updatePayload.Tags).Any());

            // Delete
            getResource = await rg.GetPhpWorkloadResourceAsync(resourceName);
            Assert.IsNotNull(getResource?.Value?.Data?.Name);
            Assert.AreEqual(resourceName, getResource?.Value.Data.Name);
            await getResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<PhpWorkloadResource> getDeletedResoure =
                    await rg.GetPhpWorkloadResourceAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"PHP Workload {resourceName} does not exist.");
            }
        }
    }
}
