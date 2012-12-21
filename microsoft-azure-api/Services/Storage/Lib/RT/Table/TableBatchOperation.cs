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
    using System.Net;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Storage.Table.Protocol;
    using Windows.Foundation;

    /// <summary>
    /// Represents a batch operation on a table.
    /// </summary>
    public sealed partial class TableBatchOperation : IList<TableOperation>
    {
        internal IAsyncOperation<IList<TableResult>> ExecuteAsync(CloudTableClient client, string tableName, TableRequestOptions requestOptions, OperationContext operationContext)
        {
            TableRequestOptions modifiedOptions = TableRequestOptions.ApplyDefaults(requestOptions, client);
            operationContext = operationContext ?? new OperationContext();

            CommonUtils.AssertNotNullOrEmpty("tableName", tableName);
            if (this.operations.Count == 0)
            {
                throw new ArgumentOutOfRangeException(SR.EmptyBatchOperation);
            }

            RESTCommand<IList<TableResult>> cmdToExecute = BatchImpl(this, client, tableName, modifiedOptions);

            return AsyncInfo.Run(async (cancellationToken) => await Executor.ExecuteAsync(
                                                                       cmdToExecute,
                                                                       modifiedOptions.RetryPolicy,
                                                                       operationContext,
                                                                       cancellationToken));
        }

        private static RESTCommand<IList<TableResult>> BatchImpl(TableBatchOperation batch, CloudTableClient client, string tableName, TableRequestOptions requestOptions)
        {
            RESTCommand<IList<TableResult>> batchCmd = new RESTCommand<IList<TableResult>>(client.Credentials, client.BaseUri);
            requestOptions.ApplyToStorageCommand(batchCmd);

            List<TableResult> results = new List<TableResult>();

            batchCmd.RetrieveResponseStream = true;
            batchCmd.Handler = client.AuthenticationHandler;
            batchCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            batchCmd.BuildRequest = (cmd, cnt, ctx) => TableOperationHttpRequestMessageFactory.BuildRequestForTableBatchOperation(cmd.Uri, cmd.ServerTimeoutInSeconds, client.BaseUri, tableName, batch, ctx);
            batchCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Accepted, resp.StatusCode, results, cmd, ex, ctx);
            batchCmd.PostProcessResponse = (cmd, resp, ex, ctx) => TableOperationHttpResponseParsers.TableBatchOperationPostProcess(results, batch, cmd, resp, ctx);
            batchCmd.RecoveryAction = (cmd, ex, ctx) => results.Clear();

            return batchCmd;
        }
    }
}
