// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class LazyLoadingReadOnlyStreamTests
    {
        private class DownloadedContent : IDownloadedContent
        {
            private readonly Stream _content;
            public Stream Content => _content;

            public DownloadedContent(Stream stream)
            {
                _content = stream;
            }
        }

        // int just fills the generic requirements, we don't care about data type and go straight for the raw response
        private static Mock<LazyLoadingReadOnlyStream<int>.DownloadInternalAsync> GetDownloadBehavior(byte[] data)
        {
            // just mocking a response from injectable behavior
            var downloadMock = new Mock<LazyLoadingReadOnlyStream<int>.DownloadInternalAsync>();
            downloadMock.Setup(_ => _(It.IsAny<HttpRange>(), It.IsAny<DownloadTransferValidationOptions>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns<HttpRange, DownloadTransferValidationOptions, bool, CancellationToken>((range, validationOptions, async, CancellationToken) =>
                {
                    var mockResponse = new Mock<Response<IDownloadedContent>>(MockBehavior.Strict);
                    mockResponse.SetupGet(r => r.Value)
                        .Returns(new DownloadedContent(new MemoryStream(data, (int)range.Offset, (int)(range.Length ?? (data.Length - range.Offset)))));
                    mockResponse.Setup(r => r.GetRawResponse())
                        .Returns(() => new MockResponse(201).AddHeader("Content-Range", $"bytes {range.Offset}-{range.Offset + range.Length - 1}/{data.Length}"));
                    return Task.FromResult(mockResponse.Object);
                });

            return downloadMock;
        }

        // int just fills the generic requirements, we don't care about data type and go straight for the raw response
        private static Mock<LazyLoadingReadOnlyStream<int>.GetPropertiesAsync> GetPropertiesBehavior(int totalResourceLength)
        {
            // just mocking a response from injectable behavior
            var propertiesMock = new Mock<LazyLoadingReadOnlyStream<int>.GetPropertiesAsync>();
            propertiesMock.Setup(_ => _(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns<bool, CancellationToken>((value, cancellationToken) =>
                {
                    var mockResponse = new Mock<Response<int>>(MockBehavior.Strict);
                    mockResponse.Setup(r => r.GetRawResponse())
                        .Returns(() => new MockResponse(200).AddHeader("Content-Length", totalResourceLength.ToString()));
                    return Task.FromResult(mockResponse.Object);
                });

            return propertiesMock;
        }

        [TestCase(0, Constants.KB, Constants.KB)]
        [TestCase(0 * Constants.KB, Constants.KB, 3 * Constants.KB)]
        [TestCase(1 * Constants.KB, Constants.KB, 3 * Constants.KB)]
        [TestCase(2 * Constants.KB, Constants.KB, 3 * Constants.KB)]
        public async Task AvoidRebuffer(int offset, int bufferSize, int dataSize)
        {
            if (offset < 0 || offset + bufferSize > dataSize)
            {
                throw new ArgumentException("Bad test definition.");
            }

            // Arrange
            byte[] data = TestHelper.GetRandomBuffer(dataSize);

            var downloadMock = GetDownloadBehavior(data);
            var propertiesMock = GetPropertiesBehavior(data.Length);
            var readStream = new LazyLoadingReadOnlyStream<int>(
                downloadMock.Object,
                propertiesMock.Object,
                transferValidation: default,
                allowModifications: false,
                initialLength: dataSize,
                position: offset,
                bufferSize: bufferSize);

            // Act
            var readTest = new byte[bufferSize];
            foreach (var _ in Enumerable.Range(0, 10))
            {
#pragma warning disable CA2022 // This test is specifically testing the behavior of the stream
                await readStream.ReadAsync(readTest, 0, readTest.Length);
#pragma warning restore CA2022
                // seek back to exact start of current buffer
                readStream.Position = offset;
            }

            // Assert
            Assert.AreEqual(1, downloadMock.Invocations.Count);
        }

        [TestCase(Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(Constants.DefaultStreamingDownloadSize)]
        [TestCase(2 * Constants.DefaultStreamingDownloadSize)]
        public void LazyLoadingReadOnlyStream_NoModification_DefaultBufferSize(int length)
        {
            // Arrange
            byte[] data = TestHelper.GetRandomBuffer(length);

            var downloadMock = GetDownloadBehavior(data);
            var propertiesMock = GetPropertiesBehavior(data.Length);
            LazyLoadingReadOnlyStream<int> readStream = new LazyLoadingReadOnlyStream<int>(
                downloadMock.Object,
                propertiesMock.Object,
                transferValidation: default,
                allowModifications: false,
                initialLength: length);

            // Act
            Type streamType = typeof(LazyLoadingReadOnlyStream<int>);
            FieldInfo fieldInfo = streamType.GetField("_bufferSize", BindingFlags.NonPublic | BindingFlags.Instance);
            int bufferSize = (int)fieldInfo.GetValue(readStream);

            // Assert
            Assert.AreEqual(bufferSize, (int)Math.Min(length, Constants.DefaultStreamingDownloadSize));
        }
    }
}
