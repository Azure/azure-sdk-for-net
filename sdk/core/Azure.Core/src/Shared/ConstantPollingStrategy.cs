// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a constant polling interval strategy. Polling interval is always equal to the default polling interval.
    /// </summary>
    internal class ConstantPollingStrategy : IOperationPollingStrategy
    {
        public TimeSpan PollingInterval { get;  }

        public ConstantPollingStrategy() : this(TimeSpan.FromSeconds(1)) { }

        public ConstantPollingStrategy(TimeSpan interval)
        {
            PollingInterval = interval;
        }
    }
}
