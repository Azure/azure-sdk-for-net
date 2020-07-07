// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs
{
    static class TableExtensions
    {

        public static async Task<CloudTable> CreateTableAsync(this StorageAccount account, string tableName)
        {
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(tableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }

        public static void InsertOrReplace(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            var operation = table.CreateInsertOrReplaceOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }

        public static void Replace(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            var operation = table.CreateReplaceOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }

        public static void Insert(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            var operation = table.CreateInsertOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }

        public static TElement Retrieve<TElement>(this CloudTable table, string partitionKey, string rowKey)
            where TElement : ITableEntity, new()
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            var operation = table.CreateRetrieveOperation<TElement>(partitionKey, rowKey);
            TableResult result = table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
            return (TElement)result.Result;
        }
    }
}
