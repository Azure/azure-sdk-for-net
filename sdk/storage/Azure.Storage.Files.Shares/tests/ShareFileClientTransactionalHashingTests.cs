// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [ClientTestFixture(
        ShareClientOptions.ServiceVersion.V2019_02_02,
        ShareClientOptions.ServiceVersion.V2019_07_07,
        ShareClientOptions.ServiceVersion.V2019_12_12,
        ShareClientOptions.ServiceVersion.V2020_02_10,
        ShareClientOptions.ServiceVersion.V2020_04_08,
        ShareClientOptions.ServiceVersion.V2020_06_12,
        ShareClientOptions.ServiceVersion.V2020_08_04,
        ShareClientOptions.ServiceVersion.V2020_10_02,
        ShareClientOptions.ServiceVersion.V2020_12_06,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
        RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
        LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class ShareFileClientTransactionalHashingTests : TransactionalHashingTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";

        public ShareFileClientTransactionalHashingTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service: service, shareName: containerName);

        protected override async Task<ShareFileClient> GetResourceClientAsync(
            ShareClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            ShareClientOptions options = null)
        {
            container = InstrumentClient(new ShareClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            var file = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await file.CreateAsync(resourceLength);
            }
            return file;
        }

        private static void AssertSupportsHashAlgorithm(TransactionalHashAlgorithm algorithm)
        {
            if (algorithm == TransactionalHashAlgorithm.StorageCrc64)
            {
                /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
                 * Change this to pass for recording and revert when done. */
                Assert.Inconclusive("Azure File Share does not support CRC64.");
            }
        }

        protected override async Task<Response> UploadPartitionAsync(ShareFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            return (await client.UploadRangeAsync(new HttpRange(0, source.Length), source, new ShareFileUploadRangeOptions
            {
                TransactionalHashingOptions = hashingOptions
            })).GetRawResponse();
        }

        protected override async Task<Response> DownloadPartitionAsync(ShareFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, HttpRange range = default)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            var response = await client.DownloadAsync(new ShareFileDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });
            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelUploadAsync(ShareFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            await client.UploadAsync(source, new ShareFileUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                // files ignores transfer options
            });
        }

        protected override Task ParallelDownloadAsync(ShareFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Pass("Share file client does not support parallel download.");
            return Task.CompletedTask;
        }

        protected override async Task<Stream> OpenWriteAsync(ShareFileClient client, UploadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            return await client.OpenWriteAsync(false, 0, new ShareFileOpenWriteOptions
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task<Stream> OpenReadAsync(ShareFileClient client, DownloadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            AssertSupportsHashAlgorithm(hashingOptions?.Algorithm ?? default);

            return await client.OpenReadAsync(new ShareFileOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task SetupDataAsync(ShareFileClient client, Stream data)
        {
            await client.UploadAsync(data);
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
        {
            return true;
        }
    }
}
