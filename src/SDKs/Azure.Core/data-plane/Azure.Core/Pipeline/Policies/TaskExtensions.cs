// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline.Policies
{
    internal static class TaskExtensions
    {
        public static T AssertCompleted<T>(this Task<T> task)
        {
            AssertTaskCompleted(task);
            return task.GetAwaiter().GetResult();
        }

        public static void AssertCompleted(this Task task)
        {
            AssertTaskCompleted(task);
            task.GetAwaiter().GetResult();
        }

        [Conditional("DEBUG")]
        private static void AssertTaskCompleted(Task task)
        {
            Debug.Assert(task.IsCompleted);
        }
    }
}
