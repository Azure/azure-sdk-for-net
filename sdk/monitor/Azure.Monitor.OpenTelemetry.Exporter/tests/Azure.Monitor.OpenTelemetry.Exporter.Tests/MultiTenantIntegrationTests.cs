// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
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

        private static AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, out string instrumentationKey)
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
                new AzureMonitorTransmitter(options, DefaultPlatform.Instance, multiTenantEnabled: true),
                multiTenantEnabled: true);
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
        /// Stands in for the regional ingestion stamps: answers per host and records what it saw.
        /// </summary>
        private sealed class MockIngestion
        {
            private readonly Dictionary<string, int> _statusByEndpoint = new(StringComparer.Ordinal);
            private readonly Dictionary<string, string> _pendingRedirects = new(StringComparer.Ordinal);

            internal MockIngestion()
            {
                Transport = new MockTransport(Respond);
            }

            internal MockTransport Transport { get; }

            internal List<CapturedRequest> Requests { get; } = new();

            internal void SetStatus(string ingestionEndpoint, int statusCode) => _statusByEndpoint[Host(ingestionEndpoint)] = statusCode;

            /// <summary>One 307 for this host, then normal responses, mirroring a stamp move.</summary>
            internal void SetRedirectOnce(string ingestionEndpoint, string location) => _pendingRedirects[Host(ingestionEndpoint)] = location;

            internal CapturedRequest RequestTo(string ingestionEndpoint) =>
                Requests.Single(request => request.Uri.StartsWith(ingestionEndpoint, StringComparison.Ordinal));

            private MockResponse Respond(Request request)
            {
                var host = request.Uri.Host ?? string.Empty;
                Requests.Add(new CapturedRequest(request.Uri.ToString(), ReadBody(request)));

                if (_pendingRedirects.TryGetValue(host, out var location))
                {
                    _pendingRedirects.Remove(host);
                    return new MockResponse(307).AddHeader("Location", location);
                }

                return new MockResponse(_statusByEndpoint.TryGetValue(host, out var status) ? status : 200);
            }

            private static string Host(string ingestionEndpoint) => new Uri(ingestionEndpoint).Host;

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
