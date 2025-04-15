// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.Versioning;
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
    public class ConcurrencyTuner
    {
        internal static ResourceMonitor _resourceMonitor;
        internal static int _concurrencyRecommendationCount;
        internal static int _concurrencyRecommendationSum;
        private int _concurrencyUpperLimit = DataMovementConstants.ConcurrencyTuner.ConcurrencyUpperLimit;
        internal int _finalReason;
        internal int _finalConcurrency;
        internal IProcessor<ConcurrencyRecommendation> _concurrencyRecommendations;
        private double _maxConcurrency;

        /// <summary>
        /// Thoughtput monitor returns throughput in Bytes per measure
        /// </summary>
        public ThroughputMonitor ThroughputMonitor { get; }

        private IProcessor<Func<Task>> _chunkProcessor;

        /// <summary>
        /// Gets the maximum concurrency level.
        /// </summary>
        public int MaxConcurrency
        {
            get => (int)_maxConcurrency;
            private set
            {
                _maxConcurrency = value;
                _chunkProcessor.MaxConcurrentProcessing = value;
            }
        }

        internal ConcurrencyTuner(
            ThroughputMonitor throughputMonitor,
            IProcessor<Func<Task>> chunkProcessor
            )
        {
            _chunkProcessor = chunkProcessor;
            _finalReason = (int)ConcurrencyTunerState.ConcurrencyReasonNone;
            _concurrencyRecommendations = ChannelProcessing.NewProcessor<ConcurrencyRecommendation>(readers: 1);
            ThroughputMonitor = throughputMonitor;
            MaxConcurrency = DataMovementConstants.ConcurrencyTuner.ConcurrencyUpperLimit;

            // Passing no cancellation token. Leaving open possibility to pass token in the future
            _concurrencyRecommendations.Process = ProcessConcurrencyRecommendationsAsync;
        }

        internal void StartConcurrencyTuner()
        {
            //_resourceMonitor.StartMonitoring(cancellationToken);
            Task.Run(() => Worker(CancellationToken.None));
        }

        private Task ProcessConcurrencyRecommendationsAsync(ConcurrencyRecommendation concurrencyRecommandation, CancellationToken cancellationToken)
        {
            if (concurrencyRecommandation.Concurrency == 0)
                return Task.CompletedTask;
            //_concurrencyRecommendationCount++;
            //_concurrencyRecommendationSum += concurrencyRecommandation.Concurrency;

            //MaxConcurrency = _concurrencyRecommendationSum / _concurrencyRecommendationCount;
            MaxConcurrency = concurrencyRecommandation.Concurrency;
            return Task.CompletedTask;
        }

        private async Task Worker(CancellationToken cancellationToken)
        {
            decimal multiplier = DataMovementConstants.ConcurrencyTuner.BoostedMultiplier;
            bool atMax = false;
            double currentConcurrency = 1;
            ConcurrencyTunerState rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonInitial;
            decimal desiredNewThroughput = 0;
            bool isThoughputIncreasing = false;

            decimal prevThroughput = 0;
            decimal currThroughput = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                // Creating a delay here so to give the recommendations time to get processed

                await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                currThroughput = ThroughputMonitor.Throughput;
                atMax = IsAtMaxConcurrency(currentConcurrency, multiplier);
                isThoughputIncreasing = prevThroughput < currThroughput;

                if (atMax)
                {
                    rateChangeReason = ConcurrencyTunerState.ConcurrencyReasonHitMax;
                    await SetConcurrencyAsync((int)currentConcurrency, rateChangeReason, cancellationToken).ConfigureAwait(false);
                    break;
                }
                // if the current throughput is less than the desired throughput,
                // if throughput in increasing
                // do nothing
                // else
                // increase mulitiplier
                // else - current throughput is greater than desired throughput
                // do nothing

                if (currThroughput <= desiredNewThroughput)
                {
                    if (isThoughputIncreasing)
                    {
                        // Do  nothing
                    }
                    else
                    {
                        currentConcurrency--;
                    }
                }
                else
                {
                    currentConcurrency += 4;
                }

                //AdjustConcurrency(multiplier, ref currentConcurrency);
                await SetConcurrencyAsync((int)currentConcurrency, rateChangeReason, cancellationToken).ConfigureAwait(false);

                desiredNewThroughput = CalculateDesiredThroughput(prevThroughput);
                prevThroughput = currThroughput;
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
private static decimal CalculateDesiredThroughput(decimal lastThroughput)
{
    lastThroughput = Math.Max(lastThroughput, 1);
    decimal desiredSpeedIncrease = lastThroughput * 0.1M;
    return lastThroughput + desiredSpeedIncrease;
}

private static void AdjustConcurrency(decimal multiplier, ref double concurrency)
{
    concurrency = (double)Math.Ceiling((decimal)concurrency * multiplier);
}

/// <summary>
/// Decreases the multiplier based on the current concurrency.
/// Math.Max(_max
/// </summary>
/// <param name="concurrency">The current concurrency level.</param>
/// <param name="multiplier">The multiplier to be adjusted.</param>
private void DecreaseMultiplier(double concurrency, ref decimal multiplier)
{
            multiplier++;
}

private void IncreaseMultiplier(double concurrency, ref decimal multiplier)
{
            multiplier--;
}

/// <summary>
/// Determines if the current concurrency has reached the maximum allowed concurrency.
/// </summary>
/// <param name="concurrency">The current concurrency level.</param>
/// <param name="multiplier">The current multiplier</param>
/// <returns>True if the current concurrency has reached or exceeded the maximum allowed concurrency; otherwise, false.</returns>
/// <remarks>
/// The method checks if the product of <paramref name="concurrency"/> exceeds the maximum allowed concurrency, which is <see cref="_maxConcurrency"/>.
/// </remarks>
private bool IsAtMaxConcurrency(double concurrency, decimal multiplier)
{
    return Convert.ToInt32((decimal)concurrency * multiplier) >= _concurrencyUpperLimit;
}

        /// <summary>
        /// Determines if a boosted multiplier is needed based on the concurrency and multiplier.
        /// </summary>
        /// <param name="multiplier">The current multiplier.</param>
        /// <param name="concurrency">The current concurrency.</param>
        /// <returns>True if a boosted multiplier is needed; otherwise, false.</returns>
        /// <remarks>
        /// The method checks if the concurrency is greater than or equal to <see cref="DataMovementConstants.ConcurrencyTuner.TopOfBoostZone"/> (256)
        /// and if the multiplier is greater than <see cref="DataMovementConstants.ConcurrencyTuner.StandardMultiplier"/> (2).
        /// </remarks>
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
