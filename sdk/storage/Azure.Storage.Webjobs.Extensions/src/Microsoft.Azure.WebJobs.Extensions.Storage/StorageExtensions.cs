// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;

namespace Microsoft.Azure.WebJobs
{
    internal static class StorageExtensions
    {
        // $$$ Move to better place. From 
        internal static void ValidateContractCompatibility<TPath>(this IBindablePath<TPath> path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            BindingTemplateExtensions.ValidateContractCompatibility(path.ParameterNames, bindingDataContract);
        }


        public static string GetBlobPath(this ICloudBlob blob)
        {
            return ToBlobPath(blob).ToString();
        }

        public static BlobPath ToBlobPath(this ICloudBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            return new BlobPath(blob.Container.Name, blob.Name);
        }

        public static Task<TableResult> ExecuteAsync(this CloudTable table, TableOperation operation, CancellationToken cancellationToken)
        {
            return table.ExecuteAsync(operation, null, null, cancellationToken);
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

        public static Task<TableBatchResult> ExecuteBatchAsync(this CloudTable sdk, TableBatchOperation batch,
    CancellationToken cancellationToken)
        {
            return sdk.ExecuteBatchAsync(batch, cancellationToken);
        }

        public static Task CreateIfNotExistsAsync(this CloudTable sdk, CancellationToken cancellationToken)
        {
            return sdk.CreateIfNotExistsAsync(requestOptions: null, operationContext: null, cancellationToken: cancellationToken);
        }
    }
}
