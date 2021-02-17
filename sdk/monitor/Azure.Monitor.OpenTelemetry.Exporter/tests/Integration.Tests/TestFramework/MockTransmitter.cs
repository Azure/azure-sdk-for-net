// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    internal class MockTransmitter : ITransmitter
    {
        public ConcurrentBag<TelemetryItem> TelemetryItems = new ConcurrentBag<TelemetryItem>();

        public ValueTask<int> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, bool async, CancellationToken cancellationToken)
        {
            foreach (var telemetryItem in telemetryItems)
            {
                this.TelemetryItems.Add(telemetryItem);
            }

            return new ValueTask<int>(Task.FromResult(telemetryItems.Count()));
        }
    }
}
