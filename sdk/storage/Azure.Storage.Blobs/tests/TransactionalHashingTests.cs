// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class TransactionalHashingTests : BlobTestBase
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

        public TransactionalHashingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region DownloadContent
        [Test, Combinatorial]
        public async Task DownloadContentSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform a download with some hashing options
                async (blob, hashingOptions) => (await blob.DownloadContentAsync(new BlobDownloadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                    Range = range
                })).GetRawResponse());
        }

        [Test, Combinatorial]
        public async Task DownloadContentHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool defers)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestDownloadHashMismatchThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform a download with some hashing options
                async (blob, hashingOptions, range) => (await blob.DownloadContentAsync(new BlobDownloadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                    Range = range
                })).GetRawResponse(),
                defers);
        }
        #endregion

        #region DownloadStreaming
        /// <summary>
        /// Stages some data where a preset blob name is needed.
        /// </summary>
        private async Task StageData(byte[] data, BlobContainerClient container, string blobName)
        {
            BlobClient blob = InstrumentClient(container.GetBlobClient(blobName));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
        }

        [Test, Combinatorial]
        public async Task DownloadStreamingSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform a download with some hashing options
                async (blob, hashingOptions) =>
                {
                    var response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                        Range = range
                    });
                    await response.Value.Content.CopyToAsync(Stream.Null);
                    return response.GetRawResponse();
                });
        }

        [Test, Combinatorial]
        public async Task DownloadStreamingHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool defers)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestDownloadHashMismatchThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform a download with some hashing options
                async (blob, hashingOptions, range) =>
                {
                    var response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                        Range = range
                    });
                    await response.Value.Content.CopyToAsync(Stream.Null);
                    return response.GetRawResponse();
                },
                defers);
        }

        // hashing, so we buffered the stream to hash then rewind before returning to user
        [TestCase(TransactionalHashAlgorithm.MD5, true)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64, true)]
        // no hashing, so we save users a buffer
        [TestCase(TransactionalHashAlgorithm.None, false)]
        public async Task ExpectedDownloadStreamingStreamTypeReturned(TransactionalHashAlgorithm algorithm, bool isBuffered)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransactionalHashingOptions hashingOptions = algorithm == TransactionalHashAlgorithm.None
                ? default
                : new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
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
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestOpenReadSuccessfulHashVerificationAsync(
                Recording.Random,
                algorithm,
                storageStreamDefinitions.DataSize,
                () => GetOptions(),
                test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform the operation (this skeleton performs the stream reads after calling this open)
                async (blob, hashingOptions) =>
                {
                    return await blob.OpenReadAsync(new BlobOpenReadOptions(false)
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
            await using DisposingContainer test = await GetTestContainerAsync();

            var blobName = GetNewBlobName();
            await TransactionalHashingTestSkeletons.TestParallelDownloadSuccessfulHashVerificationAsync(
                Recording.Random, algorithm, chunkSize, () => GetOptions(), test.Container,
                // tell test how to stage data for download
                async data => await StageData(data, test.Container, blobName),
                // tell test how to get a blob client to the staged data given some client options
                (container, testClientOptions) => MakeBlobClient(container, testClientOptions, blobName),
                // tell test how to perform a parallel download with some hashing options
                (blob, hashingOptions) => blob.DownloadToAsync(new BlobDownloadToOptions(Stream.Null)
                {
                    TransactionalHashingOptions = hashingOptions,
                    TransferOptions = new StorageTransferOptions { InitialTransferSize = chunkSize, MaximumTransferSize = chunkSize }
                }));
        }
        #endregion

        #region BlobClient PartitionedUpload
        private Task<BlobClient> MakeBlobClient(BlobContainerClient container, BlobClientOptions testClientOptions)
            => MakeBlobClient(container, testClientOptions, GetNewBlobName());

        private Task<BlobClient> MakeBlobClient(BlobContainerClient container, BlobClientOptions testClientOptions, string blobName)
        {
            container = InstrumentClient(new BlobContainerClient(container.Uri, GetNewSharedKeyCredentials(), testClientOptions));
            return Task.FromResult(InstrumentClient(container.GetBlobClient(blobName)));
        }

        private static async Task BlobParallelUploadAction(
            BlobClient blob,
            Stream stream,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await blob.UploadAsync(stream, new BlobUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlobClientUploadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestParallelUploadSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeBlobClient, BlobParallelUploadAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlobClientUploadRejectPrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var client = await MakeBlobClient(test.Container, GetOptions());

            TransactionalHashingTestSkeletons.TestPrecalculatedHashNotAccepted(
                Recording.Random, algorithm,
                async (stream, hashingOptions) => await client.UploadAsync(stream, new BlobUploadOptions()
                {
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion

        #region BlockBlobClient PartitionedUpload
        private static async Task BlockBlobParallelUploadAction(
            BlockBlobClient blob,
            Stream stream,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await blob.UploadAsync(stream, new BlobUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlockBlobClientUploadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestParallelUploadSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeBlockBlobClient, BlockBlobParallelUploadAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlockBlobClientUploadRejectPrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var client = await MakeBlockBlobClient(test.Container, GetOptions());

            TransactionalHashingTestSkeletons.TestPrecalculatedHashNotAccepted(
                Recording.Random, algorithm,
                async (stream, hashingOptions) => await client.UploadAsync(stream, new BlobUploadOptions()
                {
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion

        #region BlockBlobClient StageBlock
        private Task<BlockBlobClient> MakeBlockBlobClient(BlobContainerClient container, BlobClientOptions testClientOptions)
        {
            container = InstrumentClient(new BlobContainerClient(container.Uri, GetNewSharedKeyCredentials(), testClientOptions));
            return Task.FromResult(InstrumentClient(container.GetBlockBlobClient(GetNewBlobName())));
        }

        private static async Task StageBlockAction(BlockBlobClient blob, Stream stream, UploadTransactionalHashingOptions hashingOptions)
            => await blob.StageBlockAsync(
                Convert.ToBase64String(Encoding.UTF8.GetBytes("blockId")),
                stream,
                new BlockBlobStageBlockOptions { TransactionalHashingOptions = hashingOptions });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task StageBlockSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container,
                MakeBlockBlobClient,
                StageBlockAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task StageBlockUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionUsePrecalculatedHashAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeBlockBlobClient, StageBlockAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task StageBlockMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionMismatchedHashThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeBlockBlobClient, StageBlockAction);
        }
        #endregion

        #region PageBlobClient UploadPages
        private async Task<PageBlobClient> MakePageBlobClient(BlobContainerClient container, BlobClientOptions testClientOptions)
        {
            PageBlobClient blob = InstrumentClient(container.GetPageBlobClient(GetNewBlobName()));
            await blob.CreateAsync(Constants.MB, new PageBlobCreateOptions());
            return InstrumentClient(new PageBlobClient(blob.Uri, GetNewSharedKeyCredentials(), testClientOptions));
        }

        private static async Task UploadPagesAction(PageBlobClient blob, Stream stream, UploadTransactionalHashingOptions hashingOptions)
            => await blob.UploadPagesAsync(stream, 0, new PageBlobUploadPagesOptions
            {
                TransactionalHashingOptions = hashingOptions,
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task UploadPagesSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakePageBlobClient, UploadPagesAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task UploadPagesUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionUsePrecalculatedHashAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakePageBlobClient, UploadPagesAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task UploadPagesMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionMismatchedHashThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakePageBlobClient, UploadPagesAction);
        }
        #endregion

        #region AppendBlobClient AppendBlock
        private async Task<AppendBlobClient> MakeAppendBlobClient(BlobContainerClient container, BlobClientOptions testClientOptions)
        {
            AppendBlobClient blob = InstrumentClient(container.GetAppendBlobClient(GetNewBlobName()));
            await blob.CreateAsync();
            return InstrumentClient(new AppendBlobClient(blob.Uri, GetNewSharedKeyCredentials(), testClientOptions));
        }

        private static async Task AppendBlockAction(AppendBlobClient blob, Stream stream, UploadTransactionalHashingOptions hashingOptions)
            => await blob.AppendBlockAsync(stream, new AppendBlobAppendBlockOptions
            {
                TransactionalHashingOptions = hashingOptions,
            });

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendBlockSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionSuccessfulHashComputationAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeAppendBlobClient, AppendBlockAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendBlockUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionUsePrecalculatedHashAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeAppendBlobClient, AppendBlockAction);
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendBlockMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            await TransactionalHashingTestSkeletons.TestUploadPartitionMismatchedHashThrowsAsync(
                Recording.Random, algorithm, () => GetOptions(), test.Container, MakeAppendBlobClient, AppendBlockAction);
        }
        #endregion

        #region BlockBlobClient OpenWrite
        [Test, Combinatorial]
        public async Task BlockBlobOpenWriteSuccessfulHashComputation(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB / 2, Constants.KB, Constants.KB * 2, Constants.KB + 5)] int bufferSize)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteSuccessfulHashComputationAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                (container, clientOptions) =>
                {
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    blob = InstrumentClient(new BlockBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));
                    return Task.FromResult(blob);
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(true, new BlockBlobOpenWriteOptions
                {
                    BufferSize = bufferSize, TransactionalHashingOptions = hashingOptions
                }));
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task BlockBlobOpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteMismatchedHashThrowsAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                (container, clientOptions) =>
                {
                    BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
                    blob = InstrumentClient(new BlockBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));
                    return Task.FromResult(blob);
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(true, new BlockBlobOpenWriteOptions
                {
                    BufferSize = Constants.KB,
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion

        #region PageBlobClient OpenWrite
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task PageBlobOpenWriteSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB - 5);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteSuccessfulHashComputationAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                async (container, clientOptions) =>
                {
                    PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await blob.CreateAsync(Constants.MB);
                    blob = InstrumentClient(new PageBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));

                    return blob;
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(false, 0, new PageBlobOpenWriteOptions
                {
                    BufferSize = Constants.KB, TransactionalHashingOptions = hashingOptions
                }));
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task PageBlobOpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteMismatchedHashThrowsAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                async (container, clientOptions) =>
                {
                    PageBlobClient blob = InstrumentClient(test.Container.GetPageBlobClient(GetNewBlobName()));
                    await blob.CreateAsync(Constants.MB);
                    blob = InstrumentClient(new PageBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));

                    return blob;
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(false, 0, new PageBlobOpenWriteOptions
                {
                    BufferSize = Constants.KB,
                    TransactionalHashingOptions = hashingOptions,
                    Size = Constants.MB
                }));
        }
        #endregion

        #region AppendBlobClient OpenWrite
        [Test, Combinatorial]
        public async Task AppendBlobOpenWriteSuccessfulHashComputation(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB / 2, Constants.KB, Constants.KB * 2, Constants.KB + 5)] int bufferSize)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteSuccessfulHashComputationAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                async (container, clientOptions) =>
                {
                    AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await blob.CreateAsync();
                    blob = InstrumentClient(new AppendBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));

                    return blob;
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(true, new AppendBlobOpenWriteOptions
                {
                    BufferSize = bufferSize, TransactionalHashingOptions = hashingOptions
                }));
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task AppendBlobOpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            // Act / Assert
            await TransactionalHashingTestSkeletons.TestOpenWriteMismatchedHashThrowsAsync(
                data,
                algorithm,
                () => GetOptions(),
                test.Container,
                async (container, clientOptions) =>
                {
                    AppendBlobClient blob = InstrumentClient(test.Container.GetAppendBlobClient(GetNewBlobName()));
                    await blob.CreateAsync();
                    blob = InstrumentClient(new AppendBlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));

                    return blob;
                },
                async (blob, hashingOptions) => await blob.OpenWriteAsync(true, new AppendBlobOpenWriteOptions
                {
                    BufferSize = Constants.KB,
                    TransactionalHashingOptions = hashingOptions
                }));
        }
        #endregion
    }
}
