// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Core.Pipeline.Policies
{
    public class FixedRetryPolicy : RetryPolicy
    {
        private readonly TimeSpan _delay;

        public FixedRetryPolicy(FixedRetryOptions fixedRetryOptions) : base(fixedRetryOptions)
        {
            _delay = fixedRetryOptions.Delay;
        }

        protected override void GetDelay(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = _delay;

            TimeSpan serverDelay = GetServerDelay(message);
            if (serverDelay > delay)
            {
                delay = serverDelay;
            }
        }

        protected override void GetDelay(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = _delay;
        }
    }
}
