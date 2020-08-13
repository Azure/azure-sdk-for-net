// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using CloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;

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
        /// Get the real azure storage account. Only use this if you explicitly need to bind to the <see cref="CloudStorageAccount"/>,
        /// else use the virtuals.
        /// </summary>
        public CloudStorageAccount SdkObject { get; protected set; }

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
            var account = CloudStorageAccount.Parse(accountConnectionString);
            return New(account, accountConnectionString);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="connectionString"></param>
        /// <param name="delegatingHandlerProvider"></param>
        /// <returns></returns>
        public static StorageAccount New(CloudStorageAccount account, string connectionString, IDelegatingHandlerProvider delegatingHandlerProvider = null)
        {
            return new StorageAccount(delegatingHandlerProvider, connectionString) { SdkObject = account };
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDevelopmentStorageAccount()
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
            return String.Equals(
                SdkObject.BlobEndpoint.PathAndQuery.TrimStart('/'),
                SdkObject.Credentials.AccountName,
                StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public virtual string Name
        {
            get { return SdkObject.Credentials.AccountName; }
        }

        /// <summary>
        /// TODO.
        /// </summary>
        public virtual Uri BlobEndpoint => SdkObject.BlobEndpoint;

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public virtual CloudBlobClient CreateCloudBlobClient()
        {
            return new CloudBlobClient(SdkObject.BlobStorageUri, SdkObject.Credentials, _delegatingHandlerProvider?.Create());
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
