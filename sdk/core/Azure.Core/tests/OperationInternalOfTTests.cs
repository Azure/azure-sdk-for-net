// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestClients;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class OperationInternalOfTTests
    {
        private static readonly string DiagnosticNamespace = "Azure.Core.TestFramework";
        private static readonly ClientDiagnostics ClientDiagnostics = new(new TestClientOptions());
        private static readonly RequestFailedException OriginalException = new("");
        private static readonly StackOverflowException CustomException = new();
        private static readonly MockResponse InitialResponse = new(200);

        [Test]
        public void DefaultPropertyInitialization()
        {
            var operationInternal = new OperationInternal<int>(TestOperation.Succeeded(42), ClientDiagnostics, InitialResponse);
            Assert.IsNotNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public void RawResponseInitialization()
        {
            var operationInternal = new OperationInternal<int>(TestOperation.Succeeded(42), ClientDiagnostics, InitialResponse);

            Assert.AreEqual(InitialResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public void SetStateSucceeds()
        {
            var operationInternal = OperationInternal<int>.Succeeded(InitialResponse, 1);

            Assert.IsTrue(operationInternal.HasCompleted);
            Assert.IsTrue(operationInternal.HasValue);
            Assert.AreEqual(1, operationInternal.Value);
        }

        [Test]
        public void SetStateFails()
        {
            var operationInternal = OperationInternal<int>.Failed(InitialResponse, new RequestFailedException(InitialResponse));

            Assert.IsTrue(operationInternal.HasCompleted);
            Assert.IsFalse(operationInternal.HasValue);
            Assert.Throws<RequestFailedException>(() => _ = operationInternal.Value);
        }

        [Test]
        public async Task UpdateStatusWhenOperationIsPending([Values(true, false)] bool async)
        {
            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(1, 42), ClientDiagnostics, InitialResponse);

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(operationResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public async Task UpdateStatusWhenOperationSucceeds([Values(true, false)] bool async)
        {
            var operationInternal = new OperationInternal<int>(TestOperation.Succeeded(42), ClientDiagnostics, InitialResponse);

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(operationResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.True(operationInternal.HasValue);
            Assert.AreEqual(42, operationInternal.Value);
        }

        [Test]
        public void UpdateStatusWhenOperationFails([Values(true, false)] bool async, [Values(true, false)] bool useDefaultException)
        {
            var operationInternal = useDefaultException
                ? new OperationInternal<int>(TestOperation.Failed(418), ClientDiagnostics, InitialResponse)
                : new OperationInternal<int>(TestOperation.Failed(418, OriginalException), ClientDiagnostics, InitialResponse);

            RequestFailedException thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            if (!useDefaultException)
            {
                Assert.AreEqual(OriginalException, thrownException);
            }

            Assert.AreEqual(418, operationInternal.RawResponse.Status);
            Assert.True(operationInternal.HasCompleted);
            Assert.False(operationInternal.HasValue);
            RequestFailedException valueException = Assert.Throws<RequestFailedException>(() => _ = operationInternal.Value);
            Assert.AreEqual(thrownException, valueException);
        }

        [Test]
        public void UpdateStatusWhenOperationThrows([Values(true, false)] bool async)
        {
            var operation = new TestOperation((_, _) => new ValueTask<OperationState<int>>(Task.FromException<OperationState<int>>(CustomException)));
            var operationInternal = new OperationInternal<int>(operation, ClientDiagnostics, InitialResponse);
            StackOverflowException thrownException = async
                ? Assert.ThrowsAsync<StackOverflowException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<StackOverflowException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(CustomException, thrownException);

            Assert.IsNotNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasValue);
            Assert.Throws<InvalidOperationException>(() => _ = operationInternal.Value);
        }

        [Test]
        public async Task UpdateStatusCreatesDiagnosticScope([Values(true, false)] bool async, [Values(null, "CustomTypeName")] string operationTypeName)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            string expectedTypeName = operationTypeName ?? nameof(TestOperation);
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(1, 42), ClientDiagnostics, InitialResponse, operationTypeName, expectedAttributes);

            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.UpdateStatus", expectedAttributes);
        }

        [Test]
        public async Task UpdateStatusNotCreateDiagnosticScope([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = OperationInternal<int>.Succeeded(InitialResponse, 1);
            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            CollectionAssert.IsEmpty(testListener.Scopes);
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationFails([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = new OperationInternal<int>(TestOperation.Failed(418, OriginalException), ClientDiagnostics, InitialResponse);
            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = nameof(TestOperation);
            testListener.AssertScopeException($"{expectedTypeName}.UpdateStatus", scopeException => Assert.AreEqual(OriginalException, scopeException));
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationThrows([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);
            var operation = new TestOperation((_, _) => new ValueTask<OperationState<int>>(Task.FromException<OperationState<int>>(CustomException)));
            var operationInternal = new OperationInternal<int>(operation, ClientDiagnostics, InitialResponse);
            try
            {
                _ = async
                    ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                    : operationInternal.UpdateStatus(CancellationToken.None);
            }
            catch { }

            var expectedTypeName = nameof(TestOperation);
            testListener.AssertScopeException($"{expectedTypeName}.UpdateStatus", scopeException => Assert.AreEqual(CustomException, scopeException));
        }

        [Test]
        public async Task UpdateStatusPassesTheCancellationTokenToUpdateState([Values(true, false)] bool async)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            var operation = new TestOperation((_, ct) =>
            {
                passedToken = ct;
                return new ValueTask<OperationState<int>>(OperationState<int>.Success(new MockResponse(200), 42));
            });

            var operationInternal = new OperationInternal<int>(operation, ClientDiagnostics, InitialResponse);
            _ = async
                ? await operationInternal.UpdateStatusAsync(originalToken)
                : operationInternal.UpdateStatus(originalToken);

            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        public async Task WaitForCompletionResponseCreatesDiagnosticScope([Values(true, false)] bool async, [Values(null, "CustomTypeName")] string operationTypeName, [Values(true, false)] bool suppressNestedClientActivities)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            string expectedTypeName = operationTypeName ?? nameof(TestOperation);
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = new OperationInternal<int>(TestOperation.Succeeded(1), new(new TestClientOptions(), suppressNestedClientActivities), InitialResponse, operationTypeName, expectedAttributes);

            _ = async
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : operationInternal.WaitForCompletionResponse(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.WaitForCompletionResponse", expectedAttributes);
#if NET5_0_OR_GREATER
            if (suppressNestedClientActivities)
            {
                testListener.AssertAndRemoveScope($"{expectedTypeName}.WaitForCompletionResponse", expectedAttributes);
                CollectionAssert.IsEmpty(testListener.Scopes);
            }
#endif
        }

        [Test]
        public async Task WaitForCompletionCreatesDiagnosticScope([Values(true, false)] bool async, [Values(null, "CustomTypeName")] string operationTypeName, [Values(true, false)] bool suppressNestedClientActivities)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            string expectedTypeName = operationTypeName ?? nameof(TestOperation);
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = new OperationInternal<int>(TestOperation.Succeeded(1), new(new TestClientOptions(), suppressNestedClientActivities), InitialResponse, operationTypeName, expectedAttributes);

            _ = async
                ? await operationInternal.WaitForCompletionAsync(CancellationToken.None)
                : operationInternal.WaitForCompletion(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.WaitForCompletion", expectedAttributes);
#if NET5_0_OR_GREATER
            if (suppressNestedClientActivities)
            {
                testListener.AssertAndRemoveScope($"{expectedTypeName}.WaitForCompletion", expectedAttributes);
                CollectionAssert.IsEmpty(testListener.Scopes);
            }
#endif
        }

        [Test]
        public async Task WaitForCompletionResponseNotCreateDiagnosticScope([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = OperationInternal<int>.Succeeded(InitialResponse, 1);
            _ = async
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : operationInternal.WaitForCompletionResponse(CancellationToken.None);

            CollectionAssert.IsEmpty(testListener.Scopes);
        }

        [Test]
        public async Task WaitForCompletionNotCreateDiagnosticScope([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = OperationInternal<int>.Succeeded(InitialResponse, 1);
            _ = async
                ? await operationInternal.WaitForCompletionAsync(CancellationToken.None)
                : operationInternal.WaitForCompletion(CancellationToken.None);

            CollectionAssert.IsEmpty(testListener.Scopes);
        }

        [Test]
        public async Task WaitForCompletionCallsUntilOperationCompletes([Values(true, false)] bool useDefaultPollingInterval)
        {
            var expectedValue = 50;
            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(5, expectedValue), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            var operationResponse = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, CancellationToken.None);

            Assert.AreEqual(operationInternal.RawResponse, operationResponse);
            Assert.True(operationInternal.HasCompleted);
            Assert.True(operationInternal.HasValue);
            Assert.AreEqual(expectedValue, operationInternal.Value);
        }

        [Test]
        public async Task WaitForCompletionUsesZeroPollingInterval([Values(true, false)] bool hasSuggest, [Values(1, 2, 3)] int retries)
        {
            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(retries, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            var stopwatch = Stopwatch.StartNew();
            if (hasSuggest)
            {
                await operationInternal.WaitForCompletionResponseAsync(TimeSpan.FromSeconds(2), CancellationToken.None);
            }
            else
            {
                await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);
            }
            stopwatch.Stop();

            // if there is a suggested time, it should be used instead of the zero polling interval
            if (hasSuggest)
            {
                Assert.IsTrue(stopwatch.Elapsed > TimeSpan.FromSeconds(1));
            }
            else
            {
                Assert.IsTrue(stopwatch.Elapsed < TimeSpan.FromSeconds(1));
            }
        }

        [Test]
        public async Task WaitForCompletionPassesTheCancellationTokenToUpdateState([Values(true, false)] bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken originalToken = tokenSource.Token;
            CancellationToken passedToken = default;

            var operation = new TestOperation((_, ct) =>
            {
                passedToken = ct;
                return new ValueTask<OperationState<int>>(OperationState<int>.Success(new MockResponse(200), 42));
            });

            var operationInternal = new OperationInternal<int>(operation, ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            _ = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionResponseAsync(originalToken)
                : await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, originalToken);

            Assert.AreEqual(originalToken, passedToken);
        }

        [Test]
        public void WaitForCompletionPassesTheCancellationTokenToTaskDelay([Values(true, false)] bool useDefaultPollingInterval)
        {
            using CancellationTokenSource tokenSource = new();
            CancellationToken cancellationToken = tokenSource.Token;

            tokenSource.Cancel();

            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(1, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, cancellationToken));
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitResponseAsyncAsOperation([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(retries, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);

            Assert.AreEqual(retries, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWaitResponseAsOperation([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(retries, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = operationInternal.WaitForCompletionResponse(CancellationToken.None);

            Assert.AreEqual(retries, fallbackStrategy.CallCount);
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitAsync([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(retries, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = await operationInternal.WaitForCompletionAsync(CancellationToken.None);

            Assert.AreEqual(retries, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWait([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal<int>(TestOperation.SucceededAfter(retries, 42), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = operationInternal.WaitForCompletion(CancellationToken.None);

            Assert.AreEqual(retries, fallbackStrategy.CallCount);
        }

        [Test]
        public async Task UpdateStatusConcurrent([Values(true, false)] bool async)
        {
            var fallbackStrategy = new CallCountStrategy();
            var mre = new ManualResetEventSlim(false);
            var callCount = 0;
            var expectedDelayStrategyCalls = 40;
            var operation = new TestOperation(async (callAsync, ct) =>
            {
                mre.Wait(ct);
                if (callAsync)
                {
                    await Task.Yield();
                }

                if (callCount < expectedDelayStrategyCalls)
                {
                    callCount++;
                    return OperationState<int>.Pending(new MockResponse(200));
                }

                if (callCount > expectedDelayStrategyCalls)
                {
                    throw new Exception("More calls than expected");
                }

                callCount++;
                return OperationState<int>.Success(new MockResponse(200), 42);
            });

            var operationInternal = new OperationInternal<int>(operation, ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);

            var tasks = new List<Task<Response<int>>>();
            for (var i = 0; i < 50; i++)
            {
                var task = Task.Run(async () => async
                    ? await operationInternal.WaitForCompletionAsync(CancellationToken.None).ConfigureAwait(false)
                    : operationInternal.WaitForCompletion(CancellationToken.None));

                tasks.Add(task);
            }

            mre.Set();

            await Task.WhenAll(tasks);

            Assert.AreEqual(expectedDelayStrategyCalls + 1, callCount);
            Assert.AreEqual(expectedDelayStrategyCalls, fallbackStrategy.CallCount);

            foreach (var task in tasks.Skip(1))
            {
                Assert.AreEqual(task.Result.GetRawResponse(), tasks[0].Result.GetRawResponse());
                Assert.AreEqual(task.Result.Value, tasks[0].Result.Value);
            }
        }

        private readonly struct TestOperation : IOperation<int>
        {
            private readonly Func<bool, CancellationToken, ValueTask<OperationState<int>>> _updateStateAsyncHandler;

            public static TestOperation Succeeded(int value) => new((_, _) => new ValueTask<OperationState<int>>(OperationState<int>.Success(new MockResponse(200), value)));
            public static TestOperation SucceededAfter(int retries, int value)
            {
                var count = 0;
                return new((_, _) =>
                {
                    if (count == retries)
                    {
                        return new ValueTask<OperationState<int>>(OperationState<int>.Success(new MockResponse(200), value));
                    }

                    if (count < retries)
                    {
                        count++;
                        return new ValueTask<OperationState<int>>(OperationState<int>.Pending(new MockResponse(200)));
                    }

                    throw new InvalidOperationException("More UpdateStateAsync calls than expected");
                });
            }

            public static TestOperation Failed(int status) => new((_, _) => new ValueTask<OperationState<int>>(OperationState<int>.Failure(new MockResponse(status))));
            public static TestOperation Failed(int status, RequestFailedException exception) => new((_, _) => new ValueTask<OperationState<int>>(OperationState<int>.Failure(new MockResponse(status), exception)));
            public static TestOperation FailedAfter(int retries, int status, RequestFailedException exception)
            {
                var count = 0;
                return new((_, _) =>
                {
                    if (count >= retries)
                    {
                        return new ValueTask<OperationState<int>>(OperationState<int>.Failure(new MockResponse(status), exception));
                    }

                    count++;
                    return new ValueTask<OperationState<int>>(OperationState<int>.Pending(new MockResponse(200)));
                });
            }

            public TestOperation(Func<bool, CancellationToken, ValueTask<OperationState<int>>> updateStateAsyncHandler)
            {
                _updateStateAsyncHandler = updateStateAsyncHandler;
            }

            public ValueTask<OperationState<int>> UpdateStateAsync(bool async, CancellationToken cancellationToken) => _updateStateAsyncHandler(async, cancellationToken);

            public RehydrationToken GetRehydrationToken() =>
                throw new NotImplementedException();
        }

        private class CallCountStrategy : DelayStrategy
        {
            public int CallCount { get; private set; }

            protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
            {
                CallCount++;
                return TimeSpan.Zero;
            }
        }
    }
}
