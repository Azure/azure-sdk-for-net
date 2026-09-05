// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

using OpenTelemetry;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// End-to-end multi-tenant export through the real transmitter, REST client, and HTTP pipeline.
    /// Several mock ingestion stamps answer on their own hosts, so routing, per-endpoint URIs, and
    /// pipeline policies are all exercised rather than stubbed at the transmitter boundary.
    /// </summary>
    public class MultiTenantIntegrationTests
    {
        private const string ActivitySourceName = nameof(MultiTenantIntegrationTests);

        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";
        private const string NorthEurope = "https://northeurope-3.in.applicationinsights.azure.com/";

        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static readonly ActivityListener s_listener = CreateListener();

        [Fact]
        public void EachTenantReachesItsOwnStamp()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _);

            var result = exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs),
                CreateActivity("ikey-north", NorthEurope)));

            Assert.Equal(ExportResult.Success, result);
            Assert.Equal(3, ingestion.Requests.Count);

            Assert.Equal(
                new[]
                {
                    EastUs + "v2.1/track",
                    WestUs + "v2.1/track",
                    NorthEurope + "v2.1/track",
                },
                ingestion.Requests.Select(request => request.Uri));

            Assert.Contains("ikey-east", ingestion.RequestTo(EastUs).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-west", ingestion.RequestTo(EastUs).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-north", ingestion.RequestTo(EastUs).Body, StringComparison.Ordinal);

            Assert.Contains("ikey-west", ingestion.RequestTo(WestUs).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-east", ingestion.RequestTo(WestUs).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-north", ingestion.RequestTo(WestUs).Body, StringComparison.Ordinal);

            Assert.Contains("ikey-north", ingestion.RequestTo(NorthEurope).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-east", ingestion.RequestTo(NorthEurope).Body, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-west", ingestion.RequestTo(NorthEurope).Body, StringComparison.Ordinal);
        }

        [Fact]
        public void ManyTenantsInOneRegionShareOneRequest()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", EastUs),
                CreateActivity("ikey-c", EastUs)));

            var request = Assert.Single(ingestion.Requests);
            Assert.Equal(EastUs + "v2.1/track", request.Uri);
            Assert.Contains("ikey-a", request.Body, StringComparison.Ordinal);
            Assert.Contains("ikey-b", request.Body, StringComparison.Ordinal);
            Assert.Contains("ikey-c", request.Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// One failing stamp must not abandon the groups queued behind it. Endpoint-scoped back-off
        /// is covered separately in the storage tests: offline storage is disabled here, so there is
        /// no per-endpoint transmission state for this test to exercise.
        /// </summary>
        [Fact]
        public void AFailingStampDoesNotStopTheHealthyOnes()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(WestUs, 500);

            using var exporter = CreateExporter(ingestion, out _);

            var result = exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs),
                CreateActivity("ikey-north", NorthEurope)));

            Assert.Equal(ExportResult.Failure, result);
            Assert.Equal(3, ingestion.Requests.Count);

            // The healthy stamps must still receive their own tenants' telemetry, not just a request.
            Assert.Contains("ikey-east", ingestion.RequestTo(EastUs).Body, StringComparison.Ordinal);
            Assert.Contains("ikey-north", ingestion.RequestTo(NorthEurope).Body, StringComparison.Ordinal);
            Assert.Contains("ikey-west", ingestion.RequestTo(WestUs).Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// Regression: the redirect cache is shared by every endpoint on one pipeline, so a redirect
        /// learned for one stamp must not rewrite another stamp's request.
        /// </summary>
        [Fact]
        public void ARedirectAppliesOnlyToTheStampThatIssuedIt()
        {
            const string EastUsRedirect = "https://eastus-9.in.applicationinsights.azure.com/v2.1/track";

            var ingestion = new MockIngestion();
            ingestion.SetRedirectOnce(EastUs, EastUsRedirect);

            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs)));

            // East's 307, East's retry against the redirect target, then West untouched.
            Assert.Equal(3, ingestion.Requests.Count);
            Assert.Equal(EastUs + "v2.1/track", ingestion.Requests[0].Uri);
            Assert.Equal(EastUsRedirect, ingestion.Requests[1].Uri);
            Assert.Equal(WestUs + "v2.1/track", ingestion.Requests[2].Uri);
            Assert.Contains("ikey-west", ingestion.Requests[2].Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// A second export must reuse East's cached redirect without ever applying it to West.
        /// </summary>
        [Fact]
        public void ACachedRedirectStaysScopedToItsOwnStamp()
        {
            const string EastUsRedirect = "https://eastus-9.in.applicationinsights.azure.com/v2.1/track";

            var ingestion = new MockIngestion();
            ingestion.SetRedirectOnce(EastUs, EastUsRedirect);

            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));
            ingestion.Requests.Clear();

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs)));

            Assert.Equal(2, ingestion.Requests.Count);
            Assert.Equal(EastUsRedirect, ingestion.Requests[0].Uri);
            Assert.Equal(WestUs + "v2.1/track", ingestion.Requests[1].Uri);
        }

        /// <summary>
        /// The redirect cache is keyed by endpoint including its path, because a gateway can serve
        /// several tenants on one host and tell them apart only by path. Keyed by authority alone,
        /// one tenant's redirect would silently retarget the other's telemetry.
        /// </summary>
        [Fact]
        public void ACachedRedirectDoesNotCrossTenantsOnASharedGatewayHost()
        {
            const string FirstTenant = "https://gateway.example.com/tenant-a/";
            const string SecondTenant = "https://gateway.example.com/tenant-b/";
            const string FirstTenantRedirect = "https://gateway.example.com/tenant-a-moved/v2.1/track";

            var ingestion = new MockIngestion();
            ingestion.SetRedirectOnce(FirstTenant, FirstTenantRedirect);

            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", FirstTenant)));
            ingestion.Requests.Clear();

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", FirstTenant),
                CreateActivity("ikey-b", SecondTenant)));

            Assert.Equal(2, ingestion.Requests.Count);
            Assert.Equal(FirstTenantRedirect, ingestion.Requests[0].Uri);

            // Same host, different path: the second tenant must be untouched by the first's redirect.
            Assert.Equal(SecondTenant + "v2.1/track", ingestion.Requests[1].Uri);
        }

        /// <summary>
        /// A stamp answers 404 for a path it does not serve, so a request that lands somewhere the
        /// API is not cannot be mistaken for a delivered one. The failed target must also not be
        /// remembered: caching it would pin the endpoint to a destination known not to work, and
        /// nothing would invalidate it because the replay is no longer a redirect.
        /// </summary>
        [Fact]
        public void ARedirectToAPathTheStampDoesNotServeIsNeitherDeliveredNorCached()
        {
            var ingestion = new MockIngestion();
            ingestion.SetRedirectOnce(EastUs, EastUs + "not/the/api");

            using var exporter = CreateExporter(ingestion, out _);

            var result = exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            Assert.Equal(ExportResult.Failure, result);
            Assert.Equal(2, ingestion.Requests.Count);
            Assert.Equal(EastUs + "not/the/api", ingestion.Requests[1].Uri);

            ingestion.Requests.Clear();

            // The next export goes to the endpoint itself, not to the target that just failed.
            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            Assert.Equal(EastUs + "v2.1/track", Assert.Single(ingestion.Requests).Uri);
        }

        [Fact]
        public void UnroutableActivitiesReachNoStamp()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _);

            var result = exporter.Export(CreateBatch(
                CreateActivity(instrumentationKey: null, ingestionEndpoint: null),
                CreateActivity("ikey-a", "not-a-uri")));

            // Tenants without observability enabled are the norm, not an export failure.
            Assert.Equal(ExportResult.Success, result);
            Assert.Empty(ingestion.Requests);
        }

        [Fact]
        public void RoutableActivitiesStillReachTheirStampAlongsideUnroutableOnes()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(
                CreateActivity(instrumentationKey: null, ingestionEndpoint: null),
                CreateActivity("ikey-east", EastUs),
                CreateActivity(instrumentationKey: null, ingestionEndpoint: null)));

            var request = Assert.Single(ingestion.Requests);
            Assert.Equal(EastUs + "v2.1/track", request.Uri);
            Assert.Contains("ikey-east", request.Body, StringComparison.Ordinal);
        }

        [Fact]
        public void RoutedTelemetryNeverCarriesTheExportersOwnInstrumentationKey()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out var connectionStringIKey);

            exporter.Export(CreateBatch(CreateActivity("ikey-tenant", EastUs)));

            var request = Assert.Single(ingestion.Requests);
            Assert.Contains("ikey-tenant", request.Body, StringComparison.Ordinal);
            Assert.DoesNotContain(connectionStringIKey, request.Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// Customer SDK stats are reported under the exporter's own connection string, so counting a
        /// tenant's telemetry there would attribute one customer's volume to another.
        /// </summary>
        /// <remarks>
        /// The single-tenant export is the control. Without it this would pass even if the listener
        /// were attached to the wrong meter or the counters were switched off entirely, which is
        /// exactly what happened when it was first written against a mock transmitter that never
        /// reaches the code emitting them.
        /// </remarks>
        [Fact]
        public void RoutedExportEmitsNoCustomerSdkStatsWhileSingleTenantDoes()
        {
            var measurements = 0;

            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == CustomerSdkStatsMeters.MeterName)
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };

            listener.SetMeasurementEventCallback<long>((_, _, _, _) => Interlocked.Increment(ref measurements));
            listener.Start();

            var ingestion = new MockIngestion();

            using (var singleTenant = CreateExporter(ingestion, multiTenantEnabled: false, out _))
            {
                singleTenant.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));
            }

            var control = Volatile.Read(ref measurements);
            Assert.True(control > 0, "the listener saw nothing on the path that does report customer stats");

            using (var routed = CreateExporter(ingestion, out _))
            {
                var routedRequests = ingestion.Requests.Count;

                var result = routed.Export(CreateBatch(
                    CreateActivity("ikey-east", EastUs),
                    CreateActivity("ikey-west", WestUs)));

                // Asserted so the equality below cannot hold merely because nothing was sent.
                Assert.Equal(ExportResult.Success, result);
                Assert.Equal(routedRequests + 2, ingestion.Requests.Count);
            }

            Assert.Equal(control, Volatile.Read(ref measurements));
        }

        private static AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, out string instrumentationKey)
            => CreateExporter(ingestion, multiTenantEnabled: true, out instrumentationKey);

        private static AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, bool multiTenantEnabled, out string instrumentationKey)
        {
            instrumentationKey = "00000000-0000-0000-0000-0000000000ff";

            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={instrumentationKey};IngestionEndpoint={EastUs}",
                Transport = ingestion.Transport,
                DisableOfflineStorage = true,
                EnableStatsbeat = false,
            };

            // Both halves must be told the gate is on. The two-argument transmitter constructor reads
            // the process-wide switch, which is off under test, so the exporter and the transmitter
            // would disagree about the mode they are running in.
            return new AzureMonitorTraceExporter(
                options,
                new AzureMonitorTransmitter(options, DefaultPlatform.Instance, multiTenantEnabled),
                multiTenantEnabled);
        }

        private static Batch<Activity> CreateBatch(params Activity[] activities) => new(activities, activities.Length);

        private static Activity CreateActivity(string? instrumentationKey, string? ingestionEndpoint)
        {
            var activity = s_activitySource.StartActivity("IntegrationTest", ActivityKind.Server)!;

            if (instrumentationKey != null)
            {
                activity.SetTag(SemanticConventions.AttributeMicrosoftInstrumentationKey, instrumentationKey);
            }

            if (ingestionEndpoint != null)
            {
                activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionEndpoint, ingestionEndpoint);
            }

            activity.Stop();
            return activity;
        }

        private static ActivityListener CreateListener()
        {
            var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == ActivitySourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            };

            ActivitySource.AddActivityListener(listener);
            return listener;
        }

        /// <summary>
        /// Stands in for the regional ingestion stamps: answers per endpoint and records what it saw.
        /// </summary>
        /// <remarks>
        /// Keyed by the whole endpoint rather than the host, so two tenants behind one gateway that
        /// differ only by path are distinguishable. A request whose path is not the ingestion API is
        /// a 404; an unconfigured endpoint that does address the API is a healthy stamp answering
        /// 200, which is what most tests want.
        /// </remarks>
        private sealed class MockIngestion
        {
            private const string TrackPath = "v2.1/track";

            private readonly Dictionary<string, int> _statusByEndpoint = new(StringComparer.Ordinal);
            private readonly Dictionary<string, string> _pendingRedirects = new(StringComparer.Ordinal);

            internal MockIngestion()
            {
                Transport = new MockTransport(Respond);
            }

            internal MockTransport Transport { get; }

            internal List<CapturedRequest> Requests { get; } = new();

            internal void SetStatus(string ingestionEndpoint, int statusCode) => _statusByEndpoint[ingestionEndpoint] = statusCode;

            /// <summary>One 307 for this endpoint, then normal responses, mirroring a stamp move.</summary>
            internal void SetRedirectOnce(string ingestionEndpoint, string location) => _pendingRedirects[ingestionEndpoint] = location;

            internal CapturedRequest RequestTo(string ingestionEndpoint) =>
                Requests.Single(request => request.Uri.StartsWith(ingestionEndpoint, StringComparison.Ordinal));

            private MockResponse Respond(Request request)
            {
                Requests.Add(new CapturedRequest(request.Uri.ToString(), ReadBody(request)));

                if (!TryGetEndpoint(request, out var endpoint))
                {
                    return new MockResponse(404);
                }

                if (_pendingRedirects.TryGetValue(endpoint, out var location))
                {
                    _pendingRedirects.Remove(endpoint);
                    return new MockResponse(307).AddHeader("Location", location);
                }

                return new MockResponse(_statusByEndpoint.TryGetValue(endpoint, out var status) ? status : 200);
            }

            /// <summary>The endpoint a request was addressed to, which is its URI minus the API path.</summary>
            private static bool TryGetEndpoint(Request request, out string endpoint)
            {
                var uri = request.Uri.ToUri();
                var absolute = uri.GetLeftPart(UriPartial.Path);

                if (!absolute.EndsWith(TrackPath, StringComparison.Ordinal))
                {
                    endpoint = string.Empty;
                    return false;
                }

                endpoint = absolute.Substring(0, absolute.Length - TrackPath.Length);
                return true;
            }

            private static string ReadBody(Request request)
            {
                if (request.Content == null)
                {
                    return string.Empty;
                }

                using var stream = new MemoryStream();
                request.Content.WriteTo(stream, default);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        private sealed class CapturedRequest
        {
            internal CapturedRequest(string uri, string body)
            {
                Uri = uri;
                Body = body;
            }

            internal string Uri { get; }

            internal string Body { get; }
        }
    }
}
