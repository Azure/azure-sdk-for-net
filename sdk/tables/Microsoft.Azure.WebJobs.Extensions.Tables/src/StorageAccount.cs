// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Extensions.Tables;
using CloudStorageAccount = Microsoft.Azure.Storage.CloudStorageAccount;
using TableStorageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Wrapper around a CloudStorageAccount for abstractions and unit testing.
    /// This is handed out by <see cref="StorageAccountProvider"/>.
    /// CloudStorageAccount is not virtual, but all the other classes below it are.
    /// </summary>
    internal class StorageAccount
    {
        private readonly IDelegatingHandlerProvider _delegatingHandlerProvider;

        /// <summary>
        /// Get the real azure storage account. Only use this if you explicitly need to bind to the <see cref="CloudStorageAccount"/>,
        /// else use the virtuals.
        /// </summary>
        public CloudStorageAccount SdkObject { get; protected set; }

        public TableStorageAccount TableSdkObject { get; protected set; }

        public StorageAccount()
        {
        }

        public StorageAccount(IDelegatingHandlerProvider delegatingHandlerProvider)
        {
            _delegatingHandlerProvider = delegatingHandlerProvider;
        }

        public static StorageAccount NewFromConnectionString(string accountConnectionString)
        {
            var account = CloudStorageAccount.Parse(accountConnectionString);
            var tableAccount = TableStorageAccount.Parse(accountConnectionString);
            return New(account, tableAccount);
        }

        public static StorageAccount New(CloudStorageAccount account, TableStorageAccount tableAccount = null, IDelegatingHandlerProvider delegatingHandlerProvider = null)
        {
            return new StorageAccount(delegatingHandlerProvider) { SdkObject = account, TableSdkObject = tableAccount };
        }

        public virtual bool IsDevelopmentStorageAccount()
        {
            // see the section "Addressing local storage resources" in http://msdn.microsoft.com/en-us/library/windowsazure/hh403989.aspx
            return String.Equals(
                SdkObject.BlobEndpoint.PathAndQuery.TrimStart('/'),
                SdkObject.Credentials.AccountName,
                StringComparison.OrdinalIgnoreCase);
        }

        public virtual string Name => SdkObject.Credentials.AccountName;

        public virtual CloudTableClient CreateCloudTableClient()
        {
            var restConfiguration = new RestExecutorConfiguration()
            {
                DelegatingHandler = _delegatingHandlerProvider?.Create()
            };
            var configuration = new TableClientConfiguration
            {
                RestExecutorConfiguration = restConfiguration
            };
            return new CloudTableClient(TableSdkObject.TableStorageUri, TableSdkObject.Credentials, configuration);
        }
    }
}