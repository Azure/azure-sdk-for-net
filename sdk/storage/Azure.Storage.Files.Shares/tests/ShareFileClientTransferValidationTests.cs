// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileClientTransferValidationTests : TransferValidationTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";

        public ShareFileClientTransferValidationTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(
            ShareServiceClient service = null,
            string containerName = null,
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None)
            => await ClientBuilder.GetTestShareAsync(service: service, shareName: containerName);

        protected override async Task<ShareFileClient> GetResourceClientAsync(
            ShareClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None,
            ShareClientOptions options = null)
        {
            options ??= ClientBuilder.GetOptions();

            AssertSupportsHashAlgorithm(uploadAlgorithm);
            AssertSupportsHashAlgorithm(downloadAlgorithm);

            options.TransferValidation.Upload.ChecksumAlgorithm = uploadAlgorithm;
            options.TransferValidation.Download.ChecksumAlgorithm = downloadAlgorithm;

            container = InstrumentClient(new ShareClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options));
            var file = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await file.CreateAsync(resourceLength);
            }
            return file;
        }

        private void AssertSupportsHashAlgorithm(StorageChecksumAlgorithm algorithm)
        {
            if (algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "Azure File Share does not support CRC64.");
            }
        }

        protected override async Task<Response> UploadPartitionAsync(ShareFileClient client, Stream source, UploadTransferValidationOptions transferValidation)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            return (await client.UploadRangeAsync(new HttpRange(0, source.Length), source, new ShareFileUploadRangeOptions
            {
                TransferValidation = transferValidation
            })).GetRawResponse();
        }

        protected override async Task<Response> DownloadPartitionAsync(ShareFileClient client, Stream destination, DownloadTransferValidationOptions transferValidation, HttpRange range = default)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            var response = await client.DownloadAsync(new ShareFileDownloadOptions
            {
                TransferValidation = transferValidation,
                Range = range
            });
            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelUploadAsync(ShareFileClient client, Stream source, UploadTransferValidationOptions transferValidation, StorageTransferOptions transferOptions)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            await client.UploadAsync(source, new ShareFileUploadOptions
            {
                TransferValidation = transferValidation,
                // files ignores transfer options
            });
        }

        protected override Task ParallelDownloadAsync(ShareFileClient client, Stream destination, DownloadTransferValidationOptions transferValidation, StorageTransferOptions transferOptions)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Pass("Share file client does not support parallel download.");
            return Task.CompletedTask;
        }

        protected override async Task<Stream> OpenWriteAsync(ShareFileClient client, UploadTransferValidationOptions transferValidation, int internalBufferSize)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            return await client.OpenWriteAsync(false, 0, new ShareFileOpenWriteOptions
            {
                TransferValidation = transferValidation,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task<Stream> OpenReadAsync(ShareFileClient client, DownloadTransferValidationOptions transferValidation, int internalBufferSize)
        {
            AssertSupportsHashAlgorithm(transferValidation?.ChecksumAlgorithm ?? default);

            return await client.OpenReadAsync(new ShareFileOpenReadOptions(false)
            {
                TransferValidation = transferValidation,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task SetupDataAsync(ShareFileClient client, Stream data)
        {
            await client.UploadAsync(data);
        }

        protected override bool ParallelUploadIsChecksumExpected(Request request) => true;

        [Test]
        public override void TestAutoResolve()
        {
            Assert.AreEqual(
                StorageChecksumAlgorithm.MD5,
                TransferValidationOptionsExtensions.ResolveAuto(StorageChecksumAlgorithm.Auto));
        }
    }
}
