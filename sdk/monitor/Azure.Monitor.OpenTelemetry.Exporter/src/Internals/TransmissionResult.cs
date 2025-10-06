// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Represents the unified result of attempting to transmit telemetry (exporter or from storage).
    /// </summary>
    internal struct TransmissionResult
    {
        internal ExportResult ExportResult { get; set; }

        internal bool WillRetry { get; set; }

        internal bool SavedToStorage { get; set; }

        internal bool DeletedBlob { get; set; }

        internal int StatusCode { get; set; }

        internal int? ItemsAccepted { get; set; }
    }
}
