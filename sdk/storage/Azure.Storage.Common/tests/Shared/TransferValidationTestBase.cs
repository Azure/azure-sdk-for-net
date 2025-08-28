// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
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
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None);

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
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None,
            TClientOptions options = default);

        /// <summary>
        /// Calls the 1:1 upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="transferValidation">Validation options to use on upload.</param>
        protected abstract Task<Response> UploadPartitionAsync(
            TResourceClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation);

        /// <summary>
        /// Calls the 1:1 download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call the download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="transferValidation">Validation options to use on download.</param>
        /// <param name="range">Range parameter for download, necessary for transactional checksum request to be accepted by service.</param>
        protected abstract Task<Response> DownloadPartitionAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransferValidationOptions transferValidation,
            HttpRange range = default);

        /// <summary>
        /// Calls the parallel upload method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="source">Data to upload.</param>
        /// <param name="transferValidation">Validation options to use on upload.</param>
        /// <param name="transferOptions">Storage transfer options to use on upload.</param>
        protected abstract Task ParallelUploadAsync(
            TResourceClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the parallel download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call download on.</param>
        /// <param name="destination">Where to send downloaded data.</param>
        /// <param name="transferValidation">Validation options to use on download.</param>
        /// <param name="transferOptions">Storage transfer options to use on download.</param>
        protected abstract Task ParallelDownloadAsync(
            TResourceClient client,
            Stream destination,
            DownloadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions);

        /// <summary>
        /// Calls the open write method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open write on.</param>
        /// <param name="transferValidation">Validation options to use in the write stream.</param>
        /// <param name="internalBufferSize">Buffer size for the write stream.</param>
        protected abstract Task<Stream> OpenWriteAsync(
            TResourceClient client,
            UploadTransferValidationOptions transferValidation,
            int internalBufferSize);

        /// <summary>
        /// Calls the open read method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call open read on.</param>
        /// <param name="transferValidation">Validation options to use in the read stream.</param>
        /// <param name="internalBufferSize">Buffer size for the read stream.</param>
        protected abstract Task<Stream> OpenReadAsync(
            TResourceClient client,
            DownloadTransferValidationOptions transferValidation,
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
        internal static Action<Request> GetRequestChecksumHeaderAssertion(StorageChecksumAlgorithm algorithm, Func<Request, bool> isChecksumExpected = default, byte[] expectedChecksum = default)
        {
            // action to assert a request header is as expected
            void AssertChecksum(Request req, string headerName)
            {
                string checksum = req.AssertHeaderPresent(headerName);
                if (expectedChecksum != default)
                {
                    Assert.AreEqual(Convert.ToBase64String(expectedChecksum), checksum);
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
                    case StorageChecksumAlgorithm.MD5:
                        AssertChecksum(request, "Content-MD5");
                        break;
                    case StorageChecksumAlgorithm.StorageCrc64:
                        AssertChecksum(request, Constants.StructuredMessage.StructuredMessageHeader);
                        break;
                    default:
                        throw new Exception($"Bad {nameof(StorageChecksumAlgorithm)} provided to {nameof(GetRequestChecksumHeaderAssertion)}.");
                }
            };
        }

        internal static Action<Request> GetRequestStructuredMessageAssertion(
            StructuredMessage.Flags flags,
            Func<Request, bool> isStructuredMessageExpected = default,
            long? structuredContentSegmentLength = default)
        {
            return request =>
            {
                // filter some requests out with predicate
                if (isStructuredMessageExpected != default && !isStructuredMessageExpected(request))
                {
                    return;
                }

                Assert.That(request.Headers.TryGetValue("x-ms-structured-body", out string structuredBody));
                Assert.That(structuredBody, Does.Contain("XSM/1.0"));
                if (flags.HasFlag(StructuredMessage.Flags.StorageCrc64))
                {
                    Assert.That(structuredBody, Does.Contain("crc64"));
                }

                Assert.That(request.Headers.TryGetValue("Content-Length", out string contentLength));
                Assert.That(request.Headers.TryGetValue("x-ms-structured-content-length", out string structuredContentLength));
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
        internal static Action<Response> GetResponseChecksumAssertion(StorageChecksumAlgorithm algorithm, Func<Response, bool> isChecksumExpected = default, byte[] expectedChecksum = default)
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
                    case StorageChecksumAlgorithm.MD5:
                        AssertChecksum(response.Headers, "Content-MD5");
                        break;
                    case StorageChecksumAlgorithm.StorageCrc64:
                        AssertChecksum(response.Headers, Constants.StructuredMessage.StructuredMessageHeader);
                        break;
                    default:
                        throw new Exception($"Bad {nameof(StorageChecksumAlgorithm)} provided to {nameof(GetRequestChecksumHeaderAssertion)}.");
                }
            };
        }

        internal static Action<Response> GetResponseStructuredMessageAssertion(
            StructuredMessage.Flags flags,
            Func<Response, bool> isStructuredMessageExpected = default)
        {
            return response =>
            {
                // filter some requests out with predicate
                if (isStructuredMessageExpected != default && !isStructuredMessageExpected(response))
                {
                    return;
                }

                Assert.That(response.Headers.TryGetValue("x-ms-structured-body", out string structuredBody));
                Assert.That(structuredBody, Does.Contain("XSM/1.0"));
                if (flags.HasFlag(StructuredMessage.Flags.StorageCrc64))
                {
                    Assert.That(structuredBody, Does.Contain("crc64"));
                }

                Assert.That(response.Headers.TryGetValue("Content-Length", out string contentLength));
                Assert.That(response.Headers.TryGetValue("x-ms-structured-content-length", out string structuredContentLength));
            };
        }

        /// <summary>
        /// Asserts the service returned an error that expected checksum did not match checksum on upload.
        /// </summary>
        /// <param name="writeAction">Async action to upload data to service.</param>
        /// <param name="algorithm">Checksum algorithm used.</param>
        internal static void AssertWriteChecksumMismatch(
            AsyncTestDelegate writeAction,
            StorageChecksumAlgorithm algorithm,
            bool expectStructuredMessage = false)
        {
            var exception = ThrowsOrInconclusiveAsync<RequestFailedException>(writeAction);
            if (expectStructuredMessage)
            {
                Assert.That(exception.ErrorCode, Is.EqualTo("Crc64Mismatch"));
            }
            else
            {
                switch (algorithm.ResolveAuto())
                {
                    case StorageChecksumAlgorithm.MD5:
                        Assert.That(exception.ErrorCode, Is.EqualTo("Md5Mismatch"));
                        break;
                    case StorageChecksumAlgorithm.StorageCrc64:
                        Assert.That(exception.ErrorCode, Is.EqualTo("Crc64Mismatch"));
                        break;
                    default:
                        throw new ArgumentException("Test arguments contain bad algorithm specifier.");
                }
            }
        }
        #endregion

        public static HashSet<StorageChecksumAlgorithm> GetValidationAlgorithms()
        {
            var values = new HashSet<StorageChecksumAlgorithm>(Enum.GetValues(typeof(StorageChecksumAlgorithm)).Cast<StorageChecksumAlgorithm>());
            values.Remove(StorageChecksumAlgorithm.None);
            return values;
        }

        public static HashSet<StorageChecksumAlgorithm> GetValidationAlgorithmsIncludingNone()
        {
            var values = new HashSet<StorageChecksumAlgorithm>(Enum.GetValues(typeof(StorageChecksumAlgorithm)).Cast<StorageChecksumAlgorithm>());
            return values;
        }

        public static HashSet<StorageChecksumAlgorithm> GetComposableValidationAlgorithms()
        {
            var values = new HashSet<StorageChecksumAlgorithm>
            {
                StorageChecksumAlgorithm.StorageCrc64
            };
            if (values.Contains(StorageChecksumAlgorithm.Auto.ResolveAuto()))
            {
                values.Add(StorageChecksumAlgorithm.Auto);
            }
            return values;
        }

        public static HashSet<StorageChecksumAlgorithm> GetNonComposableValidationAlgorithms()
        {
            var values = GetValidationAlgorithms();
            values.ExceptWith(GetComposableValidationAlgorithms());
            return values;
        }

        #region UploadPartition Tests
        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task UploadPartitionSuccessfulHashComputation(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            bool expectStructuredMessage = algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64;
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var assertion = algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, null, dataLength)
                : GetRequestChecksumHeaderAssertion(algorithm);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await UploadPartitionAsync(client, stream, validationOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task UploadPartitionUsePrecalculatedHash(StorageChecksumAlgorithm algorithm)
        {
            if (algorithm == StorageChecksumAlgorithm.Auto)
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
                StorageChecksumAlgorithm.MD5 => 16,
                StorageChecksumAlgorithm.StorageCrc64 => 8,
                _ => throw new ArgumentException("Cannot determine hash size for provided algorithm type")
            };
            // checksum needs to be wrong so we detect difference from auto-SDK correct calculation
            var precalculatedChecksum = GetRandomBuffer(checksumSizeBytes);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm,
                PrecalculatedChecksum = precalculatedChecksum
            };

            // make pipeline assertion for checking precalculated checksum was present on upload
            // precalculated partition upload will never use structured message. always check header
            var assertion = GetRequestChecksumHeaderAssertion(
                algorithm,
                expectedChecksum: algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64 ? default : precalculatedChecksum);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                options: clientOptions);

            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                // Act
                AsyncTestDelegate operation = async () => await UploadPartitionAsync(client, stream, validationOptions);

                // Assert
                AssertWriteChecksumMismatch(operation, algorithm, algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64);
            }
        }

        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task UploadPartitionTamperedStreamThrows(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var streamTamperPolicy = TamperStreamContentsPolicy.TamperByteAt(100);
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
                using var listener = AzureEventSourceListener.CreateConsoleLogger();
                // Assert
                AssertWriteChecksumMismatch(operation, algorithm,
                    expectStructuredMessage: algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64);
            }
        }

        [Test]
        public virtual async Task UploadPartitionUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);

            // make pipeline assertion for checking checksum was present on upload
            var assertion = clientAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, null, dataLength)
                : GetRequestChecksumHeaderAssertion(clientAlgorithm);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await UploadPartitionAsync(client, stream, transferValidation: null);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [Combinatorial]
        public virtual async Task UploadPartitionOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var assertion = overrideAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, null, dataLength)
                : GetRequestChecksumHeaderAssertion(overrideAlgorithm);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await UploadPartitionAsync(client, stream, overrideValidationOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        public virtual async Task UploadPartitionDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains("x-ms-structured-body"))
                {
                    Assert.Fail($"Structured body used when none expected.");
                }
            });
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await UploadPartitionAsync(client, stream, overrideValidationOptions);
            }

            // Assert
            // Assertion was in the pipeline
        }
        #endregion

        #region OpenWrite Tests
        [Test]
        public virtual async Task OpenWriteSuccessfulHashComputation(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
            [Values(Constants.KB)] int streamBufferSize,
            [Values(Constants.KB - 11)] int dataSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumHeaderAssertion(algorithm));
            var clientOptions = ClientBuilder.GetOptions();
            //ObserveStructuredMessagePolicy observe = new();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);
            //clientOptions.AddPolicy(observe, HttpPipelinePosition.BeforeTransport);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                // should use dataSize instead of streamBufferSize but this gives 512 multiple and ends up irrelevant for this test
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                options: clientOptions);

            // Act
            using var writeStream = await OpenWriteAsync(client, validationOptions, streamBufferSize);

            // Assert
            //using var obsv = observe.CheckRequestScope();
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    // triggers pipeline assertion
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }
        }

        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task OpenWriteMismatchedHashThrows(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int streamBufferSize = Constants.KB; // this one needs to be 512 multiple for page blobs
            const int dataSize = Constants.KB - 11; // odd number to get some variance
            const int streamWrites = 10;

            var data = GetRandomBuffer(dataSize);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };

            // Tamper with stream contents in the pipeline to simulate silent failure in the transit layer
            var clientOptions = ClientBuilder.GetOptions();
            var tamperPolicy = TamperStreamContentsPolicy.TamperByteAt(100);
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                // should use dataSize instead of streamBufferSize but this gives 512 multiple and ends up irrelevant for this test
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                options: clientOptions);

            // Act
            using var writeStream = await OpenWriteAsync(client, validationOptions, streamBufferSize);

            // Assert
            tamperPolicy.TransformRequestBody = true;
            AssertWriteChecksumMismatch(async () =>
            {
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }, algorithm);
            tamperPolicy.TransformRequestBody = false;
        }

        [Test]
        public virtual async Task OpenWriteUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumHeaderAssertion(clientAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using var writeStream = await OpenWriteAsync(client, default, streamBufferSize);

            // Assert
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    // triggers pipeline assertion
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }
        }

        [Test]
        [Combinatorial]
        public virtual async Task OpenWriteOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: GetRequestChecksumHeaderAssertion(overrideAlgorithm));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: streamBufferSize * streamWrites,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using var writeStream = await OpenWriteAsync(client, overrideValidationOptions, streamBufferSize);

            // Assert
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    // triggers pipeline assertion
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }
        }

        [Test]
        public virtual async Task OpenWriteDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            const int streamBufferSize = Constants.KB;
            const int streamWrites = 10;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: request =>
            {
                if (request.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (request.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
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
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using var writeStream = await OpenWriteAsync(client, overrideValidationOptions, streamBufferSize);

            // Assert
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                foreach (var _ in Enumerable.Range(0, streamWrites))
                {
                    // triggers pipeline assertion
                    await writeStream.WriteAsync(data, 0, data.Length);
                }
            }
        }

        [Test]
        public virtual async Task OpenWriteSucceedsWithCallerProvidedCrc(
            [Values(Constants.KB)] int dataSize,
            [Values(Constants.KB, 200)] int bufferSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data = GetRandomBuffer(dataSize);
            Memory<byte> dataCrc = Checksum(data, StorageChecksumAlgorithm.StorageCrc64);
            UploadTransferValidationOptions validationOptions = new()
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                PrecalculatedChecksum = dataCrc
            };

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataSize,
                createResource: true);
            Stream writeStream = await OpenWriteAsync(client, validationOptions, bufferSize);

            for (int i = 0; i < dataSize; i += bufferSize)
            {
                await writeStream.WriteAsync(data, i, Math.Min(bufferSize, data.Length - i));
            }

            Assert.DoesNotThrow(writeStream.Dispose);
        }

        [Test]
        public virtual async Task OpenWriteFailsOnCallerProvidedCrcMismatch(
            [Values(Constants.KB)] int dataSize,
            [Values(Constants.KB, 200)] int bufferSize)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data = GetRandomBuffer(dataSize);
            Memory<byte> garbageDataCrc = new Memory<byte>(GetRandomBuffer(Constants.StorageCrc64SizeInBytes));
            UploadTransferValidationOptions validationOptions = new()
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.StorageCrc64,
                PrecalculatedChecksum = garbageDataCrc
            };

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataSize,
                createResource: true);
            Stream writeStream = await OpenWriteAsync(client, validationOptions, bufferSize);

            for (int i = 0; i < dataSize; i += bufferSize)
            {
                await writeStream.WriteAsync(data, i, Math.Min(bufferSize, data.Length - i));
            }

            Assert.Throws<InvalidDataException>(writeStream.Dispose);
        }
        #endregion

        #region Parallel Upload Tests
        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task ParallelUploadSplitSuccessfulHashComputation(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };
            // force split
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = 512,
                MaximumTransferSize = 512
            };

            // make pipeline assertion for checking checksum was present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestChecksumHeaderAssertion(algorithm, isChecksumExpected: ParallelUploadIsChecksumExpected));
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, validationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task ParallelUploadOneShotSuccessfulHashComputation(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm
            };
            // force oneshot
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = Constants.MB,
                MaximumTransferSize = Constants.MB
            };

            // make pipeline assertion for checking checksum was present on upload
            var assertion = algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, ParallelUploadIsChecksumExpected, dataLength)
                : GetRequestChecksumHeaderAssertion(algorithm, isChecksumExpected: ParallelUploadIsChecksumExpected);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, validationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [TestCaseSource(nameof(GetNonComposableValidationAlgorithms))]
        public virtual async Task ParallelUploadPrecalculatedNoncomposableHashNotAccepted(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            ReadOnlyMemory<byte> hash = ContentHasher.GetHash(BinaryData.FromBytes(data), algorithm).Checksum;
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm,
                PrecalculatedChecksum = hash
            };

            var client = await GetResourceClientAsync(disposingContainer.Container, dataLength);

            // Act
            var exception = ThrowsOrInconclusiveAsync<ArgumentException>(
                async () => await ParallelUploadAsync(client, new MemoryStream(data), validationOptions, transferOptions: default));

            // Assert
            Assert.AreEqual("Precalculated checksum not supported when potentially partitioning an upload.", exception.Message);
        }

        [TestCaseSource(nameof(GetComposableValidationAlgorithms))]
        public virtual async Task ParallelUploadPrecalculatedComposableHashAccepted(StorageChecksumAlgorithm algorithm)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            ReadOnlyMemory<byte> hash = ContentHasher.GetHash(BinaryData.FromBytes(data), algorithm).Checksum;
            var validationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = algorithm,
                PrecalculatedChecksum = hash
            };

            var client = await GetResourceClientAsync(disposingContainer.Container, dataLength, createResource: true);

            // Act
            await DoesNotThrowOrInconclusiveAsync(
                async () => await ParallelUploadAsync(client, new MemoryStream(data), validationOptions, transferOptions: default));
        }

        [Test]
        public virtual async Task ParallelUploadUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
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
            var assertion = clientAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64 && !split
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, ParallelUploadIsChecksumExpected, dataLength)
                : GetRequestChecksumHeaderAssertion(clientAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, default, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        [Combinatorial]
        public virtual async Task ParallelUploadOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
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
            var assertion = overrideAlgorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64 && !split
                ? GetRequestStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64, ParallelUploadIsChecksumExpected, dataLength)
                : GetRequestChecksumHeaderAssertion(overrideAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected);
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkRequest: assertion);
            var clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                createResource: true,
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }

        [Test]
        public virtual async Task ParallelUploadDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [Values(true, false)] bool split)
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var overrideValidationOptions = new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
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
                if (request.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
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
                uploadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
        }
        #endregion

        #region Parallel Download Tests
        [Test, Combinatorial]
        public virtual async Task ParallelDownloadSuccessfulHashVerification(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
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
            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = chunkSize,
                MaximumTransferSize = chunkSize
            };

            // Act
            byte[] dest;
            using (MemoryStream ms = new())
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelDownloadAsync(client, ms, validationOptions, transferOptions);
                dest = ms.ToArray();
            }

            // Assert
            // Assertion was in the pipeline and the SDK not throwing means the checksum was validated
            Assert.IsTrue(dest.SequenceEqual(data));
        }

        [Test]
        public virtual async Task ParallelDownloadUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelDownloadAsync(client, dest, default, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        [Combinatorial]
        public virtual async Task ParallelDownloadOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm,
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await ParallelDownloadAsync(client, dest, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task ParallelDownloadDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
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
                if (response.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await ParallelDownloadAsync(client, dest, overrideValidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }
        #endregion

        #region OpenRead Tests
        [Test, Combinatorial]
        public virtual async Task OpenReadSuccessfulHashVerification(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
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
            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };

            // Act
            var readStream = await OpenReadAsync(client, validationOptions, bufferSize);

            // Assert
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(dest));
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task OpenReadUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, default, bufferSize);

            // Assert
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(dest));
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        [Combinatorial]
        public virtual async Task OpenReadOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm)
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, overrideValidationOptions, bufferSize);

            // Assert
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(dest));
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task OpenReadDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: response =>
            {
                if (response.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (response.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var readStream = await OpenReadAsync(client, overrideValidationOptions, bufferSize);

            // Assert
            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await DoesNotThrowOrInconclusiveAsync(async () => await readStream.CopyToAsync(dest));
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }
        #endregion

        #region Download Streaming/Content Tests
        [TestCaseSource(nameof(GetValidationAlgorithms))]
        public virtual async Task DownloadSuccessfulHashVerification(StorageChecksumAlgorithm algorithm)
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

            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };

            // Act
            using var dest = new MemoryStream();
            var response = await DownloadPartitionAsync(client, dest, validationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (algorithm.ResolveAuto())
            {
                case StorageChecksumAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case StorageChecksumAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
            var result = dest.ToArray();
            Assert.IsTrue(result.SequenceEqual(data));
        }

        [TestCase(StorageChecksumAlgorithm.StorageCrc64, Constants.StructuredMessage.MaxDownloadCrcWithHeader, false, false)]
        [TestCase(StorageChecksumAlgorithm.StorageCrc64, Constants.StructuredMessage.MaxDownloadCrcWithHeader-1, false, false)]
        [TestCase(StorageChecksumAlgorithm.StorageCrc64, Constants.StructuredMessage.MaxDownloadCrcWithHeader+1, true, false)]
        [TestCase(StorageChecksumAlgorithm.MD5, Constants.StructuredMessage.MaxDownloadCrcWithHeader+1, false, true)]
        public virtual async Task DownloadApporpriatelyUsesStructuredMessage(
            StorageChecksumAlgorithm algorithm,
            int? downloadLen,
            bool expectStructuredMessage,
            bool expectThrow)
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

            // make pipeline assertion for checking checksum was present on download
            HttpPipelinePolicy checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: expectStructuredMessage
                ? GetResponseStructuredMessageAssertion(StructuredMessage.Flags.StorageCrc64)
                : GetResponseChecksumAssertion(algorithm));
            TClientOptions clientOptions = ClientBuilder.GetOptions();
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLength,
                resourceName: resourceName,
                createResource: false,
                downloadAlgorithm: algorithm,
                options: clientOptions);

            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };

            // Act
            var dest = new MemoryStream();
            AsyncTestDelegate operation = async () => await DownloadPartitionAsync(
                client, dest, validationOptions, downloadLen.HasValue ? new HttpRange(length: downloadLen.Value) : default);
            // Assert (policies checked use of content validation)
            if (expectThrow)
            {
                Assert.That(operation, Throws.TypeOf<RequestFailedException>());
            }
            else
            {
                Assert.That(operation, Throws.Nothing);
                Assert.IsTrue(dest.ToArray().SequenceEqual(data));
            }
        }

        [Test, Combinatorial]
        public virtual async Task DownloadHashMismatchThrows(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
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

            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm, AutoValidateChecksum = validate };

            // alter response contents in pipeline, forcing a checksum mismatch on verification step
            var clientOptions = ClientBuilder.GetOptions();
            var tamperPolicy = TamperStreamContentsPolicy.TamperByteAt(50);
            tamperPolicy.TransformResponseBody = true;
            clientOptions.AddPolicy(tamperPolicy, HttpPipelinePosition.PerCall);
            client = await GetResourceClientAsync(
                disposingContainer.Container,
                createResource: false,
                resourceName: resourceName,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            AsyncTestDelegate operation = async () => await DownloadPartitionAsync(client, dest, validationOptions, new HttpRange(length: data.Length));

            // Assert
            if (validate || algorithm.ResolveAuto() == StorageChecksumAlgorithm.StorageCrc64)
            {
                // SDK responsible for finding bad checksum. Throw.
                ThrowsOrInconclusiveAsync<InvalidDataException>(operation);
            }
            else
            {
                // bad checksum is for caller to find. Don't throw.
                await DoesNotThrowOrInconclusiveAsync(operation);
            }
            // data was tamepered. should be different.
            Assert.IsFalse(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task DownloadUsesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            var response = await DownloadPartitionAsync(client, dest, default, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (clientAlgorithm.ResolveAuto())
            {
                case StorageChecksumAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case StorageChecksumAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        [Combinatorial]
        public virtual async Task DownloadOverwritesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm,
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm overrideAlgorithm)
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = overrideAlgorithm
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            var response = await DownloadPartitionAsync(client, dest, overrideValidationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (overrideAlgorithm.ResolveAuto())
            {
                case StorageChecksumAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case StorageChecksumAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task DownloadDisablesDefaultClientValidationOptions(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm clientAlgorithm)
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

            var overrideValidationOptions = new DownloadTransferValidationOptions
            {
                ChecksumAlgorithm = StorageChecksumAlgorithm.None // disable
            };

            // make pipeline assertion for checking checksum was not present on upload
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(checkResponse: response =>
            {
                if (response.Headers.Contains("Content-MD5"))
                {
                    Assert.Fail($"Hash found when none expected.");
                }
                if (response.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage))
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
                downloadAlgorithm: clientAlgorithm,
                options: clientOptions);

            // Act
            var dest = new MemoryStream();
            var response = await DownloadPartitionAsync(client, dest, overrideValidationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            Assert.False(response.Headers.Contains("Content-MD5"));
            Assert.False(response.Headers.Contains(Constants.StructuredMessage.CrcStructuredMessage));
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }

        [Test]
        public virtual async Task DownloadRecoversFromInterruptWithValidation(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm)
        {
            using var _ = AzureEventSourceListener.CreateConsoleLogger();
            int dataLen = algorithm.ResolveAuto() switch {
                StorageChecksumAlgorithm.StorageCrc64 => 5 * Constants.MB, // >4MB for multisegment
                _ => Constants.KB,
            };

            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(dataLen);

            TClientOptions options = ClientBuilder.GetOptions();
            options.AddPolicy(new FaultyDownloadPipelinePolicy(dataLen - 512, new IOException(), () => { }), HttpPipelinePosition.BeforeTransport);
            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataLen,
                createResource: true,
                options: options);
            await SetupDataAsync(client, new MemoryStream(data));

            var validationOptions = new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };

            // Act
            var dest = new MemoryStream();
            var response = await DownloadPartitionAsync(client, dest, validationOptions, new HttpRange(length: data.Length));

            // Assert
            // no policies this time; just check response headers
            switch (algorithm.ResolveAuto())
            {
                case StorageChecksumAlgorithm.MD5:
                    Assert.True(response.Headers.Contains("Content-MD5"));
                    break;
                case StorageChecksumAlgorithm.StorageCrc64:
                    Assert.True(response.Headers.Contains(Constants.StructuredMessage.StructuredMessageHeader));
                    break;
                default:
                    Assert.Fail("Test can't validate given algorithm type.");
                    break;
            }
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
        }
        #endregion

        #region Auto-Algorithm Tests
        [Test]
        public void TestDefaults()
        {
            var uploadOptions = new UploadTransferValidationOptions();
            Assert.AreEqual(StorageChecksumAlgorithm.None, uploadOptions.ChecksumAlgorithm);
            Assert.IsTrue(uploadOptions.PrecalculatedChecksum.IsEmpty);

            var downloadOptions = new DownloadTransferValidationOptions();
            Assert.AreEqual(StorageChecksumAlgorithm.None, downloadOptions.ChecksumAlgorithm);
            Assert.IsTrue(downloadOptions.AutoValidateChecksum);
        }

        [Test]
        public abstract void TestAutoResolve();

        [Test]
        public async Task RoundtripWIthDefaults()
        {
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            StorageChecksumAlgorithm expectedAlgorithm = TransferValidationOptionsExtensions.ResolveAuto(StorageChecksumAlgorithm.Auto);
            const int dataLength = Constants.KB;
            var data = GetRandomBuffer(dataLength);
            var uploadvalidationOptions = new UploadTransferValidationOptions() { ChecksumAlgorithm = StorageChecksumAlgorithm.Auto };
            var downloadvalidationOptions = new DownloadTransferValidationOptions() { ChecksumAlgorithm = StorageChecksumAlgorithm.Auto };
            var clientOptions = ClientBuilder.GetOptions();
            StorageTransferOptions transferOptions = new StorageTransferOptions
            {
                InitialTransferSize = 512,
                MaximumTransferSize = 512
            };

            // make pipeline assertion for checking checksum was present on upload AND download
            var checksumPipelineAssertion = new AssertMessageContentsPolicy(
                checkRequest: GetRequestChecksumHeaderAssertion(expectedAlgorithm, isChecksumExpected: ParallelUploadIsChecksumExpected),
                checkResponse: GetResponseChecksumAssertion(expectedAlgorithm));
            clientOptions.AddPolicy(checksumPipelineAssertion, HttpPipelinePosition.PerCall);

            var client = await GetResourceClientAsync(disposingContainer.Container, resourceLength: dataLength, createResource: true, options: clientOptions);

            // Act
            using (var stream = new MemoryStream(data))
            using (checksumPipelineAssertion.CheckRequestScope())
            {
                await ParallelUploadAsync(client, stream, uploadvalidationOptions, transferOptions);
            }

            var dest = new MemoryStream();
            using (checksumPipelineAssertion.CheckResponseScope())
            {
                await ParallelDownloadAsync(client, dest, downloadvalidationOptions, transferOptions);
            }

            // Assert
            // Assertion was in the pipeline and the service returning success means the checksum was correct
            Assert.IsTrue(dest.ToArray().SequenceEqual(data));
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

        #region Inlines
        private Memory<byte> Checksum(ReadOnlySpan<byte> data, StorageChecksumAlgorithm algorithm)
        {
            IHasher hasher = ContentHasher.GetHasherFromAlgorithmId(algorithm);
            hasher?.AppendHash(data);
            return hasher?.GetFinalHash() ?? Memory<byte>.Empty;
        }
        #endregion
    }
}
