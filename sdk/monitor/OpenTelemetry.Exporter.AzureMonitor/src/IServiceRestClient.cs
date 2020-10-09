// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure;

using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// TODO: THIS INTERFACE WON'T BE NECESSARY IF THE METHOD WAS VIRTUAL.
    /// </summary>
    internal interface IServiceRestClient
    {
        Task<Response<TrackResponse>> InternalTrackAsync(IEnumerable<TelemetryItem> body, CancellationToken cancellationToken = default);
    }
}
