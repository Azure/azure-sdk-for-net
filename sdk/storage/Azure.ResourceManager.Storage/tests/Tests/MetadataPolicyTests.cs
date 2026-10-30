// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    [PlaybackOnly("Recordings were captured against the Metadata Policy canary endpoint.")]
    [ClientTestFixture]
    public class MetadataPolicyTests : ManagementRecordedTestBase<MetadataPolicyTestEnvironment>
    {
        private ArmClient _accountClient;
        private ArmClient _metadataPolicyClient;
        private StorageAccountCollection _accounts;
        private StorageAccountResource _accountToDelete;
        private string _accountName;

        public MetadataPolicyTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateClients()
        {
            ArmClientOptions accountOptions = new ArmClientOptions();
            accountOptions.SetApiVersion(StorageAccountResource.ResourceType, "2026-09-01");
            _accountClient = GetArmClient(accountOptions);
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroup);
            _accounts = _accountClient.GetResourceGroupResource(resourceGroupId).GetStorageAccounts();
            _accountName = IsAsync ? "testsdktr2" : "testsdktr1";
            _accountToDelete = null;

            ArmClientOptions metadataPolicyOptions = InstrumentClientOptions(new ArmClientOptions
            {
                Environment = new ArmEnvironment(
                    new Uri(TestEnvironment.MetadataPolicyEndpoint),
                    ArmEnvironment.AzurePublicCloud.Audience)
            });
            metadataPolicyOptions.SetApiVersion(MetadataPolicyResource.ResourceType, "2026-12-01");
            _metadataPolicyClient = InstrumentClientExtension(new ArmClient(
                TestEnvironment.Credential,
                TestEnvironment.SubscriptionId,
                metadataPolicyOptions));
        }

        [TearDown]
        public async Task DeleteTestStorageAccount()
        {
            if (_accountToDelete != null)
            {
                try
                {
                    await _accountToDelete.DeleteAsync(WaitUntil.Completed);
                }
                catch (RequestFailedException exception) when (exception.Status == 404)
                {
                    TestContext.WriteLine("The disposable test storage account is already absent.");
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetUpdateDelete()
        {
            Assert.IsFalse(
                (await _accounts.ExistsAsync(_accountName)).Value,
                "The disposable test account already exists; refusing to modify it.");

            _accountToDelete = _accountClient.GetStorageAccountResource(StorageAccountResource.CreateResourceIdentifier(
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroup,
                _accountName));
            StorageAccountResource account = (await _accounts.CreateOrUpdateAsync(
                WaitUntil.Completed,
                _accountName,
                new StorageAccountCreateOrUpdateContent(
                    new StorageSku(StorageSkuName.StandardLrs),
                    StorageKind.StorageV2,
                    new AzureLocation(TestEnvironment.Location)))).Value;

            MetadataPolicyResource policy = _metadataPolicyClient.GetStorageAccountResource(account.Id).GetMetadataPolicy();
            ResourceIdentifier expectedId = MetadataPolicyResource.CreateResourceIdentifier(
                TestEnvironment.SubscriptionId,
                TestEnvironment.ResourceGroup,
                _accountName);
            MetadataPolicyData enabledPolicy = new MetadataPolicyData(new MetadataPolicyProperties(
                new MetadataSnapshotPolicy(MetadataSnapshotPolicyStatus.Enabled)));

            MetadataPolicyResource created = (await policy.CreateOrUpdateAsync(WaitUntil.Completed, enabledPolicy)).Value;
            AssertPolicy(created, expectedId, MetadataSnapshotPolicyStatus.Enabled);

            MetadataPolicyResource retrieved = (await policy.GetAsync()).Value;
            AssertPolicy(retrieved, expectedId, MetadataSnapshotPolicyStatus.Enabled);
            Assert.AreEqual(created.Data.Properties.SnapshotPolicy.Name, retrieved.Data.Properties.SnapshotPolicy.Name);
            Assert.AreEqual(
                created.Data.Properties.SnapshotPolicy.DefinitionRefreshFrequency,
                retrieved.Data.Properties.SnapshotPolicy.DefinitionRefreshFrequency);

            MetadataPolicyResource retrievedById = (await _metadataPolicyClient.GetMetadataPolicyResource(expectedId).GetAsync()).Value;
            AssertPolicy(retrievedById, expectedId, MetadataSnapshotPolicyStatus.Enabled);

            MetadataPolicyData disabledPolicy = new MetadataPolicyData(new MetadataPolicyProperties(
                new MetadataSnapshotPolicy(MetadataSnapshotPolicyStatus.Disabled)));
            MetadataPolicyResource updated = (await policy.CreateOrUpdateAsync(WaitUntil.Completed, disabledPolicy)).Value;
            AssertPolicy(updated, expectedId, MetadataSnapshotPolicyStatus.Disabled);
            AssertPolicy((await policy.GetAsync()).Value, expectedId, MetadataSnapshotPolicyStatus.Disabled);

            await policy.DeleteAsync(WaitUntil.Completed);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await policy.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        private static void AssertPolicy(
            MetadataPolicyResource policy,
            ResourceIdentifier expectedId,
            MetadataSnapshotPolicyStatus expectedStatus)
        {
            Assert.IsTrue(policy.HasData);
            Assert.AreEqual(expectedId, policy.Id);
            Assert.AreEqual("default", policy.Data.Name);
            Assert.AreEqual(MetadataPolicyResource.ResourceType, policy.Data.ResourceType);
            Assert.IsNotNull(policy.Data.Properties);
            Assert.IsNotNull(policy.Data.Properties.LastModifiedOn);
            Assert.IsNotNull(policy.Data.Properties.SnapshotPolicy);
            Assert.AreEqual(expectedStatus, policy.Data.Properties.SnapshotPolicy.Status);
            Assert.IsNotEmpty(policy.Data.Properties.SnapshotPolicy.Name);
            Assert.IsNotNull(policy.Data.Properties.SnapshotPolicy.DefinitionRefreshFrequency);
        }
    }
}
