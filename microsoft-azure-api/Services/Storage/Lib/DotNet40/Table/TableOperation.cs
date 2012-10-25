// -----------------------------------------------------------------------------------------
// <copyright file="TableOperation.cs" company="Microsoft">
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
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a single table operation.
    /// </summary>
    public sealed partial class TableOperation
    {
        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <typeparam name="TElement">The class of type for the entity to retrieve.</typeparam>
        /// <param name="partitionKey">A string containing the partition key of the entity to retrieve.</param>
        /// <param name="rowkey">A string containing the row key of the entity to retrieve.</param>        
        /// <returns>The table operation.</returns>
        public static TableOperation Retrieve<TElement>(string partitionKey, string rowkey) where TElement : ITableEntity
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => EntityUtilities.ResolveEntityByType<TElement>(pk, rk, ts, prop, etag) };
        }

        /// <summary>
        /// Creates a new table operation that replaces the contents of
        /// the given entity in a table.
        /// </summary>
        /// <typeparam name="R">The return type which the specified <see cref="EntityResolver"/> will resolve the given entity to.</typeparam>
        /// <param name="partitionKey">A string containing the partition key of the entity to retrieve.</param>
        /// <param name="rowkey">A string containing the row key of the entity to retrieve.</param>
        /// <param name="resolver">The <see cref="EntityResolver{T}"/> implementation to project the entity to retrieve as a particular type in the result.</param>
        /// <returns>The table operation.</returns>
        public static TableOperation Retrieve<R>(string partitionKey, string rowkey, EntityResolver<R> resolver)
        {
            CommonUtils.AssertNotNull("partitionKey", partitionKey);
            CommonUtils.AssertNotNull("rowkey", rowkey);

            // Create and return the table operation.
            return new TableOperation(null /* entity */, TableOperationType.Retrieve) { RetrievePartitionKey = partitionKey, RetrieveRowKey = rowkey, RetrieveResolver = (pk, rk, ts, prop, etag) => resolver(pk, rk, ts, prop, etag) };
        }

        internal TableResult Execute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);

            return Executor.ExecuteSync(this.GenerateCMDForOperation(client, tableName, modifiedOptions), modifiedOptions.RetryPolicy, operationContext);
        }

        [DoesServiceRequest]
        internal ICancellableAsyncResult BeginExecute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);

            return Executor.BeginExecuteAsync(
                                          this.GenerateCMDForOperation(client, tableName, modifiedOptions),
                                          modifiedOptions.RetryPolicy,
                                          operationContext,
                                          callback,
                                          state);
        }

        internal TableResult EndExecute(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableResult>(asyncResult);
        }

        internal RESTCommand<TableResult> GenerateCMDForOperation(CloudTableClient client, string tableName, TableRequestOptions modifiedOptions)
        {
            if (this.OperationType == TableOperationType.Insert ||
                this.OperationType == TableOperationType.InsertOrMerge ||
                this.OperationType == TableOperationType.InsertOrReplace)
            {
                if (!this.isTableEntity && this.OperationType != TableOperationType.Insert)
                {
                    CommonUtils.AssertNotNull("Upserts require a valid PartitionKey", this.Entity.PartitionKey);
                    CommonUtils.AssertNotNull("Upserts require a valid RowKey", this.Entity.RowKey);
                }

                return InsertImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Delete)
            {
                if (!this.isTableEntity)
                {
                    CommonUtils.AssertNotNullOrEmpty("Delete requires a valid ETag", this.Entity.ETag);
                    CommonUtils.AssertNotNull("Delete requires a valid PartitionKey", this.Entity.PartitionKey);
                    CommonUtils.AssertNotNull("Delete requires a valid RowKey", this.Entity.RowKey);
                }

                return DeleteImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Merge)
            {
                CommonUtils.AssertNotNullOrEmpty("Merge requires a valid ETag", this.Entity.ETag);
                CommonUtils.AssertNotNull("Merge requires a valid PartitionKey", this.Entity.PartitionKey);
                CommonUtils.AssertNotNull("Merge requires a valid RowKey", this.Entity.RowKey);

                return MergeImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Replace)
            {
                CommonUtils.AssertNotNullOrEmpty("Replace requires a valid ETag", this.Entity.ETag);
                CommonUtils.AssertNotNull("Replace requires a valid PartitionKey", this.Entity.PartitionKey);
                CommonUtils.AssertNotNull("Replace requires a valid RowKey", this.Entity.RowKey);

                return ReplaceImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Retrieve)
            {
                return RetrieveImpl(this, client, tableName, modifiedOptions);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private static RESTCommand<TableResult> InsertImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> insertCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(insertCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            insertCmd.RetrieveResponseStream = true;
            insertCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            insertCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) =>
                {
                    Tuple<HttpWebRequest, Stream> res = TableOperationHttpWebRequestFactory.BuildRequestForTableOperation(uri, builder, timeout, operation, ctx);
                    insertCmd.SendStream = res.Item2;
                    return res.Item1;
                };

            insertCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);

            insertCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
                    {
                        HttpResponseParsers.ProcessExpectedStatusCodeNoException(
                                                operation.OperationType == TableOperationType.Insert ? HttpStatusCode.Created : HttpStatusCode.NoContent,
                                                resp,
                                                result,
                                                cmd,
                                                ex,
                                                ctx);

                        result = TableOperationHttpResponseParsers.TableOperationPostProcess(result, operation, cmd, resp, ctx);
                        return result;
                    };

            return insertCmd;
        }

        private static RESTCommand<TableResult> DeleteImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> deleteCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(deleteCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            deleteCmd.RetrieveResponseStream = false;
            deleteCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            deleteCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) => TableOperationHttpWebRequestFactory.BuildRequestForTableOperation(uri, builder, timeout, operation, ctx).Item1;
            deleteCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            deleteCmd.PostProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx);

            return deleteCmd;
        }

        private static RESTCommand<TableResult> MergeImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> mergeCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(mergeCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            mergeCmd.RetrieveResponseStream = false;
            mergeCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            mergeCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) =>
            {
                Tuple<HttpWebRequest, Stream> res = TableOperationHttpWebRequestFactory.BuildRequestForTableOperation(uri, builder, timeout, operation, ctx);
                mergeCmd.SendStream = res.Item2;
                return res.Item1;
            };

            mergeCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            mergeCmd.PostProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx);

            return mergeCmd;
        }

        private static RESTCommand<TableResult> ReplaceImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> replaceCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(replaceCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            replaceCmd.RetrieveResponseStream = false;
            replaceCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            replaceCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) =>
            {
                Tuple<HttpWebRequest, Stream> res = TableOperationHttpWebRequestFactory.BuildRequestForTableOperation(uri, builder, timeout, operation, ctx);
                replaceCmd.SendStream = res.Item2;
                return res.Item1;
            };

            replaceCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            replaceCmd.PostProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx);

            return replaceCmd;
        }

        private static RESTCommand<TableResult> RetrieveImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> retrieveCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(retrieveCmd);

            TableResult result = new TableResult();
            retrieveCmd.RetrieveResponseStream = true;
            retrieveCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            retrieveCmd.BuildRequestDelegate = (uri, builder, timeout, ctx) => TableOperationHttpWebRequestFactory.BuildRequestForTableOperation(uri, builder, timeout, operation, ctx).Item1;
            retrieveCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            retrieveCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
                    {
                        if (resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            return result;
                        }

                        HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, result, cmd, ex, ctx);
                        result = TableOperationHttpResponseParsers.TableOperationPostProcess(result, operation, cmd, resp, ctx);
                        return result;
                    };

            return retrieveCmd;
        }

        internal string HttpMethod
        {
            get
            {
                switch (this.OperationType)
                {
                    case TableOperationType.Insert:
                        return "POST";
                    case TableOperationType.Merge:
                    case TableOperationType.InsertOrMerge:
                        return "POST"; // Post tunneling for merge
                    case TableOperationType.Replace:
                    case TableOperationType.InsertOrReplace:
                        return "PUT";
                    case TableOperationType.Delete:
                        return "DELETE";
                    case TableOperationType.Retrieve:
                        return "GET";
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}
