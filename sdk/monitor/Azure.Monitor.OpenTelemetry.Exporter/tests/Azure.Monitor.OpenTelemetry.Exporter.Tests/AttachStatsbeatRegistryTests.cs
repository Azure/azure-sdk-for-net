// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class AttachStatsbeatRegistryTests
    {
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestEurope = "https://westeurope-5.in.applicationinsights.azure.com/";
        private const long Start = 1000;
        private const long Interval = 100;

        [Fact]
        public void KeysAreDeduplicatedAndTheirRegionIsSnapshottedForExport()
        {
            var registry = new AttachStatsbeatRegistry();
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("first", EastUs), ("first", EastUs), ("second", WestEurope)), Start);
            Assert.Equal(new[] { "first", "second" }, registry.Collect(Start, Interval, true, true).OrderBy(key => key));

            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("first", WestEurope)), Start + 1);
            Assert.True(registry.TryGetReportRegion("first", out var isEu));
            Assert.False(isEu);
            Assert.True(registry.TryGetReportRegion("second", out isEu));
            Assert.True(isEu);
        }

        [Fact]
        public void ActiveKeysBecomeDueAgainAfterTheLongInterval()
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs));
            registry.Observe(batch, Start);
            Assert.Single(registry.Collect(Start, Interval, true, true));
            registry.CompleteCollection();
            Assert.Empty(registry.Collect(Start + 1, Interval, true, true));
            registry.CompleteCollection();
            registry.Observe(batch, Start + Interval);
            Assert.Single(registry.Collect(Start + Interval, Interval, true, true));
        }

        [Fact]
        public void ConcurrentObservationsCannotExceedTheCap()
        {
            var registry = new AttachStatsbeatRegistry();
            Parallel.For(0, AttachStatsbeatRegistry.Capacity * 2, i =>
                registry.Observe(MockStatsbeatScope.CreateRouteBatch(($"key-{i}", EastUs)), Start));

            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Collect(Start, Interval, true, true).Count);
        }

        [Fact]
        public void ExpirationWaitsForTheSdkToReclaimThePreviousCollection()
        {
            var registry = new AttachStatsbeatRegistry();
            registry.Observe(Keys(0), Start);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Collect(Start, Interval, true, true).Count);
            registry.CompleteCollection();

            Assert.Empty(registry.Collect(Start + Interval, Interval, true, true));
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("replacement", EastUs)), Start + Interval);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            registry.CompleteCollection();

            Assert.Empty(registry.Collect(Start + Interval + 1, Interval, true, true));
            Assert.Equal(0, registry.Count);
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("replacement", EastUs)), Start + Interval + 1);
            Assert.Equal("replacement", Assert.Single(registry.Collect(Start + Interval + 1, Interval, true, true)));
        }

        [Fact]
        public void ReplacingAFullCohortDoesNotOverflowTheRealSdk()
        {
            using var stats = new MockStatsbeatScope();
            long now = Start;
            using var exporter = new MultiEndpointStatsbeatExporter(
                null, EastUs, null, TimeSpan.FromTicks(Interval),
                key => new Measurement<int>(1, new("rpId", stats.ResourceProviderId), new("cikey", key)));
            exporter.Initialize();
            using var meter = new Meter("AttachReclamation." + Guid.NewGuid().ToString("N"));
            meter.CreateObservableGauge("Attach", () => exporter.GetMeasurements(now));
            using var provider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meter.Name)
                .AddView("Attach", new MetricStreamConfiguration { CardinalityLimit = AttachStatsbeatRegistry.Capacity })
                .AddReader(new BaseExportingMetricReader(exporter) { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            exporter.Observe(Keys(0), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(AttachStatsbeatRegistry.Capacity, stats.TelemetryItems.Count);

            now += Interval;
            Assert.True(provider.ForceFlush());
            Assert.True(provider.ForceFlush());
            Assert.Equal(0, exporter.Registry.Count);

            exporter.Observe(Keys(AttachStatsbeatRegistry.Capacity), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(AttachStatsbeatRegistry.Capacity * 2, stats.TelemetryItems.Count);
        }

        private static Internals.MultiEndpoint.EndpointRouteBatch Keys(int start)
            => MockStatsbeatScope.CreateRouteBatch(Enumerable.Range(start, AttachStatsbeatRegistry.Capacity)
                .Select(i => ($"key-{i}", EastUs)).ToArray());
    }
}
