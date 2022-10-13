// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System;
using Azure.ResourceManager.StorageSync.Models;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class ServerEndpointTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _storageSyncServiceName;
        private string _syncGroupName;
        private string _cloudEndpointName;
        private string _serverEndpointName;
        private StorageSyncServiceCreateOrUpdateContent _storageSyncServiceCreateOrUpdateContent;
        private StorageSyncGroupCreateOrUpdateContent _storageSyncGroupCreateOrUpdateContent;
        private CloudEndpointCreateOrUpdateContent _cloudEndpointCreateOrUpdateContent;

        public ServerEndpointTests(bool async) : base(async) //, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceName = Recording.GenerateAssetName("sss-cepcreate");
            _syncGroupName = Recording.GenerateAssetName("sg-cepcreate");
            _cloudEndpointName = Recording.GenerateAssetName("cepcreate");
            _serverEndpointName = Recording.GenerateAssetName("sepall");

            _storageSyncServiceCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
            _storageSyncGroupCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
            _cloudEndpointCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();
        }

        [Test]
        [RecordedTest]
        public async Task ServerEndpointAllOperationsTest()
        {
            // Create StorageSyncService
            StorageSyncServiceResource storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

            // Create StorageSyncGroup
            StorageSyncGroupResource syncGroupResource = (await storageSyncServiceResource.GetStorageSyncGroups().CreateOrUpdateAsync(WaitUntil.Completed, _syncGroupName, _storageSyncGroupCreateOrUpdateContent)).Value;
            Assert.NotNull(syncGroupResource);
            StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

            // Create CloudEndpoint
            CloudEndpointResource cloudEndpointResource = (await syncGroupResource.GetCloudEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _cloudEndpointName, _cloudEndpointCreateOrUpdateContent)).Value;
            Assert.NotNull(cloudEndpointResource);
            StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = await EnsureRegisteredServerResource(storageSyncServiceResource);

            //StorageSyncRegisteredServerResource registeredServerResource = (await storageSyncServiceResource.GetStorageSyncRegisteredServers().CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            StorageSyncServerEndpointCreateOrUpdateContent serverEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultServerEndpointParameters(registeredServerResource.Id);

            // Create ServerEndpoints
            StorageSyncServerEndpointResource serverEndpointResource = (await syncGroupResource.GetStorageSyncServerEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _serverEndpointName, serverEndpointParameters)).Value;
            Assert.NotNull(serverEndpointResource);
            StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

            // Get ServerEndpoint
            serverEndpointResource = (await syncGroupResource.GetStorageSyncServerEndpointAsync(_serverEndpointName)).Value;
            StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

            // List ServerEndpoints
            List<StorageSyncServerEndpointResource> serverEndpointResources = await syncGroupResource.GetStorageSyncServerEndpoints().ToEnumerableAsync();
            Assert.NotNull(serverEndpointResources);
            Assert.AreEqual(serverEndpointResources.Count(), 1);
            StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResources.First(), false);

            // Recall ServerEndpoint
            RecallActionContent recallActionParameters = StorageSyncManagementTestUtilities.GetDefaultRecallActionParameters();
            ArmOperation serverEndpointsRecallOperation = await serverEndpointResource.RecallActionAsync(WaitUntil.Completed, recallActionParameters);
            Assert.NotNull(serverEndpointsRecallOperation);
            Assert.IsNotEmpty(serverEndpointsRecallOperation.GetRawResponse().ClientRequestId); // Request Id
            // Assert.IsNotEmpty(serverEndpointsRecallOperation.Id); // Getting serverEndpointsRecallOperation id throws not implemented exception

            // Note: Currently updating a ServerEndpoint is blocked by design. API enforces that PUT on an existing resource has to be
            // an exact match for all properties between old and new, including properties that are considered mutable.
            // Update ServerEndpoint
            // StorageSyncServerEndpointCreateOrUpdateContent serverEndpointUpdateParameters = StorageSyncManagementTestUtilities.GetDefaultServerEndpointUpdateParameters(registeredServerResource.Id);
            // Assert.ThrowsAsync<Exception>(async () => await syncGroupResource.GetStorageSyncServerEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _serverEndpointName, serverEndpointUpdateParameters));

            // Delete ServerEndpoint
            await serverEndpointResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await syncGroupResource.GetStorageSyncServerEndpoints().ExistsAsync(_serverEndpointName)).Value);

            await cloudEndpointResource.DeleteAsync(WaitUntil.Completed);
            await registeredServerResource.DeleteAsync(WaitUntil.Completed);
            await syncGroupResource.DeleteAsync(WaitUntil.Completed);
            await storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<StorageSyncRegisteredServerResource> EnsureRegisteredServerResource(StorageSyncServiceResource storageSyncServiceResource)
        {
            //Guid serverGuid = Guid.NewGuid();
            //var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);
            //RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
            //Assert.NotNull(registeredServerResource);
            //StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

            string message = $"$ResourceGroupName = \"{_resourceGroup.Id.Name}\";" + Environment.NewLine +
                             $"$StorageSyncServiceName = \"{storageSyncServiceResource.Id.Name}\";" + Environment.NewLine +
                             $"$SyncGroupName = \"{_syncGroupName}\";";

            // For Record :  PLACE A BREAKPOINT HERE , REGISTER SERVER AND CONITNUE.
            List<StorageSyncRegisteredServerResource> registeredServerResources = await storageSyncServiceResource.GetStorageSyncRegisteredServers().ToEnumerableAsync();
            Assert.AreEqual(registeredServerResources.Count(), 1);

            return registeredServerResources.Single();
        }
    }
}
