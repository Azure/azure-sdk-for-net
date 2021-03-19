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
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Microsoft.Azure.Management.Storage;
using Microsoft.Identity.Client;
using Microsoft.Rest;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class VersionLevelWormTests : BlobTestBase
    {
        public VersionLevelWormTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            // Test SetImmutabilityPolicyAsync API and validate response.
            // Act
            Response<BlobImmutabilityPolicy> response = await blob.SetImmutabilityPolicyAsync(immutabilityPolicy);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiriesOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Validate that we are correctly deserializing Get Properties response.
            // Act
            Response<BlobProperties> propertiesResponse = await blob.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);

            // Validate we are correctly deserializing Blob Items.
            // Act
            List<BlobItem> blobItems = new List<BlobItem>();
            await foreach (BlobItem blobItem in vlwContainer.Container.GetBlobsAsync(traits: BlobTraits.ImmutabilityPolicy))
            {
                blobItems.Add(blobItem);
            }

            // Assert
            Assert.AreEqual(1, blobItems.Count);
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, blobItems[0].Properties.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, blobItems[0].Properties.ImmutabilityPolicyMode);

            // Validate we are correctly deserialzing Get Blob response.
            // Act
            Response<BlobDownloadInfo> downloadResponse = await blob.DownloadAsync();

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, downloadResponse.Value.Details.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, downloadResponse.Value.Details.ImmutabilityPolicyMode);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_IfModifiedSince()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(1),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            BlobRequestConditions conditions = new BlobRequestConditions
            {
                IfUnmodifiedSince = Recording.UtcNow.AddDays(1)
            };

            // Act
            Response<BlobImmutabilityPolicy> response = await blob.SetImmutabilityPolicyAsync(
                immutabilityPolicy: immutabilityPolicy,
                conditions: conditions);

            // Assert
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, response.Value.ExpiriesOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetImmutibilityPolicyAsync_IfModifiedSince_Failed()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(1),
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
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(5),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetImmutabilityPolicyAsync(immutabilityPolicy),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = await GetNewBlobClient(vlwContainer.Container);

            // Act
            Response<BlobLegalHoldInfo> response = await blob.SetLegalHoldAsync(true);

            // Assert
            Assert.IsTrue(response.Value.LegalHoldEnabled);

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
            Assert.IsFalse(response.Value.LegalHoldEnabled);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SetLegalHoldAsync_Error()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient blob = InstrumentClient(vlwContainer.Container.GetBlobClient(GetNewBlobName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blob.SetLegalHoldAsync(true),
                e => Assert.AreEqual(BlobErrorCode.BlobNotFound.ToString(), e.ErrorCode));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerVersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);

            // Validate we are deserializing Get Container Properties responses correctly.
            // Act
            Response<BlobContainerProperties> propertiesResponse = await vlwContainer.Container.GetPropertiesAsync();

            // Assert
            Assert.IsTrue(propertiesResponse.Value.IsVersionLevelWormEnabled);

            // Validate we are deserializing BlobContainerItems correctly.
            // Act
            BlobServiceClient blobServiceClient = vlwContainer.Container.GetParentBlobServiceClient();
            IList<BlobContainerItem> containers = await blobServiceClient.GetBlobContainersAsync().ToListAsync();
            BlobContainerItem containerItem = containers.Where(c => c.Name == vlwContainer.Container.Name).FirstOrDefault();

            // Assert
            Assert.IsTrue(containerItem.Properties.IsVersionLevelWormEnabled);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CreateAppendBlob_VersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            AppendBlobClient appendBlob = InstrumentClient(vlwContainer.Container.GetAppendBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            AppendBlobCreateOptions options = new AppendBlobCreateOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            Response<BlobContentInfo> createResponse = await appendBlob.CreateAsync(options);

            // Assert
            Response<BlobProperties> propertiesResponse = await appendBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CreatePageBlob_VersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            PageBlobClient pageBlob = InstrumentClient(vlwContainer.Container.GetPageBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            PageBlobCreateOptions options = new PageBlobCreateOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            Response<BlobContentInfo> createResponse = await pageBlob.CreateAsync(size: Constants.KB, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await pageBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task CommitBlockList_VersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
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
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            CommitBlockListOptions options = new CommitBlockListOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            await blockBlob.CommitBlockListAsync(blockList, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await blockBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task Upload_VersionLevelWorm(bool multipart)
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlockBlobClient blockBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

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
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task SyncCopyFromUri_VersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient srcBlob = await GetNewBlobClient(vlwContainer.Container);
            BlockBlobClient destBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            await destBlob.SyncCopyFromUriAsync(srcBlob.Uri, options);

            // Assert
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task StartCopyFromUri_VersionLevelWorm()
        {
            // Arrange
            await using DisposingVersionLevelWormContainer vlwContainer = await GetTestVersionLevelWormContainer(TestConfigOAuth);
            BlobBaseClient srcBlob = await GetNewBlobClient(vlwContainer.Container);
            BlockBlobClient destBlob = InstrumentClient(vlwContainer.Container.GetBlockBlobClient(GetNewBlobName()));

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = Recording.UtcNow.AddSeconds(2),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // The service rounds Immutability Policy Expiry to the nearest second.
            DateTimeOffset expectedImmutabilityPolicyExpiry = RoundToNearestSecond(immutabilityPolicy.ExpiriesOn.Value);

            BlobCopyFromUriOptions options = new BlobCopyFromUriOptions
            {
                ImmutabilityPolicy = immutabilityPolicy,
                LegalHold = true
            };

            // Act
            Operation<long> operation = await destBlob.StartCopyFromUriAsync(srcBlob.Uri, options);

            if (Mode == RecordedTestMode.Playback)
            {
                await operation.WaitForCompletionAsync(TimeSpan.FromMilliseconds(10), CancellationToken.None);
            }
            else
            {
                await operation.WaitForCompletionAsync();
            }

            // Assert
            Response<BlobProperties> propertiesResponse = await destBlob.GetPropertiesAsync();
            Assert.AreEqual(expectedImmutabilityPolicyExpiry, propertiesResponse.Value.ImmutabilityPolicyExpiresOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, propertiesResponse.Value.ImmutabilityPolicyMode);
            Assert.IsTrue(propertiesResponse.Value.HasLegalHold);

            // Wait for immutability policy to expire.
            await WaitForImmutabilityPolicyToExpire(expectedImmutabilityPolicyExpiry);
        }

        private async Task <DisposingVersionLevelWormContainer> GetTestVersionLevelWormContainer(TenantConfiguration tenantConfiguration)
        {
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigOAuth.AccountName, TestConfigOAuth.AccountKey);
            Uri serviceUri = new Uri(TestConfigOAuth.BlobServiceEndpoint);
            BlobServiceClient blobServiceClient = InstrumentClient(new BlobServiceClient(serviceUri, sharedKeyCredential, GetOptions()));
            BlobContainerClient containerClient = InstrumentClient(blobServiceClient.GetBlobContainerClient(GetNewContainerName()));

            DisposingVersionLevelWormContainer disposingVersionLevelWormContainer = new DisposingVersionLevelWormContainer(
                tenantConfiguration,
                containerClient);
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

        private async Task WaitForImmutabilityPolicyToExpire(DateTimeOffset expiryTime)
        {
            TimeSpan remainingImmutibilityPolicyTime = expiryTime - Recording.UtcNow;
            if (remainingImmutibilityPolicyTime > TimeSpan.Zero)
            {
                await Delay((int)remainingImmutibilityPolicyTime.TotalMilliseconds + 250);
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    public class DisposingVersionLevelWormContainer : IAsyncDisposable
#pragma warning restore SA1402 // File may only contain a single type
    {
        public BlobContainerClient Container;

        private TenantConfiguration _tenantConfiguration;
        private StorageManagementClient _storageManagementClient;

        public DisposingVersionLevelWormContainer(
            TenantConfiguration tenantConfiguration,
            BlobContainerClient containerClient)
        {
            _tenantConfiguration = tenantConfiguration;
            Container = containerClient;
        }

        public async Task CreateAsync()
        {
            string subscriptionId = "ba45b233-e2ef-4169-8808-49eb0d8eba0d";
            string token = await GetAuthToken();
            TokenCredentials tokenCredentials = new TokenCredentials(token);
            _storageManagementClient = new StorageManagementClient(tokenCredentials) { SubscriptionId = subscriptionId };

            await _storageManagementClient.BlobContainers.CreateAsync(
                resourceGroupName: "XClient",
                accountName: _tenantConfiguration.AccountName,
                containerName: Container.Name,
                new Microsoft.Azure.Management.Storage.Models.BlobContainer(
                    publicAccess: Microsoft.Azure.Management.Storage.Models.PublicAccess.Container,
                    enabled: true));
        }

        public async ValueTask DisposeAsync()
        {
            if (Container != null)
            {
                await foreach (BlobItem blobItem in Container.GetBlobsAsync())
                {
                    BlobClient blobClient = Container.GetBlobClient(blobItem.Name);
                    await blobClient.SetLegalHoldAsync(false);
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
