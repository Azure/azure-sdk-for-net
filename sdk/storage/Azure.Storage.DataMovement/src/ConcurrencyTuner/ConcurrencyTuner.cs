// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Using an interpretation of AIMD to determine the best concurrency
    /// Based on AzCopy ConcurrencyTuner
    ///
    /// The worker should only start when we have any traffic.
    /// </summary>
    internal class ConcurrencyTuner
    {
        internal static ResourceMonitor _resourceMonitor;
        internal double _maxMemoryUsage;
        internal int _initialConcurrency;
        internal int _maxConcurrency;
        internal float _maxCpuUsage;
        internal int _finalReason; // ConcurrencyTunerState
        internal int _finalConcurrency;
        internal SemaphoreSlim _lockFinal;
        internal Channel<ConcurrencyObservation> _observations;
        internal Channel<ConcurrencyRecommendation> _recommendations;
        private CancellationToken _cancellationToken;

        private IProcessor<Func<Task>> _chunkProcessor;

        public int MaxConcurrency
        {
            get => _maxConcurrency;
            set
            {
                _maxConcurrency = value;
                _chunkProcessor.MaxConcurrentProcessing = value;
            }
        }

        internal ConcurrencyTuner(
            ResourceMonitor resourceMonitor,
            ThroughputMonitor throughputMonitor,
            IProcessor<Func<Task>> _chunkProcessor,
            TimeSpan monitoringInterval,
            double maxMemoryUsage,
            int initialConcurrency,
            int maxConcurrency,
            float maxCpuUsage)
        {
            this._chunkProcessor = _chunkProcessor;
            _initialConcurrency = initialConcurrency;
            _maxConcurrency = maxConcurrency;
            _maxMemoryUsage = maxMemoryUsage;
            _maxCpuUsage = maxCpuUsage;
            _resourceMonitor = resourceMonitor;
            _finalReason = (int)ConcurrencyTunerState.ConcurrencyReasonNone;
            _finalConcurrency = _initialConcurrency;
            _observations = Channel.CreateUnbounded<ConcurrencyObservation>();
            _recommendations = Channel.CreateUnbounded<ConcurrencyRecommendation>();
        }

        internal async Task<ConcurrencyRecommendation> GetRecommendedConcurrency(int currentMbps, bool highCpuUsage)
        {
            if (currentMbps < 0)
            {
                return new ConcurrencyRecommendation()
                {
                    Concurrency = _initialConcurrency,
                    State = ConcurrencyTunerState.ConcurrencyReasonInitial
                };
            }
            else
            {
                // push value into worker, and get its result
                await _observations.Writer.WriteAsync(new ConcurrencyObservation()
                {
                    isHighCpu = highCpuUsage,
                    Mpbs = currentMbps
                }).ConfigureAwait(false);
            }

            return await _recommendations.Reader.ReadAsync().ConfigureAwait(false);
        }

        internal async Task SetConcurrencyAsync(
            int mbps,
            ConcurrencyTunerState state,
            CancellationToken cancellationToken)
        {
            await _recommendations.Writer.WriteAsync(new ConcurrencyRecommendation()
            {
                State = state,
                Concurrency = mbps,
            },
            cancellationToken).ConfigureAwait(false);
        }

        internal async Task<ConcurrencyObservation> GetCurrentSpeedAsync(CancellationToken cancellationToken)
        {
            // assume that any necessary time delays, to measure or to wait for stablization,
            // are done by the caller of GetRecommendedConcurrency
            return await _observations.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);
        }

        internal Task SignalStabilityAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal void StoreFinalState(ConcurrencyRecommendation recommendation)
        {
            Volatile.Write(ref _finalConcurrency, recommendation.Concurrency);
            Volatile.Write(ref _finalReason, (int)recommendation.State);
        }

        internal ConcurrencyRecommendation GetFinalState()
        {
            return new ConcurrencyRecommendation()
            {
                Concurrency = _finalConcurrency,
                State = (ConcurrencyTunerState)_finalReason
            };
        }

        internal Task RequestCallbackWhenStable()
        {
            throw new NotImplementedException();
        }

        internal void Start(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _resourceMonitor.StartMonitoring(cancellationToken);
            ;
        }

        // Removing the stopMonitoring method. This will be handled by the TransferManager
        // when the Transfer Manager calls `.Cancel()` on the cancellationTokenSource
        //internal void Stop()
        //{
        //    _resourceMonitor.StopMonitoring();
        //}

        internal async Task Worker()
        {
            double multiplier = DataMovementConstants.ConcurrencyTuner.BoostedMultiplier;
            double concurrency = _initialConcurrency;
            bool atMax = false;
            bool everSawHighCpu = false;
            bool probeHigherRegardless = false;
            bool dontBackoffRegardless = false;
            int multiplierReductionCount = 0;
            ConcurrencyTunerState lastReason = ConcurrencyTunerState.ConcurrencyReasonNone;

            // get initial baseline throughput
            ConcurrencyObservation lastSpeed = await GetCurrentSpeedAsync(_cancellationToken).ConfigureAwait(false);

            while (!_cancellationToken.IsCancellationRequested) // todo, add the conditions here
            {
                ConcurrencyTunerState rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonSeeking;

                if (IsBoostedMultiplierNeeded(multiplier, concurrency))
                {
                    // don't use boosted multiplier for ever
                    multiplier = DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
                }
                atMax = IsAtMaxConcurrency(multiplier, concurrency);

                if (atMax)
                {
                    DecreaseMultiplier(concurrency, ref multiplier);
                    rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonHitMax;
                }

                IncreaseConcurrency(multiplier, ref concurrency);

                double desiredNewSpeed = CalculateDesiredSpeed(lastSpeed, multiplier);

                // action the increase and measure its effect
                lastReason = rateChangeReason;
                await SetConcurrencyAsync(
                    (int)concurrency,
                    rateChangeReason,
                    _cancellationToken).ConfigureAwait(false);

                ConcurrencyObservation currentObservation = await GetCurrentSpeedAsync(_cancellationToken).ConfigureAwait(false);

                // this doesn't stop us probing higher concurrency,
                // since sometimes that works even when CPU looks high,
                // but it does change the way we report the result
                everSawHighCpu = currentObservation.isHighCpu ? true : false;

                // decide what to do based on the measurement
                if (currentObservation.Mpbs > desiredNewSpeed || probeHigherRegardless)
                {
                    // Our concurrency change gave the hoped-for speed increase, so loop around and see if another increase will also work,
                    // unless already at max
                    if (atMax)
                    {
                        break;
                    }
                }
                else if (dontBackoffRegardless)
                {
                    // nothing more we can do
                    break;
                }
                else
                {
                    // the new speed didn't work, so we conclude it was too aggressive and back off to where we were before
                    concurrency /= multiplier;

                    // reduce multiplier to probe more slowly on the next iteration
                    if (multiplier > DataMovementConstants.ConcurrencyTuner.StandardMultiplier)
                    {
                        // just back off from our "boosted" multiplier
                        multiplier = DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
                    }
                    else
                    {
                        // back off to a much smaller multiplier
                        multiplier = 1 + (multiplier - 1) / DataMovementConstants.ConcurrencyTuner.SlowdownFactor;
                    }

                    // bump multiplier up until its at least enough to influence the connection count by 1
                    // (but, to make sure our algorithm terminates, limit how much we do this)
                    multiplierReductionCount++;

                    if (multiplierReductionCount <= 2)
                    {
                        while ((int)multiplier * concurrency == (int)concurrency)
                        {
                            multiplier += 0.05;
                        }
                    }

                    if (multiplier < DataMovementConstants.ConcurrencyTuner.MinMulitplier)
                    {
                        break; // no point in tuning any more
                    }
                    else
                    {
                        lastReason = ConcurrencyTunerState.ConcurrencyReasonBackoff;
                        await SetConcurrencyAsync(
                            (int)concurrency,
                            ConcurrencyTunerState.ConcurrencyReasonBackoff,
                            _cancellationToken).ConfigureAwait(false);
                        // must re-measure immediately after backing off
                        lastSpeed = await GetCurrentSpeedAsync(_cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            if (atMax)
            {
                // provide no special "we found the best value" result, because actually we possibly didn't find it, we just hit the max,
                // and we've already notified caller of that reason, when we tied using the max
            }
            else
            {
                // provide the final value once with a reason why its our final value
                if (everSawHighCpu)
                {
                    lastReason = ConcurrencyTunerState.ConcurrencyReasonHighCpu;
                    await SetConcurrencyAsync(
                        (int)concurrency,
                        ConcurrencyTunerState.ConcurrencyReasonHighCpu,
                        _cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    lastReason = ConcurrencyTunerState.ConcurrencyReasonAtOptimum;
                    await SetConcurrencyAsync(
                        (int)concurrency,
                        ConcurrencyTunerState.ConcurrencyReasonAtOptimum,
                        _cancellationToken).ConfigureAwait(false);
                }
                await GetCurrentSpeedAsync(_cancellationToken).ConfigureAwait(false); // read from the channel
            }

            StoreFinalState(
                new ConcurrencyRecommendation()
                {
                    State = lastReason,
                    Concurrency = (int)concurrency
                });

            //SignalStability();

            // now just provide an "inactive" value for ever
            while (!_cancellationToken.IsCancellationRequested)
            {
                await SetConcurrencyAsync(
                    (int)concurrency,
                    ConcurrencyTunerState.ConcurrencyReasonFinished,
                    _cancellationToken).ConfigureAwait(false);
                await GetCurrentSpeedAsync(_cancellationToken).ConfigureAwait(false); // read from the channel

                //SignalStability()        // in case anyone new has "subscribed"
            }
        }

        private void UpdateChunkProcessorConcurrency(int newMaxConcurrency)
        {
            var parallelProcessor = _chunkProcessor as object;
            if (parallelProcessor != null)
            {
                var methodInfo = parallelProcessor.GetType().GetMethod("UpdateMaxConcurrentProcessing", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(parallelProcessor, new object[] { newMaxConcurrency });
                }
                else
                {
                    throw new InvalidOperationException("The method UpdateMaxConcurrentProcessing was not found.");
                }
            }
            else
            {
                throw new InvalidOperationException("The chunks processor is not a ParallelChannelProcessor.");
            }
        }

        #region Worker helper methods
        private static double CalculateDesiredSpeed(ConcurrencyObservation lastSpeed, double multiplier)
        {
            // we'd like it to speed up linearly, but we'll accept a _lot_ less,
            // according to fudge factor in the interests of finding best possible speed
            double desiredSpeedIncrease = lastSpeed.Mpbs * (multiplier - 1) * DataMovementConstants.ConcurrencyTuner.FudgeFactor;
            return lastSpeed.Mpbs + desiredSpeedIncrease;
        }

        private static void IncreaseConcurrency(double multiplier, ref double concurrency)
        {
            concurrency *= multiplier;
        }

        private void DecreaseMultiplier(double concurrency, ref double multiplier)
        {
            multiplier = (float)(_maxConcurrency) / concurrency;
        }

        private bool IsAtMaxConcurrency(double multiplier, double concurrency)
        {
            // enforce a ceiling
            return (concurrency * multiplier) > (float)_maxConcurrency;
        }

        private static bool IsBoostedMultiplierNeeded(double multiplier, double concurrency)
        {
            return concurrency >= DataMovementConstants.ConcurrencyTuner.TopOfBoostZone
                                && multiplier > DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
        }
        #endregion
    }

    /// <summary>
    /// Representing the concurrency recommendation and the reason for the concurrency
    /// </summary>
    internal struct ConcurrencyRecommendation
    {
        public ConcurrencyTunerState State;
        public int Concurrency;
    }

    /// <summary>
    /// Representing a concurrency observation to make a better recomendation for what
    /// to set the concurrency to.
    /// </summary>
    internal struct ConcurrencyObservation
    {
        public int Mpbs;
        public bool isHighCpu;
    }
}
