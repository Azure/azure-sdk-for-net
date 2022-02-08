// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Rest.WebPubSub.Tests
{
    public static class TaskExtensions
    {
        public static async Task OrTimeout(this Task task, int millisecondsDelay = 5000)
        {
            var completed = await Task.WhenAny(task, Task.Delay(millisecondsDelay));
            if (!task.IsCompleted)
            {
                throw new TimeoutException();
            }
        }
    }
}
