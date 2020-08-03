﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading;

namespace Azure.Identity
{
    // Implementation is taken from https://github.com/dotnet/runtime/blob/master/src/libraries/System.Diagnostics.DiagnosticSource/src/System/Diagnostics/Activity.DateTime.netfx.cs
    internal static partial class DateTimeHelpers
    {
        private static TimeSync _timeSync = new TimeSync();

        // sync DateTime and Stopwatch ticks every 2 hours
#pragma warning disable CA1823 // suppress unused field warning, as it's used to keep the timer alive
        private static readonly Timer _syncTimeUpdater = InitializeSyncTimer();
#pragma warning restore CA182

        private static TimerCallback _sync = s =>
        {
            // wait for DateTime.UtcNow update to the next granular value
            Thread.Sleep(1);
            Interlocked.Exchange(ref _timeSync, new TimeSync());
        };

        /// <summary>
        /// Returns high resolution (1 DateTime tick) current UTC DateTime.
        /// </summary>
        private static DateTime GetUtcNowImplementation()
        {
            // DateTime.UtcNow accuracy on .NET Framework is ~16ms, this method
            // uses combination of Stopwatch and DateTime to calculate accurate UtcNow.

            var tmp = _timeSync;

            // Timer ticks need to be converted to DateTime ticks
            long dateTimeTicksDiff = (long)((Stopwatch.GetTimestamp() - tmp.SyncStopwatchTicks) * 10000000L / (double)Stopwatch.Frequency);

            // DateTime.AddSeconds (or Milliseconds) rounds value to 1 ms, use AddTicks to prevent it
            return tmp.SyncUtcNow.AddTicks(dateTimeTicksDiff);
        }

        [System.Security.SecuritySafeCritical]
        private static Timer InitializeSyncTimer()
        {
            Timer timer;
            // Don't capture the current ExecutionContext and its AsyncLocals onto the timer causing them to live forever
            bool restoreFlow = false;
            try
            {
                if (!ExecutionContext.IsFlowSuppressed())
                {
                    ExecutionContext.SuppressFlow();
                    restoreFlow = true;
                }

                timer = new Timer(_sync, null, 0, 7200_000);
            }
            finally
            {
                // Restore the current ExecutionContext
                if (restoreFlow)
                    ExecutionContext.RestoreFlow();
            }

            return timer;
        }

        private class TimeSync
        {
            public readonly DateTime SyncUtcNow = DateTime.UtcNow;
            public readonly long SyncStopwatchTicks = Stopwatch.GetTimestamp();
        }
    }
}
