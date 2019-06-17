// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using NUnit.Framework;

#pragma warning disable CA2007
#pragma warning disable IDE0007
#pragma warning disable IDE0059 // Value assigned to symbol is never used.  Keeping all these for the sake of the sample.

namespace Azure.Storage.Samples
{
    [TestFixture]
    public partial class BlobSamples
    {
        [Test]
        [Category("Live")]
        public async Task ContainerSample()
        {
            // Instantiate a new BlobServiceClient using a connection string.
            BlobServiceClient blobServiceClient = new BlobServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new BlobContainerClient
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient($"mycontainer-{Guid.NewGuid()}");
            try
            {
                // Create new Container in the Service
                await blobContainerClient.CreateAsync();

                // List Containers
                Response<ContainersSegment> listResponse = await blobServiceClient.ListContainersSegmentAsync();
            }
            finally
            {
                // Delete Container in the Service
                await blobContainerClient.DeleteAsync();
            }
        }

        [Test]
        [Category("Live")]
        public async Task BlockBlobSample()
        {
            // Instantiate a new BlobServiceClient using a connection string.
            BlobServiceClient blobServiceClient = new BlobServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new BlobContainerClient
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient($"mycontainer2-{Guid.NewGuid()}");
            try
            {
                // Create new Container in the Service
                await blobContainerClient.CreateAsync();

                // Instantiate a new BlockBlobClient
                BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient("myblockblob");

                // Upload content to BlockBlob
                using (FileStream fileStream = File.OpenRead("Samples/SampleSource.txt"))
                {
                    await blockBlobClient.UploadAsync(fileStream);
                }

                // Download BlockBlob
                using (FileStream fileStream = File.Create("BlockDestination.txt"))
                {
                    Response<BlobDownloadInfo> downloadResponse = await blockBlobClient.DownloadAsync();
                    await downloadResponse.Value.Content.CopyToAsync(fileStream);
                }

                // Delete BlockBlob in the Service
                await blockBlobClient.DeleteAsync();
            }
            finally
            {
                // Delete Container in the Service
                await blobContainerClient.DeleteAsync();
            }
        }

        [Test]
        [Category("Live")]
        public async Task PageBlobSample()
        {
            // Instantiate a new BlobServiceClient using a connection string.
            BlobServiceClient blobServiceClient = new BlobServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new BlobContainerClient
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient($"mycontainer3-{Guid.NewGuid()}");
            try
            {
                // Create new Container in the Service
                await blobContainerClient.CreateAsync();

                // Instantiate a new PageBlobClient
                PageBlobClient pageBlobClient = blobContainerClient.GetPageBlobClient("pageblob");

                // Create PageBlob in the Service
                await pageBlobClient.CreateAsync(size: 1024);

                // Upload content to PageBlob
                using (FileStream fileStream = File.OpenRead("Samples/SampleSource.txt"))
                {
                    await pageBlobClient.UploadPagesAsync(
                        content: fileStream,
                        offset: 0);
                }

                // Download PageBlob
                using (FileStream fileStream = File.Create("PageDestination.txt"))
                {
                    Response<BlobDownloadInfo> downloadResponse = await pageBlobClient.DownloadAsync();
                    await downloadResponse.Value.Content.CopyToAsync(fileStream);
                }

                // Delete PageBlob in the Service
                await pageBlobClient.DeleteAsync();
            }
            finally
            {
                // Delete Container in the Service
                await blobContainerClient.DeleteAsync();
            }
        }

        [Test]
        [Category("Live")]
        public async Task AppendBlobSample()
        {
            // Instantiate a new BlobServiceClient using a connection string.
            BlobServiceClient blobServiceClient = new BlobServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new BlobContainerClient
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient($"mycontainer4-{Guid.NewGuid()}");
            try
            {
                // Create new Container in the Service
                await blobContainerClient.CreateAsync();

                // Instantiate a new PageBlobClient
                AppendBlobClient appendBlobClient = blobContainerClient.GetAppendBlobClient("appendblob");

                // Create PageBlob in the Service
                await appendBlobClient.CreateAsync();

                // Append content to AppendBlob
                using (FileStream fileStream = File.OpenRead("Samples/SampleSource.txt"))
                {
                    await appendBlobClient.AppendBlockAsync(fileStream);
                }

                // Download PageBlob
                using (FileStream fileStream = File.Create("AppendDestination.txt"))
                {
                    Response<BlobDownloadInfo> downloadResponse = await appendBlobClient.DownloadAsync();
                    await downloadResponse.Value.Content.CopyToAsync(fileStream);
                }

                // Delete PageBlob in the Service
                await appendBlobClient.DeleteAsync();
            }
            finally
            {
                // Delete Container in the Service
                await blobContainerClient.DeleteAsync();
            }
        }
    }
}

#pragma warning restore CA2007
#pragma warning restore IDE0007
#pragma warning restore IDE0059
