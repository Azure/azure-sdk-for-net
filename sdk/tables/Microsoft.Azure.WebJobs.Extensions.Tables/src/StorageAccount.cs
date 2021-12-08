// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Extensions.Tables;
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
            var tableAccount = TableStorageAccount.Parse(accountConnectionString);
            return New(tableAccount);
        }

        public static StorageAccount New(TableStorageAccount tableAccount = null, IDelegatingHandlerProvider delegatingHandlerProvider = null)
        {
            return new StorageAccount(delegatingHandlerProvider) { TableSdkObject = tableAccount };
        }

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

        public string Name => TableSdkObject.TableEndpoint.AbsoluteUri;
    }
}