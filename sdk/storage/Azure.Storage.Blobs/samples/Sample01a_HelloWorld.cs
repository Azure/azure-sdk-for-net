// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Samples
{
    /// <summary>
    /// Basic Azure Blob Storage samples
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        /// <summary>
        /// Upload a file to a blob.
        /// </summary>
        [Test]
        public void Upload()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string path = CreateTempFile(SampleFileContent);

            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            // 
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            // 
            // And you can provide the connection string to your application
            // using an environment variable.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            container.Create();
            try
            {
                // Get a reference to a blob named "sample-file" in a container named "sample-container"
                BlobClient blob = container.GetBlobClient(Randomize("sample-file"));

                // Open the file and upload its data
                using (FileStream file = File.OpenRead(path))
                {
                    blob.Upload(file);
                }

                // Verify we uploaded one blob with some content
                Assert.AreEqual(1, container.GetBlobs().Count());
                BlobProperties properties = blob.GetProperties();
                Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Download a blob to a file.
        /// </summary>
        [Test]
        public void Download()
        {
            // Create a temporary Lorem Ipsum file on disk that we can upload
            string originalPath = CreateTempFile(SampleFileContent);

            // Get a temporary path on disk where we can download the file
            string downloadPath = CreateTempPath();

            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            container.Create();
            try
            {
                // Get a reference to a blob named "sample-file"
                BlobClient blob = container.GetBlobClient(Randomize("sample-file"));

                // First upload something the blob so we have something to download
                blob.Upload(File.OpenRead(originalPath));

                // Download the blob's contents and save it to a file
                BlobDownloadInfo download = blob.Download();
                using (FileStream file = File.OpenWrite(downloadPath))
                {
                    download.Content.CopyTo(file);
                }

                // Verify the contents
                Assert.AreEqual(SampleFileContent, File.ReadAllText(downloadPath));
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Download our sample image.
        /// </summary>
        [Test]
        public void DownloadImage()
        {
            // Download the public blob at https://aka.ms/bloburl
            BlobDownloadInfo download = new BlobClient(new Uri("https://aka.ms/bloburl")).Download();
            using (FileStream file = File.OpenWrite("hello.jpg"))
            {
                download.Content.CopyTo(file);
            }
        }

        /// <summary>
        /// List all the blobs in a container.
        /// </summary>
        [Test]
        public void List()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            container.Create();
            try
            {
                // Upload a couple of blobs so we have something to list
                container.UploadBlob("first", File.OpenRead(CreateTempFile()));
                container.UploadBlob("second", File.OpenRead(CreateTempFile()));
                container.UploadBlob("third", File.OpenRead(CreateTempFile()));

                // List all the blobs
                List<string> names = new List<string>();
                foreach (BlobItem blob in container.GetBlobs())
                {
                    names.Add(blob.Name);
                }

                Assert.AreEqual(3, names.Count);
                Assert.Contains("first", names);
                Assert.Contains("second", names);
                Assert.Contains("third", names);
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public void Errors()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, Randomize("sample-container"));
            container.Create();

            try
            {
                // Try to create the container again
                container.Create();
            }
            catch (StorageRequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.ContainerAlreadyExists)
            {
                // Ignore any errors if the container already exists
            }
            catch (StorageRequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }

            // Clean up after the test when we're finished
            container.Delete();
        }
    }
}
