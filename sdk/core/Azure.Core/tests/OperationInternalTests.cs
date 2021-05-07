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
        public void DefaultPropertyInitialization()
        {
            var testOperation = new TestOperation();
            var operationInternal = testOperation.MockOperationInternal;

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);
            Assert.IsNotNull(operationInternal.ScopeAttributes);
            Assert.IsEmpty(operationInternal.ScopeAttributes);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public void RawResponseInitialization()
        {
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation(mockResponse);
            var operationInternal = testOperation.MockOperationInternal;

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);
            Assert.IsNotNull(operationInternal.ScopeAttributes);
            Assert.IsEmpty(operationInternal.ScopeAttributes);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
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
            var operationInternal = testOperation.MockOperationInternal;

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
            var operationInternal = testOperation.MockOperationInternal;

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
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void UpdateStatusWhenOperationFails(bool async, bool useDefaultException)
        {
            var originalException = new RequestFailedException("");
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => useDefaultException
                    ? OperationState<int>.Failure(mockResponse)
                    : OperationState<int>.Failure(mockResponse, originalException)
            };
            var operationInternal = testOperation.MockOperationInternal;

            var thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            if (!useDefaultException)
            {
                Assert.AreEqual(originalException, thrownException);
            }

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);

            var valueException = Assert.Throws<RequestFailedException>(() => _ = operationInternal.Value);
            Assert.AreEqual(thrownException, valueException);
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
            var operationInternal = testOperation.MockOperationInternal;

            var thrownException = async
                ? Assert.ThrowsAsync<StackOverflowException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<StackOverflowException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(originalException, thrownException);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public async Task UpdateStatusCreatesDiagnosticScope(
            [Values(true, false)] bool async,
            [Values(true, false)] bool useDefaultTypeName)
        {
            const string customTypeName = "CustomTypeName";
            using var testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            var expectedTypeName = useDefaultTypeName ? nameof(TestOperation) : customTypeName;
            var expectedAttributes = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("key1", "value1"),
                new KeyValuePair<string, string>("key2", "value2")
            };

            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation(operationTypeName: useDefaultTypeName ? null : customTypeName)
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.MockOperationInternal;

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
            var operationInternal = testOperation.MockOperationInternal;

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
            var operationInternal = testOperation.MockOperationInternal;

            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            testListener.AssertScopeException($"{nameof(TestOperation)}.UpdateStatus", (Exception scopeException) =>
                Assert.AreEqual(originalException, scopeException));
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
            var operationInternal = testOperation.MockOperationInternal;

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
            var operationInternal = testOperation.MockOperationInternal;

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
        public async Task WaitForCompletionUsesRightPollingInterval(bool useDefaultPollingInterval)
        {
            var expectedDelay = TimeSpan.FromMilliseconds(100);
            TimeSpan passedDelay = default;

            var callsCount = 0;
            var mockResponse = new MockResponse(200);
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount >= 2
                    ? OperationState<int>.Success(mockResponse, 50)
                    : OperationState<int>.Pending(mockResponse)
            };
            var operationInternal = testOperation.MockOperationInternal;

            operationInternal.OnWait = delay => passedDelay = delay;

            if (useDefaultPollingInterval)
            {
                operationInternal.DefaultPollingInterval = expectedDelay;
                await operationInternal.WaitForCompletionAsync(CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionAsync(expectedDelay, CancellationToken.None);
            }

            Assert.AreEqual(expectedDelay, passedDelay);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task WaitForCompletionUsesRetryAfterHeader(bool useDefaultPollingInterval)
        {
            var originalDelay = TimeSpan.FromSeconds(2);
            var shortDelay = originalDelay.Subtract(TimeSpan.FromSeconds(1));
            var longDelay = originalDelay.Add(TimeSpan.FromSeconds(1));
            var passedDelays = new List<TimeSpan>();

            var shortDelayMockResponse = new MockResponse(200);
            shortDelayMockResponse.AddHeader(new HttpHeader("Retry-After", shortDelay.Seconds.ToString()));

            var longDelayMockResponse = new MockResponse(200);
            longDelayMockResponse.AddHeader(new HttpHeader("Retry-After", longDelay.Seconds.ToString()));

            var callsCount = 0;
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount switch
                {
                    1 => OperationState<int>.Pending(shortDelayMockResponse),
                    2 => OperationState<int>.Pending(longDelayMockResponse),
                    _ => OperationState<int>.Success(new MockResponse(200), 50)
                }
            };
            var operationInternal = testOperation.MockOperationInternal;

            operationInternal.OnWait = delay => passedDelays.Add(delay);

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
            Assert.AreEqual(2, passedDelays.Count);
            Assert.AreEqual(originalDelay, passedDelays[0]);
            Assert.AreEqual(longDelay, passedDelays[1]);
        }

        [Test]
        [TestCase(true, "retry-after-ms")]
        [TestCase(true, "x-ms-retry-after-ms")]
        [TestCase(false, "retry-after-ms")]
        [TestCase(false, "x-ms-retry-after-ms")]
        public async Task WaitForCompletionUsesRetryAfterMsHeader(bool useDefaultPollingInterval, string headerName)
        {
            var originalDelay = TimeSpan.FromMilliseconds(500);
            var shortDelay = originalDelay.Subtract(TimeSpan.FromMilliseconds(250));
            var longDelay = originalDelay.Add(TimeSpan.FromMilliseconds(250));
            var passedDelays = new List<TimeSpan>();

            var shortDelayMockResponse = new MockResponse(200);
            shortDelayMockResponse.AddHeader(new HttpHeader(headerName, shortDelay.Milliseconds.ToString()));

            var longDelayMockResponse = new MockResponse(200);
            longDelayMockResponse.AddHeader(new HttpHeader(headerName, longDelay.Milliseconds.ToString()));

            var callsCount = 0;
            var testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount switch
                {
                    1 => OperationState<int>.Pending(shortDelayMockResponse),
                    2 => OperationState<int>.Pending(longDelayMockResponse),
                    _ => OperationState<int>.Success(new MockResponse(200), 50)
                }
            };
            var operationInternal = testOperation.MockOperationInternal;

            operationInternal.OnWait = delay => passedDelays.Add(delay);

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
            Assert.AreEqual(2, passedDelays.Count);
            Assert.AreEqual(originalDelay, passedDelays[0]);
            Assert.AreEqual(longDelay, passedDelays[1]);
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
            var operationInternal = testOperation.MockOperationInternal;

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
            var operationInternal = testOperation.MockOperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, cancellationToken));
        }

        private class TestOperation : IOperation<int>
        {
            public TestOperation(Response rawResponse = null, string operationTypeName = null)
            {
                MockOperationInternal = operationTypeName is null
                    ? new MockOperationInternal<int>(ClientDiagnostics, this, rawResponse)
                    : new MockOperationInternal<int>(ClientDiagnostics, this, rawResponse, operationTypeName);
            }

            public MockOperationInternal<int> MockOperationInternal { get; }

            public Func<CancellationToken, OperationState<int>> OnUpdateState { get; set; }

            ValueTask<OperationState<int>> IOperation<int>.UpdateStateAsync(bool async, CancellationToken cancellationToken) =>
                new ValueTask<OperationState<int>>(OnUpdateState(cancellationToken));
        }

        private class MockOperationInternal<TResult> : OperationInternal<TResult>
        {
            public MockOperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation, Response rawResponse)
                : base(clientDiagnostics, operation, rawResponse)
            {
            }

            public MockOperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation, Response rawResponse, string operationTypeName)
                : base(clientDiagnostics, operation, rawResponse, operationTypeName)
            {
            }

            public Action<TimeSpan> OnWait { get; set; }

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                OnWait?.Invoke(delay);
                await base.WaitAsync(delay, cancellationToken);
            }
        }

        private class TestClientOption : ClientOptions
        {
        }
    }
}
