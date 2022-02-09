// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class OperationInternalTests
    {
        private readonly bool isOfT;
        private static readonly string DiagnosticNamespace = "Azure.Core.Tests";

        private static ClientDiagnostics ClientDiagnostics = new(new TestClientOption());
        private static RequestFailedException originalException = new("");
        private static StackOverflowException customException = new();
        private static int expectedValue = 50;
        private static MockResponse mockResponse = new(200);
        private Func<MockResponse> mockResponseFactory = () => mockResponse;

        public OperationInternalTests(bool isOfT) { this.isOfT = isOfT; }

        private OperationInternalBase CreateOperation(
            bool isOfT,
            UpdateResult result,
            Func<MockResponse> responseFactory = null,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null)
        {
            if (isOfT)
            {
                TestOperationOfT testOperationOfT = new(
                    result,
                    responseFactory ?? (() => null),
                    operationTypeName,
                    callsToComplete: callsToComplete,
                    scopeAttributes: scopeAttributes);
                var operationInternalOfT = testOperationOfT.MockOperationInternal;
                return operationInternalOfT;
            }
            TestOperation testOperation = new(
                result,
                responseFactory ?? (() => null),
                operationTypeName,
                callsToComplete: callsToComplete,
                scopeAttributes: scopeAttributes);
            var operationInternal = testOperation.MockOperationInternal;
            return operationInternal;
        }

        [Test]
        public void DefaultPropertyInitialization()
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Success);
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
        public void RawResponseInitialization()
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory);
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
        public void SetStateSucceeds()
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending);
            if (operationInternal is OperationInternal oi)
            {
                oi.SetState(OperationState.Success(mockResponse));
            }
            else if (operationInternal is OperationInternal<int> oit)
            {
                oit.SetState(OperationState<int>.Success(mockResponse, 1));
            }

            Assert.IsTrue(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit2)
            {
                Assert.IsTrue(oit2.HasValue);
                Assert.AreEqual(1, oit2.Value);
            }
        }

        [Test]
        public void SetStateIsPending()
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending);
            if (operationInternal is OperationInternal oi)
            {
                oi.SetState(OperationState.Pending(mockResponse));
            }
            else if (operationInternal is OperationInternal<int> oit)
            {
                oit.SetState(OperationState<int>.Pending(mockResponse));
            }

            Assert.IsFalse(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit2)
            {
                Assert.IsFalse(oit2.HasValue);
            }
        }

        [Test]
        public void SetStateFails()
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending);
            if (operationInternal is OperationInternal oi)
            {
                oi.SetState(OperationState.Failure(mockResponse));
            }
            else if (operationInternal is OperationInternal<int> oit)
            {
                oit.SetState(OperationState<int>.Failure(mockResponse));
            }

            Assert.IsTrue(operationInternal.HasCompleted);
            if (operationInternal is OperationInternal<int> oit2)
            {
                Assert.IsFalse(oit2.HasValue);
                Assert.Throws<RequestFailedException>(() => _ = oit2.Value);
            }
        }

        [Test]
        public async Task UpdateStatusWhenOperationIsPending([Values(true, false)] bool async)
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory);
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
        public async Task UpdateStatusWhenOperationSucceeds([Values(true, false)] bool async)
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Success, mockResponseFactory);

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
            [Values(true, false)] bool useDefaultException)
        {
            var operationInternal = useDefaultException switch
            {
                true => CreateOperation(isOfT, UpdateResult.Failure, mockResponseFactory),
                false => CreateOperation(isOfT, UpdateResult.FailureCustomException, mockResponseFactory)
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
        public void UpdateStatusWhenOperationThrows([Values(true, false)] bool async)
        {
            var operationInternal = CreateOperation(isOfT, UpdateResult.Throw);
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
            [Values(true, false)] bool useDefaultTypeName)
        {
            const string customTypeName = "CustomTypeName";
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationTypeName = isOfT ? nameof(TestOperationOfT) : nameof(TestOperation);
            string expectedTypeName = useDefaultTypeName ? operationTypeName : customTypeName;
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = CreateOperation(
                    isOfT,
                    UpdateResult.Pending,
                    mockResponseFactory,
                    useDefaultTypeName ? null : customTypeName,
                    expectedAttributes);

            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.UpdateStatus", expectedAttributes);
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationFails([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = CreateOperation(isOfT, UpdateResult.FailureCustomException, mockResponseFactory);
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
        public async Task UpdateStatusSetsFailedScopeWhenOperationThrows([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);
            var operationInternal = CreateOperation(isOfT, UpdateResult.Throw, mockResponseFactory);
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
        public async Task UpdateStatusPassesTheCancellationTokenToUpdateState([Values(true, false)] bool async)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;

            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory);
            _ = async
                ? await operationInternal.UpdateStatusAsync(originalToken)
                : operationInternal.UpdateStatus(originalToken);

            CancellationToken passedToken = ((IMockOperationInternal)operationInternal).LastTokenReceivedByUpdateStatus;
            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        public async Task WaitForCompletionCallsUntilOperationCompletes([Values(true, false)] bool useDefaultPollingInterval)
        {
            int expectedCalls = 5;
            int expectedValue = 50;
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: expectedCalls);

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            var operationResponse = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, CancellationToken.None);

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
        public async Task WaitForCompletionUsesRightPollingInterval([Values(true, false)] bool useDefaultPollingInterval)
        {
            TimeSpan expectedDelay = TimeSpan.FromMilliseconds(100);
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = expectedDelay;
                await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionResponseAsync(expectedDelay, CancellationToken.None);
            }

            Assert.AreEqual(expectedDelay, ((IMockOperationInternal)operationInternal).DelaysPassedToWait.Single());
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterHeader(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values(1, 2, 3)] int delayValue)
        {
            TimeSpan originalDelay = TimeSpan.FromSeconds(2);
            TimeSpan serviceDelay = TimeSpan.FromSeconds(delayValue);
            var response = new MockResponse(200);
            response.AddHeader(new HttpHeader("Retry-After", delayValue.ToString()));
            Func<MockResponse> factoryWithHeaders = () => response;

            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, factoryWithHeaders, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = originalDelay;
                await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionResponseAsync(originalDelay, CancellationToken.None);
            }

            // Algorithm must choose the longest delay between the two.
            Assert.AreEqual(Max(originalDelay, serviceDelay), ((IMockOperationInternal)operationInternal).DelaysPassedToWait.Single());
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterHeaderForMultipleWaits()
        {
            TimeSpan originalDelay = TimeSpan.FromSeconds(2);
            Random rnd = new();
            List<TimeSpan> expectedDelays = new();
            Func<MockResponse> responseWithHeaders = () =>
            {
                var response = new MockResponse(200);
                int delayValue = rnd.Next(3, 100);
                expectedDelays.Add(TimeSpan.FromSeconds(delayValue));
                response.AddHeader(new HttpHeader("Retry-After", delayValue.ToString()));
                return response;
            };

            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, responseWithHeaders, callsToComplete: 5);

            await operationInternal.WaitForCompletionResponseAsync(originalDelay, CancellationToken.None);

            // remove the first and last items from expectedDelays, because the first is produced when the mock is constructed
            // and the last is produced on the final success call
            Assert.AreEqual(expectedDelays.Skip(1).Take(4), ((IMockOperationInternal)operationInternal).DelaysPassedToWait);
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterMsHeader(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values("retry-after-ms", "x-ms-retry-after-ms")]
            string headerName,
            [Values(250, 500, 750)] int delayValue)
        {
            TimeSpan originalDelay = TimeSpan.FromMilliseconds(500);
            TimeSpan serviceDelay = TimeSpan.FromMilliseconds(delayValue);
            var response = new MockResponse(200);
            response.AddHeader(new HttpHeader(headerName, serviceDelay.Milliseconds.ToString()));
            Func<MockResponse> factoryWithHeader = () => response;
            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, factoryWithHeader, callsToComplete: 2);

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = originalDelay;
                await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionResponseAsync(originalDelay, CancellationToken.None);
            }

            // Algorithm must choose the longest delay between the two.
            Assert.AreEqual(Max(originalDelay, serviceDelay), ((IMockOperationInternal)operationInternal).DelaysPassedToWait.Single());
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterMsHeaderForMultipleWaits(
            [Values("retry-after-ms", "x-ms-retry-after-ms")] string headerName)
        {
            TimeSpan originalDelay = TimeSpan.FromMilliseconds(500);
            Random rnd = new();
            List<TimeSpan> expectedDelays = new();
            Func<MockResponse> responseWithHeaders = () =>
            {
                var response = new MockResponse(200);
                int delayValue = rnd.Next(600, 1000);
                expectedDelays.Add(TimeSpan.FromMilliseconds(delayValue));
                response.AddHeader(new HttpHeader(headerName, delayValue.ToString()));
                return response;
            };

            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, responseWithHeaders, callsToComplete: 5);

            await operationInternal.WaitForCompletionResponseAsync(originalDelay, CancellationToken.None);

            // remove the first and last items from expectedDelays, because the first is produced when the mock is constructed
            // and the last is produced on the final success call
            Assert.AreEqual(expectedDelays.Skip(1).Take(4), ((IMockOperationInternal)operationInternal).DelaysPassedToWait);
        }

        [Test]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState(
            [Values(true, false)] bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;

            var operationInternal = CreateOperation(isOfT, UpdateResult.Success, mockResponseFactory);
            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionResponseAsync(originalToken)
                : await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, originalToken);

            Assert.AreEqual(originalToken, ((IMockOperationInternal)operationInternal).LastTokenReceivedByUpdateStatus);
        }

        [Test]
        public void WaitForCompletionPassesTheCancellationTokenToTaskDelay([Values(true, false)] bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken cancellationToken = tokenSource.Token;

            tokenSource.Cancel();

            var operationInternal = CreateOperation(isOfT, UpdateResult.Pending, mockResponseFactory);
            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, cancellationToken));
        }

        private TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;

        private class TestOperationOfT : IOperation<int>
        {
            public TestOperationOfT(
                UpdateResult result,
                Func<MockResponse> responseFactory,
                string operationTypeName = null,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
                int? callsToComplete = null)
            {
                MockOperationInternal = new MockOperationInternalOfT<int>(ClientDiagnostics, this, responseFactory, operationTypeName, scopeAttributes);
                MockOperationInternal.CallsToComplete = callsToComplete;

                OnUpdateState = result switch
                {
                    UpdateResult.Pending => _ =>
                    {
                        return MockOperationInternal.CallsToComplete.HasValue &&
                               MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                            ? OperationState<int>.Success(responseFactory(), expectedValue)
                            : OperationState<int>.Pending(responseFactory());
                    },
                    UpdateResult.Failure => _ => OperationState<int>.Failure(responseFactory()),
                    UpdateResult.FailureCustomException => _ => OperationState<int>.Failure(responseFactory(), originalException),
                    UpdateResult.Success => _ => OperationState<int>.Success(responseFactory(), expectedValue),
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
                Func<MockResponse> responseFactory,
                string operationTypeName,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes)
                : base(clientDiagnostics, operation, responseFactory(), operationTypeName, scopeAttributes)
            { }

            public List<TimeSpan> DelaysPassedToWait { get; set; } = new();

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                DelaysPassedToWait.Add(delay);
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
                Func<MockResponse> responseFactory,
                string operationTypeName = null,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
                int? callsToComplete = null)
            {
                MockOperationInternal = new MockOperationInternal(ClientDiagnostics, this, responseFactory, operationTypeName, scopeAttributes);
                MockOperationInternal.CallsToComplete = callsToComplete;

                OnUpdateState = result switch
                {
                    UpdateResult.Pending => _ =>
                    {
                        return MockOperationInternal.CallsToComplete.HasValue &&
                               MockOperationInternal.UpdateStatusCallCount >= MockOperationInternal.CallsToComplete.Value
                            ? OperationState.Success(responseFactory())
                            : OperationState.Pending(responseFactory());
                    },
                    UpdateResult.Failure => _ => OperationState.Failure(responseFactory()),
                    UpdateResult.FailureCustomException => _ => OperationState.Failure(responseFactory(), originalException),
                    UpdateResult.Success => _ => OperationState.Success(responseFactory()),
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
                Func<MockResponse> responseFactory,
                string operationTypeName,
                IEnumerable<KeyValuePair<string, string>> scopeAttributes)
                : base(clientDiagnostics, operation, responseFactory(), operationTypeName, scopeAttributes)
            { }

            public List<TimeSpan> DelaysPassedToWait { get; set; } = new();

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                DelaysPassedToWait.Add(delay);
                await base.WaitAsync(TimeSpan.Zero, cancellationToken);
            }

            public CancellationToken LastTokenReceivedByUpdateStatus { get; set; }

            public int UpdateStatusCallCount { get; set; }
            public int? CallsToComplete { get; set; }
        }

        private interface IMockOperationInternal
        {
            List<TimeSpan> DelaysPassedToWait { get; set; }
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
