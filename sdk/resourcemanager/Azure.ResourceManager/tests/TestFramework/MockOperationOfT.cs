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
#pragma warning disable SA1649 // File name should match first type name
    public class MockOperation<T> : Operation<T>, IOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private static ClientDiagnostics _clientDiagnostics = new(new TestClientOptions());
        private bool _exceptionOnWait;
        private T _expectedValue;

        protected MockOperation()
        {
        }

        public MockOperation(
            T expectedValue,
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
            _expectedValue = expectedValue;
            if (result == UpdateResult.FailureCustomException && originalExceptionOnUpdate == null)
                throw new InvalidOperationException($"MockUpdate was asked to use {result} but no {nameof(originalExceptionOnUpdate)} was given");

            if (result == UpdateResult.Throw && customExceptionOnUpdate == null)
                throw new InvalidOperationException($"MockUpdate was asked to use {result} but no {nameof(customExceptionOnUpdate)} was given");

            _exceptionOnWait = exceptionOnWait;
            MockOperationInternal = new MockOperationInternal<T>(_clientDiagnostics, this, responseFactory, operationTypeName, scopeAttributes, fallbackStrategy);
            MockOperationInternal.CallsToComplete = callsToComplete;

            OnUpdateState = result switch
            {
                UpdateResult.Pending => _ =>
                {
                    return MockOperationInternal.CallsToComplete.HasValue &&
                           MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                        ? OperationState<T>.Success(responseFactory(), _expectedValue)
                        : OperationState<T>.Pending(responseFactory());
                }
                ,
                UpdateResult.Failure => _ => OperationState<T>.Failure(responseFactory()),
                UpdateResult.FailureCustomException => _ => OperationState<T>.Failure(responseFactory(), originalExceptionOnUpdate),
                UpdateResult.Success => _ => OperationState<T>.Success(responseFactory(), _expectedValue),
                UpdateResult.Throw => _ => throw customExceptionOnUpdate,
                _ => null
            };
        }

        public override string Id => "testId";

        public override bool HasCompleted => MockOperationInternal.HasCompleted;

        public override T Value => _expectedValue;

        public override bool HasValue => MockOperationInternal.HasValue;

        public override Response GetRawResponse() => MockOperationInternal.RawResponse;

        public override Response<T> WaitForCompletion(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletion(cancellationToken);
        }

        public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return MockOperationInternal.WaitForCompletion(pollingInterval, cancellationToken);
        }

        public async override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            if (_exceptionOnWait)
                throw new ArgumentException("FakeArg");

            return await MockOperationInternal.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
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

        ValueTask<OperationState<T>> IOperation<T>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
        {
            MockOperationInternal.UpdateStatusCallCount++;
            MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;

            return new ValueTask<OperationState<T>>(OnUpdateState(cancellationToken));
        }

        RehydrationToken IOperation<T>.GetRehydrationToken() =>
            throw new NotImplementedException();

        internal MockOperationInternal<T> MockOperationInternal { get; }

        internal Func<CancellationToken, OperationState<T>> OnUpdateState { get; set; }
    }
}
