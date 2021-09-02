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
            // hash needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedHash = TestHelper.GetRandomBuffer(16, random);
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
            Func<TClient, Stream, UploadTransactionalHashingOptions, StorageTransferOptions, Task> parallelUploadAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            StorageTransferOptions transferOptions = default;

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await parallelUploadAsync(client, stream, hashingOptions, transferOptions);
            }
        }

        public static async Task TestParallelUploadUsePrecalculatedHashOnOneshotAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, StorageTransferOptions, Task> parallelUploadAsync) where TClientOptions : ClientOptions
        {
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            // hash needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedHash = TestHelper.GetRandomBuffer(16, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };
            // excessively large threshold before split
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = long.MaxValue,
                MaximumTransferSize = long.MaxValue
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, expectedHash: precalculatedHash));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            hashPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                AssertWriteHashMismatch(async () => await parallelUploadAsync(client, stream, hashingOptions, transferOptions), algorithm);
            }
        }

        public static async Task TestParallelUploadIgnorePrecalculatedOnSplitAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, StorageTransferOptions, Task> parallelUploadAsync,
            Func<Request, bool> isHashExpected) where TClientOptions : ClientOptions
        {
            const int blockSize = Constants.KB;
            var data = TestHelper.GetRandomBuffer(2 * blockSize, random);
            var transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = blockSize,
                MaximumTransferSize = blockSize
            };

            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(
                algorithm,
                // only check put block, not put block list
                isHashExpected: isHashExpected));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            // create bad hash to ignore
            var precalculatedHash = TestHelper.GetRandomBuffer(16, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            // Act / Assert
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await parallelUploadAsync(client, stream, hashingOptions, transferOptions);
            }
        }
        #endregion
    }
}
