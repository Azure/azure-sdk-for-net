// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        public TransactionalHashingTestBase(
            bool async,
            string generatedResourceNamePrefix = default,
            RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _generatedResourceNamePrefix = generatedResourceNamePrefix ?? "test-resource-";
        }

        #region Service-Specific Methods
        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            TServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets a new service-specific resource client from a given container, e.g. a BlobClient from a
        /// BlobContainerClient or a DataLakeFileClient from a DataLakeFileSystemClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="resourceLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="resourceName">Optional name for the resource.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        protected abstract Task<TResourceClient> GetResourceClientAsync(
            TContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = default,
            TClientOptions options = default);

        /// <summary>
        /// Calls the 1:1 upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="hashingOptions">Transactional hashing options to use on upload.</param>
        protected abstract Task<Response> UploadPartitionAsync(
            TResourceClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions);

        /// <summary>
        /// Calls the 1:1 download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call the download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="hashingOptions">Transactional hashing options to use on download.</param>
        /// <param name="range">Range parameter for download, necessary for transactional hash request to be accepted by service.</param>
        protected abstract Task<Response> DownloadPartitionAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransactionalHashingOptions hashingOptions,
            HttpRange range = default);

        /// <summary>
        /// Calls the parallel upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="hashingOptions">Transactional hashing options to use on upload.</param>
        /// <param name="transferOptions">Storage transfer options to use on upload.</param>
        protected abstract Task ParallelUploadAsync(
            TResourceClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the parallel download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="hashingOptions">Transactional hashing options to use on download.</param>
        /// <param name="transferOptions">Storage transfer options to use on download.</param>
        protected abstract Task ParallelDownloadAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the open write method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open write on.</param>
        /// <param name="hashingOptions">Transactinal hashing options to use in the write stream.</param>
        /// <param name="internalBufferSize">Buffer size for the write stream.</param>
        protected abstract Task<Stream> OpenWriteAsync(
            TResourceClient client,
            UploadTransactionalHashingOptions hashingOptions,
            int internalBufferSize);

        /// <summary>
        /// Calls the open read method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open read on.</param>
        /// <param name="hashingOptions">Transactinal hashing options to use in the read stream.</param>
        /// <param name="internalBufferSize">Buffer size for the read stream.</param>
        protected abstract Task<Stream> OpenReadAsync(
            TResourceClient client,
            DownloadTransactionalHashingOptions hashingOptions,
            int internalBufferSize);

        /// <summary>
        /// Sets up data for a test.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="data"></param>
        /// <remarks>
        /// Not every client has every upload implemented and we dont' directly expose commit for these tests.
        /// We need a guaranteed way to setup data for download-based tests. This is a space for clients to
        /// select how they prepare data in a container for a download test.
        /// </remarks>
        protected abstract Task SetupDataAsync(TResourceClient client, Stream data);
        #endregion

        #region Service-Specific Predicates
        /// <summary>
        /// Service-specific check on the given request to determine if this is a request to perform
        /// a hash assertion on in a parallel upload.
        /// </summary>
        /// <remarks>
        /// Not every request sent in a parallel upload has a hash on it. To correctly test whether hashes
        /// are going out on requests as expected, we need to determine which requests are expected to have
        /// hashes on them in the first place. E.g. BlobClient sends out PutBlock calls which DO have a hash
        /// and a PutBlockList call which does NOT have a hash on it.
        /// </remarks>
        protected abstract bool ParallelUploadIsHashExpected(Request request);
        #endregion

        protected string GetNewResourceName()
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
            var exception = ThrowsOrInconclusiveAsync<RequestFailedException>(writeAction);
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
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

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
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
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

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

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
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var streamTamperPolicy = new TamperStreamContentsPolicy();
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(streamTamperPolicy, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

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
            const int streamBufferSize = Constants.KB; // this one needs to be 512 multiple for page blobs
            const int dataSize = Constants.KB - 11; // odd number to get some variance
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                // should use dataSize instead of streamBufferSize but this gives 512 multiple and ends up irrelevant for this test
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, hashingOptions, streamBufferSize);

            // Assert
            hashPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, streamWrites))
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
            const int streamBufferSize = Constants.KB; // this one needs to be 512 multiple for page blobs
            const int dataSize = Constants.KB - 11; // odd number to get some variance
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var clientOptions = ClientBuilder.GetOptions();
            var tamperPolicy = new TamperStreamContentsPolicy();
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                // should use dataSize instead of streamBufferSize but this gives 512 multiple and ends up irrelevant for this test
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, hashingOptions, streamBufferSize);

            // Assert
            AssertWriteHashMismatch(async () =>
            {
                tamperPolicy.TransformRequestBody = true;
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }, algorithm);
        }
        #endregion

        #region Parallel Upload Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task ParallelUploadSplitSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            // force split
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = 512,
                MaximumTransferSize = 512
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestHashAssertion(algorithm, isHashExpected: ParallelUploadIsHashExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

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
        public virtual async Task ParallelUploadOneShotSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };
            // force oneshot
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = Constants.MB,
                MaximumTransferSize = Constants.MB
            };

            // make pipeline assertion for checking hash was present on upload
            var hashPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestHashAssertion(algorithm, isHashExpected: ParallelUploadIsHashExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

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
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm,
                PrecalculatedHash = GetRandomBuffer(16)
            };

            var client = await GetResourceClientAsync(disposingContainer.Container, dataLength);

            // Act
            var exception = ThrowsOrInconclusiveAsync<ArgumentException>(
                async () => await ParallelUploadAsync(client, new MemoryStream(data), hashingOptions, transferOptions: default));

            // Assert
            Assert.AreEqual("Precalculated hash not supported when potentially partitioning an upload.", exception.Message);
        }
        #endregion

        #region Parallel Download Tests
        [Test, Combinatorial]
        public virtual async Task ParallelDownloadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(512, 2 * Constants.KB)] int chunkSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = 2 * Constants.KB;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            // make pipeline assertion for checking hash was present on download
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = chunkSize,
                MaximumTransferSize = chunkSize
            };

            // Act
            hashPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, hashingOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the SDK not throwing means the hash was validated
        }
        #endregion

        #region OpenRead Tests
        [Test, Combinatorial]
        public virtual async Task OpenReadSuccessfulHashVerification(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(
                // multiple reads that neatly align
                Constants.KB,
                // multiple reads with final having leftover buffer space
                2 * Constants.KB,
                // buffer larger than data
                4 * Constants.KB)] int bufferSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            // bufferSize/datasize MUST be a multiple of 512 for pageblob tests
            const int dataLength = 3 * Constants.KB;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            // make pipeline assertion for checking hash was present on download
            var hashPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseHashAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(hashPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);
            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var readStream = await OpenReadAsync(client, hashingOptions, bufferSize);

            // Assert
            hashPipelineAssertion.CheckResponse = true;
            await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
        #endregion

        #region Download Streaming/Content Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public virtual async Task DownloadSuccessfulHashVerification(TransactionalHashAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm };

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, hashingOptions, new HttpRange(length: data.Length));

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

        [Test, Combinatorial]
        public virtual async Task DownloadHashMismatchThrows(
            [Values(TransactionalHashAlgorithm.MD5, TransactionalHashAlgorithm.StorageCrc64)] TransactionalHashAlgorithm algorithm,
            [Values(true, false)] bool validate)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            var hashingOptions = new DownloadTransactionalHashingOptions { Algorithm = algorithm, Validate = validate };

            // alter response contents in pipeline, forcing a hash mismatch on verification step
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy() { TransformResponseBody = true }, HttpPipelinePosition.PerCall);
            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await DownloadPartitionAsync(client, Stream.Null, hashingOptions, new HttpRange(length: data.Length));

            // Assert
            if (validate)
            {
                // SDK responsible for finding bad hash. Throw.
                ThrowsOrInconclusiveAsync<InvalidDataException>(operation);
            }
            else
            {
                // bad hash is for caller to find. Don't throw.
                await DoesNotThrowOrInconclusiveAsync(operation);
            }
        }
        #endregion

        /// <summary>
        /// Replicates <c>ThrowsOrInconclusiveAsync&lt;<typeparamref name="TException"/>&gt;</c> while allowing
        /// NUnit <see cref="ResultStateException"/>s to bubble up to the test framework.
        /// </summary>
        /// <typeparam name="TException">Expected exception type.</typeparam>
        private static TException ThrowsOrInconclusiveAsync<TException>(AsyncTestDelegate code)
            where TException : Exception
        {
            var exception = Assert.ThrowsAsync(Is.InstanceOf<TException>().Or.InstanceOf<ResultStateException>(), code);

            // let nunit results bubble up
            if (exception is ResultStateException)
            {
                throw exception;
            }

            return exception as TException;
        }

        /// <summary>
        /// Replicates <c>DoesNotThrowOrInconclusiveAsync</c> while allowing
        /// NUnit <see cref="ResultStateException"/>s to bubble up to the test framework.
        /// </summary>
        private static async Task DoesNotThrowOrInconclusiveAsync(AsyncTestDelegate code)
        {
            try
            {
                await code.Invoke();
            }
            catch (Exception e) when (e is not ResultStateException)
            {
                Assert.Fail($"Expected: No Exception to be thrown\nBut was: {e}");
            }
        }
    }
}
