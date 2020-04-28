// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Diagnostics;

    [DebuggerStepThrough]
    internal struct TimeoutHelper
    {
	    private DateTime _deadline;
	    private bool _deadlineSet;
	    private TimeSpan _originalTimeout;

        public TimeoutHelper(TimeSpan timeout, bool startTimeout)
        {
            Debug.Assert(timeout >= TimeSpan.Zero, "timeout must be non-negative");

            _originalTimeout = timeout;
            _deadline = DateTime.MaxValue;
            _deadlineSet = timeout == TimeSpan.MaxValue;

            if (startTimeout && !_deadlineSet)
            {
                SetDeadline();
            }
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
            if (timeout == TimeSpan.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            return Ticks.ToTimeSpan(Ticks.FromTimeSpan(timeout) / factor + 1);
        }

        public static TimeSpan Min(TimeSpan time1, TimeSpan time2)
        {
            if (time1 <= time2)
            {
                return time1;
            }

            return time2;
        }

        public static DateTime Min(DateTime first, DateTime second)
        {
            if (first <= second)
            {
                return first;
            }

            return second;
        }

        public static void ThrowIfNegativeArgument(TimeSpan timeout)
        {
            ThrowIfNegativeArgument(timeout, nameof(timeout));
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
            ThrowIfNonPositiveArgument(timeout, nameof(timeout));
        }

        public static void ThrowIfNonPositiveArgument(TimeSpan timeout, string argumentName)
        {
            if (timeout <= TimeSpan.Zero)
            {
                throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, Resources.TimeoutMustBePositive.FormatForUser(argumentName, timeout));
            }
        }

        public TimeSpan RemainingTime()
        {
            if (!_deadlineSet)
            {
                SetDeadline();
                return _originalTimeout;
            }

            if (_deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            var remaining = _deadline - DateTime.UtcNow;
            if (remaining <= TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return remaining;
        }

        public TimeSpan ElapsedTime()
        {
            return _originalTimeout - RemainingTime();
        }

        private void SetDeadline()
        {
            Debug.Assert(!_deadlineSet, "TimeoutHelper deadline set twice.");
            _deadline = DateTime.UtcNow + _originalTimeout;
            _deadlineSet = true;
        }
    }
}