// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class MultiEndpointStatsbeat : IDisposable
    {
        // Allow old and new regional series to coexist during slot reclamation.
        internal const int CardinalityLimit = 2 * AttachStatsbeatRegistry.Capacity;
        private static readonly Destinations s_disposed = new(null, null);

        private readonly string? _connectionStringOverride;
        private readonly bool _defaultIsEu;
        private readonly HttpMessageHandler? _configHandler;
        private readonly Func<string, Measurement<int>> _createMeasurement;
        private readonly long _intervalTicks;
        private Destinations? _destinations;
        private KeyValuePair<string, object?>[]? _tags;
        private int _keyIndex;

        internal MultiEndpointStatsbeat(
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
            // One collector config serves both regional keys.
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
                return new Destination(connectionString);
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
            // Do not publish after disposal.
            if (Interlocked.CompareExchange(ref _destinations, destinations, null) == null)
            {
                Registry.SetEnabledRegions(nonEu != null, eu != null);
            }
        }

        internal PeriodicExportingMetricReader CreateReader(int exportIntervalMilliseconds)
        {
            var destinations = Volatile.Read(ref _destinations);
            var connectionString = DefaultConnectionString
                ?? destinations?.NonEu?.ConnectionString
                ?? destinations?.Eu?.ConnectionString
                ?? throw new InvalidOperationException("SDK stats have no enabled destination.");
            var options = AzureMonitorStatsbeat.CreateExporterOptions(connectionString);
            var exporter = _connectionStringOverride != null
                ? AzureMonitorMetricExporter.CreateForInternalTelemetry(options)
                : AzureMonitorMetricExporter.CreateForInternalTelemetry(options, StatsbeatConstants.AttachStatsbeatMeterName);
            return new AttachMetricReader(exporter, this, exportIntervalMilliseconds);
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
                    var tags = _createMeasurement(string.Empty).Tags.ToArray();
                    var keyIndex = Array.FindIndex(tags, tag => tag.Key == "cikey");
                    if (keyIndex < 0)
                    {
                        throw new InvalidOperationException("Attach measurements require a cikey dimension.");
                    }
                    _keyIndex = keyIndex;
                    _tags = new KeyValuePair<string, object?>[tags.Length + (_connectionStringOverride == null ? 2 : 0)];
                    tags.CopyTo(_tags, 0);
                }

                var destinations = Volatile.Read(ref _destinations);
                var regions = Registry.Collect(now, _intervalTicks);
                var measurements = new List<Measurement<int>>(regions.Count);
                foreach (var pair in regions)
                {
                    var destination = destinations?.Get(pair.Value);
                    if (destination == null)
                    {
                        continue;
                    }
                    var tags = (KeyValuePair<string, object?>[])_tags.Clone();
                    tags[_keyIndex] = new KeyValuePair<string, object?>("cikey", pair.Key);
                    if (_connectionStringOverride == null)
                    {
                        tags[tags.Length - 2] = new(SemanticConventions.AttributeMicrosoftInstrumentationKey, destination.Vars.InstrumentationKey);
                        tags[tags.Length - 1] = new(SemanticConventions.AttributeMicrosoftIngestionEndpoint, destination.Vars.IngestionEndpoint);
                    }
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

        public void Dispose()
        {
            Registry.Close();
            Interlocked.Exchange(ref _destinations, s_disposed);
        }

        private sealed class AttachMetricReader : PeriodicExportingMetricReader
        {
            private readonly MultiEndpointStatsbeat _stats;

            internal AttachMetricReader(AzureMonitorMetricExporter exporter, MultiEndpointStatsbeat stats, int exportIntervalMilliseconds)
                : base(exporter, exportIntervalMilliseconds)
            {
                _stats = stats;
                TemporalityPreference = MetricReaderTemporalityPreference.Delta;
            }

            protected override bool OnCollect(int timeoutMilliseconds)
            {
                var result = base.OnCollect(timeoutMilliseconds);
                _stats.Registry.CompleteCollection();
                return result;
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    base.Dispose(disposing);
                }
                finally
                {
                    if (disposing)
                    {
                        _stats.Dispose();
                    }
                }
            }
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
            internal Destination(string connectionString)
            {
                ConnectionString = connectionString;
                Vars = ConnectionStringParser.GetValues(connectionString);
            }

            internal string ConnectionString { get; }
            internal ConnectionVars Vars { get; }
        }
    }
}
