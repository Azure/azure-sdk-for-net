// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Models;
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

        [Test, Combinatorial]
        public async Task DownloadContentSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync(new BlobBaseDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });

            // Assert
            // we didn't throw, so that's good
            switch (algorithm)
            {
                case TransactionalHashAlgorithm.MD5:
                    Assert.True(response.GetRawResponse().Headers.Contains("Content-MD5"));
                    break;
                case TransactionalHashAlgorithm.StorageCrc64:
                    Assert.True(response.GetRawResponse().Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }

        [Test, Combinatorial]
        public async Task DownloadStreamingSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("DefaultDataHttpRanges")] HttpRange range)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            Assert.DoesNotThrowAsync(async () => await (await blob.DownloadStreamingAsync(new BlobBaseDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            })).Value.Content.CopyToAsync(Stream.Null));
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
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobBaseDownloadOptions { TransactionalHashingOptions = hashingOptions });

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

        [Test, Combinatorial]
        public async Task OpenReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [ValueSource("StorageStreamDefinitions")] (int DataSize, int BufferSize) storageStreamDefinitions)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(storageStreamDefinitions.DataSize);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await blob.OpenReadAsync(new BlobOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = storageStreamDefinitions.BufferSize
            });

            // Assert
            Assert.DoesNotThrowAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }

        [Test, Combinatorial]
        public async Task PartitionedDownloadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(Constants.KB, 3 * Constants.KB, 5 * Constants.KB)] int chunkSize)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            Response<BlobDownloadResult> response = await blob.DownloadContentAsync(new BlobBaseDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions
            });

            // Assert
            // we didn't throw, so that's good
            switch (algorithm)
            {
                case TransactionalHashAlgorithm.MD5:
                    Assert.True(response.GetRawResponse().Headers.Contains("Content-MD5"));
                    break;
                case TransactionalHashAlgorithm.StorageCrc64:
                    Assert.True(response.GetRawResponse().Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }
    }
}
