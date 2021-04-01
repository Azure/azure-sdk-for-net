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
    public abstract class ArmOperation : Operation<Response>
    {
        private readonly ArmOperationHelpers<Response> _operation;
        private readonly Response _voidResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation"/> class.
        /// </summary>
        /// <param name="source"> The operation source to use. </param>
        /// <param name="clientDiagnostics">The client diagnostics to use. </param>
        /// <param name="pipeline"> The HttpPipeline to use. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response"> The original response. </param>
        /// <param name="scopeName"> The scope name to use. </param>
        internal ArmOperation(IOperationSource<Response> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, string scopeName)
        {
            _operation = new ArmOperationHelpers<Response>(source, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, scopeName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation"/> class.
        /// </summary>
        /// <param name="response"></param>
        protected ArmOperation(Response response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _voidResponse = response;
        }

        /// <inheritdoc/>
        private bool _doesWrapOperation => _voidResponse is null;

        /// <inheritdoc/>
        public override string Id => _operation?.Id;

        /// <inheritdoc/>
        public override Response Value => throw new InvalidOperationException();

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _operation.HasCompleted : true;

        /// <inheritdoc/>
        public override bool HasValue => false;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _doesWrapOperation ? _operation.GetRawResponse() : _voidResponse;
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? _operation.UpdateStatus(cancellationToken) : _voidResponse;
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? _operation.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(_voidResponse);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(ArmOperationHelpers<Response>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<Response>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : Response.FromValue(_voidResponse, _voidResponse);
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<Response>.DefaultPollingInterval.Seconds, cancellationToken);
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
        public virtual Response WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return new VoidArmResponse(GetRawResponse());
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
        private readonly ArmOperationHelpers<TOperations> _operation;
        private readonly Response<TOperations> _valueResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class for mocking.
        /// </summary>
        protected ArmOperation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class.
        /// </summary>
        /// <param name="response"> The non lro response to wrap. </param>
        protected ArmOperation(Response<TOperations> response)
        {
            if (response is null)
                throw new ArgumentNullException(nameof(response));

            _valueResponse = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArmOperation{TOperations}"/> class.
        /// </summary>
        /// <param name="source"> The operation source to use. </param>
        /// <param name="clientDiagnostics">The client diagnostics to use. </param>
        /// <param name="pipeline"> The HttpPipeline to use. </param>
        /// <param name="request"> The original request. </param>
        /// <param name="response"> The original response. </param>
        /// <param name="scopeName"> The scope name to use. </param>
        internal ArmOperation(IOperationSource<TOperations> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, string scopeName)
        {
            _operation = new ArmOperationHelpers<TOperations>(source, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, scopeName);
        }

        private bool _doesWrapOperation => _valueResponse is null;

        /// <inheritdoc/>
        public override string Id => _operation?.Id;

        /// <inheritdoc/>
        public override TOperations Value => _doesWrapOperation ? _operation.Value : _valueResponse.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? _operation.HasCompleted : true;

        /// <inheritdoc/>
        public override bool HasValue => _doesWrapOperation ? _operation.HasValue : true;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _doesWrapOperation ? _operation.GetRawResponse() : _valueResponse.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? _operation.UpdateStatus(cancellationToken) : _valueResponse.GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? _operation.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(_valueResponse.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(ArmOperationHelpers<TOperations>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<TOperations>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : _valueResponse;
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response<TOperations> WaitForCompletion(CancellationToken cancellationToken = default)
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
        public virtual Response<TOperations> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
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
