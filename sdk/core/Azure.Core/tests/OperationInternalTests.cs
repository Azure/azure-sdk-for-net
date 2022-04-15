// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestClients;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class OperationInternalTests
    {
        private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(1);

        private readonly bool isOfT;
        private static readonly string DiagnosticNamespace = "Azure.Core.Tests";

        private static ClientDiagnostics ClientDiagnostics = new(new TestClientOptions());
        private static RequestFailedException originalException = new("");
        private static StackOverflowException customException = new();
        private static int expectedValue = 50;
        private static MockResponse mockResponse = new(200);
        private Func<MockResponse> mockResponseFactory = () => mockResponse;

        public OperationInternalTests(bool isOfT) { this.isOfT = isOfT; }

        private OperationInternalBase CreateOperationAsInternalBase(
            bool isOfT,
            UpdateResult result,
            Func<MockResponse> responseFactory = null,
            string operationTypeName = null,
            IEnumerable<KeyValuePair<string, string>> scopeAttributes = null,
            int? callsToComplete = null,
            DelayStrategy fallbackStrategy = null,
            Exception customExceptionOnUpdate = null,
            RequestFailedException originalExceptionOnUpdate = null)
        {
            if (isOfT)
            {
                return new MockOperationOfInt(
                    result,
                    responseFactory ?? (() => null),
                    operationTypeName,
                    callsToComplete: callsToComplete,
                    scopeAttributes: scopeAttributes,
                    fallbackStrategy: fallbackStrategy,
                    customExceptionOnUpdate: customExceptionOnUpdate,
                    originalExceptionOnUpdate: originalExceptionOnUpdate).MockOperationInternal;
            }
            else
            {
                return new MockOperation(
                    result,
                    responseFactory ?? (() => null),
                    operationTypeName,
                    callsToComplete: callsToComplete,
                    scopeAttributes: scopeAttributes,
                    fallbackStrategy: fallbackStrategy,
                    customExceptionOnUpdate: customExceptionOnUpdate,
                    originalExceptionOnUpdate: originalExceptionOnUpdate).MockOperationInternal;
            }
        }

        [Test]
        public void DefaultPropertyInitialization()
        {
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Success);

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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory);

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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Success, mockResponseFactory);

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
                true => CreateOperationAsInternalBase(isOfT, UpdateResult.Failure, mockResponseFactory),
                false => CreateOperationAsInternalBase(isOfT, UpdateResult.FailureCustomException, mockResponseFactory, originalExceptionOnUpdate: originalException)
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Throw, customExceptionOnUpdate: customException);
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

            var operationTypeName = isOfT ? nameof(MockOperationOfInt) : nameof(MockOperation);
            string expectedTypeName = useDefaultTypeName ? operationTypeName : customTypeName;
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = CreateOperationAsInternalBase(
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

            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.FailureCustomException, mockResponseFactory, originalExceptionOnUpdate: originalException);
            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = isOfT ? nameof(MockOperationOfInt) : nameof(MockOperation);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Throw, mockResponseFactory, customExceptionOnUpdate: customException);
            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = isOfT ? nameof(MockOperationOfInt) : nameof(MockOperation);
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

            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory);
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
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: expectedCalls, fallbackStrategy: new ZeroPollingStrategy());

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
        public async Task WaitForCompletionUsesZeroPollingInterval(
            [Values(true, false)] bool hasSuggest,
            [Values(1, 2, 3)] int count)
        {
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: count, fallbackStrategy: new ZeroPollingStrategy());

            if (hasSuggest)
            {
                await operationInternal.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(10), CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);
            }

            Assert.IsTrue(((IMockOperationInternal)operationInternal).DelaysPassedToWait.All(d => d == TimeSpan.Zero));
        }

        [Test]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState(
            [Values(true, false)] bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;

            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Success, mockResponseFactory, fallbackStrategy: new ZeroPollingStrategy());

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

            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory, fallbackStrategy: new ZeroPollingStrategy());

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, cancellationToken));
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitResponseAsync(
            [Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWaitResponse(
            [Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();
            var operationInternal = CreateOperationAsInternalBase(isOfT, UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = operationInternal.WaitForCompletionResponse(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitResponseAsyncAsOperation(
            [Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();
            var operation = new MockOperation(UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = await operation.WaitForCompletionResponseAsync(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWaitResponseAsOperation(
            [Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();
            var opeartion = new MockOperation(UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = opeartion.WaitForCompletionResponse(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitAsync(
            [Values(1, 3)] int retries)
        {
            if (!isOfT)
                return; //invalid for non T

            var fallbackStrategy = new MockDelayStrategy();
            var operation = new MockOperationOfInt(UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = await operation.WaitForCompletionAsync(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWait(
            [Values(1, 3)] int retries)
        {
            if (!isOfT)
                return; //invalid for non T

            var fallbackStrategy = new MockDelayStrategy();
            var operation = new MockOperationOfInt(UpdateResult.Pending, mockResponseFactory, callsToComplete: retries, fallbackStrategy: fallbackStrategy);

            _ = operation.WaitForCompletion(CancellationToken.None);

            Assert.AreEqual(retries - 1, fallbackStrategy.CallCount);
        }
    }
}
