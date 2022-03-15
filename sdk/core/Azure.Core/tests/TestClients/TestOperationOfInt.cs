// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Core.Tests
{
    internal class TestOperationOfInt : Operation<int>, IOperation<int>
    {
        private static ClientDiagnostics _clientDiagnostics = new(new TestClientOptions());
        private bool _exceptionOnWait;
        private int _expectedValue = 50;

        protected TestOperationOfInt()
        {
        }

        public TestOperationOfInt(
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

            _exceptionOnWait = exceptionOnWait;
            MockOperationInternal = new MockOperationInternal<int>(_clientDiagnostics, this, responseFactory, operationTypeName, scopeAttributes, fallbackStrategy);
            MockOperationInternal.CallsToComplete = callsToComplete;

            OnUpdateState = result switch
            {
                UpdateResult.Pending => _ =>
                {
                    return MockOperationInternal.CallsToComplete.HasValue &&
                           MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                        ? OperationState<int>.Success(responseFactory(), _expectedValue)
                        : OperationState<int>.Pending(responseFactory());
                }
                ,
                UpdateResult.Failure => _ => OperationState<int>.Failure(responseFactory()),
                UpdateResult.FailureCustomException => _ => OperationState<int>.Failure(responseFactory(), originalExceptionOnUpdate),
                UpdateResult.Success => _ => OperationState<int>.Success(responseFactory(), _expectedValue),
                UpdateResult.Throw => _ => throw customExceptionOnUpdate,
                _ => null
            };
        }

        public override string Id => "testId";

        public override bool HasCompleted => MockOperationInternal.HasCompleted;

        public override int Value => _expectedValue;

        public override bool HasValue => MockOperationInternal.HasValue;

        public override Response GetRawResponse() => MockOperationInternal.RawResponse;

        public override Response<int> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletion(cancellationToken);
        }

        public override Response<int> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletion(pollingInterval, cancellationToken);
        }

        public async override ValueTask<Response<int>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async override ValueTask<Response<int>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;

            return new ValueTask<Response>(OnUpdateState(cancellationToken).RawResponse);
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
            return OnUpdateState(cancellationToken).RawResponse;
        }

        public ValueTask<OperationState<int>> UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
            return new ValueTask<OperationState<int>>(OnUpdateState(cancellationToken));
        }

        public MockOperationInternal<int> MockOperationInternal { get; }

        public Func<CancellationToken, OperationState<int>> OnUpdateState { get; set; }
    }
}
