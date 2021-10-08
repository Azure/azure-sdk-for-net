// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// We're going to make our tests retry a few additional error types that
    /// may be more wasteful, but are less likely to cause test failures.
    /// </summary>
    public abstract class TransactionalHashingTestBase<TServiceClient, TContainerClient, TResourceClient, TClientOptions, TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TResourceClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private readonly string _generatedResourceNamePrefix;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; }

        public TransactionalHashingTestBase(
            bool async,
            ClientBuilder<TServiceClient, TClientOptions> clientBuilder,
            string generatedResourceNamePrefix = default,
            RecordedTestMode? mode = null)
            : base(async, mode)
        {
            ClientBuilder = clientBuilder;
            _generatedResourceNamePrefix = generatedResourceNamePrefix ?? "test-resource-";
        }

        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            TServiceClient service = default,
            string containerName = default);

        protected abstract Task<TResourceClient> GetResourceClientAsync(TContainerClient container, string resourceName = default, TClientOptions options = default);

        protected abstract Task<Response> UploadPartitionAsync(TResourceClient client, Stream source, UploadTransactionalHashingOptions hashingOptions);

        protected abstract Task<Response> DownloadPartitionAsync(TResourceClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, HttpRange range = default);

        protected abstract Task ParallelUploadAsync(TResourceClient client, Stream source, UploadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions);

        protected abstract Task ParallelDownloadAsync(TResourceClient client, Stream destination, DownloadTransactionalHashingOptions hashingOptions, StorageTransferOptions transferOptions);

        protected abstract Task<Stream> OpenWriteAsync(TResourceClient client, UploadTransactionalHashingOptions hashingOptions, int internalBufferSize);

        protected abstract Task<Stream> OpenReadAsync(TResourceClient client, DownloadTransactionalHashingOptions hashingOptions, int internalBufferSize);

        private string GetNewResourceName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

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
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task UploadPartitionSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await UploadPartitionAsync(client, stream, hashingOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the hash was correct
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task UploadPartitionUsePrecalculatedHash(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            // service throws different error for crc only when hash size in incorrect; we don't want to test that
            var hashSizeBytes = algorithm switch
            {
                TransactionalHashAlgorithm.MD5 => 16,
                TransactionalHashAlgorithm.StorageCrc64 => 8,
                _ => throw new ArgumentException("Cannot determine hash size for provided algorithm type")
            };
            // hash needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedHash = GetRandomBuffer(hashSizeBytes);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = precalculatedHash
            };

            // make pipeline assertion for checking precalculated hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, expectedHash: precalculatedHash));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            hashPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                // Act
                AsyncTestDelegate operation = async () => await UploadPartitionAsync(client, stream, hashingOptions);

                // Assert
                AssertWriteHashMismatch(operation, algorithm);
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task UploadPartitionMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var streamTamperPolicy = new TamperStreamContentsPolicy();
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(streamTamperPolicy, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            using (var stream = new MemoryStream(data))
            {
                // Act
                streamTamperPolicy.TransformRequestBody = true;
                AsyncTestDelegate operation = async () => await UploadPartitionAsync(client, stream, hashingOptions);

                // Assert
                AssertWriteHashMismatch(operation, algorithm);
            }
        }
        #endregion

        #region OpenWrite Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task OpenWriteSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamBufferSize = Constants.KB;
            const int writeBufferSize = Constants.KB - 11; // odd number to get some variance

            var data = GetRandomBuffer(writeBufferSize);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, hashingOptions, streamBufferSize);

            // Assert
            hashPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, 10))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(data, 0, data.Length);
            }
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task OpenWriteMismatchedHashThrows(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamBufferSize = Constants.KB;
            const int writeBufferSize = Constants.KB - 11; // odd number to get some variance

            var data = GetRandomBuffer(writeBufferSize);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var clientOptions = ClientBuilder.GetOptions();
            var tamperPolicy = new TamperStreamContentsPolicy();
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, hashingOptions, streamBufferSize);

            // Assert
            AssertWriteHashMismatch(async () =>
            {
                tamperPolicy.TransformRequestBody = true;
                foreach (var _ in Enumerable.Range(0, 10))
                {
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }, algorithm);
        }
        #endregion

        #region Parallel Upload Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task ParallelUploadSuccessfulHashComputation(TransactionalHashAlgorithm algorithm, Func<Request, bool> isHashExpected = default)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            StorageTransferOptions transferOptions = default;

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm, isHashExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                hashPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, hashingOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the hash was correct
        }

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task PrecalculatedHashNotAccepted(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = GetRandomBuffer(16)
            };

            var client = await GetResourceClientAsync(disposingContainer.Container);

            // Act
            var exception = Assert.ThrowsAsync<ArgumentException>(
                async () => await ParallelUploadAsync(client, new MemoryStream(data), hashingOptions, transferOptions: default));

            // Assert
            Assert.AreEqual("Precalculated hash not supported when potentially partitioning an upload.", exception.Message);
        }
        #endregion

        #region Parallel Download Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task ParallelDownloadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm, int chunkSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName);
            await ParallelUploadAsync(client, new MemoryStream(data), default, default);

            // make pipeline assertion for checking hash was present on download
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName, options: clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };
            StorageTransferOptions transferOptions = default;

            // Act
            hashPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, hashingOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the SDK not throwing means the hash was validated
        }
        #endregion

        #region OpenRead Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task OpenReadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm, int bufferSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName);
            await ParallelUploadAsync(client, new MemoryStream(data), default, default);

            // make pipeline assertion for checking hash was present on download
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName, options: clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await OpenReadAsync(client, hashingOptions, bufferSize);

            // Assert
            hashPipelineAssertion.CheckResponse = true;
            Assert.DoesNotThrowAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
        #endregion

        #region Download Streaming/Content Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task DownloadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName);
            await ParallelUploadAsync(client, new MemoryStream(data), default, default);

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, hashingOptions);

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

        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task DownloadHashMismatchThrows(
            TransactionalHashAlgorithm algorithm,
            bool validate)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName);
            await ParallelUploadAsync(client, new MemoryStream(data), default, default);

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm, Validate = validate };

            // alter response contents in pipeline, forcing a hash mismatch on verification step
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy() { TransformResponseBody = true }, HttpPipelinePosition.PerCall);
            client = await GetResourceClientAsync(disposingContainer.Container, resourceName: resourceName, options: clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await DownloadPartitionAsync(client, Stream.Null, hashingOptions, new HttpRange(length: data.Length));

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
