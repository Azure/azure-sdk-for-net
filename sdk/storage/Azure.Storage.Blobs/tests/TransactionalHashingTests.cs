// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
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

        internal Action<Request> GetRequestHashAssertion(TransactionalHashAlgorithm algorithm, Func<Request, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            return request =>
            {
                if (isHashExpected != default && !isHashExpected(request)) {
                    return;
                }

                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        if (request.Headers.TryGetValue("Content-MD5", out string md5))
                        {
                            if (expectedHash != default)
                            {
                                Assert.AreEqual(Convert.ToBase64String(expectedHash), md5);
                            }
                        }
                        else
                        {
                            Assert.Fail("Content-MD5 expected on request but was not found.");
                        }
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        if (request.Headers.TryGetValue("x-ms-content-crc64", out string crc))
                        {
                            if (expectedHash != default)
                            {
                                Assert.AreEqual(Convert.ToBase64String(expectedHash), crc);
                            }
                        }
                        else
                        {
                            Assert.Fail("x-ms-content-crc64 expected on request but was not found.");
                        }
                        break;
                    default:
                        throw new Exception("Bad TransactionalHashAlgorithm provided to Request hash assertion.");
                }
            };
        }

        internal Action<Response> GetResponseHashAssertion(TransactionalHashAlgorithm algorithm, Func<Response, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            return response =>
            {
                if (isHashExpected != default && !isHashExpected(response))
                {
                    return;
                }

                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        if (response.Headers.TryGetValue("Content-MD5", out string md5))
                        {
                            if (expectedHash != default)
                            {
                                Assert.AreEqual(Convert.ToBase64String(expectedHash), md5);
                            }
                        }
                        else
                        {
                            Assert.Fail("Content-MD5 expected on request but was not found.");
                        }
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        if (response.Headers.TryGetValue("x-ms-content-crc64", out string crc))
                        {
                            if (expectedHash != default)
                            {
                                Assert.AreEqual(Convert.ToBase64String(expectedHash), crc);
                            }
                        }
                        else
                        {
                            Assert.Fail("x-ms-content-crc64 expected on request but was not found.");
                        }
                        break;
                    default:
                        throw new Exception("Bad TransactionalHashAlgorithm provided to Request hash assertion.");
                }
            };
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

            // Act
            var response = await blob.DownloadStreamingAsync(new BlobBaseDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });

            // Assert
            Assert.DoesNotThrowAsync(async () => await response.Value.Content.CopyToAsync(Stream.Null));
        }

        [Test, Combinatorial]
        public async Task DownloadStreamingHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool defers)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm, DeferValidation = defers };

            // alter response contents in pipeline, forcing a hash mismatch on verification step
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy(), HttpPipelinePosition.PerCall);
            blob = new BlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await blob.DownloadStreamingAsync(new BlobBaseDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            if (defers)
            {
                Assert.DoesNotThrowAsync(operation);
            }
            else
            {
                Assert.ThrowsAsync<InvalidDataException>(operation);
            }
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
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobBaseDownloadOptions
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

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);
            blob = InstrumentClient(new BlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await blob.OpenReadAsync(new BlobOpenReadOptions(false)
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = storageStreamDefinitions.BufferSize
            });

            // Assert
            hashPipelineAssertion.CheckResponse = true;
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

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);
            blob = InstrumentClient(new BlobClient(blob.Uri, GetNewSharedKeyCredentials(), clientOptions));
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            hashPipelineAssertion.CheckResponse = true;
            await blob.DownloadToAsync(new BlobBaseDownloadToOptions(Stream.Null)
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = new StorageTransferOptions { InitialTransferSize = chunkSize, MaximumTransferSize = chunkSize }
            });
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlobClientUploadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(DefaultDataSize);

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
            var hashingOptions = new UploadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions
                });
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlobClientUploadUsePrecalculatedOnOneshot(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB); // well below partition size

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            // create an incorrect hash to check on request pipeline, guaranteeing we didn't autocalculate
            var precalculatedHash = GetRandomBuffer(16);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                }));
                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        Assert.AreEqual("Md5Mismatch", exception.ErrorCode);
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        Assert.AreEqual("Crc64Mismatch", exception.ErrorCode);
                        break;
                    default:
                        throw new ArgumentException("Test arguments contain bad algorithm specifier.");
                }
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task BlobClientUploadIgnorePrecalculatedOnSplit(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blockSize = Constants.KB;
            var data = GetRandomBuffer(2 * blockSize);

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(
                algorithm,
                // only check put block, not put block list
                isHashExpected: request => request.Uri.Query.Contains("blockid=")));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            // create bad hash for to ignore
            var precalculatedHash = GetRandomBuffer(16);
            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                    TransferOptions = new StorageTransferOptions
                    {
                        InitialTransferSize = blockSize,
                        MaximumTransferSize = blockSize
                    }
                });
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        //[TestCase(TransactionalHashAlgorithm.StorageCrc64)] TODO #23578
        public async Task BlockBlobClientUploadUsePrecalculatedOnOneshot(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB); // well below partition size

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            // create an incorrect hash to check on request pipeline, guaranteeing we didn't autocalculate
            var precalculatedHash = GetRandomBuffer(16);
            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            // Act / Assert

            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                }));
                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        Assert.AreEqual("Md5Mismatch", exception.ErrorCode);
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        Assert.AreEqual("Crc64Mismatch", exception.ErrorCode);
                        break;
                    default:
                        throw new ArgumentException("Test arguments contain bad algorithm specifier.");
                }
            }

            // TODO intercept requests in pipeline to check for hash values
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task BlockBlobClientUploadIgnorePrecalculatedOnSplit(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blockSize = Constants.KB;
            var data = GetRandomBuffer(2 * blockSize);

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(
                algorithm,
                // only check put block, not put block list
                isHashExpected: request => request.Uri.Query.Contains("blockid=")));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // create bad hash to ignore
            var precalculatedHash = GetRandomBuffer(16);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await blob.UploadAsync(stream, new BlobUploadOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                    TransferOptions = new StorageTransferOptions
                    {
                        InitialTransferSize = blockSize,
                        MaximumTransferSize = blockSize
                    }
                });
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task StageBlockSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blockSize = Constants.KB;
            var data = GetRandomBuffer(2 * blockSize);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await blob.StageBlockAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes("blockId")), stream, new BlockBlobStageBlockOptions
                {
                    TransactionalHashingOptions = hashingOptions,
                });
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task StageBlockUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            const int blockSize = Constants.KB;
            var data = GetRandomBuffer(2 * blockSize);

            var precalculatedHash = GetRandomBuffer(16);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, expectedHash: precalculatedHash));
            var clientOptions = GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var container = InstrumentClient(new BlobContainerClient(test.Container.Uri, GetNewSharedKeyCredentials(), clientOptions));
            BlockBlobClient blob = InstrumentClient(container.GetBlockBlobClient(GetNewBlobName()));

            // Act / Assert
            hashPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                // we sent a bad hash; this request will fail
                var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await blob.StageBlockAsync(
                    Convert.ToBase64String(Encoding.UTF8.GetBytes("blockId")),
                    stream,
                    new BlockBlobStageBlockOptions
                    {
                        TransactionalHashingOptions = hashingOptions,
                    }));
                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        Assert.AreEqual("Md5Mismatch", exception.ErrorCode);
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        Assert.AreEqual("Crc64Mismatch", exception.ErrorCode);
                        break;
                    default:
                        throw new ArgumentException("Test arguments contain bad algorithm specifier.");
                }
            }
        }
    }
}
