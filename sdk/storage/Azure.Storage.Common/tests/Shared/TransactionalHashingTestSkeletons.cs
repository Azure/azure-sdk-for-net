// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Tests.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// We're going to make our tests retry a few additional error types that
    /// may be more wasteful, but are less likely to cause test failures.
    /// </summary>
    public static class TransactionalHashingTestSkeletons
    {
        internal static Action<Request> GetRequestHashAssertion(TransactionalHashAlgorithm algorithm, Func<Request, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            void AssertHash(RequestHeaders headers, string headerName)
            {
                if (headers.TryGetValue(headerName, out string hash))
                {
                    if (expectedHash != default)
                    {
                        Assert.AreEqual(Convert.ToBase64String(expectedHash), hash);
                    }
                }
                else
                {
                    Assert.Fail($"{headerName} expected on request but was not found.");
                }
            };

            return request =>
            {
                if (isHashExpected != default && !isHashExpected(request))
                {
                    return;
                }

                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        AssertHash(request.Headers, "Content-MD5");
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        AssertHash(request.Headers, "x-ms-content-crc64");
                        break;
                    default:
                        throw new Exception("Bad TransactionalHashAlgorithm provided to Request hash assertion.");
                }
            };
        }

        internal static Action<Response> GetResponseHashAssertion(TransactionalHashAlgorithm algorithm, Func<Response, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            void AssertHash(ResponseHeaders headers, string headerName)
            {
                if (headers.TryGetValue(headerName, out string hash))
                {
                    if (expectedHash != default)
                    {
                        Assert.AreEqual(Convert.ToBase64String(expectedHash), hash);
                    }
                }
                else
                {
                    Assert.Fail($"{headerName} expected on response but was not found.");
                }
            };

            return response =>
            {
                if (isHashExpected != default && !isHashExpected(response))
                {
                    return;
                }

                switch (algorithm)
                {
                    case TransactionalHashAlgorithm.MD5:
                        AssertHash(response.Headers, "Content-MD5");
                        break;
                    case TransactionalHashAlgorithm.StorageCrc64:
                        AssertHash(response.Headers, "x-ms-content-crc64");
                        break;
                    default:
                        throw new Exception("Bad TransactionalHashAlgorithm provided to Response hash assertion.");
                }
            };
        }

        /// <summary>
        /// Checks if service returns an error that content and transactional hash did not match.
        /// </summary>
        /// <param name="writeAction"></param>
        /// <param name="algorithm"></param>
        internal static void AssertWriteHashMismatch(AsyncTestDelegate writeAction, TransactionalHashAlgorithm algorithm)
        {
            var exception = Assert.ThrowsAsync<RequestFailedException>(writeAction);
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

        #region UploadPartition Tests
        public static async Task TestUploadPartitionSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await uploadPartitionAsync(client, stream, hashingOptions);
            }
        }

        public static async Task TestUploadPartitionUsePrecalculatedHashAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            var hashSizeBytes = algorithm switch
            {
                TransactionalHashAlgorithm.MD5 => 16,
                TransactionalHashAlgorithm.StorageCrc64 => 8,
                _ => throw new ArgumentException("Cannot determine hash size for provided algorithm type")
            };
            // hash needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedHash = TestHelper.GetRandomBuffer(hashSizeBytes, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, expectedHash: precalculatedHash));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            hashPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                AssertWriteHashMismatch(async () => await uploadPartitionAsync(client, stream, hashingOptions), algorithm);
            }
        }

        public static async Task TestUploadPartitionMismatchedHashThrowsAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var streamTamperPolicy = new TamperStreamContentsPolicy();
            var clientOptions = getOptions();
            clientOptions.AddPolicy(streamTamperPolicy, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            using (var stream = new MemoryStream(data))
            {
                streamTamperPolicy.TransformRequestBody = true;
                AssertWriteHashMismatch(async () => await uploadPartitionAsync(client, stream, hashingOptions), algorithm);
            }
        }
        #endregion

        #region OpenWrite Tests
        // TODO make sync and async
        public static async Task TestOpenWriteSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            byte[] writeBuffer,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, UploadTransactionalHashingOptions, Task<Stream>> openWriteAsync) where TClientOptions : ClientOptions
        {
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var writeStream = await openWriteAsync(client, hashingOptions);

            hashPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, 10))
            {
                await writeStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
            }
        }

        // TODO make sync and async
        public static async Task TestOpenWriteMismatchedHashThrowsAsync<TClient, TParentClient, TClientOptions>(
            byte[] writeBuffer,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, UploadTransactionalHashingOptions, Task<Stream>> openWriteAsync) where TClientOptions : ClientOptions
        {
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var clientOptions = getOptions();
            var tamperPolicy = new TamperStreamContentsPolicy();
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var writeStream = await openWriteAsync(client, hashingOptions);

            AssertWriteHashMismatch(async () =>
            {
                tamperPolicy.TransformRequestBody = true;
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    await writeStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
                }
            }, algorithm);
        }
        #endregion

        #region Parallel Upload Tests
        public static async Task TestParallelUploadSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, StorageTransferOptions, Task> parallelUploadAsync,
            Func<Request, bool> isHashExpected = default) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            StorageTransferOptions transferOptions = default;

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, isHashExpected));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await parallelUploadAsync(client, stream, hashingOptions, transferOptions);
            }
        }

        public static void TestPrecalculatedHashNotAccepted(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<Stream, UploadTransactionalHashingOptions, Task> uploadAsync)
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = TestHelper.GetRandomBuffer(16, random)
            };

            var exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await uploadAsync(new MemoryStream(data), hashingOptions));
            Assert.AreEqual("Precalculated hash not supported when potentially partitioning an upload.", exception.Message);
        }
        #endregion

        #region Parallel Download Tests
        public static async Task TestParallelDownloadSuccessfulHashVerificationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            int chunkSize,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<byte[], Task> setupDataAsync,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, DownloadTransactionalHashingOptions, Task> parallelDownloadAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            await setupDataAsync(data);

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act / Assert
            hashPipelineAssertion.CheckResponse = true;
            await parallelDownloadAsync(client, hashingOptions);
        }
        #endregion

        #region OpenRead Tests
        public static async Task TestOpenReadSuccessfulHashVerificationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            int dataSize,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<byte[], Task> setupDataAsync,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, DownloadTransactionalHashingOptions, Task<Stream>> openReadAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(dataSize, random);
            await setupDataAsync(data);

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await openReadAsync(client, hashingOptions);

            // Assert
            hashPipelineAssertion.CheckResponse = true;
            Assert.DoesNotThrowAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
        #endregion

        #region Download Streaming/Content Tests
        public static async Task TestDownloadSuccessfulHashVerificationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<byte[], Task> setupDataAsync,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, DownloadTransactionalHashingOptions, Task<Response>> downloadAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            await setupDataAsync(data);

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };
            var client = await getObjectClientAsync(parentClient, getOptions());

            // Act
            var response = await downloadAsync(client, hashingOptions);

            // Assert
            switch (algorithm)
            {
                case TransactionalHashAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case TransactionalHashAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }

        public static async Task TestDownloadHashMismatchThrowsAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<byte[], Task> setupDataAsync,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, DownloadTransactionalHashingOptions, HttpRange, Task<Response>> downloadAsync,
            bool deferValidation) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            await setupDataAsync(data);

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm, DeferValidation = deferValidation };

            // alter response contents in pipeline, forcing a hash mismatch on verification step
            var clientOptions = getOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy() { TransformResponseBody = true }, HttpPipelinePosition.PerCall);
            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await downloadAsync(client, hashingOptions, new HttpRange(length: data.Length));

            // Assert
            if (deferValidation)
            {
                Assert.DoesNotThrowAsync(operation);
            }
            else
            {
                Assert.ThrowsAsync<InvalidDataException>(operation);
            }
        }
        #endregion
    }
}
