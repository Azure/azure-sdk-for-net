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
            TestOperation testOperation = new TestOperation();
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);

            Assert.IsNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public void RawResponseInitialization()
        {
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation(mockResponse);
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            Assert.AreEqual(TimeSpan.FromSeconds(1), operationInternal.DefaultPollingInterval);

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
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            Response operationResponse = async
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
            int expectedValue = 50;
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Success(mockResponse, expectedValue)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            Response operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(mockResponse, operationResponse);

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.True(operationInternal.HasValue);
            Assert.AreEqual(expectedValue, operationInternal.Value);
        }

        [Test]
        public void UpdateStatusWhenOperationFails(
            [Values(true, false)] bool async,
            [Values(true, false)] bool useDefaultException)
        {
            RequestFailedException originalException = new RequestFailedException("");
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => useDefaultException
                    ? OperationState<int>.Failure(mockResponse)
                    : OperationState<int>.Failure(mockResponse, originalException)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            RequestFailedException thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            if (!useDefaultException)
            {
                Assert.AreEqual(originalException, thrownException);
            }

            Assert.AreEqual(mockResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);

            RequestFailedException valueException = Assert.Throws<RequestFailedException>(() => _ = operationInternal.Value);
            Assert.AreEqual(thrownException, valueException);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void UpdateStatusWhenOperationThrows(bool async)
        {
            StackOverflowException originalException = new StackOverflowException();
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => throw originalException
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            StackOverflowException thrownException = async
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
            using ClientDiagnosticListener testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            string expectedTypeName = useDefaultTypeName ? nameof(TestOperation) : customTypeName;
            KeyValuePair<string, string>[] expectedAttributes = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("key1", "value1"),
                new KeyValuePair<string, string>("key2", "value2")
            };

            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation(operationTypeName: useDefaultTypeName ? null : customTypeName, scopeAttributes: expectedAttributes)
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            using ClientDiagnosticListener testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            RequestFailedException originalException = new RequestFailedException("");
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Failure(mockResponse, originalException)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            using ClientDiagnosticListener testListener = new ClientDiagnosticListener(DiagnosticNamespace);

            StackOverflowException originalException = new StackOverflowException();
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => throw originalException
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = cancellationToken =>
                {
                    passedToken = cancellationToken;
                    return OperationState<int>.Pending(mockResponse);
                }
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            int callsCount = 0;
            int expectedCalls = 5;
            int expectedValue = 50;
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount >= expectedCalls
                    ? OperationState<int>.Success(mockResponse, expectedValue)
                    : OperationState<int>.Pending(mockResponse)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            Response<int> operationResponse = useDefaultPollingInterval
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
            TimeSpan expectedDelay = TimeSpan.FromMilliseconds(100);
            TimeSpan passedDelay = default;

            int callsCount = 0;
            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount >= 2
                    ? OperationState<int>.Success(mockResponse, 50)
                    : OperationState<int>.Pending(mockResponse)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            TimeSpan originalDelay = TimeSpan.FromSeconds(2);
            TimeSpan shortDelay = originalDelay.Subtract(TimeSpan.FromSeconds(1));
            TimeSpan longDelay = originalDelay.Add(TimeSpan.FromSeconds(1));
            List<TimeSpan> passedDelays = new List<TimeSpan>();

            MockResponse shortDelayMockResponse = new MockResponse(200);
            shortDelayMockResponse.AddHeader(new HttpHeader("Retry-After", shortDelay.Seconds.ToString()));

            MockResponse longDelayMockResponse = new MockResponse(200);
            longDelayMockResponse.AddHeader(new HttpHeader("Retry-After", longDelay.Seconds.ToString()));

            int callsCount = 0;
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount switch
                {
                    1 => OperationState<int>.Pending(shortDelayMockResponse),
                    2 => OperationState<int>.Pending(longDelayMockResponse),
                    _ => OperationState<int>.Success(new MockResponse(200), 50)
                }
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            Assert.AreEqual(Max(originalDelay, shortDelay), passedDelays[0]);
            Assert.AreEqual(Max(originalDelay, longDelay), passedDelays[1]);
        }

        [Test]
        public async Task WaitForCompletionUsesRetryAfterMsHeader(
            [Values(true, false)] bool useDefaultPollingInterval,
            [Values("retry-after-ms", "x-ms-retry-after-ms")] string headerName)
        {
            TimeSpan originalDelay = TimeSpan.FromMilliseconds(500);
            TimeSpan shortDelay = originalDelay.Subtract(TimeSpan.FromMilliseconds(250));
            TimeSpan longDelay = originalDelay.Add(TimeSpan.FromMilliseconds(250));
            List<TimeSpan> passedDelays = new List<TimeSpan>();

            MockResponse shortDelayMockResponse = new MockResponse(200);
            shortDelayMockResponse.AddHeader(new HttpHeader(headerName, shortDelay.Milliseconds.ToString()));

            MockResponse longDelayMockResponse = new MockResponse(200);
            longDelayMockResponse.AddHeader(new HttpHeader(headerName, longDelay.Milliseconds.ToString()));

            int callsCount = 0;
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => ++callsCount switch
                {
                    1 => OperationState<int>.Pending(shortDelayMockResponse),
                    2 => OperationState<int>.Pending(longDelayMockResponse),
                    _ => OperationState<int>.Success(new MockResponse(200), 50)
                }
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            Assert.AreEqual(Max(originalDelay, shortDelay), passedDelays[0]);
            Assert.AreEqual(Max(originalDelay, longDelay), passedDelays[1]);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState(bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = cancellationToken =>
                {
                    passedToken = cancellationToken;
                    return OperationState<int>.Success(mockResponse, default);
                }
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

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
            using CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = tokenSource.Token;

            tokenSource.Cancel();

            MockResponse mockResponse = new MockResponse(200);
            TestOperation testOperation = new TestOperation()
            {
                OnUpdateState = _ => OperationState<int>.Pending(mockResponse)
            };
            MockOperationInternal<int> operationInternal = testOperation.MockOperationInternal;

            operationInternal.DefaultPollingInterval = TimeSpan.Zero;

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionAsync(TimeSpan.Zero, cancellationToken));
        }

        private TimeSpan Max(TimeSpan t1, TimeSpan t2) => t1 > t2 ? t1 : t2;

        private class TestOperation : IOperation<int>
        {
            public TestOperation(Response rawResponse = null, string operationTypeName = null, IEnumerable<KeyValuePair<string, string>> scopeAttributes = null)
            {
                MockOperationInternal = operationTypeName is null && scopeAttributes is null
                    ? new MockOperationInternal<int>(ClientDiagnostics, this, rawResponse)
                    : new MockOperationInternal<int>(ClientDiagnostics, this, rawResponse, operationTypeName, scopeAttributes);
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

            public MockOperationInternal(ClientDiagnostics clientDiagnostics, IOperation<TResult> operation, Response rawResponse, string operationTypeName, IEnumerable<KeyValuePair<string, string>> scopeAttributes)
                : base(clientDiagnostics, operation, rawResponse, operationTypeName, scopeAttributes)
            {
            }

            public Action<TimeSpan> OnWait { get; set; }

            protected override async Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken)
            {
                OnWait?.Invoke(delay);
                await base.WaitAsync(TimeSpan.Zero, cancellationToken);
            }
        }

        private class TestClientOption : ClientOptions
        {
        }
    }
}
