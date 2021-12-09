// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System;
using System.Threading;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Extensions.Tables;

namespace Microsoft.Azure.WebJobs
{
    internal static class TableExtensions
    {
        public static void InsertOrReplace(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            var operation = table.CreateInsertOrReplaceOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }
        public static void Replace(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            var operation = table.CreateReplaceOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }
        public static void Insert(this CloudTable table, ITableEntity entity)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            var operation = table.CreateInsertOperation(entity);
            table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
        }
        public static TElement Retrieve<TElement>(this CloudTable table, string partitionKey, string rowKey)
            where TElement : ITableEntity, new()
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }
            var operation = table.CreateRetrieveOperation<TElement>(partitionKey, rowKey);
            TableResult result = table.ExecuteAsync(operation, CancellationToken.None).GetAwaiter().GetResult();
            return (TElement)result.Result;
        }
    }
}