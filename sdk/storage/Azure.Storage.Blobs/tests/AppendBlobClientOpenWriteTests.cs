// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
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
                Assert.Inconclusive("PageBlobClient.OpenWriteAsync() does not support metadata.");
            }
            if (tags != default)
            {
                Assert.Inconclusive("PageBlobClient.OpenWriteAsync() does not support tags.");
            }
            if (httpHeaders != default)
            {
                Assert.Inconclusive("PageBlobClient.OpenWriteAsync() does not support httpHeaders.");
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
    }
}
