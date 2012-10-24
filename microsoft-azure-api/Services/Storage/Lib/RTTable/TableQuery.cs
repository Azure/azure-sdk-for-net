// -----------------------------------------------------------------------------------------
// <copyright file="TableQuery.cs" company="Microsoft">
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
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using Windows.Foundation;

    /// <summary>
    /// Represents a query against a specified table.
    /// </summary>
    /// <typeparam name="TElement">The entity type of the query.</typeparam>
    public partial class TableQuery<TElement> where TElement : ITableEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableQuery{TElement}"/> class.
        /// </summary>
        public TableQuery()
        {
        }

        #region Impl

        internal IEnumerable<TElement> Execute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            IEnumerable<TElement> enumerable =
                General.LazyEnumerable<TElement>(
                (continuationToken) =>
                {
                    var task = Task.Run(() => this.ExecuteQuerySegmentedAsync((TableContinuationToken)continuationToken, client, tableName, modifiedOptions, operationContext).AsTask());
                    task.Wait();

                    TableQuerySegment<TElement> seg = task.Result;

                    return new ResultSegment<TElement>((List<TElement>)seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                long.MaxValue,
                operationContext);

            return enumerable;
        }

        internal IAsyncOperation<TableQuerySegment<TElement>> ExecuteQuerySegmentedAsync(TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<TElement>> cmdToExecute = QueryImpl(this, token, client, tableName, EntityUtilities.ResolveEntityByType<TElement>, modifiedOptions);

            return AsyncInfo.Run(async (continuationToken) => await Executor.ExecuteAsync(
                                                                                           cmdToExecute,
                                                                                           modifiedOptions.RetryPolicy,
                                                                                           operationContext,
                                                                                           continuationToken));
        }

        internal IEnumerable<R> Execute<R>(CloudTableClient client, string tableName, EntityResolver<R> resolver, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            CommonUtils.AssertNotNull("resolver", resolver);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            IEnumerable<R> enumerable =
                General.LazyEnumerable<R>(
                (continuationToken) =>
                {
                    var task = Task.Run(() => this.ExecuteQuerySegmentedAsync((TableContinuationToken)continuationToken, client, tableName, resolver, modifiedOptions, operationContext).AsTask());
                    task.Wait();

                    TableQuerySegment<R> seg = task.Result;

                    return new ResultSegment<R>(seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                this.takeCount.HasValue ? this.takeCount.Value : long.MaxValue,
                operationContext);

            return enumerable;
        }

        internal IAsyncOperation<TableQuerySegment<R>> ExecuteQuerySegmentedAsync<R>(TableContinuationToken token, CloudTableClient client, string tableName, EntityResolver<R> resolver, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            CommonUtils.AssertNotNull("resolver", resolver);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<R>> cmdToExecute = QueryImpl(this, token, client, tableName, resolver, modifiedOptions);

            return AsyncInfo.Run((cancellationToken) => Executor.ExecuteAsync(
                                                                                   cmdToExecute,
                                                                                   modifiedOptions.RetryPolicy,
                                                                                   operationContext,
                                                                                   cancellationToken));
        }

        private static RESTCommand<TableQuerySegment<RESULT_TYPE>> QueryImpl<T, RESULT_TYPE>(TableQuery<T> query, TableContinuationToken token, CloudTableClient client, string tableName, EntityResolver<RESULT_TYPE> resolver, TableRequestOptions requestOptions) where T : ITableEntity, new()
        {
            Uri tempUri = NavigationHelper.AppendPathToUri(client.BaseUri, tableName);
            UriQueryBuilder builder = query.GenerateQueryBuilder();

            if (token != null)
            {
                token.ApplyToUriQueryBuilder(builder);
            }

            Uri reqUri = builder.AddToUri(tempUri);

            RESTCommand<TableQuerySegment<RESULT_TYPE>> queryCmd = new RESTCommand<TableQuerySegment<RESULT_TYPE>>(client.Credentials, reqUri);
            requestOptions.ApplyToStorageCommand(queryCmd);

            queryCmd.RetrieveResponseStream = true;
            queryCmd.Handler = client.AuthenticationHandler;
            queryCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            queryCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableQuery(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);
            queryCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp.StatusCode, null /* retVal */, cmd, ex, ctx);
            queryCmd.PostProcessResponse = async (cmd, resp, ex, ctx) =>
            {
                ResultSegment<RESULT_TYPE> resSeg = await TableOperationHttpResponseParsers.TableQueryPostProcessGeneric<RESULT_TYPE>(cmd.ResponseStream, resolver.Invoke, resp, ex, ctx);
                return new TableQuerySegment<RESULT_TYPE>(resSeg);
            };

            return queryCmd;
        }

        #endregion
    }
}
