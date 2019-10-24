// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PartitionedDownloaderTests
    {
        private readonly bool _async;

        // Use constants to verify that we flow them everywhere
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly BlobRequestConditions s_conditions = new BlobRequestConditions()
        {
            IfModifiedSince = DateTimeOffset.Now,
            LeaseId = "MyImportantLease"
        };
        private static readonly ETag s_etag = new ETag("0xQWERTY");

        public PartitionedDownloaderTests(bool async)
        {
            _async = async;
        }

        [Test]
        public async Task ReturnsPropertiesForZeroLength()
        {
            MemoryStream stream = new MemoryStream();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties zeroLengthProperties = new BlobProperties()
            {
                ContentLength = 0
            };

            SetupGetProperties(blockClient, zeroLengthProperties);

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreSame(result.Value, zeroLengthProperties);
            Assert.AreEqual(0, stream.Length);
        }

        [Test]
        public async Task DownloadsInOneBlockIfUnderLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(10);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties smallLengthProperties = new BlobProperties()
            {
                ContentLength = 10
            };

            SetupGetProperties(blockClient, smallLengthProperties);

            if (_async)
            {
                blockClient.Setup(c => c.DownloadAsync(s_cancellationToken))
                    .Returns(dataSource.GetStreamAsync);
            }
            else
            {
                blockClient.Setup(c => c.Download(s_cancellationToken))
                    .Returns(dataSource.GetStream);
            }


            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreSame(result.Value, smallLengthProperties);
            AssertContent(10, stream);
        }

        [Test]
        public void SurfacesSingleDownloadException()
        {
            Exception e = new Exception();

            MemoryStream stream = new MemoryStream();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties smallLengthProperties = new BlobProperties()
            {
                ContentLength = 10
            };

            SetupGetProperties(blockClient, smallLengthProperties);

            if (_async)
            {
                blockClient.Setup(c => c.DownloadAsync(s_cancellationToken))
                    .ThrowsAsync(e);
            }
            else
            {
                blockClient.Setup(c => c.Download(s_cancellationToken))
                    .Throws(e);
            }

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object);

            Exception thrown = Assert.ThrowsAsync<Exception>(async () => await InvokeDownloadToAsync(downloader, stream));

            Assert.AreSame(e, thrown);
        }

        [Test]
        public async Task DownloadsInBlocksWhenOverTheLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties smallLengthProperties = new BlobProperties()
            {
                ContentLength = 100
            };

            SetupGetProperties(blockClient, smallLengthProperties);

            if (_async)
            {
                blockClient.Setup(c => c.DownloadAsync(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .Returns<HttpRange, BlobRequestConditions, bool, CancellationToken>(dataSource.GetStreamAsync);
            }
            else
            {
                blockClient.Setup(c => c.Download(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .Returns<HttpRange, BlobRequestConditions, bool, CancellationToken>(dataSource.GetStream);
            }

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10}, 20);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreSame(result.Value, smallLengthProperties);
            Assert.AreEqual(dataSource.Requests.Count, 10);
            AssertContent(100, stream);
        }

        [Test]
        public async Task IncludesEtagInConditions()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties properties = new BlobProperties()
            {
                ContentLength = 100,
                ETag = s_etag
            };

            SetupGetProperties(blockClient, properties);

            if (_async)
            {
                blockClient.Setup(c => c.DownloadAsync(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .Returns<HttpRange, BlobRequestConditions, bool, CancellationToken>(dataSource.GetStreamAsync);
            }
            else
            {
                blockClient.Setup(c => c.Download(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .Returns<HttpRange, BlobRequestConditions, bool, CancellationToken>(dataSource.GetStream);
            }

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10}, 20);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreSame(result.Value, properties);
            Assert.AreEqual(dataSource.Requests.Count, 10);
            AssertContent(100, stream);

            foreach ((HttpRange Range, BlobRequestConditions Conditions) request in dataSource.Requests)
            {
                Assert.AreEqual(s_conditions.LeaseId, request.Conditions.LeaseId);
                Assert.AreEqual(s_conditions.IfModifiedSince, request.Conditions.IfModifiedSince);
                Assert.AreEqual(s_conditions.IfUnmodifiedSince, request.Conditions.IfUnmodifiedSince);
                Assert.AreEqual(s_conditions.IfNoneMatch, request.Conditions.IfNoneMatch);
                Assert.AreEqual(s_etag, request.Conditions.IfMatch);
            }
        }

        [Test]
        public void SurfacesDownloadExceptions()
        {
            Exception e = new Exception();

            MemoryStream stream = new MemoryStream();
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);
            BlobProperties smallLengthProperties = new BlobProperties()
            {
                ContentLength = 100
            };

            SetupGetProperties(blockClient, smallLengthProperties);

            if (_async)
            {
                blockClient.Setup(c => c.DownloadAsync(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .ThrowsAsync(e);
            }
            else
            {
                blockClient.Setup(c => c.Download(It.IsAny<HttpRange>(), It.IsAny<BlobRequestConditions>(), false, s_cancellationToken))
                    .Throws(e);
            }

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10}, 20);

            Exception thrown = Assert.ThrowsAsync<Exception>(async () => await InvokeDownloadToAsync(downloader, stream));

            Assert.AreSame(e, thrown);
        }

        private void AssertContent(int expectedLength, MemoryStream stream)
        {
            Assert.AreEqual(expectedLength, stream.Length);

            byte[] array = stream.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual((byte)i, array[i]);
            }
        }

        private void SetupGetProperties(Mock<BlobBaseClient> client, BlobProperties properties)
        {
            Response<BlobProperties> response = Response.FromValue(properties, new MockResponse(200));

            if (_async)
            {
                client.Setup(c => c.GetPropertiesAsync(s_conditions, s_cancellationToken))
                    .ReturnsAsync(response);
            }
            else
            {
                client.Setup(c => c.GetProperties(s_conditions, s_cancellationToken))
                    .Returns(response);
            }
        }

        private async Task<Response<BlobProperties>> InvokeDownloadToAsync(PartitionedDownloader downloader, Stream stream)
        {
            if (_async)
            {
                return await downloader.DownloadToAsync(stream, s_conditions, s_cancellationToken);
            }
            else
            {
                return downloader.DownloadTo(stream, s_conditions, s_cancellationToken);
            }
        }

        private class MockDataSource
        {
            private readonly int _length;

            public List<(HttpRange Range, BlobRequestConditions Conditions)> Requests { get; } = new List<(HttpRange Range, BlobRequestConditions Conditions)>();

            public MockDataSource(int length)
            {
                _length = length;
            }

            public Task<Response<BlobDownloadInfo>> GetStreamAsync()
            {
                return GetStreamAsync(FullRange);
            }

            public async Task<Response<BlobDownloadInfo>> GetStreamAsync(HttpRange range, BlobRequestConditions conditions = default, bool hash = default, CancellationToken token = default)
            {
                await Task.Delay(25);
                return GetStream(range, conditions, hash, token);
            }

            public Response<BlobDownloadInfo> GetStream()
            {
                return GetStream(FullRange, default, default, default);
            }

            public HttpRange FullRange => new HttpRange(0, _length);

            public Response<BlobDownloadInfo> GetStream(HttpRange range, BlobRequestConditions conditions, bool hash, CancellationToken token)
            {
                lock (Requests)
                {
                    Requests.Add((range, conditions));
                }

                var memoryStream = new MemoryStream();
                for (int i = 0; i < range.Length; i++)
                {
                    if (i > _length)
                    {
                        throw new InvalidOperationException();
                    }

                    memoryStream.WriteByte((byte)(range.Offset + i));
                }

                memoryStream.Position = 0;

                return Response.FromValue(new BlobDownloadInfo(new FlattenedDownloadProperties()
                {
                    Content = memoryStream
                }), new MockResponse(200));
            }
        }
    }
}
