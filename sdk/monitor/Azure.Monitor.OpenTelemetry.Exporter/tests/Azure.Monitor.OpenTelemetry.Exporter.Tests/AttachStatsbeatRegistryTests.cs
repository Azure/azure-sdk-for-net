// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
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
            var reported = registry.Collect(Start, Interval);
            Assert.Equal(new[] { "first", "second" }, reported.Keys.OrderBy(key => key));

            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("first", WestEurope)), Start + 1);
            registry.Close();
            Assert.False(reported["first"]);
            Assert.True(reported["second"]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(Start)]
        public void ActiveKeysBecomeDueAgainAfterTheLongInterval(long start)
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs));
            registry.Observe(batch, start);
            Assert.Single(registry.Collect(start, Interval));
            registry.CompleteCollection();
            Assert.Empty(registry.Collect(start, Interval));
            Assert.Empty(registry.Collect(start + Interval - 1, Interval));
            registry.CompleteCollection();
            registry.Observe(batch, start + Interval);
            Assert.Single(registry.Collect(start + Interval, Interval));
        }

        [Fact]
        public void ConcurrentObservationsCannotExceedTheCap()
        {
            var registry = new AttachStatsbeatRegistry();
            Parallel.For(0, AttachStatsbeatRegistry.Capacity * 2, i =>
                registry.Observe(MockStatsbeatScope.CreateRouteBatch(($"key-{i}", EastUs)), Start));

            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Collect(Start, Interval).Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(Start)]
        public void ExpirationWaitsForTheSdkToReclaimThePreviousCollection(long start)
        {
            var registry = new AttachStatsbeatRegistry();
            registry.Observe(Keys(0), start);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Collect(start, Interval).Count);
            registry.CompleteCollection();

            Assert.Empty(registry.Collect(start + Interval, Interval));
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("replacement", EastUs)), start + Interval);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            registry.CompleteCollection();

            Assert.Empty(registry.Collect(start + Interval + 1, Interval));
            Assert.Equal(0, registry.Count);
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("replacement", EastUs)), start + Interval + 1);
            Assert.Equal("replacement", Assert.Single(registry.Collect(start + Interval + 1, Interval)).Key);
        }

        [Fact]
        public void DuplicateKeysPreserveCaseAndLatestRegionAcrossGroups()
        {
            var registry = new AttachStatsbeatRegistry();
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(
                ("key", EastUs), ("key", EastUs), ("", EastUs), ("Key", EastUs),
                ("key", WestEurope), ("key", WestEurope)), Start + 2);
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(("key", EastUs)), Start + 1);

            var reported = registry.Collect(Start + 2, Interval);
            Assert.Equal(2, registry.Count);
            Assert.True(reported["key"]);
            Assert.False(reported["Key"]);
        }

        [Fact]
        public void PreparationDeduplicatesNonconsecutiveEqualStringsAcrossGroups()
        {
            var registry = new AttachStatsbeatRegistry();
            var first = new string("first".ToCharArray());
            var duplicate = new string("first".ToCharArray());
            Assert.NotSame(first, duplicate);
            var batch = MockStatsbeatScope.CreateRouteBatch(
                (first, EastUs), ("second", EastUs), (duplicate, EastUs), ("", EastUs), ("First", EastUs),
                (duplicate, WestEurope), ("second", WestEurope), (first, WestEurope));
            batch.GetOrAdd(WestEurope, isAad: true).TelemetryItems.Add(
                new TelemetryItem(DateTime.UtcNow, resource: null, first));

            registry.Observe(batch, Start);

            var observations = Assert.IsType<AttachStatsbeatRegistry.ObservationBuffer>(batch.AttachObservations);
            Assert.Equal(new[] { "first", "second", "First" }, observations.Items.Select(pair => pair.Key));
            var reported = registry.Collect(Start, Interval);
            Assert.Equal(3, reported.Count);
            Assert.True(reported["first"]);
            Assert.True(reported["second"]);
            Assert.False(reported["First"]);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        public void DuplicateKeysUseTheLastEnabledRegion(bool nonEuEnabled, bool euEnabled, bool expectedIsEu)
        {
            var registry = new AttachStatsbeatRegistry();
            registry.SetEnabledRegions(nonEuEnabled, euEnabled);
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs), ("key", WestEurope));

            registry.Observe(batch, Start);

            Assert.Equal(expectedIsEu, Assert.Single(registry.Collect(Start, Interval)).Value);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DisabledGroupsDoNotChangeAdmissionOrderAtCapacity(bool nonEuEnabled)
        {
            var registry = new AttachStatsbeatRegistry();
            var enabledEndpoint = nonEuEnabled ? EastUs : WestEurope;
            var disabledEndpoint = nonEuEnabled ? WestEurope : EastUs;
            registry.SetEnabledRegions(nonEuEnabled, !nonEuEnabled);
            registry.Observe(MockStatsbeatScope.CreateRouteBatch(
                Enumerable.Range(0, AttachStatsbeatRegistry.Capacity - 1)
                    .Select(i => ($"key-{i}", enabledEndpoint)).ToArray()), Start);
            var batch = MockStatsbeatScope.CreateRouteBatch(
                ("later", disabledEndpoint), ("first", enabledEndpoint), ("later", enabledEndpoint));

            registry.Observe(batch, Start);

            var reported = registry.Collect(Start, Interval);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            Assert.Contains("first", reported.Keys);
            Assert.DoesNotContain("later", reported.Keys);
        }

        [Fact]
        public void ReusedBatchesRefreshRegionsAndClearPreparedKeys()
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("old", EastUs));
            registry.Observe(batch, Start);
            var group = batch[0];
            var observations = Assert.IsType<AttachStatsbeatRegistry.ObservationBuffer>(batch.AttachObservations);

            foreach (var endpoint in new[] { WestEurope, new string(WestEurope.ToCharArray()), EastUs })
            {
                batch.Reset();
                Assert.Empty(observations.Items);
                Assert.Empty(group.TelemetryItems);
                var reusedGroup = batch.GetOrAdd(endpoint);
                Assert.Same(group, reusedGroup);
                reusedGroup.TelemetryItems.Add(new TelemetryItem(DateTime.UtcNow, resource: null, "new"));

                registry.Observe(batch, Start + 1);

                Assert.Same(observations, batch.AttachObservations);
                var observation = Assert.Single(observations.Items);
                Assert.Equal("new", observation.Key);
                Assert.Equal(endpoint == WestEurope, observation.Value);
            }

            Assert.Equal(2, registry.Count);
            Assert.All(registry.Collect(Start + 1, Interval), pair => Assert.False(pair.Value));
        }

        [Fact]
        public void ReusedBatchesRespectChangedRegionConfiguration()
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs), ("key", WestEurope));
            registry.Observe(batch, Start);
            Assert.True(Assert.Single(batch.AttachObservations!.Items).Value);

            registry.SetEnabledRegions(true, false);
            registry.Observe(batch, Start + 1);
            Assert.False(Assert.Single(batch.AttachObservations.Items).Value);

            registry.SetEnabledRegions(false, false);
            registry.Observe(batch, Start + 2);
            Assert.Equal(0, registry.Count);

            registry.SetEnabledRegions(false, true);
            registry.Observe(batch, Start + 3);
            Assert.True(Assert.Single(registry.Collect(Start + 3, Interval)).Value);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DisabledOrClosedRegistriesSkipBatchPreparation(bool closed)
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs));
            if (closed)
            {
                registry.Close();
                registry.SetEnabledRegions(true, true);
            }
            else
            {
                registry.SetEnabledRegions(false, false);
            }

            registry.Observe(batch, Start);

            Assert.Null(batch.AttachObservations);
            Assert.Equal(0, registry.Count);
            Assert.Empty(registry.Collect(Start, Interval));
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ConfigurationControlsObservationAndCollection(bool nonEuEnabled, bool euEnabled)
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("us", EastUs), ("eu", WestEurope));
            registry.Observe(batch, Start);
            registry.SetEnabledRegions(nonEuEnabled, euEnabled);
            registry.Observe(batch, Start + 1);

            var reported = registry.Collect(Start + 1, Interval);
            Assert.Equal(nonEuEnabled, reported.ContainsKey("us"));
            Assert.Equal(euEnabled, reported.ContainsKey("eu"));
            Assert.Equal(reported.Count, registry.Count);
        }

        [Fact]
        public void ClosingDuringObservationCannotRepopulateTheRegistry()
        {
            var registry = new AttachStatsbeatRegistry();
            var batch = MockStatsbeatScope.CreateRouteBatch(("key", EastUs));
            using var start = new Barrier(2);
            Parallel.Invoke(
                () =>
                {
                    registry.Observe(batch, Start);
                    Assert.True(start.SignalAndWait(TimeSpan.FromSeconds(10)));
                    for (int i = 0; i < 1000; i++)
                    {
                        registry.Observe(batch, Start + i);
                    }
                },
                () =>
                {
                    Assert.True(start.SignalAndWait(TimeSpan.FromSeconds(10)));
                    registry.Close();
                });

            registry.SetEnabledRegions(true, true);
            registry.Observe(batch, Start + 1000);
            Assert.Equal(0, registry.Count);
            Assert.Empty(registry.Collect(Start + 1000, Interval));
        }

        [Fact]
        public void ConcurrentObservationsAndCollectionPreserveAllAdmittedKeys()
        {
            var registry = new AttachStatsbeatRegistry();
            var snapshots = new List<IReadOnlyDictionary<string, bool>>();
            Parallel.Invoke(
                () => Parallel.For(0, AttachStatsbeatRegistry.Capacity, i =>
                    registry.Observe(MockStatsbeatScope.CreateRouteBatch(
                        ($"key-{i}", i % 2 == 0 ? WestEurope : EastUs)), Start)),
                () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        snapshots.Add(registry.Collect(Start, Interval));
                        registry.CompleteCollection();
                    }
                });
            snapshots.Add(registry.Collect(Start, Interval));

            var reported = snapshots.SelectMany(snapshot => snapshot).ToDictionary(pair => pair.Key, pair => pair.Value);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, reported.Count);
            Assert.Equal(AttachStatsbeatRegistry.Capacity, registry.Count);
            for (int i = 0; i < AttachStatsbeatRegistry.Capacity; i++)
            {
                Assert.Equal(i % 2 == 0, reported[$"key-{i}"]);
            }
        }

        [Fact]
        public void ObservationDuringCollectionDoesNotChangeTheExportedRegion()
        {
            using var stats = new MockStatsbeatScope();
            long now = Start;
            using var collector = new MultiEndpointStatsbeat(
                null, EastUs, null, TimeSpan.FromTicks(Interval),
                key => new Measurement<int>(1, new("rpId", stats.ResourceProviderId), new("cikey", key)));
            collector.Initialize();
            using var meter = new Meter(StatsbeatConstants.AttachStatsbeatMeterName);
            var instrument = meter.CreateObservableGauge("Attach", () =>
            {
                var measurements = collector.GetMeasurements(now);
                collector.Observe(MockStatsbeatScope.CreateRouteBatch(("key", WestEurope)), now + 1);
                return measurements;
            });
            using var provider = BuildProvider(collector, instrument);

            collector.Observe(MockStatsbeatScope.CreateRouteBatch(("key", EastUs)), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, Assert.Single(stats.TelemetryItems).InstrumentationKey);

            now += Interval;
            Assert.True(provider.ForceFlush());
            Assert.Equal(2, stats.TelemetryItems.Count);
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_EU, stats.TelemetryItems[1].InstrumentationKey);
            Assert.All(stats.TelemetryItems, item =>
                Assert.Equal("key", ((MetricsData)item.Data.BaseData).Properties["cikey"]));
        }

        [Fact]
        public void ConcurrentInitializationAndDisposalCannotPublishOrLeakDestinations()
        {
            for (int i = 0; i < 100; i++)
            {
                using var stats = new MockStatsbeatScope();
                var nonEu = Assert.IsType<MockTransmitter>(
                    TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_NonEU]);
                var eu = Assert.IsType<MockTransmitter>(
                    TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_EU]);
                using var collector = new MultiEndpointStatsbeat(
                    null, EastUs, null, TimeSpan.FromTicks(Interval), _ => new Measurement<int>(1));
                Parallel.Invoke(collector.Initialize, collector.Dispose);
                collector.Observe(MockStatsbeatScope.CreateRouteBatch(("late", EastUs)), Start);

                Assert.False(collector.HasDestination);
                Assert.Null(collector.DefaultConnectionString);
                Assert.Equal(0, collector.Registry.Count);
                Assert.Equal(0, nonEu.DisposeCallCount);
                Assert.Equal(0, eu.DisposeCallCount);
            }
        }

        [Fact]
        public void ReplacingAFullCohortDoesNotOverflowTheRealSdk()
        {
            using var stats = new MockStatsbeatScope();
            long now = Start;
            using var collector = new MultiEndpointStatsbeat(
                null, EastUs, null, TimeSpan.FromTicks(Interval),
                key => new Measurement<int>(1, new("rpId", stats.ResourceProviderId), new("cikey", key)));
            collector.Initialize();
            using var meter = new Meter(StatsbeatConstants.AttachStatsbeatMeterName);
            var instrument = meter.CreateObservableGauge("Attach", () => collector.GetMeasurements(now));
            using var provider = BuildProvider(collector, instrument);

            collector.Observe(Keys(0), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(AttachStatsbeatRegistry.Capacity, stats.TelemetryItems.Count);

            now += Interval;
            Assert.True(provider.ForceFlush());
            Assert.True(provider.ForceFlush());
            Assert.Equal(0, collector.Registry.Count);

            collector.Observe(Keys(AttachStatsbeatRegistry.Capacity), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(AttachStatsbeatRegistry.Capacity * 2, stats.TelemetryItems.Count);
        }

        [Fact]
        public void MovingAFullCohortBetweenRegionsWithUpdatedMetadataDoesNotOverflowTheRealSdk()
        {
            using var stats = new MockStatsbeatScope();
            long now = Start;
            var version = string.Empty;
            using var collector = new MultiEndpointStatsbeat(
                null, EastUs, null, TimeSpan.FromTicks(Interval),
                key => new Measurement<int>(1, new("rpId", stats.ResourceProviderId), new("cikey", key), new("version", version)));
            collector.Initialize();
            using var meter = new Meter(StatsbeatConstants.AttachStatsbeatMeterName);
            var instrument = meter.CreateObservableGauge("Attach", () => collector.GetMeasurements(now));
            using var provider = BuildProvider(collector, instrument);

            for (int collection = 0; collection < 4; collection++)
            {
                var isEu = collection % 2 != 0;
                version = $"version-{collection}";
                collector.Observe(Keys(0, isEu ? WestEurope : EastUs), now);
                Assert.True(provider.ForceFlush());
                var items = stats.TelemetryItems.Skip(collection * AttachStatsbeatRegistry.Capacity).ToArray();
                Assert.Equal(AttachStatsbeatRegistry.Capacity, items.Length);
                Assert.Equal(AttachStatsbeatRegistry.Capacity,
                    items.Select(item => ((MetricsData)item.Data.BaseData).Properties["cikey"]).Distinct().Count());
                Assert.All(items, item => Assert.Equal(isEu
                    ? StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                    : StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, item.InstrumentationKey));
                Assert.All(items, item => Assert.Equal(version, ((MetricsData)item.Data.BaseData).Properties["version"]));
                now += Interval;
            }

            Assert.True(provider.ForceFlush());
            Assert.True(provider.ForceFlush());
            Assert.Equal(0, collector.Registry.Count);
            collector.Observe(Keys(AttachStatsbeatRegistry.Capacity), now);
            Assert.True(provider.ForceFlush());
            Assert.Equal(5 * AttachStatsbeatRegistry.Capacity, stats.TelemetryItems.Count);
        }

        private static MeterProvider BuildProvider(MultiEndpointStatsbeat collector, Instrument instrument)
            => Sdk.CreateMeterProviderBuilder()
                .AddMeter(instrument.Meter.Name)
                .AddView(candidate => ReferenceEquals(candidate, instrument)
                    ? new MetricStreamConfiguration { CardinalityLimit = MultiEndpointStatsbeat.CardinalityLimit }
                    : MetricStreamConfiguration.Drop)
                .AddReader(collector.CreateReader(int.MaxValue))
                .Build();

        private static EndpointRouteBatch Keys(int start, string endpoint = EastUs)
            => MockStatsbeatScope.CreateRouteBatch(Enumerable.Range(start, AttachStatsbeatRegistry.Capacity)
                .Select(i => ($"key-{i}", endpoint)).ToArray());
    }
}
