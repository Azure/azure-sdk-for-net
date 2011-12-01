//-----------------------------------------------------------------------
// <copyright file="CloudStorageAccountStorageClientExtensions.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the CloudStorageAccountStorageClientExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;

    /// <summary>
    /// Provides a set of extensions to the <see cref="CloudStorageAccount"/> class that may be used to generate client objects for 
    /// the Windows Azure storage services.
    /// </summary>
    public static class CloudStorageAccountStorageClientExtensions
    {
        /// <summary>
        /// Creates a new Blob service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Blob service endpoint.</returns>
        public static CloudBlobClient CreateCloudBlobClient(this CloudStorageAccount account)
        {
            if (account.BlobEndpoint == null)
            {
                throw new InvalidOperationException("No blob endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided configured.");
            }

            return new CloudBlobClient(account.BlobEndpoint, account.Credentials);
        }

        /// <summary>
        /// Creates a new Queue service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Queue service endpoint.</returns>
        public static CloudQueueClient CreateCloudQueueClient(this CloudStorageAccount account)
        {
            if (account.QueueEndpoint == null)
            {
                throw new InvalidOperationException("No queue endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided.");
            }

            if (!account.Credentials.CanSignRequest)
            {
                throw new InvalidOperationException("CloudQueueClient requires a credential that can sign request");
            }

            return new CloudQueueClient(account.QueueEndpoint, account.Credentials);
        }

        /// <summary>
        /// Creates the Table service client.
        /// </summary>
        /// <param name="account">The storage account.</param>
        /// <returns>A client object that specifies the Table service endpoint.</returns>
        public static CloudTableClient CreateCloudTableClient(this CloudStorageAccount account)
        {
            if (account.TableEndpoint == null)
            {
                throw new InvalidOperationException("No table endpoint configured.");
            }

            if (account.Credentials == null)
            {
                throw new InvalidOperationException("No credentials provided.");
            }

            if (!account.Credentials.CanSignRequest || !account.Credentials.CanSignRequestLite)
            {
                throw new InvalidOperationException("CloudTableClient requires a credential that can sign request");
            }

            return new CloudTableClient(account.TableEndpoint, account.Credentials);
        }
    }
}
