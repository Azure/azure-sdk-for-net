// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class AutoRefreshingCacheTests
    {
        private readonly bool _async;

        public AutoRefreshingCacheTests(bool async)
        {
            _async = async;
        }

        #region Test Value Type
        /// <summary>
        /// Lightweight test struct implementing <see cref="IExpiringValue"/>
        /// so we can test <see cref="AutoRefreshingCache{TValue}"/> in isolation.
        /// </summary>
        private readonly struct TestValue : IExpiringValue
        {
            public string Token { get; }
            public DateTimeOffset ExpiresOn { get; }
            public DateTimeOffset RefreshOn { get; }

            public TestValue(string token, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
            {
                Token = token;
                ExpiresOn = expiresOn;
                RefreshOn = refreshOn;
            }

            public TestValue(string token, DateTimeOffset expiresOn)
                : this(token, expiresOn, expiresOn - TimeSpan.FromSeconds(30))
            { }

            public IExpiringValue WithRefreshOn(DateTimeOffset refreshOn) =>
                new TestValue(Token, ExpiresOn, refreshOn);
        }
        #endregion

        #region Helpers
        private ValueTask<TestValue> GetValueAsync(
            AutoRefreshingCache<TestValue> cache,
            CancellationToken cancellationToken = default)
            => cache.GetAsync(_async, cancellationToken);

        private static TestValue MakeValue(string token, TimeSpan expiresIn)
        {
            var expiresOn = DateTimeOffset.UtcNow + expiresIn;
            return new TestValue(token, expiresOn, expiresOn - TimeSpan.FromSeconds(30));
        }

        private static TestValue MakeValue(string token, DateTimeOffset expiresOn, DateTimeOffset refreshOn)
            => new TestValue(token, expiresOn, refreshOn);
        #endregion

        [Test]
        public async Task FirstCall_AcquiresValue()
        {
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) => new ValueTask<TestValue>(MakeValue("token1", TimeSpan.FromMinutes(30))),
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue result = await GetValueAsync(cache);

            Assert.AreEqual("token1", result.Token);
        }

        [Test]
        public async Task CachesValue_WhenNotExpired()
        {
            int callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    return new ValueTask<TestValue>(MakeValue($"token{callCount}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            TestValue second = await GetValueAsync(cache);

            Assert.AreEqual(1, callCount);
            Assert.AreEqual(first.Token, second.Token);
        }

        [Test]
        public async Task ReAcquires_WhenExpired()
        {
            int callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{callCount}",
                        expiresOn: DateTimeOffset.UtcNow,
                        refreshOn: DateTimeOffset.UtcNow));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            TestValue second = await GetValueAsync(cache);

            Assert.AreEqual(2, callCount);
            Assert.AreNotEqual(first.Token, second.Token);
        }

        [Test]
        public async Task BackgroundRefresh_WhenApproachingExpiry()
        {
            // requestMre: signals that the acquire delegate has been entered.
            // responseMre: controls when the acquire delegate is allowed to complete.
            // Both start OPEN so the first (foreground) acquisition runs unimpeded.
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var callCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    requestMre.Set();       // signal: "acquire has been called"
                    responseMre.Wait(ct);   // block until the test allows completion
                    requestMre.Reset();
                    Interlocked.Increment(ref callCount);

                    // First call: value is valid for 10 min but refreshOn = now,
                    //             so the cache will trigger a background refresh immediately.
                    // Subsequent calls: return a fully fresh value.
                    return new ValueTask<TestValue>(callCount == 1
                        ? MakeValue("original", expiresOn: DateTimeOffset.UtcNow.AddMinutes(10), refreshOn: DateTimeOffset.UtcNow)
                        : MakeValue("refreshed", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // --- Phase 1: Initial foreground acquisition (both gates open) ---
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            // Close the response gate so the next acquire call will block inside the delegate.
            responseMre.Reset();

            // --- Phase 2: Background refresh is kicked off but blocked ---
            // The cache sees refreshOn has passed (needs refresh) but expiresOn hasn't
            // (still valid), so it returns the current "original" value immediately
            // and starts a background Task.Run to refresh. That background task is now
            // stuck waiting on responseMre.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            // --- Phase 3: Unblock the background refresh and verify the new value ---
            responseMre.Set();          // let the background acquire complete
            await Task.Delay(1_000);    // give the background task time to finish

            // The background result ("refreshed") is now promoted to current.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("refreshed", third.Token);
            Assert.GreaterOrEqual(callCount, 2);
        }

        [Test]
        public async Task BackgroundRefresh_DoesNotBlockConcurrentCallers()
        {
            // requestMre: signals that acquire has been entered and passed responseMre.
            // responseMre: controls when the acquire delegate is allowed to complete.
            // Both start OPEN so the first foreground acquisition runs unimpeded.
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var callCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    responseMre.Wait(ct);
                    requestMre.Set();
                    // Every value returned has refreshOn = now, so the cache always
                    // wants a background refresh on the next call.
                    return new ValueTask<TestValue>(
                        MakeValue($"token{callCount}", expiresOn: DateTimeOffset.UtcNow.AddMinutes(10), refreshOn: DateTimeOffset.UtcNow));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // --- Phase 1: Initial foreground acquisition ---
            await GetValueAsync(cache);
            requestMre.Wait();
            // Close the gate so the background refresh will block inside the delegate.
            responseMre.Reset();

            // --- Phase 2: Three calls while background is blocked ---
            // The first call triggers a background refresh (stuck on responseMre).
            // The second and third calls see a background refresh is already in-flight,
            // so they just return the current value — no additional acquire calls.
            TestValue v1 = await GetValueAsync(cache);
            TestValue v2 = await GetValueAsync(cache);
            TestValue v3 = await GetValueAsync(cache);

            // --- Phase 3: Let the background finish ---
            requestMre.Reset();
            responseMre.Set();
            requestMre.Wait();

            // Only 2 acquire calls total: the initial foreground + one background.
            Assert.AreEqual(2, callCount);
            Assert.AreEqual(v1.Token, v2.Token);
            Assert.AreEqual(v2.Token, v3.Token);
        }

        [Test]
        public async Task HundredConcurrentCalls_SingleAcquisition()
        {
            int callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Thread.Sleep(100);
                    Interlocked.Increment(ref callCount);
                    return new ValueTask<TestValue>(MakeValue(Guid.NewGuid().ToString(), TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            var tasks = new Task<TestValue>[100];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = GetValueAsync(cache).AsTask();
            }

            await Task.WhenAll(tasks);

            Assert.AreEqual(1, callCount);
            string firstToken = tasks[0].Result.Token;
            for (int i = 1; i < tasks.Length; i++)
            {
                Assert.AreEqual(firstToken, tasks[i].Result.Token);
            }
        }

        [Test]
        public async Task GatedConcurrentCalls_WaitOnSameTcs()
        {
            int callCount = 0;
            // Both gates start CLOSED so we can control the exact ordering.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    requestMre.Set();       // signal: "I'm inside acquire"
                    responseMre.Wait(ct);   // block until test says go
                    return new ValueTask<TestValue>(MakeValue(Guid.NewGuid().ToString(), TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // First caller enters acquire and blocks on responseMre.
            var firstTask = Task.Run(async () => await GetValueAsync(cache));
            requestMre.Wait();

            // Second caller arrives while acquire is still in-flight —
            // it joins the same TCS rather than starting a new acquisition.
            var secondTask = Task.Run(async () => await GetValueAsync(cache));
            responseMre.Set();

            await Task.WhenAll(firstTask, secondTask);

            // Only one acquire call, and both callers got the same value.
            Assert.AreEqual(1, callCount);
            Assert.AreEqual(firstTask.Result.Token, secondTask.Result.Token);
        }

        [Test]
        public async Task SuccessThenFailureThenSuccess()
        {
            var callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    if (callCount == 2)
                    {
                        throw new InvalidOperationException("Acquire failed");
                    }
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{callCount}",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(1),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(1)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            Assert.AreEqual(1, callCount);

            await Task.Delay(2_000);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await GetValueAsync(cache));
            Assert.AreEqual(2, callCount);

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token3", third.Token);
            Assert.AreEqual(3, callCount);
        }

        [Test]
        public void HundredConcurrentCalls_AllFail()
        {
            ThreadPool.GetMinThreads(out int prevWorker, out int prevIO);
            ThreadPool.SetMinThreads(Math.Max(prevWorker, 120), prevIO);
            try
            {
                int callCount = 0;
                // Gate the acquire so it blocks until we're sure all tasks are queued.
                var requestMre = new ManualResetEventSlim(false);
                var responseMre = new ManualResetEventSlim(false);
                var cache = new AutoRefreshingCache<TestValue>(
                    acquire: (async, ct) =>
                    {
                        Interlocked.Increment(ref callCount);
                        requestMre.Set();       // signal: acquire entered
                        responseMre.Wait(ct);   // block until test releases
                        throw new InvalidOperationException("Error");
                    },
                    backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

                var tasks = new Task<TestValue>[100];
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(async () => await GetValueAsync(cache));
                }

                // Wait for the first task to enter the acquire delegate.
                requestMre.Wait();

                // Give the thread pool time to schedule remaining tasks so they
                // join the same TCS. The acquire is blocked, so this is reliable.
                Thread.Sleep(500);

                // Let the acquire throw — all 100 tasks observe the same faulted TCS.
                responseMre.Set();

                Assert.CatchAsync(async () => await Task.WhenAll(tasks));

                Assert.AreEqual(1, callCount);
                foreach (var task in tasks)
                {
                    Assert.IsTrue(task.IsFaulted);
                }

                // All tasks waited on the same TCS, so they share the same exception.
                Exception firstException = tasks[0].Exception.InnerException;
                Assert.IsInstanceOf<InvalidOperationException>(firstException);
                for (int i = 1; i < tasks.Length; i++)
                {
                    Assert.AreSame(firstException, tasks[i].Exception.InnerException);
                }
            }
            finally
            {
                ThreadPool.SetMinThreads(prevWorker, prevIO);
            }
        }

        [Test]
        public void GatedConcurrentCalls_BothFail()
        {
            // Both gates start CLOSED for precise ordering control.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            int callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    // Only the first caller blocks — ensures the second arrives
                    // while acquisition is still in-flight.
                    if (Interlocked.Increment(ref callCount) == 1)
                    {
                        requestMre.Set();
                        responseMre.Wait(ct);
                    }
                    throw new InvalidOperationException("Error");
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // First caller enters acquire, blocks on responseMre.
            var firstTask = Task.Run(async () => await GetValueAsync(cache));
            requestMre.Wait();

            // Second caller joins the same TCS (acquire still in-flight).
            var secondTask = Task.Run(async () => await GetValueAsync(cache));
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstTask, secondTask));

            Assert.IsTrue(firstTask.IsFaulted);
            Assert.IsTrue(secondTask.IsFaulted);

            // If both callers shared the same TCS, they get the same exception.
            // Guard handles the race where the second caller arrived after the
            // first already failed, triggering a separate acquire (callCount == 2).
            if (callCount == 1)
            {
                Assert.AreEqual(firstTask.Exception.InnerException, secondTask.Exception.InnerException);
            }
        }

        [Test]
        public async Task ExpiredThenFailed_PropagatesException()
        {
            // Both gates start OPEN so the first acquisition runs unimpeded.
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            bool fail = false;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    requestMre.Set();
                    responseMre.Wait(ct);
                    if (fail)
                    {
                        throw new InvalidOperationException("Error");
                    }
                    fail = true;
                    // Short-lived value: expires in 2 seconds.
                    return new ValueTask<TestValue>(MakeValue("token1",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(2),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(2)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // --- Phase 1: Acquire a short-lived value ---
            await GetValueAsync(cache);

            // --- Phase 2: Let it expire ---
            await Task.Delay(3_000);

            // Close both gates so we can control the next acquisition.
            requestMre.Reset();
            responseMre.Reset();

            // --- Phase 3: Two callers arrive after expiry ---
            // One wins the foreground acquire (blocks on responseMre),
            // the other joins the same TCS.
            var firstTask = Task.Run(async () => await GetValueAsync(cache));
            var secondTask = Task.Run(async () => await GetValueAsync(cache));
            requestMre.Wait();
            await Task.Delay(1_000);
            responseMre.Set();

            Assert.CatchAsync(async () => await Task.WhenAll(firstTask, secondTask));

            // Both callers see the same exception from the shared faulted TCS.
            Assert.IsTrue(firstTask.IsFaulted);
            Assert.IsTrue(secondTask.IsFaulted);
            Assert.AreEqual(firstTask.Exception.InnerException, secondTask.Exception.InnerException);
        }

        [Test]
        public async Task CancelledFirstRequest_DoesNotCancelSecond()
        {
            // Both gates start CLOSED for precise ordering.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cts = new CancellationTokenSource();
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    requestMre.Set();
                    responseMre.Wait(ct);   // throws when cts is canceled
                    return new ValueTask<TestValue>(MakeValue("token1", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // First caller enters acquire with a cancellable token.
            var firstTask = Task.Run(async () => await GetValueAsync(cache, cts.Token));
            requestMre.Wait();

            // Second caller joins the same TCS (no cancellation token).
            var secondTask = Task.Run(async () => await GetValueAsync(cache));

            // Cancel the first caller's token — TCS becomes canceled.
            cts.Cancel();

            // First caller gets OperationCanceledException.
            Assert.CatchAsync<OperationCanceledException>(async () => await firstTask);

            // Open the gate so the second caller's retry loop can re-acquire.
            // The second caller's token isn't canceled, so it retries via the
            // while(true) loop in GetAsync and successfully acquires.
            responseMre.Set();

            TestValue result = await secondTask;
            Assert.AreEqual("token1", result.Token);
        }

        [Test]
        [Repeat(10)]
        public void NoUnobservedTaskException()
        {
            bool unobservedRaised = false;
            var expectedException = new InvalidOperationException("Acquire Error");

            try
            {
                TaskScheduler.UnobservedTaskException += Handler;

                var cache = new AutoRefreshingCache<TestValue>(
                    acquire: (async, ct) => throw expectedException,
                    backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

                // Foreground acquire throws — exception should be observed via the TCS.
                Assert.ThrowsAsync<InvalidOperationException>(async () => await GetValueAsync(cache));

                // Force GC to finalize the faulted task and trigger
                // UnobservedTaskException if the exception wasn't observed.
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            finally
            {
                TaskScheduler.UnobservedTaskException -= Handler;
            }

            Assert.False(unobservedRaised, "UnobservedTaskException should not be raised");

            void Handler(object sender, UnobservedTaskExceptionEventArgs args)
            {
                if (args.Exception?.InnerException?.ToString() == expectedException.ToString())
                {
                    args.SetObserved();
                    unobservedRaised = true;
                }
            }
        }

        [Test]
        public async Task BackgroundFailure_ThrottlesRetry()
        {
            var backgroundAcquireTimes = new ConcurrentQueue<DateTimeOffset>();
            int callCount = 0;
            var retryDelay = TimeSpan.FromSeconds(2);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref callCount);
                    if (count > 1)
                    {
                        backgroundAcquireTimes.Enqueue(DateTimeOffset.UtcNow);
                        throw new InvalidOperationException("Background refresh failed");
                    }
                    return new ValueTask<TestValue>(MakeValue("original",
                        expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                        refreshOn: DateTimeOffset.UtcNow));
                },
                backgroundAcquireTimeout: retryDelay);

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            await Task.Delay(retryDelay + TimeSpan.FromSeconds(1));

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("original", third.Token);

            await Task.Delay(1_000);

            Assert.GreaterOrEqual(backgroundAcquireTimes.Count, 2);
            var times = backgroundAcquireTimes.ToArray();
            Assert.That(times[1] - times[0], Is.GreaterThanOrEqualTo(retryDelay));
        }

        [Test]
        public async Task Invalidate_ClearsCacheAndReAcquires()
        {
            int callCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref callCount);
                    return new ValueTask<TestValue>(MakeValue($"token{callCount}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            Assert.AreEqual(1, callCount);

            cache.Invalidate();

            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token2", second.Token);
            Assert.AreEqual(2, callCount);
        }

        [Test]
        public async Task Invalidate_DuringInflightAcquire_NextCallerReAcquires()
        {
            int acquireCount = 0;
            // Both gates start CLOSED for precise ordering.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    requestMre.Set();
                    responseMre.Wait(ct);
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Caller A enters acquire, blocks on responseMre.
            var callerA = Task.Run(async () => await GetValueAsync(cache));
            requestMre.Wait();

            // Invalidate while caller A is still acquiring.
            cache.Invalidate();

            // Reset the gate so we can detect a second acquire entry.
            requestMre.Reset();

            // Let caller A finish — it completes with "token1", but the
            // state was already nulled by Invalidate.
            responseMre.Set();
            TestValue resultA = await callerA;
            Assert.AreEqual("token1", resultA.Token);

            // Caller C arrives after Invalidate — should do a fresh foreground acquire
            // since _state was set to null by Invalidate.
            responseMre.Reset();
            var callerC = Task.Run(async () => await GetValueAsync(cache));
            requestMre.Wait();
            responseMre.Set();

            TestValue resultC = await callerC;
            Assert.AreEqual("token2", resultC.Token);
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task ScheduleRefresh_TriggersBackgroundRefresh()
        {
            int acquireCount = 0;
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    responseMre.Wait(ct);
                    int count = Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);

            cache.ScheduleRefresh();

            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token1", second.Token);

            await Task.Delay(1_000);

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token2", third.Token);
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task ScheduleRefresh_BeforeFirstCall_IsNoOp()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // ScheduleRefresh on an empty cache (_state == null) — should be a no-op.
            cache.ScheduleRefresh();

            // First call still does a normal foreground acquire.
            TestValue result = await GetValueAsync(cache);
            Assert.AreEqual("token1", result.Token);
            Assert.AreEqual(1, acquireCount);
        }

        [Test]
        public async Task ScheduleRefresh_BackgroundFailure_IsAbsorbed()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count > 1)
                    {
                        throw new InvalidOperationException("Background refresh failed");
                    }
                    return new ValueTask<TestValue>(MakeValue("original",
                        expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                        refreshOn: DateTimeOffset.UtcNow.AddMinutes(10)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            // Trigger a background refresh that will fail.
            cache.ScheduleRefresh();

            // This call kicks off the background refresh (which throws).
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            await Task.Delay(1_000);

            // The caller still gets the valid cached value — failure was absorbed.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("original", third.Token);
            Assert.GreaterOrEqual(acquireCount, 2);
        }

        [Test]
        public async Task BackgroundAcquireTimeout_KeepsCurrentValueAndRetriesImmediately()
        {
            var backgroundTimeout = TimeSpan.FromSeconds(1);
            int acquireCount = 0;
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: async (isAsync, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        // First call: return a value whose refreshOn = now so the
                        // next GetAsync triggers a background refresh.
                        return MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow);
                    }
                    if (count == 2)
                    {
                        // Second call (background): block until the timeout fires.
                        // The CTS created by AcquireInBackgroundAsync will cancel
                        // after backgroundAcquireTimeout, triggering the timeout path.
                        await Task.Delay(Timeout.InfiniteTimeSpan, ct);
                    }
                    // Third call (retry after timeout): succeed with a new value.
                    responseMre.Wait(ct);
                    return MakeValue("refreshed", TimeSpan.FromMinutes(30));
                },
                backgroundAcquireTimeout: backgroundTimeout);

            // Phase 1: Foreground acquire returns "original" with refreshOn = now.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            // Phase 2: Triggers background refresh (which will block and timeout).
            // Returns "original" immediately since the value is still valid.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            // Phase 3: Wait for the background timeout to fire and the background
            // TCS to be completed with the current value (refreshOn = now).
            await Task.Delay(backgroundTimeout + TimeSpan.FromSeconds(1));

            // Phase 4: The timed-out background result was promoted with refreshOn = now,
            // so this call triggers another background refresh — which succeeds this time.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("original", third.Token);

            // Wait for the successful background refresh to complete.
            await Task.Delay(1_000);

            // Phase 5: The refreshed value is now promoted.
            TestValue fourth = await GetValueAsync(cache);
            Assert.AreEqual("refreshed", fourth.Token);
            Assert.AreEqual(3, acquireCount);
        }
    }
}
