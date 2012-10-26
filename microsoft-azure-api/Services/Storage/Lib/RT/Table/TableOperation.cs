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
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using Windows.Foundation;

    /// <summary>
    /// Represents a single table operation.
    /// </summary>
    public sealed partial class TableOperation
    {
        internal IAsyncOperation<TableResult> ExecuteAsync(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            RESTCommand<TableResult> cmdToExecute = null;

            if (this.OperationType == TableOperationType.Insert ||
                this.OperationType == TableOperationType.InsertOrMerge ||
                this.OperationType == TableOperationType.InsertOrReplace)
            {
                if (!this.isTableEntity && this.OperationType != TableOperationType.Insert)
                {
                    CommonUtils.AssertNotNull("Upserts require a valid PartitionKey", this.Entity.PartitionKey);
                    CommonUtils.AssertNotNull("Upserts require a valid RowKey", this.Entity.RowKey);
                }

                cmdToExecute = InsertImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Delete)
            {
                if (!this.isTableEntity)
                {
                    CommonUtils.AssertNotNullOrEmpty("Delete requires a valid ETag", this.Entity.ETag);
                    CommonUtils.AssertNotNull("Delete requires a valid PartitionKey", this.Entity.PartitionKey);
                    CommonUtils.AssertNotNull("Delete requires a valid RowKey", this.Entity.RowKey);
                }

                cmdToExecute = DeleteImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Merge)
            {
                CommonUtils.AssertNotNullOrEmpty("Merge requires a valid ETag", this.Entity.ETag);
                CommonUtils.AssertNotNull("Merge requires a valid PartitionKey", this.Entity.PartitionKey);
                CommonUtils.AssertNotNull("Merge requires a valid RowKey", this.Entity.RowKey);

                cmdToExecute = MergeImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Replace)
            {
                CommonUtils.AssertNotNullOrEmpty("Replace requires a valid ETag", this.Entity.ETag);
                CommonUtils.AssertNotNull("Replace requires a valid PartitionKey", this.Entity.PartitionKey);
                CommonUtils.AssertNotNull("Replace requires a valid RowKey", this.Entity.RowKey);

                cmdToExecute = ReplaceImpl(this, client, tableName, modifiedOptions);
            }
            else if (this.OperationType == TableOperationType.Retrieve)
            {
                cmdToExecute = RetrieveImpl(this, client, tableName, modifiedOptions);
            }
            else
            {
                throw new NotSupportedException();
            }

            return AsyncInfo.Run((cancellationToken) => Executor.ExecuteAsync(
                                                                       cmdToExecute,
                                                                       modifiedOptions.RetryPolicy,
                                                                       operationContext,
                                                                       cancellationToken));
        }

        private static RESTCommand<TableResult> InsertImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> insertCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(insertCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            insertCmd.RetrieveResponseStream = true;
            insertCmd.Handler = client.AuthenticationHandler;
            insertCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            insertCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, operation, ctx);
            insertCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);

            insertCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
                  Task.Run(async () =>
                    {
                        HttpResponseParsers.ProcessExpectedStatusCodeNoException(
                                                operation.OperationType == TableOperationType.Insert ? HttpStatusCode.Created : HttpStatusCode.NoContent,
                                                resp,
                                                result,
                                                cmd,
                                                ex,
                                                ctx);

                        result = await TableOperationHttpResponseParsers.TableOperationPostProcess(result, operation, cmd, resp, ctx);
                        return result;
                    });

            return insertCmd;
        }

        private static RESTCommand<TableResult> DeleteImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> deleteCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(deleteCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            deleteCmd.RetrieveResponseStream = false;
            deleteCmd.Handler = client.AuthenticationHandler;
            deleteCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            deleteCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, operation, ctx);
            deleteCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            deleteCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
                {
                    return Task.Factory.StartNew(() => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx));
                };

            return deleteCmd;
        }

        private static RESTCommand<TableResult> MergeImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> mergeCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(mergeCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            mergeCmd.RetrieveResponseStream = false;
            mergeCmd.Handler = client.AuthenticationHandler;
            mergeCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            mergeCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, operation, ctx);
            mergeCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            mergeCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                return Task.Factory.StartNew(() => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx));
            };

            return mergeCmd;
        }

        private static RESTCommand<TableResult> ReplaceImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> replaceCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(replaceCmd);

            TableResult result = new TableResult() { Result = operation.Entity };
            replaceCmd.RetrieveResponseStream = false;
            replaceCmd.Handler = client.AuthenticationHandler;
            replaceCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            replaceCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, operation, ctx);
            replaceCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            replaceCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                return Task.Factory.StartNew(() => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, result, cmd, ex, ctx));
            };
            return replaceCmd;
        }

        private static RESTCommand<TableResult> RetrieveImpl(TableOperation operation, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<TableResult> retrieveCmd = new RESTCommand<TableResult>(client.Credentials, operation.GenerateRequestURI(client.BaseUri, tableName));
            requestOptions.ApplyToStorageCommand(retrieveCmd);

            TableResult result = new TableResult();
            retrieveCmd.RetrieveResponseStream = true;
            retrieveCmd.Handler = client.AuthenticationHandler;
            retrieveCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            retrieveCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, operation, ctx);
            retrieveCmd.PreProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableOperationPreProcess(result, operation, resp, ex, cmd, ctx);
            retrieveCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
                  Task.Run(async () =>
                    {
                        if (resp.StatusCode == HttpStatusCode.NotFound)
                        {
                            return result;
                        }

                        HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, result, cmd, ex, ctx);
                        result = await TableOperationHttpResponseParsers.TableOperationPostProcess(result, operation, cmd, resp, ctx);
                        return result;
                    });
            return retrieveCmd;
        }

        internal HttpMethod HttpMethod
        {
            get
            {
                switch (this.OperationType)
                {
                    case TableOperationType.Insert:
                        return HttpMethod.Post;
                    case TableOperationType.Merge:
                    case TableOperationType.InsertOrMerge:
                        return HttpMethod.Post; // Post tunneling for merge
                    case TableOperationType.Replace:
                    case TableOperationType.InsertOrReplace:
                        return HttpMethod.Put;
                    case TableOperationType.Delete:
                        return HttpMethod.Delete;
                    case TableOperationType.Retrieve:
                        return HttpMethod.Get;
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }
}
