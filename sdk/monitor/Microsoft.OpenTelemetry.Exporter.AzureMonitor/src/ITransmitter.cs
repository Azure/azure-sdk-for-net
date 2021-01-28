// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal interface ITransmitter
    {
        /// <summary>
        /// Sent telemetry and return the number of items Accepted.
        /// </summary>
        ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken);
    }
}
