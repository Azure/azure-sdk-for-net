// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class TransactionalHashingTests : FileTestBase
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

        public TransactionalHashingTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Setup Actions
        private Task<ShareFileClient> MakeFileClient(ShareClient share, ShareClientOptions testClientOptions, bool createFile, int fileSize = 2 * Constants.KB)
            => MakeFileClient(share, testClientOptions, createFile, GetNewFileName(), fileSize);

        private async Task<ShareFileClient> MakeFileClient(ShareClient fileShare, ShareClientOptions clientOptions, bool createFile, string fileName, int fileSize = 2 * Constants.KB)
        {
            fileShare = InstrumentClient(new ShareClient(fileShare.Uri, Tenants.GetNewSharedKeyCredentials(), clientOptions));
            var file = InstrumentClient(fileShare.GetRootDirectoryClient().GetFileClient(fileName));
            if (createFile)
            {
                await file.CreateAsync(fileSize);
            }
            return file;
        }

        private async Task StageData(byte[] data, ShareClient fileShare, string fileName, int fileSize = 2 * Constants.KB)
        {
            ShareFileClient file = InstrumentClient(fileShare.GetRootDirectoryClient().GetFileClient(fileName));
            await file.CreateAsync(fileSize);
            using (var stream = new MemoryStream(data))
            {
                await file.UploadAsync(stream);
            }
        }
        #endregion

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
    }
}
