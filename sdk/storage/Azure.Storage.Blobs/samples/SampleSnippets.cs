// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Samples.Tests
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class SampleSnippets
    {

        [Test]
        public void Upload()
        {
            string connectionString = "<connection_string>";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, "sample-container");
            container.Create();

            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            BlobClient blob = container.GetBlobClient("sample-file");

            // Upload a local file
            blob.Upload(@"local-file.jpg");
        }

        [Test]
        public void Download()
        {
            // Get a reference to the public blob at https://aka.ms/bloburl
            BlobClient blob = new BlobClient(new Uri("https://aka.ms/bloburl"));

            // Download the blob
            Response<BlobDownloadInfo> download = blob.Download();
            using (FileStream file = File.OpenWrite("hello.jpg"))
            {
                download.Value.Content.CopyTo(file);
            }
        }

        [Test]
        public void List()
        {
            string connectionString = "<connection_string>";

            // Get a reference to a container named "sample-container"
            BlobContainerClient container = new BlobContainerClient(connectionString, "sample-container");

            // List all of its blobs
            foreach (BlobItem blob in container.GetBlobs())
            {
                Console.WriteLine(blob.Name);
            }
        }

        [Test]
        public async Task DownloadAsync()
        {
            // Get a reference to the public blob at https://aka.ms/bloburl
            BlobClient blob = new BlobClient(new Uri("https://aka.ms/bloburl"));

            // Download the blob
            Response<BlobDownloadInfo> download = await blob.DownloadAsync();
            using (FileStream file = File.OpenWrite("hello.jpg"))
            {
                await download.Value.Content.CopyToAsync(file);
            }
        }

        [Test]
        public 
    }
}
