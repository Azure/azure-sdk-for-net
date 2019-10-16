// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage;
using Azure.Storage.Blobs;
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
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            container.Create();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                foo.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Foo!")));
                bar.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Bar!")));
                baz.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Baz!")));

                // Delete all three blobs at once
                BlobBatchClient batch = service.GetBlobBatchClient();
                batch.DeleteBlobs(new Uri[] { foo.Uri, bar.Uri, baz.Uri });
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Set several blob access tiers in one request.
        /// </summary>
        [Test]
        public void BatchSetAccessTier()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            container.Create();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                foo.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Foo!")));
                bar.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Bar!")));
                baz.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Baz!")));

                // Set the access tier for all three blobs at once
                BlobBatchClient batch = service.GetBlobBatchClient();
                batch.SetBlobsAccessTier(new Uri[] { foo.Uri, bar.Uri, baz.Uri }, AccessTier.Cool);
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Exert fine-grained control over individual operations in a batch
        /// request.
        /// </summary>
        [Test]
        public void FineGrainedBatching()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            container.Create();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                foo.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Foo!")));
                bar.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Bar!")));
                baz.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Baz!")));

                // Create a batch with three deletes
                BlobBatchClient batchClient = service.GetBlobBatchClient();
                BlobBatch batch = batchClient.CreateBatch();
                Response fooResponse = batch.DeleteBlob(foo.Uri, DeleteSnapshotsOption.Include);
                Response barResponse = batch.DeleteBlob(bar.Uri);
                Response bazResponse = batch.DeleteBlob(baz.Uri);

                // Submit the batch
                batchClient.SubmitBatch(batch);

                // Verify the results
                Assert.AreEqual(202, fooResponse.Status);
                Assert.AreEqual(202, barResponse.Status);
                Assert.AreEqual(202, bazResponse.Status);
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }

        /// <summary>
        /// Catch any errors from a failed sub-operation.
        /// </summary>
        [Test]
        public void BatchErrors()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            container.Create();
            try
            {
                // Create a blob named "valid"
                BlobClient valid = container.GetBlobClient("valid");
                valid.Upload(new MemoryStream(Encoding.UTF8.GetBytes("Valid!")));

                // Get a reference to a blob named "invalid", but never create it
                BlobClient invalid = container.GetBlobClient("invalid");

                // Delete both blobs at the same time
                BlobBatchClient batch = service.GetBlobBatchClient();
                batch.DeleteBlobs(new Uri[] { valid.Uri, invalid.Uri });
            }
            catch (AggregateException ex)
            {
                // An aggregate exception is thrown for all the indivudal failures
                Assert.AreEqual(1, ex.InnerExceptions.Count);
                StorageRequestFailedException failure = ex.InnerException as StorageRequestFailedException;
                Assert.IsTrue(BlobErrorCode.BlobNotFound == failure.ErrorCode);
            }
            finally
            {
                // Clean up after the test when we're finished
                container.Delete();
            }
        }
    }
}
