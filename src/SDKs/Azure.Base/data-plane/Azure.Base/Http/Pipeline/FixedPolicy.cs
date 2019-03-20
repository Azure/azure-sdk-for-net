// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Http.Pipeline
{
    public class FixedPolicy : RetryPolicy {
        private readonly int[] _retriableCodes;
        private readonly int _maxRetries;
        private readonly TimeSpan _delay;

        public FixedPolicy(HttpPipelinePolicy next, int maxRetries, TimeSpan delay, params int[] retriableCodes): base(next)
        {
            _retriableCodes = retriableCodes;
            Array.Sort(_retriableCodes);
            _maxRetries = maxRetries;
            _delay = delay;
        }

        protected override bool ShouldRetry(HttpMessage message, int attempted, out TimeSpan delay)
        {
            delay = _delay;
            if (attempted > _maxRetries) return false;
            if(Array.BinarySearch(_retriableCodes, message.Response.Status) < 0) return false;
            return true;
        }
    }
}
