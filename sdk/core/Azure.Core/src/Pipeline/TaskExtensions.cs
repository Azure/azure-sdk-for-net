// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal static class TaskExtensions
    {
        public static T EnsureCompleted<T>(this Task<T> task)
        {
            Debug.Assert(task.IsCompleted);
            return task.GetAwaiter().GetResult();
        }

        public static void EnsureCompleted(this Task task)
        {
            Debug.Assert(task.IsCompleted);
            task.GetAwaiter().GetResult();
        }

        public static T EnsureCompleted<T>(this ValueTask<T> task)
        {
            Debug.Assert(task.IsCompleted);
            return task.GetAwaiter().GetResult();
        }

        public static void EnsureCompleted(this ValueTask task)
        {
            Debug.Assert(task.IsCompleted);
            task.GetAwaiter().GetResult();
        }

        public static ConfiguredValueTaskAwaitable<T> EnsureCompleted<T>(this ConfiguredValueTaskAwaitable<T> task, bool async)
        {
            Debug.Assert(async || task.GetAwaiter().IsCompleted);
            return task;
        }

        public static ConfiguredValueTaskAwaitable EnsureCompleted(this ConfiguredValueTaskAwaitable task, bool async)
        {
            Debug.Assert(async || task.GetAwaiter().IsCompleted);
            return task;
        }
    }
}
