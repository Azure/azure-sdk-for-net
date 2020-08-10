// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AsyncLockWithValue
    {
        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            AsyncLockWithValue<int>.Lock asyncLock;
            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.IsFalse(asyncLock.HasValue);
                asyncLock.SetValue(42);
            }

            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.IsTrue(asyncLock.HasValue);
                Assert.AreEqual(42, asyncLock.Value);
            }
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_Canceled([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);

            var cts = new CancellationTokenSource();
            var task = Task.Run(async () =>
            {
                using var secondLock = await alwv.GetLockOrValueAsync(async, cts.Token);
            }, default);

            Assert.IsFalse(task.IsCompleted);
            cts.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await task);

            asyncLock.SetValue(42);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_FirstFailedSecondSucceeded([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var tcs = new TaskCompletionSource<int>();

            var task1 = Task.Run(async () =>
            {
                using var lock1 = await alwv.GetLockOrValueAsync(async);
                return async ? await tcs.Task : tcs.Task.GetAwaiter().GetResult();
            });

            var task2 = Task.Run(async () =>
            {
                using var lock2 = await alwv.GetLockOrValueAsync(async);
                lock2.SetValue(42);
            });

            Assert.IsFalse(task1.IsCompleted);
            Assert.IsFalse(task2.IsCompleted);

            tcs.SetException(new InvalidOperationException());
            Assert.CatchAsync<InvalidOperationException>(async () => await task1);
            await task2;

            using var lock3 = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);
            Assert.IsTrue(lock3.HasValue);
            Assert.AreEqual(42, lock3.Value);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_SecondCanceled([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var tcs = new TaskCompletionSource<int>();
            var tcs1 = new TaskCompletionSource<int>();

            var cts = new CancellationTokenSource();
            var task1 = Task.Run(async () =>
            {
                using var lock1 = await alwv.GetLockOrValueAsync(async, default);
                tcs1.SetResult(0);
                return async ? await tcs.Task : tcs.Task.GetAwaiter().GetResult();
            }, default);

            await tcs1.Task;

            var task2 = Task.Run(async () =>
            {
                using var lock2 = await alwv.GetLockOrValueAsync(async, cts.Token);
            }, default);

            var task3 = Task.Run(async () =>
            {
                using var lock3 = await alwv.GetLockOrValueAsync(async, default);
                lock3.SetValue(42);
            }, default);

            Assert.IsFalse(task1.IsCompleted);
            Assert.IsFalse(task2.IsCompleted);
            Assert.IsFalse(task3.IsCompleted);

            cts.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await task2);

            tcs.SetResult(0);
            await task1;
            await task3;

            var lock4 = await alwv.GetLockOrValueAsync(async, default);
            Assert.IsTrue(lock4.HasValue);
            Assert.AreEqual(42, lock4.Value);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_HasNoValue([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);
            var tasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using var asyncLock = await alwv.GetLockOrValueAsync(async);
                    Assert.IsFalse(asyncLock.HasValue);
                }));
            }

            firstLock.Dispose();
            await Task.WhenAll(tasks);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_HasValue([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);
            var tasks = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using var asyncLock = await alwv.GetLockOrValueAsync(async);
                    Assert.IsTrue(asyncLock.HasValue);
                    Assert.AreEqual(asyncLock.Value, 42);
                }));
            }

            firstLock.SetValue(42);
            await Task.WhenAll(tasks);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_Canceled([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);

            var startingTasks = new List<Task>();
            var tasks = new List<Task>();
            var cts = new CancellationTokenSource();
            for (var i = 0; i < 10; i++)
            {
                var token = i % 2 == 0 ? cts.Token : default;
                var tcs = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
                tasks.Add(CreateTask(alwv, tcs, async, token));
                startingTasks.Add(tcs.Task);
            }

            await Task.WhenAll(startingTasks);
            for (var i = 0; i < 90; i++)
            {
                var token = i % 2 == 0 ? cts.Token : default;
                tasks.Add(CreateTask(alwv, default, async, token));
            }

            cts.Cancel();
            firstLock.Dispose();
            Assert.CatchAsync<OperationCanceledException>(async () => await Task.WhenAll(tasks));

            static Task CreateTask(AsyncLockWithValue<int> lockWithValue, TaskCompletionSource<int> tcs, bool isAsync, CancellationToken token) =>
                Task.Run(async () =>
                {
                    tcs?.SetResult(0);
                    using var asyncLock = await lockWithValue.GetLockOrValueAsync(isAsync, token);
                    Assert.IsFalse(asyncLock.HasValue);
                }, default);
        }
    }
}
