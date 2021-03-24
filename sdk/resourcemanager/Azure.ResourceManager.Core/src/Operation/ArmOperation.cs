// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    public abstract class ArmOperation : ArmOperation<Response>
    {
    }

    /// <summary>
    /// Abstract class for long-running or synchronous applications.
    /// </summary>
    /// <typeparam name="TOperations"> The <see cref="OperationsBase"/> to return representing the result of the ArmOperation. </typeparam>
#pragma warning disable SA1402 // File may only contain a single type
    public abstract class ArmOperation<TOperations> : Operation<TOperations>
        where TOperations : notnull, IUtf8JsonSerializable
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly ArmOperationHelpers<TOperations> _operation;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        protected ArmOperation(Operation<TOperations> operation)
        {
            WrappedOperation = operation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        protected ArmOperation(Response<TOperations> response)
        {
            WrappedResponse = response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientDiagnostics"></param>
        /// <param name="pipeline"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        protected ArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new ArmOperationHelpers<TOperations>(this, )
        }

        /// <summary>
        /// 
        /// </summary>
        protected Response<TOperations> WrappedResponse { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected Operation<TOperations> WrappedOperation { get; private set; }

        /// <inheritdoc/>
        public override TOperations Value => WrappedOperation is null ? WrappedResponse.Value : WrappedOperation.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => WrappedResponse is null ? WrappedOperation.HasCompleted : true;

        /// <inheritdoc/>
        public override bool HasValue => WrappedResponse is null ? WrappedOperation.HasValue : true;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return WrappedResponse is null ? WrappedOperation.GetRawResponse() : WrappedResponse.GetRawResponse();
        }

        /// <inheritdoc/>
        public override string Id => WrappedOperation?.Id;

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmResponse<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<TOperations>.DefaultPollingInterval.Seconds, cancellationToken);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="pollingInterval"> The polling interval in seconds to check for status. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public ArmResponse<TOperations> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
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
