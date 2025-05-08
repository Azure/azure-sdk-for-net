// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class OperationInternalTests
    {
        private static readonly string DiagnosticNamespace = "Azure.Core.TestFramework";
        private static readonly ClientDiagnostics ClientDiagnostics = new(new TestClientOptions());
        private static readonly RequestFailedException OriginalException = new("");
        private static readonly StackOverflowException CustomException = new();
        private static readonly MockResponse InitialResponse = new(200);

        [Test]
        public void DefaultPropertyInitialization()
        {
            var operationInternal = new OperationInternal(TestOperation.Succeeded(), ClientDiagnostics, InitialResponse);
            Assert.IsNotNull(operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
        }

        [Test]
        public void RawResponseInitialization()
        {
            var operationInternal = new OperationInternal(TestOperation.Succeeded(), ClientDiagnostics, InitialResponse);

            Assert.AreEqual(InitialResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
        }

        [Test]
        public void SetStateSucceeds()
        {
            var operationInternal = OperationInternal.Succeeded(InitialResponse);
            Assert.IsTrue(operationInternal.HasCompleted);
        }

        [Test]
        public void SetStateFails()
        {
            var operationInternal = OperationInternal.Failed(InitialResponse, new RequestFailedException(InitialResponse));
            Assert.IsTrue(operationInternal.HasCompleted);
        }

        [Test]
        public async Task UpdateStatusWhenOperationIsPending([Values(true, false)] bool async)
        {
            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(1), ClientDiagnostics, InitialResponse);

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(operationResponse, operationInternal.RawResponse);
            Assert.False(operationInternal.HasCompleted);
        }

        [Test]
        public async Task UpdateStatusWhenOperationSucceeds([Values(true, false)] bool async)
        {
            var operationInternal = new OperationInternal(TestOperation.Succeeded(), ClientDiagnostics, InitialResponse);

            var operationResponse = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            Assert.AreEqual(operationResponse, operationInternal.RawResponse);
            Assert.True(operationInternal.HasCompleted);
        }

        [Test]
        public void UpdateStatusWhenOperationFails([Values(true, false)] bool async, [Values(true, false)] bool useDefaultException)
        {
            var operationInternal = useDefaultException
                ? new OperationInternal(TestOperation.Failed(418), ClientDiagnostics, InitialResponse)
                : new OperationInternal(TestOperation.Failed(418, OriginalException), ClientDiagnostics, InitialResponse);

            RequestFailedException thrownException = async
                ? Assert.ThrowsAsync<RequestFailedException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<RequestFailedException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            if (!useDefaultException)
            {
                Assert.AreEqual(OriginalException, thrownException);
            }

            Assert.AreEqual(418, operationInternal.RawResponse.Status);
            Assert.True(operationInternal.HasCompleted);
        }

        [Test]
        public void UpdateStatusWhenOperationThrows([Values(true, false)] bool async)
        {
            var operation = new TestOperation((_, _) => new ValueTask<OperationState>(Task.FromException<OperationState>(CustomException)));
            var operationInternal = new OperationInternal(operation, ClientDiagnostics, InitialResponse);
            StackOverflowException thrownException = async
                ? Assert.ThrowsAsync<StackOverflowException>(async () => await operationInternal.UpdateStatusAsync(CancellationToken.None))
                : Assert.Throws<StackOverflowException>(() => operationInternal.UpdateStatus(CancellationToken.None));

            Assert.AreEqual(CustomException, thrownException);

            Assert.IsNotNull(operationInternal.RawResponse);
        }

        [Test]
        public async Task UpdateStatusCreatesDiagnosticScope([Values(true, false)] bool async, [Values(null, "CustomTypeName")] string operationTypeName)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            string expectedTypeName = operationTypeName ?? nameof(TestOperation);
            KeyValuePair<string, string>[] expectedAttributes = { new("key1", "value1"), new("key2", "value2") };
            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(1), ClientDiagnostics, InitialResponse, operationTypeName, expectedAttributes);

            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            testListener.AssertScope($"{expectedTypeName}.UpdateStatus", expectedAttributes);
        }

        [Test]
        public async Task UpdateStatusNotCreateDiagnosticScope([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = OperationInternal.Succeeded(InitialResponse);
            _ = async
                ? await operationInternal.UpdateStatusAsync(CancellationToken.None)
                : operationInternal.UpdateStatus(CancellationToken.None);

            CollectionAssert.IsEmpty(testListener.Scopes);
        }

        [Test]
        public async Task UpdateStatusSetsFailedScopeWhenOperationFails([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = new OperationInternal(TestOperation.Failed(418, OriginalException), ClientDiagnostics, InitialResponse);
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
            var operation = new TestOperation((_, _) => new ValueTask<OperationState>(Task.FromException<OperationState>(CustomException)));
            var operationInternal = new OperationInternal(operation, ClientDiagnostics, InitialResponse);
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
                return new ValueTask<OperationState>(OperationState.Success(new MockResponse(200)));
            });

            var operationInternal = new OperationInternal(operation, ClientDiagnostics, InitialResponse);
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
            var operationInternal = new OperationInternal( TestOperation.Succeeded(), new(new TestClientOptions(), suppressNestedClientActivities), InitialResponse, operationTypeName, expectedAttributes);

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
        public async Task WaitForCompletionResponseNotCreateDiagnosticScope([Values(true, false)] bool async)
        {
            using ClientDiagnosticListener testListener = new(DiagnosticNamespace);

            var operationInternal = OperationInternal.Succeeded(InitialResponse);
            _ = async
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : operationInternal.WaitForCompletionResponse(CancellationToken.None);

            CollectionAssert.IsEmpty(testListener.Scopes);
        }

        [Test]
        public async Task WaitForCompletionCallsUntilOperationCompletes([Values(true, false)] bool useDefaultPollingInterval)
        {
            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(5), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            var operationResponse = useDefaultPollingInterval
                ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None)
                : await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, CancellationToken.None);

            Assert.AreEqual(operationInternal.RawResponse, operationResponse);
            Assert.True(operationInternal.HasCompleted);
        }

        [Test]
        public async Task WaitForCompletionUsesZeroPollingInterval([Values(true, false)] bool hasSuggest, [Values(1, 2, 3)] int retries)
        {
            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(retries), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

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
                return new ValueTask<OperationState>(OperationState.Success(new MockResponse(200)));
            });

            var operationInternal = new OperationInternal(operation, ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

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

            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(1), ClientDiagnostics, InitialResponse, fallbackStrategy: new ZeroPollingStrategy());

            _ = useDefaultPollingInterval
                ? Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(cancellationToken))
                : Assert.ThrowsAsync<TaskCanceledException>(async () => await operationInternal.WaitForCompletionResponseAsync(TimeSpan.Zero, cancellationToken));
        }

        [Test]
        public async Task FallbackCanBeOverridenWaitResponseAsyncAsOperation([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(retries), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None);

            Assert.AreEqual(retries, fallbackStrategy.CallCount);
        }

        [Test]
        public void FallbackCanBeOverridenWaitResponseAsOperation([Values(1, 3)] int retries)
        {
            var fallbackStrategy = new MockDelayStrategy();

            var operationInternal = new OperationInternal(TestOperation.SucceededAfter(retries), ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);
            _ = operationInternal.WaitForCompletionResponse(CancellationToken.None);

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
                    return OperationState.Pending(new MockResponse(200));
                }

                if (callCount > expectedDelayStrategyCalls)
                {
                    throw new Exception("More calls than expected");
                }

                callCount++;
                return OperationState.Success(new MockResponse(200));
            });

            var operationInternal = new OperationInternal(operation, ClientDiagnostics, InitialResponse, fallbackStrategy: fallbackStrategy);

            var tasks = new List<Task<Response>>();
            for (var i = 0; i < 50; i++)
            {
                var task = Task.Run(async () => async
                    ? await operationInternal.WaitForCompletionResponseAsync(CancellationToken.None).ConfigureAwait(false)
                    : operationInternal.WaitForCompletionResponse(CancellationToken.None));

                tasks.Add(task);
            }

            mre.Set();

            await Task.WhenAll(tasks);

            Assert.AreEqual(expectedDelayStrategyCalls + 1, callCount);
            Assert.AreEqual(expectedDelayStrategyCalls, fallbackStrategy.CallCount);

            foreach (var task in tasks.Skip(1))
            {
                Assert.AreEqual(task.Result, tasks[0].Result);
            }
        }

        private readonly struct TestOperation : IOperation
        {
            private readonly Func<bool, CancellationToken, ValueTask<OperationState>> _updateStateAsyncHandler;

            public static TestOperation Succeeded() => new((_, _) => new ValueTask<OperationState>(OperationState.Success(new MockResponse(200))));
            public static TestOperation SucceededAfter(int retries)
            {
                var count = 0;
                return new((_, _) =>
                {
                    if (count == retries)
                    {
                        return new ValueTask<OperationState>(OperationState.Success(new MockResponse(200)));
                    }

                    if (count < retries)
                    {
                        count++;
                        return new ValueTask<OperationState>(OperationState.Pending(new MockResponse(200)));
                    }

                    throw new InvalidOperationException("More UpdateStateAsync calls than expected");
                });
            }

            public static TestOperation Failed(int status) => new((_, _) => new ValueTask<OperationState>(OperationState.Failure(new MockResponse(status))));
            public static TestOperation Failed(int status, RequestFailedException exception) => new((_, _) => new ValueTask<OperationState>(OperationState.Failure(new MockResponse(status), exception)));
            public static TestOperation FailedAfter(int retries, int status, RequestFailedException exception)
            {
                var count = 0;
                return new((_, _) =>
                {
                    if (count >= retries)
                    {
                        return new ValueTask<OperationState>(OperationState.Failure(new MockResponse(status), exception));
                    }

                    count++;
                    return new ValueTask<OperationState>(OperationState.Pending(new MockResponse(200)));
                });
            }

            public TestOperation(Func<bool, CancellationToken, ValueTask<OperationState>> updateStateAsyncHandler)
            {
                _updateStateAsyncHandler = updateStateAsyncHandler;
            }

            public ValueTask<OperationState> UpdateStateAsync(bool async, CancellationToken cancellationToken) => _updateStateAsyncHandler(async, cancellationToken);

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
