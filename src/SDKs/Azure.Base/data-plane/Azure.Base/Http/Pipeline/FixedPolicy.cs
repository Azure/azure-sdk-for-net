// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Base.Http.Pipeline
{
    internal class FixedPolicy : RetryPolicy
    {
        private readonly int _maxRetries;

        private readonly TimeSpan _delay;

        private readonly int[] _retriableCodes;

        public FixedPolicy(int[] retriableCodes, int maxRetries, TimeSpan delay)
        {
            if (retriableCodes == null)
            {
                throw new ArgumentNullException(nameof(retriableCodes));
            }

            _maxRetries = maxRetries;
            _delay = delay;

            _retriableCodes = retriableCodes.ToArray();
            Array.Sort(_retriableCodes);
        }

        protected override bool ShouldRetry(HttpPipelineMessage message, Exception exception, int attempted, out TimeSpan delay)
        {
            delay = _delay;

            if (attempted > _maxRetries)
            {
                return false;
            }

            if (exception != null)
            {
                return true;
            }

            return Array.BinarySearch(_retriableCodes, message.Response.Status) >= 0;
        }
    }
}
