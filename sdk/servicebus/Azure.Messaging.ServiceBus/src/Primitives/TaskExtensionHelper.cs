// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;

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
                MessagingEventSource.Log.ScheduleTaskFailed(func, ex);
            }
        }

    }
}
