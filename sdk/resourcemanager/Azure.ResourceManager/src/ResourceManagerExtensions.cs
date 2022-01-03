// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Extension class for resource manager.
    /// </summary>
    public static class ResourceManagerExtensions
    {
        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="operation"> The operation instance to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public static Response WaitForCompletion(this Operation operation, CancellationToken cancellationToken)
        {
            return operation.WaitForCompletion(OperationInternals.DefaultPollingInterval, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="operation"> The operation instance to use. </param>
        /// <param name="pollingInterval"> The polling interval to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public static Response WaitForCompletion(this Operation operation, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return operation.GetRawResponse();
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="operation"> The operation instance to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public static Response<T> WaitForCompletion<T>(this Operation<T> operation, CancellationToken cancellationToken = default)
        {
            return operation.WaitForCompletion(OperationInternals.DefaultPollingInterval, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="operation"> The operation instance to use. </param>
        /// <param name="pollingInterval"> The polling interval to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public static Response<T> WaitForCompletion<T>(this Operation<T> operation, TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                operation.UpdateStatus(cancellationToken);
                if (operation.HasCompleted)
                {
                    return Response.FromValue(operation.Value, operation.GetRawResponse());
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }

        /// <summary>
        /// Gets the correlation id from x-ms-correlation-id.
        /// </summary>
        public static string GetCorrelationId(this Response response)
        {
            string correlationId = null;
            response.Headers.TryGetValue("x-ms-correlation-request-id", out correlationId);
            return correlationId;
        }
    }
}
