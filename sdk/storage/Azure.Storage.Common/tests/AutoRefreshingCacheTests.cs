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
        private readonly struct TestValue : IExpiringValue, IEquatable<TestValue>
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

            public bool Equals(TestValue other) =>
                string.Equals(Token, other.Token, StringComparison.Ordinal);
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

        #region Construction

        [Test]
        public void Ctor_NullAcquire_Throws()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new AutoRefreshingCache<TestValue>(acquire: null, TimeSpan.FromSeconds(30)));
            Assert.AreEqual("acquire", ex.ParamName);
        }

        #endregion

        #region Basic Acquisition

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
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{acquireCount}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            TestValue second = await GetValueAsync(cache);

            Assert.AreEqual(1, acquireCount);
            Assert.AreEqual(first.Token, second.Token);
        }

        [Test]
        public async Task ReAcquires_WhenExpired()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{acquireCount}",
                        expiresOn: DateTimeOffset.UtcNow,
                        refreshOn: DateTimeOffset.UtcNow));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            TestValue second = await GetValueAsync(cache);

            Assert.AreEqual(2, acquireCount);
            Assert.AreNotEqual(first.Token, second.Token);
        }

        [Test]
        public async Task MultipleExpiryCycles_WorkCorrectly()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    // Each value expires in ~1 second.
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{count}",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(1),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(1)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            for (int cycle = 1; cycle <= 3; cycle++)
            {
                TestValue result = await GetValueAsync(cache);
                Assert.AreEqual($"token{cycle}", result.Token);
                await Task.Delay(2_000);
            }

            Assert.AreEqual(3, acquireCount);
        }

        #endregion

        #region Foreground Concurrency

        [Test]
        public async Task GatedConcurrentCalls_WaitOnSameTcs()
        {
            int acquireCount = 0;
            // Both gates start CLOSED so we can control the exact ordering.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
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
            Assert.AreEqual(1, acquireCount);
            Assert.AreEqual(firstTask.Result.Token, secondTask.Result.Token);
        }

        [Test]
        public async Task HundredConcurrentCalls_SingleAcquisition()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Thread.Sleep(100);
                    Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue(Guid.NewGuid().ToString(), TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            var tasks = new Task<TestValue>[100];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = GetValueAsync(cache).AsTask();
            }

            await Task.WhenAll(tasks);

            Assert.AreEqual(1, acquireCount);
            string firstToken = tasks[0].Result.Token;
            for (int i = 1; i < tasks.Length; i++)
            {
                Assert.AreEqual(firstToken, tasks[i].Result.Token);
            }
        }

        [Test]
        public async Task ConcurrentCalls_AfterExpiry_SingleReAcquisition()
        {
            int acquireCount = 0;
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    responseMre.Wait(ct);
                    requestMre.Set();
                    if (count == 1)
                    {
                        // Short-lived value that expires almost immediately.
                        return new ValueTask<TestValue>(MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddSeconds(1),
                            refreshOn: DateTimeOffset.UtcNow.AddSeconds(1)));
                    }
                    return new ValueTask<TestValue>(MakeValue("new", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Phase 1: Foreground acquire returns a short-lived value.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);
            Assert.AreEqual(1, acquireCount);

            // Phase 2: Let it expire.
            await Task.Delay(2_000);

            // Close gates so the re-acquisition blocks.
            requestMre.Reset();
            responseMre.Reset();

            // Phase 3: Multiple callers arrive after expiry — one wins foreground
            // acquire, the rest join the same TCS.
            var tasks = new Task<TestValue>[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(async () => await GetValueAsync(cache));
            }

            // Wait for the winning caller to enter the acquire delegate.
            await Task.Delay(500);

            // Release the acquire delegate.
            responseMre.Set();
            requestMre.Wait();

            await Task.WhenAll(tasks);

            // Only one re-acquisition after expiry (2 total: initial + expiration re-acquire).
            Assert.AreEqual(2, acquireCount);
            foreach (var task in tasks)
            {
                Assert.AreEqual("new", task.Result.Token);
            }
        }

        [Test]
        public async Task SteadyState_HighConcurrency_NoExtraAcquires()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue("steady", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Prime the cache with a long-lived value
            TestValue primed = await GetValueAsync(cache);
            Assert.AreEqual("steady", primed.Token);
            Assert.AreEqual(1, acquireCount);

            // Hammer the cache with 200 concurrent calls. All should hit the
            // lock-free fast path; none should trigger another acquire.
            var tasks = new Task<TestValue>[200];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(async () => await GetValueAsync(cache));
            }
            await Task.WhenAll(tasks);

            Assert.AreEqual(1, acquireCount, "Steady-state reads must not trigger acquire.");
            foreach (var t in tasks)
            {
                Assert.AreEqual("steady", t.Result.Token);
            }
        }

        [Test]
        public async Task FullLifecycle_AcquireCacheExpireReAcquire()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    // 5-second expiry: plenty of headroom for steps 1–2,
                    // short enough that the test finishes quickly.
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{count}",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(5),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(5)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Step 1: First call triggers a foreground acquire.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            Assert.AreEqual(1, acquireCount);

            // Step 2: Immediate second call. Value is still fresh, so no acquire triggered.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token1", second.Token);
            Assert.AreEqual(1, acquireCount);

            // Let the value expire.
            await Task.Delay(6_000);

            // Step 3: Value expired — triggers a new foreground acquire.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token2", third.Token);
            Assert.AreEqual(2, acquireCount);

            // Step 4: Immediate call — new value still fresh.
            TestValue fourth = await GetValueAsync(cache);
            Assert.AreEqual("token2", fourth.Token);
            Assert.AreEqual(2, acquireCount);
        }

        #endregion

        #region Background Refresh

        [Test]
        public async Task BackgroundRefresh_WhenApproachingExpiry()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var acquireCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    requestMre.Set();
                    responseMre.Wait(ct);
                    requestMre.Reset();
                    Interlocked.Increment(ref acquireCount);

                    return new ValueTask<TestValue>(acquireCount == 1
                        ? MakeValue("original", expiresOn: DateTimeOffset.UtcNow.AddMinutes(10), refreshOn: DateTimeOffset.UtcNow)
                        : MakeValue("refreshed", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // --- Phase 1: Initial foreground acquisition (both gates open) ---
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);
            Assert.AreEqual(1, acquireCount);

            // Close the response gate so the next acquire call will block inside the delegate.
            responseMre.Reset();

            // --- Phase 2: Background refresh is kicked off but blocked ---
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);
            Assert.AreEqual(1, acquireCount);

            // --- Phase 3: Unblock the background refresh and verify the new value ---
            responseMre.Set();
            await Task.Delay(1_000);

            // The background result ("refreshed") is now promoted to current.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("refreshed", third.Token);
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task BackgroundRefresh_DoesNotBlockConcurrentCallers()
        {
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);
            var acquireCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    responseMre.Wait(ct);
                    requestMre.Set();
                    return new ValueTask<TestValue>(
                        MakeValue($"token{acquireCount}", expiresOn: DateTimeOffset.UtcNow.AddMinutes(10), refreshOn: DateTimeOffset.UtcNow));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // --- Phase 1: Initial foreground acquisition ---
            await GetValueAsync(cache);
            requestMre.Wait();
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
            Assert.AreEqual(2, acquireCount);
            Assert.AreEqual("token1", v1.Token);
            Assert.AreEqual(v1.Token, v2.Token);
            Assert.AreEqual(v2.Token, v3.Token);

            // --- Phase 4: Verify the background result was promoted to current in the next call ---
            await Task.Delay(500);
            TestValue v4 = await GetValueAsync(cache);
            Assert.AreEqual("token2", v4.Token);
        }

        [Test]
        public async Task ConcurrentCalls_DuringBackgroundRefresh_OneAcquireAllSeeCurrent()
        {
            int acquireCount = 0;
            int delegateEntries = 0;
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref delegateEntries);
                    requestMre.Set();
                    responseMre.Wait(ct);
                    int count = Interlocked.Increment(ref acquireCount);
                    return count == 1
                        ? new ValueTask<TestValue>(MakeValue("current",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow))
                        : new ValueTask<TestValue>(MakeValue("refreshed", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Phase 1: foreground acquire.
            await GetValueAsync(cache);
            Assert.AreEqual(1, delegateEntries);

            // Phase 2: close the gate so the next acquire stalls inside the delegate.
            requestMre.Reset();
            responseMre.Reset();

            // Phase 3: 50 concurrent callers arrive during the refresh window.
            // Exactly one wins the background-refresh slot; all 50 get "current"
            // immediately without waiting on the background.
            var tasks = new Task<TestValue>[50];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(async () => await GetValueAsync(cache));
            }
            await Task.WhenAll(tasks);

            // Wait for the background task to actually enter the delegate
            requestMre.Wait();

            foreach (var t in tasks)
            {
                Assert.AreEqual("current", t.Result.Token);
            }

            // Initial foreground entry (1) + exactly one background entry (1) = 2.
            // No duplicate background acquires should have been issued.
            Assert.AreEqual(2, delegateEntries,
                "Only one background refresh should be in flight at a time.");

            // Cleanup: let the background acquire complete.
            responseMre.Set();
        }

        [Test]
        public async Task BackgroundAcquireTimeout_KeepsCurrentValueAndRetriesImmediately()
        {
            var backgroundTimeout = TimeSpan.FromSeconds(2);
            int acquireCount = 0;
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: async (isAsync, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        return MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow);
                    }
                    if (count == 2)
                    {
                        await Task.Delay(Timeout.InfiniteTimeSpan, ct);
                    }
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

        [Test]
        public async Task BackgroundPromotedValue_EventuallyExpires_TriggersReAcquire()
        {
            int acquireCount = 0;
            var requestMre = new ManualResetEventSlim(true);
            var responseMre = new ManualResetEventSlim(true);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    responseMre.Wait(ct);
                    requestMre.Set();
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        return new ValueTask<TestValue>(MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow));
                    }
                    if (count == 2)
                    {
                        return new ValueTask<TestValue>(MakeValue("background",
                            expiresOn: DateTimeOffset.UtcNow.AddSeconds(1),
                            refreshOn: DateTimeOffset.UtcNow.AddSeconds(1)));
                    }
                    return new ValueTask<TestValue>(MakeValue("final", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Phase 1: Foreground acquire.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            // Phase 2: Trigger background refresh and let it complete.
            responseMre.Reset();
            requestMre.Reset();
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            // Unblock background acquire and wait for it to finish.
            responseMre.Set();
            requestMre.Wait();
            await Task.Delay(500);

            // Phase 3: Background value promoted.
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("background", third.Token);

            // Phase 4: Let the promoted value expire.
            await Task.Delay(2_000);

            TestValue fourth = await GetValueAsync(cache);
            Assert.AreEqual("final", fourth.Token);
            Assert.AreEqual(3, acquireCount);
        }

        [Test]
        public async Task BackgroundResult_AlreadyExpired_IsNotPromoted()
        {
            int acquireCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        return new ValueTask<TestValue>(MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow));
                    }
                    return new ValueTask<TestValue>(MakeValue("stale",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(-1),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(-1)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Phase 1: Foreground acquire.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("original", first.Token);

            // Phase 2: Kick off the background refresh (will return original).
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);

            // Let the background acquire complete with the stale value.
            await Task.Delay(500);

            // Phase 3: The stale background value must NOT be promoted
            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("original", third.Token);
        }

        #endregion

        #region Failure Handling

        [Test]
        public async Task SuccessThenFailureThenSuccess()
        {
            var acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    if (acquireCount == 2)
                    {
                        throw new InvalidOperationException("Acquire failed");
                    }
                    return new ValueTask<TestValue>(MakeValue(
                        $"token{acquireCount}",
                        expiresOn: DateTimeOffset.UtcNow.AddSeconds(1),
                        refreshOn: DateTimeOffset.UtcNow.AddSeconds(1)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            Assert.AreEqual(1, acquireCount);

            await Task.Delay(2_000);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await GetValueAsync(cache));
            Assert.AreEqual(2, acquireCount);

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token3", third.Token);
            Assert.AreEqual(3, acquireCount);
        }

        [Test]
        public void GatedConcurrentCalls_BothFail()
        {
            // Both gates start CLOSED for precise ordering control.
            var requestMre = new ManualResetEventSlim(false);
            var responseMre = new ManualResetEventSlim(false);
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    // Only the first caller blocks — ensures the second arrives
                    // while acquisition is still in-flight.
                    if (Interlocked.Increment(ref acquireCount) == 1)
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
            // first already failed, triggering a separate acquire (acquireCount == 2).
            if (acquireCount == 1)
            {
                Assert.AreEqual(firstTask.Exception.InnerException, secondTask.Exception.InnerException);
            }
        }

        [Test]
        public void HundredConcurrentCalls_AllFail()
        {
            ThreadPool.GetMinThreads(out int prevWorker, out int prevIO);
            ThreadPool.SetMinThreads(Math.Max(prevWorker, 120), prevIO);
            try
            {
                int acquireCount = 0;
                // Gate the acquire so it blocks until we're sure all tasks are queued.
                var requestMre = new ManualResetEventSlim(false);
                var responseMre = new ManualResetEventSlim(false);
                // Two-phase barrier: ensures all 100 threads are alive and
                // waiting before any of them calls GetValueAsync.
                var ready = new CountdownEvent(100);
                var startGate = new ManualResetEventSlim(false);

                var cache = new AutoRefreshingCache<TestValue>(
                    acquire: (async, ct) =>
                    {
                        Interlocked.Increment(ref acquireCount);
                        requestMre.Set();       // signal: acquire entered
                        responseMre.Wait(ct);   // block until test releases
                        throw new InvalidOperationException("Error");
                    },
                    backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

                var tasks = new Task<TestValue>[100];
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Run(async () =>
                    {
                        ready.Signal();       // "I'm on a thread-pool thread"
                        startGate.Wait();     // wait for all threads to be ready
                        return await GetValueAsync(cache);
                    });
                }

                // Phase 1: Wait until all 100 threads are alive and at the gate.
                ready.Wait();

                // Phase 2: Release all threads simultaneously.
                startGate.Set();

                // Wait for the first task to enter the acquire delegate.
                requestMre.Wait();

                // All 100 threads are already executing. Give them time to pass
                // through EvaluateState (just a lock acquisition each) and start
                // awaiting the shared TCS.
                Thread.Sleep(500);

                // Let the acquire throw — all 100 tasks observe the same faulted TCS.
                responseMre.Set();

                Assert.CatchAsync(async () => await Task.WhenAll(tasks));

                Assert.AreEqual(1, acquireCount);
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

        #endregion

        #region Throttling

        [Test]
        public async Task BackgroundFailure_DoesNotRetryUntilThrottleElapses()
        {
            int acquireCount = 0;
            var throttleWindow = TimeSpan.FromSeconds(2);
            // Signaled each time a background acquire enters the delegate.
            var backgroundEntered = new AutoResetEvent(false);

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        // Foreground: long-lived value with refreshOn = now,
                        // so the next GetAsync triggers a background refresh.
                        return new ValueTask<TestValue>(MakeValue("original",
                            expiresOn: DateTimeOffset.UtcNow.AddMinutes(10),
                            refreshOn: DateTimeOffset.UtcNow));
                    }
                    // Every background acquire fails — signal entry first so the
                    // test can synchronize without timing-based waits.
                    backgroundEntered.Set();
                    throw new InvalidOperationException("Background refresh failed");
                },
                backgroundAcquireTimeout: throttleWindow);

            // Phase 1: foreground acquire.
            Assert.AreEqual("original", (await GetValueAsync(cache)).Token);
            Assert.AreEqual(1, acquireCount);

            // Phase 2: trigger the failing background refresh.
            Assert.AreEqual("original", (await GetValueAsync(cache)).Token);

            // Wait deterministically for the background to enter and fail.
            Assert.IsTrue(backgroundEntered.WaitOne(TimeSpan.FromSeconds(10)),
                "Background acquire never ran.");
            // Give the cache a beat to apply the WithRefreshOn(now + throttleWindow) update.
            // (This is the one unavoidable wait — it's between the throw and the
            // catch handler updating state. Generous bound since it's microseconds in practice.)
            await Task.Delay(100);
            int countAfterFailure = Volatile.Read(ref acquireCount);
            Assert.AreEqual(2, countAfterFailure);

            // Phase 3: within the throttle window, repeated calls must NOT trigger
            // another background acquire. We don't loop with delays — we just verify
            // that the gate hasn't been signaled.
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual("original", (await GetValueAsync(cache)).Token);
            }
            Assert.IsFalse(backgroundEntered.WaitOne(TimeSpan.Zero),
                "Background acquire should be throttled within the failure window.");
            Assert.AreEqual(countAfterFailure, Volatile.Read(ref acquireCount));

            // Phase 4: after the throttle window elapses, the next call triggers
            // another background acquire. Wait deterministically.
            await Task.Delay(throttleWindow + TimeSpan.FromMilliseconds(100));
            Assert.AreEqual("original", (await GetValueAsync(cache)).Token);

            Assert.IsTrue(backgroundEntered.WaitOne(TimeSpan.FromSeconds(10)),
                "Background acquire should resume after the throttle window elapses.");
            Assert.Greater(Volatile.Read(ref acquireCount), countAfterFailure);
        }

        #endregion

        #region Invalidate

        [Test]
        public async Task InvalidateIfCurrent_ClearsCacheAndReAcquires()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{acquireCount}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            Assert.AreEqual(1, acquireCount);

            cache.InvalidateIfCurrent(first);

            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token2", second.Token);
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task InvalidateIfCurrent_DuringInflightAcquire_IsNoOp()
        {
            int acquireCount = 0;
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

            // Caller B arrives while A is still acquiring — joins A's in-flight TCS.
            var callerB = Task.Run(async () => await GetValueAsync(cache));
            await Task.Delay(200);

            // InvalidateIfCurrent during in-flight acquire is a no-op (CurrentValueTcs
            // is not RanToCompletion, so the equality check is skipped).
            cache.InvalidateIfCurrent(MakeValue("anything", TimeSpan.FromMinutes(30)));

            // Let caller A finish.
            responseMre.Set();
            TestValue resultA = await callerA;
            TestValue resultB = await callerB;
            Assert.AreEqual("token1", resultA.Token);
            Assert.AreEqual("token1", resultB.Token);
            Assert.AreEqual(1, acquireCount);

            // Caller C arrives after — sees A's cached result, no re-acquire.
            TestValue resultC = await GetValueAsync(cache);
            Assert.AreEqual("token1", resultC.Token);
            Assert.AreEqual(1, acquireCount,
                "InvalidateIfCurrent during in-flight acquire must not trigger a re-acquire.");
        }

        [Test]
        public async Task InvalidateIfCurrent_AfterValueReplaced_IsNoOp()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // Acquire token1, then replace it with token2 via InvalidateIfCurrent + GetAsync.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);
            cache.InvalidateIfCurrent(first);
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token2", second.Token);
            Assert.AreEqual(2, acquireCount);

            // Simulate a "late" 401 handler still holding token1: must NOT clear the cache.
            cache.InvalidateIfCurrent(first);

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token2", third.Token, "Stale invalidate must not displace the current token.");
            Assert.AreEqual(2, acquireCount, "Stale invalidate must not trigger a re-acquire.");
        }

        [Test]
        public void InvalidateIfCurrent_WhenEmpty_IsNoOp()
        {
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) => new ValueTask<TestValue>(MakeValue("token", TimeSpan.FromMinutes(30))),
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // No cached value yet — must not throw.
            Assert.DoesNotThrow(() => cache.InvalidateIfCurrent(MakeValue("anything", TimeSpan.FromMinutes(30))));
        }

        #endregion

        #region ScheduleRefresh

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
        public async Task ScheduleRefresh_TriggersBackgroundRefresh()
        {
            int acquireCount = 0;

            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);

            // Kicks off the background refresh immediately.
            cache.ScheduleRefresh();

            // Give the background acquire time to complete.
            await Task.Delay(1_000);

            // Next call promotes the background result.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token2", second.Token);
            Assert.AreEqual(2, acquireCount);
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

            // Kicks off a background refresh that will fail.
            cache.ScheduleRefresh();

            // Give the background acquire time to fail.
            await Task.Delay(1_000);

            // The caller still gets the valid cached value — failure was absorbed.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("original", second.Token);
            Assert.GreaterOrEqual(acquireCount, 2);
        }

        [Test]
        public async Task ScheduleRefresh_DuringInflightBackground_IsNoOp()
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

            // Foreground acquire.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);

            // Block the next acquire, then trigger a background refresh.
            responseMre.Reset();
            cache.ScheduleRefresh();

            // GetAsync returns the current value while the background refresh is in flight.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token1", second.Token);

            // Another ScheduleRefresh while background is in-flight — should be ignored.
            cache.ScheduleRefresh();

            // Release the background refresh.
            responseMre.Set();
            await Task.Delay(1_000);

            TestValue third = await GetValueAsync(cache);
            Assert.AreEqual("token2", third.Token);

            // Only 2 acquires total: initial + one background. The second ScheduleRefresh was a no-op.
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task ScheduleRefresh_AfterFailedAcquire_IsNoOp()
        {
            int acquireCount = 0;
            var cache = new AutoRefreshingCache<TestValue>(
                acquire: (async, ct) =>
                {
                    int count = Interlocked.Increment(ref acquireCount);
                    if (count == 1)
                    {
                        throw new InvalidOperationException("First acquire failed");
                    }
                    return new ValueTask<TestValue>(MakeValue($"token{count}", TimeSpan.FromMinutes(30)));
                },
                backgroundAcquireTimeout: TimeSpan.FromSeconds(30));

            // First call faults — CurrentValueTcs is now in the Faulted state.
            Assert.ThrowsAsync<InvalidOperationException>(async () => await GetValueAsync(cache));
            Assert.AreEqual(1, acquireCount);

            // ScheduleRefresh on a faulted cache must be a no-op — it must not
            // throw, and it must not touch _state in a way that breaks recovery.
            Assert.DoesNotThrow(() => cache.ScheduleRefresh());
            Assert.AreEqual(1, acquireCount, "ScheduleRefresh must not trigger acquire on its own.");

            // The next GetAsync recovers normally via the EvaluateState
            // failed-or-expired path (foreground re-acquire).
            TestValue recovered = await GetValueAsync(cache);
            Assert.AreEqual("token2", recovered.Token);
            Assert.AreEqual(2, acquireCount);
        }

        [Test]
        public async Task ScheduleRefresh_ConcurrentCalls_TriggersSingleAcquire()
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

            // Foreground acquire to seed the cache.
            TestValue first = await GetValueAsync(cache);
            Assert.AreEqual("token1", first.Token);

            // Block the next acquire so all concurrent ScheduleRefresh callers
            // race against the same in-flight background slot.
            responseMre.Reset();

            // Fire many concurrent ScheduleRefresh calls.
            const int parallelism = 32;
            Parallel.For(0, parallelism, _ => cache.ScheduleRefresh());

            // Release the background acquire and let it complete.
            responseMre.Set();
            await Task.Delay(1_000);

            // The next GetAsync promotes the single background result.
            TestValue second = await GetValueAsync(cache);
            Assert.AreEqual("token2", second.Token);

            // Only 2 acquires total: initial + exactly one background, regardless
            // of how many ScheduleRefresh calls raced.
            Assert.AreEqual(2, acquireCount);
        }

        #endregion

        #region Cancellation

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

        #endregion
    }
}
