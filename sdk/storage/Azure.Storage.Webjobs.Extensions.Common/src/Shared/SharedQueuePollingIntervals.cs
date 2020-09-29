// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    // TODO (kasobol-msft) This duplicates QueuePollingIntervals, find way to share.
    internal static class SharedQueuePollingIntervals
    {
        public static readonly TimeSpan Minimum = TimeSpan.FromMilliseconds(100);
        public static readonly TimeSpan DefaultMaximum = TimeSpan.FromMinutes(1);
    }
}
