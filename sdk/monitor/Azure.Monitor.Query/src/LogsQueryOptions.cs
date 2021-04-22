// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.Query
{
    public class LogsQueryOptions
    {
        public TimeSpan? Timeout { get; }
        public bool IncludeStatistics { get; }
    }
}