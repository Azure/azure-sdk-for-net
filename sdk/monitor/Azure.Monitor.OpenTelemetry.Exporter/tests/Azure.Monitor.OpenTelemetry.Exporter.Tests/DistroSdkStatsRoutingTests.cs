// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
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

        public DistroSdkStatsRoutingTests()
        {
            _hadSwitch = AppContext.TryGetSwitch(
                StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out _previousSwitchValue);
            AppContext.SetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, true);
        }

        public void Dispose()
        {
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
        public void GetSdkStatsConfigUrl_EuCustomer_ReturnsEuConfigUrl(string euEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_EU, result);
        }

        [Theory]
        [MemberData(nameof(StatsbeatTests.NonEuEndpoints), MemberType = typeof(StatsbeatTests))]
        public void GetSdkStatsConfigUrl_NonEuCustomer_ReturnsNonEuConfigUrl(string nonEuEndpoint)
        {
            var customerCs = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEuEndpoint}.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, result);
        }

        [Fact]
        public void GetSdkStatsConfigUrl_UnknownRegion_FallsBackToNonEu()
        {
            // Unknown region defaults to the non-EU config endpoint so the distro can
            // still attempt to fetch configuration for OTLP/Console/Agent365-only
            // deployments that supply the placeholder iKey + an unrecognized region.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var result = AzureMonitorStatsbeat.GetSdkStatsConfigUrl(
                ConnectionStringParser.GetValues(customerCs).IngestionEndpoint);

            Assert.Equal(StatsbeatConstants.SdkStatsConfigUrl_NonEU, result);
        }

        [Fact]
        public void DistroSwitchOn_ConstructorDoesNotThrow_ForUnknownRegion()
        {
            // Counterpart to StatsbeatIsNotInitializedForUnknownRegions: when the distro
            // switch is on the constructor must complete without throwing even if the
            // customer connection string maps to an unknown region. SDK statistics
            // initialization is deferred to a background task (which fetches the remote
            // configuration); the constructor itself only kicks that task off.
            var customerCs = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customerCs);

            // No throw == passing assertion for this case. The Statsbeat MeterProvider
            // will only build later (and only if the remote config returns enabled=true
            // and a valid url); we cannot synchronously assert on that here without
            // standing up an in-process HTTP stub.
            using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            // _statsbeat_ConnectionString stays null until the background fetch completes
            // and returns a non-null, enabled config — neither expected during this test.
            Assert.Null(statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public void DistroSwitchOn_SlowOrUnreachableConfigEndpoint_DoesNotBlockConstruction()
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

            try
            {
                var stopwatch = Stopwatch.StartNew();
                using var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform(), handler);
                stopwatch.Stop();

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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
            await AwaitInitAsync(statsbeat);

            Assert.NotNull(statsbeat._statsbeat_ConnectionString);
            Assert.Contains("IngestionEndpoint=https://bare.host.invalid/", statsbeat._statsbeat_ConnectionString!);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigUrlHasScheme_PreservesScheme()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"https://full.url.invalid/\"}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
            await AwaitInitAsync(statsbeat);

            // The trailing slash is normalized away then re-added; the scheme is not duplicated.
            Assert.Contains("IngestionEndpoint=https://full.url.invalid/", statsbeat._statsbeat_ConnectionString!);
            Assert.DoesNotContain("https://https://", statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_RemoteDisabled_DoesNotBuildMeterProvider()
        {
            var handler = new StubHandler(_ => OkJson("{\"ver\":1,\"enabled\":false}"));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
            await AwaitInitAsync(statsbeat);

            // Explicit kill switch: no MeterProvider, no fallback.
            Assert.Null(statsbeat._statsbeatMeterProvider);
            Assert.Null(statsbeat._statsbeat_ConnectionString);
        }

        [Fact]
        public async Task DistroSwitchOn_ConfigFetchFails_FallsBackToLegacyNonEuEndpoint()
        {
            var handler = new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.NotFound));
            var vars = ConnectionStringParser.GetValues(NonEuCustomerCs);

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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

            using var statsbeat = new AzureMonitorStatsbeat(vars, new MockPlatform(), handler);
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
