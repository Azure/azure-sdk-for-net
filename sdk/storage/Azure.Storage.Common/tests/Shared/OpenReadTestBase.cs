// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public abstract class OpenReadTestBase<TServiceClient, TContainerClient, TResourceClient, TClientOptions, TRequestConditions, TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TResourceClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        public enum ModifyDataMode
        {
            None = 0,
            Replace = 1,
            Append = 2
        };

        private readonly string _generatedResourceNamePrefix;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        /// <summary>
        /// Supplies service-agnostic access conditions for tests.
        /// </summary>
        public abstract AccessConditionConfigs Conditions { get; }

        /// <summary>
        /// Error code expected from the service when attempted to open read on a nonexistent blob.
        /// Different services supply different error codes.
        /// </summary>
        protected abstract string OpenReadAsync_Error_Code { get; }

        public OpenReadTestBase(
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
        protected abstract TResourceClient GetResourceClient(
            TContainerClient container,
            string resourceName = default,
            TClientOptions options = default);

        /// <summary>
        /// Uploads data to be used for an OpenRead test.
        /// </summary>
        /// <param name="client">Client to call upload on.</param>
        /// <param name="data">Data to upload.</param>
        protected abstract Task StageDataAsync(
            TResourceClient client,
            Stream data);

        protected abstract Task ModifyDataAsync(
            TResourceClient client,
            Stream data,
            ModifyDataMode mode);

        /// <summary>
        /// Calls the 1:1 download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call the download on.</param>
        protected abstract Task<Stream> OpenReadAsync(
            TResourceClient client,
            int? bufferSize = default,
            long position = default,
            TRequestConditions conditions = default,
            bool allowModifications = false);

        /// <summary>
        /// Calls the 1:1 download method for the given resource client.
        /// </summary>
        /// <param name="client">Client to call the download on.</param>
        protected abstract Task<Stream> OpenReadAsyncOverload(
            TResourceClient client,
            int? bufferSize = default,
            long position = default,
            bool allowModifications = false);

        protected abstract Task<string> SetupLeaseAsync(TResourceClient client, string leaseId, string garbageLeaseId);
        protected abstract Task<string> GetMatchConditionAsync(TResourceClient client, string match);
        protected abstract TRequestConditions BuildRequestConditions(AccessConditionParameters parameters, bool lease = true);
        #endregion

        protected string GetNewResourceName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

        private string GetGarbageLeaseId()
            => ClientBuilder.Recording.Random.NewGuid().ToString();

        [RecordedTest]
        public async Task OpenReadAsync()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client);
            byte[] outputBytes = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, 0, size);
