// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal static class TaskExtensions
    {
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

#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
            public bool MoveNext() => _asyncEnumerator.MoveNextAsync().EnsureCompleted();
#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.

            public void Reset() => throw new NotSupportedException();

            public T Current => _asyncEnumerator.Current;

            object IEnumerator.Current => Current;

#pragma warning disable AZC0107 // DO NOT call public asynchronous method in synchronous scope.
            public void Dispose() => _asyncEnumerator.DisposeAsync().EnsureCompleted();
#pragma warning restore AZC0107 // DO NOT call public asynchronous method in synchronous scope.
        }
    }
}
