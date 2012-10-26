// -----------------------------------------------------------------------------------------
// <copyright file="TableBatchOperation.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a batch operation on a table.
    /// </summary>
    public sealed partial class TableBatchOperation : IList<TableOperation>
    {
        #region Factories
        /// <summary>
        /// Inserts a <see cref="TableOperation"/> into the batch that retrieves an entity based on its row key and partition key. The entity will be deserialzed into the specified class type which extends <see cref="ITableEntity"/>.
        /// </summary>
        /// <typeparam name="TElement">The class of type for the entity to retrieve.</typeparam>
        /// <param name="partitionKey">A string containing the partition key of the entity to retrieve.</param>
        /// <param name="rowkey">A string containing the row key of the entity to retrieve.</param>        
        public void Retrieve<TElement>(string partitionKey, string rowkey) where TElement : ITableEntity
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Add the table operation.
            this.Add(new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => EntityUtilities.ResolveEntityByType<TElement>(pk, rk, ts, prop, etag) });
        }

        /// <summary>
        /// Adds a table operation to retrieve an entity of the specified class type with the specified partition key and row key to the batch operation.
        /// </summary>
        /// <typeparam name="R">The return type which the specified <see cref="EntityResolver{T}"/> will resolve the given entity to.</typeparam>
        /// <param name="partitionKey">A string containing the partition key of the entity to retrieve.</param>
        /// <param name="rowkey">A string containing the row key of the entity to retrieve.</param>
        /// <param name="resolver">The <see cref="EntityResolver{T}"/> implementation to project the entity to retrieve as a particular type in the result.</param>
        public void Retrieve<R>(string partitionKey, string rowkey, EntityResolver<R> resolver)
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Add the table operation.
            this.Add(new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => resolver(pk, rk, ts, prop, etag) });
        }

        #endregion

        [DoesServiceRequest]
        internal IList<TableResult> Execute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            if (this.operations.Count == 0)
            {
                throw new ArgumentOutOfRangeException(SR.EmptyBatchOperation);
            }

            return Executor.ExecuteSync(BatchImpl(this, client, tableName, modifiedOptions), modifiedOptions.RetryPolicy, operationContext);
        }

        [DoesServiceRequest]
        internal ICancellableAsyncResult BeginExecute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            if (this.operations.Count == 0)
            {
                throw new ArgumentOutOfRangeException(SR.EmptyBatchOperation);
            }

            return Executor.BeginExecuteAsync(
                                          BatchImpl(this, client, tableName, modifiedOptions),
                                          modifiedOptions.RetryPolicy,
                                          operationContext,
                                          callback,
                                          state);
        }

        internal IList<TableResult> EndExecute(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<IList<TableResult>>(asyncResult);
        }

        private static RESTCommand<IList<TableResult>> BatchImpl(TableBatchOperation batch, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<IList<TableResult>> batchCmd = new RESTCommand<IList<TableResult>>(client.Credentials, client.BaseUri);
            requestOptions.ApplyToStorageCommand(batchCmd);

            List<TableResult> results = new List<TableResult>();

            batchCmd.RetrieveResponseStream = true;
            batchCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            batchCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) =>
            {
                Tuple<HttpWebRequest, Stream> res = TableOperationHttpWebRequestFactory.BuildRequestForTableBatchOperation(uri, builder, timeout, client.BaseUri, tableName, batch, ctx);
                batchCmd.SendStream = res.Item2;
                return res.Item1;
            };

            batchCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp != null ? resp.StatusCode : HttpStatusCode.Unused, results, cmd, ex, ctx);
            batchCmd.PostProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableBatchOperationPostProcess(results, batch, cmd, resp, ctx);

            return batchCmd;
        }
    }
}
