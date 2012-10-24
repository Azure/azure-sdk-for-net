// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryNonGeneric.cs" company="Microsoft">
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

    public partial class TableQuery
    {
        public TableQuery()
        {
        }

        #region Impl

        internal IEnumerable<DynamicTableEntity> Execute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            IEnumerable<DynamicTableEntity> enumerable =
                General.LazyEnumerable<DynamicTableEntity>(
                (continuationToken) =>
                {
                    TableQuerySegment<DynamicTableEntity> seg = this.ExecuteQuerySegmented((TableContinuationToken)continuationToken, client, tableName, modifiedOptions, operationContext);

                    return new ResultSegment<DynamicTableEntity>(seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                long.MaxValue,
                operationContext);

            return enumerable;
        }

        internal TableQuerySegment<DynamicTableEntity> ExecuteQuerySegmented(TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<DynamicTableEntity>> cmdToExecute = QueryImpl(this, token, client, tableName, modifiedOptions);

            return Executor.ExecuteSync(cmdToExecute, modifiedOptions.RetryPolicy, operationContext);
        }

        [DoesServiceRequest]
        internal ICancellableAsyncResult BeginExecuteQuerySegmented(TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);

            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            return Executor.BeginExecuteAsync(
                                          QueryImpl(this, token, client, tableName, modifiedOptions),
                                          modifiedOptions.RetryPolicy,
                                          operationContext,
                                          callback,
                                          state);
        }

        internal TableQuerySegment<DynamicTableEntity> EndExecuteQuerySegmented(IAsyncResult asyncResult)
        {
            return Executor.EndExecuteAsync<TableQuerySegment<DynamicTableEntity>>(asyncResult);
        }

        private static RESTCommand<TableQuerySegment<DynamicTableEntity>> QueryImpl(TableQuery query, TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            Uri tempUri = NavigationHelper.AppendPathToUri(client.BaseUri, tableName);
            UriQueryBuilder builder = query.GenerateQueryBuilder();

            if (token != null)
            {
                token.ApplyToUriQueryBuilder(builder);
            }

            Uri reqUri = builder.AddToUri(tempUri);

            RESTCommand<TableQuerySegment<DynamicTableEntity>> queryCmd = new RESTCommand<TableQuerySegment<DynamicTableEntity>>(client.Credentials, reqUri);
            requestOptions.ApplyToStorageCommand(queryCmd);

            queryCmd.RetrieveResponseStream = true;
            queryCmd.SignRequest = client.AuthenticationHandler.SignRequest;
            queryCmd.BuildRequestDelegate = TableOperationHttpWebRequestFactory.BuildRequestForTableQuery;

            queryCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp != null ? resp.StatusCode : HttpStatusCode.Unused, null /* retVal */, cmd, ex, ctx);
            queryCmd.PostProcessResponse = (cmd, resp, ex, ctx) =>
            {
                ResultSegment<DynamicTableEntity> resSeg = TableOperationHttpResponseParsers.TableQueryPostProcessGeneric<DynamicTableEntity>(cmd.ResponseStream, EntityUtilities.ResolveDynamicEntity, resp, ex, ctx);
                return new TableQuerySegment<DynamicTableEntity>(resSeg);
            };

            return queryCmd;
        }

        #endregion
    }
}
