// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// This Factory encapsulates the <see cref="AzureMonitorTransmitter"/>.
    /// An ideal users will create a single exporter for each signal (Logs, Metrics, Traces).
    /// This factory should ensure that only one instance of the Transmitter is created for
    /// any unique connection string.
    /// </summary>
    internal sealed class TransmitterFactory
    {
        public static readonly TransmitterFactory Instance = new();

        internal readonly Dictionary<string, ITransmitter> _transmitters = new();
        private readonly object _lockObj = new();

        public ITransmitter Get(AzureMonitorExporterOptions azureMonitorExporterOptions)
        {
            return Get(azureMonitorExporterOptions, DefaultPlatform.Instance);
        }

        /// <remarks>
        /// This method should not be called directly in product code.
        /// This method is primarially intended for unit testing scenarios where providing a mock platform is necessary.
        /// </remarks>
        internal ITransmitter Get(AzureMonitorExporterOptions azureMonitorExporterOptions, IPlatform platform)
        {
            var key = azureMonitorExporterOptions.ConnectionString ?? string.Empty;

            if (!_transmitters.TryGetValue(key, out ITransmitter? transmitter))
            {
                lock (_lockObj)
                {
                    if (!_transmitters.TryGetValue(key, out transmitter))
                    {
                        transmitter = new AzureMonitorTransmitter(azureMonitorExporterOptions, platform);

                        _transmitters.Add(key, transmitter);
                    }
                }
            }

            return transmitter;
        }

        internal void Set(string connectionString, ITransmitter transmitter)
        {
            lock (_lockObj)
            {
                _transmitters[connectionString] = transmitter;
            }
        }
    }
}
