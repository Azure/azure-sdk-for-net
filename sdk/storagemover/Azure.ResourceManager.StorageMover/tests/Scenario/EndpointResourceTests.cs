// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class EndpointResourceTests : StorageMoverManagementTestBase
    {
        public EndpointResourceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetUpdateDeleteTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            string endpointName = Recording.GenerateAssetName("endpoint-");
            AzureStorageBlobContainerEndpointProperties containerEndpointProperties =
               new AzureStorageBlobContainerEndpointProperties(accountResourceId, ContainerName);
            StorageMoverEndpointData data = new StorageMoverEndpointData(containerEndpointProperties);
            StorageMoverEndpointResource endpoint1 = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, endpointName, data)).Value;
            StorageMoverEndpointResource endpoint2 = (await endpoint1.GetAsync()).Value;
            Assert.AreEqual(endpoint1.Data.Name, endpoint2.Data.Name);
            Assert.AreEqual(endpoint1.Data.Properties.Description, endpoint2.Data.Properties.Description);
            Assert.AreEqual(endpoint1.Id.Name, endpoint2.Id.Name);
            Assert.AreEqual(endpoint1.Id.Location, endpoint2.Id.Location);

            StorageMoverEndpointPatch patch = new();
            patch.Properties = new EndpointBaseUpdateProperties();
            patch.Properties.Description = "this is an updated endpoint";
            endpoint1 = (await endpoint1.UpdateAsync(patch)).Value;
            Assert.AreEqual("this is an updated endpoint", endpoint1.Data.Properties.Description);

            await endpoint1.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(await endpoints.ExistsAsync(endpointName));
        }
    }
}
