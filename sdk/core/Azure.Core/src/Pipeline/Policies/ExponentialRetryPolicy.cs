// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Core.Pipeline.Policies
{
    public class ExponentialRetryPolicy : RetryPolicy
    {
        private readonly Random _random = new ThreadSafeRandom();

        private readonly TimeSpan _maxDelay;

        private readonly TimeSpan _delay;

        /// <summary>
        ///   Creates a retry policy with exponential backoff for use with external operations.
        /// </summary>
        public ExponentialRetryPolicy(ExponentialRetryOptions options) : base(options.MaxRetries)
        {
            _delay = options.Delay;
            _maxDelay = options.MaxDelay;
        }

        protected override void GetDelay(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);
            TimeSpan serverDelay = GetServerDelay(message);
            if (serverDelay > delay)
            {
                delay = serverDelay;
            }
        }

        protected override void GetDelay(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);
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
