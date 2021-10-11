// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    [ClientTestFixture(
        DataLakeClientOptions.ServiceVersion.V2019_02_02,
        DataLakeClientOptions.ServiceVersion.V2019_07_07,
        DataLakeClientOptions.ServiceVersion.V2019_12_12,
        DataLakeClientOptions.ServiceVersion.V2020_02_10,
        DataLakeClientOptions.ServiceVersion.V2020_04_08,
        DataLakeClientOptions.ServiceVersion.V2020_06_12,
        DataLakeClientOptions.ServiceVersion.V2020_08_04,
        DataLakeClientOptions.ServiceVersion.V2020_10_02,
        DataLakeClientOptions.ServiceVersion.V2020_12_06,
        StorageVersionExtensions.LatestVersion,
        StorageVersionExtensions.MaxVersion,
        RecordingServiceVersion = StorageVersionExtensions.MaxVersion,
        LiveServiceVersions = new object[] { StorageVersionExtensions.LatestVersion })]
    public class DataLakeFileClientTransactionalHashingTests : TransactionalHashingTestBase<
        DataLakeServiceClient,
        DataLakeFileSystemClient,
        DataLakeFileClient,
        DataLakeClientOptions,
        DataLakeTestEnvironment>
    {
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

        private const string _fileResourcePrefix = "test-file-";

        public DataLakeFileClientTransactionalHashingTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewDataLakeClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<DataLakeFileSystemClient>> GetDisposingContainerAsync(
            DataLakeServiceClient service = null,
            string containerName = null)
            => await ClientBuilder.GetNewFileSystem(service: service, fileSystemName: containerName);

        protected override async Task<DataLakeFileClient> GetResourceClientAsync(
            DataLakeFileSystemClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            DataLakeClientOptions options = null)
        {
            container = InstrumentClient(new DataLakeFileSystemClient(container.Uri, Tenants.GetNewHnsSharedKeyCredentials(), options));
            var file = InstrumentClient(container.GetRootDirectoryClient().GetFileClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await file.CreateAsync();
            }
            return file;
        }

        protected override async Task<Response> UploadPartitionAsync(DataLakeFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions)
        {
            return await client.AppendAsync(source, 0, new DataLakeFileAppendOptions
            {
                TransactionalHashingOptions = hashingOptions
            });
        }

        protected override async Task<Response> DownloadPartitionAsync(DataLakeFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, HttpRange range = default)
        {
            var response = await client.ReadAsync(new DataLakeFileReadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });

            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelUploadAsync(DataLakeFileClient client, Stream source, UploadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            await client.UploadAsync(source, new DataLakeFileUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });
        }

        protected override async Task ParallelDownloadAsync(DataLakeFileClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions)
        {
            await client.ReadToAsync(destination, new DataLakeFileReadToOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });
        }

        protected override async Task<Stream> OpenWriteAsync(DataLakeFileClient client, UploadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            return await client.OpenWriteAsync(true, new DataLakeFileOpenWriteOptions
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task<Stream> OpenReadAsync(DataLakeFileClient client, DownloadTransactionalHashingOptions hashingOptions, int internalBufferSize)
        {
            return await client.OpenReadAsync(new DataLakeOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task SetupDataAsync(DataLakeFileClient client, Stream data)
        {
            await client.AppendAsync(data, 0);
            await client.FlushAsync(data.Length);
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
        {
            return request.Uri.Query.Contains("action=append");
        }

        /* TODO older tests, search them for anything missed in the refactor
        #region Read
        [Test, Combinatorial]
        public async Task ReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async data => await StageData(data, test.FileSystem, fileName),
                (fileSystem, testClientOptions) => MakeFileClient(fileSystem, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions) =>
                {
                    var response = await file.ReadAsync(new DataLakeFileReadOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                        Range = range
                    });
                    await response.Value.Content.CopyToAsync(Stream.Null);
                    return response.GetRawResponse();
                });
        }

        [Test, Combinatorial]
        public async Task ReadHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool validates)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestDownloadHashMismatchThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async data => await StageData(data, test.FileSystem, fileName),
                (fileSystem, testClientOptions) => MakeFileClient(fileSystem, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions, range) =>
                {
                    var response = await file.ReadAsync(new DataLakeFileReadOptions
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
        [TestCase(TransactionalHashAlgorithm.StorageCrc64, true)]
        // no hashing, so we save users a buffer
        [TestCase(TransactionalHashAlgorithm.None, false)]
        public async Task ExpectedReadStreamTypeReturned(TransactionalHashAlgorithm algorithm, bool isBuffered)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransactionalHashingOptions hashingOptions = algorithm == TransactionalHashAlgorithm.None
                ? default
                : new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await file.ReadAsync(new DataLakeFileReadOptions
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
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("StorageStreamDefinitions")] (int DataSize, int BufferSize) storageStreamDefinitions)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestOpenReadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, storageStreamDefinitions.DataSize, () => GetOptions(), test.FileSystem,
                async data => await StageData(data, test.FileSystem, fileName),
                (fileSystem, testClientOptions) => MakeFileClient(fileSystem, testClientOptions, createFile: false, fileName),
                async (file, hashingOptions) =>
                {
                    return await file.OpenReadAsync(new DataLakeOpenReadOptions(false)
                    {
                        TransactionalHashingOptions = hashingOptions,
                        BufferSize = storageStreamDefinitions.BufferSize
                    });
                });
        }
        #endregion

        #region PartitionedDownload
        [Test, Combinatorial]
        public async Task PartitionedDownloadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB, 3 * Constants.KB, 5 * Constants.KB)] int chunkSize)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            var fileName = GetNewFileName();
            await TransactionalHashingTestSkeletons.TestParallelDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, chunkSize, () => GetOptions(), test.FileSystem,
                async data => await StageData(data, test.FileSystem, fileName),
                (fileSystem, testClientOptions) => MakeFileClient(fileSystem, testClientOptions, createFile: false, fileName),
                (file, hashingOptions) => file.ReadToAsync(Stream.Null, new DataLakeFileReadToOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                    TransferOptions = new StorageTransferOptions { InitialTransferSize = chunkSize, MaximumTransferSize = chunkSize }
                }));
        }
        #endregion

        #region PartitionedUpload
        private static async Task FileParallelUploadAction(
            DataLakeFileClient file,
            Stream stream,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await file.UploadAsync(stream, new DataLakeFileUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task FileUploadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            await TransactionalHashingTestSkeletons.TestParallelUploadSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: false),
                FileParallelUploadAction,
                request => request.Uri.Query.Contains("action=append"));
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlockBlobClientUploadRejectPrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            var client = await MakeFileClient(test.FileSystem, GetOptions(), false);

            TransactionalHashingTestSkeletons.TestPrecalculatedHashNotAccepted(
                Recording.Random, algorithm,
                async (stream, hashingOptions) => await client.UploadAsync(stream, new DataLakeFileUploadOptions()
                {
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion

        #region Append
        private static async Task AppendAction(DataLakeFileClient file, Stream stream, UploadTransactionalHashingOptions hashingOptions)
            => await file.AppendAsync(
                stream,
                0,
                new DataLakeFileAppendOptions { TransactionalHashingOptions = hashingOptions });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            await TransactionalHashingTestSkeletons.TestUploadPartitionSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: true),
                AppendAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            await TransactionalHashingTestSkeletons.TestUploadPartitionUsePrecalculatedHashAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: true),
                AppendAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            await TransactionalHashingTestSkeletons.TestUploadPartitionMismatchedHashThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: true),
                AppendAction);
        }
        #endregion

        #region OpenWrite
        internal async Task<Stream> FileOpenWriteAction(DataLakeFileClient file, UploadTransactionalHashingOptions hashingOptions)
            => await file.OpenWriteAsync(true, new DataLakeFileOpenWriteOptions
            {
                BufferSize = Constants.KB,
                TransactionalHashingOptions = hashingOptions
            });

        [Test, Combinatorial]
        public async Task FileOpenWriteSuccessfulHashComputation(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB / 2, Constants.KB, Constants.KB * 2, Constants.KB + 5)] int bufferSize)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteSuccessfulHashComputationAsync(
                data, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: true),
                FileOpenWriteAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task FileOpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteMismatchedHashThrowsAsync(
                data, algorithm, () => GetOptions(), test.FileSystem,
                async (fileSystem, clientOptions) => await MakeFileClient(fileSystem, clientOptions, createFile: true),
                FileOpenWriteAction);
        }
        #endregion
        */
    }
}
