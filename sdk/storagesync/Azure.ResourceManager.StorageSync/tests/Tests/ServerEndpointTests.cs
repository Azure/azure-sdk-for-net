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
        private StorageSyncServiceResource _storageSyncServiceResource;
        private StorageSyncGroupResource _storageSyncGroupResource;
        private CloudEndpointResource _cloudEndpointResource;

        private string _serverEndpointName;

        public ServerEndpointTests(bool async) : base(async, ModeFromSourceCode )
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceResource = await CreateSyncServiceAsync(_resourceGroup);
            _storageSyncGroupResource = await CreateSyncGroupAsync(_storageSyncServiceResource);
            _cloudEndpointResource = await CreateCloudEndpointAsync(_storageSyncGroupResource);

            _serverEndpointName = Recording.GenerateAssetName(DefaultServerEndpointRecordingName);
        }

        [Test]
        [RecordedTest]
        public async Task ServerEndpointAllOperationsTest()
        {
            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = await EnsureRegisteredServerResource(_storageSyncServiceResource);
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            StorageSyncServerEndpointCreateOrUpdateContent serverEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultServerEndpointParameters(registeredServerResource.Id);

            // Create ServerEndpoints
            StorageSyncServerEndpointResource serverEndpointResource = (await _storageSyncGroupResource.GetStorageSyncServerEndpoints().CreateOrUpdateAsync(WaitUntil.Completed, _serverEndpointName, serverEndpointParameters)).Value;
            Assert.NotNull(serverEndpointResource);
            StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

            // Get ServerEndpoint
            serverEndpointResource = (await _storageSyncGroupResource.GetStorageSyncServerEndpointAsync(_serverEndpointName)).Value;
            StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

            // List ServerEndpoints
            List<StorageSyncServerEndpointResource> serverEndpointResources = await _storageSyncGroupResource.GetStorageSyncServerEndpoints().ToEnumerableAsync();
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
            Assert.IsFalse((await _storageSyncGroupResource.GetStorageSyncServerEndpoints().ExistsAsync(_serverEndpointName)).Value);

            await _cloudEndpointResource.DeleteAsync(WaitUntil.Completed);
            await registeredServerResource.DeleteAsync(WaitUntil.Completed);
            await _storageSyncGroupResource.DeleteAsync(WaitUntil.Completed);
            await _storageSyncServiceResource.DeleteAsync(WaitUntil.Completed);
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
                             $"$SyncGroupName = \"{_storageSyncGroupResource.Id.Name}\";";

            // For Record :  PLACE A BREAKPOINT HERE , REGISTER SERVER AND CONTINUE.
            List<StorageSyncRegisteredServerResource> registeredServerResources = await storageSyncServiceResource.GetStorageSyncRegisteredServers().ToEnumerableAsync();
            Assert.AreEqual(registeredServerResources.Count(), 1);

            return registeredServerResources.Single();
        }
    }
}
