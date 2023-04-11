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

        protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
        {
            CallCount++;
            return TimeSpan.Zero;
        }
    }
}
