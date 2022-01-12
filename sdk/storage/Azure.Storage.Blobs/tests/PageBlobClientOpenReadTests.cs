// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Tests
{
    public class PageBlobClientOpenReadTests : BlobBaseClientOpenReadTests<PageBlobClient>
    {
        public PageBlobClientOpenReadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Client-Specific Impl
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

        protected override async Task StageDataAsync(PageBlobClient client, Stream data)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            using Stream writeStream = await client.OpenWriteAsync(overwrite: true, position: 0, new PageBlobOpenWriteOptions
            {
                Size = data.Length
            });
            await data.CopyToAsync(writeStream);
        }

        protected override async Task ModifyDataAsync(PageBlobClient client, Stream data, ModifyDataMode mode)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            long position = mode switch
            {
                ModifyDataMode.Replace => 0,
                ModifyDataMode.Append => (await client.GetPropertiesAsync()).Value.ContentLength,
                _ => throw Errors.InvalidArgument(nameof(mode))
            };

            await client.ResizeAsync(position + data.Length);
            using Stream writeStream = await client.OpenWriteAsync(overwrite: false, position, new PageBlobOpenWriteOptions
            {
                Size = data.Length
            });
            await data.CopyToAsync(writeStream);
        }
        #endregion
    }
}
