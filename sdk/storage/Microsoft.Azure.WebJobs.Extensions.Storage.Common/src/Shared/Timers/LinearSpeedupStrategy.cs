// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    internal class LinearSpeedupStrategy : IDelayStrategy
    {
        private readonly TimeSpan _normalInterval;
        private readonly TimeSpan _minimumInterval;
        private readonly int _failureSpeedupDivisor;

        private TimeSpan _currentInterval;

        public LinearSpeedupStrategy(TimeSpan normalInterval, TimeSpan minimumInterval)
            : this(normalInterval, minimumInterval, 2)
        {
        }

        public LinearSpeedupStrategy(TimeSpan normalInterval, TimeSpan minimumInterval, int failureSpeedupDivisor)
        {
            if (normalInterval.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(normalInterval), "The TimeSpan must not be negative.");
            }

            if (minimumInterval.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumInterval), "The TimeSpan must not be negative.");
            }

            if (minimumInterval.Ticks > normalInterval.Ticks)
            {
                throw new ArgumentException("The minimumInterval must not be greater than the normalInterval.",
                    nameof(minimumInterval));
            }

            if (failureSpeedupDivisor < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(failureSpeedupDivisor),
                    "The failureSpeedupDivisor must not be less than 1.");
            }

            _normalInterval = normalInterval;
            _minimumInterval = minimumInterval;
            _failureSpeedupDivisor = failureSpeedupDivisor;
            _currentInterval = normalInterval;
        }

        public TimeSpan GetNextDelay(bool executionSucceeded)
        {
            if (executionSucceeded)
            {
                _currentInterval = _normalInterval;
            }
            else
            {
                TimeSpan speedupInterval = new TimeSpan(_currentInterval.Ticks / _failureSpeedupDivisor);
                _currentInterval = Max(speedupInterval, _minimumInterval);
            }

            return _currentInterval;
        }

        private static TimeSpan Max(TimeSpan x, TimeSpan y)
        {
            return x.Ticks > y.Ticks ? x : y;
        }

        public static ITaskSeriesTimer CreateTimer(IRecurrentCommand command, TimeSpan normalInterval,
            TimeSpan minimumInterval, IWebJobsExceptionHandler exceptionHandler)
        {
            IDelayStrategy delayStrategy = new LinearSpeedupStrategy(normalInterval, minimumInterval);
            ITaskSeriesCommand timerCommand = new RecurrentTaskSeriesCommand(command, delayStrategy);
            return new TaskSeriesTimer(timerCommand, exceptionHandler, Task.Delay(normalInterval));
        }
    }
}
