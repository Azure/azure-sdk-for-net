// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Primitives
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

            this._originalTimeout = timeout;
            this._deadline = DateTime.MaxValue;
            this._deadlineSet = (timeout == TimeSpan.MaxValue);

            if (startTimeout && !this._deadlineSet)
            {
                this.SetDeadline();
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

            return Ticks.ToTimeSpan((Ticks.FromTimeSpan(timeout) / factor) + 1);
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
                throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, Resources1.TimeoutMustBePositive.FormatForUser(argumentName, timeout));
            }
        }

        public TimeSpan RemainingTime()
        {
            if (!this._deadlineSet)
            {
                this.SetDeadline();
                return this._originalTimeout;
            }

            if (this._deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            var remaining = this._deadline - DateTime.UtcNow;
            if (remaining <= TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return remaining;
        }

        public TimeSpan ElapsedTime()
        {
            return this._originalTimeout - this.RemainingTime();
        }

        private void SetDeadline()
        {
            Debug.Assert(!this._deadlineSet, "TimeoutHelper deadline set twice.");
            this._deadline = DateTime.UtcNow + this._originalTimeout;
            this._deadlineSet = true;
        }
    }
}
