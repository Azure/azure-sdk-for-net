// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

using TestEventListener = Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework.TestEventListener;

using OpenTelemetry;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// End-to-end multi-endpoint routing through the real transmitter, REST client, and HTTP pipeline.
    /// Several mock ingestion stamps answer on their own hosts, so routing, per-endpoint URIs, and
    /// pipeline policies are all exercised rather than stubbed at the transmitter boundary.
    /// </summary>
    public class MultiEndpointIntegrationTests
    {
        private const string ActivitySourceName = nameof(MultiEndpointIntegrationTests);

        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";
        private const string NorthEurope = "https://northeurope-3.in.applicationinsights.azure.com/";

        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static readonly ActivityListener s_listener = CreateListener();

        [Fact]
        public void EachDestinationReachesItsOwnStamp()
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

        /// <summary>
        /// Delivery is reported per endpoint, so a stamp that took nothing is distinguishable from
        /// one that was never addressed.
        /// </summary>
        [Fact]
        public void EachStampsDeliveryIsReported()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            Assert.Equal(ExportResult.Success, exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-east-2", EastUs),
                CreateActivity("ikey-west", WestUs))));

            var outcomes = listener.Messages.Where(e => e.EventName == "RoutedGroupOutcome").ToArray();
            Assert.Equal(2, outcomes.Length);
            Assert.All(outcomes, outcome => Assert.Equal("transmitted", outcome.Payload![3]));

            var east = Assert.Single(outcomes.Where(o => (string)o.Payload![2]! == EastUs));
            Assert.Equal(2, east.Payload![1]);
            Assert.Equal(2, east.Payload[4]);

            var west = Assert.Single(outcomes.Where(o => (string)o.Payload![2]! == WestUs));
            Assert.Equal(1, west.Payload![1]);
            Assert.Equal(1, west.Payload[4]);

            // The summary and both deliveries describe one export.
            var summary = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedExportSummary"));
            Assert.All(outcomes, outcome => Assert.Equal(summary.Payload![0], outcome.Payload![0]));
        }

        /// <summary>
        /// An unreachable endpoint throws before any response exists, which is the case the whole
        /// diagnostic exists for, so it must still say what became of the batch.
        /// </summary>
        [Fact]
        public void AStampThatCannotBeReachedStillReportsAnOutcome()
        {
            var ingestion = new MockIngestion();
            ingestion.SetUnreachable(EastUs);
            using var exporter = CreateExporter(ingestion, out _);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs), CreateActivity("ikey-west", WestUs)));

            var outcomes = listener.Messages.Where(e => e.EventName == "RoutedGroupOutcome").ToArray();

            // The reachable stamp is still reported, so one failure does not hide the rest.
            var east = Assert.Single(outcomes.Where(o => (string)o.Payload![2]! == EastUs));
            Assert.Equal(1, east.Payload![1]);
            Assert.Equal("dropped", east.Payload[3]);

            // Nothing answered, so acceptance is unknown rather than zero.
            Assert.Equal(-1, east.Payload[4]);
            Assert.Equal(0, east.Payload[5]);

            var west = Assert.Single(outcomes.Where(o => (string)o.Payload![2]! == WestUs));
            Assert.Equal("transmitted", west.Payload![3]);
        }

        /// <summary>
        /// A 206 accepts some items, retries some and rejects others outright. Only the accepted
        /// count is knowable here, so the outcome must not claim what became of the rest.
        /// </summary>
        [Fact]
        public void APartiallyAcceptedBatchClaimsOnlyWhatIngestionAccepted()
        {
            var ingestion = new MockIngestion();
            ingestion.SetResponse(
                EastUs,
                206,
                "{\"itemsReceived\":3,\"itemsAccepted\":1,\"errors\":[{\"index\":1,\"statusCode\":503,\"message\":\"retry\"},{\"index\":2,\"statusCode\":400,\"message\":\"rejected\"}]}");

            using var exporter = CreateExporter(ingestion, out _);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", EastUs),
                CreateActivity("ikey-c", EastUs)));

            var outcome = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedGroupOutcome"));
            Assert.Equal(3, outcome.Payload![1]);
            Assert.Equal("partially accepted", outcome.Payload[3]);
            Assert.Equal(1, outcome.Payload[4]);
            Assert.Equal(206, outcome.Payload[5]);
        }

        /// <summary>
        /// A 206 that accepted nothing still settled each item separately, so the group must not be
        /// described as persisted when only the retryable subset was kept.
        /// </summary>
        [Fact]
        public void APartialResponseThatAcceptedNothingIsNotCalledPersisted()
        {
            var ingestion = new MockIngestion();
            ingestion.SetResponse(
                EastUs,
                206,
                "{\"itemsReceived\":2,\"itemsAccepted\":0,\"errors\":[{\"index\":0,\"statusCode\":503,\"message\":\"retry\"},{\"index\":1,\"statusCode\":400,\"message\":\"rejected\"}]}");

            using var exporter = CreateExporter(ingestion, out _);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs), CreateActivity("ikey-b", EastUs)));

            var outcome = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedGroupOutcome"));
            Assert.Equal("partially accepted", outcome.Payload![3]);
            Assert.Equal(0, outcome.Payload[4]);
            Assert.Equal(206, outcome.Payload[5]);
        }

        /// <summary>A count the batch cannot support says more about ingestion than about delivery.</summary>
        [Fact]
        public void AnUnusableAcceptedCountIsReportedAsUnknown()
        {
            var ingestion = new MockIngestion();
            ingestion.SetResponse(EastUs, 206, "{\"itemsReceived\":1,\"itemsAccepted\":99,\"errors\":[]}");

            using var exporter = CreateExporter(ingestion, out _);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Informational, EventKeywords.All);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs)));

            var outcome = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedGroupOutcome"));
            Assert.Equal(-1, outcome.Payload![4]);
        }

        [Fact]
        public void ManyApplicationsInOneRegionShareOneRequest()
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

            // The healthy stamps must still receive their own destinations' telemetry, not just a request.
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
        /// several endpoints on one host and tell them apart only by path. Keyed by authority alone,
        /// one endpoint's redirect would silently retarget the other's telemetry.
        /// </summary>
        [Fact]
        public void ACachedRedirectDoesNotCrossEndpointsOnASharedGatewayHost()
        {
            const string FirstEndpoint = "https://gateway.example.com/app-a/";
            const string SecondEndpoint = "https://gateway.example.com/app-b/";
            const string FirstEndpointRedirect = "https://gateway.example.com/app-a-moved/v2.1/track";

            var ingestion = new MockIngestion();
            ingestion.SetRedirectOnce(FirstEndpoint, FirstEndpointRedirect);

            using var exporter = CreateExporter(ingestion, out _);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", FirstEndpoint)));
            ingestion.Requests.Clear();

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", FirstEndpoint),
                CreateActivity("ikey-b", SecondEndpoint)));

            Assert.Equal(2, ingestion.Requests.Count);
            Assert.Equal(FirstEndpointRedirect, ingestion.Requests[0].Uri);

            // Same host, different path: the second endpoint must be untouched by the first's redirect.
            Assert.Equal(SecondEndpoint + "v2.1/track", ingestion.Requests[1].Uri);
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

            // Applications without observability enabled are the norm, not an export failure.
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

            exporter.Export(CreateBatch(CreateActivity("ikey-app", EastUs)));

            var request = Assert.Single(ingestion.Requests);
            Assert.Contains("ikey-app", request.Body, StringComparison.Ordinal);
            Assert.DoesNotContain(connectionStringIKey, request.Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// Customer SDK stats are reported under the exporter's own connection string, so counting a
        /// endpoint's telemetry there would attribute one customer's volume to another.
        /// </summary>
        /// <remarks>
        /// The single-endpoint export is the control. Without it this would pass even if the listener
        /// were attached to the wrong meter or the counters were switched off entirely, which is
        /// exactly what happened when it was first written against a mock transmitter that never
        /// reaches the code emitting them.
        /// </remarks>
        [Fact]
        public void RoutedExportEmitsNoCustomerSdkStatsWhileSingleEndpointDoes()
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

            using (var singleEndpoint = CreateExporter(ingestion, multiEndpointEnabled: false, out _))
            {
                singleEndpoint.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));
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
            => CreateExporter(ingestion, multiEndpointEnabled: true, out instrumentationKey);

        private static AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, bool multiEndpointEnabled, out string instrumentationKey)
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
                new AzureMonitorTransmitter(options, DefaultPlatform.Instance, multiEndpointEnabled),
                multiEndpointEnabled);
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
        /// Keyed by the whole endpoint rather than the host, so two endpoints behind one gateway that
        /// differ only by path are distinguishable. A request whose path is not the ingestion API is
        /// a 404; an unconfigured endpoint that does address the API is a healthy stamp answering
        /// 200, which is what most tests want.
        /// </remarks>
        private sealed class MockIngestion
        {
            private const string TrackPath = "v2.1/track";

            private readonly Dictionary<string, int> _statusByEndpoint = new(StringComparer.Ordinal);
            private readonly Dictionary<string, string> _bodyByEndpoint = new(StringComparer.Ordinal);
            private readonly Dictionary<string, string> _pendingRedirects = new(StringComparer.Ordinal);
            private readonly HashSet<string> _unreachable = new(StringComparer.Ordinal);

            internal MockIngestion()
            {
                Transport = new MockTransport(Respond);
            }

            internal MockTransport Transport { get; }

            internal List<CapturedRequest> Requests { get; } = new();

            internal void SetStatus(string ingestionEndpoint, int statusCode) => _statusByEndpoint[ingestionEndpoint] = statusCode;

            /// <summary>A response with a body, so partial-success accounting can be exercised.</summary>
            internal void SetResponse(string ingestionEndpoint, int statusCode, string body)
            {
                _statusByEndpoint[ingestionEndpoint] = statusCode;
                _bodyByEndpoint[ingestionEndpoint] = body;
            }

            /// <summary>A stamp that answers nothing at all, so the send throws instead of returning.</summary>
            internal void SetUnreachable(string ingestionEndpoint) => _unreachable.Add(ingestionEndpoint);

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

                if (_unreachable.Contains(endpoint))
                {
                    throw new InvalidOperationException($"'{endpoint}' cannot be reached.");
                }

                if (_pendingRedirects.TryGetValue(endpoint, out var location))
                {
                    _pendingRedirects.Remove(endpoint);
                    return new MockResponse(307).AddHeader("Location", location);
                }

                var response = new MockResponse(_statusByEndpoint.TryGetValue(endpoint, out var status) ? status : 200);

                if (_bodyByEndpoint.TryGetValue(endpoint, out var body))
                {
                    response.SetContent(body);
                }

                return response;
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
