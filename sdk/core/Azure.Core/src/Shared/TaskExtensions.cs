// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal static class TaskExtensions
    {
        public static WithCancellationTaskAwaitable AwaitWithCancellation(this Task task, CancellationToken cancellationToken)
            => new WithCancellationTaskAwaitable(task, cancellationToken);

        public static WithCancellationTaskAwaitable<T> AwaitWithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
            => new WithCancellationTaskAwaitable<T>(task, cancellationToken);

        public static WithCancellationValueTaskAwaitable<T> AwaitWithCancellation<T>(this ValueTask<T> task, CancellationToken cancellationToken)
            => new WithCancellationValueTaskAwaitable<T>(task, cancellationToken);

        public static T EnsureCompleted<T>(this Task<T> task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        public static void EnsureCompleted(this Task task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        public static T EnsureCompleted<T>(this ValueTask<T> task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        public static void EnsureCompleted(this ValueTask task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
            task.GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult(). Use the TaskExtensions.EnsureCompleted() extension method instead.
        }

        public static Enumerable<T> EnsureSyncEnumerable<T>(this IAsyncEnumerable<T> asyncEnumerable) => new Enumerable<T>(asyncEnumerable);

        public static ConfiguredValueTaskAwaitable<T> EnsureCompleted<T>(this ConfiguredValueTaskAwaitable<T> awaitable, bool async)
        {
            if (!async)
            {
#if DEBUG
                VerifyTaskCompleted(awaitable.GetAwaiter().IsCompleted);
#endif
            }
            return awaitable;
        }

        public static ConfiguredValueTaskAwaitable EnsureCompleted(this ConfiguredValueTaskAwaitable awaitable, bool async)
        {
            if (!async)
            {
#if DEBUG
                VerifyTaskCompleted(awaitable.GetAwaiter().IsCompleted);
#endif
            }
            return awaitable;
        }

        [Conditional("DEBUG")]
        private static void VerifyTaskCompleted(bool isCompleted)
        {
            if (!isCompleted)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                // Throw an InvalidOperationException instead of using
                // Debug.Assert because that brings down nUnit immediately
                throw new InvalidOperationException("Task is not completed");
            }
        }

        /// <summary>
        /// Both <see cref="Enumerable{T}"/> and <see cref="Enumerator{T}"/> are defined as public structs so that foreach can use duck typing
        /// to call <see cref="Enumerable{T}.GetEnumerator"/> and avoid heap memory allocation.
        /// Please don't delete this method and don't make these types private.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public readonly struct Enumerable<T> : IEnumerable<T>
        {
            private readonly IAsyncEnumerable<T> _asyncEnumerable;

            public Enumerable(IAsyncEnumerable<T> asyncEnumerable) => _asyncEnumerable = asyncEnumerable;

            public Enumerator<T> GetEnumerator() => new Enumerator<T>(_asyncEnumerable.GetAsyncEnumerator());

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => new Enumerator<T>(_asyncEnumerable.GetAsyncEnumerator());

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public readonly struct Enumerator<T> : IEnumerator<T>
        {
            private readonly IAsyncEnumerator<T> _asyncEnumerator;

            public Enumerator(IAsyncEnumerator<T> asyncEnumerator) => _asyncEnumerator = asyncEnumerator;

#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
            public bool MoveNext() => _asyncEnumerator.MoveNextAsync().EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.

            public void Reset() => throw new NotSupportedException($"{GetType()} is a synchronous wrapper for {_asyncEnumerator.GetType()} async enumerator, which can't be reset, so IEnumerable.Reset() calls aren't supported.");

            public T Current => _asyncEnumerator.Current;

            object IEnumerator.Current => Current;

#pragma warning disable AZC0107 // Do not call public asynchronous method in synchronous scope.
            public void Dispose() => _asyncEnumerator.DisposeAsync().EnsureCompleted();
#pragma warning restore AZC0107 // Do not call public asynchronous method in synchronous scope.
        }

        public readonly struct WithCancellationTaskAwaitable
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable _awaitable;

            public WithCancellationTaskAwaitable(Task task, CancellationToken cancellationToken)
            {
                _awaitable = task.ConfigureAwait(false);
                _cancellationToken = cancellationToken;
            }

            public WithCancellationTaskAwaiter GetAwaiter() => new WithCancellationTaskAwaiter(_awaitable.GetAwaiter(), _cancellationToken);
        }

        public readonly struct WithCancellationTaskAwaitable<T>
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable<T> _awaitable;

            public WithCancellationTaskAwaitable(Task<T> task, CancellationToken cancellationToken)
            {
                _awaitable = task.ConfigureAwait(false);
                _cancellationToken = cancellationToken;
            }

            public WithCancellationTaskAwaiter<T> GetAwaiter() => new WithCancellationTaskAwaiter<T>(_awaitable.GetAwaiter(), _cancellationToken);
        }

        public readonly struct WithCancellationValueTaskAwaitable<T>
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredValueTaskAwaitable<T> _awaitable;

            public WithCancellationValueTaskAwaitable(ValueTask<T> task, CancellationToken cancellationToken)
            {
                _awaitable = task.ConfigureAwait(false);
                _cancellationToken = cancellationToken;
            }

            public WithCancellationValueTaskAwaiter<T> GetAwaiter() => new WithCancellationValueTaskAwaiter<T>(_awaitable.GetAwaiter(), _cancellationToken);
        }

        public readonly struct WithCancellationTaskAwaiter : ICriticalNotifyCompletion
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _taskAwaiter;

            public WithCancellationTaskAwaiter(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter, CancellationToken cancellationToken)
            {
                _taskAwaiter = awaiter;
                _cancellationToken = cancellationToken;
            }

            public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

            public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

            public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

            public void GetResult()
            {
                Debug.Assert(IsCompleted);
                if (!_taskAwaiter.IsCompleted)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }
                _taskAwaiter.GetResult();
            }

            private Action WrapContinuation(in Action originalContinuation)
                => _cancellationToken.CanBeCanceled
                    ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                    : originalContinuation;
        }

        public readonly struct WithCancellationTaskAwaiter<T> : ICriticalNotifyCompletion
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter _taskAwaiter;

            public WithCancellationTaskAwaiter(ConfiguredTaskAwaitable<T>.ConfiguredTaskAwaiter awaiter, CancellationToken cancellationToken)
            {
                _taskAwaiter = awaiter;
                _cancellationToken = cancellationToken;
            }

            public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

            public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

            public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

            public T GetResult()
            {
                Debug.Assert(IsCompleted);
                if (!_taskAwaiter.IsCompleted)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }
                return _taskAwaiter.GetResult();
            }

            private Action WrapContinuation(in Action originalContinuation)
                => _cancellationToken.CanBeCanceled
                    ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                    : originalContinuation;
        }

        public readonly struct WithCancellationValueTaskAwaiter<T> : ICriticalNotifyCompletion
        {
            private readonly CancellationToken _cancellationToken;
            private readonly ConfiguredValueTaskAwaitable<T>.ConfiguredValueTaskAwaiter _taskAwaiter;

            public WithCancellationValueTaskAwaiter(ConfiguredValueTaskAwaitable<T>.ConfiguredValueTaskAwaiter awaiter, CancellationToken cancellationToken)
            {
                _taskAwaiter = awaiter;
                _cancellationToken = cancellationToken;
            }

            public bool IsCompleted => _taskAwaiter.IsCompleted || _cancellationToken.IsCancellationRequested;

            public void OnCompleted(Action continuation) => _taskAwaiter.OnCompleted(WrapContinuation(continuation));

            public void UnsafeOnCompleted(Action continuation) => _taskAwaiter.UnsafeOnCompleted(WrapContinuation(continuation));

            public T GetResult()
            {
                Debug.Assert(IsCompleted);
                if (!_taskAwaiter.IsCompleted)
                {
                    _cancellationToken.ThrowIfCancellationRequested();
                }
                return _taskAwaiter.GetResult();
            }

            private Action WrapContinuation(in Action originalContinuation)
                => _cancellationToken.CanBeCanceled
                    ? new WithCancellationContinuationWrapper(originalContinuation, _cancellationToken).Continuation
                    : originalContinuation;
        }

        private class WithCancellationContinuationWrapper
        {
            private Action _originalContinuation;
            private readonly CancellationTokenRegistration _registration;

            public WithCancellationContinuationWrapper(Action originalContinuation, CancellationToken cancellationToken)
            {
                Action continuation = ContinuationImplementation;
                _originalContinuation = originalContinuation;
                _registration = cancellationToken.Register(continuation);
                Continuation = continuation;
            }

            public Action Continuation { get; }

            private void ContinuationImplementation()
            {
                Action originalContinuation = Interlocked.Exchange(ref _originalContinuation, null);
                if (originalContinuation != null)
                {
                    _registration.Dispose();
                    originalContinuation();
                }
            }
        }
    }
}
