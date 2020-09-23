// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;

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
        private readonly string _connectionString;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="connectionString"></param>
        public StorageAccount(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="accountConnectionString"></param>
        /// <returns></returns>
        public static StorageAccount NewFromConnectionString(string accountConnectionString)
        {
            return new StorageAccount(accountConnectionString);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDevelopmentStorageAccount()
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
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
            get { return CreateBlobServiceClient().AccountName; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public virtual BlobServiceClient CreateBlobServiceClient()
        {
            var blobClientOptions = SkuUtility.IsDynamicSku ? new BlobClientOptions()
            {
                Transport = CreateTransportForDynamicSku()
            } : default;
            return new BlobServiceClient(_connectionString, blobClientOptions);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual QueueServiceClient CreateQueueServiceClient()
        {
            var queueClientOptions = SkuUtility.IsDynamicSku ? new QueueClientOptions()
            {
                Transport = CreateTransportForDynamicSku()
            } : default;
            return new QueueServiceClient(_connectionString, queueClientOptions);
        }

        private HttpPipelineTransport CreateTransportForDynamicSku()
        {
            return new HttpClientTransport(new HttpClient(new HttpClientHandler()
            {
                MaxConnectionsPerServer = 50
            }));
        }
    }
}
