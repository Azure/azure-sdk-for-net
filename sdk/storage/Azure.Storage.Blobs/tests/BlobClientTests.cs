// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
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

            var containerName = GetNewContainerName();
            var blobName = GetNewBlobName();

            BlobClient blob1 = InstrumentClient(new BlobClient(connectionString.ToString(true), containerName, blobName, GetOptions()));

            BlobClient blob2 = InstrumentClient(new BlobClient(connectionString.ToString(true), containerName, blobName));

            var builder1 = new BlobUriBuilder(blob1.Uri);
            var builder2 = new BlobUriBuilder(blob2.Uri);

            Assert.AreEqual(containerName, builder1.BlobContainerName);
            Assert.AreEqual(blobName, builder1.BlobName);
            Assert.AreEqual("accountName", builder1.AccountName);

            Assert.AreEqual(containerName, builder2.BlobContainerName);
            Assert.AreEqual(blobName, builder2.BlobName);
            Assert.AreEqual("accountName", builder2.AccountName);
        }

        #region Upload

        [Test]
        public async Task UploadAsync_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            System.Collections.Generic.IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(name, blobs.First().Name);

            Response<BlobDownloadInfo> download = await blob.DownloadAsync();
            using var actual = new MemoryStream();
            await download.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task UploadAsync_Stream_UploadsBlock()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_Stream_StorageTransferOptions(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                await Verify(stream => blob.UploadAsync(stream, transferOptions: options));

                async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
                {
                    using (var stream = new MemoryStream(data))
                    {
                        await upload(stream);
                    }

                    Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                    using var actual = new MemoryStream();
                    await download.Value.Content.CopyToAsync(actual);
                    TestHelper.AssertSequenceEqual(data, actual.ToArray());
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        public async Task UploadAsync_Stream_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            await Verify(stream => blob.UploadAsync(stream));
            await Verify(stream => blob.UploadAsync(stream, true, CancellationToken.None));
            await Verify(stream => blob.UploadAsync(stream, metadata: default));

            async Task Verify(Func<Stream, Task<Response<BlobContentInfo>>> upload)
            {
                using (var stream = new MemoryStream(data))
                {
                    await upload(stream);
                }

                Response<BlobDownloadInfo> download = await blob.DownloadAsync();
                using var actual = new MemoryStream();
                await download.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
            }
        }

        [Test]
        public async Task UploadAsync_File()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await blob.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            System.Collections.Generic.IList<BlobItem> blobs = await test.Container.GetBlobsAsync().ToListAsync();
            Assert.AreEqual(1, blobs.Count);
            Assert.AreEqual(name, blobs.First().Name);

            Response<BlobDownloadInfo> download = await blob.DownloadAsync();
            using var actual = new MemoryStream();
            await download.Value.Content.CopyToAsync(actual);
            TestHelper.AssertSequenceEqual(data, actual.ToArray());
        }

        [Test]
        public async Task UploadAsync_File_UploadsBlock()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await blob.UploadAsync(path);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(16)]
        [TestCase(null)]
        public async Task UploadAsync_File_StorageTransferOptions(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                    await Verify(blob.UploadAsync(path, transferOptions: options));

                    async Task Verify(Task<Response<BlobContentInfo>> upload)
                    {
                        using (var stream = new MemoryStream(data))
                        {
                            await upload;
                        }

                        Response<BlobDownloadInfo> download = await blob.DownloadAsync();
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

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(BlobType.Block, properties.Value.BlobType);
        }

        [Test]
        [TestCase(1)]
        public async Task UploadAsync_File_AccessTier(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    await blob.UploadAsync(
                        path,
                        accessTier: AccessTier.Cool);
                }
                finally
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

            Response<BlobProperties> properties = await blob.GetPropertiesAsync();
            Assert.AreEqual(AccessTier.Cool.ToString(), properties.Value.AccessTier);
        }

        [Test]
        [TestCase(1)]
        public async Task UploadAsync_File_AccessTierFail(int? maximumThreadCount)
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            var data = GetRandomBuffer(Constants.KB);

            using (var stream = new MemoryStream(data))
            {
                var path = Path.GetTempFileName();

                try
                {
                    File.WriteAllBytes(path, data);

                    var options = new StorageTransferOptions { MaximumConcurrency = maximumThreadCount };

                    // Assert
                    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                        blob.UploadAsync(
                        path,
                        transferOptions: options,
                        accessTier: AccessTier.P10),
                        e => Assert.AreEqual(BlobErrorCode.InvalidHeaderValue.ToString(), e.ErrorCode));
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

        [Test]
        public async Task UploadAsync_File_Overloads()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var data = GetRandomBuffer(Constants.KB);

            var path = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(path, data);

                await Verify(blob.UploadAsync(path));
                await Verify(blob.UploadAsync(path, true, CancellationToken.None));
                await Verify(blob.UploadAsync(path, metadata: default));

                async Task Verify(Task<Response<BlobContentInfo>> upload)
                {
                    using (var stream = new MemoryStream(data))
                    {
                        await upload;
                    }

                    Response<BlobDownloadInfo> download = await blob.DownloadAsync();
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

        private async Task UploadStreamAndVerify(
            long size,
            long singleBlockThreshold,
            StorageTransferOptions transferOptions)
        {
            var data = GetRandomBuffer(size);
            await using DisposingContainer test = await GetTestContainerAsync();

            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
            blob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

            using (var stream = new MemoryStream(data))
            {
                await blob.StagedUploadAsync(
                    content: stream,
                    blobHttpHeaders: default,
                    metadata: default,
                    conditions: default,
                    progressHandler: default,
                    singleUploadThreshold: singleBlockThreshold,
                    transferOptions: transferOptions,
                    async: true);
            }

            var actual = new byte[Constants.DefaultBufferSize];
            var actualStream = new MemoryStream(actual);

            // we are testing Upload, not download: so we download in partitions to avoid the default timeout
            for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
            {
                var startIndex = i;
                var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                Response<BlobDownloadInfo> download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                actualStream.Position = 0;
                await download.Value.Content.CopyToAsync(actualStream);
                TestHelper.AssertSequenceEqual(
                    data.AsSpan(startIndex, count).ToArray(),
                    actual.AsSpan(0, count).ToArray()
                    );
            }
        }

        private async Task UploadFileAndVerify(
            long size,
            long singleBlockThreshold,
            StorageTransferOptions transferOptions)
        {
            var data = GetRandomBuffer(size);
            var path = Path.GetTempFileName();

            try
            {
                File.WriteAllBytes(path, data);
                await using DisposingContainer test = await GetTestContainerAsync();

                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                var credential = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
                blob = InstrumentClient(new BlobClient(blob.Uri, credential, GetOptions(true)));

                using (var stream = new MemoryStream(data))
                {
                    await blob.StagedUploadAsync(
                        path: path,
                        blobHttpHeaders: default,
                        metadata: default,
                        conditions: default,
                        progressHandler: default,
                        singleUploadThreshold: singleBlockThreshold,
                        transferOptions: transferOptions,
                        async: true);
                }

                var actual = new byte[Constants.DefaultBufferSize];
                var actualStream = new MemoryStream(actual);

                // we are testing Upload, not download: so we download in partitions to avoid the default timeout
                for (var i = 0; i < size; i += Constants.DefaultBufferSize * 5 / 2)
                {
                    var startIndex = i;
                    var count = Math.Min(Constants.DefaultBufferSize, (int)(size - startIndex));

                    Response<BlobDownloadInfo> download = await blob.DownloadAsync(new HttpRange(startIndex, count));
                    actualStream.Position = 0;
                    await download.Value.Content.CopyToAsync(actualStream);
                    TestHelper.AssertSequenceEqual(
                        data.AsSpan(startIndex, count).ToArray(),
                        actual.AsSpan(0, count).ToArray()
                        );
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        // [TestCase(501 * Constants.KB)] // TODO: #6781 We don't want to add 500K of random data in the recordings
        public async Task UploadStreamAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadStreamAndVerify(size, Constants.KB, new StorageTransferOptions { MaximumTransferLength = Constants.KB });

        [Test]
        [TestCase(512)]
        [TestCase(1 * Constants.KB)]
        [TestCase(2 * Constants.KB)]
        [TestCase(4 * Constants.KB)]
        [TestCase(10 * Constants.KB)]
        [TestCase(20 * Constants.KB)]
        [TestCase(30 * Constants.KB)]
        [TestCase(50 * Constants.KB)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        // [TestCase(501 * Constants.KB)] // TODO: #6781 We don't want to add 500K of random data in the recordings
        public async Task UploadFileAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of individual blocks
            await UploadFileAndVerify(size, Constants.KB, new StorageTransferOptions { MaximumTransferLength = Constants.KB });

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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        public async Task UploadStreamAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadStreamAndVerify(size, 16 * Constants.MB, new StorageTransferOptions { MaximumConcurrency = maximumThreadCount });
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
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/8354")]
        public async Task UploadFileAsync_LargeBlobs(long size, int? maximumThreadCount)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            await UploadFileAndVerify(size, 16 * Constants.MB, new StorageTransferOptions { MaximumConcurrency = maximumThreadCount });
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwriteDefault_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting fails
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.UploadAsync(stream2));
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwrite_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting fails
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await blob.UploadAsync(stream2, overwrite: false));
        }

        [Test]
        public async Task UploadAsync_OverwritesDeliberately_Stream()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload one blob
            var name = GetNewBlobName();
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
            using var stream = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream);

            // Overwriting works if allowed
            using var stream2 = new MemoryStream(GetRandomBuffer(Constants.KB));
            await blob.UploadAsync(stream2, overwrite: true);
        }

        [Test]
        public async Task UploadAsync_DoesNotOverwriteDefault_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting fails
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await blob.UploadAsync(path));
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
        public async Task UploadAsync_DoesNotOverwrite_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting fails
                Assert.ThrowsAsync<RequestFailedException>(
                    async () => await blob.UploadAsync(path, overwrite: false));
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
        public async Task UploadAsync_OverwritesDeliberately_Path()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            var path = Path.GetTempFileName();
            try
            {
                // Upload one blob
                var name = GetNewBlobName();
                BlobClient blob = InstrumentClient(test.Container.GetBlobClient(name));
                File.WriteAllBytes(path, GetRandomBuffer(Constants.KB));
                await blob.UploadAsync(path);

                // Overwriting works if allowed
                await blob.UploadAsync(path, overwrite: true);
            }
            finally
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }
        #endregion Upload

        [Test]
        [Explicit]
        [Ignore("The latest test runner isn't handling the [Explicit] attribute properly")]
        public async Task Perf_SmallBlobs()
        {
            // Turn off logging and diagnostics
            TestDiagnostics = false;
            BlobClientOptions options = new BlobClientOptions();
            options.Diagnostics.IsDistributedTracingEnabled = false;
            options.Diagnostics.IsLoggingEnabled = false;

            BlobServiceClient service = new BlobServiceClient(
                new Uri(TestConfigDefault.BlobServiceEndpoint),
                GetNewSharedKeyCredentials(),
                options);

            await using DisposingContainer test = await GetTestContainerAsync(service);

            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            } // Add breakpoint here to start collecting traces

            for (int trial = 0; trial < 1000; trial++)
            {
                BlobClient b = test.Container.GetBlobClient(blob.Name);
                using BlobDownloadInfo download = await b.DownloadAsync();
            }
        } // Add breakpoint here to stop collecting traces

        [Test]
        [Explicit] // This runs for a full minute and uploads a ton of data.  Don't want this on every run.
        [Ignore("The latest test runner isn't handling the [Explicit] attribute properly")]
        public async Task Upload_Stress()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            try
            {
                // Create a CancellationToken that times out after 60s
                CancellationTokenSource source = new CancellationTokenSource(TimeSpan.FromSeconds(60));
                CancellationToken token = source.Token;

                // Keep uploading a GB
                var data = GetRandomBuffer(Constants.GB);
                for (;;)
                {
                    BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
                    using var stream = new MemoryStream(data);
                    await blob.UploadAsync(
                        stream,
                        transferOptions: new StorageTransferOptions { MaximumConcurrency = 8 },
                        cancellationToken: token);
                }
            }
            catch (OperationCanceledException)
            {
                return; // Succeeded
            }
        }

        [Test]
        [LiveOnly] // Don't want a 100MB recording
        public async Task ChecksForCancelation()
        {
            await using DisposingContainer test = await GetTestContainerAsync();

            // Upload a GB
            var data = GetRandomBuffer(100 * Constants.MB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewBlobName()));
            using var stream = new MemoryStream(data);
            await blob.UploadAsync(stream);

            // Create a CancellationToken that times out after .1s
            CancellationTokenSource source = new CancellationTokenSource(TimeSpan.FromSeconds(.1));
            CancellationToken token = source.Token;

            // Verifying downloading will cancel
            try
            {
                using BlobDownloadInfo result = await blob.DownloadAsync(cancellationToken: token);
            }
            catch (OperationCanceledException)
            {
                return; // Succeeded
            }
            Assert.Fail("Not canceled!");
        }
    }
}
