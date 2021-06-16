// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Microsoft.Azure.Management.Storage;
using Microsoft.Identity.Client;
using Microsoft.Rest;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/20501")]
    public class ImmutableStorageWithVersioningTests : BlobTestBase
    {
        public ImmutableStorageWithVersioningTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

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
            await foreach (BlobItem blobItem in vlwContainer.Container.GetBlobsAsync(traits: BlobTraits.ImmutabilityPolicy))
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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

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
                e => Assert.AreEqual($"{invalidCondition} is not applicable to this API.", e.Message));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(AccountSasPermissions.All)]
        [TestCase(AccountSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_AccoutnSas(AccountSasPermissions sasPermissions)
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container, GetNewBlobName());

            BlobServiceClient sharedKeyServiceClient = InstrumentClient(
                GetServiceClient_OAuthAccount_SharedKey());
            Uri serviceSasUri = sharedKeyServiceClient.GenerateAccountSasUri(
                sasPermissions,
                Recording.UtcNow.AddDays(1),
                AccountSasResourceTypes.All);
            BlobBaseClient sasBlobClient = InstrumentClient(new BlobServiceClient(serviceSasUri, GetOptions())
                .GetBlobContainerClient(vlwContainer.Container.Name)
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20501")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobContainerSasPermissions.All)]
        [TestCase(BlobContainerSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_ContainerSas(BlobContainerSasPermissions sasPermissions)
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container, GetNewBlobName());

            BlobContainerClient sharedKeyContainer = InstrumentClient(
                GetServiceClient_OAuthAccount_SharedKey().GetBlobContainerClient(vlwContainer.Container.Name));
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20501")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobSasPermissions.All)]
        [TestCase(BlobSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobSas(BlobSasPermissions sasPermissions)
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container, GetNewBlobName());

            BlobBaseClient sharedKeyBlob = InstrumentClient(
                GetServiceClient_OAuthAccount_SharedKey()
                    .GetBlobContainerClient(vlwContainer.Container.Name)
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20501")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(SnapshotSasPermissions.All)]
        [TestCase(SnapshotSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobSnapshotSas(SnapshotSasPermissions sasPermissions)
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container, GetNewBlobName());

            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = vlwContainer.Container.Name,
                BlobName = blob.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1),
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(sasPermissions);
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigOAuth.AccountName, TestConfigOAuth.AccountKey);
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20501")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(BlobVersionSasPermissions.All)]
        [TestCase(BlobVersionSasPermissions.SetImmutabilityPolicy)]
        public async Task SetImmutibilityPolicyAsync_SetLegalHold_BlobVersionSas(BlobVersionSasPermissions sasPermissions)
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container, GetNewBlobName());

            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder
            {
                BlobContainerName = vlwContainer.Container.Name,
                BlobName = blob.Name,
                ExpiresOn = Recording.UtcNow.AddDays(1),
                Version = metadataResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(sasPermissions);
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigOAuth.AccountName, TestConfigOAuth.AccountKey);
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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiresOn = Recording.UtcNow.AddSeconds(1),
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
                e => Assert.AreEqual(BlobErrorCode.ConditionNotMet.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_Error()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

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
        public async Task DeleteImmutibilityPolicyAsync_Error()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

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
            await foreach (BlobItem blobItem in vlwContainer.Container.GetBlobsAsync(traits: BlobTraits.LegalHold))
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
        public async Task SetLegalHoldAsync_Error()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetLegalHoldAsync(true),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerImmutableStorageWithVersioning()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            // Validate we are deserializing Get Container Properties responses correctly.
            // Act
            Response<BlobContainerProperties> propertiesResponse = await vlwContainer.Container.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(propertiesResponse.Value.HasImmutableStorageWithVersioning);

            // Validate we are deserializing BlobContainerItems correctly.
            // Act
            BlobServiceClient blobServiceClient = vlwContainer.Container.GetParentBlobServiceClient();
            IList<BlobContainerItem> containers = await blobServiceClient.GetBlobContainersAsync().ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == vlwContainer.Container.Name).FirstOrDefault();

            // Assert
            Assert.IsTrue(containerItem.Properties.HasImmutableStorageWithVersioning);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CreateAppendBlob_ImmutableStorageWithVersioning()
        {
            // Arrange
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            AppendBlobClient appendBlob = InstrumentClient(vlwContainer.Container.GetAppendBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            PageBlobClient pageBlob = InstrumentClient(vlwContainer.Container.GetPageBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlockBlobClient blockBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlockBlobClient blockBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient srcBlob = await GetNewBlobClient(vlwContainer.Container);
            BlockBlobClient destBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

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
            await destBlob.SyncCopyFromUriAsync(srcBlob.Uri, options);

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
            await using DisposingImmutableStorageWithVersioningContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient srcBlob = await GetNewBlobClient(vlwContainer.Container);
            BlockBlobClient destBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

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

        private async Task <DisposingImmutableStorageWithVersioningContainer> GetTestVersionLevelWormContainer(TenantConfiguration tenantConfiguration)
        {
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigOAuth.AccountName, TestConfigOAuth.AccountKey);
            Uri serviceUri = new Uri(TestConfigOAuth.BlobServiceEndpoint);
            BlobServiceClient blobServiceClient = InstrumentClient(new BlobServiceClient(serviceUri, sharedKeyCredential, GetOptions()));
            BlobContainerClient containerClient = InstrumentClient(blobServiceClient.GetBlobContainerClient(GetNewContainerName()));

            DisposingImmutableStorageWithVersioningContainer disposingVersionLevelWormContainer = new DisposingImmutableStorageWithVersioningContainer(
                tenantConfiguration,
                containerClient,
                Mode);
            await disposingVersionLevelWormContainer.CreateAsync();
            return disposingVersionLevelWormContainer;
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

#pragma warning disable SA1402 // File may only contain a single type
    public class DisposingImmutableStorageWithVersioningContainer : IAsyncDisposable
#pragma warning restore SA1402 // File may only contain a single type
    {
        public BlobContainerClient Container;

        private TenantConfiguration _tenantConfiguration;
        private StorageManagementClient _storageManagementClient;

        private RecordedTestMode _testMode;

        public DisposingImmutableStorageWithVersioningContainer(
            TenantConfiguration tenantConfiguration,
            BlobContainerClient containerClient,
            RecordedTestMode recordedTestMode)
        {
            _tenantConfiguration = tenantConfiguration;
            Container = containerClient;
            _testMode = recordedTestMode;
        }

        public async Task CreateAsync()
        {
            if (_testMode == RecordedTestMode.Playback)
            {
                return;
            }

            string subscriptionId = _tenantConfiguration.SubscriptionId;
            string token = await GetAuthToken();
            TokenCredentials tokenCredentials = new TokenCredentials(token);
            _storageManagementClient = new StorageManagementClient(tokenCredentials) { SubscriptionId = subscriptionId };

            await _storageManagementClient.BlobContainers.CreateAsync(
                resourceGroupName: _tenantConfiguration.ResourceGroupName,
                accountName: _tenantConfiguration.AccountName,
                containerName: Container.Name,
                new Microsoft.Azure.Management.Storage.Models.BlobContainer(
                    publicAccess: Microsoft.Azure.Management.Storage.Models.PublicAccess.Container,
                    immutableStorageWithVersioning: new Microsoft.Azure.Management.Storage.Models.ImmutableStorageWithVersioning(true)));
        }

        public async ValueTask DisposeAsync()
        {
            if (_testMode == RecordedTestMode.Playback)
            {
                return;
            }

            if (Container != null)
            {
                await foreach (BlobItem blobItem in Container.GetBlobsAsync(BlobTraits.ImmutabilityPolicy | BlobTraits.LegalHold))
                {
                    BlobClient blobClient = Container.GetBlobClient(blobItem.Name);

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

                try
                {
                    await _storageManagementClient.BlobContainers.DeleteAsync(
                        resourceGroupName: "XClient",
                        accountName: _tenantConfiguration.AccountName,
                        containerName: Container.Name);
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }

        private async Task<string> GetAuthToken()
        {
            IConfidentialClientApplication application = ConfidentialClientApplicationBuilder.Create(_tenantConfiguration.ActiveDirectoryApplicationId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantConfiguration.ActiveDirectoryTenantId)
                .WithClientSecret(_tenantConfiguration.ActiveDirectoryApplicationSecret)
                .Build();

            string[] scopes = new string[] { "https://management.azure.com/.default" };

            AcquireTokenForClientParameterBuilder result = application.AcquireTokenForClient(scopes);
            AuthenticationResult authenticationResult = await result.ExecuteAsync();
            return authenticationResult.AccessToken;
        }
    }
}
