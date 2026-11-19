// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class MultiEndpointNetworkStatsbeatTests
    {
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestEurope = "https://westeurope-5.in.applicationinsights.azure.com/";
        private const string CustomerConnectionString = "InstrumentationKey=configured;IngestionEndpoint=" + WestEurope;

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void MixedCustomerKeysCountOncePerCustomerAndRouteByHost(bool configured)
        {
            using var scope = new NetworkTestScope(configured: configured);
            var batch = MockStatsbeatScope.CreateRouteBatch(
                ("us-1", EastUs), ("us-2", EastUs), ("us-1", EastUs),
                ("eu-1", WestEurope), ("eu-2", WestEurope), ("eu-2", WestEurope));

            Assert.Equal(ExportResult.Success, scope.Send(batch));
            Assert.Equal(2, scope.Requests);
            scope.Flush();

            Assert.Equal(4, scope.Stats.TelemetryItems.Count(item => Name(item) == "Attach"));
            Assert.Equal(4, scope.NetworkItems("Request_Success_Count").Length);
            Assert.Equal(4, scope.NetworkItems("Request_Duration").Length);
            Assert.All(scope.NetworkItems("Request_Success_Count"), item =>
            {
                var data = Data(item);
                Assert.Equal(1, Assert.Single(data.Metrics).Value);
                Assert.Contains(data.Properties["cikey"], new[] { "us-1", "us-2", "eu-1", "eu-2" });
                Assert.Equal(data.Properties["cikey"].StartsWith("eu", StringComparison.Ordinal) ? "westeurope-5" : "eastus-1", data.Properties["host"]);
                Assert.Equal("breeze", data.Properties["endpoint"]);
                Assert.Equal(SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter), truncate: false), data.Properties["version"]);
                Assert.DoesNotContain(item.Tags.Keys, key => key.StartsWith("ai.cloud.", StringComparison.Ordinal) || key.StartsWith("ai.operation.", StringComparison.Ordinal));
                Assert.Equal(data.Properties["host"] == "westeurope-5"
                    ? StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                    : StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, item.InstrumentationKey);
                Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, data.Properties.Keys);
                Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, data.Properties.Keys);
            });

            scope.Stats.TelemetryItems.Clear();
            scope.Flush();
            Assert.Empty(scope.Stats.TelemetryItems);
            Assert.Equal(ExportResult.Success, scope.Send(batch));
            scope.Flush();
            Assert.Equal(4, scope.NetworkItems("Request_Success_Count").Length);
            Assert.DoesNotContain(scope.Stats.TelemetryItems, item => Name(item) == "Attach");
        }

        [Theory]
        [InlineData(400, "Request_Failure_Count")]
        [InlineData(401, "Retry_Count")]
        [InlineData(429, "Retry_Count")]
        [InlineData(503, "Retry_Count")]
        [InlineData(402, "Throttle_Count")]
        [InlineData(439, "Throttle_Count")]
        public void ResponseFailuresAreAttributedToTheirEndpoint(int status, string metric)
        {
            using var scope = new NetworkTestScope();
            scope.Response = request => new MockResponse(request.Uri.Host!.StartsWith("eastus", StringComparison.Ordinal) ? status : 200);

            Assert.Equal(ExportResult.Failure, scope.Send(MockStatsbeatScope.CreateRouteBatch(("us", EastUs), ("eu", WestEurope))));
            scope.Flush();

            var failure = Assert.Single(scope.NetworkItems(metric));
            Assert.Equal("eastus-1", Data(failure).Properties["host"]);
            Assert.Equal(status.ToString(), Data(failure).Properties["statusCode"]);
            Assert.Equal(1, Assert.Single(Data(failure).Metrics).Value);
            Assert.Equal("us", Data(failure).Properties["cikey"]);
            Assert.Equal("westeurope-5", Data(Assert.Single(scope.NetworkItems("Request_Success_Count"))).Properties["host"]);
            Assert.Equal(2, scope.NetworkItems("Request_Duration").Length);
        }

        [Fact]
        public void PartialSuccessAttributesAcceptedAndRejectedEnvelopesToTheirCustomers()
        {
            using var scope = new NetworkTestScope();
            scope.Response = _ => new MockResponse(206).SetContent(
                "{\"itemsReceived\":6,\"itemsAccepted\":3,\"errors\":[{\"index\":1,\"statusCode\":503,\"message\":\"retry\"},{\"index\":3,\"statusCode\":400,\"message\":\"invalid\"},{\"index\":5,\"statusCode\":429,\"message\":\"retry\"}]}");
            scope.Send(MockStatsbeatScope.CreateRouteBatch(("a", EastUs), ("b", EastUs), ("a", EastUs), ("a", EastUs), ("c", EastUs), ("c", EastUs)));
            scope.Flush();

            Assert.Equal(1, scope.Requests);
            var successes = scope.NetworkItems("Request_Success_Count").ToDictionary(item => Data(item).Properties["cikey"], item => Assert.Single(Data(item).Metrics).Value);
            Assert.Equal(2, successes.Count);
            Assert.Equal(2, successes["a"]);
            Assert.Equal(1, successes["c"]);
            Assert.Equal(new[] { "b", "c" }, scope.NetworkItems("Retry_Count").Select(item => Data(item).Properties["cikey"]).OrderBy(key => key));
            Assert.Equal("a", Data(Assert.Single(scope.NetworkItems("Exception_Count"))).Properties["cikey"]);
            Assert.Equal(3, scope.NetworkItems("Request_Duration").Length);
            Assert.All(scope.Stats.TelemetryItems.Where(item => Name(item) != "Attach"), item =>
            {
                Assert.Contains(Data(item).Properties["cikey"], new[] { "a", "b", "c" });
                Assert.Equal("eastus-1", Data(item).Properties["host"]);
            });
        }

        [Fact]
        public void RedirectedRequestUsesTheHostThatAnswered()
        {
            using var scope = new NetworkTestScope();
            scope.Response = request => request.Uri.Host!.StartsWith("eastus", StringComparison.Ordinal)
                ? new MockResponse(307).AddHeader("Location", WestEurope + "v2.1/track")
                : new MockResponse(200);

            Assert.Equal(ExportResult.Success, scope.Send(MockStatsbeatScope.CreateRouteBatch(("us", EastUs))));
            scope.Flush();

            Assert.Equal(2, scope.Requests);
            var success = Assert.Single(scope.NetworkItems("Request_Success_Count"));
            Assert.Equal("westeurope-5", Data(success).Properties["host"]);
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_EU, success.InstrumentationKey);
            Assert.DoesNotContain(success.Tags.Keys, key => key.StartsWith("ai.cloud.", StringComparison.Ordinal) || key.StartsWith("ai.operation.", StringComparison.Ordinal));
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU,
                Assert.Single(scope.Stats.TelemetryItems.Where(item => Name(item) == "Attach")).InstrumentationKey);
        }

        [Theory]
        [InlineData("{\"itemsReceived\":2,\"itemsAccepted\":0,\"errors\":[{\"index\":0,\"statusCode\":503},{\"index\":0,\"statusCode\":400}]}")]
        [InlineData("{\"itemsReceived\":2,\"itemsAccepted\":1,\"errors\":[{\"index\":2,\"statusCode\":503}]}")]
        [InlineData("{\"itemsReceived\":2,\"itemsAccepted\":2,\"errors\":[{\"index\":0,\"statusCode\":503}]}")]
        public void InvalidPartialResponseDoesNotMisattributeCustomerOutcomes(string response)
        {
            using var scope = new NetworkTestScope();
            scope.Response = _ => new MockResponse(206).SetContent(response);
            scope.Send(MockStatsbeatScope.CreateRouteBatch(("one", EastUs), ("two", EastUs)));
            scope.Flush();

            Assert.Empty(scope.NetworkItems("Request_Success_Count"));
            Assert.Empty(scope.NetworkItems("Retry_Count"));
            Assert.Empty(scope.NetworkItems("Exception_Count"));
            Assert.Equal(2, scope.NetworkItems("Request_Duration").Length);
        }

        [Fact]
        public void PartialResponsePersistsAndReplaysOnlyTheRetryingCustomer()
        {
            using var scope = new NetworkTestScope(storage: true);
            scope.Response = _ => new MockResponse(206).SetContent(
                "{\"itemsReceived\":3,\"itemsAccepted\":1,\"errors\":[{\"index\":1,\"statusCode\":503,\"message\":\"retry\"},{\"index\":2,\"statusCode\":400,\"message\":\"invalid\"}]}");
            Assert.Equal(ExportResult.Success, scope.Send(MockStatsbeatScope.CreateRouteBatch(
                ("accepted", EastUs), ("retry", EastUs), ("rejected", EastUs))));
            scope.Flush();
            Assert.Equal("accepted", Data(Assert.Single(scope.NetworkItems("Request_Success_Count"))).Properties["cikey"]);
            Assert.Equal("retry", Data(Assert.Single(scope.NetworkItems("Retry_Count"))).Properties["cikey"]);
            Assert.Equal("rejected", Data(Assert.Single(scope.NetworkItems("Exception_Count"))).Properties["cikey"]);
            scope.Stats.TelemetryItems.Clear();

            scope.Response = _ => new MockResponse(200);
            var partition = scope.Transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();
            scope.Flush();

            Assert.Equal("retry", Data(Assert.Single(scope.NetworkItems("Request_Success_Count"))).Properties["cikey"]);
            Assert.Equal("retry", Data(Assert.Single(scope.NetworkItems("Request_Duration"))).Properties["cikey"]);
            Assert.DoesNotContain(scope.Stats.TelemetryItems, item => Name(item) == "Attach");
        }

        [Fact]
        public void PartialReplayAttributesErrorsWithinCoalescedBlobs()
        {
            using var scope = new NetworkTestScope(storage: true);
            scope.Response = _ => new MockResponse(503);
            scope.Send(MockStatsbeatScope.CreateRouteBatch(("one", EastUs)));
            scope.Send(MockStatsbeatScope.CreateRouteBatch(("two", EastUs)));
            scope.Flush();
            scope.Stats.TelemetryItems.Clear();

            string? rejectedKey = null;
            scope.Response = request =>
            {
                using var content = new MemoryStream();
                request.Content!.WriteTo(content, CancellationToken.None);
                var lines = System.Text.Encoding.UTF8.GetString(content.ToArray()).Split('\n');
                using var first = System.Text.Json.JsonDocument.Parse(lines[0]);
                rejectedKey = first.RootElement.GetProperty("iKey").GetString();
                return new MockResponse(206).SetContent(
                    "{\"itemsReceived\":2,\"itemsAccepted\":1,\"errors\":[{\"index\":0,\"statusCode\":400,\"message\":\"invalid\"}]}");
            };
            var partition = scope.Transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();
            scope.Flush();

            Assert.NotNull(rejectedKey);
            Assert.Equal(rejectedKey, Data(Assert.Single(scope.NetworkItems("Exception_Count"))).Properties["cikey"]);
            Assert.Equal(rejectedKey == "one" ? "two" : "one",
                Data(Assert.Single(scope.NetworkItems("Request_Success_Count"))).Properties["cikey"]);
        }

        [Fact]
        public void UnreadablePartialReplayResponseRetainsCustomerAttribution()
        {
            using var scope = new NetworkTestScope(storage: true);
            scope.Response = _ => new MockResponse(503);
            scope.Send(MockStatsbeatScope.CreateRouteBatch(("one", EastUs), ("two", EastUs)));
            scope.Flush();
            scope.Stats.TelemetryItems.Clear();

            scope.Response = _ => new MockResponse(206).SetContent("invalid-json");
            var partition = scope.Transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();
            scope.Flush();

            Assert.Equal(new[] { "one", "two" },
                scope.NetworkItems("Exception_Count").Select(item => Data(item).Properties["cikey"]).OrderBy(key => key));
            Assert.All(scope.NetworkItems("Exception_Count"), item => Assert.Equal(1, Assert.Single(Data(item).Metrics).Value));
            Assert.Equal(2, scope.NetworkItems("Request_Duration").Length);
            Assert.All(scope.NetworkItems("Request_Duration"), item => Assert.Equal(1, Assert.Single(Data(item).Metrics).Count));
            Assert.Empty(scope.NetworkItems("Request_Success_Count"));
        }

        [Theory]
        [InlineData(200)]
        [InlineData(206)]
        [InlineData(0)]
        public void ConfiguredStorageReplayRetainsCustomerKeyWhenRoutingEnabled(int status)
        {
            using var scope = new NetworkTestScope(configured: true, storage: true);
            scope.Response = _ => new MockResponse(503);
            var batch = MockStatsbeatScope.CreateRouteBatch(("configured", WestEurope), ("configured", WestEurope));
            Assert.Equal(ExportResult.Success, scope.Transmitter.TrackAsync(batch[0].TelemetryItems,
                new TelemetrySchemaTypeCounter(), TelemetryItemOrigin.AzureMonitorTraceExporter, false, CancellationToken.None).Result);
            scope.Flush();
            Assert.Equal("configured", Data(Assert.Single(scope.NetworkItems("Retry_Count"))).Properties["cikey"]);
            scope.Stats.TelemetryItems.Clear();

            scope.Response = _ => status switch
            {
                0 => throw new IOException("Mock replay failure"),
                206 => new MockResponse(206).SetContent(
                    "{\"itemsReceived\":2,\"itemsAccepted\":1,\"errors\":[{\"index\":1,\"statusCode\":400,\"message\":\"invalid\"}]}"),
                _ => new MockResponse(status)
            };
            scope.Transmitter._transmissionStateManager.ResetConsecutiveErrors();
            scope.Transmitter._transmissionStateManager.CloseTransmission();
            scope.Transmitter._transmitFromStorageHandler!.Drain();
            scope.Flush();

            Assert.Single(scope.NetworkItems(status == 0 ? "Exception_Count" : "Request_Success_Count"));
            Assert.Single(scope.NetworkItems("Request_Duration"));
            Assert.All(scope.Stats.TelemetryItems.Where(item => Name(item) != "Attach"),
                item => Assert.Equal("configured", Data(item).Properties["cikey"]));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ExceptionUsesTheRequestHostAndRecordsDuration(bool multiEndpoint)
        {
            using var scope = new NetworkTestScope(configured: true, multiEndpointEnabled: multiEndpoint);
            scope.Response = _ => throw new IOException("Mock network failure");

            var batch = MockStatsbeatScope.CreateRouteBatch(("us", EastUs));
            Assert.Equal(ExportResult.Failure, multiEndpoint
                ? scope.Send(batch)
                : scope.Transmitter.TrackAsync(batch[0].TelemetryItems, new TelemetrySchemaTypeCounter(),
                    TelemetryItemOrigin.AzureMonitorTraceExporter, false, CancellationToken.None).Result);
            scope.Flush();

            var exception = Assert.Single(scope.NetworkItems("Exception_Count"));
            Assert.Equal(multiEndpoint ? "eastus-1" : "westeurope-5", Data(exception).Properties["host"]);
            Assert.Equal(typeof(AggregateException).FullName, Data(exception).Properties["exceptionType"]);
            Assert.Equal(multiEndpoint ? StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU
                : StatsbeatConstants.Statsbeat_InstrumentationKey_EU, exception.InstrumentationKey);
            Assert.Empty(scope.NetworkItems("Request_Success_Count"));
            var duration = Data(Assert.Single(scope.NetworkItems("Request_Duration")));
            Assert.Equal(multiEndpoint ? "eastus-1" : "westeurope-5", duration.Properties["host"]);
            Assert.Equal(1, Assert.Single(duration.Metrics).Count);
            Assert.True(Assert.Single(duration.Metrics).Value > 0);
        }

        [Fact]
        public void AuthenticationGroupsCountTheirOwnRequests()
        {
            using var scope = new NetworkTestScope(credential: new TestCredential());
            var batch = MockStatsbeatScope.CreateRouteBatch(("ikey", EastUs));
            batch.GetOrAdd(EastUs, isAad: true).Add(
                MockStatsbeatScope.CreateRouteBatch(("aad", EastUs))[0].TelemetryItems[0]);

            Assert.Equal(ExportResult.Success, scope.Send(batch));
            scope.Flush();

            Assert.Equal(2, scope.Requests);
            Assert.Equal(2, scope.NetworkItems("Request_Success_Count").Length);
            Assert.All(scope.NetworkItems("Request_Success_Count"), item => Assert.Equal(1, Assert.Single(Data(item).Metrics).Value));
        }

        [Fact]
        public void MissingCredentialAndCancellationDoNotRecordNetworkRequests()
        {
            using var scope = new NetworkTestScope();
            var batch = new EndpointRouteBatch();
            batch.GetOrAdd(EastUs, isAad: true).Add(
                MockStatsbeatScope.CreateRouteBatch(("aad", EastUs))[0].TelemetryItems[0]);
            Assert.Equal(ExportResult.Failure, scope.Send(batch));
            Assert.Equal(ExportResult.Failure, scope.Transmitter.Track(
                MockStatsbeatScope.CreateRouteBatch(("cancelled", EastUs)),
                TelemetryItemOrigin.AzureMonitorTraceExporter, new CancellationToken(canceled: true)));
            scope.Flush();

            Assert.Equal(0, scope.Requests);
            Assert.All(scope.Stats.TelemetryItems, item => Assert.Equal("Attach", Name(item)));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void OfflineReplayRecordsNetworkStatsWithoutRefreshingAttach(bool failReplay)
        {
            using var scope = new NetworkTestScope(storage: true);
            scope.Response = _ => new MockResponse(503);
            var batch = MockStatsbeatScope.CreateRouteBatch(("one", WestEurope), ("two", WestEurope));
            Assert.Equal(ExportResult.Success, scope.Send(batch));
            Assert.Equal(ExportResult.Success, scope.Send(batch));
            Assert.Equal(1, scope.Requests);
            scope.Flush();
            Assert.Equal(2, scope.NetworkItems("Retry_Count").Length);
            scope.Stats.TelemetryItems.Clear();

            scope.Response = _ => failReplay ? throw new IOException("Mock replay failure") : new MockResponse(200);
            var partition = scope.Transmitter._multiEndpointStorage!.TryGet(WestEurope)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();
            scope.Flush();

            Assert.Equal(2, scope.Requests);
            var network = scope.NetworkItems(failReplay ? "Exception_Count" : "Request_Success_Count");
            Assert.Equal(new[] { "one", "two" }, network.Select(item => Data(item).Properties["cikey"]).OrderBy(key => key));
            Assert.All(network, item =>
            {
                Assert.Equal("westeurope-5", Data(item).Properties["host"]);
                Assert.Equal(1, Assert.Single(Data(item).Metrics).Value);
                Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_EU, item.InstrumentationKey);
            });
            Assert.Equal(2, scope.NetworkItems("Request_Duration").Length);
            Assert.All(scope.NetworkItems("Request_Duration"), item => Assert.Equal(1, Assert.Single(Data(item).Metrics).Count));
            Assert.DoesNotContain(scope.Stats.TelemetryItems, item => Name(item) == "Attach");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void AnotherStatsOwnerCannotExportTheseMeasurements(bool otherMultiEndpoint)
        {
            using var scope = new MockStatsbeatScope();
            using var first = new AzureMonitorStatsbeat(ConnectionVars.CreateUnconfigured(), scope.Platform, multiEndpointEnabled: true);
            using var second = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(CustomerConnectionString),
                scope.Platform, multiEndpointEnabled: otherMultiEndpoint);
            using var firstProvider = first._statsbeatMeterProvider!;
            using var secondProvider = second._statsbeatMeterProvider!;

            Parallel.For(0, 100, _ => first.NetworkSdkStatsManager!.TrackSuccess("eastus-1.in.applicationinsights.azure.com"));
            Assert.True(secondProvider.ForceFlush());
            Assert.DoesNotContain(scope.TelemetryItems, item => Name(item) == "Request_Success_Count");
            scope.TelemetryItems.Clear();
            Assert.True(firstProvider.ForceFlush());
            Assert.Equal(100, Assert.Single(Data(Assert.Single(scope.TelemetryItems)).Metrics).Value);

            scope.TelemetryItems.Clear();
            second.NetworkSdkStatsManager!.TrackSuccess("westeurope-5.in.applicationinsights.azure.com");
            Assert.True(firstProvider.ForceFlush());
            Assert.Empty(scope.TelemetryItems);
            Assert.True(secondProvider.ForceFlush());
            var success = Data(Assert.Single(scope.TelemetryItems));
            Assert.Equal(otherMultiEndpoint ? "N/A" : "configured", success.Properties["cikey"]);
        }

        [Fact]
        public void ConnectionStringOverrideWinsForEveryNetworkHost()
        {
            using var scope = new MockStatsbeatScope();
            const string connectionString = "InstrumentationKey=override;IngestionEndpoint=http://localhost:4318/";
            scope.Add(connectionString);
            scope.Platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, connectionString);
            using var stats = new AzureMonitorStatsbeat(ConnectionVars.CreateUnconfigured(), scope.Platform, multiEndpointEnabled: true);
            using var provider = stats._statsbeatMeterProvider!;
            stats.NetworkSdkStatsManager!.TrackSuccess("eastus-1.in.applicationinsights.azure.com");
            stats.NetworkSdkStatsManager.TrackSuccess("westeurope-5.in.applicationinsights.azure.com");
            Assert.True(provider.ForceFlush());

            Assert.Equal(2, scope.TelemetryItems.Count);
            Assert.All(scope.TelemetryItems, item => Assert.Equal("override", item.InstrumentationKey));
            var transmitter = Assert.IsType<MockTransmitter>(TransmitterFactory.Instance._transmitters[connectionString]);
            Assert.Equal(1, transmitter.TrackAsyncCallCount);
            Assert.Empty(transmitter.Sends);
        }

        [Fact]
        public void NetworkCardinalityIsBoundedAndDoesNotExportHostlessOverflow()
        {
            using var scope = new MockStatsbeatScope();
            using var stats = new AzureMonitorStatsbeat(ConnectionVars.CreateUnconfigured(), scope.Platform, multiEndpointEnabled: true);
            using var provider = stats._statsbeatMeterProvider!;
            for (int i = 0; i < 2100; i++)
            {
                stats.NetworkSdkStatsManager!.TrackSuccess($"eastus-{i}.in.applicationinsights.azure.com");
            }
            Assert.True(provider.ForceFlush());

            Assert.InRange(scope.TelemetryItems.Count, 1999, 2000);
            Assert.All(scope.TelemetryItems, item =>
            {
                Assert.Equal("N/A", Data(item).Properties["cikey"]);
                Assert.StartsWith("eastus-", Data(item).Properties["host"]);
                Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, item.InstrumentationKey);
                Assert.Equal(1, Assert.Single(Data(item).Metrics).Value);
            });
        }

        [Fact]
        public void UnknownNetworkHostsUseTheExistingNonEuFallback()
        {
            using var scope = new NetworkTestScope(configured: true);
            Assert.Equal(ExportResult.Success, scope.Send(
                MockStatsbeatScope.CreateRouteBatch(("unknown", "https://unknown.example.invalid/"))));
            scope.Flush();

            var success = Assert.Single(scope.NetworkItems("Request_Success_Count"));
            Assert.Equal("unknown", Data(success).Properties["host"]);
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU, success.InstrumentationKey);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ConfiguredTransmissionRetainsItsCustomerKeyAndDestination(bool multiEndpoint)
        {
            using var scope = new NetworkTestScope(configured: true, multiEndpointEnabled: multiEndpoint);
            var batch = MockStatsbeatScope.CreateRouteBatch(("configured", WestEurope));
            Assert.Equal(ExportResult.Success, scope.Transmitter.TrackAsync(batch[0].TelemetryItems,
                new TelemetrySchemaTypeCounter(), TelemetryItemOrigin.AzureMonitorTraceExporter, false, CancellationToken.None).Result);
            scope.Flush();

            Assert.Equal(1, scope.Requests);
            var success = Assert.Single(scope.NetworkItems("Request_Success_Count"));
            Assert.Equal("configured", Data(success).Properties["cikey"]);
            Assert.Equal("westeurope-5", Data(success).Properties["host"]);
            Assert.Equal(StatsbeatConstants.Statsbeat_InstrumentationKey_EU, success.InstrumentationKey);
            Assert.DoesNotContain(success.Tags.Keys, key => key.StartsWith("ai.cloud.", StringComparison.Ordinal) || key.StartsWith("ai.operation.", StringComparison.Ordinal));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DisposalFlushesNetworkStatsBeforeReleasingTheirInstruments(bool multiEndpoint)
        {
            using var scope = new MockStatsbeatScope();
            using var stats = new AzureMonitorStatsbeat(ConnectionStringParser.GetValues(CustomerConnectionString),
                scope.Platform, multiEndpointEnabled: multiEndpoint);
            stats.NetworkSdkStatsManager!.TrackSuccess("westeurope-5.in.applicationinsights.azure.com");
            stats.Dispose();

            Assert.True(SpinWait.SpinUntil(() =>
            {
                lock (scope.TelemetryItems)
                {
                    return scope.TelemetryItems.Any(item => Name(item) == "Request_Success_Count");
                }
            }, TimeSpan.FromSeconds(5)));
        }

        private static MetricsData Data(TelemetryItem item) => Assert.IsType<MetricsData>(item.Data.BaseData);
        private static string Name(TelemetryItem item) => Assert.Single(Data(item).Metrics).Name;

        private sealed class NetworkTestScope : IDisposable
        {
            private readonly string? _storageRoot;
            private readonly bool _previousEagerDrainDisabled = TransmitFromStorageHandler.DisableEagerDrainForTesting;
            internal MockStatsbeatScope Stats { get; } = new();
            internal AzureMonitorTransmitter Transmitter { get; }
            internal Func<Request, MockResponse> Response { get; set; } = _ => new MockResponse(200);
            internal int Requests { get; private set; }

            internal NetworkTestScope(bool configured = false, bool storage = false, TokenCredential? credential = null, bool multiEndpointEnabled = true)
            {
                TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
                _storageRoot = storage ? Path.Combine(Path.GetTempPath(), "network-stats-" + Guid.NewGuid().ToString("N")) : null;
                Transmitter = new AzureMonitorTransmitter(new AzureMonitorExporterOptions
                {
                    ConnectionString = configured ? CustomerConnectionString : null,
                    DisableOfflineStorage = !storage,
                    StorageDirectory = _storageRoot,
                    Credential = credential,
                    Transport = new MockTransport(request =>
                    {
                        Requests++;
                        return Response(request);
                    }),
                }, Stats.Platform, multiEndpointEnabled);
            }

            internal ExportResult Send(EndpointRouteBatch batch)
                => Transmitter.Track(batch, TelemetryItemOrigin.AzureMonitorTraceExporter, CancellationToken.None);

            internal void Flush() => Assert.True(Transmitter._statsbeat!._statsbeatMeterProvider!.ForceFlush());

            internal TelemetryItem[] NetworkItems(string metric)
                => Stats.TelemetryItems.Where(item => Name(item) == metric).ToArray();

            public void Dispose()
            {
                Transmitter._statsbeat?._statsbeatMeterProvider?.Dispose();
                Transmitter.Dispose();
                Stats.Dispose();
                TransmitFromStorageHandler.DisableEagerDrainForTesting = _previousEagerDrainDisabled;
                if (_storageRoot != null && Directory.Exists(_storageRoot))
                {
                    Directory.Delete(_storageRoot, recursive: true);
                }
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("test-token", DateTimeOffset.UtcNow.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}
