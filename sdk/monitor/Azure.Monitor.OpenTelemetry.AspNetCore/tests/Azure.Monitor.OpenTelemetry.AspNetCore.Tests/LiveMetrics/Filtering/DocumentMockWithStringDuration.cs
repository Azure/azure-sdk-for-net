// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.LiveMetrics.Filtering
{
    using Azure.Monitor.OpenTelemetry.AspNetCore.Models;

    internal class DocumentMockWithStringDuration : DocumentIngress
    {
        internal DocumentMockWithStringDuration(string duration)
        {
            Duration = duration;
        }

        public string Duration { get; set; }
    }
}
