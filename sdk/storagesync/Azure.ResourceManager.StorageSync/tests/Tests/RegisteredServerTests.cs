// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.StorageSync.Models;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using System;

namespace Azure.ResourceManager.StorageSync.Tests
{
    public class RegisteredServerTests : StorageSyncManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private string _storageSyncServiceName;
        private Guid _guid;
        private StorageSyncServiceCreateOrUpdateContent _storageSyncServiceCreateOrUpdateContent;
        private StorageSyncRegisteredServerCreateOrUpdateContent _registeredServerCreateOrUpdateContent;
        private StorageSyncServiceResource _storageSyncServiceResource;

        public RegisteredServerTests(bool async) : base(async, ModeFromSourceCode )
        {
        }

        [SetUp]
        public async Task CreateStorageSyncResources()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _storageSyncServiceName = Recording.GenerateAssetName("sss-cepcreate");
            _guid = StorageSyncManagementTestUtilities.GenerateSeededGuid(int.Parse(Recording.Variables["RandomSeed"]));

            _registeredServerCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(_guid);
            _storageSyncServiceCreateOrUpdateContent = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

            // Create StorageSyncService
            _storageSyncServiceResource = (await _resourceGroup.GetStorageSyncServices().CreateOrUpdateAsync(WaitUntil.Completed, _storageSyncServiceName, _storageSyncServiceCreateOrUpdateContent)).Value;
            Assert.NotNull(_storageSyncServiceResource);
            StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(_storageSyncServiceResource, true);
        }

        [TearDown]
        public async Task RemoveStorageSyncResources()
        {
            var storageSyncServiseExists = (await _resourceGroup.GetStorageSyncServices().ExistsAsync(_storageSyncServiceName)).Value;
            if (storageSyncServiseExists)
            {
                var storageSyncService = (await _resourceGroup.GetStorageSyncServiceAsync(_storageSyncServiceName)).Value;
                if ((await storageSyncService.GetStorageSyncRegisteredServers().ExistsAsync(_guid)).Value)
                {
                    var registeredServerResource = (await storageSyncService.GetStorageSyncRegisteredServerAsync(_guid)).Value;
                    await registeredServerResource.DeleteAsync(WaitUntil.Completed);
                }
                await storageSyncService.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task RegisteredServerCreateTest()
        {
            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = (await _storageSyncServiceResource.GetStorageSyncRegisteredServers().CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);
        }

        [Test]
        [RecordedTest]
        public async Task RegisteredServerGetTest()
        {
            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = (await _storageSyncServiceResource.GetStorageSyncRegisteredServers().CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            // Get a RegisteredServer
            registeredServerResource = (await _storageSyncServiceResource.GetStorageSyncRegisteredServerAsync(_guid)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);
        }

        [Test]
        [RecordedTest]
        public async Task RegisteredServerTriggerRolloverTest()
        {
            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = (await _storageSyncServiceResource.GetStorageSyncRegisteredServers().CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            // Trigger Rollover
            BinaryData serverCertificate = StorageSyncManagementTestUtilities.GetSecondaryCertificate();
            TriggerRolloverContent triggerRolloverContent = new TriggerRolloverContent
            {
                ServerCertificate = serverCertificate
            };
            await registeredServerResource.TriggerRolloverAsync(WaitUntil.Completed, triggerRolloverContent);
        }

        [Test]
        [RecordedTest]
        public async Task RegisteredServerListTest()
        {
            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = (await _storageSyncServiceResource.GetStorageSyncRegisteredServers().CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            // Get a list of existing RegisteredServers
            List<StorageSyncRegisteredServerResource> registeredServerResources = await _storageSyncServiceResource.GetStorageSyncRegisteredServers().ToEnumerableAsync();
            Assert.NotNull(registeredServerResources);
            Assert.AreEqual(registeredServerResources.Count(), 1);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResources.First());
        }

        [Test]
        [RecordedTest]
        public async Task RegisteredServerDeleteTest()
        {
            // Get RegisteredServerCollection
            StorageSyncRegisteredServerCollection registeredServersCollection = _storageSyncServiceResource.GetStorageSyncRegisteredServers();
            Assert.NotNull(registeredServersCollection);

            // Delete RegisteredServer before it's created
            var deleteException = Assert.ThrowsAsync<RequestFailedException>(async () => (await _storageSyncServiceResource.GetStorageSyncRegisteredServerAsync(_guid)).Value?.Delete(WaitUntil.Completed));
            Assert.AreEqual(404, deleteException.Status);
            Assert.IsFalse((await registeredServersCollection.ExistsAsync(_guid)).Value);

            // Create RegisteredServer
            StorageSyncRegisteredServerResource registeredServerResource = (await registeredServersCollection.CreateOrUpdateAsync(WaitUntil.Completed, _guid, _registeredServerCreateOrUpdateContent)).Value;
            Assert.NotNull(registeredServerResource);
            StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource);

            // Delete RegisteredServer
            await registeredServerResource.DeleteAsync(WaitUntil.Completed);

            // Verify RegisteredServer has been deleted.
            Assert.IsFalse((await registeredServersCollection.ExistsAsync(_guid)).Value);
        }
    }
}
