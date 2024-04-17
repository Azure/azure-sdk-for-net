﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    internal class DocumentMockWithStringDuration : DocumentIngress
    {
        internal DocumentMockWithStringDuration(string duration)
        {
            Duration = duration;
        }

        public string Duration { get; set; }
    }
}
