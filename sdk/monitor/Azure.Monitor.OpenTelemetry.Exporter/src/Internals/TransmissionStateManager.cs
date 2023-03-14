// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmissionStateManager
    {
        private int _consecutiveErrors;

        private const long MaxDelayInMilliseconds = 3600000;

        internal const long MinDelayInMilliseconds = 10000;

        private readonly Random _random = new();

        private readonly TimeSpan _minIntervalToUpdateConsecutiveErrors = TimeSpan.FromMilliseconds(20000);

        private DateTimeOffset _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.MinValue;

        private readonly System.Timers.Timer _timer;

        private double _syncBackOffIntervalCalculation;

        internal TransmissionState State { get; private set; }

        private TransmissionStateManager()
        {
            _timer = new();
            _timer.Elapsed += RestartTransmission;
            _timer.AutoReset = false;
            State = TransmissionState.Closed;
        }

        /// <summary>
        /// Prevents transmitting data to backend.
        /// </summary>
        private void OpenTransmission()
        {
            State = TransmissionState.Open;
        }

        internal void RestartTransmission(Object source, System.Timers.ElapsedEventArgs e)
        {
            _consecutiveErrors = 0;

            // reset _sync so that the threads can close the transmission again if needed.
            _syncBackOffIntervalCalculation = 0;
            State = TransmissionState.Closed;
        }

        internal void EnableBackOff(Response? response)
        {
            if (Interlocked.Exchange(ref _syncBackOffIntervalCalculation, 1) == 0)
            {
                // Do not increase number of errors more often than minimum interval (MinDelayInMilliseconds).
                // since we can have 4 parallel transmissions (logs, metrics, traces and offline storage tranmission) and all of them most likely would fail if we have intermittent error.
                if (DateTimeOffset.UtcNow > _nextMinTimeToUpdateConsecutiveErrors)
                {
                    _consecutiveErrors++;
                    _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.UtcNow + _minIntervalToUpdateConsecutiveErrors;

                    // If backend responded with a retryAfter header we will use it
                    // else we will calculate by increasing time interval exponentially.
                    var retryAfterInterval = HttpPipelineHelper.GetRetryIntervalTimespan(response);
                    var backOffTimeInterval = retryAfterInterval != TimeSpan.MinValue ? retryAfterInterval : GetBackOffTimeInterval();

                    OpenTransmission();

                    _timer.Interval = backOffTimeInterval.TotalMilliseconds;

                    _timer.Start();
                }

                Interlocked.Exchange(ref _syncBackOffIntervalCalculation, 0);
            }
        }

        internal TimeSpan GetBackOffTimeInterval()
        {
            double delayInMilliseconds = MinDelayInMilliseconds;
            if (_consecutiveErrors > 1)
            {
                double backOffSlot = (Math.Pow(2, _consecutiveErrors) - 1) / 2;
                var backOffDelay = _random.Next(1, (int)Math.Min(backOffSlot * MinDelayInMilliseconds, int.MaxValue));
                delayInMilliseconds = Math.Max(Math.Min(backOffDelay, MaxDelayInMilliseconds), MinDelayInMilliseconds);
            }

            return TimeSpan.FromMilliseconds(delayInMilliseconds);
        }
    }
}
