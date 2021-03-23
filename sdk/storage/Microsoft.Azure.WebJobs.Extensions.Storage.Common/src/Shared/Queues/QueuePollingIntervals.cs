// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal static class QueuePollingIntervals
    {
        public static readonly TimeSpan Minimum = TimeSpan.FromMilliseconds(100);
        public static readonly TimeSpan DefaultMaximum = TimeSpan.FromMinutes(1);
    }
}
