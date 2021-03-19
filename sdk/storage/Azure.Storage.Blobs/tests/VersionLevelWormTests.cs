// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            DateTimeOffset expectedImmutabilityPolicyExpiry = new DateTimeOffset(
                year: immutabilityPolicy.ExpiriesOn.Value.Year,
                month: immutabilityPolicy.ExpiriesOn.Value.Month,
                day: immutabilityPolicy.ExpiriesOn.Value.Day,
                hour: immutabilityPolicy.ExpiriesOn.Value.Hour,
                minute: immutabilityPolicy.ExpiriesOn.Value.Minute,
                second: immutabilityPolicy.ExpiriesOn.Value.Second,
                offset: TimeSpan.Zero);

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
            TimeSpan remainingImmutibilityPolicyTime = expectedImmutabilityPolicyExpiry - Recording.UtcNow;
            if (remainingImmutibilityPolicyTime > TimeSpan.Zero)
            {
                await Delay((int)remainingImmutibilityPolicyTime.TotalMilliseconds + 250);
            }
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
            DateTimeOffset expectedImmutabilityPolicyExpiry = new DateTimeOffset(
                year: immutabilityPolicy.ExpiriesOn.Value.Year,
                month: immutabilityPolicy.ExpiriesOn.Value.Month,
                day: immutabilityPolicy.ExpiriesOn.Value.Day,
                hour: immutabilityPolicy.ExpiriesOn.Value.Hour,
                minute: immutabilityPolicy.ExpiriesOn.Value.Minute,
                second: immutabilityPolicy.ExpiriesOn.Value.Second,
                offset: TimeSpan.Zero);

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
            TimeSpan remainingImmutibilityPolicyTime = expectedImmutabilityPolicyExpiry - Recording.UtcNow;
            if (remainingImmutibilityPolicyTime > TimeSpan.Zero)
            {
                await Delay((int)remainingImmutibilityPolicyTime.TotalMilliseconds + 250);
            }
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
            DateTimeOffset expectedImmutabilityPolicyExpiry = new DateTimeOffset(
                year: immutabilityPolicy.ExpiriesOn.Value.Year,
                month: immutabilityPolicy.ExpiriesOn.Value.Month,
                day: immutabilityPolicy.ExpiriesOn.Value.Day,
                hour: immutabilityPolicy.ExpiriesOn.Value.Hour,
                minute: immutabilityPolicy.ExpiriesOn.Value.Minute,
                second: immutabilityPolicy.ExpiriesOn.Value.Second,
                offset: TimeSpan.Zero);

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
            TimeSpan remainingImmutibilityPolicyTime = expectedImmutabilityPolicyExpiry - Recording.UtcNow;
            if (remainingImmutibilityPolicyTime > TimeSpan.Zero)
            {
                await Delay((int)remainingImmutibilityPolicyTime.TotalMilliseconds + 250);
            }
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
            DateTimeOffset expectedImmutabilityPolicyExpiry = new DateTimeOffset(
                year: immutabilityPolicy.ExpiriesOn.Value.Year,
                month: immutabilityPolicy.ExpiriesOn.Value.Month,
                day: immutabilityPolicy.ExpiriesOn.Value.Day,
                hour: immutabilityPolicy.ExpiriesOn.Value.Hour,
                minute: immutabilityPolicy.ExpiriesOn.Value.Minute,
                second: immutabilityPolicy.ExpiriesOn.Value.Second,
                offset: TimeSpan.Zero);

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
            TimeSpan remainingImmutibilityPolicyTime = expectedImmutabilityPolicyExpiry - Recording.UtcNow;
            if (remainingImmutibilityPolicyTime > TimeSpan.Zero)
            {
                await Delay((int)remainingImmutibilityPolicyTime.TotalMilliseconds + 250);
            }
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
                    enabled: true));
        }

        public async ValueTask DisposeAsync()
        {
            if (Container != null)
            {
                await foreach (BlobItem blobItem in Container.GetBlobsAsync(traits: BlobTraits.ImmutabilityPolicy | BlobTraits.LegalHold))
                {
                    BlobClient blobClient = Container.GetBlobClient(blobItem.Name);
                    if (blobItem.Properties.HasLegalHold)
                    {
                        await blobClient.SetLegalHoldAsync(false);
                    }

                    //if (blobItem.Properties.ImmutabilityPolicyMode == BlobImmutabilityPolicyMode.Locked)
                    //{
                    //    BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
                    //    {
                    //        PolicyMode = BlobImmutabilityPolicyMode.Unlocked
                    //    };
                    //    await blobClient.SetImmutabilityPolicyAsync(immutabilityPolicy);
                    //}

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
