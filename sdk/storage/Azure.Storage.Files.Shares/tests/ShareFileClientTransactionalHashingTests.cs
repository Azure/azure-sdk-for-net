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

        #region Test Arg Definitions
        private const long DefaultDataSize = Constants.KB;
        private static IEnumerable<HttpRange> DefaultDataHttpRanges
        {
            get
            {
                yield return new HttpRange(0, 512);
                yield return new HttpRange(256, 512);
                yield return new HttpRange(512, 512);
            }
        }

        private static IEnumerable<(int DataSize, int BufferSize)> StorageStreamDefinitions
        {
            get
            {
                yield return (Constants.KB, Constants.KB);
            }
        }
        #endregion

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
            container = InstrumentClient(new ShareClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options));
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

            Assert.Inconclusive("Share file client does not support parallel download.");
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

        /* TODO older tests, search them for anything missed in the refactor
        #region Read
        [Test, Combinatorial]
        public async Task DownloadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingShare test = await GetTestShareAsync();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async data => await StageData(data, test.Share, fileName),
                (fileShare, testClientOptions) => MakeFileClient(fileShare, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions) =>
                {
                    var response = await file.DownloadAsync(new ShareFileDownloadOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                        Range = range
                    });
                    await response.Value.Content.CopyToAsync(Stream.Null);
                    return response.GetRawResponse();
                });
        }

        [Test, Combinatorial]
        public async Task DownloadHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool validates)
        {
            await using DisposingShare test = await GetTestShareAsync();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestDownloadHashMismatchThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async data => await StageData(data, test.Share, fileName),
                (fileShare, testClientOptions) => MakeFileClient(fileShare, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions, range) =>
                {
                    var response = await file.DownloadAsync(new ShareFileDownloadOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                        Range = range
                    });
                    await response.Value.Content.CopyToAsync(Stream.Null);
                    return response.GetRawResponse();
                },
                validates);
        }

        // hashing, so we buffered the stream to hash then rewind before returning to user
        [TestCase(TransactionalHashAlgorithm.MD5, true)]
        // no hashing, so we save users a buffer
        [TestCase(TransactionalHashAlgorithm.None, false)]
        public async Task ExpectedDownloadStreamTypeReturned(TransactionalHashAlgorithm algorithm, bool isBuffered)
        {
            await using DisposingShare test = await GetTestShareAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            ShareFileClient file = InstrumentClient(test.Share.GetRootDirectoryClient().GetFileClient(GetNewFileName()));
            await file.CreateAsync(Constants.KB);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransactionalHashingOptions hashingOptions = algorithm == TransactionalHashAlgorithm.None
                ? default
                : new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await file.DownloadAsync(new ShareFileDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            if (isBuffered)
            {
                Assert.AreEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
            // actual unbuffered stream type is private; just check we didn't get back a buffered stream
            else
            {
                Assert.AreNotEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
        }
        #endregion

        #region OpenRead
        [Test, Combinatorial]
        public async Task OpenReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5)] TransactionalHashAlgorithm algorithm,
            [ValueSource("StorageStreamDefinitions")] (int DataSize, int BufferSize) storageStreamDefinitions)
        {
            await using DisposingShare test = await GetTestShareAsync();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestOpenReadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, storageStreamDefinitions.DataSize, () => GetOptions(), test.Share,
                async data => await StageData(data, test.Share, fileName),
                (fileShare, testClientOptions) => MakeFileClient(fileShare, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions) =>
                {
                    return await file.OpenReadAsync(new ShareFileOpenReadOptions(false)
                    {
                        TransactionalHashingOptions = hashingOptions,
                        BufferSize = storageStreamDefinitions.BufferSize
                    });
                });
        }
        #endregion

        #region PartitionedUpload
        private static async Task FileParallelUploadAction(
            ShareFileClient file,
            Stream stream,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await file.UploadAsync(stream, new ShareFileUploadOptions
            {
                TransactionalHashingOptions = hashingOptions
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        public async Task FileUploadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            await TransactionalHashingTestSkeletons.TestParallelUploadSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                FileParallelUploadAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task FileUploadRejectPrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            var client = await MakeFileClient(test.Share, GetOptions(), false);

            TransactionalHashingTestSkeletons.TestPrecalculatedHashNotAccepted(
                Recording.Random, algorithm,
                async (stream, hashingOptions) => await client.UploadAsync(stream, new ShareFileUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion

        #region Append
        private static async Task UploadRangeAction(ShareFileClient file, Stream stream, UploadTransactionalHashingOptions hashingOptions)
            => await file.UploadRangeAsync(
                new HttpRange(length: stream.Length),
                stream,
                new ShareFileUploadRangeOptions { TransactionalHashingOptions = hashingOptions });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        public async Task AppendSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                UploadRangeAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        public async Task AppendUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionUsePrecalculatedHashAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                UploadRangeAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        public async Task AppendMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionMismatchedHashThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                UploadRangeAction);
        }
        #endregion

        #region OpenWrite
        internal async Task<Stream> FileOpenWriteAction(ShareFileClient file, UploadTransactionalHashingOptions hashingOptions, int bufferSize)
            => await file.OpenWriteAsync(true, 0, new ShareFileOpenWriteOptions
            {
                BufferSize = bufferSize,
                TransactionalHashingOptions = hashingOptions,
                MaxSize = Constants.MB
            });

        [Test, Combinatorial]
        public async Task FileOpenWriteSuccessfulHashComputation(
            [Values(TransactionalHashAlgorithm.MD5)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB / 2, Constants.KB, Constants.KB * 2, Constants.KB + 5)] int bufferSize)
        {
            await using DisposingShare test = await GetTestShareAsync();

            // Arrange
            var data = GetRandomBuffer(2 * Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteSuccessfulHashComputationAsync(
                data, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                async (file, hashingOptions) => await FileOpenWriteAction(file, hashingOptions, bufferSize));
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        public async Task FileOpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingShare test = await GetTestShareAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteMismatchedHashThrowsAsync(
                data, algorithm, () => GetOptions(), test.Share,
                async (fileShare, clientOptions) => await MakeFileClient(fileShare, clientOptions, createFile: true),
                async (file, hashingOptions) => await FileOpenWriteAction(file, hashingOptions, Constants.KB));
        }
        #endregion
        */
    }
}
