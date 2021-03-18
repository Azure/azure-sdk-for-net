// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
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
            BlobContainerClient blobContainer = await CreateVersionLevelWormContainer();
            BlobBaseClient blob = await GetNewBlobClient(blobContainer);

            BlobImmutabilityPolicy immutabilityPolicy = new BlobImmutabilityPolicy
            {
                ExpiriesOn = BuildExpiryDateTimeOffset(),
                PolicyMode = BlobImmutabilityPolicyMode.Locked
            };

            // Act
            Response<BlobImmutabilityPolicy> response = await blob.SetImmutabilityPolicyAsync(immutabilityPolicy);

            // Assert
            Assert.AreEqual(immutabilityPolicy.ExpiriesOn, response.Value.ExpiriesOn);
            Assert.AreEqual(immutabilityPolicy.PolicyMode, response.Value.PolicyMode);

            //await blobContainer.DeleteIfExistsAsync();
        }

        // TODO how do we record this??
        public async Task<BlobContainerClient> CreateVersionLevelWormContainer()
        {
            // TODO move this to TestConfiguration.xml
            string subscriptionId = "ba45b233-e2ef-4169-8808-49eb0d8eba0d";
            string token = await GetAuthToken();
            TokenCredentials tokenCredentials = new TokenCredentials(token);
            StorageManagementClient storageManagementClient = new StorageManagementClient(tokenCredentials) { SubscriptionId = subscriptionId };
            string containerName = GetNewContainerName();

            await storageManagementClient.BlobContainers.CreateAsync(
                resourceGroupName: "XClient",
                accountName: TestConfigOAuth.AccountName,
                containerName: containerName,
                new Microsoft.Azure.Management.Storage.Models.BlobContainer(
                    enabled: true));

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(TestConfigOAuth.AccountName, TestConfigOAuth.AccountKey);
            Uri serviceUri = new Uri(TestConfigOAuth.BlobServiceEndpoint);
            BlobServiceClient blobServiceClient = InstrumentClient(new BlobServiceClient(serviceUri, sharedKeyCredential, GetOptions()));
            return InstrumentClient(blobServiceClient.GetBlobContainerClient(containerName));

            //await storageManagementClient.BlobContainers.CreateOrUpdateImmutabilityPolicyAsync(
            //    resourceGroupName: "XClient",
            //    accountName: TestConfigOAuth.AccountName,
            //    containerName: containerClient.Name,
            //    immutabilityPeriodSinceCreationInDays: 1,
            //    allowProtectedAppendWrites: true);

            //await storageManagementClient.BlobContainers.VersionLevelWormMethodAsync(
            //    // TODO
            //    resourceGroupName: "XClient",
            //    accountName: TestConfigOAuth.AccountName,
            //    containerName: containerClient.Name);
        }

        //public async Task DeleteVersionLevelWormContainer(BlobContainerClient containerClient)
        //{
        //    string subscriptionId = "ba45b233-e2ef-4169-8808-49eb0d8eba0d";
        //    string token = await GetAuthToken();
        //    TokenCredentials tokenCredentials = new TokenCredentials(token);
        //    StorageManagementClient storageManagementClient = new StorageManagementClient(tokenCredentials) { SubscriptionId = subscriptionId };
        //    storageManagementClient.BlobContainers.
        //}

        /// <summary>
        /// The service rounds expiry times for Version Level Worm to the nearest second.
        /// We're sending a DateTimeOffset without milliseconds so our equality check will pass in the unit tests.
        /// </summary>
        private DateTimeOffset BuildExpiryDateTimeOffset()
            => new DateTimeOffset(
                    Recording.UtcNow.Year,
                    Recording.UtcNow.Month,
                    Recording.UtcNow.Day,
                    Recording.UtcNow.Hour + 1,
                    Recording.UtcNow.Minute,
                    Recording.UtcNow.Second,
                    TimeSpan.Zero);

        private async Task<string> GetAuthToken()
        {
            IConfidentialClientApplication application = ConfidentialClientApplicationBuilder.Create(TestConfigOAuth.ActiveDirectoryApplicationId)
                .WithAuthority(AzureCloudInstance.AzurePublic, TestConfigOAuth.ActiveDirectoryTenantId)
                .WithClientSecret(TestConfigOAuth.ActiveDirectoryApplicationSecret)
                .Build();

            string[] scopes = new string[] { "https://management.azure.com/.default" };

            AcquireTokenForClientParameterBuilder result = application.AcquireTokenForClient(scopes);
            AuthenticationResult authenticationResult = await result.ExecuteAsync();
            return authenticationResult.AccessToken;
        }
    }
}
