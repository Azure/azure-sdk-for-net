// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
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
        internal int _finalReason;
        internal int _finalConcurrency;
        internal SemaphoreSlim _lockFinal;
        internal IProcessor<ConcurrencyRecommendation> _concurrencyRecommendations;

        internal ThroughputMonitor ThroughputMonitor { get; }

        private IProcessor<Func<Task>> _chunkProcessor;

        public int MaxConcurrency
        {
            get => _maxConcurrency;
            private set
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
            _concurrencyRecommendations = ChannelProcessing.NewProcessor<ConcurrencyRecommendation>(readers: 1);
            ThroughputMonitor = throughputMonitor;

            // Passing no cancellation token. Leaving open possibility to pass token in the future
            StartConcurrencyTuner();
            _concurrencyRecommendations.Process = ProcessConcurrencyRecommendationsAsync;
        }

        private void StartConcurrencyTuner()
        {
            //_resourceMonitor.StartMonitoring(cancellationToken);
            Task.Run(() => Worker(CancellationToken.None));
        }

        private Task ProcessConcurrencyRecommendationsAsync(ConcurrencyRecommendation concurrencyRecommandation, CancellationToken cancellationToken)
        {
            _chunkProcessor.MaxConcurrentProcessing = concurrencyRecommandation.Concurrency;
            return Task.CompletedTask;
        }

        private async Task Worker(CancellationToken cancellationToken)
        {
            decimal multiplier = DataMovementConstants.ConcurrencyTuner.BoostedMultiplier;
            double concurrency = _initialConcurrency;
            bool atMax = false;
            bool everSawHighCpu = false;
            bool probeHigherRegardless = false;
            bool dontBackoffRegardless = false;
            int numOfReductions = 0;
            ConcurrencyTunerState lastReason = ConcurrencyTunerState.ConcurrencyReasonNone;

            var prevThroughput = ThroughputMonitor.Throughput;
            var currThroughput = 0.0M;

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

                decimal desiredNewThroughput = CalculateDesiredThroughput(prevThroughput, multiplier);

                lastReason = rateChangeReason;
                await SetConcurrencyAsync((int)concurrency, rateChangeReason, cancellationToken).ConfigureAwait(false);

                currThroughput = ThroughputMonitor.Throughput;

                if (
                    ( atMax && (currThroughput > desiredNewThroughput || probeHigherRegardless) ) ||
                    dontBackoffRegardless
                    )
                {
                    break;
                }
                else
                {
                    concurrency = (double)((decimal)concurrency / multiplier);

                    multiplier = AdjustMultiplier(multiplier);

                    numOfReductions++;
                    if (numOfReductions <= 2)
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
                        prevThroughput = currThroughput;
                    }
                }
            }

            if (!atMax)
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
                currThroughput = ThroughputMonitor.Throughput;
            }

            StoreFinalState(new ConcurrencyRecommendation()
            {
                State = lastReason,
                Concurrency = (int)concurrency
            });

            while (!cancellationToken.IsCancellationRequested)
            {
                await SetConcurrencyAsync((int)concurrency, ConcurrencyTunerState.ConcurrencyReasonFinished, cancellationToken).ConfigureAwait(false);
                currThroughput = ThroughputMonitor.Throughput;
            }
        }

        private static decimal AdjustMultiplier(decimal multiplier)
        {
            if (multiplier > DataMovementConstants.ConcurrencyTuner.StandardMultiplier)
            {
                multiplier = DataMovementConstants.ConcurrencyTuner.StandardMultiplier;
            }
            else
            {
                multiplier = 1 + (multiplier - 1) / DataMovementConstants.ConcurrencyTuner.SlowdownFactor;
            }

            return multiplier;
        }

        //private async Task ProcessConcurrencyRecommendationsAsync(ConcurrencyRecommendation concurrencyRecommendation, CancellationToken _)
        //{
        //    // We want to start the runner that is looking for concurrency recommendations
        //    await _concurrencyRecommendations.QueueAsync(concurrencyRecommendation, CancellationToken.None).ConfigureAwait(false);
        //}

        //private async Task<ConcurrencyRecommendation> GetRecommendedConcurrency()
        //{
        //    decimal throughput = ThroughputMonitor.Throughput;
        //    if (throughput == 0)
        //    {
        //        return new ConcurrencyRecommendation()
        //        {
        //            Concurrency = _initialConcurrency,
        //            State = ConcurrencyTunerState.ConcurrencyReasonInitial
        //        };
        //    }
        //    else
        //    {
        //        // push value into worker, and get its result
        //        await _thoughtputObservations.QueueAsync(new ThroughputObservation()
        //        {
        //            Throughput = throughput
        //        }).ConfigureAwait(false);
        //    }

        //    await _concurrencyRecommendations.Process
        //}

        internal async Task SetConcurrencyAsync(int concurrency, ConcurrencyTunerState state, CancellationToken cancellationToken)
        {
            await _concurrencyRecommendations.QueueAsync(new ConcurrencyRecommendation()
            {
                State = state,
                Concurrency = concurrency
            }, cancellationToken).ConfigureAwait(false);
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

        //private void UpdateChunkProcessorConcurrency(int newMaxConcurrency)
        //{
        //    _chunkProcessor.MaxConcurrentProcessing = newMaxConcurrency;
        ////    var parallelProcessor = _chunkProcessor as object;
        ////    if (parallelProcessor != null)
        ////    {
        ////        var methodInfo = parallelProcessor.GetType().GetMethod("UpdateMaxConcurrentProcessing", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        ////        if (methodInfo != null)
        ////        {
        ////            methodInfo.Invoke(parallelProcessor, new object[] { newMaxConcurrency });
        ////        }
        ////        else
        ////        {
        ////            throw new InvalidOperationException("The method UpdateMaxConcurrentProcessing was not found.");
        ////        }
        ////    }
        ////    else
        ////    {
        ////        throw new InvalidOperationException("The chunks processor is not a ParallelChannelProcessor.");
        ////    }
        //}

        #region
        private static decimal CalculateDesiredThroughput(decimal lastThroughput, decimal multiplier)
        {
            decimal desiredSpeedIncrease = lastThroughput * (multiplier - 1) * (decimal)DataMovementConstants.ConcurrencyTuner.FudgeFactor;
            return lastThroughput + desiredSpeedIncrease;
        }

        private static void IncreaseConcurrency(decimal multiplier, ref double concurrency)
        {
            concurrency = (double)((decimal)concurrency *multiplier);
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
    #endregion
}
