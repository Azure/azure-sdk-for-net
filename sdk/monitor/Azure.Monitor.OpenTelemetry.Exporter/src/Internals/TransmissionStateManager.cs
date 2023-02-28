// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmissionStateManager
    {
        private int _consecutiveErrors;

        private const int MaxDelayInMilliseconds = 3600000;

        internal const int MinDelayInMilliseconds = 10000;

        private readonly Random s_random = new();

        private readonly TimeSpan _minIntervalToUpdateConsecutiveErrors = TimeSpan.FromMilliseconds(20000);

        private DateTimeOffset _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.MinValue;

        private readonly System.Timers.Timer _timer;

        private double _syncBackOffIntervalCalculation;

        private double _syncconsecutiveErrorIncrement;

        private static TransmissionStateManager? s_transmissionStateManager;

        internal static TransmissionStateManager Instance => s_transmissionStateManager ??= new TransmissionStateManager();

        internal TransmissionState State { get; private set; }

        private TransmissionStateManager()
        {
            _timer = new();
            _timer.Elapsed += RestartTransmission;
            _timer.AutoReset = false;
            State = TransmissionState.Open;
        }

        /// <summary>
        /// Prevents transmitting data to backend.
        /// </summary>
        private void CloseTransmission()
        {
            State = TransmissionState.Closed;
        }

        /// <summary>
        /// Re-enable transmitting telemetry to backend.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        internal void RestartTransmission(Object source, System.Timers.ElapsedEventArgs e)
        {
            _consecutiveErrors = 0;
            // reset _sync so that the threads can close the transmission again if needed.
            _syncBackOffIntervalCalculation = 0;
            State = TransmissionState.Open;
        }

        internal void SetBackOffTimeAndShutOffTransmission(Response? response)
        {
            if (Interlocked.Exchange(ref _syncconsecutiveErrorIncrement, 1) == 0)
            {
                // Do not increase number of errors more often than minimum interval (MinDelayInSeconds).
                // since we have at most 4 senders (3 transmitters and one offline storage thread) and all of them most likely would fail if we have intermittent error.
                if (DateTimeOffset.UtcNow > _nextMinTimeToUpdateConsecutiveErrors)
                {
                    _consecutiveErrors++;
                    _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.UtcNow + _minIntervalToUpdateConsecutiveErrors;
                }

                Interlocked.Exchange(ref _syncconsecutiveErrorIncrement, 0);
            }

            if (Interlocked.Exchange(ref _syncBackOffIntervalCalculation, 1) == 0)
            {
                // if backend responded with a retryAfter header we will use it
                // else we will calculate by increasing time interval exponentially.
                var retryAfterInterval = HttpPipelineHelper.GetRetryInterval(response);
                var backOffTimeInterval = retryAfterInterval != TimeSpan.MinValue ? retryAfterInterval : GetBackOffTimeInterval();

                CloseTransmission();

                _timer.Interval = backOffTimeInterval.TotalMilliseconds;

                _timer.Start();
            }
        }

        internal TimeSpan GetBackOffTimeInterval()
        {
            double delayInMilliseconds = MinDelayInMilliseconds;
            if (_consecutiveErrors > 1)
            {
                double backOffSlot = (Math.Pow(2, _consecutiveErrors) - 1) / 2;
                var backOffDelay = s_random.Next(1, (int)Math.Min(backOffSlot * MinDelayInMilliseconds, int.MaxValue));
                delayInMilliseconds = Math.Max(Math.Min(backOffDelay, MaxDelayInMilliseconds), MinDelayInMilliseconds);
            }

            return TimeSpan.FromMilliseconds(delayInMilliseconds);
        }
    }
}
