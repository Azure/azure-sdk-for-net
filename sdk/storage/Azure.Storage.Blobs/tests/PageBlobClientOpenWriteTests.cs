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
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class PageBlobClientOpenWriteTests : BlobBaseClientOpenWriteTests<PageBlobClient>
    {
        public PageBlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override PageBlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string blobName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetPageBlobClient(blobName);
            }

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetPageBlobClient(blobName));
        }

        protected override async Task ModifyAsync(PageBlobClient client, Stream data)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            // open write doesn't support modification, we need to manually edit the blob

            await client.UploadPagesAsync(data, 0);
        }

        protected override Task<Stream> OpenWriteAsync(
            PageBlobClient client,
            bool overwrite,
            long? maxDataSize,
            int? bufferSize = null,
            BlobRequestConditions conditions = null,
            Dictionary<string, string> metadata = null,
            HttpHeaderParameters httpHeaders = null,
            IProgress<long> progressHandler = null)
            => OpenWriteAsync(client, overwrite, maxDataSize, tags: default, bufferSize, conditions, metadata, httpHeaders, progressHandler);

        protected override async Task<Stream> OpenWriteAsync(
            PageBlobClient client,
            bool overwrite,
            long? maxDataSize,
            Dictionary<string, string> tags,
            int? bufferSize = default,
            BlobRequestConditions conditions = default,
            Dictionary<string, string> metadata = default,
            HttpHeaderParameters httpHeaders = default,
            IProgress<long> progressHandler = default)
        {
            if (metadata != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "PageBlobClient.OpenWriteAsync() does not support metadata.");
            }
            if (tags != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "PageBlobClient.OpenWriteAsync() does not support tags.");
            }
            if (httpHeaders != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "PageBlobClient.OpenWriteAsync() does not support httpHeaders.");
            }

            PageBlobRequestConditions pageConditions = conditions == default ? default : new PageBlobRequestConditions
            {
                IfModifiedSince = conditions.IfModifiedSince,
                IfUnmodifiedSince = conditions.IfUnmodifiedSince,
                IfMatch = conditions.IfMatch,
                IfNoneMatch = conditions.IfNoneMatch,
                LeaseId = conditions.LeaseId,
            };
            return await client.OpenWriteAsync(overwrite, 0, new PageBlobOpenWriteOptions
            {
                BufferSize = bufferSize,
                OpenConditions = pageConditions,
                Size = maxDataSize,
                ProgressHandler = progressHandler,
            });
        }

        #region PageBlob specific tests
        [RecordedTest]
        public async Task OpenWriteAsync_UpdateExistingBlob()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            PageBlobClient blob = GetResourceClient(disposingContainer.Container);
            await blob.CreateAsync(2 * Constants.KB);

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);

            await blob.UploadPagesAsync(originalStream, offset: 0);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(
                overwrite: false,
                position: Constants.KB);
            await newStream.CopyToAsync(openWriteStream);
            await openWriteStream.FlushAsync();

            // Assert
            byte[] expectedData = new byte[2 * Constants.KB];
            Array.Copy(originalData, 0, expectedData, 0, Constants.KB);
            Array.Copy(newData, 0, expectedData, Constants.KB, Constants.KB);

            Response<BlobDownloadInfo> result = await blob.DownloadAsync(new HttpRange(0, 2 * Constants.KB));
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        [RecordedTest]
        public async Task OpenWriteAsync_OverwriteNoSize()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            PageBlobClient blob = GetResourceClient(disposingContainer.Container);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.OpenWriteAsync(
                    overwrite: true,
                    position: 0),
                e => Assert.AreEqual("options.Size must be set if overwrite is set to true", e.Message));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_NewBlobNoSize()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            PageBlobClient blob = GetResourceClient(disposingContainer.Container);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blob.OpenWriteAsync(
                    overwrite: false,
                    position: 0),
                e => Assert.AreEqual("options.Size must be set if the Page Blob is being created for the first time", e.Message));
        }

        [RecordedTest]
        public async Task OpenWriteAsync_Position()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            PageBlobClient blob = GetResourceClient(disposingContainer.Container);
            await blob.CreateAsync(Constants.KB);

            byte[] data0 = GetRandomBuffer(512);
            byte[] data1 = GetRandomBuffer(512);
            using Stream dataStream0 = new MemoryStream(data0);
            using Stream dataStream1 = new MemoryStream(data1);
            byte[] expectedData = new byte[Constants.KB];
            Array.Copy(data0, expectedData, 512);
            Array.Copy(data1, 0, expectedData, 512, 512);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(
                overwrite: false,
                position: 0);

            Assert.AreEqual(0, openWriteStream.Position);

            await dataStream0.CopyToAsync(openWriteStream);

            Assert.AreEqual(512, openWriteStream.Position);

            await dataStream1.CopyToAsync(openWriteStream);

            Assert.AreEqual(1024, openWriteStream.Position);

            await openWriteStream.FlushAsync();

            Assert.AreEqual(1024, openWriteStream.Position);

            Response<BlobDownloadInfo> result = await blob.DownloadAsync();
            MemoryStream dataResult = new MemoryStream();
            await result.Value.Content.CopyToAsync(dataResult);
            Assert.AreEqual(expectedData.Length, dataResult.Length);
            TestHelper.AssertSequenceEqual(expectedData, dataResult.ToArray());
        }

        /// <summary>
        /// Override test for page-alligned results, leaving more arbitrary numbers to still run for other services.
        /// </summary>
        /// <returns></returns>
        [RecordedTest]
        public override async Task OpenWriteAsync_WithIntermediateFlushes()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            PageBlobClient client = GetResourceClient(disposingContainer.Container);

            // Act
            using (Stream stream = await OpenWriteAsync(client, overwrite: true, maxDataSize: 2 * Constants.KB, bufferSize: 2 * Constants.KB))
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII))
                {
                    writer.Write(new string('A', 512));
                    writer.Flush();

                    writer.Write(new string('B', 1024));
                    writer.Flush();

                    writer.Write(new string('C', 512));
                    writer.Flush();
                }
            }

            // Assert
            byte[] dataResult = (await DownloadAsync(client)).ToArray();
            Assert.AreEqual(new string('A', 512) + new string('B', 1024) + new string('C', 512), Encoding.ASCII.GetString(dataResult));

            await (AdditionalAssertions?.Invoke(client) ?? Task.CompletedTask);
        }
        #endregion
    }
}