#pragma warning restore CA2022

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [RecordedTest]
        public async Task OpenReadAsync_BufferSize()
        {
            int size = Constants.KB;
            int bufferSize = size / 8;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client, bufferSize: bufferSize);
            byte[] outputBytes = new byte[size];
            int downloadedBytes = 0;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [RecordedTest]
        public async Task OpenReadAsync_OffsetAndBufferSize()
        {
            int size = Constants.KB;
            int bufferSize = size / 8;
            int position = size / 2;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            byte[] expected = new byte[size];
            Array.Copy(data, position, expected, position, size - position);

            // Act
            Stream outputStream = await OpenReadAsync(client, bufferSize: bufferSize, position: position);
            byte[] outputBytes = new byte[size];

            int downloadedBytes = position;

            while (downloadedBytes < size)
            {
                downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
            }

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(expected, outputBytes);
        }

        [RecordedTest]
        public async Task OpenReadAsync_Error()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            TResourceClient client = GetResourceClient(disposingContainer.Container);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                OpenReadAsync(client),
                e => Assert.AreEqual(OpenReadAsync_Error_Code, e.ErrorCode));
        }

        [RecordedTest]
        public virtual async Task OpenReadAsync_AccessConditions()
        {
            // Arrange
            int size = Constants.KB;
            int bufferSize = size / 4;
            var garbageLeaseId = GetGarbageLeaseId();
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            foreach (AccessConditionParameters parameters in Conditions.AccessConditions_Data)
            {
                var data = GetRandomBuffer(size);
                TResourceClient client = GetResourceClient(disposingContainer.Container);
                await StageDataAsync(client, new MemoryStream(data));

                parameters.Match = await GetMatchConditionAsync(client, parameters.Match);
                parameters.LeaseId = await SetupLeaseAsync(client, parameters.LeaseId, garbageLeaseId);
                TRequestConditions conditions = BuildRequestConditions(
                    parameters: parameters,
                    lease: true);

                // Act
                Stream outputStream = await OpenReadAsync(client, bufferSize: bufferSize, conditions: conditions);
                byte[] outputBytes = new byte[size];

                int downloadedBytes = 0;

                while (downloadedBytes < size)
                {
                    downloadedBytes += await outputStream.ReadAsync(outputBytes, downloadedBytes, size / 4);
                }

                // Assert
                Assert.AreEqual(data.Length, outputStream.Length);
                TestHelper.AssertSequenceEqual(data, outputBytes);
            }
        }

        [RecordedTest]
        public virtual async Task OpenReadAsync_AccessConditionsFail()
        {
            // Arrange
            int size = Constants.KB;
            int bufferSize = size / 4;
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions.GetAccessConditionsFail_Data(garbageLeaseId))
            {
                await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
                var data = GetRandomBuffer(size);
                TResourceClient client = GetResourceClient(disposingContainer.Container);
                await StageDataAsync(client, new MemoryStream(data));

                parameters.NoneMatch = await GetMatchConditionAsync(client, parameters.NoneMatch);
                TRequestConditions conditions = BuildRequestConditions(parameters, lease: true);

                // Act

                await TestHelper.CatchAsync<Exception>(
                    async () =>
                    {
                        var _ = await OpenReadAsync(client, bufferSize: bufferSize, conditions: conditions);
                    });
            }
        }

        [RecordedTest]
        public async Task OpenReadAsync_StrangeOffsetsTest()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            int size = Constants.KB;
            int bufferSize = 157;
            byte[] expectedData = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(expectedData));

            Stream outputStream = await OpenReadAsync(client, bufferSize: bufferSize);
            byte[] actualData = new byte[size];
            int offset = 0;

            // Act
            int count = 0;
            int readBytes = -1;
            while (readBytes != 0)
            {
                for (count = 6; count < 37; count += 6)
                {
                    readBytes = await outputStream.ReadAsync(actualData, offset, count);
                    if (readBytes == 0)
                    {
                        break;
                    }
                    offset += readBytes;
                }
            }

            // Assert
            TestHelper.AssertSequenceEqual(expectedData, actualData);
        }

        [RecordedTest]
        public virtual async Task OpenReadAsync_Modified()
        {
            int size = Constants.KB;
            int bufferSize = size / 2;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client, bufferSize: bufferSize);
            byte[] outputBytes = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, 0, size / 2);
#pragma warning restore CA2022

            // Modify the blob.
            await ModifyDataAsync(client, new MemoryStream(GetRandomBuffer(size)), ModifyDataMode.Replace);

            // Assert
            await AssertExpectedExceptionOpenReadModifiedAsync(outputStream.ReadAsync(outputBytes, size / 2, size / 2));
        }

        /// <summary>
        /// For the test <see cref="OpenReadAsync_Modified"/>, different services surface different exception types
        /// and we check fields in that exception to ensure they are as expected. This method allows service-specific
        /// subclasses to specify how they check this expected error.
        /// </summary>
        /// <param name="readTask">Task to asynchronously read from the stream.</param>
        /// <returns></returns>
        public abstract Task AssertExpectedExceptionOpenReadModifiedAsync(Task readTask);

        [RecordedTest]
        public async Task OpenReadAsync_ModifiedAllowBlobModifications()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data0 = GetRandomBuffer(size);
            byte[] data1 = GetRandomBuffer(size);
            byte[] expectedData = new byte[2 * size];
            Array.Copy(data0, 0, expectedData, 0, size);
            Array.Copy(data1, 0, expectedData, size, size);

            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data0));

            // Act
            Stream outputStream = await OpenReadAsync(client, allowModifications: true);
            byte[] outputBytes = new byte[2 * size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, 0, size);
#pragma warning restore CA2022

            // Modify the blob.
            await ModifyDataAsync(client, new MemoryStream(data1), ModifyDataMode.Append);

