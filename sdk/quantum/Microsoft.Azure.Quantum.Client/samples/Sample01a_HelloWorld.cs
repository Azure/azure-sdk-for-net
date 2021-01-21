// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Azure.Identity;
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
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");
            string blobName = Randomize("sample-file");
            string filePath = CreateTempFile(SampleFileContent);
            #region Snippet:SampleSnippetsBlob_Upload
            // Get a connection string to our Azure Storage account.  You can
            // obtain your connection string from the Azure Portal (click
            // Access Keys under Settings in the Portal Storage account blade)
            // or using the Azure CLI with:
            //
            //     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
            //
            // And you can provide the connection string to your application
            // using an environment variable.

            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";
            //@@ string blobName = "sample-blob";
            //@@ string filePath = "sample-file";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.Create();

            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            BlobClient blob = container.GetBlobClient(blobName);

            // Upload local file
            blob.Upload(filePath);
            #endregion

            Assert.AreEqual(1, container.GetBlobs().Count());
            BlobProperties properties = blob.GetProperties();
            Assert.AreEqual(SampleFileContent.Length, properties.ContentLength);
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
            string downloadPath = CreateTempPath();

            #region Snippet:SampleSnippetsBlob_Download
            // Get a temporary path on disk where we can download the file
            //@@ string downloadPath = "hello.jpg";

            // Download the public blob at https://aka.ms/bloburl
            new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadTo(downloadPath);
            #endregion

            Assert.IsTrue(File.ReadAllBytes(downloadPath).Length > 0);
            File.Delete("hello.jpg");
        }

        /// <summary>
        /// List all the blobs in a container.
        /// </summary>
        [Test]
        public void List()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");
            string filePath = CreateTempFile();

            #region Snippet:SampleSnippetsBlob_List
            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";
            //@@ string filePath = "hello.jpg";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.Create();

            // Upload a few blobs so we have something to list
            container.UploadBlob("first", File.OpenRead(filePath));
            container.UploadBlob("second", File.OpenRead(filePath));
            container.UploadBlob("third", File.OpenRead(filePath));

            // Print out all the blob names
            foreach (BlobItem blob in container.GetBlobs())
            {
                Console.WriteLine(blob.Name);
            }
            #endregion

            List<string> names = new List<string>();
            foreach (BlobItem blob in container.GetBlobs())
            {
                names.Add(blob.Name);
            }
            Assert.AreEqual(3, names.Count);
            Assert.Contains("first", names);
            Assert.Contains("second", names);
            Assert.Contains("third", names);
            container.Delete();
        }

        /// <summary>
        /// Trigger a recoverable error.
        /// </summary>
        [Test]
        public void Errors()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            #region Snippet:SampleSnippetsBlob_Troubleshooting
            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";

            // Try to delete a container named "sample-container" and avoid any potential race conditions
            // that might arise by checking if the container is already deleted or is in the process
            // of being deleted.
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            try
            {
                container.Delete();
            }
            catch (RequestFailedException ex)
                when (ex.ErrorCode == BlobErrorCode.ContainerBeingDeleted ||
                      ex.ErrorCode == BlobErrorCode.ContainerNotFound)
            {
                // Ignore any errors if the container being deleted or if it has already been deleted
            }
            #endregion
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void Authenticate()
        {
            #region Snippet:SampleSnippetsBlob_Auth
            // Create a BlobServiceClient that will authenticate through Active Directory
            Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
            BlobServiceClient client = new BlobServiceClient(accountUri, new DefaultAzureCredential());
            #endregion
        }
    }
}
