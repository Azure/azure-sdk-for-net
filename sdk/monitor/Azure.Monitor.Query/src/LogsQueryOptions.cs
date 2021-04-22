// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.Query
{
    public class LogsQueryOptions
    {
        public TimeSpan? Timeout { get; set; }
        public bool IncludeStatistics { get; set; }
    }
}