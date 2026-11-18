// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal sealed class MockStatsbeatScope : IDisposable
    {
        private readonly Dictionary<string, ITransmitter?> _previousTransmitters = new();

        public MockStatsbeatScope()
        {
            ResourceProviderId = "statsbeat-test-" + Guid.NewGuid().ToString("N");
            Platform.SetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_SITE_NAME, ResourceProviderId);
            Add(StatsbeatConstants.Statsbeat_ConnectionString_NonEU);
            Add(StatsbeatConstants.Statsbeat_ConnectionString_EU);

            var configuredOverride = DefaultPlatform.Instance.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING);
            if (!string.IsNullOrWhiteSpace(configuredOverride))
            {
                Add(configuredOverride!);
            }
        }

        public string ResourceProviderId { get; }
        public MockPlatform Platform { get; } = new();
        public List<TelemetryItem> TelemetryItems { get; } = new();

        public void Add(string connectionString)
        {
            if (_previousTransmitters.ContainsKey(connectionString))
            {
                return;
            }

            TransmitterFactory.Instance._transmitters.TryGetValue(connectionString, out var previous);
            _previousTransmitters.Add(connectionString, previous);
            TransmitterFactory.Instance.Set(connectionString,
                new MockTransmitter(TelemetryItems, ConnectionStringParser.GetValues(connectionString).InstrumentationKey)
                { CaptureRoutedTelemetry = true });
        }

        public void AddEndpoint(string endpoint)
        {
            Add(AzureMonitorStatsbeat.BuildConnectionStringFromHost(endpoint, StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU));
            Add(AzureMonitorStatsbeat.BuildConnectionStringFromHost(endpoint, StatsbeatConstants.Statsbeat_InstrumentationKey_EU));
        }

        internal static EndpointRouteBatch CreateRouteBatch(params (string Key, string Endpoint)[] destinations)
        {
            var batch = new EndpointRouteBatch();
            foreach (var destination in destinations)
            {
                batch.GetOrAdd(destination.Endpoint).TelemetryItems.Add(
                    new TelemetryItem(DateTime.UtcNow, resource: null, instrumentationKey: destination.Key)
                    {
                        Data = new MonitorBase { BaseType = "MetricData", BaseData = new MetricsData(2) },
                    });
            }

            return batch;
        }

        public void Dispose()
        {
            // Keep first-time mocks installed for initialization or shutdown that outlives a test.
            foreach (var entry in _previousTransmitters)
            {
                if (entry.Value != null)
                {
                    TransmitterFactory.Instance.Set(entry.Key, entry.Value);
                }
            }
        }
    }
}
