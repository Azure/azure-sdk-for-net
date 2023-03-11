// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Tests.TestClients
{
    internal class MockDelayStrategy : DelayStrategy
    {
        public int CallCount { get; private set; }

        public override TimeSpan GetNextDelay(Response response, int attempt, TimeSpan? clientDelayHint, TimeSpan? serverDelayHint)
        {
            CallCount++;
            return TimeSpan.Zero;
        }
    }
}
