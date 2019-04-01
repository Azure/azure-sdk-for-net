// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Base.Http.Pipeline
{
    public class ExponentialRetryPolicy : RetryPolicy
    {
        private readonly int[] _retriableCodes;

        private readonly Func<Exception, bool> _shouldRetryException;

        private readonly int _maxRetries;

        private readonly TimeSpan _delay;

        private readonly TimeSpan _maxDelay;

        private Random _random;

        public ExponentialRetryPolicy(int[] retriableCodes, Func<Exception, bool> shouldRetryException, int maxRetries, TimeSpan delay, TimeSpan maxDelay)
        {
            _random = new ThreadSafeRandom();
            _shouldRetryException = shouldRetryException;
            _maxRetries = maxRetries;
            _delay = delay;
            _maxDelay = maxDelay;

            _retriableCodes = retriableCodes.ToArray();
            Array.Sort(_retriableCodes);
        }

        protected override bool ShouldRetryResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);

            if (attempted > _maxRetries)
            {
                return false;
            }

            return Array.BinarySearch(_retriableCodes, message.Response.Status) >= 0;
        }

        protected override bool ShouldRetryException(Exception exception, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);

            if (attempted > _maxRetries)
            {
                return false;
            }

            return _shouldRetryException != null && _shouldRetryException(exception);
        }

        private TimeSpan CalculateDelay(int attempted)
        {
            return TimeSpan.FromMilliseconds(
                Math.Min(
                    (1 << (attempted - 1)) * _random.Next((int)(_delay.TotalMilliseconds * 0.8), (int)(_delay.TotalMilliseconds * 1.2)),
                    _maxDelay.TotalMilliseconds));
        }
    }
}