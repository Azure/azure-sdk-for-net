// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OperationOfTInternalTests
    {
        private static readonly string DiagnosticNamespace = "Azure.Core.Tests";

        private static ClientDiagnostics ClientDiagnostics = new(new TestClientOption());
        private static RequestFailedException originalException = new("");
        private static StackOverflowException customException = new();
        private static int expectedValue = 50;

        private MockOperationInternalOfT<int> CreateOperationOfT(
            UpdateResult result,
            MockResponse mockResponse = null,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null)
        {
            TestOperationOfT testOperationOfT = mockResponse == null
                ? new TestOperationOfT(result, operationTypeName: operationTypeName, callsToComplete: callsToComplete, scopeAttributes: scopeAttributes)
                : new TestOperationOfT(result, mockResponse, operationTypeName, callsToComplete: callsToComplete, scopeAttributes: scopeAttributes);
            var operationInternalOfT = testOperationOfT.MockOperationInternal;
            return operationInternalOfT;
        }

        private OperationInternal CreateOperation(
            UpdateResult result,
            MockResponse mockResponse = null,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null)
        {
            TestOperation testOperation = mockResponse == null
                ? new TestOperation(result, operationTypeName: operationTypeName, callsToComplete: callsToComplete, scopeAttributes: scopeAttributes)
                : new TestOperation(result, mockResponse, operationTypeName, callsToComplete: callsToComplete, scopeAttributes: scopeAttributes);
            var operationInternal = testOperation.MockOperationInternal;
            return operationInternal;
        }

        [Test]
        public void DefaultPropertyInitialization([Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Success) : CreateOperation(UpdateResult.Success);

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.False(oit.HasValue);
                Assert.Throws<InvalidOperationException>(() => _ = oit.Value);
            }
        }

        [Test]
        public void RawResponseInitialization([Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Pending, mockResponse) : CreateOperation(UpdateResult.Pending, mockResponse);

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.False(oit.HasValue);
                Assert.Throws<InvalidOperationException>(() => _ = oit.Value);
            }
        }

        [Test]
        public async Task UpdateStatusWhenOperationIsPending([Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Pending, mockResponse) : CreateOperation(UpdateResult.Pending, mockResponse);

            Response operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.False(oit.HasValue);
                Assert.Throws<InvalidOperationException>(() => _ = oit.Value);
            }
        }

        [Test]
        public async Task UpdateStatusWhenOperationSucceeds([Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Success, mockResponse) : CreateOperation(UpdateResult.Success, mockResponse);

            Response operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.True(oit.HasValue);
                Assert.AreEqual(expectedValue, oit.Value);
            }
        }

        [Test]
        public void UpdateStatusWhenOperationFails(
            [Values(true, false)] bool async,
            [Values(true, false)] bool useDefaultException,
            [Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = useDefaultException switch
            {
                true => isOfT ? CreateOperationOfT(UpdateResult.Failure, mockResponse) : CreateOperation(UpdateResult.Failure, mockResponse),
                false => isOfT
                    ? CreateOperationOfT(UpdateResult.FailureCustomException, mockResponse)
                    : CreateOperation(UpdateResult.FailureCustomException, mockResponse)
            };

            RequestFailedException thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            if (!useDefaultException)
            {
                Assert.AreEqual(originalException, thrownException);
            }

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.False(oit.HasValue);
                RequestFailedException valueException = Assert.Throws<RequestFailedException>(() => _ = oit.Value);
                Assert.AreEqual(thrownException, valueException);
            }
        }

        [Test]
        public void UpdateStatusWhenOperationThrows( [Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Throw) : CreateOperation(UpdateResult.Throw);

            StackOverflowException thrownException = async
                ? Assert.ThrowsAsync<StackOverflowException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<StackOverflowException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(customException, thrownException);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.False(oit.HasValue);
                Assert.Throws<InvalidOperationException>(() => _ = oit.Value);
            }
        }

        [Test]
        public async Task UpdateStatusCreatesDiagnosticScope(
            [Values(true, false)] bool async,
            [Values(true, false)] bool useDefaultTypeName,
            [Values(true, false)] bool isOfT)
        {
            const string customTypeName = "CustomTypeName";
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationTypeName = isOfT ? nameof(TestOperationOfT) : nameof(TestOperation);
            string expectedTypeName = useDefaultTypeName ? operationTypeName : customTypeName;
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT
                ? CreateOperationOfT(
                    UpdateResult.Pending,
                    mockResponse,
                    operationTypeName: useDefaultTypeName ? null : customTypeName,
                    scopeAttributes: expectedAttributes)
                : CreateOperation(
                    UpdateResult.Pending,
                    mockResponse,
                    useDefaultTypeName ? null : customTypeName,
                    expectedAttributes);

            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.UpdateStatus", expectedAttributes);
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationFails([Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            MockResponse mockResponse = new(200);
            var operationInternal =
                isOfT ? CreateOperationOfT(UpdateResult.FailureCustomException, mockResponse) : CreateOperation(UpdateResult.FailureCustomException, mockResponse);

            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = isOfT ? nameof(TestOperationOfT) : nameof(TestOperation);
            testListener.AssertScopeException(
                $"{expectedTypeName}.UpdateStatus",
                scopeException =>
                {
                    Assert.AreEqual(originalException, scopeException);
                });
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationThrows([Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            MockResponse mockResponse = new(200);
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Throw, mockResponse) : CreateOperation(UpdateResult.Throw, mockResponse);

            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = isOfT ? nameof(TestOperationOfT) : nameof(TestOperation);
            testListener.AssertScopeException(
                $"{expectedTypeName}.UpdateStatus",
                scopeException =>
                    Assert.AreEqual(customException, scopeException));
        }

        [Test]
        public async Task UpdateStatusPassesTheCancellationTokenToUpdateState([Values(true, false)] bool async, [Values(true, false)] bool isOfT)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;

            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Pending, mockResponse) : CreateOperation(UpdateResult.Pending, mockResponse);

            _ = async
                ? await operationInternal.UpdateStatusAsync(originalToken)
                : operationInternal.UpdateStatus(originalToken);

            CancellationToken passedToken = ((IMockOperationInternal)operationInternal).LastTokenReceivedByUpdateStatus;
            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        public async Task WaitForCompletionCallsUntilOperationCompletes( [Values(true, false)] bool useDefaultPollingInterval, [Values(true, false)] bool isOfT)
        {
            int expectedCalls = 5;
            int expectedValue = 50;
            MockResponse mockResponse = new(200);
            var operationInternal =
                isOfT
                    ? CreateOperationOfT(UpdateResult.Pending, mockResponse, callsToComplete: expectedCalls)
                    : CreateOperation(UpdateResult.Pending, mockResponse, callsToComplete: expectedCalls);

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            var operationResponse = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionAsync(CancellationToken.None)
                : await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);
            int callsCount = ((IMockOperationInternal)operationInternal).UpdateStatusCallCount;
            Assert.AreEqual(expectedCalls, callsCount);
            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit)
            {
                Assert.True(oit.HasValue);
                Assert.AreEqual(expectedValue, oit.Value);
            }
        }

        [Test]
        public async Task WaitForCompletionUsesRightPollingInterval([Values(true, false)] bool useDefaultPollingInterval, [Values(true, false)] bool isOfT)
        {
            TimeSpan expectedDelay = TimeSpan.FromMilliseconds(100);
            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Pending, mockResponse, callsToComplete: 2) : CreateOperation(UpdateResult.Pending, mockResponse, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = expectedDelay;
                await operationInternal.WaitForCompletionAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionAsync(expectedDelay, CancellationToken.None);
            }

            Assert.AreEqual(expectedDelay, ((IMockOperationInternal)operationInternal).DelayPassedToWait);
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterHeader(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values(true, false)] bool isOfT,
            [Values(1, 2, 3)] int delayValue)
        {
            TimeSpan originalDelay = TimeSpan.FromSeconds(2);
            TimeSpan serviceDelay = TimeSpan.FromSeconds(delayValue);
            MockResponse mockResponse = new(200);
            mockResponse.AddHeader(new HttpHeader("Retry-After", delayValue.ToString()));

            var operationInternal =
                isOfT
                    ? CreateOperationOfT(UpdateResult.Pending, mockResponse, callsToComplete: 2)
                    : CreateOperation(UpdateResult.Pending, mockResponse, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = originalDelay;
                await operationInternal.WaitForCompletionAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionAsync(originalDelay, CancellationToken.None);
            }

            // Algorithm must choose the longest delay between the two.
            Assert.AreEqual(Max(originalDelay, serviceDelay), ((IMockOperationInternal)operationInternal).DelayPassedToWait);
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterMsHeader(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values(true, false)] bool isOfT,
            [Values("retry-after-ms", "x-ms-retry-after-ms")]
            string headerName,
            [Values(250, 500, 750)] int delayValue)
        {
            TimeSpan originalDelay = TimeSpan.FromMilliseconds(500);
            TimeSpan serviceDelay = TimeSpan.FromMilliseconds(delayValue);

            MockResponse mockResponse = new(200);
            mockResponse.AddHeader(new HttpHeader(headerName, serviceDelay.Milliseconds.ToString()));
            var operationInternal =
                isOfT
                    ? CreateOperationOfT(UpdateResult.Pending, mockResponse, callsToComplete: 2)
                    : CreateOperation(UpdateResult.Pending, mockResponse, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = originalDelay;
                await operationInternal.WaitForCompletionAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionAsync(originalDelay, CancellationToken.None);
            }

            // Algorithm must choose the longest delay between the two.
            Assert.AreEqual(Max(originalDelay, serviceDelay), ((IMockOperationInternal)operationInternal).DelayPassedToWait);
        }

        [Test]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values(true, false)] bool isOfT)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;

            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Success, mockResponse) : CreateOperation(UpdateResult.Success, mockResponse);

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionAsync(originalToken)
                : await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, originalToken);

            Assert.AreEqual(originalToken, ((IMockOperationInternal)operationInternal).LastTokenReceivedByUpdateStatus);
        }

        [Test]
        public void WaitForCompletionPassesTheCancellationTokenToTaskDelay([Values(true, false)] bool useDefaultPollingInterval, [Values(true, false)] bool isOfT)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken cancellationToken = tokenSource.Token;

            tokenSource.Cancel();

            MockResponse mockResponse = new(200);
            var operationInternal = isOfT ? CreateOperationOfT(UpdateResult.Pending, mockResponse) : CreateOperation(UpdateResult.Pending, mockResponse);

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, cancellationToken));
        }

        private TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;

        private class TestOperationOfT : IOperation<int>
        {
            public TestOperationOfT(
                UpdateResult result,
                MockResponse mockResponse = null,
                string operationTypeName = null,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
                int? callsToComplete = null)
            {
                MockOperationInternal = new MockOperationInternalOfT<int>(ClientDiagnostics, this, mockResponse, operationTypeName, scopeAttributes);
                MockOperationInternal.CallsToComplete = callsToComplete;

                OnUpdateState = result switch
                {
                    UpdateResult.Pending => _ =>
                    {
                        return MockOperationInternal.CallsToComplete.HasValue &&
                               MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                            ? OperationState<int>.Success(mockResponse, expectedValue)
                            : OperationState<int>.Pending(mockResponse);
                    },
                    UpdateResult.Failure => _ => OperationState<int>.Failure(mockResponse),
                    UpdateResult.FailureCustomException => _ => OperationState<int>.Failure(mockResponse, originalException),
                    UpdateResult.Success => _ => OperationState<int>.Success(mockResponse, expectedValue),
                    UpdateResult.Throw => _ => throw customException,
                    _ => null
                };
            }

            public MockOperationInternalOfT<int> MockOperationInternal { get; }

            public Func<CancellationToken, OperationState<int>> OnUpdateState { get; set; }

            ValueTask<OperationState<int>> IOperation<int>.UpdateStateAsync(bool async, CancellationToken cancellationToken)
            {
                MockOperationInternal.UpdateStatusCallCount++;
                MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
                return new ValueTask<OperationState<int>>(OnUpdateState(cancellationToken));
            }
        }

        private class MockOperationInternalOfT<TResult> : OperationInternal<TResult>, IMockOperationInternal
        {
            public MockOperationInternalOfT(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation, Response rawResponse)
                : base(clientDiagnostics, operation, rawResponse)
            { }

            public MockOperationInternalOfT(
                ClientDiagnostics clientDiagnostics,
                IOperation<TResult> operation,
                Response rawResponse,
                string operationTypeName,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes)
                : base(clientDiagnostics, operation, rawResponse, operationTypeName, scopeAttributes)
            { }

            public TimeSpan DelayPassedToWait { get; set; }

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                DelayPassedToWait = delay;
                await base.WaitAsync(TimeSpan.Zero, cancellationToken);
            }

            public CancellationToken LastTokenReceivedByUpdateStatus { get; set; }

            public int UpdateStatusCallCount { get; set; }
            public int? CallsToComplete { get; set; }
        }

        private class TestOperation : IOperation
        {
            public TestOperation(
                UpdateResult result,
                MockResponse mockResponse = null,
                string operationTypeName = null,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
                int? callsToComplete = null)
            {
                MockOperationInternal = new MockOperationInternal(ClientDiagnostics, this, mockResponse, operationTypeName, scopeAttributes);
                MockOperationInternal.CallsToComplete = callsToComplete;

                OnUpdateState = result switch
                {
                    UpdateResult.Pending => _ =>
                    {
                        return MockOperationInternal.CallsToComplete.HasValue &&
                               MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                            ? OperationState.Success(mockResponse)
                            : OperationState.Pending(mockResponse);
                    },
                    UpdateResult.Failure => _ => OperationState.Failure(mockResponse),
                    UpdateResult.FailureCustomException => _ => OperationState.Failure(mockResponse, originalException),
                    UpdateResult.Success => _ => OperationState.Success(mockResponse),
                    UpdateResult.Throw => _ => throw customException,
                    _ => null
                };
            }

            public MockOperationInternal MockOperationInternal { get; }

            public Func<CancellationToken, OperationState> OnUpdateState { get; set; }

            ValueTask<OperationState> IOperation.UpdateStateAsync(bool async, CancellationToken cancellationToken)
            {
                MockOperationInternal.UpdateStatusCallCount++;
                MockOperationInternal.LastTokenReceivedByUpdateStatus = cancellationToken;
                return new(OnUpdateState(cancellationToken));
            }
        }

        private class MockOperationInternal : OperationInternal, IMockOperationInternal
        {
            public MockOperationInternal(ClientDiagnostics clientDiagnostics, IOperation operation, Response rawResponse)
                : base(clientDiagnostics, operation, rawResponse)
            { }

            public MockOperationInternal(
                ClientDiagnostics clientDiagnostics,
                IOperation operation,
                Response rawResponse,
                string operationTypeName,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes)
                : base(clientDiagnostics, operation, rawResponse, operationTypeName, scopeAttributes)
            { }

            public TimeSpan DelayPassedToWait { get; set; }

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                DelayPassedToWait = delay;
                await base.WaitAsync(TimeSpan.Zero, cancellationToken);
            }

            public CancellationToken LastTokenReceivedByUpdateStatus { get; set; }

            public int UpdateStatusCallCount { get; set; }
            public int? CallsToComplete { get; set; }
        }

        private interface IMockOperationInternal
        {
            TimeSpan DelayPassedToWait { get; set; }
            CancellationToken LastTokenReceivedByUpdateStatus { get; set; }
            int UpdateStatusCallCount { get; set; }
        }

        private class TestClientOption : ClientOptions
        { }

        private enum UpdateResult
        {
            Pending,
            Failure,
            FailureCustomException,
            Success,
            Throw
        }
    }
}