#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, size, size);
#pragma warning restore CA2022

            // Assert
            TestHelper.AssertSequenceEqual(expectedData, outputBytes);
        }

        [RecordedTest]
        [Ignore("Don't want to record 1 GB of data.")]
        public async Task OpenReadAsync_LargeData()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            int length = 1 * Constants.GB;
            byte[] expectedData = GetRandomBuffer(length);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            using Stream stream = new MemoryStream(expectedData);
            await StageDataAsync(client, stream);

            Stream outputStream = await OpenReadAsync(client);
            int readSize = 8 * Constants.MB;
            byte[] actualData = new byte[readSize];
            int offset = 0;

            // Act
            for (int i = 0; i < length / readSize; i++)
            {
                int actualRead = await outputStream.ReadAsync(actualData, 0, readSize);
                for (int j = 0; j < actualRead; j++)
                {
                    // Assert
                    if (actualData[j] != expectedData[offset + j])
                    {
                        Assert.Fail($"Index {offset + j} does not match.  Expected: {expectedData[offset + j]} Actual: {actualData[j]}");
                    }
                }
                offset += actualRead;
            }
        }

        [RecordedTest]
        public async Task OpenReadAsync_CopyReadStreamToAnotherStream()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();
            long size = 4 * Constants.MB;
            byte[] expectedData = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(expectedData));

            MemoryStream outputStream = new MemoryStream();

            // Act
            using Stream blobStream = await OpenReadAsync(client);
            await blobStream.CopyToAsync(outputStream);

            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        [RecordedTest]
        public async Task OpenReadAsync_InvalidParameterTests()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));
            Stream stream = await OpenReadAsync(client);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                stream.ReadAsync(buffer: null, offset: 0, count: 10),
                new ArgumentNullException("buffer", "buffer cannot be null."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: -1, count: 10),
                new ArgumentOutOfRangeException("offset", "offset cannot be less than 0."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 11, count: 10),
                new ArgumentOutOfRangeException("offset", "offset cannot exceed buffer length."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                stream.ReadAsync(buffer: new byte[10], offset: 1, count: -1),
                new ArgumentOutOfRangeException("count", "count cannot be less than 0."));
        }

        [RecordedTest]
        public async Task OpenReadAsync_Seek_PositionUnchanged()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client);
            byte[] outputBytes = new byte[size];
            outputStream.Seek(0, SeekOrigin.Begin);

            Assert.AreEqual(0, outputStream.Position);

#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytes, 0, size);
#pragma warning restore CA2022

            // Assert
            Assert.AreEqual(data.Length, outputStream.Length);
            TestHelper.AssertSequenceEqual(data, outputBytes);
        }

        [RecordedTest]
        public async Task OpenReadAsync_Seek_NegativeNewPosition()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(-10, SeekOrigin.Begin),
                new ArgumentException("New offset cannot be less than 0.  Value was -10", "offset"));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task OpenReadAsync_Seek_NewPositionGreaterThanResourceLength(bool allowModifications)
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream outputStream = await OpenReadAsync(client, allowModifications: allowModifications);
            TestHelper.AssertExpectedException<ArgumentException>(
                () => outputStream.Seek(1025, SeekOrigin.Begin),
                new ArgumentException("You cannot seek past the last known length of the underlying blob or file.", "offset"));

            Assert.AreEqual(size, outputStream.Length);
        }

        [RecordedTest]
        [TestCase(0, SeekOrigin.Begin)]
        [TestCase(10, SeekOrigin.Begin)]
        [TestCase(-10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.Current)]
        [TestCase(10, SeekOrigin.Current)]
        [TestCase(0, SeekOrigin.End)]
        [TestCase(-10, SeekOrigin.End)]
        public async Task OpenReadAsync_Seek_Position(long offset, SeekOrigin origin)
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(size);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            Stream outputStream = await OpenReadAsync(client);
            int readBytes = 512;
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(new byte[readBytes], 0, readBytes);
#pragma warning restore CA2022
            Assert.AreEqual(512, outputStream.Position);

            // Act
            outputStream.Seek(offset, origin);

            // Assert
            if (origin == SeekOrigin.Begin)
            {
                Assert.AreEqual(offset, outputStream.Position);
            }
            else if (origin == SeekOrigin.Current)
            {
                Assert.AreEqual(readBytes + offset, outputStream.Position);
            }
            else
            {
                Assert.AreEqual(size + offset, outputStream.Position);
            }

            Assert.AreEqual(size, outputStream.Length);
        }

        [RecordedTest]
        // lower position within _buffer
        [TestCase(-50)]
        // higher position within _buffer
        [TestCase(50)]
        // lower position below _buffer
        [TestCase(-100)]
        // higher position above _buffer
        [TestCase(100)]
        public async Task OpenReadAsync_Seek(long offset)
        {
            int size = Constants.KB;
            int bufferSize = 128;
            int initalPosition = 450;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - (initalPosition + offset)];
            Array.Copy(data, initalPosition + offset, expectedData, 0, size - (initalPosition + offset));
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream openReadStream = await OpenReadAsync(client, bufferSize: bufferSize);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Seek(offset, SeekOrigin.Current);

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            Assert.AreEqual(size, openReadStream.Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        [RecordedTest]
        // lower position within _buffer
        [TestCase(400)]
        // higher position within _buffer
        [TestCase(500)]
        // lower position below _buffer
        [TestCase(250)]
        // higher position above _buffer
        [TestCase(550)]
        public async Task OpenReadAsync_SetPosition(long position)
        {
            int size = Constants.KB;
            int bufferSize = 128;
            int initalPosition = 450;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data = GetRandomBuffer(size);
            byte[] expectedData = new byte[size - position];
            Array.Copy(data, position, expectedData, 0, size - position);
            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data));

            // Act
            Stream openReadStream = await OpenReadAsync(client, bufferSize: bufferSize);
            int readbytes = initalPosition;
            while (readbytes > 0)
            {
                readbytes -= await openReadStream.ReadAsync(new byte[readbytes], 0, readbytes);
            }

            openReadStream.Position = position;

            using MemoryStream outputStream = new MemoryStream();
            await openReadStream.CopyToAsync(outputStream);

            // Assert
            Assert.AreEqual(expectedData.Length, outputStream.ToArray().Length);
            TestHelper.AssertSequenceEqual(expectedData, outputStream.ToArray());
        }

        [RecordedTest]
        public async Task OpenReadAsyncOverload_AllowModifications()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data0 = GetRandomBuffer(size);
            byte[] data1 = GetRandomBuffer(size);
            byte[] expectedDataBeforeModify = new byte[size];
            byte[] expectedDataAfterModify = new byte[size];
            Array.Copy(data0, 0, expectedDataBeforeModify, 0, size);
            Array.Copy(data1, 0, expectedDataAfterModify, 0, size);

            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data0));

            // Act
            Stream outputStream = await OpenReadAsyncOverload(client, allowModifications: true);
            byte[] outputBytesBeforeModify = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytesBeforeModify, 0, size);
