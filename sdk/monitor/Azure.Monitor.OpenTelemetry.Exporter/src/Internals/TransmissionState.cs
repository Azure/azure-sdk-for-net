// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal enum TransmissionState
    {
        /// <summary>
        /// Represents disabled transmission.
        /// </summary>
        Open,

        /// <summary>
        /// Represents enabled transmission.
        /// </summary>
        Closed
    }
}
