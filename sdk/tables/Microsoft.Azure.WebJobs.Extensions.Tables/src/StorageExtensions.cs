// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal static class StorageExtensions
    {
        // $$$ Move to better place. From
        internal static void ValidateContractCompatibility<TPath>(this IBindablePath<TPath> path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            BindingTemplateExtensions.ValidateContractCompatibility(path.ParameterNames, bindingDataContract);
        }

        public static TableOperation CreateInsertOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.Insert(entity);
            return sdkOperation;
        }

        public static TableOperation CreateInsertOrReplaceOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.InsertOrReplace(entity);
            return sdkOperation;
        }

        public static TableOperation CreateReplaceOperation(this CloudTable sdk, ITableEntity entity)
        {
            var sdkOperation = TableOperation.Replace(entity);
            return sdkOperation;
        }

        public static TableOperation CreateRetrieveOperation<TElement>(this CloudTable table, string partitionKey, string rowKey)
            where TElement : ITableEntity, new()
        {
            return Retrieve<TElement>(partitionKey, rowKey);
        }

        public static TableOperation Retrieve<TElement>(string partitionKey, string rowKey) where TElement : ITableEntity, new()
        {
            TableOperation sdkOperation = TableOperation.Retrieve<TElement>(partitionKey, rowKey);
            return sdkOperation;
        }
    }
}