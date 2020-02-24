// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
#pragma warning disable AZC0102
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public static void EnsureCompleted(this Task task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102
            task.GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public static T EnsureCompleted<T>(this ValueTask<T> task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102
            return task.GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        public static void EnsureCompleted(this ValueTask task)
        {
#if DEBUG
            VerifyTaskCompleted(task.IsCompleted);
#endif
#pragma warning disable AZC0102
            task.GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

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
    }
}
