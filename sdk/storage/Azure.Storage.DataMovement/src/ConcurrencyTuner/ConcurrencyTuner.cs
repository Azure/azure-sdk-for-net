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
        private ThroughputMonitor _throughputMonitor;

        internal ThroughputMonitor ThroughputMonitor { get => _throughputMonitor; }

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
            ThroughputMonitor throughputMonitor,
            IProcessor<Func<Task>> chunkProcessor,
            TimeSpan monitoringInterval,
            double maxMemoryUsage,
            int initialConcurrency,
            int maxConcurrency,
            float maxCpuUsage)
        {
            _chunkProcessor = chunkProcessor;
            _initialConcurrency = initialConcurrency;
            _maxConcurrency = maxConcurrency;
            _maxMemoryUsage = maxMemoryUsage;
            _maxCpuUsage = maxCpuUsage;
            _finalReason = (int)ConcurrencyTunerState.ConcurrencyReasonNone;
            _finalConcurrency = _initialConcurrency;
            _observations = Channel.CreateUnbounded<ConcurrencyObservation>();
            _recommendations = Channel.CreateUnbounded<ConcurrencyRecommendation>();
            _throughputMonitor = throughputMonitor;
        }

        internal async Task<ConcurrencyRecommendation> GetRecommendedConcurrency()
        {
            decimal throughput = ThroughputMonitor.Throughput;
            if (throughput == 0)
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
                    Throughput = throughput
                }).ConfigureAwait(false);
            }

            return await _recommendations.Reader.ReadAsync().ConfigureAwait(false);
        }

        internal async Task SetConcurrencyAsync(int concurrency, ConcurrencyTunerState state, CancellationToken cancellationToken)
        {
            await _recommendations.Writer.WriteAsync(new ConcurrencyRecommendation()
            {
                State = state,
                Concurrency = concurrency
            }, cancellationToken).ConfigureAwait(false);
            UpdateChunkProcessorConcurrency(concurrency);
        }

        internal async Task<ConcurrencyObservation> GetCurrentSpeedAsync(CancellationToken cancellationToken)
        {
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
            Task.Run(() => Worker(cancellationToken)).Start();
        }

        internal async Task Worker(CancellationToken cancellationToken)
        {
            decimal multiplier = DataMovementConstants.ConcurrencyTuner.BoostedMultiplier;
            double concurrency = _initialConcurrency;
            bool atMax = false;
            bool everSawHighCpu = false;
            bool probeHigherRegardless = false;
            bool dontBackoffRegardless = false;
            int multiplierReductionCount = 0;
            ConcurrencyTunerState lastReason = ConcurrencyTunerState.ConcurrencyReasonNone;

            ConcurrencyObservation lastSpeed = await GetCurrentSpeedAsync(cancellationToken).ConfigureAwait(false);

            while (!cancellationToken.IsCancellationRequested)
            {
                ConcurrencyTunerState rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonSeeking;

                if (IsBoostedMultiplierNeeded(multiplier, concurrency))
                {
                    multiplier = DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
                }
                atMax = IsAtMaxConcurrency(multiplier, concurrency);

                if (atMax)
                {
                    DecreaseMultiplier(concurrency, ref multiplier);
                    rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonHitMax;
                }

                IncreaseConcurrency(multiplier, ref concurrency);

                decimal desiredNewSpeed = CalculateDesiredSpeed(lastSpeed, multiplier);

                lastReason = rateChangeReason;
                await SetConcurrencyAsync((int)concurrency, rateChangeReason, cancellationToken).ConfigureAwait(false);

                ConcurrencyObservation currentObservation = await GetCurrentSpeedAsync(cancellationToken).ConfigureAwait(false);

                if (currentObservation.Throughput > desiredNewSpeed || probeHigherRegardless)
                {
                    if (atMax)
                    {
                        break;
                    }
                }
                else if (dontBackoffRegardless)
                {
                    break;
                }
                else
                {
                    concurrency /= multiplier;

                    if (multiplier > DataMovementConstants.ConcurrencyTuner.StandardMultiplier)
                    {
                        multiplier = DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
                    }
                    else
                    {
                        multiplier = 1 + (multiplier - 1) / DataMovementConstants.ConcurrencyTuner.SlowdownFactor;
                    }

                    multiplierReductionCount++;
                    if (multiplierReductionCount <= 2)
                    {
                        while ((int)multiplier * concurrency == (int)concurrency)
                        {
                            multiplier += 0.05M;
                        }
                    }

                    if (multiplier < (decimal)DataMovementConstants.ConcurrencyTuner.MinMulitplier)
                    {
                        break;
                    }
                    else
                    {
                        lastReason = ConcurrencyTunerState.ConcurrencyReasonBackoff;
                        await SetConcurrencyAsync((int)concurrency, ConcurrencyTunerState.ConcurrencyReasonBackoff, cancellationToken).ConfigureAwait(false);
                        lastSpeed = await GetCurrentSpeedAsync(cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            if (atMax)
            {
            }
            else
            {
                if (everSawHighCpu)
                {
                    lastReason = ConcurrencyTunerState.ConcurrencyReasonHighCpu;
                    await SetConcurrencyAsync((int)concurrency, ConcurrencyTunerState.ConcurrencyReasonHighCpu, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    lastReason = ConcurrencyTunerState.ConcurrencyReasonAtOptimum;
                    await SetConcurrencyAsync((int)concurrency, ConcurrencyTunerState.ConcurrencyReasonAtOptimum, cancellationToken).ConfigureAwait(false);
                }
                await GetCurrentSpeedAsync(cancellationToken).ConfigureAwait(false);
            }

            StoreFinalState(new ConcurrencyRecommendation()
            {
                State = lastReason,
                Concurrency = (int)concurrency
            });

            while (!cancellationToken.IsCancellationRequested)
            {
                await SetConcurrencyAsync((int)concurrency, ConcurrencyTunerState.ConcurrencyReasonFinished, cancellationToken).ConfigureAwait(false);
                await GetCurrentSpeedAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        private void UpdateChunkProcessorConcurrency(int newMaxConcurrency)
        {
            _chunkProcessor.MaxConcurrentProcessing = newMaxConcurrency;
        //    var parallelProcessor = _chunkProcessor as object;
        //    if (parallelProcessor != null)
        //    {
        //        var methodInfo = parallelProcessor.GetType().GetMethod("UpdateMaxConcurrentProcessing", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        //        if (methodInfo != null)
        //        {
        //            methodInfo.Invoke(parallelProcessor, new object[] { newMaxConcurrency });
        //        }
        //        else
        //        {
        //            throw new InvalidOperationException("The method UpdateMaxConcurrentProcessing was not found.");
        //        }
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("The chunks processor is not a ParallelChannelProcessor.");
        //    }
        }

        #region
        private static decimal CalculateDesiredSpeed(ConcurrencyObservation lastSpeed, decimal multiplier)
        {
            decimal desiredSpeedIncrease = lastSpeed.Throughput * (multiplier - 1) * (decimal)DataMovementConstants.ConcurrencyTuner.FudgeFactor;
            return lastSpeed.Throughput + desiredSpeedIncrease;
        }

        private static void IncreaseConcurrency(double multiplier, ref double concurrency)
        {
            concurrency *= multiplier;
        }

        private void DecreaseMultiplier(double concurrency, ref decimal multiplier)
        {
            multiplier = (decimal)(_maxConcurrency / concurrency);
        }

        private bool IsAtMaxConcurrency(decimal multiplier, double concurrency)
        {
            return (concurrency * (double)multiplier) > _maxConcurrency;
        }

        private static bool IsBoostedMultiplierNeeded(decimal multiplier, double concurrency)
        {
            return concurrency >= DataMovementConstants.ConcurrencyTuner.TopOfBoostZone
                                && multiplier > DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
        }
        #endregion
    }
#region structs
    internal struct ConcurrencyRecommendation
    {
        public ConcurrencyTunerState State;
        public int Concurrency;
    }

    internal struct ConcurrencyObservation
    {
        public decimal Throughput;
    }
    #endregion
}
