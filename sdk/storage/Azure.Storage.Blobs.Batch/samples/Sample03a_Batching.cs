// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Identity;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Samples
{
    /// <summary>
    /// Basic Azure Blob Storage batching samples
    /// </summary>
    public class Sample03a_Batching : SampleTest
    {
        /// <summary>
        /// Delete several blobs in one request.
        /// </summary>
        [Test]
        public void BatchDelete()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            #region Snippet:SampleSnippetsBatch_DeleteBatch

            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            container.Create();

            // Create three blobs named "foo", "bar", and "baz"
            BlobClient foo = container.GetBlobClient("foo");
            BlobClient bar = container.GetBlobClient("bar");
            BlobClient baz = container.GetBlobClient("baz");
            foo.Upload(BinaryData.FromString("Foo!"));
            bar.Upload(BinaryData.FromString("Bar!"));
            baz.Upload(BinaryData.FromString("Baz!"));

            // Delete all three blobs at once
            BlobBatchClient batch = service.GetBlobBatchClient();
            batch.DeleteBlobs(new Uri[] { foo.Uri, bar.Uri, baz.Uri });
            #endregion

            Assert.AreEqual(0, container.GetBlobs().ToList().Count);
            // Clean up after we're finished
            container.Delete();
        }

        /// <summary>
        /// Set several blob access tiers in one request.
        /// </summary>
        [Test]
        public void BatchSetAccessTierCool()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            #region Snippet:SampleSnippetsBatch_AccessTier
            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            container.Create();
            // Create three blobs named "foo", "bar", and "baz"
            BlobClient foo = container.GetBlobClient("foo");
            BlobClient bar = container.GetBlobClient("bar");
            BlobClient baz = container.GetBlobClient("baz");
            foo.Upload(BinaryData.FromString("Foo!"));
            bar.Upload(BinaryData.FromString("Bar!"));
            baz.Upload(BinaryData.FromString("Baz!"));

            // Set the access tier for all three blobs at once
            BlobBatchClient batch = service.GetBlobBatchClient();
            batch.SetBlobsAccessTier(new Uri[] { foo.Uri, bar.Uri, baz.Uri }, AccessTier.Cool);
            #endregion

            foreach (BlobItem blob in container.GetBlobs())
            {
                Assert.AreEqual(AccessTier.Cool, blob.Properties.AccessTier);
            }
            // Clean up after the test when we're finished
        }

        /// <summary>
        /// Exert fine-grained control over individual operations in a batch
        /// request.
        /// </summary>
        [Test]
        public void FineGrainedBatching()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            #region Snippet:SampleSnippetsBatch_FineGrainedBatching
            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            container.Create();

            // Create three blobs named "foo", "bar", and "baz"
            BlobClient foo = container.GetBlobClient("foo");
            BlobClient bar = container.GetBlobClient("bar");
            BlobClient baz = container.GetBlobClient("baz");
            foo.Upload(BinaryData.FromString("Foo!"));
            foo.CreateSnapshot();
            bar.Upload(BinaryData.FromString("Bar!"));
            bar.CreateSnapshot();
            baz.Upload(BinaryData.FromString("Baz!"));

            // Create a batch with three deletes
            BlobBatchClient batchClient = service.GetBlobBatchClient();
            BlobBatch batch = batchClient.CreateBatch();
            batch.DeleteBlob(foo.Uri, DeleteSnapshotsOption.IncludeSnapshots);
            batch.DeleteBlob(bar.Uri, DeleteSnapshotsOption.OnlySnapshots);
            batch.DeleteBlob(baz.Uri);

            // Submit the batch
            batchClient.SubmitBatch(batch);
            #endregion

            GetBlobsOptions options = new GetBlobsOptions
            {
                States = BlobStates.Snapshots
            };

            Pageable<BlobItem> blobs = container.GetBlobs(options);
            Assert.AreEqual(1, blobs.Count());
            Assert.AreEqual("bar", blobs.FirstOrDefault().Name);
            // Clean up after the test when we're finished
            container.Delete();
        }

        /// <summary>
        /// Catch any errors from a failed sub-operation.
        /// </summary>
        [Test]
        public void BatchErrors()
        {
            string connectionString = ConnectionString;
            string containerName = Randomize("sample-container");

            #region Snippet:SampleSnippetsBatch_Troubleshooting
            // Get a connection string to our Azure Storage account.
            //@@ string connectionString = "<connection_string>";
            //@@ string containerName = "sample-container";

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(containerName);
            container.Create();

            // Create a blob named "valid"
            BlobClient valid = container.GetBlobClient("valid");
            valid.Upload(BinaryData.FromString("Valid!"));

            // Get a reference to a blob named "invalid", but never create it
            BlobClient invalid = container.GetBlobClient("invalid");

            // Delete both blobs at the same time
            BlobBatchClient batch = service.GetBlobBatchClient();
            try
            {
                batch.DeleteBlobs(new Uri[] { valid.Uri, invalid.Uri });
            }
            catch (AggregateException)
            {
                // An aggregate exception is thrown for all the individual failures
                // Check ex.InnerExceptions for RequestFailedException instances
            }
            #endregion
        }

        /// <summary>
        /// Authenticate with <see cref="DefaultAzureCredential"/>.
        /// </summary>
        public void Authenticate()
        {
            #region Snippet:SampleSnippetsBlobBatch_Auth
            // Create a BlobServiceClient that will authenticate through Active Directory
            Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
            BlobServiceClient client = new BlobServiceClient(accountUri, new DefaultAzureCredential());
            BlobBatchClient batch = client.GetBlobBatchClient();
            #endregion
        }
    }
}
