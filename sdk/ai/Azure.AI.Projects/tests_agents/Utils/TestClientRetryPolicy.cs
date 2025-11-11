// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Tests
{
    internal class TestClientRetryPolicy : ClientRetryPolicy
    {
        private readonly TimeSpan _delay;

        public TestClientRetryPolicy() : this(TimeSpan.FromMilliseconds(10))
        {
        }

        public TestClientRetryPolicy(TimeSpan delay) : base(maxRetries: 3)
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
        {
            return _delay; // Configurable delay for tests
        }
    }
}
