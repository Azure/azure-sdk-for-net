// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using TestConstants = Azure.Storage.Test.Constants;

namespace Azure.Storage.Blobs.Test
{
    public class BlobClientTests : BlobTestBase
    {
        public BlobClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            TestDiagnostics = false;
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

        [Test]
        public async Task UploadAsync()
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
        public async Task UploadAsync_UploadsBlock()
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
        public async Task UploadAsync_Overloads()
        {
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));
                var data = this.GetRandomBuffer(Constants.KB);

                await Verify(async stream => await blob.UploadAsync(stream));
                await Verify(async stream => await blob.UploadAsync(stream, CancellationToken.None));
                await Verify(async stream => await blob.UploadAsync(stream, metadata: default));

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

        private async Task UploadAndVerify(
            long size,
            long singleBlockThreshold,
            int blockSize)
        {
            var data = this.GetRandomBuffer(size);
            using (this.GetNewContainer(out var container))
            {
                var name = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlobClient(name));

                using (var stream = new MemoryStream(data))
                {
                    await blob.StagedUploadAsync(
                        stream,
                        null,
                        null,
                        null,
                        null,
                        singleBlockThreshold: singleBlockThreshold,
                        blockSize: blockSize,
                        async: true);
                }

                var download = await blob.DownloadAsync();
                using var actual = new MemoryStream();
                await download.Value.Content.CopyToAsync(actual);
                TestHelper.AssertSequenceEqual(data, actual.ToArray());
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
        public async Task UploadAsync_SmallBlobs(long size) =>
            // Use a 1KB threshold so we get a lot of indiviaul blocks
            await this.UploadAndVerify(size, Constants.KB, Constants.KB);

        [Test]
        [Category("Live")]
        [TestCase(33 * Constants.MB)]
        [TestCase(257 * Constants.MB)]
        [TestCase(1 * Constants.GB)]
        public async Task UploadAsync_LargeBlobs(long size)
        {
            // TODO: #6781 We don't want to add 1GB of random data in the recordings
            if (this.Mode == RecordedTestMode.Live)
            {
                await this.UploadAndVerify(size, 16 * Constants.MB, Constants.MB);
            }
        }
    }
}
