// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    internal interface IDelayStrategy
    {
        TimeSpan GetNextDelay(bool executionSucceeded);
    }
}
