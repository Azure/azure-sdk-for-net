// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class TaskExtensionHelper
    {
        public static void Schedule(Func<Task> func)
        {
            _ = ScheduleInternal(func);
        }

        private static async Task ScheduleInternal(Func<Task> func)
        {
            try
            {
                await func().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ScheduleTaskFailed(func, ex);
            }
        }

    }
}
