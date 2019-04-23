// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Core.Pipeline.Policies
{
    public class FixedRetryPolicy : RetryPolicy
    {
        /// <summary>
        /// Gets or sets the timespan to wait before retries.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(1);

        protected override void GetDelay(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = Delay;
        }

        protected override void GetDelay(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = Delay;
        } 
    }
}
