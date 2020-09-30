// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    /// <summary>
    /// Wrapper around a CloudStorageAccount for abstractions and unit testing.
    /// This is handed out by <see cref="StorageAccountProvider"/>.
    /// CloudStorageAccount is not virtual, but all the other classes below it are.
    /// </summary>
    // TODO (kasobol-msft) split this between blobs and queues.
    public class StorageAccount
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly QueueServiceClient _queueServiceClient;

        /// <summary>
        /// TODO.
        /// </summary>
        public StorageAccount(BlobServiceClient blobServiceClient, QueueServiceClient queueServiceClient)
        {
            _blobServiceClient = blobServiceClient;
            _queueServiceClient = queueServiceClient;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="accountConnectionString"></param>
        /// <returns></returns>
        public static StorageAccount NewFromConnectionString(string accountConnectionString)
        {
            return new StorageAccount(new BlobServiceClient(accountConnectionString), new QueueServiceClient(accountConnectionString));
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDevelopmentStorageAccount()
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
            var blobServiceClient = _blobServiceClient;
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
            get { return _blobServiceClient.AccountName; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public virtual BlobServiceClient CreateBlobServiceClient() => _blobServiceClient;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual QueueServiceClient CreateQueueServiceClient() => _queueServiceClient;
    }
}
