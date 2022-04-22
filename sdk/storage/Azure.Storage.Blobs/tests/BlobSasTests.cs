// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Test
{
    public class BlobSasTests : BlobTestBase
    {
        public BlobSasTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task BlobSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task BlobIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobVersionSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                BlobVersionId = createResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(BlobVersionSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                VersionId = createResponse.Value.VersionId,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobVersionIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            Response<BlobContentInfo> createResponse = await blob.CreateAsync();
            IDictionary<string, string> metadata = BuildMetadata();
            Response<BlobInfo> metadataResponse = await blob.SetMetadataAsync(metadata);

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                BlobVersionId = createResponse.Value.VersionId
            };
            blobSasBuilder.SetPermissions(BlobVersionSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                VersionId = createResponse.Value.VersionId,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobSnapshotSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(SnapshotSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = snapshotResponse.Value.Snapshot,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_04_08)]
        public async Task BlobSnapshotIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();
            Response<BlobSnapshotInfo> snapshotResponse = await blob.CreateSnapshotAsync();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder()
            {
                ExpiresOn = Recording.UtcNow.AddDays(1),
                BlobContainerName = test.Container.Name,
                BlobName = blobName,
                Snapshot = snapshotResponse.Value.Snapshot
            };
            blobSasBuilder.SetPermissions(SnapshotSasPermissions.All);

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blob.Uri)
            {
                Snapshot = snapshotResponse.Value.Snapshot,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobContainerSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(Tenants.GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task ContainerIdentitySas_AllPermissions()
        {
            // Arrange
            BlobServiceClient oauthService = BlobsClientBuilder.GetServiceClient_OAuth();
            string containerName = GetNewContainerName();
            string blobName = GetNewBlobName();
            await using DisposingContainer test = await GetTestContainerAsync(containerName: containerName, service: oauthService);

            Response<UserDelegationKey> userDelegationKey = await oauthService.GetUserDelegationKeyAsync(
                startsOn: null,
                expiresOn: Recording.UtcNow.AddHours(1));

            BlobSasBuilder blobSasBuilder = new BlobSasBuilder(
                permissions: BlobContainerSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1))
            {
                BlobContainerName = test.Container.Name,
            };

            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(test.Container.Uri)
            {
                BlobName = blobName,
                Sas = blobSasBuilder.ToSasQueryParameters(userDelegationKey.Value, oauthService.AccountName)
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_AllPermissions()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            string blobName = GetNewBlobName();
            AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(blobName));
            await blob.CreateAsync();

            AccountSasBuilder accountSasBuilder = new AccountSasBuilder(
                permissions: AccountSasPermissions.All,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: AccountSasServices.Blobs,
                resourceTypes: AccountSasResourceTypes.Object);

            Uri accountSasUri = test.Container.GetParentBlobServiceClient().GenerateAccountSasUri(accountSasBuilder);
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(accountSasUri)
            {
                BlobContainerName = test.Container.Name,
                BlobName = blobName
            };

            // Assert
            AppendBlobClient sasBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasBlobClient.GetPropertiesAsync();
        }
    }
}
