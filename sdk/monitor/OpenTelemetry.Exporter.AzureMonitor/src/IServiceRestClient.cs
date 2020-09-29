// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// This interface provides access to the TrackAsync method for Moq to override in our tests.
    /// The actual <see cref="ApplicationInsightsRestClient.TrackAsync(IEnumerable{TelemetryItem}, CancellationToken)"/> method is non-virtual and cannot be overridden.
    /// </summary>
    internal interface IServiceRestClient
    {
        public Task<Azure.Response<TrackResponse>> TrackAsync(IEnumerable<TelemetryItem> body, CancellationToken cancellationToken = default);
    }
}
