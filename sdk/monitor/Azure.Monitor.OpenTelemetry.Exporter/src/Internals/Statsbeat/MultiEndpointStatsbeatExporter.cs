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
        private static readonly Destinations s_disposed = new(null, null);

        private readonly string? _connectionStringOverride;
        private readonly bool _defaultIsEu;
        private readonly HttpMessageHandler? _configHandler;
        private readonly Func<string, Measurement<int>> _createMeasurement;
        private readonly long _intervalTicks;
        private Destinations? _destinations;
        private IReadOnlyDictionary<string, bool>? _reportRegions;
        private KeyValuePair<string, object?>[]? _tags;
        private int _keyIndex;
        private AzureMonitorResource? _resource;

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

        internal bool HasDestination => Volatile.Read(ref _destinations)?.HasDestination == true;

        internal string? DefaultConnectionString => Volatile.Read(ref _destinations)?.Get(_defaultIsEu)?.ConnectionString;

        internal void Observe(EndpointRouteBatch batch, long now)
            => Registry.Observe(batch, now);

        internal void Initialize()
        {
            Publish(
                CreateDestination(_connectionStringOverride ?? StatsbeatConstants.Statsbeat_ConnectionString_NonEU),
                CreateDestination(_connectionStringOverride ?? StatsbeatConstants.Statsbeat_ConnectionString_EU));
        }

        internal async Task InitializeAsync()
        {
            // The collector has no EU deployment. Share its configuration while preserving
            // the regional envelope keys and the existing regional Breeze fallback.
            var result = await SdkStatsConfigFetcher.FetchAsync(
                StatsbeatConstants.SdkStatsConfigUrl_NonEU, _configHandler).ConfigureAwait(false);
            Publish(ResolveDestination(result, isEu: false), ResolveDestination(result, isEu: true));
        }

        private static Destination? ResolveDestination(SdkStatsConfigResult result, bool isEu)
        {
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
            var destinations = new Destinations(nonEu, eu);
            // Disposal replaces the pending state, so late configuration cannot publish.
            if (Interlocked.CompareExchange(ref _destinations, destinations, null) == null)
            {
                Registry.SetEnabledRegions(nonEu != null, eu != null);
                return;
            }

            nonEu?.Transmitter.Dispose();
            eu?.Transmitter.Dispose();
        }

        internal IEnumerable<Measurement<int>> GetMeasurements()
            => GetMeasurements(DateTime.UtcNow.Ticks);

        internal IEnumerable<Measurement<int>> GetMeasurements(long now)
        {
            _reportRegions = null;
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

                // The reader serializes collection and export. Observations cannot mutate
                // this collection's region snapshot while its metrics are being exported.
                var regions = Registry.Collect(now, _intervalTicks);
                var measurements = new List<Measurement<int>>(regions.Count);
                foreach (var key in regions.Keys)
                {
                    var tags = (KeyValuePair<string, object?>[])_tags.Clone();
                    tags[_keyIndex] = new KeyValuePair<string, object?>("cikey", key);
                    measurements.Add(new Measurement<int>(1, tags));
                }
                _reportRegions = regions;

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
                var destinations = Volatile.Read(ref _destinations);
                var reportRegions = _reportRegions;
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
                            || reportRegions == null
                            || !reportRegions.TryGetValue(key, out isEu))
                        {
                            continue;
                        }
                    }

                    var destination = destinations?.Get(isEu);
                    if (destination != null)
                    {
                        item.InstrumentationKey = destination.InstrumentationKey;
                        (isEu ? euItems : nonEuItems).Add(item);
                    }
                }

                var nonEuResult = Send(destinations?.NonEu, nonEuItems);
                var euResult = Send(destinations?.Eu, euItems);
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
                Registry.Close();
                var destinations = Interlocked.Exchange(ref _destinations, s_disposed);
                destinations?.NonEu?.Transmitter.Dispose();
                destinations?.Eu?.Transmitter.Dispose();
            }

            base.Dispose(disposing);
        }

        private sealed class Destinations
        {
            internal Destinations(Destination? nonEu, Destination? eu)
            {
                NonEu = nonEu;
                Eu = eu;
            }

            internal Destination? NonEu { get; }
            internal Destination? Eu { get; }
            internal bool HasDestination => NonEu != null || Eu != null;
            internal Destination? Get(bool isEu) => isEu ? Eu : NonEu;
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
