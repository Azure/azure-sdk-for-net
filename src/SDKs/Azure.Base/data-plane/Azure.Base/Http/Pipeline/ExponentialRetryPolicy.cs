// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Base.Http.Pipeline
{
    internal class ExponentialRetryPolicy : RetryPolicy
    {
        private readonly int[] _retriableCodes;

        private readonly Func<Exception, bool> _exceptionFilter;

        private readonly int _maxRetries;

        private readonly TimeSpan _delay;

        private readonly TimeSpan _maxDelay;

        private Random _random;

        public ExponentialRetryPolicy(int[] retriableCodes, Func<Exception, bool> exceptionFilter, int maxRetries, TimeSpan delay, TimeSpan maxDelay)
        {
            _random = new ThreadSafeRandom();
            _exceptionFilter = exceptionFilter;
            _maxRetries = maxRetries;
            _delay = delay;
            _maxDelay = maxDelay;

            _retriableCodes = retriableCodes.ToArray();
            Array.Sort(_retriableCodes);
        }

        protected override bool ShouldRetry(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = TimeSpan.FromMilliseconds(
                Math.Min(
                    (1 << (attempted - 1)) * _random.Next((int)(_delay.TotalMilliseconds * 0.8), (int)(_delay.TotalMilliseconds * 1.2)),
                    _maxDelay.TotalMilliseconds));

            if (attempted > _maxRetries)
            {
                return false;
            }

            if (exception != null)
            {
                return _exceptionFilter != null && _exceptionFilter(exception);
            }

            if (Array.BinarySearch(_retriableCodes, message.Response.Status) < 0)
            {
                return false;
            }

            return true;
        }
    }
}