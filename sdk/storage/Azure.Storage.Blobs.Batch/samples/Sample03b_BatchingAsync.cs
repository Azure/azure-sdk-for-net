// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
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
    public class Sample03b_BatchingAsync : SampleTest
    {
        /// <summary>
        /// Delete several blobs in one request.
        /// </summary>
        [Test]
        public async Task BatchDeleteAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                await foo.UploadAsync(BinaryData.FromString("Foo!"));
                await bar.UploadAsync(BinaryData.FromString("Bar!"));
                await baz.UploadAsync(BinaryData.FromString("Baz!"));

                // Delete all three blobs at once
                BlobBatchClient batch = service.GetBlobBatchClient();
                await batch.DeleteBlobsAsync(new Uri[] { foo.Uri, bar.Uri, baz.Uri });
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Set several blob access tiers in one request.
        /// </summary>
        [Test]
        public async Task BatchSetAccessTierAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                await foo.UploadAsync(BinaryData.FromString("Foo!"));
                await bar.UploadAsync(BinaryData.FromString("Bar!"));
                await baz.UploadAsync(BinaryData.FromString("Baz!"));

                // Set the access tier for all three blobs at once
                BlobBatchClient batch = service.GetBlobBatchClient();
                await batch.SetBlobsAccessTierAsync(new Uri[] { foo.Uri, bar.Uri, baz.Uri }, AccessTier.Cool);
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Exert fine-grained control over individual operations in a batch
        /// request.
        /// </summary>
        [Test]
        public async Task FineGrainedBatchingAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Create three blobs named "foo", "bar", and "baz"
                BlobClient foo = container.GetBlobClient("foo");
                BlobClient bar = container.GetBlobClient("bar");
                BlobClient baz = container.GetBlobClient("baz");
                await foo.UploadAsync(BinaryData.FromString("Foo!"));
                await bar.UploadAsync(BinaryData.FromString("Bar!"));
                await baz.UploadAsync(BinaryData.FromString("Baz!"));

                // Create a batch with three deletes
                BlobBatchClient batchClient = service.GetBlobBatchClient();
                BlobBatch batch = batchClient.CreateBatch();
                Response fooResponse = batch.DeleteBlob(foo.Uri, DeleteSnapshotsOption.IncludeSnapshots);
                Response barResponse = batch.DeleteBlob(bar.Uri);
                Response bazResponse = batch.DeleteBlob(baz.Uri);

                // Submit the batch
                await batchClient.SubmitBatchAsync(batch);

                // Verify the results
                Assert.AreEqual(202, fooResponse.Status);
                Assert.AreEqual(202, barResponse.Status);
                Assert.AreEqual(202, bazResponse.Status);
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }

        /// <summary>
        /// Catch any errors from a failed sub-operation.
        /// </summary>
        [Test]
        public async Task BatchErrorsAsync()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Get a reference to a container named "sample-container" and then create it
            BlobServiceClient service = new BlobServiceClient(connectionString);
            BlobContainerClient container = service.GetBlobContainerClient(Randomize("sample-container"));
            await container.CreateAsync();
            try
            {
                // Create a blob named "valid"
                BlobClient valid = container.GetBlobClient("valid");
                await valid.UploadAsync(BinaryData.FromString("Valid!"));

                // Get a reference to a blob named "invalid", but never create it
                BlobClient invalid = container.GetBlobClient("invalid");

                // Delete both blobs at the same time
                BlobBatchClient batch = service.GetBlobBatchClient();
                await batch.DeleteBlobsAsync(new Uri[] { valid.Uri, invalid.Uri });
            }
            catch (AggregateException ex)
            {
                // An aggregate exception is thrown for all the indivudal failures
                Assert.AreEqual(1, ex.InnerExceptions.Count);
                RequestFailedException failure = ex.InnerException as RequestFailedException;
                Assert.IsTrue(BlobErrorCode.BlobNotFound == failure.ErrorCode);
            }
            finally
            {
                // Clean up after the test when we're finished
                await container.DeleteAsync();
            }
        }
    }
}
