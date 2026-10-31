// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Tests for the distro SDK statistics routing AppContext switch. Isolated into its own
    /// class + collection because the switch is process-wide; concurrent execution with the
    /// routing-off tests in <see cref="StatsbeatTests"/> would race.
    /// </summary>
    [Collection(nameof(DistroSdkStatsRoutingCollection))]
    public class DistroSdkStatsRoutingTests : IDisposable
    {
        private readonly bool _previousSwitchValue;
        private readonly bool _hadSwitch;
        private readonly MockStatsbeatScope _stats = new();

        public DistroSdkStatsRoutingTests()
        {
            _stats.AddEndpoint("data.example.invalid");
            _stats.AddEndpoint("bare.host.invalid");
            _stats.AddEndpoint("full.url.invalid");
            _stats.AddEndpoint("stats.example.invalid");
            _hadSwitch = AppContext.TryGetSwitch(
                StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out _previousSwitchValue);
            AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, true);
        }

        public void Dispose()
        {
            _stats.Dispose();
            if (_hadSwitch)
            {
                AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, _previousSwitchValue);
            }
            else
            {
                // No clean "unset" API; the typical pattern is to leave it false.
                AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, false);
            }
        }

        [Theory]
        [MemberData(nameof(StatsbeatTests.EuEndpoints), MemberType = typeof(StatsbeatTests))]
        [MemberData(nameof(StatsbeatTests.NonEuEndpoints), MemberType = typeof(StatsbeatTests))]
        [InlineData("foo")]
        public async Task DistroSwitchOn_AllCustomerRegions_RequestStandardConfig(string region)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{region}.in.applicationinsights.azure.com/";
            var requestedUrls = new ConcurrentBag<string>();
            using var handler = new StubHandler(request =>
            {
                requestedUrls.Add(request.RequestUri!.AbsoluteUri);
                return OkJson("{\"ver\":1,\"enabled\":false}");
            });
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionStringParser.GetValues(customerCs), _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.Equal("https://data.stats.monitor.azure.com/cfg/v1.json", Assert.Single(requestedUrls));
        }

        [Fact]
        public async Task DistroSwitchOn_ConstructorDoesNotThrow_ForUnknownRegion()
        {
            // Counterpart to StatsbeatIsNotInitializedForUnknownRegions: when the distro
            // switch is on the constructor must complete without throwing even if the
            // customer connection string maps to an unknown region. SDK statistics
            // initialization is deferred to a background task (which fetches the remote
            // configuration); the constructor itself only kicks that task off.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customerCs);

            using var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":false}"));
            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, _stats.Platform, handler);
            await AwaitInitAsync(statsBeatInstance);

            Assert.Null(statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_SlowOrUnreachableConfigEndpoint_DoesNotBlockConstruction()
        {
            // Customer impact contract: even when the SDK statistics configuration endpoint
            // hangs for the full attempt timeout (per-attempt 10s) and all retries, the
            // AzureMonitorStatsbeat constructor — and by extension every downstream
            // MeterProvider build in the customer's pipeline — must complete promptly.
            //
            // We simulate a 20-second-unreachable endpoint with a handler that blocks
            // indefinitely until the test releases it during cleanup, and assert the
            // constructor returns in well under 1 second. (Reality is sub-millisecond;
            // the 1s budget is just slack for CI noise.)
            var releaseHandler = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
            using var handler = new BlockingHandler(releaseHandler.Task);

            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://westus.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customerCs);
            var stopwatch = Stopwatch.StartNew();
            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, _stats.Platform, handler);
            stopwatch.Stop();

            try
            {
                Assert.True(
                    stopwatch.Elapsed < TimeSpan.FromSeconds(1),
                    $"Constructor should not block on the SDK statistics config fetch; took {stopwatch.ElapsedMilliseconds}ms.");

                // The background fetch is still pending against the blocking handler — the
                // MeterProvider has not been built yet, which is the expected steady state
                // while the config endpoint is unreachable.
                Assert.Null(statsBeatInstance._statsbeat_ConnectionString);
                Assert.Null(statsBeatInstance._statsbeatMeterProvider);
            }
            finally
            {
                // Release the blocked background fetch so it can complete (with a fake
                // success response) and tear down its HttpClient before xUnit moves on.
                // Without this the Task.Run hangs on the inner GetAsync until the
                // per-attempt 10s timeout fires, repeating MaxAttempts times — leaking
                // ~30 seconds of background work across test runs.
                releaseHandler.TrySetResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"ver\":1,\"enabled\":false}", System.Text.Encoding.UTF8, "application/json"),
                });
                await AwaitInitAsync(statsBeatInstance);
            }
        }

        private sealed class BlockingHandler : HttpMessageHandler
        {
            private readonly Task<HttpResponseMessage> _gate;

            public BlockingHandler(Task<HttpResponseMessage> gate)
            {
                _gate = gate;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // Block until either the test releases the gate or the per-attempt
                // HttpClient timeout fires (which surfaces as cancellation).
                // Note: Task.WaitAsync(CancellationToken) is .NET 6+; this polyfill keeps the test buildable for net462.
                var cancelTcs = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
                using var registration = cancellationToken.Register(static state => ((TaskCompletionSource<HttpResponseMessage>)state!).TrySetCanceled(), cancelTcs);
                var completed = await Task.WhenAny(_gate, cancelTcs.Task).ConfigureAwait(false);
                return await completed.ConfigureAwait(false);
            }
        }

        // -----------------------------------------------------------------------------
        // End-to-end behavior of the distro path: config fetch → MeterProvider build.
        // Each scenario uses a deterministic in-process StubHandler and awaits the
        // exposed _configInitializationTask so assertions reflect the post-fetch state.
        // -----------------------------------------------------------------------------

        private const string NonEuCustomerCs =
            "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://westus.in.applicationinsights.azure.com/";

        private const string EuCustomerCs =
            "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://westeurope.in.applicationinsights.azure.com/";

        private const string UnknownRegionCustomerCs =
            "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

        [Fact]
        public async Task DistroSwitchOn_ConfigReturnsUrl_BuildsMeterProviderWithConfigUrl()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.NotNull(statsbeat._statsbeat_ConnectionString);
            Assert.Contains("data.example.invalid", statsbeat._statsbeat_ConnectionString!);
            // Defense in depth: must NOT have fallen back to the legacy AI endpoints.
            Assert.DoesNotContain("applicationinsights.azure.com", statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigUrlMissingScheme_PrependsHttps()
        {
            // Server contract returns a bare host (e.g. "bare.host.invalid"); the exporter
            // must produce a usable IngestionEndpoint URL from it by prepending https://.
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"bare.host.invalid\"}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeat_ConnectionString);
            Assert.Contains("IngestionEndpoint=https://bare.host.invalid/", statsbeat._statsbeat_ConnectionString!);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigUrlHasScheme_PreservesScheme()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"https://full.url.invalid/\"}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            // The trailing slash is normalized away then re-added; the scheme is not duplicated.
            Assert.Contains("IngestionEndpoint=https://full.url.invalid/", statsbeat._statsbeat_ConnectionString!);
            Assert.DoesNotContain("https://https://", statsbeat._statsbeat_ConnectionString);
        }

        // The distro changes only the destination. Envelopes must keep the SDK statistics
        // instrumentation key the legacy endpoint receives - never a placeholder, and never
        // the customer's own key, which is carried separately as the cikey dimension.
        private const string DistinctCustomerIkey = "11111111-2222-3333-4444-555555555555";

        public static TheoryData<string, string> ConfigUrlIkeyCases => new()
        {
            { "westus", StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU },
            { "westeurope", StatsbeatConstants.Statsbeat_InstrumentationKey_EU },
            { "foo", StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU },
        };

        [Theory]
        [MemberData(nameof(ConfigUrlIkeyCases))]
        public async Task DistroSwitchOn_ConfigReturnsUrl_UsesSdkStatsInstrumentationKey(string region, string expectedIkey)
        {
            var requestedUrls = new ConcurrentBag<string>();
            using var handler = new StubHandler(request =>
            {
                requestedUrls.Add(request.RequestUri!.AbsoluteUri);
                return request.RequestUri.AbsoluteUri == StatsbeatConstants.SdkStatsConfigUrl_NonEU
                    ? OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}")
                    : OkJson("{\"ver\":1,\"enabled\":false}");
            });
            var vars = ConnectionStringParser.GetValues(
                $"InstrumentationKey={DistinctCustomerIkey};IngestionEndpoint=https://{region}.in.applicationinsights.azure.com/");

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, Assert.Single(requestedUrls));
            Assert.Equal(
                $"InstrumentationKey={expectedIkey};IngestionEndpoint=https://data.example.invalid/",
                statsbeat._statsbeat_ConnectionString);

            var exporterVars = ConnectionStringParser.GetValues(statsbeat._statsbeat_ConnectionString!);
            Assert.Equal(expectedIkey, exporterVars.InstrumentationKey);
            Assert.NotEqual(DistinctCustomerIkey, exporterVars.InstrumentationKey);
            Assert.NotEqual("00000000-0000-0000-0000-000000000000", exporterVars.InstrumentationKey);

            Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
            var item = Assert.Single(_stats.TelemetryItems);
            Assert.Equal(expectedIkey, item.InstrumentationKey);
            Assert.Equal(DistinctCustomerIkey, ((MetricsData)item.Data.BaseData).Properties["cikey"]);
        }

        [Theory]
        [InlineData("bare.host.invalid")]
        [InlineData("bare.host.invalid/")]
        [InlineData("https://bare.host.invalid")]
        [InlineData("https://bare.host.invalid/")]
        public void BuildConnectionStringFromHost_KeepsInstrumentationKey(string host)
        {
            Assert.Equal(
                "InstrumentationKey=" + StatsbeatConstants.Statsbeat_InstrumentationKey_EU + ";IngestionEndpoint=https://bare.host.invalid/",
                AzureMonitorStatsbeat.BuildConnectionStringFromHost(host, StatsbeatConstants.Statsbeat_InstrumentationKey_EU));
        }

        /// <summary>
        /// Literals rather than references, so regrouping the constants cannot silently change
        /// which resource SDK statistics are attributed to.
        /// </summary>
        [Fact]
        public void SdkStatsInstrumentationKeysAreUnchanged()
        {
            Assert.Equal("c4a29126-a7cb-47e5-b348-11414998b11e", StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU);
            Assert.Equal("7dc56bab-3c0c-4e9f-9ebb-d1acadee8d0f", StatsbeatConstants.Statsbeat_InstrumentationKey_EU);
            Assert.Equal(
                "InstrumentationKey=c4a29126-a7cb-47e5-b348-11414998b11e;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/;LiveEndpoint=https://westus.livediagnostics.monitor.azure.com/",
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU);
            Assert.Equal(
                "InstrumentationKey=7dc56bab-3c0c-4e9f-9ebb-d1acadee8d0f;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/",
                StatsbeatConstants.Statsbeat_ConnectionString_EU);
        }

        [Theory]
        [MemberData(nameof(ConfigUrlIkeyCases))]
        public void GetSdkStatsInstrumentationKey_PreservesCustomerRegion(string region, string expectedIkey)
        {
            var ingestionEndpoint = $"https://{region}.in.applicationinsights.azure.com/";

            Assert.Equal(expectedIkey, AzureMonitorStatsbeat.GetSdkStatsInstrumentationKey(ingestionEndpoint));
        }

        [Fact]
        public async Task DistroSwitchOn_RemoteDisabled_DoesNotBuildMeterProvider()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":false}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            // Explicit kill switch: no MeterProvider, no fallback.
            Assert.Null(statsbeat._statsbeatMeterProvider);
            Assert.Null(statsbeat._statsbeat_ConnectionString);
        }

        [Theory]
        [InlineData(null, StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU)]
        [InlineData(NonEuCustomerCs, StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU)]
        [InlineData(EuCustomerCs, StatsbeatConstants.Statsbeat_InstrumentationKey_EU)]
        public async Task MultiEndpointAttachUsesStandardCollectorWithRegionalKeys(string? customerCs, string defaultIkey)
        {
            var requestedUrls = new ConcurrentBag<string>();
            using var handler = new StubHandler(request =>
            {
                requestedUrls.Add(request.RequestUri!.AbsoluteUri);
                return request.RequestUri.AbsoluteUri == StatsbeatConstants.SdkStatsConfigUrl_NonEU
                    ? OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"stats.example.invalid\"}")
                    : OkJson("{\"ver\":1,\"enabled\":false}");
            });
            using var statsbeat = new AzureMonitorStatsbeat(
                customerCs == null ? ConnectionVars.CreateUnconfigured() : ConnectionStringParser.GetValues(customerCs),
                _stats.Platform, handler, multiEndpointEnabled: true);
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(
                ("us", "https://eastus-1.in.applicationinsights.azure.com/"),
                ("eu", "https://westeurope-5.in.applicationinsights.azure.com/")));

            await AwaitInitAsync(statsbeat);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, Assert.Single(requestedUrls));
            Assert.Equal(
                $"InstrumentationKey={defaultIkey};IngestionEndpoint=https://stats.example.invalid/",
                statsbeat._statsbeat_ConnectionString);
            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            if (customerCs == null)
            {
                Assert.Null(statsbeat.NetworkSdkStatsManager);
            }
            Assert.True(statsbeat._statsbeatMeterProvider.ForceFlush());
            Assert.Equal(2, _stats.TelemetryItems.Count);
            Assert.Contains(_stats.TelemetryItems, item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                && ((MetricsData)item.Data.BaseData).Properties["cikey"] == "eu");
            Assert.Contains(_stats.TelemetryItems, item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU
                && ((MetricsData)item.Data.BaseData).Properties["cikey"] == "us");
            Assert.All(_stats.TelemetryItems, item =>
                Assert.Equal(_stats.ResourceProviderId, ((MetricsData)item.Data.BaseData).Properties["rpId"]));
            var send = Assert.Single(GetTransmitter("stats.example.invalid", defaultIkey).Sends);
            Assert.Equal("https://stats.example.invalid/", send.IngestionEndpoint);
            Assert.Equal(2, send.TelemetryItems.Length);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task StandardCollectorConfigurationControlsBothRegions(bool enabled)
        {
            var requestedUrls = new ConcurrentBag<string>();
            using var handler = new StubHandler(request =>
            {
                requestedUrls.Add(request.RequestUri!.AbsoluteUri);
                var requestEnabled = request.RequestUri.AbsoluteUri == StatsbeatConstants.SdkStatsConfigUrl_NonEU ? enabled : !enabled;
                return requestEnabled
                    ? OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"stats.example.invalid\"}")
                    : OkJson("{\"ver\":1,\"enabled\":false}");
            });
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(
                ("us", "https://eastus-1.in.applicationinsights.azure.com/"),
                ("eu", "https://westeurope-5.in.applicationinsights.azure.com/")));

            await AwaitInitAsync(statsbeat);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, Assert.Single(requestedUrls));
            if (enabled)
            {
                Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
                Assert.Equal(new[] { "eu", "us" },
                    _stats.TelemetryItems.Select(item => ((MetricsData)item.Data.BaseData).Properties["cikey"]).OrderBy(key => key));
            }
            else
            {
                Assert.Null(statsbeat._statsbeatMeterProvider);
                Assert.Null(statsbeat._statsbeat_ConnectionString);
                Assert.Equal(0, statsbeat._multiEndpointStats!.Registry.Count);
                statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(
                    ("late-eu", "https://westeurope-5.in.applicationinsights.azure.com/")));
                Assert.Equal(0, statsbeat._multiEndpointStats.Registry.Count);
                Assert.Empty(_stats.TelemetryItems);
            }
        }

        [Theory]
        [MemberData(nameof(ConfigUrlIkeyCases))]
        public async Task MultiEndpointDistroFeatureAndNetworkUseStandardCollector(string region, string expectedIkey)
        {
            using var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"stats.example.invalid\"}"));
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionStringParser.GetValues(
                    $"InstrumentationKey={DistinctCustomerIkey};IngestionEndpoint=https://{region}.in.applicationinsights.azure.com/"),
                _stats.Platform, handler, multiEndpointEnabled: true);
            await AwaitInitAsync(statsbeat);

            using var featureMeter = new Meter(StatsbeatConstants.DistroFeatureSdkStatsMeterName);
            using var networkMeter = new Meter(StatsbeatConstants.DistroNetworkSdkStatsMeterName);
            featureMeter.CreateObservableGauge("Feature", () => new Measurement<int>(1,
                new KeyValuePair<string, object?>("cikey", DistinctCustomerIkey)));
            networkMeter.CreateObservableGauge("Request_Success_Count", () => new Measurement<int>(1,
                new KeyValuePair<string, object?>("cikey", DistinctCustomerIkey)));

            Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Equal(2, _stats.TelemetryItems.Count);
            Assert.All(_stats.TelemetryItems, item =>
            {
                Assert.Equal(expectedIkey, item.InstrumentationKey);
                Assert.Equal(DistinctCustomerIkey, ((MetricsData)item.Data.BaseData).Properties["cikey"]);
            });
            Assert.Equal(2, Assert.Single(GetTransmitter("stats.example.invalid", expectedIkey).Sends).TelemetryItems.Length);
        }

        [Fact]
        public async Task MultiEndpointConfigFailureFallsBackWithinEachRegion()
        {
            var requestedUrls = new ConcurrentBag<string>();
            using var handler = new StubHandler(request =>
            {
                requestedUrls.Add(request.RequestUri!.AbsoluteUri);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            });
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(
                ("us", "https://eastus-1.in.applicationinsights.azure.com/"),
                ("eu", "https://westeurope-5.in.applicationinsights.azure.com/")));
            await AwaitInitAsync(statsbeat);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, Assert.Single(requestedUrls));
            Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.Equal(2, _stats.TelemetryItems.Count);
            Assert.Contains(_stats.TelemetryItems, item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_EU);
            Assert.Contains(_stats.TelemetryItems, item => item.InstrumentationKey == StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU);
            var sends = Assert.IsType<MockTransmitter>(
                TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_NonEU]).Sends;
            Assert.Equal(2, sends.Count);
            Assert.Contains(sends, send => send.IngestionEndpoint == "https://westus-0.in.applicationinsights.azure.com/");
            Assert.Contains(sends, send => send.IngestionEndpoint == "https://westeurope-5.in.applicationinsights.azure.com/");
        }

        [Theory]
        [InlineData("https://override.example.invalid/")]
        [InlineData("http://localhost:4318/")]
        public void MultiEndpointOverrideSkipsCollectorConfiguration(string endpoint)
        {
            bool requested = false;
            using var handler = new StubHandler(_ =>
            {
                requested = true;
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            });
            var connectionString = $"InstrumentationKey={Guid.NewGuid()};IngestionEndpoint={endpoint}";
            _stats.Add(connectionString);
            _stats.Platform.SetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING, connectionString);
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);
            statsbeat.ObserveAttach(MockStatsbeatScope.CreateRouteBatch(
                ("us", "https://eastus-1.in.applicationinsights.azure.com/"),
                ("eu", "https://westeurope-5.in.applicationinsights.azure.com/")));

            Assert.Null(statsbeat._configInitializationTask);
            Assert.True(statsbeat._statsbeatMeterProvider!.ForceFlush());
            Assert.False(requested);
            Assert.Equal(2, _stats.TelemetryItems.Count);
            Assert.All(_stats.TelemetryItems, item =>
                Assert.Equal(ConnectionStringParser.GetValues(connectionString).InstrumentationKey, item.InstrumentationKey));
            var transmitter = Assert.IsType<MockTransmitter>(TransmitterFactory.Instance._transmitters[connectionString]);
            Assert.Equal(1, transmitter.TrackAsyncCallCount);
            Assert.Empty(transmitter.Sends);
            Assert.All(_stats.TelemetryItems, item => Assert.DoesNotContain(
                SemanticConventions.AttributeMicrosoftIngestionEndpoint, ((MetricsData)item.Data.BaseData).Properties.Keys));
        }

        [Fact]
        public async Task DisposalDuringCollectorConfigurationDoesNotAcquireSenders()
        {
            var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            using var handler = new DelayedConfigHandler(release.Task);
            var nonEu = Assert.IsType<MockTransmitter>(
                TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_NonEU]);
            var eu = Assert.IsType<MockTransmitter>(
                TransmitterFactory.Instance._transmitters[StatsbeatConstants.Statsbeat_ConnectionString_EU]);
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);

            statsbeat.Dispose();
            release.SetResult(true);
            await AwaitInitAsync(statsbeat);

            Assert.Null(statsbeat._statsbeatMeterProvider);
            Assert.Equal(0, nonEu.DisposeCallCount);
            Assert.Equal(0, eu.DisposeCallCount);
            Assert.False(statsbeat._multiEndpointStats!.HasDestination);
            Assert.Empty(_stats.TelemetryItems);
        }

        [Fact]
        public async Task DisposingCollectorReleasesTheSharedRoutedSender()
        {
            using var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"stats.example.invalid\"}"));
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);
            await AwaitInitAsync(statsbeat);
            var eu = GetTransmitter("stats.example.invalid", StatsbeatConstants.Statsbeat_InstrumentationKey_EU);
            var nonEu = GetTransmitter("stats.example.invalid", StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU);

            statsbeat.Dispose();

            Assert.True(SpinWait.SpinUntil(
                () => nonEu.DisposeCallCount == 1 && !statsbeat._multiEndpointStats!.HasDestination, TimeSpan.FromSeconds(5)));
            Assert.Equal(0, eu.DisposeCallCount);
        }

        [Fact]
        public async Task RoutingOnlyAttachHonorsRemoteDisablement()
        {
            using var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":false}"));
            using var statsbeat = new AzureMonitorStatsbeat(
                ConnectionVars.CreateUnconfigured(), _stats.Platform, handler, multiEndpointEnabled: true);

            await AwaitInitAsync(statsbeat);

            Assert.Null(statsbeat._statsbeatMeterProvider);
            Assert.Null(statsbeat._statsbeat_ConnectionString);
            Assert.Null(statsbeat.NetworkSdkStatsManager);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigFetchFails_FallsBackToLegacyNonEuEndpoint()
        {
            var handler = new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.NotFound));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigFetchFails_FallsBackToLegacyEuEndpoint()
        {
            var handler = new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.InternalServerError));
            var vars = ConnectionStringParser.GetValues(EuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_EU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigFetchFails_UnknownRegion_FallsBackToLegacyNonEuEndpoint()
        {
            // GetStatsbeatConnectionString returns null for unknown regions; the distro
            // path defaults to non-EU rather than throwing.
            var handler = new StubHandler(_ => throw new HttpRequestException("dns failure"));
            var vars = ConnectionStringParser.GetValues(UnknownRegionCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigMalformedJson_FallsBackToLegacyEndpoint()
        {
            var handler = new StubHandler(_ => OkJson("not a json document"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigVerMismatch_FallsBackToLegacyEndpoint()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":99,\"enabled\":true,\"url\":\"x\"}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigEnabledTrueWithoutUrl_FallsBackToLegacyEndpoint()
        {
            // ver=1, enabled=true, url omitted entirely — the "incomplete control plane"
            // case. Must fall back so SDK statistics keep flowing.
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, _stats.Platform, handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeatMeterProvider);
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public void GetLegacyFallbackConnectionString_KnownRegion_ReturnsRegionMatched()
        {
            var euVars = ConnectionStringParser.GetValues(EuCustomerCs);
            var nonEuVars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_EU,
                AzureMonitorStatsbeat.GetLegacyFallbackConnectionString(euVars.IngestionEndpoint));
            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                AzureMonitorStatsbeat.GetLegacyFallbackConnectionString(nonEuVars.IngestionEndpoint));
        }

        [Fact]
        public void GetLegacyFallbackConnectionString_UnknownRegion_DefaultsToNonEu()
        {
            var vars = ConnectionStringParser.GetValues(UnknownRegionCustomerCs);

            Assert.Equal(
                StatsbeatConstants.Statsbeat_ConnectionString_NonEU,
                AzureMonitorStatsbeat.GetLegacyFallbackConnectionString(vars.IngestionEndpoint));
        }

        /// <summary>
        /// Awaits the AzureMonitorStatsbeat distro-path background initialization task with
        /// a generous timeout. Fails fast if the background task never completes.
        /// </summary>
        private static async Task AwaitInitAsync(AzureMonitorStatsbeat statsbeat)
        {
            var task = statsbeat._configInitializationTask;
            Assert.NotNull(task);
            // Note: Task.WaitAsync(CancellationToken) is .NET 6+; this polyfill keeps the test buildable for net462.
            var timeout = Task.Delay(TimeSpan.FromSeconds(10));
            var completed = await Task.WhenAny(task!, timeout).ConfigureAwait(false);
            if (completed == timeout)
            {
                throw new TimeoutException("AzureMonitorStatsbeat distro-path background initialization did not complete within 10 seconds.");
            }
            await task!.ConfigureAwait(false);
        }

        private static HttpResponseMessage OkJson(string body) =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

        private static MockTransmitter GetTransmitter(string host, string instrumentationKey) =>
            Assert.IsType<MockTransmitter>(TransmitterFactory.Instance._transmitters[
                AzureMonitorStatsbeat.BuildConnectionStringFromHost(host, instrumentationKey)]);

        private sealed class DelayedConfigHandler : HttpMessageHandler
        {
            private readonly Task _release;

            internal DelayedConfigHandler(Task release) => _release = release;

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                await _release.ConfigureAwait(false);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        private sealed class StubHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder;

            public StubHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
            {
                _responder = responder;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return Task.FromResult(_responder(request));
            }
        }
    }
}
