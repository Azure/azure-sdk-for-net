// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    internal class MockOperation : Operation, IOperation
    {
        private static ClientDiagnostics _clientDiagnostics = new(new TestClientOptions());
        private bool _exceptionOnWait;

        protected MockOperation()
        {
        }

        public MockOperation(
            UpdateResult result,
            Func<MockResponse> responseFactory,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null,
            DelayStrategy fallbackStrategy = null,
            bool exceptionOnWait = false,
            Exception customExceptionOnUpdate = null,
            RequestFailedException originalExceptionOnUpdate = null)
        {
            if (result == UpdateResult.FailureCustomException && originalExceptionOnUpdate == null)
                throw new InvalidOperationException($"MockUpdate was asked to use {result} but no {nameof(originalExceptionOnUpdate)} was given");

            if (result == UpdateResult.Throw && customExceptionOnUpdate == null)
                throw new InvalidOperationException($"MockUpdate was asked to use {result} but no {nameof(customExceptionOnUpdate)} was given");

            responseFactory ??= (() => null);

            _exceptionOnWait = exceptionOnWait;
            MockOperationInternal = new MockOperationInternal(_clientDiagnostics, this, responseFactory, operationTypeName, scopeAttributes, fallbackStrategy);
            MockOperationInternal.CallsToComplete = callsToComplete;

            OnUpdateState = result switch
            {
                UpdateResult.Pending => _ =>
                {
                    return MockOperationInternal.CallsToComplete.HasValue &&
                           MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                        ? OperationState.Success(responseFactory())
                        : OperationState.Pending(responseFactory());
                }
                ,
                UpdateResult.Failure => _ => OperationState.Failure(responseFactory()),
                UpdateResult.FailureCustomException => _ => OperationState.Failure(responseFactory(), originalExceptionOnUpdate),
                UpdateResult.Success => _ => OperationState.Success(responseFactory()),
                UpdateResult.Throw => _ => throw customExceptionOnUpdate,
                _ => null
            };
        }

        public override string Id => "testId";

        public override bool HasCompleted => MockOperationInternal.HasCompleted;

        public override Response GetRawResponse() => MockOperationInternal.RawResponse;

        public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletionResponse(cancellationToken);
        }

        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletionResponse(pollingInterval, cancellationToken);
        }

        public async override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
        }

        public async override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionResponseAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;

            return await MockOperationInternal.UpdateStatusAsync(cancellationToken);
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
            return MockOperationInternal.UpdateStatus(cancellationToken);
        }

        public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
            return new ValueTask<OperationState>(OnUpdateState(cancellationToken));
        }

        public MockOperationInternal MockOperationInternal { get; }

        public Func<CancellationToken, OperationState> OnUpdateState { get; set; }
    }
}
