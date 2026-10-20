// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class MultiEndpointStatsbeatExporter : BaseExporter<Metric>
    {
        private readonly string? _connectionStringOverride;
        private readonly bool _defaultIsEu;
        private readonly HttpMessageHandler? _configHandler;
        private readonly Func<string, Measurement<int>> _createMeasurement;
        private readonly long _intervalTicks;
        private readonly object _destinationGate = new();
        private Destination? _nonEu;
        private Destination? _eu;
        private KeyValuePair<string, object?>[]? _tags;
        private int _keyIndex;
        private AzureMonitorResource? _resource;
        private bool _disposed;
        private bool _initialized;

        internal MultiEndpointStatsbeatExporter(
            string? connectionStringOverride,
            string defaultIngestionEndpoint,
            HttpMessageHandler? configHandler,
            TimeSpan interval,
            Func<string, Measurement<int>> createMeasurement)
        {
            _connectionStringOverride = connectionStringOverride;
            _defaultIsEu = AzureMonitorStatsbeat.IsEuRegion(defaultIngestionEndpoint);
            _configHandler = configHandler;
            _intervalTicks = interval.Ticks;
            _createMeasurement = createMeasurement;
        }

        internal AttachStatsbeatRegistry Registry { get; } = new();

        internal bool HasDestination => _nonEu != null || _eu != null;

        internal string? DefaultConnectionString => (_defaultIsEu ? _eu : _nonEu)?.ConnectionString;

        internal void Observe(EndpointRouteBatch batch, long now)
        {
            lock (_destinationGate)
            {
                if (!_disposed)
                {
                    Registry.Observe(batch, now, !_initialized || _nonEu != null, !_initialized || _eu != null);
                }
            }
        }

        internal void Initialize()
        {
            Publish(
                CreateDestination(_connectionStringOverride ?? StatsbeatConstants.Statsbeat_ConnectionString_NonEU),
                CreateDestination(_connectionStringOverride ?? StatsbeatConstants.Statsbeat_ConnectionString_EU));
        }

        internal async Task InitializeAsync()
        {
            var destinations = await Task.WhenAll(
                ResolveDestinationAsync(isEu: false),
                ResolveDestinationAsync(isEu: true)).ConfigureAwait(false);
            Publish(destinations[0], destinations[1]);
        }

        private async Task<Destination?> ResolveDestinationAsync(bool isEu)
        {
            var configUrl = isEu ? StatsbeatConstants.SdkStatsConfigUrl_EU : StatsbeatConstants.SdkStatsConfigUrl_NonEU;
            var result = await SdkStatsConfigFetcher.FetchAsync(configUrl, _configHandler).ConfigureAwait(false);
            if (result.Status == SdkStatsConfigStatus.Disabled)
            {
                return null;
            }

            var connectionString = result.Status == SdkStatsConfigStatus.UseUrl
                ? AzureMonitorStatsbeat.BuildConnectionStringFromHost(result.Url!,
                    isEu ? StatsbeatConstants.Statsbeat_InstrumentationKey_EU : StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU)
                : isEu ? StatsbeatConstants.Statsbeat_ConnectionString_EU : StatsbeatConstants.Statsbeat_ConnectionString_NonEU;
            return CreateDestination(connectionString);
        }

        private static Destination? CreateDestination(string connectionString)
        {
            try
            {
                var vars = ConnectionStringParser.GetValues(connectionString);
                return new Destination(connectionString, vars.InstrumentationKey,
                    TransmitterFactory.Instance.Get(AzureMonitorStatsbeat.CreateExporterOptions(connectionString)));
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                return null;
            }
        }

        private void Publish(Destination? nonEu, Destination? eu)
        {
            lock (_destinationGate)
            {
                if (!_disposed)
                {
                    _nonEu = nonEu;
                    _eu = eu;
                    _initialized = true;
                    return;
                }
            }

            nonEu?.Transmitter.Dispose();
            eu?.Transmitter.Dispose();
        }

        internal IEnumerable<Measurement<int>> GetMeasurements()
            => GetMeasurements(DateTime.UtcNow.Ticks);

        internal IEnumerable<Measurement<int>> GetMeasurements(long now)
        {
            if (Registry.Count == 0)
            {
                return Array.Empty<Measurement<int>>();
            }

            try
            {
                if (_tags == null)
                {
                    // Keep invariant dimensions stable so only customer keys consume new SDK slots.
                    var tags = _createMeasurement(string.Empty).Tags.ToArray();
                    var keyIndex = Array.FindIndex(tags, tag => tag.Key == "cikey");
                    if (keyIndex < 0)
                    {
                        throw new InvalidOperationException("Attach measurements require a cikey dimension.");
                    }
                    _keyIndex = keyIndex;
                    _tags = tags;
                }

                var keys = Registry.Collect(now, _intervalTicks, _nonEu != null, _eu != null);
                var measurements = new List<Measurement<int>>(keys.Count);
                foreach (var key in keys)
                {
                    var tags = (KeyValuePair<string, object?>[])_tags.Clone();
                    tags[_keyIndex] = new KeyValuePair<string, object?>("cikey", key);
                    measurements.Add(new Measurement<int>(1, tags));
                }

                return measurements;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                return Array.Empty<Measurement<int>>();
            }
        }

        public override ExportResult Export(in Batch<Metric> batch)
        {
            using var suppression = SuppressInstrumentationScope.Begin();
            try
            {
                _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(string.Empty);
                var (items, _) = MetricHelper.OtelToAzureMonitorMetrics(batch, _resource, string.Empty);
                var nonEuItems = new List<TelemetryItem>();
                var euItems = new List<TelemetryItem>();

                foreach (var item in items)
                {
                    var isEu = _defaultIsEu;
                    if (item.Data.BaseData is MetricsData data
                        && data.Metrics.Count == 1
                        && data.Metrics[0].Name == StatsbeatConstants.AttachStatsbeatMetricName)
                    {
                        if (!data.Properties.TryGetValue("cikey", out var key)
                            || !Registry.TryGetReportRegion(key, out isEu))
                        {
                            continue;
                        }
                    }

                    var destination = isEu ? _eu : _nonEu;
                    if (destination != null)
                    {
                        item.InstrumentationKey = destination.InstrumentationKey;
                        (isEu ? euItems : nonEuItems).Add(item);
                    }
                }

                var nonEuResult = Send(_nonEu, nonEuItems);
                var euResult = Send(_eu, euItems);
                return nonEuResult == ExportResult.Success && euResult == ExportResult.Success
                    ? ExportResult.Success : ExportResult.Failure;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                return ExportResult.Failure;
            }
            finally
            {
                Registry.CompleteCollection();
            }
        }

        private static ExportResult Send(Destination? destination, List<TelemetryItem> items)
        {
            if (destination == null || items.Count == 0)
            {
                return ExportResult.Success;
            }

            try
            {
                return destination.Transmitter.TrackAsync(items,
                    new TelemetrySchemaTypeCounter(),
                    TelemetryItemOrigin.AzureMonitorMetricExporter, async: false, CancellationToken.None).EnsureCompleted();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                return ExportResult.Failure;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Destination? nonEu;
                Destination? eu;
                lock (_destinationGate)
                {
                    _disposed = true;
                    nonEu = _nonEu;
                    eu = _eu;
                    _nonEu = null;
                    _eu = null;
                }

                nonEu?.Transmitter.Dispose();
                eu?.Transmitter.Dispose();
                Registry.Clear();
            }

            base.Dispose(disposing);
        }

        private sealed class Destination
        {
            internal Destination(string connectionString, string instrumentationKey, ITransmitter transmitter)
            {
                ConnectionString = connectionString;
                InstrumentationKey = instrumentationKey;
                Transmitter = transmitter;
            }

            internal string ConnectionString { get; }
            internal string InstrumentationKey { get; }
            internal ITransmitter Transmitter { get; }
        }
    }
}
