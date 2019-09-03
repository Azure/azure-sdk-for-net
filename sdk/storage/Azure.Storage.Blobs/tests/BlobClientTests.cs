// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobClientTests : BlobTestBase
    {
        public BlobClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var containerName = this.GetNewContainerName();
            var blobName = this.GetNewBlobName();

            var blob = this.InstrumentClient(new BlobClient(connectionString.ToString(true), containerName, blobName, this.GetOptions()));

            var builder = new BlobUriBuilder(blob.Uri);

            Assert.AreEqual(containerName, builder.ContainerName);
            Assert.AreEqual(blobName, builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        #region Upload

        [Test]
        public async Task UploadAsync_Stream()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(name, blobs.First().Value.Name);

                var download = await blob.DownloadAsync();
                using var actual = new MemoryStream();
                await download.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_Stream_UploadsBlock()
        {
            using (this.GetNewContainer(out var container))
            {
                var blob = this.InstrumentClient(container.GetBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    await blob.UploadAsync(stream);
                }

                var properties = await blob.GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_Stream_ParallelTransferOptions(int? maximumThreadCount)
        {
            using (this.GetNewContainer(out var container))
            {
                var blob = this.InstrumentClient(container.GetBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var options = new ParallelTransferOptions { MaximumThreadCount = maximumThreadCount };

                    await Verify(stream => blob.UploadAsync(stream, parallelTransferOptions: options));

                    async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
                    {
                        using (var stream = new MemoryStream(data))
                        {
                            await upload(stream);
                        }

                        var download = await blob.DownloadAsync();
                        using var actual = new MemoryStream();
                        await download.Value.Content.CopyToAsync(actual);
                        TestHelper.AssertSequenceEqual(data, actual.ToArray());
                    }
                }

                var properties = await blob.GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        public async Task UploadAsync_Stream_Overloads()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));
                var data = this.GetRandomBuffer(Constants.KB);

                await Verify(stream => blob.UploadAsync(stream));
                await Verify(stream => blob.UploadAsync(stream, CancellationToken.None));
                await Verify(stream => blob.UploadAsync(stream, metadata: default));

                async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
                {
                    using (var stream = new MemoryStream(data))
                    {
                        await upload(stream);
                    }

                    var download = await blob.DownloadAsync();
                    using var actual = new MemoryStream();
                    await download.Value.Content.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
                }
            }
        }

        [Test]
        public async Task UploadAsync_File()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var path = Path.GetTempFileName();

                    try
                    {
                        File.WriteAllBytes(path, data);

                        var file = new FileInfo(path);

                        await blob.UploadAsync(file);
                    }
                    finally
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                }

                var blobs = await container.GetBlobsAsync().ToListAsync();
                Assert.AreEqual(1, blobs.Count);
                Assert.AreEqual(name, blobs.First().Value.Name);

                var download = await blob.DownloadAsync();
                using var actual = new MemoryStream();
                await download.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_File_UploadsBlock()
        {
            using (this.GetNewContainer(out var container))
            {
                var blob = this.InstrumentClient(container.GetBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var path = Path.GetTempFileName();

                    try
                    {
                        File.WriteAllBytes(path, data);

                        var file = new FileInfo(path);

                        await blob.UploadAsync(file);
                    }
                    finally
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                }

                var properties = await blob.GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_File_ParallelTransferOptions(int? maximumThreadCount)
        {
            using (this.GetNewContainer(out var container))
            {
                var blob = this.InstrumentClient(container.GetBlobClient(this.GetNewBlobName()));
                var data = this.GetRandomBuffer(Constants.KB);

                using (var stream = new MemoryStream(data))
                {
                    var path = Path.GetTempFileName();

                    try
                    {
                        File.WriteAllBytes(path, data);

                        var file = new FileInfo(path);

                        var options = new ParallelTransferOptions { MaximumThreadCount = maximumThreadCount };

                        await Verify(blob.UploadAsync(file, parallelTransferOptions: options));

                        async Task Verify(Task<Response<BlobContentInfo>> upload)
                        {
                            using (var stream = new MemoryStream(data))
                            {
                                await upload;
                            }

                            var download = await blob.DownloadAsync();
                            using var actual = new MemoryStream();
                            await download.Value.Content.CopyToAsync(actual);
                            TestHelper.AssertSequenceEqual(data, actual.ToArray());
                        }
                    }
                    finally
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                    }
                }

                var properties = await blob.GetPropertiesAsync();
                Assert.AreEqual(BlobType.BlockBlob, properties.Value.BlobType);
            }
        }

        [Test]
        public async Task UploadAsync_File_Overloads()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));
                var data = this.GetRandomBuffer(Constants.KB);

                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    var file = new FileInfo(path);

                    await Verify(blob.UploadAsync(file));
                    await Verify(blob.UploadAsync(file, CancellationToken.None));
                    await Verify(blob.UploadAsync(file, metadata: default));

                    async Task Verify(Task<Response<BlobContentInfo>> upload)
                    {
                        using (var stream = new MemoryStream(data))
                        {
                            await upload;
                        }

                        var download = await blob.DownloadAsync();
                        using var actual = new MemoryStream();
                        await download.Value.Content.CopyToAsync(actual);
                        TestHelper.AssertSequenceEqual(data, actual.ToArray());
                    }
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
        }

        private async Task UploadStreamAndVerify(
            long size,
            long singleBlockThreshold,
            ParallelTransferOptions parallelTransferOptions)
        {
            var data = this.GetRandomBuffer(size);
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));

                using (var stream = new MemoryStream(data))
                {
                    await blob.StagedUploadAsync(
                        content: stream,
                        blobHttpHeaders: default,
                        metadata: default,
                        blobAccessConditions: default,
                        customerProvidedKey: default,
                        progressHandler: default,
                        singleBlockThreshold: singleBlockThreshold,
                        parallelTransferOptions,
                        async: true);
                }

                var actual = new byte[Constants.DefaultBufferSize];
                var actualStream = new MemoryStream(actual);

                // we are testing Upload, not download: so we download in partitions to avoid the default timeout
                for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
                {
                    var startIndex = i;
                    var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                    var download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                    actualStream.Position = 0;
                    await download.Value.Content.CopyToAsync(actualStream);
                    TestHelper.AssertSequenceEqual(
                        data.AsSpan(startIndex, count).ToArray(),
                        actual.AsSpan(0, count).ToArray()
                        );
                }
            }
        }

        private async Task UploadFileAndVerify(
            long size,
            long singleBlockThreshold,
            ParallelTransferOptions parallelTransferOptions)
        {
            var data = this.GetRandomBuffer(size);
            var path = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(path, data);

                using (this.GetNewContainer(out var container))
                {
                    var name = this.GetNewBlobName();
                    var blob = this.InstrumentClient(container.GetBlobClient(name));

                    using (var stream = new MemoryStream(data))
                    {
                        await blob.StagedUploadAsync(
                            file: new FileInfo(path),
                            blobHttpHeaders: default,
                            metadata: default,
                            blobAccessConditions: default,
                            customerProvidedKey: default,
                            progressHandler: default,
                            singleBlockThreshold: singleBlockThreshold,
                            parallelTransferOptions,
                            async: true);
                    }

                    var actual = new byte[Constants.DefaultBufferSize];
                    var actualStream = new MemoryStream(actual);

                    // we are testing Upload, not download: so we download in partitions to avoid the default timeout
                    for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
                    {
                        var startIndex = i;
                        var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                        var download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                        actualStream.Position = 0;
                        await download.Value.Content.CopyToAsync(actualStream);
                        TestHelper.AssertSequenceEqual(
                            data.AsSpan(startIndex, count).ToArray(),
                            actual.AsSpan(0, count).ToArray()
                            );
                    }
                }
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task UploadStreamAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await this.UploadStreamAndVerify(size, Constants.KB, new ParallelTransferOptions { MaximumTransferLength = Constants.KB });

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [TestCase(501 * Constants.KB)]
        public async Task UploadFileAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await this.UploadFileAndVerify(size, Constants.KB, new ParallelTransferOptions { MaximumTransferLength = Constants.KB });

        [Test]
        [LiveOnly]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, 16)]
        [TestCase(1 * Constants.GB, null)]
        public async Task UploadStreamAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await this.UploadStreamAndVerify(size, 16 * Constants.MB, new ParallelTransferOptions { MaximumThreadCount = maximumThreadCount });
        }

        [Test]
        [LiveOnly]
        [TestCase(33 * Constants.MB, 1)]
        [TestCase(33 * Constants.MB, 4)]
        [TestCase(33 * Constants.MB, 8)]
        [TestCase(33 * Constants.MB, 16)]
        [TestCase(33 * Constants.MB, null)]
        [TestCase(257 * Constants.MB, 1)]
        [TestCase(257 * Constants.MB, 4)]
        [TestCase(257 * Constants.MB, 8)]
        [TestCase(257 * Constants.MB, 16)]
        [TestCase(257 * Constants.MB, null)]
        [TestCase(1 * Constants.GB, 1)]
        [TestCase(1 * Constants.GB, 4)]
        [TestCase(1 * Constants.GB, 8)]
        [TestCase(1 * Constants.GB, 16)]
        [TestCase(1 * Constants.GB, null)]
        public async Task UploadFileAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await this.UploadFileAndVerify(size, 16 * Constants.MB, new ParallelTransferOptions { MaximumThreadCount = maximumThreadCount });
        }

        #endregion Upload
    }
}
