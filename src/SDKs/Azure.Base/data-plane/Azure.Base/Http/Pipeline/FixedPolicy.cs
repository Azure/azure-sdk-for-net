﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Http.Pipeline
{
    class FixedPolicy : RetryPolicy {
        int _maxRetries;
        TimeSpan _delay;
        int[] _retriableCodes;

        public FixedPolicy(int[] retriableCodes, int maxRetries, TimeSpan delay)
        {
            if (retriableCodes == null) throw new ArgumentNullException(nameof(retriableCodes));

            _maxRetries = maxRetries;
            _delay = delay;
            _retriableCodes = retriableCodes;
            Array.Sort(_retriableCodes);
        }

        protected override bool ShouldRetry(HttpPipelineMessage message, int attempted, out TimeSpan delay)
        {
            delay = _delay;
            if (attempted > _maxRetries) return false;
            if(Array.BinarySearch(_retriableCodes, message.Response.Status) < 0) return false;
            return true;
        }
    }
}
