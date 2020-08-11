// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;
    using System.Diagnostics;

    [DebuggerStepThrough]
    struct TimeoutHelper
    {
        DateTime deadline;
        bool deadlineSet;
        TimeSpan originalTimeout;

        public TimeoutHelper(TimeSpan timeout, bool startTimeout)
        {
            Debug.Assert(timeout >= TimeSpan.Zero, "timeout must be non-negative");

            this.originalTimeout = timeout;
            this.deadline = DateTime.MaxValue;
            this.deadlineSet = (timeout == TimeSpan.MaxValue);

            if (startTimeout && !this.deadlineSet)
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
                throw Fx.Exception.ArgumentOutOfRange(argumentName, timeout, Resources.TimeoutMustBePositive.FormatForUser(argumentName, timeout));
            }
        }

        public TimeSpan RemainingTime()
        {
            if (!this.deadlineSet)
            {
                this.SetDeadline();
                return this.originalTimeout;
            }

            if (this.deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }

            var remaining = this.deadline - DateTime.UtcNow;
            if (remaining <= TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return remaining;
        }

        public TimeSpan ElapsedTime()
        {
            return this.originalTimeout - this.RemainingTime();
        }

        void SetDeadline()
        {
            Debug.Assert(!this.deadlineSet, "TimeoutHelper deadline set twice.");
            this.deadline = DateTime.UtcNow + this.originalTimeout;
            this.deadlineSet = true;
        }
    }
}