#pragma warning restore CA2022

            // Modify the blob.
            await ModifyDataAsync(client, new MemoryStream(data1), ModifyDataMode.Append);

            byte[] outputBytesAfterModify = new byte[size];
            byte[] emptyBytes = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytesAfterModify, 0, size);
#pragma warning restore CA2022

            // Assert
            TestHelper.AssertSequenceEqual(expectedDataBeforeModify, outputBytesBeforeModify);
            TestHelper.AssertSequenceEqual(expectedDataAfterModify, outputBytesAfterModify);
            Assert.AreNotEqual(emptyBytes, outputBytesAfterModify);
        }

        [RecordedTest]
        public async Task OpenReadAsyncOverload_NotAllowModifications()
        {
            int size = Constants.KB;
            await using IDisposingContainer<TContainerClient> disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            byte[] data0 = GetRandomBuffer(size);
            byte[] data1 = GetRandomBuffer(size);
            byte[] expectedDataBeforeModify = new byte[size];
            byte[] expectedDataAfterModify = new byte[size];
            Array.Copy(data0, 0, expectedDataBeforeModify, 0, size);
            Array.Copy(data1, 0, expectedDataAfterModify, 0, size);

            TResourceClient client = GetResourceClient(disposingContainer.Container);
            await StageDataAsync(client, new MemoryStream(data0));

            // Act
            Stream outputStream = await OpenReadAsyncOverload(client, allowModifications: false);
            byte[] outputBytesBeforeModify = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytesBeforeModify, 0, size);
#pragma warning restore CA2022

            // Modify the blob.
            await ModifyDataAsync(client, new MemoryStream(data1), ModifyDataMode.Append);

            byte[] outputBytesAfterModify = new byte[size];
            byte[] emptyBytes = new byte[size];
#pragma warning disable CA2022 // This test is specifically testing the behavior of the returned stream
            await outputStream.ReadAsync(outputBytesAfterModify, 0, size);
#pragma warning restore CA2022

            // Assert
            TestHelper.AssertSequenceEqual(expectedDataBeforeModify, outputBytesBeforeModify);
            Assert.AreNotEqual(expectedDataAfterModify, outputBytesAfterModify);
            TestHelper.AssertSequenceEqual(emptyBytes, outputBytesAfterModify);
        }
    }
}
