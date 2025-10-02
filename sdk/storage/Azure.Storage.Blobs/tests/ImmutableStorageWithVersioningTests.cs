// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ImmutableStorageWithVersioningTests : BlobTestBase
    {
        public ImmutableStorageWithVersioningTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        // The container is shared by all tests in this class
        private string _containerName;
        private BlobContainerResource _container;
        //private StorageManagementClient _storageManagementClient;

        private BlobContainerClient _containerClient;

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                _containerName = Guid.NewGuid().ToString();
                TenantConfiguration configuration = TestConfigurations.DefaultTargetOAuthTenant;

                try
                {
                    ArmClient armClient = new ArmClient(TestEnvironment.Credential);
                    SubscriptionResource subscription = armClient.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{configuration.SubscriptionId}"));
                    ResourceGroupResource resourceGroup = await subscription.GetResourceGroupAsync(configuration.ResourceGroupName);
                    StorageAccountResource storageAccount = await resourceGroup.GetStorageAccountAsync(configuration.AccountName);
                    BlobServiceResource blobService = storageAccount.GetBlobService();
                    BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
                    BlobContainerData blobContainerData = new BlobContainerData();
                    blobContainerData.ImmutableStorageWithVersioning = new ImmutableStorageWithVersioning
                    {
                        IsEnabled = true
                    };
                    ArmOperation<BlobContainerResource> blobContainerCreateOperation = await blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, _containerName, blobContainerData);
                    _container = blobContainerCreateOperation.Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return;
            }
        }

        [SetUp]
        public void SetUp()
        {
            _containerName = Recording.GetVariable(nameof(_containerName), _containerName);
            _containerClient = BlobsClientBuilder.GetServiceClient_OAuthAccount_SharedKey().GetBlobContainerClient(_containerName);
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                TenantConfiguration configuration = TestConfigurations.DefaultTargetOAuthTenant;
                BlobContainerClient containerClient = new BlobServiceClient(
                    new Uri(Tenants.TestConfigOAuth.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(Tenants.TestConfigOAuth.AccountName,
                    Tenants.TestConfigOAuth.AccountKey))
                    .GetBlobContainerClient(_containerName);

                GetBlobsOptions options = new GetBlobsOptions
                {
                    Traits = BlobTraits.ImmutabilityPolicy | BlobTraits.LegalHold,
                };

                await foreach (BlobItem blobItem in containerClient.GetBlobsAsync(options))
                {
                    BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);

                    if (blobItem.Properties.HasLegalHold)
                    {
                        await blobClient.SetLegalHoldAsync(false);
                    }

                    if (blobItem.Properties.ImmutabilityPolicy.ExpiresOn != null)
                    {
                        await blobClient.DeleteImmutabilityPolicyAsync();
                    }

                    await blobClient.DeleteIfExistsAsync();
                }

                await _container.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Test SetImmutabilityPolicyAsync API and validate response.
            // Act
            Response<BlobImmutabilityPolicy> response = await blob.SetImmutabilityPolicyAsync(immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Validate that we are correctly deserializing Get Properties response.
            // Act
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);

            // Validate we are correctly deserializing Blob Items.
            // Act
            List<BlobItem> blobItems = new List<BlobItem>();

            GetBlobsOptions options = new GetBlobsOptions
            {
                Traits = BlobTraits.ImmutabilityPolicy,
                Prefix = blob.Name
            };

            await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync(options))
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobItems.Count);
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, blobItems[0].Properties.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, blobItems[0].Properties.ImmutabilityPolicy.PolicyMode);

            // Validate we are correctly deserialzing Get Blob response.
            // Act
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, downloadResponse.Value.Details.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, downloadResponse.Value.Details.ImmutabilityPolicy.PolicyMode);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_IfModifiedSince()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                IfUnmodifiedSince = Recording.UtcNow.AddDays(1)
            };

            // Act
            Response<BlobImmutabilityPolicy> response = await blob.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy,
                conditions: conditions);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(nameof(BlobRequestConditions.IfMatch))]
        [TestCase(nameof(BlobRequestConditions.IfModifiedSince))]
        [TestCase(nameof(BlobRequestConditions.IfNoneMatch))]
        [TestCase(nameof(BlobRequestConditions.LeaseId))]
        [TestCase(nameof(BlobRequestConditions.TagConditions))]
        public async Task SetImmutibilityPolicyAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            BlobBaseClient blobBaseClient = new BlobBaseClient(new Uri("https://www.doesntmatter.com"), GetOptions());

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            BlobRequestConditions conditions = new BlobRequestConditions();

            switch (invalidCondition)
            {
                case nameof(BlobRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = Recording.UtcNow.AddMinutes(5);
                    break;
                case nameof(BlobRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(BlobRequestConditions.LeaseId):
                    conditions.LeaseId = string.Empty;
                    break;
                case nameof(BlobRequestConditions.TagConditions):
                    conditions.TagConditions = string.Empty;
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blobBaseClient.SetImmutabilityPolicyAsync(
                    immutabilityPolicy,
                    conditions),
                e =>
                {
                    Assert.IsTrue(e.Message.Contains($"SetImmutabilityPolicy does not support the {invalidCondition} condition(s)."));
                    Assert.IsTrue(e.Message.Contains("conditions"));
                });
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(AccountSasPermissions.All)]
        [TestCase(AccountSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_AccoutnSas(AccountSasPermissions sasPermissions)
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient, GetNewBlobName());

            BlobServiceClient sharedKeyServiceClient = InstrumentClient(
                BlobsClientBuilder.GetServiceClient_OAuthAccount_SharedKey());
            Uri serviceSasUri = sharedKeyServiceClient.GenerateAccountSasUri(
                sasPermissions,
                Recording.UtcNow.AddDays(1),
                AccountSasResourceTypes.All);
            BlobBaseClient sasBlobClient = InstrumentClient(new BlobServiceClient(serviceSasUri, GetOptions())
                .GetBlobContainerClient(_containerClient.Name)
                .GetBlobBaseClient(blob.Name));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Act
            Response<BlobImmutabilityPolicy> response = await sasBlobClient.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Act
            Response<BlobLegalHoldResult> legalHoldResponse = await sasBlobClient.SetLegalHoldAsync(hasLegalHold: false);

            // Assert
            Assert.IsFalse(legalHoldResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobContainerSasPermissions.All)]
        [TestCase(BlobContainerSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_ContainerSas(BlobContainerSasPermissions sasPermissions)
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient, GetNewBlobName());

            BlobContainerClient sharedKeyContainer = InstrumentClient(
                BlobsClientBuilder.GetServiceClient_OAuthAccount_SharedKey().GetBlobContainerClient(_containerClient.Name));
            Uri containerSasUri = sharedKeyContainer.GenerateSasUri(sasPermissions, Recording.UtcNow.AddDays(1));
            BlobBaseClient sasBlobClient = InstrumentClient(new BlobContainerClient(containerSasUri, GetOptions()).GetBlobBaseClient(blob.Name));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Act
            Response<BlobImmutabilityPolicy> response = await sasBlobClient.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Act
            Response<BlobLegalHoldResult> legalHoldResponse = await sasBlobClient.SetLegalHoldAsync(hasLegalHold: false);

            // Assert
            Assert.IsFalse(legalHoldResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobSasPermissions.All)]
        [TestCase(BlobSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobSas(BlobSasPermissions sasPermissions)
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient, GetNewBlobName());

            BlobBaseClient sharedKeyBlob = InstrumentClient(
                BlobsClientBuilder.GetServiceClient_OAuthAccount_SharedKey()
                    .GetBlobContainerClient(_containerClient.Name)
                    .GetBlobBaseClient(blob.Name));
            Uri blobSasUri = sharedKeyBlob.GenerateSasUri(sasPermissions, Recording.UtcNow.AddDays(1));
            BlobBaseClient sasBlobClient = InstrumentClient(new BlobBaseClient(blobSasUri, GetOptions()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Act
            Response<BlobImmutabilityPolicy> response = await sasBlobClient.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Act
            Response<BlobLegalHoldResult> legalHoldResponse = await sasBlobClient.SetLegalHoldAsync(hasLegalHold: false);

            // Assert
            Assert.IsFalse(legalHoldResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(SnapshotSasPermissions.All)]
        [TestCase(SnapshotSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobSnapshotSas(SnapshotSasPermissions sasPermissions)
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient, GetNewBlobName());

            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = _containerClient.Name,
                BlobName = blob.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1),
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(sasPermissions);
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigOAuth.AccountName, Tenants.TestConfigOAuth.AccountKey);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = snapshotResponse.Value.Snapshot,
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            BlobBaseClient sasBlobSnapshotClient = InstrumentClient(new BlobBaseClient(uriBuilder.ToUri(), GetOptions()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Act
            Response<BlobImmutabilityPolicy> response = await sasBlobSnapshotClient.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Act
            Response<BlobLegalHoldResult> legalHoldResponse = await sasBlobSnapshotClient.SetLegalHoldAsync(hasLegalHold: false);

            // Assert
            Assert.IsFalse(legalHoldResponse.Value.HasLegalHold);

            await sasBlobSnapshotClient.DeleteImmutabilityPolicyAsync();

            // Delete blob snapshot.
            await blob.WithSnapshot(snapshotResponse.Value.Snapshot).DeleteAsync();
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobVersionSasPermissions.All)]
        [TestCase(BlobVersionSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobVersionSas(BlobVersionSasPermissions sasPermissions)
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient, GetNewBlobName());

            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = _containerClient.Name,
                BlobName = blob.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1),
                Version = metadataResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(sasPermissions);
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(Tenants.TestConfigOAuth.AccountName, Tenants.TestConfigOAuth.AccountKey);
            BlobUriBuilder uriBuilder = new BlobUriBuilder(blob.Uri)
            {
                VersionId = metadataResponse.Value.VersionId,
                Sas = blobSasBuilder.ToSasQueryParameters(sharedKeyCredential)
            };

            BlobBaseClient sasBlobSnapshotClient = InstrumentClient(new BlobBaseClient(uriBuilder.ToUri(), GetOptions()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            // Act
            Response<BlobImmutabilityPolicy> response = await sasBlobSnapshotClient.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Act
            Response<BlobLegalHoldResult> legalHoldResponse = await sasBlobSnapshotClient.SetLegalHoldAsync(hasLegalHold: false);

            // Assert
            Assert.IsFalse(legalHoldResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_IfModifiedSince_Failed()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                IfUnmodifiedSince = Recording.UtcNow.AddDays(-1)
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetImmutabilityPolicyAsync(
                    immutabilityPolicy: immutabilityPolicy,
                    conditions: conditions),
                e => Assert.AreEqual("ConditionNotMet", e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_Error()
        {
            // Arrange
            BlobBaseClient blob = InstrumentClient(_containerClient.GetBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetImmutabilityPolicyAsync(immutabilityPolicy),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_Mutable()
        {
            // Arrange
            BlobBaseClient blob = InstrumentClient(_containerClient.GetBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Mutable
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.SetImmutabilityPolicyAsync(immutabilityPolicy),
                e => Assert.AreEqual("PolicyMode must be Locked or Unlocked", e.Message));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task DeleteImmutibilityPolicyAsync()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            await blob.SetImmutabilityPolicyAsync(immutabilityPolicy);

            // Act
            await blob.DeleteImmutabilityPolicyAsync();

            // Assert
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetDeleteImmutibilityPolicyAsync_Snapshot()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            Response<BlobSnapshotInfo> createSnapshotResponse = await blob.CreateSnapshotAsync();
            BlobBaseClient snapshotClient = blob.WithSnapshot(createSnapshotResponse.Value.Snapshot);
            try
            {
                BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
                {
                    ExpiresOn = Recording.UtcNow.AddSeconds(5),
                    PolicyMode = BlobImmutabilityPolicyMode.Unlocked
                };

                // Act
                await snapshotClient.SetImmutabilityPolicyAsync(immutabilityPolicy);

                // Assert that the base blob does not have an immutability policy.
                Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();
                Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
                Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);

                // Assert that the blob snapshot has an immuability policy.
                propertiesResponse = await snapshotClient.GetPropertiesAsync();
                Assert.IsNotNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
                Assert.IsNotNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);

                await snapshotClient.DeleteImmutabilityPolicyAsync();

                // Assert
                propertiesResponse = await snapshotClient.GetPropertiesAsync();
                Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
                Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            }
            finally
            {
                await snapshotClient.DeleteAsync();
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetDeleteImmutibilityPolicyAsync_BlobVersion()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            IDictionary<string, string> metadata = BuildMetadata();

            // Create Blob Version
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionClient = blob.WithVersion(setMetadataResponse.Value.VersionId);

            // Create another blob Version
            await blob.SetMetadataAsync(new Dictionary<string, string>());

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // Act
            await versionClient.SetImmutabilityPolicyAsync(immutabilityPolicy);

            // Assert that the base blob does not have an immutability policy
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);

            // Assert that the blob version does have an immutability policy
            propertiesResponse = await versionClient.GetPropertiesAsync();
            Assert.IsNotNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.IsNotNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);

            await versionClient.DeleteImmutabilityPolicyAsync();

            // Assert blob version does not have an immutability policy
            propertiesResponse = await versionClient.GetPropertiesAsync();
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.IsNull(propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task DeleteImmutibilityPolicyAsync_Error()
        {
            // Arrange
            BlobBaseClient blob = InstrumentClient(_containerClient.GetBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.DeleteImmutabilityPolicyAsync(),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            // Act
            Response<BlobLegalHoldResult> response = await blob.SetLegalHoldAsync(true);

            // Assert
            Assert.IsTrue(response.Value.HasLegalHold);

            // Validate that we are correctly deserializing Get Properties response.
            // Act
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Validate we are correctly deserializing Blob Items.
            // Act
            List<BlobItem> blobItems = new List<BlobItem>();

            GetBlobsOptions options = new GetBlobsOptions
            {
                Traits = BlobTraits.LegalHold,
                Prefix = blob.Name,
            };

            await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync(options))
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobItems.Count);
            Assert.IsTrue(blobItems[0].Properties.HasLegalHold);

            // Validate we are correctly deserialzing Get Blob response.
            // Act
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();

            // Assert
            Assert.IsTrue(downloadResponse.Value.Details.HasLegalHold);

            // Act
            response = await blob.SetLegalHoldAsync(false);

            // Assert
            Assert.IsFalse(response.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync_Snapshot()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            Response<BlobSnapshotInfo> createSnapshotResponse = await blob.CreateSnapshotAsync();
            BlobBaseClient snapshotClient = blob.WithSnapshot(createSnapshotResponse.Value.Snapshot);

            try
            {
                // Act
                await snapshotClient.SetLegalHoldAsync(true);

                // Assert the blob snapshot has a legal hold
                Response<BlobProperties> propertiesResponse = await snapshotClient.GetPropertiesAsync();
                Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

                // Assert the base blob does not have a legal hold
                propertiesResponse = await blob.GetPropertiesAsync();
                Assert.IsFalse(propertiesResponse.Value.HasLegalHold);

                await snapshotClient.SetLegalHoldAsync(false);
            }
            finally
            {
                await snapshotClient.DeleteAsync();
            }
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync_BlobVersion()
        {
            // Arrange
            BlobBaseClient blob = await GetNewBlobClient(_containerClient);

            IDictionary<string, string> metadata = BuildMetadata();

            // Create Blob Version
            Response<BlobInfo> setMetadataResponse = await blob.SetMetadataAsync(metadata);
            BlobBaseClient versionClient = blob.WithVersion(setMetadataResponse.Value.VersionId);

            // Create another blob Version
            await blob.SetMetadataAsync(new Dictionary<string, string>());

            // Act
            await versionClient.SetLegalHoldAsync(true);

            // Assert the blob version has a legal hold
            Response<BlobProperties> propertiesResponse = await versionClient.GetPropertiesAsync();
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Assert the base blob does not have a legal hold
            propertiesResponse = await blob.GetPropertiesAsync();
            Assert.IsFalse(propertiesResponse.Value.HasLegalHold);

            await versionClient.SetLegalHoldAsync(false);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync_Error()
        {
            // Arrange
            BlobBaseClient blob = InstrumentClient(_containerClient.GetBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetLegalHoldAsync(true),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerImmutableStorageWithVersioning()
        {
            // Validate we are deserializing Get Container Properties responses correctly.
            // Act
            Response<BlobContainerProperties> propertiesResponse = await _containerClient.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(propertiesResponse.Value.HasImmutableStorageWithVersioning);

            // Validate we are deserializing BlobContainerItems correctly.
            // Act
            BlobServiceClient blobServiceClient = _containerClient.GetParentBlobServiceClient();
            IList<BlobContainerItem> containers = await blobServiceClient.GetBlobContainersAsync().ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == _containerClient.Name).FirstOrDefault();

            // Assert
            Assert.IsTrue(containerItem.Properties.HasImmutableStorageWithVersioning);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CreateAppendBlob_ImmutableStorageWithVersioning()
        {
            // Arrange
            AppendBlobClient appendBlob = InstrumentClient(_containerClient.GetAppendBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                HasLegalHold = true
            };

            // Act
            Response<BlobContentInfo> createResponse = await appendBlob.CreateAsync(options);

            // Assert
            Response<BlobProperties> propertiesResponse = await appendBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CreatePageBlob_ImmutableStorageWithVersioning()
        {
            // Arrange
            PageBlobClient pageBlob = InstrumentClient(_containerClient.GetPageBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            PageBlobCreateOptions options = new PageBlobCreateOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            Response<BlobContentInfo> createResponse = await pageBlob.CreateAsync(size: Constants.KB, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await pageBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CommitBlockList_ImmutableStorageWithVersioning()
        {
            // Arrange
            BlockBlobClient blockBlob = InstrumentClient(_containerClient.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = GetRandomBuffer(Constants.KB);
            string blockName = GetNewBlockName();
            using Stream stream = new MemoryStream(data);
            await blockBlob.StageBlockAsync(ToBase64(blockName), stream);

            string[] blockList = new string[]
            {
                ToBase64(blockName)
            };

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            CommitBlockListOptions options = new CommitBlockListOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            await blockBlob.CommitBlockListAsync(blockList, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await blockBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task Upload_ImmutableStorageWithVersioning(bool multipart)
        {
            // Arrange
            BlockBlobClient blockBlob = InstrumentClient(_containerClient.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobUploadOptions options = new BlobUploadOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            if (multipart)
            {
                StorageTransferOptions transferOptions = new StorageTransferOptions
                {
                    InitialTransferSize = Constants.KB / 2,
                    MaximumTransferSize = Constants.KB / 2
                };
                options.TransferOptions = transferOptions;
            }

            // Act
            await blockBlob.UploadAsync(stream, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await blockBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SyncCopyFromUri_ImmutableStorageWithVersioning()
        {
            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(_containerClient);
            BlockBlobClient destBlob = InstrumentClient(_containerClient.GetBlockBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            await destBlob.SyncCopyFromUriAsync(
                srcBlob.GenerateSasUri(BlobSasPermissions.Read, Recording.UtcNow.AddHours(1)),
                options);

            // Assert
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task StartCopyFromUri_ImmutableStorageWithVersioning()
        {
            // Arrange
            BlobBaseClient srcBlob = await GetNewBlobClient(_containerClient);
            BlockBlobClient destBlob = InstrumentClient(_containerClient.GetBlockBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddMinutes(5),
                PolicyMode = BlobImmutabilityPolicyMode.Unlocked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiresOn.Value);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                DestinationImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);
            await operation.WaitForCompletionAsync();

            // Assert
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicy.ExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicy.PolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);
        }

        private DateTimeOffset RoundToNearestSecond(DateTimeOffset initalDateTimeOffset)
            => new DateTimeOffset(
                year: initalDateTimeOffset.Year,
                month: initalDateTimeOffset.Month,
                day: initalDateTimeOffset.Day,
                hour: initalDateTimeOffset.Hour,
                minute: initalDateTimeOffset.Minute,
                second: initalDateTimeOffset.Second,
                offset: TimeSpan.Zero);
    }
}
