// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Models
{
    /// <summary> Additional properties used to calculate metrics. </summary>
    internal partial class DocumentIngress
    {
        public bool Extension_IsSuccess { get; set; }
        public double Extension_Duration { get; set; }
    }
}
