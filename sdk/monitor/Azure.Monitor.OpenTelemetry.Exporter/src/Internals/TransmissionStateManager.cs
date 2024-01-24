// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class TransmissionStateManager : IDisposable
    {
        private const int MaxDelayInSeconds = 3600;

        private const int MinDelayInSeconds = 10;

        private readonly Random _random = new();

        /// <summary>
        /// Minimum time interval between failures to increment consecutive error count.
        /// </summary>
        private TimeSpan _minIntervalToUpdateConsecutiveErrors = TimeSpan.FromSeconds(20);

        /// <summary>
        /// Time threshold after which consecutive error count can be incremented.
        /// </summary>
        private DateTimeOffset _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.MinValue;

        private readonly System.Timers.Timer _backOffIntervalTimer;

        private double _syncBackOffIntervalCalculation;

        private int _consecutiveErrors;
        private bool _disposed;

        internal TransmissionState State { get; private set; }

        internal TransmissionStateManager()
        {
            _backOffIntervalTimer = new();
            _backOffIntervalTimer.Elapsed += ResetTransmission;
            _backOffIntervalTimer.AutoReset = false;
            State = TransmissionState.Closed;
        }

        /// <summary>
        /// For test purposes.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minIntervalToUpdateConsecutiveErrors"></param>
        /// <param name="nextMinTimeToUpdateConsecutiveErrors"></param>
        /// <param name="backOffIntervalTimer"></param>
        /// <param name="state"></param>
        internal TransmissionStateManager(
            Random random,
            TimeSpan minIntervalToUpdateConsecutiveErrors,
            DateTimeOffset nextMinTimeToUpdateConsecutiveErrors,
            System.Timers.Timer backOffIntervalTimer,
            TransmissionState state)
        {
            _random = random;
            _minIntervalToUpdateConsecutiveErrors = minIntervalToUpdateConsecutiveErrors;
            _nextMinTimeToUpdateConsecutiveErrors = nextMinTimeToUpdateConsecutiveErrors;
            _backOffIntervalTimer = backOffIntervalTimer;
            State = state;
        }

        /// <summary>
        /// Stops transmitting data to backend.
        /// </summary>
        internal void OpenTransmission()
        {
            State = TransmissionState.Open;
        }

        /// <summary>
        /// Enable transmitting data to backend.
        /// To be called for each successful request or after back-off interval expiration.
        /// </summary>
        internal void CloseTransmission()
        {
            State = TransmissionState.Closed;
        }

        /// <summary>
        /// Resets consecutive error count.
        /// To be called for each successful request.
        /// </summary>
        internal void ResetConsecutiveErrors()
        {
            _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.MinValue;
            Interlocked.Exchange(ref _consecutiveErrors, 0);
        }

        internal void ResetTransmission(object? source, System.Timers.ElapsedEventArgs e)
        {
            CloseTransmission();
        }

        internal void EnableBackOff(Response? response)
        {
            if (Interlocked.Exchange(ref _syncBackOffIntervalCalculation, 1) == 0)
            {
                // Do not increase number of errors more often than minimum interval.
                // since we can have 4 parallel transmissions (logs, metrics, traces and offline storage transmission) and all of them most likely would fail if we have intermittent error.
                if (DateTimeOffset.UtcNow > _nextMinTimeToUpdateConsecutiveErrors)
                {
                    Interlocked.Increment(ref _consecutiveErrors);
                    _nextMinTimeToUpdateConsecutiveErrors = DateTimeOffset.UtcNow + _minIntervalToUpdateConsecutiveErrors;

                    // If backend responded with a retryAfter header we will use it
                    // else we will calculate by increasing time interval exponentially.
                    var backOffTimeInterval = HttpPipelineHelper.TryGetRetryIntervalTimespan(response, out var retryAfterInterval) ? retryAfterInterval : GetBackOffTimeInterval();

                    if (backOffTimeInterval > TimeSpan.Zero)
                    {
                        OpenTransmission();

                        _backOffIntervalTimer.Interval = backOffTimeInterval.TotalMilliseconds;

                        _backOffIntervalTimer.Start();

                        AzureMonitorExporterEventSource.Log.BackoffEnabled(backOffTimeInterval.TotalMilliseconds);
                    }
                }

                Interlocked.Exchange(ref _syncBackOffIntervalCalculation, 0);
            }
        }

        /// <summary>
        /// Calculates the time interval for which the transmission should be halted.
        /// Number of consecutive errors are taken in to account to increase the time.
        /// Random variation is introduced in order to avoid collision.
        /// </summary>
        /// <returns>BackOff time interval.</returns>
        internal TimeSpan GetBackOffTimeInterval()
        {
            double delayInSeconds = 0;
            if (_consecutiveErrors > 0)
            {
                double backOffSlot = (Math.Pow(2, _consecutiveErrors) - 1) / 2;
                var backOffDelay = _random.Next(1, (int)Math.Min(backOffSlot * MinDelayInSeconds, int.MaxValue));
                delayInSeconds = Math.Max(Math.Min(backOffDelay, MaxDelayInSeconds), MinDelayInSeconds);
            }

            return TimeSpan.FromSeconds(delayInSeconds);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _backOffIntervalTimer?.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
