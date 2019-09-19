// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Threading;

namespace TrackOne
{
    [DebuggerStepThrough]
    internal struct TimeoutHelper
    {
        private DateTime _deadline;
        private bool _deadlineSet;
        public static readonly TimeSpan s_maxWait = TimeSpan.FromMilliseconds(int.MaxValue);

        public TimeoutHelper(TimeSpan timeout) :
            this(timeout, false)
        {
        }

        public TimeoutHelper(TimeSpan timeout, bool startTimeout)
        {
            Fx.Assert(timeout >= TimeSpan.Zero, "timeout must be non-negative");

            OriginalTimeout = timeout;
            _deadline = DateTime.MaxValue;
            _deadlineSet = (timeout == TimeSpan.MaxValue);

            if (startTimeout && !_deadlineSet)
            {
                SetDeadline();
            }
        }

        public TimeSpan OriginalTimeout { get; }

        public static bool IsTooLarge(TimeSpan timeout)
        {
            return (timeout > TimeoutHelper.s_maxWait) && (timeout != TimeSpan.MaxValue);
        }

        public static TimeSpan FromMilliseconds(int milliseconds)
        {
            return milliseconds == Timeout.Infinite
                ? TimeSpan.MaxValue
                : TimeSpan.FromMilliseconds(milliseconds);
        }

        public static int ToMilliseconds(TimeSpan timeout)
        {
            if (timeout == TimeSpan.MaxValue)
            {
                return Timeout.Infinite;
            }

            long ticks = Ticks.FromTimeSpan(timeout);

            return ticks / TimeSpan.TicksPerMillisecond > int.MaxValue
                ? int.MaxValue
                : Ticks.ToMilliseconds(ticks);
        }

        public static TimeSpan Min(TimeSpan val1, TimeSpan val2)
        {
            return val1 > val2 ? val2 : val1;
        }

        public static DateTime Min(DateTime val1, DateTime val2)
        {
            return val1 > val2 ? val2 : val1;
        }

        public static TimeSpan Add(TimeSpan timeout1, TimeSpan timeout2)
        {
            return Ticks.ToTimeSpan(Ticks.Add(Ticks.FromTimeSpan(timeout1), Ticks.FromTimeSpan(timeout2)));
        }

        public static DateTime Add(DateTime time, TimeSpan timeout)
        {
            if (timeout >= TimeSpan.Zero && DateTime.MaxValue - time <= timeout)
            {
                return DateTime.MaxValue;
            }
            if (timeout <= TimeSpan.Zero && DateTime.MinValue - time >= timeout)
            {
                return DateTime.MinValue;
            }
            return time + timeout;
        }

        public static DateTime Subtract(DateTime time, TimeSpan timeout)
        {
            return Add(time, TimeSpan.Zero - timeout);
        }

        public static TimeSpan Divide(TimeSpan timeout, int factor)
        {
            return timeout == TimeSpan.MaxValue
                ? TimeSpan.MaxValue
                : Ticks.ToTimeSpan((Ticks.FromTimeSpan(timeout) / factor) + 1);
        }

        public TimeSpan RemainingTime()
        {
            if (!_deadlineSet)
            {
                SetDeadline();
                return OriginalTimeout;
            }

            if (_deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            TimeSpan remaining = _deadline - DateTime.UtcNow;
            return remaining <= TimeSpan.Zero ? TimeSpan.Zero : remaining;
        }

        public TimeSpan ElapsedTime()
        {
            return OriginalTimeout - RemainingTime();
        }

        private void SetDeadline()
        {
            Fx.Assert(!_deadlineSet, "TimeoutHelper deadline set twice.");
            _deadline = DateTime.UtcNow + OriginalTimeout;
            _deadlineSet = true;
        }

        public static void ThrowIfNegativeArgument(TimeSpan timeout)
        {
            ThrowIfNegativeArgument(timeout, "timeout");
        }

        public static void ThrowIfNegativeArgument(TimeSpan timeout, string argumentName)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, Resources.TimeoutMustBeNonNegative.FormatForUser(argumentName, timeout));
            }
        }

        public static void ThrowIfNonPositiveArgument(TimeSpan timeout)
        {
            ThrowIfNonPositiveArgument(timeout, "timeout");
        }

        public static void ThrowIfNonPositiveArgument(TimeSpan timeout, string argumentName)
        {
            if (timeout <= TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, Resources.TimeoutMustBePositive.FormatForUser(argumentName, timeout));
            }
        }

        public static bool WaitOne(WaitHandle waitHandle, TimeSpan timeout)
        {
            ThrowIfNegativeArgument(timeout);
            if (timeout == TimeSpan.MaxValue)
            {
                waitHandle.WaitOne();
                return true;
            }

            return waitHandle.WaitOne(timeout);
        }
    }
}
