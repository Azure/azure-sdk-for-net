// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class AppendBlobClientOpenReadTests : BlobBaseClientOpenReadTests<AppendBlobClient>
    {
        public AppendBlobClientOpenReadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Client-Specific Impl
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

        protected override async Task StageDataAsync(AppendBlobClient client, Stream data)
        {
            using Stream writeStream = await client.OpenWriteAsync(overwrite: true);
            await data.CopyToAsync(writeStream);
        }

        protected override async Task ModifyDataAsync(AppendBlobClient client, Stream data, ModifyDataMode mode)
        {
            if (mode == ModifyDataMode.Replace)
            {
                // test framework won't save recordings for inconclusive tests
                // need to pass when recording to have a recording in CI
                if (Recording.Mode == Core.TestFramework.RecordedTestMode.Record)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Inconclusive();
                }
            }

            using Stream writeStream = await client.OpenWriteAsync(overwrite: false);
            await data.CopyToAsync(writeStream);
        }
        #endregion
    }
}
