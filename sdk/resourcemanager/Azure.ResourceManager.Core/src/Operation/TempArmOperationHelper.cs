// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Core
{
    internal class TempArmOperationHelper<T> : ArmOperationHelpers<T>
    {
        private ArmResponse<T> _response;

        public TempArmOperationHelper(
            ArmResponse<T> response,
            ResourceOperationsBase operationBase,
            OperationFinalStateVia finalStateVia,
            string scopeName)
            : base(null,
                  new ClientDiagnostics(operationBase.ClientOptions),
                  ManagementPipelineBuilder.Build(operationBase.Credential, operationBase.BaseUri, operationBase.ClientOptions),
                  null,
                  null, 
                  finalStateVia,
                  scopeName)
        {
            _response = response;
        }

        public TempArmOperationHelper(
            IOperationSource<T> source,
            ClientDiagnostics clientDiagnostics,
            HttpPipeline pipeline,
            Request originalRequest,
            Response originalResponse,
            OperationFinalStateVia finalStateVia,
            string scopeName)
            :base(source, clientDiagnostics, pipeline, originalRequest, originalResponse, finalStateVia, scopeName)
        {
        }

        private bool _doesWrapOperation => _response is null;

        /// <inheritdoc/>
        public override T Value => _doesWrapOperation ? base.Value : _response.Value;

        /// <inheritdoc/>
        public override bool HasCompleted => _doesWrapOperation ? base.HasCompleted : true;

        /// <inheritdoc/>
        public override bool HasValue => _doesWrapOperation ? base.HasValue : true;

        /// <inheritdoc/>
        public override Response GetRawResponse()
        {
            return _doesWrapOperation ? base.GetRawResponse() : _response.GetRawResponse();
        }

        /// <inheritdoc/>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation ? base.UpdateStatus(cancellationToken) : _response.GetRawResponse();
        }

        /// <inheritdoc/>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return _doesWrapOperation
                ? base.UpdateStatusAsync(cancellationToken)
                : new ValueTask<Response>(_response.GetRawResponse());
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<T>> WaitForCompletionAsync(
            CancellationToken cancellationToken = default)
        {
            return await WaitForCompletionAsync(ArmOperationHelpers<T>.DefaultPollingInterval, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public override async ValueTask<Response<T>> WaitForCompletionAsync(
            TimeSpan pollingInterval,
            CancellationToken cancellationToken)
        {
            return _doesWrapOperation
                ? await base.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false)
                : _response;
        }

        /// <summary>
        /// Waits for the completion of the long running operations.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A response with the <see cref="ArmOperation{TOperations}"/> operation for this resource. </returns>
        /// <remarks>
        /// <see href="https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning">Details on long running operation object.</see>
        /// </remarks>
        public virtual Response<T> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            return WaitForCompletion(ArmOperationHelpers<T>.DefaultPollingInterval.Seconds, cancellationToken);
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
        public virtual Response<T> WaitForCompletion(int pollingInterval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                UpdateStatus(cancellationToken);
                if (HasCompleted)
                {
                    return Response.FromValue(Value, GetRawResponse()) as ArmResponse<T>;
                }

                Task.Delay(pollingInterval, cancellationToken).Wait(cancellationToken);
            }
        }
    }
}
