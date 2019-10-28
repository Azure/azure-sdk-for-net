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
            MockDataSource dataSource = new MockDataSource(0);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(0, stream.Length);
            AssertResult(result, 0);
        }

        [Test]
        public async Task DownloadsInOneBlockIfUnderLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(10);
            Mock<BlobBaseClient> blockClient = new Mock<BlobBaseClient>(MockBehavior.Strict);

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            AssertContent(10, stream);
            AssertResult(result, 10);
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

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10}, 20);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            // First block request is 20, and 10 for every block after that.
            Assert.AreEqual(dataSource.Requests.Count, 9);
            AssertContent(100, stream);
            AssertResult(result, 100);
        }

        private void AssertResult(Response<BlobProperties> result, long expectedLength)
        {
            Assert.NotNull(result.GetRawResponse());
            var value = result.Value;
            Assert.AreEqual(value.ContentLength, expectedLength);

            Assert.AreNotEqual(value.LastModified, default(DateTimeOffset));
            Assert.AreNotEqual(value.Metadata, default);
            Assert.AreNotEqual(value.BlobType, default(BlobType));
            Assert.AreNotEqual(value.CopyCompletedOn, default(DateTimeOffset));
            Assert.AreNotEqual(value.CopyStatusDescription, default);
            Assert.AreNotEqual(value.CopyId, default);
            Assert.AreNotEqual(value.CopyProgress, default);
            Assert.AreNotEqual(value.CopySource, default(Uri));
            Assert.AreNotEqual(value.CopyStatus, default(CopyStatus));
            Assert.AreNotEqual(value.LeaseDuration, default(LeaseDurationType));
            Assert.AreNotEqual(value.LeaseState, default(LeaseState));
            Assert.AreNotEqual(value.LeaseStatus, default(LeaseStatus));
            Assert.AreNotEqual(value.ContentType, default);
            Assert.AreNotEqual(value.ETag, default(ETag));
            Assert.AreNotEqual(value.ContentHash, default);
            Assert.AreNotEqual(value.ContentEncoding, default);
            Assert.AreNotEqual(value.ContentDisposition, default);
            Assert.AreNotEqual(value.ContentLanguage, default);
            Assert.AreNotEqual(value.CacheControl, default);
            Assert.AreNotEqual(value.BlobSequenceNumber, default(long));
            Assert.AreNotEqual(value.AcceptRanges, default);
            Assert.AreNotEqual(value.BlobCommittedBlockCount, default(int));
            Assert.AreNotEqual(value.IsServerEncrypted, default(bool));
            Assert.AreNotEqual(value.EncryptionKeySha256, default);
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

            SetupDownload(blockClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(blockClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10}, 10);

            Response<BlobProperties> result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 10);
            AssertContent(100, stream);
            AssertResult(result, 100);

            bool first = true;
            foreach ((HttpRange Range, BlobRequestConditions Conditions) request in dataSource.Requests)
            {
                Assert.AreEqual(s_conditions.LeaseId, request.Conditions.LeaseId);
                Assert.AreEqual(s_conditions.IfModifiedSince, request.Conditions.IfModifiedSince);
                Assert.AreEqual(s_conditions.IfUnmodifiedSince, request.Conditions.IfUnmodifiedSince);
                Assert.AreEqual(s_conditions.IfNoneMatch, request.Conditions.IfNoneMatch);
                if (first)
                {
                    first = false;
                }
                else
                {
                    Assert.AreEqual(s_etag, request.Conditions.IfMatch);
                }
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

        private void SetupDownload(Mock<BlobBaseClient> blockClient, MockDataSource dataSource)
        {
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

            public async Task<Response<BlobDownloadInfo>> GetStreamAsync(HttpRange range, BlobRequestConditions conditions = default, bool hash = default, CancellationToken token = default)
            {
                await Task.Delay(25);
                return GetStream(range, conditions, hash, token);
            }

            public HttpRange FullRange => new HttpRange(0, _length);

            public Response<BlobDownloadInfo> GetStream(HttpRange range, BlobRequestConditions conditions, bool hash, CancellationToken token)
            {
                lock (Requests)
                {
                    Requests.Add((range, conditions));
                }

                var contentLength = Math.Min(range.Length.Value, _length);

                var memoryStream = new MemoryStream();
                for (int i = 0; i < contentLength; i++)
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
                    ContentRange = $"bytes {range.Offset}-{range.Offset + contentLength}/{_length}",
                    ContentLength = contentLength,
                    Content = memoryStream,
                    LastModified = DateTimeOffset.Now,
                    Metadata = new Dictionary<string, string>() { { "meta", "data"}},
                    BlobType = BlobType.Page,
                    CopyStatusDescription = "test",
                    CopyId = "test",
                    CopyProgress = "test",
                    CopySource = new Uri("http://example.com"),
                    CopyStatus = CopyStatus.Failed,
                    LeaseDuration = LeaseDurationType.Fixed,
                    LeaseState = LeaseState.Expired,
                    LeaseStatus = LeaseStatus.Unlocked,
                    ContentType = "test",
                    ETag = s_etag,
                    ContentHash = new byte[]{ 1, 2, 3},
                    ContentEncoding = "test",
                    ContentDisposition = "test",
                    ContentLanguage = "test",
                    CacheControl = "test",
                    BlobSequenceNumber = 12,
                    AcceptRanges = "test",
                    BlobCommittedBlockCount = 5,
                    IsServerEncrypted = true,
                    EncryptionKeySha256 = "test",
                    CopyCompletionTime =  DateTimeOffset.Now
                }), new MockResponse(200));
            }
        }
    }
}
