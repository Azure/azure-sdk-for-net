// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Models
{
    /// <summary> Represents the collection configuration - a customizable description of performance counters, metrics, and full telemetry documents to be collected by the client SDK. </summary>
    internal partial class CollectionConfigurationInfo
    {
        public CollectionConfigurationInfo()
        {
            ETag = default;
            Metrics = new List<DerivedMetricInfo>();
            DocumentStreams = new List<DocumentStreamInfo>();
        }
    }
}
