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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;

    /// <summary>
    /// Represents a query against a specified table.
    /// </summary>
    /// <typeparam name="TElement">A class which implements <see cref="ITableEntity"/>.</typeparam>
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
                    TableQuerySegment<TElement> seg = this.ExecuteQuerySegmented((TableContinuationToken)continuationToken, client, tableName, modifiedOptions, operationContext);

                    return new ResultSegment<TElement>(seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                long.MaxValue,
                operationContext);

            return enumerable;
        }

        internal TableQuerySegment<TElement> ExecuteQuerySegmented(TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<TElement>> cmdToExecute = QueryImpl(this, token, client, tableName, EntityUtilities.ResolveEntityByType<TElement>, modifiedOptions);

            return Executor.ExecuteSync(cmdToExecute, modifiedOptions.RetryPolicy, operationContext);
        }

        [DoesServiceRequest]
        internal ICancellableAsyncResult BeginExecuteQuerySegmented(TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                                          QueryImpl(this, token, client, tableName, EntityUtilities.ResolveEntityByType<TElement>, modifiedOptions),
                                          modifiedOptions.RetryPolicy,
                                          operationContext,
                                          callback,
                                          state);
        }

        internal TableQuerySegment<TElement> EndExecuteQuerySegmented(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<TElement>>(asyncResult);
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
                    TableQuerySegment<R> seg = this.ExecuteQuerySegmented((TableContinuationToken)continuationToken, client, tableName, resolver, modifiedOptions, operationContext);

                    return new ResultSegment<R>(seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                this.takeCount.HasValue ? this.takeCount.Value : long.MaxValue,
                operationContext);

            return enumerable;
        }

        internal TableQuerySegment<R> ExecuteQuerySegmented<R>(TableContinuationToken token, CloudTableClient client, string tableName, EntityResolver<R> resolver, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            CommonUtils.AssertNotNull("resolver", resolver);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<R>> cmdToExecute = QueryImpl(this, token, client, tableName, resolver, modifiedOptions);

            return Executor.ExecuteSync(cmdToExecute, modifiedOptions.RetryPolicy, operationContext);
        }

        [DoesServiceRequest]
        internal ICancellableAsyncResult BeginExecuteQuerySegmented<R>(TableContinuationToken token, CloudTableClient client, string tableName, EntityResolver<R> resolver, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            CommonUtils.AssertNotNull("resolver", resolver);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                                          QueryImpl(this, token, client, tableName, resolver, modifiedOptions),
                                          modifiedOptions.RetryPolicy,
                                          operationContext,
                                          callback,
                                          state);
        }

        internal TableQuerySegment<R> EndExecuteQuerySegmented<R>(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<R>>(asyncResult);
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
            queryCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            queryCmd.BuildRequestDelegate = TableOperationHttpWebRequestFactory.BuildRequestForTableQuery;

            queryCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp != null ? resp.StatusCode : HttpStatusCode.Unused, null /* retVal */, cmd, ex, ctx);
            queryCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                ResultSegment<RESULT_TYPE> resSeg = TableOperationHttpResponseParsers.TableQueryPostProcessGeneric<RESULT_TYPE>(cmd.ResponseStream, resolver.Invoke, resp, ex, ctx);
                return new TableQuerySegment<RESULT_TYPE>(resSeg);
            };

            return queryCmd;
        }

        #endregion
    }
}
