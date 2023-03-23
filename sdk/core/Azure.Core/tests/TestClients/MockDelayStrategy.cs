// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core.Tests.TestClients
{
    internal class MockDelayStrategy : DelayStrategy
    {
        public int CallCount { get; private set; }

        protected override TimeSpan GetNextDelayCore(Response response, int retryNumber, IDictionary<string, object> context)
        {
            CallCount++;
            return TimeSpan.Zero;
        }

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response response, int retryNumber, IDictionary<string, object> context)
        {
            CallCount++;
            return new(TimeSpan.Zero);
        }
    }
}
