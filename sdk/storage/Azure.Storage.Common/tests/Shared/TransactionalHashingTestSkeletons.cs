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
        #region Assertions
        /// <summary>
        /// Gets an assertion as to whether a transactional hash appeared on an outgoing request.
        /// Meant to be injected into a pipeline.
        /// </summary>
        /// <param name="algorithm">
        /// Hash algorithm to look for.
        /// </param>
        /// <param name="isHashExpected">
        /// Predicate to determine wheter a hash is expected on that particular request. E.g. on a block blob
        /// partitioned upload, stage block requests are expected to have a hash but commit block list is not.
        /// Defaults to all requests expected to have the hash.
        /// </param>
        /// <param name="expectedHash">
        /// The actual hash value expected to be on the request, if known. Defaults to no specific value expected or checked.
        /// </param>
        /// <returns>An assertion to put into a pipeline policy.</returns>
        internal static Action<Request> GetRequestHashAssertion(TransactionalHashAlgorithm algorithm, Func<Request, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            // action to assert a request header is as expected
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
                // filter some requests out with predicate
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
        /// Gets an assertion as to whether a transactional hash appeared on a returned response.
        /// Meant to be injected into a pipeline.
        /// </summary>
        /// <param name="algorithm">
        /// Hash algorithm to look for.
        /// </param>
        /// <param name="isHashExpected">
        /// Predicate to determine wheter a hash is expected on that particular response. E.g. on OpenRead,
        /// the initial GetProperties is not expected to have a hash, but download responses are.
        /// Defaults to all requests expected to have the hash.
        /// </param>
        /// <param name="expectedHash">
        /// The actual hash value expected to be on the response, if known. Defaults to no specific value expected or checked.
        /// </param>
        /// <returns>An assertion to put into a pipeline policy.</returns>
        internal static Action<Response> GetResponseHashAssertion(TransactionalHashAlgorithm algorithm, Func<Response, bool> isHashExpected = default, byte[] expectedHash = default)
        {
            // action to assert a response header is as expected
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
                // filter some requests out with predicate
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
        /// Asserts the service returned an error that expected hash did not match hash on upload.
        /// </summary>
        /// <param name="writeAction">Async action to upload data to service.</param>
        /// <param name="algorithm">Hash algorithm used.</param>
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
        #endregion

        #region UploadPartition Tests
        /// <summary>
        /// Tests if a oneshot uplaod method successfully computes transactional hash.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="uploadPartitionAsync">Operation to perform the oneshot upload with given client and data.</param>
        public static async Task TestUploadPartitionSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await uploadPartitionAsync(client, stream, hashingOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the hash was correct
        }

        /// <summary>
        /// Tests if a oneshot uplaod method uses a precalculated hash when provided
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="uploadPartitionAsync">Operation to perform the oneshot upload with given client and data.</param>
        public static async Task TestUploadPartitionUsePrecalculatedHashAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            // service throws different error for crc only when hash size in incorrect; we don't want to test that
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

            // make pipeline assertion for checking precalculated hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, expectedHash: precalculatedHash));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            hashPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                // Act
                AsyncTestDelegate operation = async () => await uploadPartitionAsync(client, stream, hashingOptions);

                // Assert
                AssertWriteHashMismatch(operation, algorithm);
            }
        }

        /// <summary>
        /// Tests if a oneshot uplaod method throws when a hash mismatch takes place.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="uploadPartitionAsync">Operation to perform the oneshot upload with given client and data.</param>
        public static async Task TestUploadPartitionMismatchedHashThrowsAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, Task> uploadPartitionAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(2 * Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var streamTamperPolicy = new TamperStreamContentsPolicy();
            var clientOptions = getOptions();
            clientOptions.AddPolicy(streamTamperPolicy, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            using (var stream = new MemoryStream(data))
            {
                // Act
                streamTamperPolicy.TransformRequestBody = true;
                AsyncTestDelegate operation = async () => await uploadPartitionAsync(client, stream, hashingOptions);

                // Assert
                AssertWriteHashMismatch(operation, algorithm);
            }
        }
        #endregion

        #region OpenWrite Tests
        /// <summary>
        /// Tests if stream returned by OpenWrite successfully uploads with transactional hashing.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="openWriteAsync">Operation to open a write stream to the resource.</param>
        // TODO make sync and async
        public static async Task TestOpenWriteSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            byte[] writeBuffer,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, UploadTransactionalHashingOptions, Task<Stream>> openWriteAsync) where TClientOptions : ClientOptions
        {
            // Arrange
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            var writeStream = await openWriteAsync(client, hashingOptions);

            // Assert
            hashPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, 10))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(writeBuffer, 0, writeBuffer.Length);
            }
        }

        /// <summary>
        /// Tests if stream returned by OpenWrite throws when uploading a mismatched hash.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="openWriteAsync">Operation to open a write stream to the resource.</param>
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

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var clientOptions = getOptions();
            var tamperPolicy = new TamperStreamContentsPolicy();
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            var writeStream = await openWriteAsync(client, hashingOptions);

            // Assert
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
        /// <summary>
        /// Tests if a parallel upload successfully computes transactional hashes.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="parallelUploadAsync">Operation to parallel upload the resource.</param>
        /// <param name="isHashExpected">Service-specific predicate to determine if that particular REST request is expected to have a hash on it.</param>
        public static async Task TestParallelUploadSuccessfulHashComputationAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, Stream, UploadTransactionalHashingOptions, StorageTransferOptions, Task> parallelUploadAsync,
            Func<Request, bool> isHashExpected = default) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            StorageTransferOptions transferOptions = default;

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, isHashExpected));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await parallelUploadAsync(client, stream, hashingOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the hash was correct
        }

        /// <summary>
        /// Validate an upload operation does not accept precalculated hashes.
        /// </summary>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="uploadAsync">Upload operation that does not accept a precalculated hash.</param>
        public static void TestPrecalculatedHashNotAccepted(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<Stream, UploadTransactionalHashingOptions, Task> uploadAsync)
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = TestHelper.GetRandomBuffer(16, random)
            };

            // Act
            var exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await uploadAsync(new MemoryStream(data), hashingOptions));

            // Assert
            Assert.AreEqual("Precalculated hash not supported when potentially partitioning an upload.", exception.Message);
        }
        #endregion

        #region Parallel Download Tests
        /// <summary>
        /// Tests if a parallel download successfully validates transactional hashes.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="chunkSize">Size to partition parallel download into.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="setupDataAsync">Sets up resource to be downloaded.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="parallelDownloadAsync">Operation to parallel download the resource.</param>
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
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            await setupDataAsync(data);

            // make pipeline assertion for checking hash was present on download
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = getOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await getObjectClientAsync(parentClient, clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            hashPipelineAssertion.CheckResponse = true;
            await parallelDownloadAsync(client, hashingOptions);

            // Assert
            // Assertion was in the pipeline and the SDK not throwing means the hash was validated
        }
        #endregion

        #region OpenRead Tests
        /// <summary>
        /// Tests if a download stream opened to the resource successfully validates hashes.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="setupDataAsync">Sets up resource to be downloaded.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="openReadAsync">Operation to open a read stream the resource.</param>
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

            // make pipeline assertion for checking hash was present on download
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
        /// <summary>
        /// Tests if a oneshot download succeeds with transactional hashing.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="setupDataAsync">Sets up resource to be downloaded.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="downloadAsync">Operation to oneshot download a resource.</param>
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
            // no policies this time; just check response headers
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

        /// <summary>
        /// Tests if a oneshot download handles a bad hash appropriately.
        /// </summary>
        /// <typeparam name="TClient">Client to upload with.</typeparam>
        /// <typeparam name="TParentClient">"Parent" client that can spawn the TClient.</typeparam>
        /// <typeparam name="TClientOptions">ClientOptions child type to build clients with.</typeparam>
        /// <param name="random">Recordable Random instance that would normally be a property on the test class.</param>
        /// <param name="algorithm">Hash algorithm to test with.</param>
        /// <param name="getOptions">GetOptions() method that would normally be accessible on the test class.</param>
        /// <param name="parentClient">Parent client generated by the test.</param>
        /// <param name="setupDataAsync">Sets up resource to be downloaded.</param>
        /// <param name="getObjectClientAsync">Operation to get a client with the given client options, creating the resource if necessary.</param>
        /// <param name="downloadAsync">Operation to oneshot download a resource.</param>
        /// <param name="validate">Whether to defer validation.</param>
        public static async Task TestDownloadHashMismatchThrowsAsync<TClient, TParentClient, TClientOptions>(
            TestRandom random,
            TransactionalHashAlgorithm algorithm,
            Func<TClientOptions> getOptions,
            TParentClient parentClient,
            Func<byte[], Task> setupDataAsync,
            Func<TParentClient, TClientOptions, Task<TClient>> getObjectClientAsync,
            Func<TClient, DownloadTransactionalHashingOptions, HttpRange, Task<Response>> downloadAsync,
            bool validate) where TClientOptions : ClientOptions
        {
            // Arrange
            var data = TestHelper.GetRandomBuffer(Constants.KB, random);
            await setupDataAsync(data);

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm, Validate = validate };

            // alter response contents in pipeline, forcing a hash mismatch on verification step
            var clientOptions = getOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy() { TransformResponseBody = true }, HttpPipelinePosition.PerCall);
            var client = await getObjectClientAsync(parentClient, clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await downloadAsync(client, hashingOptions, new HttpRange(length: data.Length));

            // Assert
            if (validate)
            {
                // SDK responsible for finding bad hash. Throw.
                Assert.ThrowsAsync<InvalidDataException>(operation);
            }
            else
            {
                // bad hash is for caller to find. Don't throw.
                Assert.DoesNotThrowAsync(operation);
            }
        }
        #endregion
    }
}
