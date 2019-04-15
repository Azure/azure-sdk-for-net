﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Core.Pipeline.Policies
{
    public class ExponentialRetryPolicy : RetryPolicy
    {
        private readonly Random _random = new ThreadSafeRandom();

        /// <summary>
        /// Gets or sets the list of response status codes to retry.
        /// </summary>
        public int[] RetriableCodes { get; set; } = Array.Empty<int>();

        /// <summary>
        /// Gets or sets the delegate to specify is exception should be retried.
        /// </summary>
        public Func<Exception, bool> ShouldRetryException { get; set; } = _ => false;

        /// <summary>
        /// Gets or sets the maximum number of retry attempts before giving up.
        /// </summary>
        public int MaxRetries { get; set; } = 10;

        /// <summary>
        /// Gets or sets the timespan used as a base for exponential backoff.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets or sets maximum timespan to pause between requests.
        /// </summary>
        public TimeSpan MaxDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   Creates a retry policy with exponential backoff for use with external operations.
        /// </summary>
        public ExponentialRetryPolicy()
        {
        }

        protected override bool IsRetriableResponse(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);

            if (attempted > MaxRetries)
            {
                return false;
            }

            return Array.IndexOf(RetriableCodes, message.Response.Status) >= 0;
        }

        protected override bool IsRetriableException(Exception exception, int attempted, out TimeSpan delay)
        {
            delay = CalculateDelay(attempted);

            if (attempted > MaxRetries)
            {
                return false;
            }

            return ShouldRetryException != null && ShouldRetryException(exception);
        }

        private TimeSpan CalculateDelay(int attempted)
        {
            return TimeSpan.FromMilliseconds(
                Math.Min(
                    (1 << (attempted - 1)) * _random.Next((int)(Delay.TotalMilliseconds * 0.8), (int)(Delay.TotalMilliseconds * 1.2)),
                    MaxDelay.TotalMilliseconds));
        }
    }
}
