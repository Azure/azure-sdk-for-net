// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class ProtocolOperation<T> : Operation<T>, IOperation<T> where T : notnull
    {
        private readonly Func<Response, T> _resultSelector;
        private readonly OperationInternal<T> _operation;
        private readonly IOperation _nextLinkOperation;

        internal ProtocolOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName, Func<Response, T> resultSelector)
        {
            _resultSelector = resultSelector;
            _nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal<T>(this, clientDiagnostics, response, scopeName);
        }

#pragma warning disable CA1822
        // This scenario is currently unsupported.
        // See: https://github.com/Azure/autorest.csharp/issues/2158.
        /// <inheritdoc />
        public override string Id => throw new NotSupportedException();
#pragma warning restore CA1822

        /// <inheritdoc />
        public override T Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        async ValueTask<OperationState<T>> IOperation<T>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            var state = await _nextLinkOperation.UpdateStateAsync(async, cancellationToken).ConfigureAwait(false);
            if (state.HasSucceeded)
            {
                return OperationState<T>.Success(state.RawResponse, _resultSelector(state.RawResponse));
            }

            if (state.HasCompleted)
            {
                return OperationState<T>.Failure(state.RawResponse, state.OperationFailedException);
            }

            return OperationState<T>.Pending(state.RawResponse);
        }
    }
}
