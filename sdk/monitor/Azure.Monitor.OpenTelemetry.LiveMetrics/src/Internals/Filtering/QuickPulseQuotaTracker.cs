// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Threading;

    /// <summary>
    /// Quota tracker to support throttling telemetry item collection.
    /// </summary>
    internal class QuickPulseQuotaTracker
    {
        private readonly float quotaAccrualRatePerSec;

        private readonly DateTimeOffset startedTrackingTime;

        private float currentQuota;

        private float maxQuota;

        private long lastQuotaAccrualFullSeconds;

        public QuickPulseQuotaTracker(float maxQuota, float startQuota, float? quotaAccrualRatePerSec = null)
        {
            this.maxQuota = maxQuota;
            this.quotaAccrualRatePerSec = quotaAccrualRatePerSec ?? this.maxQuota / 60; // should not be calculated from maxQuota - Should be passed from the service
            startedTrackingTime = DateTimeOffset.UtcNow;
            lastQuotaAccrualFullSeconds = 0;
            currentQuota = startQuota;
        }

        public float CurrentQuota => Interlocked.CompareExchange(ref currentQuota, 0, 0);

        public float MaxQuota => Interlocked.CompareExchange(ref maxQuota, 0, 0);

        public bool QuotaExhausted => Interlocked.CompareExchange(ref currentQuota, 0, 0) < 1f;

        /// <summary>
        /// Checks if there's quota left.
        /// </summary>
        /// <returns><b>true</b> if there's still quota left, <b>false</b> otherwise.</returns>
        public bool ApplyQuota()
        {
            var currentTimeFullSeconds = (long)(DateTimeOffset.UtcNow - startedTrackingTime).TotalSeconds;

            AccrueQuota(currentTimeFullSeconds);

            return UseQuota();
        }

        private bool UseQuota()
        {
            var spin = new SpinWait();

            while (true)
            {
                float originalValue = Interlocked.CompareExchange(ref currentQuota, 0, 0);

                if (originalValue < 1f)
                {
                    return false;
                }

                float newValue = originalValue - 1f;

                if (Interlocked.CompareExchange(ref currentQuota, newValue, originalValue) == originalValue)
                {
                    return true;
                }

                spin.SpinOnce();
            }
        }

        private void AccrueQuota(long currentTimeFullSeconds)
        {
            var spin = new SpinWait();

            while (true)
            {
                long lastQuotaAccrualFullSecondsLocal = Interlocked.Read(ref lastQuotaAccrualFullSeconds);

                long fullSecondsSinceLastQuotaAccrual = currentTimeFullSeconds - lastQuotaAccrualFullSecondsLocal;

                // fullSecondsSinceLastQuotaAccrual <= 0 means we're in a second for which some thread has already updated this.lastQuotaAccrualFullSeconds
                if (fullSecondsSinceLastQuotaAccrual > 0)
                {
                    // we are in a new second (possibly along with a bunch of competing threads, some of which might actually be in different (also new) seconds)
                    // only one thread will succeed in updating this.lastQuotaAccrualFullSeconds
                    long newValue = lastQuotaAccrualFullSecondsLocal + fullSecondsSinceLastQuotaAccrual;

                    long valueBeforeExchange = Interlocked.CompareExchange(
                        ref lastQuotaAccrualFullSeconds,
                        newValue,
                        lastQuotaAccrualFullSecondsLocal);

                    if (valueBeforeExchange == lastQuotaAccrualFullSecondsLocal)
                    {
                        // we have updated this.lastQuotaAccrualFullSeconds, now increase the quota value
                        IncreaseQuota(fullSecondsSinceLastQuotaAccrual);

                        break;
                    }
                    else if (valueBeforeExchange >= newValue)
                    {
                        // a thread that was in a later (or same) second has beaten us to updating the value
                        // we don't have to do anything since the time that has passed between the previous
                        // update and this thread's current time has already been accounted for by that other thread
                        break;
                    }
                    else
                    {
                        // a thread that was in an earlier second (but still a later one compared to the previous update) has beaten us to updating the value
                        // we have to repeat the attempt to account for the time that has passed since
                    }
                }
                else
                {
                    // we're within a second that has already been accounted for, do nothing
                    break;
                }

                spin.SpinOnce();
            }
        }

        private void IncreaseQuota(long seconds)
        {
            var spin = new SpinWait();

            while (true)
            {
                float originalValue = Interlocked.CompareExchange(ref currentQuota, 0, 0);

                float delta = Math.Min(quotaAccrualRatePerSec * seconds, maxQuota - originalValue);

                if (Interlocked.CompareExchange(ref currentQuota, originalValue + delta, originalValue) == originalValue)
                {
                    break;
                }

                spin.SpinOnce();
            }
        }
    }
}
