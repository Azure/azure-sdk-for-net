// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    public abstract class ArmOperation : Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public virtual Response WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(OperationInternals<Response>.DefaultPollingInterval, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="pollingInterval"> The polling interval to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public virtual Response WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return new ArmVoidResponse(GetRawResponse());
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }

    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="OperationsBase"/> to return representing the result of the ArmOperation. </typeparam>
#pragma warning disable SA1402 // File may only contain a single type
    public abstract class ArmOperation<TOperations> : Operation<TOperations>
        where TOperations : notnull
#pragma warning restore SA1402 // File may only contain a single type
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public virtual Response<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(OperationInternals<TOperations>.DefaultPollingInterval, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="pollingInterval"> The polling interval to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> The response with the final state of the operation. </returns>
        public virtual Response<TOperations> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse()) as ArmResponse<TOperations>;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
