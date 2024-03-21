// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
    public class AppendBlobClientOpenWriteTests : BlobBaseClientOpenWriteTests<AppendBlobClient>
    {
        public AppendBlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override AppendBlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string blobName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetAppendBlobClient(blobName);
            }

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetAppendBlobClient(blobName));
        }

        protected override async Task ModifyAsync(AppendBlobClient client, Stream data)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            // open write doesn't support modification, we need to manually edit the blob

            await client.AppendBlockAsync(data);
        }

        protected override Task<Stream> OpenWriteAsync(
            AppendBlobClient client,
            bool overwrite,
            long? maxDataSize,
            int? bufferSize = null,
            BlobRequestConditions conditions = null,
            Dictionary<string, string> metadata = null,
            HttpHeaderParameters httpHeaders = null,
            IProgress<long> progressHandler = null)
            => OpenWriteAsync(client, overwrite, maxDataSize, tags: default, bufferSize, conditions, metadata, httpHeaders, progressHandler);

        protected override async Task<Stream> OpenWriteAsync(
            AppendBlobClient client,
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
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "AppendBlobClient.OpenWriteAsync() does not support metadata.");
            }
            if (tags != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "AppendBlobClient.OpenWriteAsync() does not support tags.");
            }
            if (httpHeaders != default)
            {
                TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "AppendBlobClient.OpenWriteAsync() does not support httpHeaders.");
            }

            AppendBlobRequestConditions appendConditions = conditions == default ? default : new AppendBlobRequestConditions
            {
                IfModifiedSince = conditions.IfModifiedSince,
                IfUnmodifiedSince = conditions.IfUnmodifiedSince,
                IfMatch = conditions.IfMatch,
                IfNoneMatch = conditions.IfNoneMatch,
                LeaseId = conditions.LeaseId,
            };
            return await client.OpenWriteAsync(overwrite, new AppendBlobOpenWriteOptions
            {
                BufferSize = bufferSize,
                OpenConditions = appendConditions,
                ProgressHandler = progressHandler
            });
        }

        #region Tests
        [RecordedTest]
        public async Task OpenWriteAsync_AppendExistingBlob()
        {
            await using IDisposingContainer<BlobContainerClient> disposingContainer = await GetDisposingContainerAsync();
            AppendBlobClient blob = GetResourceClient(disposingContainer.Container);
            await blob.CreateAsync();

            byte[] originalData = GetRandomBuffer(Constants.KB);
            using Stream originalStream = new MemoryStream(originalData);

            await blob.AppendBlockAsync(content: originalStream);

            byte[] newData = GetRandomBuffer(Constants.KB);
            using Stream newStream = new MemoryStream(newData);

            // Act
            Stream openWriteStream = await blob.OpenWriteAsync(overwrite: false);
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
        #endregion
    }
}
