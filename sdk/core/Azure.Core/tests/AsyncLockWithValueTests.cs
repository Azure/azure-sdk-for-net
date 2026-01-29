// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AsyncLockWithValueTests
    {
        [Test]
        public async Task AsyncLockWithValue_SetValueInCtor([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>(42);

            Assert.That(alwv.HasValue, Is.True);
            Assert.That(alwv.TryGetValue(out var value), Is.True);
            Assert.That(value, Is.EqualTo(42));

            using var asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);
            Assert.That(asyncLock.HasValue, Is.True);
            Assert.That(asyncLock.Value, Is.EqualTo(42));
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            AsyncLockWithValue<int>.LockOrValue asyncLock;

            Assert.That(alwv.HasValue, Is.False);
            Assert.That(alwv.TryGetValue(out _), Is.False);
            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.That(asyncLock.HasValue, Is.False);
                asyncLock.SetValue(42);
            }

            Assert.That(alwv.HasValue, Is.True);
            Assert.That(alwv.TryGetValue(out var value), Is.True);
            Assert.That(value, Is.EqualTo(42));
            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.That(asyncLock.HasValue, Is.True);
                Assert.That(asyncLock.Value, Is.EqualTo(42));
            }
        }

        [Test]
        public async Task AsyncLockWithValue_ThrowOnValueOverride([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            AsyncLockWithValue<int>.LockOrValue asyncLock;

            Assert.That(alwv.HasValue, Is.False);
            Assert.That(alwv.TryGetValue(out _), Is.False);
            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.That(asyncLock.HasValue, Is.False);
                asyncLock.SetValue(42);
            }

            Assert.That(alwv.HasValue, Is.True);
            Assert.That(alwv.TryGetValue(out var value), Is.True);
            Assert.That(value, Is.EqualTo(42));
            using (asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            {
                Assert.That(asyncLock.HasValue, Is.True);
                Assert.Throws<InvalidOperationException>(() => asyncLock.SetValue(6 * 9));
            }
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_Canceled([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            using var asyncLock = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);

            var cts = new CancellationTokenSource();
            var task = Task.Run(async () =>
            {
                using var secondLock = await alwv.GetLockOrValueAsync(async, cts.Token);
            }, default);

            Assert.That(task.IsCompleted, Is.False);
            cts.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await task);

            asyncLock.SetValue(42);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_FirstFailedSecondSucceeded([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var tcs = new TaskCompletionSource<int>();
            var tcsWait = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

            var task1 = Task.Run(async () =>
            {
                using var lock1 = await alwv.GetLockOrValueAsync(async);
                tcsWait.SetResult(0);
                return async ? await tcs.Task : tcs.Task.GetAwaiter().GetResult();
            });

            await tcsWait.Task;

            var task2 = Task.Run(async () =>
            {
                using var lock2 = await alwv.GetLockOrValueAsync(async);
                lock2.SetValue(42);
            });

            Assert.That(task1.IsCompleted, Is.False);
            Assert.That(task2.IsCompleted, Is.False);

            tcs.SetException(new InvalidOperationException());
            Assert.CatchAsync<InvalidOperationException>(async () => await task1);
            await task2;

            using var lock3 = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);
            Assert.That(lock3.HasValue, Is.True);
            Assert.That(lock3.Value, Is.EqualTo(42));
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

            Assert.That(task1.IsCompleted, Is.False);
            Assert.That(task2.IsCompleted, Is.False);
            Assert.That(task3.IsCompleted, Is.False);

            cts.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await task2);

            tcs.SetResult(0);
            await task1;
            await task3;

            var lock4 = await alwv.GetLockOrValueAsync(async, default);
            Assert.That(lock4.HasValue, Is.True);
            Assert.That(lock4.Value, Is.EqualTo(42));
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_SetAfterDispose([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            AsyncLockWithValue<int>.LockOrValue lockOrValue;

            Assert.That(alwv.HasValue, Is.False);
            Assert.That(alwv.TryGetValue(out _), Is.False);
            using (lockOrValue = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            { }

            Assert.Throws<InvalidOperationException>(() => lockOrValue.SetValue(42));
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_DisposedMoreThanOnce([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();

            Assert.That(alwv.HasValue, Is.False);
            Assert.That(alwv.TryGetValue(out _), Is.False);
            var lockOrValue = await alwv.GetLockOrValueAsync(async).ConfigureAwait(false);

            lockOrValue.Dispose();
            lockOrValue.Dispose();

            using (await alwv.GetLockOrValueAsync(async).ConfigureAwait(false))
            { }

            lockOrValue.Dispose();
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_HasNoValue([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);
            var tasks = new List<Task>();
            for (var i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    Assert.That(alwv.HasValue, Is.False);
                    Assert.That(alwv.TryGetValue(out _), Is.False);
                    using var asyncLock = await alwv.GetLockOrValueAsync(async);
                    Assert.That(asyncLock.HasValue, Is.False);
                }));
            }

            firstLock.Dispose();
            await Task.WhenAll(tasks);
            Assert.That(alwv.HasValue, Is.False);
            Assert.That(alwv.TryGetValue(out _), Is.False);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_HasValue([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);
            var tasks = new List<Task>();
            for (var i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using var asyncLock = await alwv.GetLockOrValueAsync(async);
                    Assert.That(asyncLock.HasValue, Is.True);
                    Assert.That(asyncLock.Value, Is.EqualTo(42));
                }));
            }

            firstLock.SetValue(42);
            await Task.WhenAll(tasks);
        }

        [Test]
        public async Task AsyncLockWithValue_GetLockOrValueAsync_OneHundredCalls_SetValue([Values(true, false)] bool async)
        {
            var alwv = new AsyncLockWithValue<int>();
            var firstLock = await alwv.GetLockOrValueAsync(async);
            var tasks = new List<Task>();
            for (var i = 0; i < 50; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using var asyncLock = await alwv.GetLockOrValueAsync(async);
                    if (asyncLock.HasValue)
                    {
                        Assert.That(asyncLock.Value, Is.EqualTo(42));
                    }
                }));
            }

            AsyncLockWithValue<int>.LockOrValue lastLock;
            tasks.Add(Task.Run(async () =>
            {
                lastLock = await alwv.GetLockOrValueAsync(async);
                lastLock.SetValue(42);
                lastLock.Dispose();
            }));

            firstLock.Dispose();
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
            for (var i = 0; i < 40; i++)
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
                    Assert.That(asyncLock.HasValue, Is.False);
                }, default);
        }
    }
}
