// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    internal interface IDelayStrategy
    {
        TimeSpan GetNextDelay(bool executionSucceeded);
    }
}
