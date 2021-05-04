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
    public class OperationInternalTests
    {
        private static readonly string DiagnosticNamespace = "Azure.Core.Tests";

        private static ClientDiagnostics ClientDiagnostics = new ClientDiagnostics(new TestClientOption());

        [Test]
        public void InitialState()
        {
            var testOperation = new TestOperation();
            var operationInternal = testOperation.OperationInternal;

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);
            Assert.AreEqual(nameof(TestOperation), operationInternal.OperationTypeName);
            Assert.IsNotNull(operationInternal.ScopeAttributes);
            Assert.IsEmpty(operationInternal.ScopeAttributes);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusWhenOperationIsPending(bool async)
        {
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.OperationInternal;

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusWhenOperationSucceeds(bool async)
        {
            var expectedValue = 50;
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Success(mockResponse, expectedValue)
            };
            var operationInternal = testOperation.OperationInternal;

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.True(operationInternal.HasValue);
            Assert.AreEqual(expectedValue, operationInternal.Value);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UpdateStatusWhenOperationFails(bool async)
        {
            var originalException = new RequestFailedException("");
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Failure(mockResponse, originalException)
            };
            var operationInternal = testOperation.OperationInternal;

            var thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(originalException, thrownException);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);

            var valueException = Assert.Throws<RequestFailedException>(() => _ = operationInternal.Value);
            Assert.AreEqual(originalException, valueException);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UpdateStatusWhenOperationThrows(bool async)
        {
            var originalException = new StackOverflowException();
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => throw originalException
            };
            var operationInternal = testOperation.OperationInternal;

            var thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(originalException, thrownException.InnerException);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusCreatesDiagnosticScope(bool async)
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            var expectedTypeName = "CustomTypeName";
            var expectedAttributes = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("key1", "value1"),
                new KeyValuePair<string, string>("key2", "value2")
            };

            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.OperationInternal;

            operationInternal.OperationTypeName = expectedTypeName;

            foreach (var kvp in expectedAttributes)
            {
                operationInternal.ScopeAttributes.Add(kvp);
            }

            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.UpdateStatus", expectedAttributes);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusSetsFailedScopeWhenOperationFails(bool async)
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            var originalException = new RequestFailedException("");
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Failure(mockResponse, originalException)
            };
            var operationInternal = testOperation.OperationInternal;

            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            testListener.AssertScopeException($"{nameof(TestOperation)}.UpdateStatus", (Exception scopeException) =>
            {
                Assert.AreEqual(originalException, scopeException);
            });
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusSetsFailedScopeWhenOperationThrows(bool async)
        {
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            var originalException = new StackOverflowException();
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => throw originalException
            };
            var operationInternal = testOperation.OperationInternal;

            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            testListener.AssertScopeException($"{nameof(TestOperation)}.UpdateStatus", (Exception scopeException) =>
            {
                Assert.IsInstanceOf(typeof(RequestFailedException), scopeException);
                Assert.AreEqual(originalException, scopeException.InnerException);
            });
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateStatusPassesTheCancellationTokenToUpdateState(bool async)
        {
            using var tokenSource = new CancellationTokenSource();
            var originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = cancellationToken =>
                {
                    passedToken = cancellationToken;
                    return OperationState<int>.Pending(mockResponse);
                }
            };
            var operationInternal = testOperation.OperationInternal;

            _ = async
                ? await operationInternal.UpdateStatusAsync(originalToken)
                : operationInternal.UpdateStatus(originalToken);

            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task WaitForCompletionCallsUntilOperationCompletes(bool useDefaultPollingInterval)
        {
            var callsCount = 0;
            var expectedCalls = 5;
            var expectedValue = 50;
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount >= expectedCalls
                    ? OperationState<int>.Success(mockResponse, expectedValue)
                    : OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.OperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            var operationResponse = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionAsync(CancellationToken.None)
                : await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse.GetRawResponse());
            Assert.AreEqual(expectedCalls, callsCount);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.True(operationInternal.HasValue);
            Assert.AreEqual(expectedValue, operationInternal.Value);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState(bool useDefaultPollingInterval)
        {
            using var tokenSource = new CancellationTokenSource();
            var originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = cancellationToken =>
                {
                    passedToken = cancellationToken;
                    return OperationState<int>.Success(mockResponse, default);
                }
            };
            var operationInternal = testOperation.OperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionAsync(originalToken)
                : await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, originalToken);

            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void WaitForCompletionPassesTheCancellationTokenToTaskDelay(bool useDefaultPollingInterval)
        {
            using var tokenSource = new CancellationTokenSource();
            var cancellationToken = tokenSource.Token;

            tokenSource.Cancel();

            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.OperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, cancellationToken));
        }

        private class TestOperation : IOperation<int>
        {
            public TestOperation()
            {
                OperationInternal = new OperationInternal<int>(ClientDiagnostics, this);
            }

            public OperationInternal<int> OperationInternal { get; }

            public Func<CancellationToken, OperationState<int>> OnUpdateState { get; set; }

            ValueTask<OperationState<int>> IOperation<int>.UpdateStateAsync(bool async, CancellationToken cancellationToken) =>
                new ValueTask<OperationState<int>>(OnUpdateState(cancellationToken));
        }

        private class TestClientOption : ClientOptions
        {
        }
    }
}
