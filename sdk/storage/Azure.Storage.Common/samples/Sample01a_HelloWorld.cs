// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Storage.Samples
{
    /// <summary>
    /// Basic Azure Storage samples
    /// </summary>
    public class Sample01a_HelloWorld : SampleTest
    {
        [Test]
        public void ConfigureRetries()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Create our client options and customize our retries
            BlobClientOptions options = new BlobClientOptions();
            options.Retry.MaxRetries = 5;

            // Create our client and make a simple request
            BlobServiceClient client = new BlobServiceClient(connectionString, options);
            client.GetProperties();
        }

        [Test]
        public void ApplyServerTimeout()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = ConnectionString;

            // Create our client options and customize our retries
            BlobClientOptions options = new BlobClientOptions();
            options.Retry.MaxRetries = 5;

            // Create our client and make a simple request
            #region Snippet:Sample_StorageServerTimeout
            BlobServiceClient client = new BlobServiceClient(connectionString, options);
            using (StorageExtensions.CreateServiceTimeoutScope(TimeSpan.FromSeconds(10)))
            {
                client.GetProperties();
            }
            #endregion
        }
    }
}
