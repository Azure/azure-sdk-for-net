// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal static class QueuePollingIntervals
    {
        public static readonly TimeSpan Minimum = TimeSpan.FromMilliseconds(100);
        public static readonly TimeSpan DefaultMaximum = TimeSpan.FromMinutes(1);
    }
}
