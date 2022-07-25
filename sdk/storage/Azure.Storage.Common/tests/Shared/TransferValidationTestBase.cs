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
    public abstract class TransferValidationTestBase<TServiceClient, TContainerClient, TResourceClient, TClientOptions, TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TResourceClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private readonly string _generatedResourceNamePrefix;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        public TransferValidationTestBase(
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
        /// <param name="clientUploadTransferOptions">Default upload transfer validation options to set on the client.</param>
        /// <param name="clientDownloadTransferOptions">Default download transfer validation options to set on the client.</param>
        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            TServiceClient service = default,
            string containerName = default,
            UploadTransferValidationOptions uploadTransferValidationOptions = default,
            DownloadTransferValidationOptions downloadTransferValidationOptions = default);

        /// <summary>
        /// Gets a new service-specific resource client from a given container, e.g. a BlobClient from a
        /// BlobContainerClient or a DataLakeFileClient from a DataLakeFileSystemClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="resourceLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="resourceName">Optional name for the resource.</param>
        /// <param name="uploadTransferValidationOptions">Default upload transfer validation options to set on the client.</param>
        /// <param name="downloadTransferValidationOptions">Default download transfer validation options to set on the client.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        protected abstract Task<TResourceClient> GetResourceClientAsync(
            TContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = default,
            UploadTransferValidationOptions uploadTransferValidationOptions = default,
            DownloadTransferValidationOptions downloadTransferValidationOptions = default,
            TClientOptions options = default);

        /// <summary>
        /// Calls the 1:1 upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="validationOptions">Validation options to use on upload.</param>
        protected abstract Task<Response> UploadPartitionAsync(
            TResourceClient client,
            Stream source,
            UploadTransferValidationOptions validationOptions);

        /// <summary>
        /// Calls the 1:1 download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call the download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="validationOptions">Validation options to use on download.</param>
        /// <param name="range">Range parameter for download, necessary for transactional checksum request to be accepted by service.</param>
        protected abstract Task<Response> DownloadPartitionAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransferValidationOptions validationOptions,
            HttpRange range = default);

        /// <summary>
        /// Calls the parallel upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="validationOptions">Validation options to use on upload.</param>
        /// <param name="transferOptions">Storage transfer options to use on upload.</param>
        protected abstract Task ParallelUploadAsync(
            TResourceClient client,
            Stream source,
            UploadTransferValidationOptions validationOptions,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the parallel download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="validationOptions">Validation options to use on download.</param>
        /// <param name="transferOptions">Storage transfer options to use on download.</param>
        protected abstract Task ParallelDownloadAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransferValidationOptions validationOptions,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the open write method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open write on.</param>
        /// <param name="validationOptions">Validation options to use in the write stream.</param>
        /// <param name="internalBufferSize">Buffer size for the write stream.</param>
        protected abstract Task<Stream> OpenWriteAsync(
            TResourceClient client,
            UploadTransferValidationOptions validationOptions,
            int internalBufferSize);

        /// <summary>
        /// Calls the open read method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open read on.</param>
        /// <param name="validationOptions">Validation options to use in the read stream.</param>
        /// <param name="internalBufferSize">Buffer size for the read stream.</param>
        protected abstract Task<Stream> OpenReadAsync(
            TResourceClient client,
            DownloadTransferValidationOptions validationOptions,
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
        /// a checksum assertion on in a parallel upload.
        /// </summary>
        /// <remarks>
        /// Not every request sent in a parallel upload has a checksum on it. To correctly test whether checksums
        /// are going out on requests as expected, we need to determine which requests are expected to have
        /// checksums on them in the first place. E.g. BlobClient sends out PutBlock calls which DO have a checksum
        /// and a PutBlockList call which does NOT have a checksum on it.
        /// </remarks>
        protected abstract bool ParallelUploadIsChecksumExpected(Request request);
        #endregion

        protected string GetNewResourceName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

        #region Assertions
        /// <summary>
        /// Gets an assertion as to whether a checksum appeared on an outgoing request.
        /// Meant to be injected into a pipeline.
        /// </summary>
        /// <param name="algorithm">
        /// Algorithm to search by.
        /// </param>
        /// <param name="isChecksumExpected">
        /// Predicate to determine wheter a checksum is expected on that particular request. E.g. on a block blob
        /// partitioned upload, stage block requests are expected to have a checksum but commit block list is not.
        /// Defaults to all requests expected to have a checksum.
        /// </param>
        /// <param name="expectedChecksum">
        /// The actual checksum value expected to be on the request, if known. Defaults to no specific value expected or checked.
        /// </param>
        /// <returns>An assertion to put into a pipeline policy.</returns>
        internal static Action<Request> GetRequestChecksumAssertion(ValidationAlgorithm algorithm, Func<Request, bool> isChecksumExpected = default, byte[] expectedChecksum = default)
        {
            // action to assert a request header is as expected
            void AssertChecksum(RequestHeaders headers, string headerName)
            {
                if (headers.TryGetValue(headerName, out string checksum))
                {
                    if (expectedChecksum != default)
                    {
                        Assert.AreEqual(Convert.ToBase64String(expectedChecksum), checksum);
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
                if (isChecksumExpected != default && !isChecksumExpected(request))
                {
                    return;
                }

                switch (algorithm.ResolveAuto())
                {
                    case ValidationAlgorithm.MD5:
                        AssertChecksum(request.Headers, "Content-MD5");
                        break;
                    case ValidationAlgorithm.StorageCrc64:
                        AssertChecksum(request.Headers, "x-ms-content-crc64");
                        break;
                    default:
                        throw new Exception($"Bad {nameof(ValidationAlgorithm)} provided to {nameof(GetRequestChecksumAssertion)}.");
                }
            };
        }

        /// <summary>
        /// Gets an assertion as to whether a transactional checksum appeared on a returned response.
        /// Meant to be injected into a pipeline.
        /// </summary>
        /// <param name="algorithm">
        /// Algorithm to search by.
        /// </param>
        /// <param name="isChecksumExpected">
        /// Predicate to determine wheter a checksum is expected on that particular response. E.g. on OpenRead,
        /// the initial GetProperties is not expected to have a checksum, but download responses are.
        /// Defaults to all requests expected to have the checksum.
        /// </param>
        /// <param name="expectedChecksum">
        /// The actual checksum value expected to be on the response, if known. Defaults to no specific value expected or checked.
        /// </param>
        /// <returns>An assertion to put into a pipeline policy.</returns>
        internal static Action<Response> GetResponseChecksumAssertion(ValidationAlgorithm algorithm, Func<Response, bool> isChecksumExpected = default, byte[] expectedChecksum = default)
        {
            // action to assert a response header is as expected
            void AssertChecksum(ResponseHeaders headers, string headerName)
            {
                if (headers.TryGetValue(headerName, out string checksum))
                {
                    if (expectedChecksum != default)
                    {
                        Assert.AreEqual(Convert.ToBase64String(expectedChecksum), checksum);
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
                if (isChecksumExpected != default && !isChecksumExpected(response))
                {
                    return;
                }

                switch (algorithm.ResolveAuto())
                {
                    case ValidationAlgorithm.MD5:
                        AssertChecksum(response.Headers, "Content-MD5");
                        break;
                    case ValidationAlgorithm.StorageCrc64:
                        AssertChecksum(response.Headers, "x-ms-content-crc64");
                        break;
                    default:
                        throw new Exception($"Bad {nameof(ValidationAlgorithm)} provided to {nameof(GetRequestChecksumAssertion)}.");
                }
            };
        }

        /// <summary>
        /// Asserts the service returned an error that expected checksum did not match checksum on upload.
        /// </summary>
        /// <param name="writeAction">Async action to upload data to service.</param>
        /// <param name="algorithm">Checksum algorithm used.</param>
        internal static void AssertWriteChecksumMismatch(AsyncTestDelegate writeAction, ValidationAlgorithm algorithm)
        {
            var exception = ThrowsOrInconclusiveAsync<RequestFailedException>(writeAction);
            switch (algorithm.ResolveAuto())
            {
                case ValidationAlgorithm.MD5:
                    Assert.AreEqual("Md5Mismatch", exception.ErrorCode);
                    break;
                case ValidationAlgorithm.StorageCrc64:
                    Assert.AreEqual("Crc64Mismatch", exception.ErrorCode);
                    break;
                default:
                    throw new ArgumentException("Test arguments contain bad algorithm specifier.");
            }
        }
        #endregion

        public static IEnumerable<ValidationAlgorithm> GetValidationAlgorithms()
        {
            var values = new HashSet<ValidationAlgorithm>(Enum.GetValues(typeof(ValidationAlgorithm)).Cast<ValidationAlgorithm>());
            values.Remove(ValidationAlgorithm.None);
            return values;
        }

        public static IEnumerable<ValidationAlgorithm> GetValidationAlgorithmsIncludingNone()
        {
            var values = new HashSet<ValidationAlgorithm>(Enum.GetValues(typeof(ValidationAlgorithm)).Cast<ValidationAlgorithm>());
            return values;
        }

        #region UploadPartition Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task UploadPartitionSuccessfulHashComputation(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await UploadPartitionAsync(client, stream, validationOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task UploadPartitionUsePrecalculatedHash(ValidationAlgorithm algorithm)
        {
            if (algorithm == ValidationAlgorithm.Auto)
            {
                Assert.Inconclusive();
            }

            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            // service throws different error for crc only when checksum size in incorrect; we don't want to test that
            var checksumSizeBytes = algorithm.ResolveAuto() switch
            {
                ValidationAlgorithm.MD5 => 16,
                ValidationAlgorithm.StorageCrc64 => 8,
                _ => throw new ArgumentException("Cannot determine hash size for provided algorithm type")
            };
            // checksum needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedChecksum = GetRandomBuffer(checksumSizeBytes);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm,
                PrecalculatedChecksum = precalculatedChecksum
            };

            // make pipeline assertion for checking precalculated checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm, expectedChecksum: precalculatedChecksum));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

            checksumPipelineAssertion.CheckRequest = true;
            using (var stream = new MemoryStream(data))
            {
                // Act
                AsyncTestDelegate operation = async () => await UploadPartitionAsync(client, stream, validationOptions);

                // Assert
                AssertWriteChecksumMismatch(operation, algorithm);
            }
        }

        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task UploadPartitionMismatchedHashThrows(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
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
                AsyncTestDelegate operation = async () => await UploadPartitionAsync(client, stream, validationOptions);

                // Assert
                AssertWriteChecksumMismatch(operation, algorithm);
            }
        }

        [Test]
        public virtual async Task UploadPartitionUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await UploadPartitionAsync(client, stream, validationOptions: null);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [Combinatorial]
        public virtual async Task UploadPartitionOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await UploadPartitionAsync(client, stream, overrideValidationOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        public virtual async Task UploadPartitionDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await UploadPartitionAsync(client, stream, overrideValidationOptions);
            }

            // Assert
            // Assertion was in the pipeline
        }
        #endregion

        #region OpenWrite Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task OpenWriteSuccessfulHashComputation(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamBufferSize = Constants.KB; // this one needs to be 512 multiple for page blobs
            const int dataSize = Constants.KB - 11; // odd number to get some variance
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                // should use dataSize instead of streamBufferSize but this gives 512 multiple and ends up irrelevant for this test
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, validationOptions, streamBufferSize);

            // Assert
            checksumPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, streamWrites))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(data, 0, data.Length);
            }
        }

        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task OpenWriteMismatchedHashThrows(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamBufferSize = Constants.KB; // this one needs to be 512 multiple for page blobs
            const int dataSize = Constants.KB - 11; // odd number to get some variance
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var validationOptions = new UploadTransferValidationOptions
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
            var writeStream = await OpenWriteAsync(client, validationOptions, streamBufferSize);

            // Assert
            AssertWriteChecksumMismatch(async () =>
            {
                tamperPolicy.TransformRequestBody = true;
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }, algorithm);
        }

        [Test]
        public virtual async Task OpenWriteUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, default, streamBufferSize);

            // Assert
            checksumPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, streamWrites))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(data, 0, data.Length);
            }
        }

        [Test]
        [Combinatorial]
        public virtual async Task OpenWriteOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, overrideValidationOptions, streamBufferSize);

            // Assert
            checksumPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, streamWrites))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(data, 0, data.Length);
            }
        }

        [Test]
        public virtual async Task OpenWriteDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var writeStream = await OpenWriteAsync(client, overrideValidationOptions, streamBufferSize);

            // Assert
            checksumPipelineAssertion.CheckRequest = true;
            foreach (var _ in Enumerable.Range(0, streamWrites))
            {
                // triggers pipeline assertion
                await writeStream.WriteAsync(data, 0, data.Length);
            }
        }
        #endregion

        #region Parallel Upload Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task ParallelUploadSplitSuccessfulHashComputation(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm
            };
            // force split
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = 512,
                MaximumTransferSize = 512
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestChecksumAssertion(algorithm, isChecksumExpected: ParallelUploadIsChecksumExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, validationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task ParallelUploadOneShotSuccessfulHashComputation(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm
            };
            // force oneshot
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = Constants.MB,
                MaximumTransferSize = Constants.MB
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestChecksumAssertion(algorithm, isChecksumExpected: ParallelUploadIsChecksumExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, validationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task PrecalculatedHashNotAccepted(ValidationAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                Algorithm = algorithm,
                PrecalculatedChecksum = GetRandomBuffer(16)
            };

            var client = await GetResourceClientAsync(disposingContainer.Container, dataLength);

            // Act
            var exception = ThrowsOrInconclusiveAsync<ArgumentException>(
                async () => await ParallelUploadAsync(client, new MemoryStream(data), validationOptions, transferOptions: default));

            // Assert
            Assert.AreEqual("Precalculated checksum not supported when potentially partitioning an upload.", exception.Message);
        }

        [Test]
        public virtual async Task ParallelUploadUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            StorageTransferOptions transferOptions = split
                ? new StorageTransferOptions
                {
                    InitialTransferSize = dataLength/2,
                    MaximumTransferSize = dataLength/2
                }
                : new StorageTransferOptions
                {
                    InitialTransferSize = dataLength * 2,
                    MaximumTransferSize = dataLength * 2
                };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(
                clientAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, default, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [Combinatorial]
        public virtual async Task ParallelUploadOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };
            StorageTransferOptions transferOptions = split
              ? new StorageTransferOptions
              {
                  InitialTransferSize = dataLength / 2,
                  MaximumTransferSize = dataLength / 2
              }
              : new StorageTransferOptions
              {
                  InitialTransferSize = dataLength * 2,
                  MaximumTransferSize = dataLength * 2
              };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumAssertion(
                overrideAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        public virtual async Task ParallelUploadDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var clientValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };
            StorageTransferOptions transferOptions = split
              ? new StorageTransferOptions
              {
                  InitialTransferSize = dataLength / 2,
                  MaximumTransferSize = dataLength / 2
              }
              : new StorageTransferOptions
              {
                  InitialTransferSize = dataLength * 2,
                  MaximumTransferSize = dataLength * 2
              };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }
        #endregion

        #region Parallel Download Tests
        [Test, Combinatorial]
        public virtual async Task ParallelDownloadSuccessfulHashVerification(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm algorithm,
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

            // make pipeline assertion for checking checksum was present on download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);
            var validationOptions = new DownloadTransferValidationOptions { Algorithm = algorithm };
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = chunkSize,
                MaximumTransferSize = chunkSize
            };

            // Act
            checksumPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, validationOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the SDK not throwing means the checksum was validated
        }

        [Test]
        public virtual async Task ParallelDownloadUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            StorageTransferOptions transferOptions = split
                ? new StorageTransferOptions
                {
                    InitialTransferSize = dataLength / 2,
                    MaximumTransferSize = dataLength / 2
                }
                : new StorageTransferOptions
                {
                    InitialTransferSize = dataLength,
                    MaximumTransferSize = dataLength
                };

            // make pipeline assertion for checking checksum was present on download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            checksumPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, default, transferOptions);

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [Combinatorial]
        public virtual async Task ParallelDownloadOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm,
            [Values(true, false)] bool split)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };
            StorageTransferOptions transferOptions = split
                ? new StorageTransferOptions
                {
                    InitialTransferSize = dataLength / 2,
                    MaximumTransferSize = dataLength / 2
                }
                : new StorageTransferOptions
                {
                    InitialTransferSize = dataLength,
                    MaximumTransferSize = dataLength
                };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            checksumPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, overrideValidationOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        public virtual async Task ParallelDownloadDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };
            StorageTransferOptions transferOptions = split
              ? new StorageTransferOptions
              {
                  InitialTransferSize = dataLength / 2,
                  MaximumTransferSize = dataLength / 2
              }
              : new StorageTransferOptions
              {
                  InitialTransferSize = dataLength,
                  MaximumTransferSize = dataLength
              };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: response =>
            {
                if (response.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (response.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            checksumPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, overrideValidationOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }
        #endregion

        #region OpenRead Tests
        [Test, Combinatorial]
        public virtual async Task OpenReadSuccessfulHashVerification(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm algorithm,
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

            // make pipeline assertion for checking checksum was present on download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);
            var validationOptions = new DownloadTransferValidationOptions { Algorithm = algorithm };

            // Act
            var readStream = await OpenReadAsync(client, validationOptions, bufferSize);

            // Assert
            checksumPipelineAssertion.CheckResponse = true;
            await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }

        [Test]
        public virtual async Task OpenReadUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int bufferSize = Constants.KB / 2;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };

            // make pipeline assertion for checking checksum was present on download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, default, bufferSize);

            // Assert
            checksumPipelineAssertion.CheckResponse = true;
            await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }

        [Test]
        [Combinatorial]
        public virtual async Task OpenReadOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int bufferSize = Constants.KB / 2;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, overrideValidationOptions, bufferSize);

            // Assert
            checksumPipelineAssertion.CheckResponse = true;
            await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }

        [Test]
        public virtual async Task OpenReadDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int bufferSize = Constants.KB / 2;
            var data = GetRandomBuffer(dataLength);

            var resourceName = GetNewResourceName();
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                resourceName: resourceName);
            await SetupDataAsync(client, new MemoryStream(data));

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: response =>
            {
                if (response.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (response.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, overrideValidationOptions, bufferSize);

            // Assert
            checksumPipelineAssertion.CheckResponse = true;
            await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(Stream.Null));
        }
        #endregion

        #region Download Streaming/Content Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public virtual async Task DownloadSuccessfulHashVerification(ValidationAlgorithm algorithm)
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

            var validationOptions = new DownloadTransferValidationOptions { Algorithm = algorithm };

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, validationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (algorithm.ResolveAuto())
            {
                case ValidationAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case ValidationAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }

        [Test, Combinatorial]
        public virtual async Task DownloadHashMismatchThrows(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm algorithm,
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

            var validationOptions = new DownloadTransferValidationOptions { Algorithm = algorithm, Validate = validate };

            // alter response contents in pipeline, forcing a checksum mismatch on verification step
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(new TamperStreamContentsPolicy() { TransformResponseBody = true }, HttpPipelinePosition.PerCall);
            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);

            // Act
            AsyncTestDelegate operation = async () => await DownloadPartitionAsync(client, Stream.Null, validationOptions, new HttpRange(length: data.Length));

            // Assert
            if (validate)
            {
                // SDK responsible for finding bad checksum. Throw.
                ThrowsOrInconclusiveAsync<InvalidDataException>(operation);
            }
            else
            {
                // bad checksum is for caller to find. Don't throw.
                await DoesNotThrowOrInconclusiveAsync(operation);
            }
        }

        [Test]
        public virtual async Task DownloadUsesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };

            // make pipeline assertion for checking checksum was present on download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, default, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (clientAlgorithm.ResolveAuto())
            {
                case ValidationAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case ValidationAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }

        [Test]
        [Combinatorial]
        public virtual async Task DownloadOverwritesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm,
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm overrideAlgorithm)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: GetResponseChecksumAssertion(
                overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, overrideValidationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (overrideAlgorithm.ResolveAuto())
            {
                case ValidationAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case ValidationAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains("x-ms-content-crc64"));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
        }

        [Test]
        public virtual async Task DownloadDisablesDefaultClientValidationOptions(
            [ValueSource("GetValidationAlgorithms")] ValidationAlgorithm clientAlgorithm)
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

            var clientValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = clientAlgorithm
            };
            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                Algorithm = ValidationAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: response =>
            {
                if (response.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (response.Headers.Contains("x-ms-content-crc64"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadTransferValidationOptions: clientValidationOptions,
                options: clientOptions);

            // Act
            var response = await DownloadPartitionAsync(client, Stream.Null, overrideValidationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            Assert.False(response.Headers.Contains("Content-MD5"));
            Assert.False(response.Headers.Contains("x-ms-content-crc64"));
        }
        #endregion

        #region Auto-Algorithm Tests
        [Test]
        public void TestDefaults()
        {
            var uploadOptions = new UploadTransferValidationOptions();
            Assert.AreEqual(ValidationAlgorithm.Auto, uploadOptions.Algorithm);
            Assert.IsNull(uploadOptions.PrecalculatedChecksum);

            var downloadOptions = new DownloadTransferValidationOptions();
            Assert.AreEqual(ValidationAlgorithm.Auto, downloadOptions.Algorithm);
            Assert.IsTrue(downloadOptions.Validate);
        }

        [Test]
        public async Task RoundtripWIthDefaults()
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const ValidationAlgorithm expectedAlgorithm = ValidationAlgorithm.StorageCrc64;
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var uploadvalidationOptions = new UploadTransferValidationOptions();
            var downloadvalidationOptions = new DownloadTransferValidationOptions();
            var clientOptions = ClientBuilder.GetOptions();
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = 512,
                MaximumTransferSize = 512
            };

            // make pipeline assertion for checking checksum was present on upload AND download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestChecksumAssertion(expectedAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected),
                checkResponse: GetResponseChecksumAssertion(expectedAlgorithm));
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            {
                checksumPipelineAssertion.CheckRequest = true;
                await ParallelUploadAsync(client, stream, uploadvalidationOptions, transferOptions);
                checksumPipelineAssertion.CheckRequest = false;
            }

            checksumPipelineAssertion.CheckResponse = true;
            await ParallelDownloadAsync(client, Stream.Null, downloadvalidationOptions, transferOptions);

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }
        #endregion

        #region Nunit ResultStateException Handlers
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
        #endregion
    }
}
