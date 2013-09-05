// -----------------------------------------------------------------------------------------
// <copyright file="TableQueryExtensions.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using System;
    using System.Net;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;

    /// <summary>
    /// Defines the extension methods to the <see cref="TableQuery"/> class. This is a static class.
    /// </summary>
    internal static class TableQueryExtensions
    {
        internal static IAsyncOperation<TableQuerySegment<TResult>> ExecuteQuerySegmentedAsync<TResult>(TableQuery query, TableContinuationToken continuationToken, CloudTableClient client, string tableName, EntityResolver<TResult> resolver, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            CommonUtility.AssertNotNullOrEmpty("tableName", tableName);
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            RESTCommand<TableQuerySegment<TResult>> cmdToExecute = QueryImpl(query, continuationToken, client, tableName, resolver, modifiedOptions);

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsync(
                                                                                       cmdToExecute,
                                                                                       modifiedOptions.RetryPolicy,
                                                                                       operationContext,
                                                                                       cancellationToken));
        }

        private static RESTCommand<TableQuerySegment<RESULT_TYPE>> QueryImpl<RESULT_TYPE>(TableQuery query, TableContinuationToken token, CloudTableClient client, string tableName, EntityResolver<RESULT_TYPE> resolver, TableRequestOptions requestOptions)
        {
            Uri tempUri = NavigationHelper.AppendPathToUri(client.BaseUri, tableName);
            UriQueryBuilder builder = query.GenerateQueryBuilder();

            if (token != null)
            {
                token.ApplyToUriQueryBuilder(builder);
            }

            Uri reqUri = builder.AddToUri(tempUri);

            RESTCommand<TableQuerySegment<RESULT_TYPE>> queryCmd = new RESTCommand<TableQuerySegment<RESULT_TYPE>>(client.Credentials, reqUri);
            queryCmd.ApplyRequestOptions(requestOptions);

            queryCmd.RetrieveResponseStream = true;
            queryCmd.Handler = client.AuthenticationHandler;
            queryCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            queryCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableQuery(cmd.Uri, cmd.ServerTimeoutInSeconds, ctx);
            queryCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp.StatusCode, null /* retVal */, cmd, ex);
            queryCmd.PostProcessResponse = async (cmd, resp, ctx) =>
            {
                ResultSegment<RESULT_TYPE> resSeg = await TableOperationHttpResponseParsers.TableQueryPostProcessGeneric<RESULT_TYPE>(cmd.ResponseStream, resolver.Invoke, resp, ctx);
                return new TableQuerySegment<RESULT_TYPE>(resSeg);
            };

            return queryCmd;
        }
    }
}
