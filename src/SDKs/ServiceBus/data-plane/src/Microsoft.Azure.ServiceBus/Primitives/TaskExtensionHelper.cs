// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Threading.Tasks;

    static class TaskExtensionHelper
    {
        public static void Schedule(Func<Task> func)
        {
            Task.Run(async () =>
            {
                try
                {
                    await func().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    MessagingEventSource.Log.ScheduleTaskFailed(func, ex);
                }
            });
        }
    }
}