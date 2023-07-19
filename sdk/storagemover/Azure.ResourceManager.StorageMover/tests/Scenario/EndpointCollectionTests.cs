// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class EndpointCollectionTests : StorageMoverManagementTestBase
    {
        public EndpointCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
            {
            }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetTest()
        {
            ResourceGroupResource resourceGroup = await GetResourceGroupAsync(ResourceGroupName);
            StorageMoverCollection storageMovers = resourceGroup.GetStorageMovers();
            StorageMoverEndpointCollection endpoints = (await storageMovers.GetAsync(StorageMoverName)).Value.GetStorageMoverEndpoints();

            string cEndpointName = Recording.GenerateAssetName("conendpoint-");
            string nfsEndpointName = Recording.GenerateAssetName("nfsendpoint-");
            string accountResourceId = DefaultSubscription.Id.ToString() + "/resourceGroups/" + ResourceGroupName +
                "/providers/Microsoft.Storage/storageAccounts/" + StorageAccountName;

            AzureStorageBlobContainerEndpointProperties containerEndpointProperties =
                new AzureStorageBlobContainerEndpointProperties(accountResourceId, ContainerName);
            StorageMoverEndpointData data = new StorageMoverEndpointData(containerEndpointProperties);
            StorageMoverEndpointResource cEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, cEndpointName, data)).Value;
            Assert.AreEqual(cEndpoint.Data.Name, cEndpointName);
            Assert.AreEqual("AzureStorageBlobContainer", cEndpoint.Data.Properties.EndpointType.ToString());

            NfsMountEndpointProperties nfsMountEndpointProperties = new NfsMountEndpointProperties("10.0.0.1", "/");
            data = new StorageMoverEndpointData(nfsMountEndpointProperties);
            StorageMoverEndpointResource nfsEndpoint = (await endpoints.CreateOrUpdateAsync(WaitUntil.Completed, nfsEndpointName, data)).Value;
            Assert.AreEqual(nfsEndpoint.Data.Name, nfsEndpointName);
            Assert.AreEqual("NfsMount", nfsEndpoint.Data.Properties.EndpointType.ToString());

            cEndpoint = (await endpoints.GetAsync(cEndpointName)).Value;
            Assert.AreEqual(cEndpoint.Data.Name, cEndpointName);
            Assert.AreEqual("AzureStorageBlobContainer", cEndpoint.Data.Properties.EndpointType.ToString());

            int counter = 0;
            await foreach (StorageMoverEndpointResource _ in endpoints.GetAllAsync())
            {
                counter++;
            }
            Assert.Greater(counter, 1);

            Assert.IsTrue(await endpoints.ExistsAsync(cEndpointName));
            Assert.IsFalse(await endpoints.ExistsAsync(cEndpointName + "111"));
        }
    }
}
