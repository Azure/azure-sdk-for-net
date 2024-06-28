// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Threading.Tasks;
using System.Threading;
using System;
using Azure.Core;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    [CodeGenType("MySqlFlexibleServersExtensions")]
    [CodeGenSuppress("GetOperationProgres", typeof(SubscriptionResource), typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationProgresAsync", typeof(SubscriptionResource),  typeof(AzureLocation), typeof(string), typeof(CancellationToken))]
    public static partial class FlexibleServersExtensions
    {
        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static async Task<Response<OperationProgressResult>> GetDetailedStatusAsync(this ArmOperation<MySqlFlexibleServerBackupAndExportResult> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Response response = await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            OperationProgressResult result = OperationProgressResult.ToBackupAndExportResponse(ModelReaderWriter.Read<OperationProgressResult>(response.Content));
            return Response.FromValue(result, response);
        }

        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static Response<OperationProgressResult> GetDetailedStatus(this ArmOperation<MySqlFlexibleServerBackupAndExportResult> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Response response = operation.UpdateStatus(cancellationToken);
            OperationProgressResult result = OperationProgressResult.ToBackupAndExportResponse(ModelReaderWriter.Read<OperationProgressResult>(response.Content));
            return Response.FromValue(result, response);
        }

        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static async Task<Response<OperationProgressResult>> GetDetailedStatusAsync(this ArmOperation<MySqlFlexibleServerResource> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Response response = await operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            OperationProgressResult result = OperationProgressResult.ToImportFromStorageResponse(ModelReaderWriter.Read<OperationProgressResult>(response.Content));
            return Response.FromValue(result, response);
        }

        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static Response<OperationProgressResult> GetDetailedStatus(this ArmOperation<MySqlFlexibleServerResource> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Response response = operation.UpdateStatus(cancellationToken);
            OperationProgressResult result = OperationProgressResult.ToImportFromStorageResponse(ModelReaderWriter.Read<OperationProgressResult>(response.Content));
            return Response.FromValue(result, response);
        }
    }
}
