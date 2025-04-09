// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Test;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class LazyLoadingBlobStreamTests : ChangeFeedTestBase
    {
        public LazyLoadingBlobStreamTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Tests Read() with various sized Reads().
        /// </summary>
        [RecordedTest]
        public async Task ReadAsync()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();

            // Arrange
            int length = Constants.KB;
            byte[] exectedData = GetRandomBuffer(length);
            BlobClient blobClient = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(exectedData))
            {
                await blobClient.UploadAsync(stream);
            }
            LazyLoadingBlobStream lazyStream = new LazyLoadingBlobStream(blobClient, offset: 0, blockSize: 157);
            byte[] actualData = new byte[length];
            int offset = 0;

            // Act
            int count = 0;
            while (offset + count < length)
            {
                for (count = 6; count < 37; count += 6)
                {
#pragma warning disable CA2022 // This test is specifically testing the behavior of ReadAsync
                    await lazyStream.ReadAsync(actualData, offset, count);
#pragma warning restore CA2022
                    offset += count;
                }
            }
#pragma warning disable CA2022 // This test is specifically testing the behavior of ReadAsync
            await lazyStream.ReadAsync(actualData, offset, length - offset);
#pragma warning restore CA2022

            // Assert
            TestHelper.AssertSequenceEqual(exectedData, actualData);
        }

        /// <summary>
        /// Tests LazyBlobStream parameter validation.
        /// </summary>
        [RecordedTest]
        public async Task ReadAsync_InvalidParameterTests()
        {
            // Arrange
            BlobClient blobClient = new BlobClient(new Uri("https://www.doesntmatter.com"));
            LazyLoadingBlobStream lazyStream = new LazyLoadingBlobStream(blobClient, offset: 0, blockSize: Constants.KB);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentNullException>(
                lazyStream.ReadAsync(buffer: null, offset: 0, count: 10),
                new ArgumentNullException("buffer", $"buffer cannot be null."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                lazyStream.ReadAsync(buffer: new byte[10], offset: -1, count: 10),
                new ArgumentOutOfRangeException("offset", "offset cannot be less than 0."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                lazyStream.ReadAsync(buffer: new byte[10], offset: 11, count: 10),
                new ArgumentOutOfRangeException("offset", "offset cannot exceed buffer length."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                lazyStream.ReadAsync(buffer: new byte[10], offset: 1, count: -1),
                new ArgumentOutOfRangeException("count", "count cannot be less than 0."));

            await TestHelper.AssertExpectedExceptionAsync<ArgumentOutOfRangeException>(
                lazyStream.ReadAsync(buffer: new byte[10], offset: 5, count: 15),
                new ArgumentOutOfRangeException("offset and count", "offset + count cannot exceed buffer length."));
        }
    }
}
