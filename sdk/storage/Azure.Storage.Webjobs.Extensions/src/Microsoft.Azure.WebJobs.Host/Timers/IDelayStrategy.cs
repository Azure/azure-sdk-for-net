// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    internal interface IDelayStrategy
    {
        TimeSpan GetNextDelay(bool executionSucceeded);
    }
}
