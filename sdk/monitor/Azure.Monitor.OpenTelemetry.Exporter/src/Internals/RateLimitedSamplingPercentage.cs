// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class RateLimitedSamplingPercentage
    {
        private class State
        {
            public readonly double EffectiveWindowCount;
            public readonly double EffectiveWindowNanos;
            public readonly long LastNanoTime;

            public State(double effectiveWindowCount, double effectiveWindowNanos, long lastNanoTime)
            {
                EffectiveWindowCount = effectiveWindowCount;
                EffectiveWindowNanos = effectiveWindowNanos;
                LastNanoTime = lastNanoTime;
            }
        }

        private readonly double _inverseAdaptationTimeNanos;
        private readonly double _targetTracesPerNanosecondLimit;
        private State _state;
        private const double AdaptationTimeSeconds = 0.1;
        private static readonly double NanoTimeFactor = 1_000_000_000.0 / Stopwatch.Frequency;

        public RateLimitedSamplingPercentage(double targetTracesPerSecondLimit)
        {
            if (targetTracesPerSecondLimit < 0.0)
                throw new ArgumentOutOfRangeException(nameof(targetTracesPerSecondLimit), "Limit for sampled Traces per second must be nonnegative!");
            _inverseAdaptationTimeNanos = 1e-9 / AdaptationTimeSeconds;
            _targetTracesPerNanosecondLimit = 1e-9 * targetTracesPerSecondLimit;
            _state = new State(0, 0, GetNanoTime());
        }

        private State UpdateState(State oldState, long currentNanoTime)
        {
            if (currentNanoTime <= oldState.LastNanoTime)
            {
                return new State(
                    oldState.EffectiveWindowCount + 1,
                    oldState.EffectiveWindowNanos,
                    oldState.LastNanoTime);
            }
            long nanoTimeDelta = currentNanoTime - oldState.LastNanoTime;
            double decayFactor = Math.Exp(-nanoTimeDelta * _inverseAdaptationTimeNanos);
            double currentEffectiveWindowCount = oldState.EffectiveWindowCount * decayFactor + 1;
            double currentEffectiveWindowNanos = oldState.EffectiveWindowNanos * decayFactor + nanoTimeDelta;
            return new State(currentEffectiveWindowCount, currentEffectiveWindowNanos, currentNanoTime);
        }

        public double Get()
        {
            long currentNanoTime = GetNanoTime();

            // trying to replicate the atomic update behavior of Java's AtomicReference
            // using Interlocked.CompareExchange to ensure thread safety
            State originalState, newState;
            do
            {
                originalState = _state;
                newState = UpdateState(originalState, currentNanoTime);
                // Try to atomically update _state to newState, only if it is still originalState
            } while (Interlocked.CompareExchange(ref _state, newState, originalState) != originalState);
            State currentState = newState;

            double samplingProbability =
                (currentState.EffectiveWindowNanos * _targetTracesPerNanosecondLimit)
                / currentState.EffectiveWindowCount;

            double samplingPercentage = 100 * Math.Min(samplingProbability, 1);

            samplingPercentage = RoundDownToNearest(samplingPercentage);

            return samplingPercentage;
        }

        private static double RoundDownToNearest(double samplingPercentage)
        {
            if (samplingPercentage == 0)
                return 0;
            double itemCount = 100 / samplingPercentage;
            return 100.0 / Math.Ceiling(itemCount);
        }

        private static long GetNanoTime()
        {
            // .NET does not have System.nanoTime, so use Stopwatch for high-res time
            // This is not absolute time, but is monotonic and suitable for deltas
            return (long)(Stopwatch.GetTimestamp() * NanoTimeFactor);
        }
    }
}