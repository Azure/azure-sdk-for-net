// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobAccessPointConfigurationTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string NamePrefix = "teststoragemgmt";

        public BlobAccessPointConfigurationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetListUpdateDeleteAndTestConnections()
        {
            AzureLocation location = new AzureLocation("centraluseuap");
            string resourceGroupName = Recording.GenerateAssetName("teststorageRG-");
            _resourceGroup = (await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(location))).Value;
            string accountName = Recording.GenerateAssetName(NamePrefix);
            StorageAccountCreateOrUpdateContent accountParameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                location)
            {
                DataCollaborationPolicyProperties = new StorageDataCollaborationPolicyProperties
                {
                    AllowBlobAccessPoints = true
                }
            };
            StorageAccountResource account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(
                WaitUntil.Completed,
                accountName,
                accountParameters)).Value;

            BlobAccessPointQumuloSourceProperties source = CreateSource();
            ArmOperation<BlobAccessPointConnectionTestResult> proposedConnectionOperation = await account.TestBlobAccessPointProposedConnectionAsync(
                WaitUntil.Started,
                new BlobAccessPointProposedConnectionTestContent(source));
            Assert.IsNotEmpty(proposedConnectionOperation.Id);

            string configurationName = Recording.GenerateAssetName("bap");
            BlobAccessPointConfigurationData configurationData = new BlobAccessPointConfigurationData(
                location,
                new BlobAccessPointConfigurationProperties(source)
                {
                    State = BlobAccessPointConfigurationState.Active,
                    Description = "Test Blob Access Point configuration"
                });
            configurationData.Tags.Add("environment", "test");

            BlobAccessPointConfigurationCollection configurations = account.GetBlobAccessPointConfigurations();
            BlobAccessPointConfigurationResource configuration = (await configurations.CreateOrUpdateAsync(
                WaitUntil.Completed,
                configurationName,
                configurationData)).Value;

            Assert.AreEqual(configurationName, configuration.Data.Name);
            Assert.AreEqual(location, configuration.Data.Location);
            Assert.AreEqual(BlobAccessPointConfigurationState.Active, configuration.Data.Properties.State);
            Assert.AreEqual("Test Blob Access Point configuration", configuration.Data.Properties.Description);
            Assert.IsNotEmpty(configuration.Data.Properties.UniqueId);
            Assert.AreEqual(StorageResourceProvisioningState.Succeeded, configuration.Data.Properties.ProvisioningState);
            Assert.AreEqual("test", configuration.Data.Tags["environment"]);
            AssertSource(configuration.Data.Properties.Source);

            BlobAccessPointConfigurationResource retrieved = (await configuration.GetAsync()).Value;
            Assert.AreEqual(configuration.Id, retrieved.Id);
            Assert.AreEqual(configuration.Id, (await configurations.GetAsync(configurationName)).Value.Id);
            Assert.AreEqual(configuration.Id, (await account.GetBlobAccessPointConfigurationAsync(configurationName)).Value.Id);
            Assert.AreEqual(configuration.Id, (await Client.GetBlobAccessPointConfigurationResource(configuration.Id).GetAsync()).Value.Id);
            Assert.IsTrue((await configurations.ExistsAsync(configurationName)).Value);
            Assert.IsTrue((await configurations.GetIfExistsAsync(configurationName)).HasValue);

            List<BlobAccessPointConfigurationResource> allConfigurations = await configurations.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(allConfigurations.Any(item => item.Data.Name == configurationName));

            BlobAccessPointConnectionTestResult existingConnectionResult = (await configuration.TestExistingConnectionAsync(
                WaitUntil.Completed,
                new BlobAccessPointConnectionTestContent(configuration.Data.Properties.UniqueId))).Value;
            Assert.IsNotEmpty(existingConnectionResult.MethodName);

            string containerName = Recording.GenerateAssetName("container");
            BlobContainerData containerData = new BlobContainerData
            {
                BlobAccessPointConfiguration = new BlobAccessPointConfigurationConnection
                {
                    BlobAccessPointConfigurationName = configurationName,
                    BlobAccessPointConfigurationUniqueId = configuration.Data.Properties.UniqueId
                }
            };
            BlobContainerResource container = (await account.GetBlobService().GetBlobContainers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                containerName,
                containerData)).Value;
            Assert.AreEqual(configurationName, container.Data.BlobAccessPointConfiguration.BlobAccessPointConfigurationName);
            Assert.AreEqual(configuration.Data.Properties.UniqueId, container.Data.BlobAccessPointConfiguration.BlobAccessPointConfigurationUniqueId);
            await container.DeleteAsync(WaitUntil.Completed);

            BlobAccessPointConfigurationPatch patch = new BlobAccessPointConfigurationPatch
            {
                Properties = new BlobAccessPointConfigurationPropertiesPatch
                {
                    State = BlobAccessPointConfigurationState.Inactive,
                    Description = "Updated Blob Access Point configuration"
                }
            };
            patch.Tags.Add("environment", "production");
            configuration = (await configuration.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.AreEqual(BlobAccessPointConfigurationState.Inactive, configuration.Data.Properties.State);
            Assert.AreEqual("Updated Blob Access Point configuration", configuration.Data.Properties.Description);
            Assert.AreEqual("production", configuration.Data.Tags["environment"]);

            await configuration.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse((await configurations.ExistsAsync(configurationName)).Value);
            Assert.IsFalse((await configurations.GetIfExistsAsync(configurationName)).HasValue);
        }

        private BlobAccessPointQumuloSourceProperties CreateSource()
        {
            BlobAccessPointEndpointConnectionProperties connection = new BlobAccessPointEndpointConnectionProperties(new Uri("https://52.176.39.155:9000/gamibucket1"))
            {
                TlsVerification = BlobAccessPointTlsVerification.Skip
            };
            BlobAccessPointAccessKeyAuthProperties auth = new BlobAccessPointAccessKeyAuthProperties(
                "00000000000001f44038",
                TestEnvironment.BlobAccessPointSecretAccessKey)
            {
                SigningRegion = "us-east-1"
            };
            return new BlobAccessPointQumuloSourceProperties(connection, auth);
        }

        private static void AssertSource(BlobAccessPointSourceProperties source)
        {
            Assert.IsInstanceOf<BlobAccessPointQumuloSourceProperties>(source);
            BlobAccessPointQumuloSourceProperties qumuloSource = (BlobAccessPointQumuloSourceProperties)source;
            Assert.IsInstanceOf<BlobAccessPointEndpointConnectionProperties>(qumuloSource.Connection);
            BlobAccessPointEndpointConnectionProperties connection = (BlobAccessPointEndpointConnectionProperties)qumuloSource.Connection;
            Assert.IsInstanceOf<BlobAccessPointAccessKeyAuthProperties>(qumuloSource.Auth);
            BlobAccessPointAccessKeyAuthProperties auth = (BlobAccessPointAccessKeyAuthProperties)qumuloSource.Auth;
            Assert.AreEqual("00000000000001f44038", auth.AccessKeyId);
            Assert.AreEqual("us-east-1", auth.SigningRegion);
        }
    }
}
