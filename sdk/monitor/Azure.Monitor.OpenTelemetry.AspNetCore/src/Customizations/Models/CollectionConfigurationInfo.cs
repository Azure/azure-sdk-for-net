// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Models
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
