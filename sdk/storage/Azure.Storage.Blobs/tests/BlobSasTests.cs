// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Tests
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
                Sas = blobSasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient appendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await appendBlobClient.CreateAsync();
        }

        [RecordedTest]
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
                Sas = blobSasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials())
            };

            // Act
            AppendBlobClient sasAppendBlobClient = InstrumentClient(new AppendBlobClient(blobUriBuilder.ToUri(), GetOptions()));
            await sasAppendBlobClient.DeleteAsync();
        }
    }
}
