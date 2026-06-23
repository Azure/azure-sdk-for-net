// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// Defines service-agnostic tests for OpenRead() methods.
    /// </summary>
    public abstract class OpenWriteTestBase<TServiceClient, TContainerClient, TResourceClient, TClientOptions, TRequestConditions, TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TResourceClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        public delegate Task AdditionalTestAssertions(TResourceClient client);

        public enum ModifyDataMode
        {
            None = 0,
            Replace = 1,
            Append = 2
        };

        private readonly string _generatedResourceNamePrefix;

        /// <summary>
        /// Any additional assertions to be applied at the end of each test
        /// to a client that has been written to through an OpenWrite call.
        /// Not applicable to some tests.
        /// </summary>
        protected AdditionalTestAssertions AdditionalAssertions;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        /// <summary>
        /// Supplies service-agnostic access conditions for tests.
        /// </summary>
        public abstract AccessConditionConfigs Conditions { get; }

        public abstract string ConditionNotMetErrorCode { get; }
        public abstract string ContainerNotFoundErrorCode { get; }

        public OpenWriteTestBase(
            bool async,
            string generatedResourceNamePrefix = default,
            RecordedTestMode? mode = null)
            : base(async, mode)
        {
            _generatedResourceNamePrefix = generatedResourceNamePrefix ?? "test-resource-";
        }

        #region Service-Specific Methods
        /// <summary>
        /// Gets a service-specific container client for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract TContainerClient GetUninitializedContainerClient(
            TServiceClient service = default,
            string containerName = default);

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
        protected abstract TResourceClient GetResourceClient(
            TContainerClient container,
            string resourceName = default,
            TClientOptions options = default);

        /// <summary>
        /// Calls the client's OpenWrite method.
        /// </summary>
        /// <param name="client">
        /// Client to call method on.
        /// </param>
        /// <param name="overwrite">
        /// Overwrite parameter of open write method.
        /// </param>
        /// <param name="maxDataSize">
        /// Optional. Sets the total size of the resource on OpenWrite
        /// if the resource type requires such a parameter.
        /// </param>
        /// <param name="bufferSize">
        /// Optional. Internal buffer size of the write stream.
        /// </param>
        /// <param name="conditions">
        /// Optional. Request conditions.
        /// </param>
        /// <param name="metadata">
        /// Optional. Metadata to set on resource.
        /// </param>
        /// <param name="httpHeaders">
        /// Optional. HTTP headers to set on resource.
        /// </param>
        /// <param name="progressHandler">
        /// Optional. Progress handler.
        /// </param>
        /// <returns>
        /// Task containing a write stream.
        /// </returns>
        protected abstract Task<Stream> OpenWriteAsync(
            TResourceClient client,
            bool overwrite,
            long? maxDataSize,
            int? bufferSize = default,
            TRequestConditions conditions = default,
            Dictionary<string, string> metadata = default,
            HttpHeaderParameters httpHeaders = default,
            IProgress<long> progressHandler = default);

        protected abstract Task<BinaryData> DownloadAsync(TResourceClient client);
        protected abstract Task ModifyAsync(TResourceClient client, Stream data);
        protected abstract Task<Response> GetPropertiesAsync(TResourceClient client);
        protected abstract Task<IDictionary<string, string>> GetMetadataAsync(TResourceClient client);

        protected abstract Task<string> SetupLeaseAsync(TResourceClient client, string leaseId, string garbageLeaseId);
        protected abstract Task<string> GetMatchConditionAsync(TResourceClient client, string match);
        protected abstract TRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true);
        #endregion

        protected string GetNewResourceName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

        private string GetGarbageLeaseId()
            => ClientBuilder.Recording.Random.NewGuid().ToString();

        // hook for clientside encryption to adjust some test assertions
        protected virtual long GetExpectedDataLength(long dataLength) => dataLength;

        #region Tests
        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob()
        {
            const int size = 16 * Constants.KB;
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            byte[] data = GetRandomBuffer(size);
            using (Stream stream = await OpenWriteAsync(client, overwrite: true, maxDataSize: size, bufferSize: bufferSize))
            {
                // Act
                await stream.WriteAsync(data, 0, 512);
                await stream.WriteAsync(data, 512, 1024);
                await stream.WriteAsync(data, 1536, 2048);
                await stream.WriteAsync(data, 3584, 77);
                await stream.WriteAsync(data, 3661, 2066);
                await stream.WriteAsync(data, 5727, 4096);
                await stream.WriteAsync(data, 9823, 6561);
                await stream.FlushAsync();
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_WithIntermediateFlushes()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            // Act
            const int a = 100;
            const int b = 50;
            const int c = 25;
            using (Stream stream = await OpenWriteAsync(client, maxDataSize: a + b + c, overwrite: true))
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII))
                {
                    writer.Write(new string('A', a));
                    writer.Flush();

                    writer.Write(new string('B', b));
                    writer.Flush();

                    writer.Write(new string('C', c));
                    writer.Flush();
                }
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(new string('A', 100) + new string('B', 50) + new string('C', 25), Encoding.ASCII.GetString(dataResult));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_NewBlob_WithMetadata()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
                bufferSize: bufferSize,
                metadata: metadata))
            {
                // Act
                await stream.FlushAsync();
            }

            // Assert
            CollectionAssert.AreEqual(metadata, await GetMetadataAsync(client));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_CreateEmptyBlob_WithMetadata()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            Dictionary<string, string> metadata = new Dictionary<string, string>() { { "testkey", "testvalue" } };

            // Act
            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
                bufferSize: bufferSize,
                metadata: metadata))
            {
            }

            // Assert
            CollectionAssert.AreEqual(metadata, await GetMetadataAsync(client));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob_WithHeaders()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            // don't have a service-agnostic type
            HttpHeaderParameters headers = new HttpHeaderParameters
            {
                ContentType = "application/json",
                ContentLanguage = "en",
            };

            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
                bufferSize: bufferSize,
                httpHeaders: headers))
            {
                // Act
                await stream.FlushAsync();
            }

            // Assert
            Response response = await GetPropertiesAsync(client);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out string downloadedContentType));
            Assert.AreEqual(headers.ContentType, downloadedContentType);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Language", out string downloadedContentLanguage));
            Assert.AreEqual(headers.ContentLanguage, downloadedContentLanguage);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_CreateEmptyBlob_WithHeaders()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            HttpHeaderParameters headers = new HttpHeaderParameters
            {
                ContentType = "application/json",
                ContentLanguage = "en",
            };

            // Act
            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: Constants.KB,
                bufferSize: bufferSize,
                httpHeaders: headers))
            {
            }

            // Assert
            Response response = await GetPropertiesAsync(client);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Type", out string downloadedContentType));
            Assert.AreEqual(headers.ContentType, downloadedContentType);
            Assert.IsTrue(response.Headers.TryGetValue("Content-Language", out string downloadedContentLanguage));
            Assert.AreEqual(headers.ContentLanguage, downloadedContentLanguage);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlob_WithUsing()
        {
            const int bufferSize = Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            byte[] data = GetRandomBuffer(16 * Constants.KB);

            // Act
            using (Stream stream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: data.Length,
                bufferSize: bufferSize))
            {
                await stream.WriteAsync(data, 0, 512);
                await stream.WriteAsync(data, 512, 1024);
                await stream.WriteAsync(data, 1536, 2048);
                await stream.WriteAsync(data, 3584, 77);
                await stream.WriteAsync(data, 3661, 2066);
                await stream.WriteAsync(data, 5727, 4096);
                await stream.WriteAsync(data, 9823, 6561);
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(data.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(data, dataResult);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Overwrite()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using (Stream originalStream = new MemoryStream(originalData))
            {
                using (Stream openWriteStream = await OpenWriteAsync(
                    client,
                    overwrite: true,
                    maxDataSize: originalData.Length))
                {
                    await originalStream.CopyToAsync(openWriteStream);
                }
            }

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            using (Stream openWriteStream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: newData.Length))
            {
                await newStream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(newData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(newData, dataResult);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AlternatingWriteAndFlush()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            var name = GetNewResourceName();
            TResourceClient client = GetResourceClient(disposingContainer.Container, resourceName: name);

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            using (Stream writeStream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: data0.Length + data1.Length))
            {
                await dataStream0.CopyToAsync(writeStream);
                await writeStream.FlushAsync();
                await dataStream1.CopyToAsync(writeStream);
                await writeStream.FlushAsync();
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Error()
        {
            // Arrange
            TResourceClient client = GetResourceClient(GetUninitializedContainerClient());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                OpenWriteAsync(client, overwrite: true, maxDataSize: Constants.KB),
                e => Assert.AreEqual(ContainerNotFoundErrorCode, e.ErrorCode));
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_ModifiedDuringWrite()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            byte[] data = GetRandomBuffer(Constants.KB);
            using Stream stream = new MemoryStream(data);

            // Act
            Stream openWriteStream = await OpenWriteAsync(client, overwrite: true, maxDataSize: Constants.KB);

            using (Stream update = new MemoryStream(GetRandomBuffer(Constants.KB)))
            {
                await ModifyAsync(client, update);
            }

            await stream.CopyToAsync(openWriteStream);

            async Task CloseStream()
            {
                await openWriteStream.FlushAsync();
                // dispose necessary for some stream implementations
                openWriteStream.Dispose();
            }

            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                CloseStream(),
                e => Assert.AreEqual(ConditionNotMetErrorCode, e.ErrorCode));
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_ProgressReporting()
        {
            const int bufferSize = 512;
            const int dataSize = 2 * Constants.KB;

            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            byte[] data = GetRandomBuffer(dataSize);
            using Stream stream = new MemoryStream(data);

            TestProgress progress = new TestProgress();

            // Act
            using (Stream openWriteStream = await OpenWriteAsync(
                client,
                overwrite: true,
                maxDataSize: data.Length,
                bufferSize: bufferSize,
                progressHandler: progress))
            {
                await stream.CopyToAsync(openWriteStream);
                await openWriteStream.FlushAsync();
            }

            // Assert
            Assert.IsTrue(progress.List.Count > 0);
            Assert.AreEqual(GetExpectedDataLength(dataSize), progress.List[progress.List.Count - 1]);

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }

        [RecordedTest]
        public async Task OpenWriteAsync_AccessConditions()
        {
            foreach (AccessConditionParameters parameters in Conditions.AccessConditions_Data)
            {
                // Arrange
                await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
                TResourceClient client = GetResourceClient(disposingContainer.Container);

                // initialize client with starter data
                using (Stream dest = await OpenWriteAsync(
                    client,
                    overwrite: true,
                    maxDataSize: Constants.KB))
                {
                    await new MemoryStream(GetRandomBuffer(Constants.KB)).CopyToAsync(dest);
                    await dest.FlushAsync();
                }

                var garbageLeaseId = GetGarbageLeaseId();
                parameters.Match = await GetMatchConditionAsync(client, parameters.Match);
                parameters.LeaseId = await SetupLeaseAsync(client, parameters.LeaseId, garbageLeaseId);
                TRequestConditions accessConditions = BuildRequestConditions(parameters);

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                // Act
                using (Stream openWriteStream = await OpenWriteAsync(
                    client,
                    overwrite: true,
                    maxDataSize: data.Length,
                    conditions: accessConditions))
                {
                    await stream.CopyToAsync(openWriteStream);
                    await openWriteStream.FlushAsync();
                }

                // Assert
                byte[] dataResult = (await DownloadAsync(client)).ToArray();
                Assert.AreEqual(data.Length, dataResult.Length);
                TestHelper.AssertSequenceEqual(data, dataResult);

                await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
            }
        }

        [RecordedTest]
        public virtual async Task OpenWriteAsync_AccessConditionsFail()
        {
            foreach (AccessConditionParameters parameters in Conditions.AccessConditionsFail_Data)
            {
                // Arrange
                await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
                TResourceClient client = GetResourceClient(disposingContainer.Container);

                // initialize client with starter data
                using (Stream dest = await OpenWriteAsync(
                    client,
                    overwrite: true,
                    maxDataSize: Constants.KB))
                {
                    await new MemoryStream(GetRandomBuffer(Constants.KB)).CopyToAsync(dest);
                    await dest.FlushAsync();
                }

                parameters.NoneMatch = await GetMatchConditionAsync(client, parameters.NoneMatch);
                TRequestConditions accessConditions = BuildRequestConditions(parameters);

                byte[] data = GetRandomBuffer(Constants.KB);
                using Stream stream = new MemoryStream(data);

                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    OpenWriteAsync(
                        client,
                        overwrite: true,
                        maxDataSize: Constants.KB,
                        conditions: accessConditions),
                    e => Assert.AreEqual(ConditionNotMetErrorCode, e.ErrorCode));
            }
        }
        #endregion
    }
}
