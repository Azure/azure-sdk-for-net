// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#if !NET

namespace System.Diagnostics;

internal static class StopwatchExtensions
{
    extension(Stopwatch)
    {
        public static TimeSpan GetElapsedTime(long begin)
        {
            var end = Stopwatch.GetTimestamp();

            var timestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;
            var delta = end - begin;
            var ticks = (long)(timestampToTicks * delta);

            return new TimeSpan(ticks);
        }
    }
}

#endif
