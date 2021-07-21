// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PartitionedDownloaderTests
    {
        private readonly bool _async;

        // Use constants to verify that we flow them everywhere
        private static readonly CancellationToken s_cancellationToken = new CancellationTokenSource().Token;
        private static readonly ShareFileRequestConditions s_conditions = new ShareFileRequestConditions()
        {
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
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownload(fileClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(fileClient.Object);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(0, stream.Length);
            Assert.NotNull(result);
        }

        [Test]
        public async Task DownloadsInOneBlockIfUnderLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(10);
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();

            SetupDownload(fileClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(fileClient.Object);

            Response result = await InvokeDownloadToAsync(downloader, stream);

            AssertContent(10, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task DownloadsInBlocksWhenOverTheLimit()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();
            fileClient.SetupGet(c => c.Uri).CallBase();

            SetupDownload(fileClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                fileClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 20
                });

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 9);
            AssertContent(100, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task RespectsInitialTransferSizeBeforeDownloadingInBlocks()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();
            fileClient.SetupGet(c => c.Uri).CallBase();

            SetupDownload(fileClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                fileClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 40,
                    InitialTransferLength = 10
                });

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 4);
            AssertContent(100, stream);
            Assert.NotNull(result);
        }

        [Test]
        public async Task ETagPersistsThroughBlocks()
        {
            MemoryStream stream = new MemoryStream();
            MockDataSource dataSource = new MockDataSource(100);
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();
            fileClient.SetupGet(c => c.Uri).CallBase();

            SetupDownload(fileClient, dataSource);

            PartitionedDownloader downloader = new PartitionedDownloader(
                fileClient.Object,
                new StorageTransferOptions()
                {
                    MaximumTransferLength = 10,
                    InitialTransferLength = 10
                });

            Response result = await InvokeDownloadToAsync(downloader, stream);

            Assert.AreEqual(dataSource.Requests.Count, 10);
            AssertContent(100, stream);
            Assert.NotNull(result);

            Assert.AreEqual(s_etag, result.Headers.ETag);
        }

        [Test]
        public void SurfacesDownloadExceptions()
        {
            Exception e = new Exception();

            MemoryStream stream = new MemoryStream();
            Mock<ShareFileClient> fileClient = new Mock<ShareFileClient>(MockBehavior.Strict, new Uri("http://mock"), new ShareClientOptions());
            fileClient.SetupGet(c => c.ClientConfiguration).CallBase();

            if (_async)
            {
                fileClient.Setup(c => c.DownloadAsync(It.IsAny<HttpRange>(), false, It.IsAny<ShareFileRequestConditions>(), s_cancellationToken))
                    .ThrowsAsync(e);
            }
            else
            {
                fileClient.Setup(c => c.Download(It.IsAny<HttpRange>(), false, It.IsAny<ShareFileRequestConditions>(), s_cancellationToken))
                    .Throws(e);
            }

            PartitionedDownloader downloader = new PartitionedDownloader(fileClient.Object, new StorageTransferOptions() { MaximumTransferLength = 10});

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

        private void SetupDownload(Mock<ShareFileClient> fileClient, MockDataSource dataSource)
        {
            if (_async)
            {
                fileClient.Setup(c => c.DownloadAsync(It.IsAny<HttpRange>(), false, It.IsAny<ShareFileRequestConditions>(), s_cancellationToken))
                    .Returns<HttpRange, bool, ShareFileRequestConditions, CancellationToken>(dataSource.GetStreamAsync);
            }
            else
            {
                fileClient.Setup(c => c.Download(It.IsAny<HttpRange>(), false, It.IsAny<ShareFileRequestConditions>(), s_cancellationToken))
                    .Returns<HttpRange, bool, ShareFileRequestConditions, CancellationToken>(dataSource.GetStream);
            }
        }

        private async Task<Response> InvokeDownloadToAsync(PartitionedDownloader downloader, Stream stream)
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

            public List<(HttpRange Range, ShareFileRequestConditions Conditions)> Requests { get; } = new List<(HttpRange Range, ShareFileRequestConditions Conditions)>();

            public MockDataSource(int length)
            {
                _length = length;
            }

            public async Task<Response<ShareFileDownloadInfo>> GetStreamAsync(HttpRange range, bool hash = default, ShareFileRequestConditions conditions = default, CancellationToken token = default)
            {
                await Task.Delay(25);
                return GetStream(range, hash, conditions, token);
            }

            public HttpRange FullRange => new HttpRange(0, _length);

            public Response<ShareFileDownloadInfo> GetStream(HttpRange range, bool hash, ShareFileRequestConditions conditions, CancellationToken token)
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

                MockResponse responseWithHeaders = new MockResponse(200);
                responseWithHeaders.AddHeader(new Core.HttpHeader("ETag", $"\"{s_etag}\""));

                return Response.FromValue(new ShareFileDownloadInfo()
                {
                    Content = memoryStream,
                    ContentLength = contentLength,
                    ContentType = "test",
                    ContentHash = new byte[] { 1, 2, 3 },
                    Details = new ShareFileDownloadDetails()
                    {
                        LastModified = DateTimeOffset.Now,
                        Metadata = new Dictionary<string, string>() { { "meta", "data" } },
                        ContentRange = $"bytes {range.Offset}-{range.Offset + contentLength}/{_length}",
                        ETag = s_etag,
                        ContentEncoding = new List<string> { "test" },
                        CacheControl = "test",
                        ContentDisposition = "test",
                        ContentLanguage = new List<string> { "test" },
                        CopyCompletedOn = DateTimeOffset.Now,
                        CopyStatusDescription = "test",
                        CopyId = "test",
                        CopyProgress = "test",
                        CopySource = new Uri("http://example.com"),
                        CopyStatus = CopyStatus.Failed,
                        AcceptRanges = "test",
                        IsServerEncrypted = true
                    }
                }, responseWithHeaders);
            }
        }
    }
}
