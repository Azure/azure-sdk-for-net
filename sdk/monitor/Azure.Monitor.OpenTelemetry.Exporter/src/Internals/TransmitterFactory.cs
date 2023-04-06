// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// This Factory encapsulates the <see cref="AzureMonitorTransmitter"/>.
    /// An ideal users will create a single exporter for each signal (Logs, Metrics, Traces).
    /// This factory should ensure that only one instance of the Transmitter is created for
    /// any unique connection string.
    /// </summary>
    internal class TransmitterFactory
    {
        public static readonly TransmitterFactory Instance = new();
        public static readonly IPlatform platform = new DefaultPlatform();
        public static readonly IVmMetadataProvider vmMetadataProvider = new DefaultVmMetadataProvider();

        internal readonly Dictionary<string, AzureMonitorTransmitter> _transmitters = new();
        private readonly object _lockObj = new();

        public AzureMonitorTransmitter Get(AzureMonitorExporterOptions azureMonitorExporterOptions)
        {
            var key = azureMonitorExporterOptions.ConnectionString ?? string.Empty;

            if (!_transmitters.TryGetValue(key, out AzureMonitorTransmitter? transmitter))
            {
                lock (_lockObj)
                {
                    if (!_transmitters.TryGetValue(key, out transmitter))
                    {
                        transmitter = new AzureMonitorTransmitter(azureMonitorExporterOptions, platform, vmMetadataProvider);

                        _transmitters.Add(key, transmitter);
                    }
                }
            }

            return transmitter;
        }
    }
}
