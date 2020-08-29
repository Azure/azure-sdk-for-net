// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Wrapper around a CloudStorageAccount for abstractions and unit testing.
    /// This is handed out by <see cref="StorageAccountProvider"/>.
    /// CloudStorageAccount is not virtual, but all the other classes below it are.
    /// </summary>
    public class StorageAccount
    {
        private readonly IDelegatingHandlerProvider _delegatingHandlerProvider;
        private readonly string _connectionString;

        /// <summary>
        /// TODO.
        /// </summary>
        public StorageAccount()
        {
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="delegatingHandlerProvider"></param>
        /// <param name="connectionString"></param>
        public StorageAccount(IDelegatingHandlerProvider delegatingHandlerProvider, string connectionString)
        {
            _delegatingHandlerProvider = delegatingHandlerProvider;
            _connectionString = connectionString;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="accountConnectionString"></param>
        /// <returns></returns>
        public static StorageAccount NewFromConnectionString(string accountConnectionString)
        {
            return New(accountConnectionString, null);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="delegatingHandlerProvider"></param>
        /// <returns></returns>
        // TODO (kasobol-msft) delegating handler ?
        public static StorageAccount New(string connectionString, IDelegatingHandlerProvider delegatingHandlerProvider = null)
        {
            return new StorageAccount(delegatingHandlerProvider, connectionString);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDevelopmentStorageAccount()
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
            // TODO (kasobol-msft) is there better way?
            var blobServiceClient = CreateBlobServiceClient();
            return String.Equals(
                blobServiceClient.Uri.PathAndQuery.TrimStart('/'),
                blobServiceClient.AccountName,
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public virtual string Name
        {
            // TODO (kasobol-msft) is there better way?
            get { return CreateBlobServiceClient().AccountName; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public virtual BlobServiceClient CreateBlobServiceClient()
        {
            return new BlobServiceClient(_connectionString);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual QueueServiceClient CreateQueueServiceClient()
        {
            return new QueueServiceClient(_connectionString);
        }
    }
}
