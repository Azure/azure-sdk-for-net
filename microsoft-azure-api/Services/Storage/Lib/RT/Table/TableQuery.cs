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
    public sealed partial class TableQuery
    {
        #region Impl
        internal IEnumerable<DynamicTableEntity> Execute(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtility.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            IEnumerable<DynamicTableEntity> enumerable =
                CommonUtility.LazyEnumerable<DynamicTableEntity>(
                (continuationToken) =>
                {
                    Task<TableQuerySegment> task = Task.Run(() => this.ExecuteQuerySegmentedAsync((TableContinuationToken)continuationToken, client, tableName, modifiedOptions, operationContext).AsTask());
                    task.Wait();

                    TableQuerySegment seg = task.Result;

                    return new ResultSegment<DynamicTableEntity>((List<DynamicTableEntity>)seg.Results) { ContinuationToken = seg.ContinuationToken };
                },
                this.takeCount.HasValue ? this.takeCount.Value : long.MaxValue);

            return enumerable;
        }

        internal IAsyncOperation<TableQuerySegment> ExecuteQuerySegmentedAsync(TableContinuationToken continuationToken, CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtility.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment> cmdToExecute = QueryImpl(this, continuationToken, client, tableName, modifiedOptions);

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsync(
                                                                                       cmdToExecute,
                                                                                       modifiedOptions.RetryPolicy,
                                                                                       operationContext,
                                                                                       cancellationToken));
        }

        private static RESTCommand<TableQuerySegment> QueryImpl(TableQuery query, TableContinuationToken token, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            Uri tempUri = NavigationHelper.AppendPathToUri(client.BaseUri, tableName);
            UriQueryBuilder builder = query.GenerateQueryBuilder();

            if (token != null)
            {
                token.ApplyToUriQueryBuilder(builder);
            }

            Uri reqUri = builder.AddToUri(tempUri);

            RESTCommand<TableQuerySegment> queryCmd = new RESTCommand<TableQuerySegment>(client.Credentials, reqUri);
            queryCmd.ApplyRequestOptions(requestOptions);

            queryCmd.RetrieveResponseStream = true;
            queryCmd.Handler = client.AuthenticationHandler;
            queryCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            queryCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableQuery(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);
            queryCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp.StatusCode, null /* retVal */, cmd, ex);
            queryCmd.PostProcessResponse = (cmd, resp, ctx) => TableOperationHttpResponseParsers.TableQueryPostProcess(cmd.ResponseStream, resp, ctx);

            return queryCmd;
        }
        #endregion
    }
}
