// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task CreateFile_Data_SuccessfulHashComputation()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.MD5;
            await using IDisposingContainer<ShareClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            byte[] data = GetRandomBuffer(dataLength);

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm));
            ShareClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            ShareClient container = InstrumentClient(new ShareClient(disposingContainer.Container.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            ShareFileClient fileClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(GetNewResourceName()));

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                ShareFileCreateOptions options = new ShareFileCreateOptions
                {
                    Content = stream,
                    TransferValidation = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = algorithm
                    }
                };

                await fileClient.CreateAsync(maxSize: Constants.KB, options: options);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public virtual async Task CreateFile_Data_UsePrecalculatedHashSuccess()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.MD5;
            await using IDisposingContainer<ShareClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            byte[] data = GetRandomBuffer(dataLength);
            // checksum is expected
            byte[] precalculatedChecksum = MD5.Create().ComputeHash(data);

            // make pipeline assertion for checking precalculated checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm, expectedChecksum: precalculatedChecksum));
            ShareClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            ShareClient container = InstrumentClient(new ShareClient(disposingContainer.Container.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            ShareFileClient fileClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(GetNewResourceName()));

            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                ShareFileCreateOptions options = new ShareFileCreateOptions
                {
                    Content = stream,
                    TransferValidation = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = algorithm,
                        PrecalculatedChecksum = precalculatedChecksum
                    }
                };

                await fileClient.CreateAsync(maxSize: Constants.KB, options: options);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public virtual async Task CreateFile_Data_UsePrecalculatedHashFail()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.MD5;
            await using IDisposingContainer<ShareClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            byte[] data = GetRandomBuffer(dataLength);
            // service throws different error for crc only when checksum size in incorrect; we don't want to test that
            long checksumSizeBytes = 16;
            // checksum needs to be wrong so we detect difference from auto-SDK correct calculation
            byte[] precalculatedChecksum = GetRandomBuffer(checksumSizeBytes);

            // make pipeline assertion for checking precalculated checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm, expectedChecksum: precalculatedChecksum));
            ShareClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            ShareClient container = InstrumentClient(new ShareClient(disposingContainer.Container.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            ShareFileClient fileClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(GetNewResourceName()));

            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                ShareFileCreateOptions options = new ShareFileCreateOptions
                {
                    Content = stream,
                    TransferValidation = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = algorithm,
                        PrecalculatedChecksum = precalculatedChecksum
                    }
                };

                // Act
                AsyncTestDelegate operation = async () => await fileClient.CreateAsync(maxSize: Constants.KB, options: options);

                // Assert
                AssertWriteChecksumMismatch(operation, algorithm);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public virtual async Task CreateFile_Data_MismatchedHashThrows()
        {
            StorageChecksumAlgorithm algorithm = StorageChecksumAlgorithm.MD5;
            await using IDisposingContainer<ShareClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            byte[] data = GetRandomBuffer(dataLength);

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var streamTamperPolicy = new TamperStreamContentsPolicy();
            ShareClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(streamTamperPolicy, HttpPipelinePosition.PerCall);

            ShareClient container = InstrumentClient(new ShareClient(disposingContainer.Container.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            ShareFileClient fileClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(GetNewResourceName()));

            using (var stream = new MemoryStream(data))
            {
                ShareFileCreateOptions options = new ShareFileCreateOptions
                {
                    Content = stream,
                    TransferValidation = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = algorithm
                    }
                };

                // Act
                streamTamperPolicy.TransformRequestBody = true;
                AsyncTestDelegate operation = async () => await fileClient.CreateAsync(maxSize: Constants.KB, options: options);

                // Assert
                AssertWriteChecksumMismatch(operation, algorithm);
            }
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public virtual async Task CreateFile_Data_DisablesDefaultClientValidationOptions()
        {
            await using IDisposingContainer<ShareClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            byte[] data = GetRandomBuffer(dataLength);

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            ShareClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            ShareClient container = InstrumentClient(new ShareClient(disposingContainer.Container.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            ShareFileClient fileClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(GetNewResourceName()));

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                ShareFileCreateOptions options = new ShareFileCreateOptions
                {
                    Content = stream,
                    TransferValidation = new UploadTransferValidationOptions
                    {
                        ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
                    }
                };

                await fileClient.CreateAsync(maxSize: Constants.KB, options: options);
            }

            // Assert
            // Assertion was in the pipeline
        }
    }
}
