// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
    }
}
