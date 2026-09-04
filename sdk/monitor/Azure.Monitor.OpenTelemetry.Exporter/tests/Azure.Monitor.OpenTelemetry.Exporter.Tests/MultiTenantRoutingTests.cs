// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;
using OpenTelemetry.Resources;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MultiTenantRoutingTests
    {
        private const string ActivitySourceName = nameof(MultiTenantRoutingTests);
        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static readonly ActivityListener s_listener = CreateListener();

        [Fact]
        public void MixedInstrumentationKeysOnOneEndpointCollapseToOneGroup()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", EastUs),
                CreateActivity("ikey-c", EastUs));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(EastUs, routeBatch[0].IngestionEndpoint);
            Assert.Equal(3, routeBatch[0].TelemetryItems.Count);
        }

        [Fact]
        public void DistinctEndpointsBecomeDistinctGroups()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-a", WestUs),
                CreateActivity("ikey-b", EastUs));

            Assert.Equal(2, routeBatch.Count);
            Assert.Equal(2, routeBatch[0].TelemetryItems.Count);
            Assert.Single(routeBatch[1].TelemetryItems);
        }

        [Theory]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com")]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com/")]
        [InlineData("HTTPS://eastus-1.in.applicationinsights.azure.com/")]
        [InlineData("https://EastUs-1.In.ApplicationInsights.Azure.Com/")]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com./")]
        [InlineData("https://@eastus-1.in.applicationinsights.azure.com/")]
        [InlineData("https://eastus-1.in.applicationinsights.azure\u3002com/")]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com:443/")]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com/a/../")]
        public void EndpointSpellingsShareOneGroup(string variant)
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-a", variant));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(2, routeBatch[0].TelemetryItems.Count);
            Assert.Equal(EastUs, routeBatch[0].IngestionEndpoint);
        }

        [Fact]
        public void EachItemCarriesItsOwnInstrumentationKey()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", EastUs));

            Assert.Equal(
                new[] { "ikey-a", "ikey-b" },
                routeBatch[0].TelemetryItems.Select(item => item.InstrumentationKey));
        }

        [Fact]
        public void RoutingTagsDoNotReachCustomDimensions()
        {
            var routeBatch = Convert(CreateActivity("ikey-a", EastUs));

            var properties = ((RequestData)routeBatch[0].TelemetryItems.Single().Data!.BaseData).Properties;
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, properties.Keys);
        }

        [Theory]
        [InlineData(null, EastUs)]
        [InlineData("", EastUs)]
        [InlineData("   ", EastUs)]
        [InlineData("ikey-a", null)]
        [InlineData("ikey-a", "")]
        [InlineData("ikey-a", "not-a-uri")]
        [InlineData("ikey-a", "/relative/path")]
        [InlineData("ikey-a", "ftp://example.com/")]
        public void ActivityWithoutAValidRouteIsDropped(string? instrumentationKey, string? ingestionEndpoint)
        {
            var routeBatch = Convert(CreateActivity(instrumentationKey, ingestionEndpoint));

            Assert.Equal(0, routeBatch.Count);
        }

        /// <summary>
        /// The endpoint is resolved upstream from the same trusted source as a connection string, so
        /// only values that cannot be a usable ingestion target are rejected.
        /// </summary>
        [Theory]
        [InlineData("not-a-uri")]
        [InlineData("/relative/path")]
        [InlineData("ftp://example.com/")]
        [InlineData("https://user:pass@eastus-1.in.applicationinsights.azure.com/")] // credentials in URI
        [InlineData("https://eastus-1.in.applicationinsights.azure.com/?a=b")]       // query
        [InlineData("https://eastus-1.in.applicationinsights.azure.com/#frag")]      // fragment
        [InlineData("https://xn--\u00fc.in.applicationinsights.azure.com/")]         // malformed punycode label
        [InlineData("http://eastus-1.in.applicationinsights.azure.com/")]            // cleartext
        [InlineData("http://localhost:9000/")]                                      // cleartext
        public void UnusableEndpointIsRejected(string ingestionEndpoint)
        {
            Assert.Null(TenantRouting.NormalizeEndpoint(ingestionEndpoint));
            Assert.Equal(0, Convert(CreateActivity("ikey-a", ingestionEndpoint)).Count);
        }

        /// <summary>
        /// Private, sovereign, and proxied endpoints are not fenced off by a host allow-list.
        /// </summary>
        [Theory]
        [InlineData("https://ingestion.contoso-private.example/", "https://ingestion.contoso-private.example/")]
        [InlineData("https://localhost:9000/", "https://localhost:9000/")]
        [InlineData("https://gateway.example:8443/ingest", "https://gateway.example:8443/ingest/")]
        [InlineData("https://dc.applicationinsights.azure.cn/", "https://dc.applicationinsights.azure.cn/")]
        public void NonPublicEndpointIsAccepted(string ingestionEndpoint, string expected)
        {
            Assert.Equal(expected, TenantRouting.NormalizeEndpoint(ingestionEndpoint));

            var routeBatch = Convert(CreateActivity("ikey-a", ingestionEndpoint));
            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(expected, routeBatch[0].IngestionEndpoint);
        }

        [Fact]
        public void DistinctPortsAreDistinctGroups()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", "https://gateway.example/"),
                CreateActivity("ikey-a", "https://gateway.example:8443/"));

            Assert.Equal(2, routeBatch.Count);
        }

        [Fact]
        public void ArrayValuedRoutingTagIsRejectedRatherThanStringified()
        {
            var activity = s_activitySource.StartActivity("Test", ActivityKind.Server)!;
            activity.SetTag(SemanticConventions.AttributeMicrosoftInstrumentationKey, new[] { "ikey-a", "ikey-b" });
            activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionEndpoint, EastUs);
            activity.Stop();

            Assert.Equal(0, Convert(activity).Count);
        }

        [Fact]
        public void InstrumentationKeyIsTrimmedSoSpacingDoesNotCreateATenant()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("  ikey-a  ", EastUs));

            Assert.All(routeBatch[0].TelemetryItems, item => Assert.Equal("ikey-a", item.InstrumentationKey));
        }

        [Fact]
        public void OneUnroutableActivityDoesNotDropTheRestOfTheBatch()
        {
            var routeBatch = Convert(
                CreateActivity("ikey-a", EastUs),
                CreateActivity(instrumentationKey: null, EastUs),
                CreateActivity("ikey-b", EastUs));

            Assert.Equal(1, routeBatch.Count);
            Assert.Equal(2, routeBatch[0].TelemetryItems.Count);
        }

        /// <summary>
        /// The resource envelope describes the host process. Filing it under a tenant's
        /// instrumentation key would report the host's identity as that tenant's own application.
        /// </summary>
        [Fact]
        public void NoResourceEnvelopeIsEmittedForRoutedTelemetry()
        {
            var resource = ResourceBuilder.CreateDefault().Build().CreateAzureMonitorResource("ikey-a");
            Assert.NotNull(resource!.MonitorBaseData);

            var routeBatch = new EndpointRouteBatch();
            TraceHelper.OtelToAzureMonitorTraceMultiTenant(
                CreateBatch(
                    CreateActivity("ikey-a", EastUs),
                    CreateActivity("ikey-a", EastUs),
                    CreateActivity("ikey-b", EastUs)),
                resource,
                sampleRate: 100,
                routeBatch);

            Assert.Empty(routeBatch[0].TelemetryItems.Where(item => item.Data?.BaseType == "MetricData"));

            // The activities themselves still go, one envelope each.
            Assert.Equal(3, routeBatch[0].TelemetryItems.Count);
        }

        /// <summary>
        /// Characterizes what a routed envelope currently says about identity when the host has a
        /// real resource. The resource metric is withheld, but the role tags on the envelope are the
        /// host's, so a tenant sees the relaying service's name and instance as its own application.
        /// This is a recorded gap, not settled behaviour: the test exists so that changing it is a
        /// deliberate act rather than an accident.
        /// </summary>
        [Fact]
        public void RoutedEnvelopesCarryTheHostsCloudRole()
        {
            var resource = ResourceBuilder.CreateDefault()
                .AddAttributes(new Dictionary<string, object>
                {
                    { "service.name", "relay-host" },
                    { "service.instance.id", "relay-instance" },
                })
                .Build()
                .CreateAzureMonitorResource("exporter-ikey");

            Assert.NotNull(resource);

            var routeBatch = new EndpointRouteBatch();
            TraceHelper.OtelToAzureMonitorTraceMultiTenant(
                CreateBatch(CreateActivity("ikey-a", EastUs)),
                resource,
                sampleRate: 100,
                routeBatch);

            var telemetryItem = routeBatch[0].TelemetryItems.Single();

            Assert.Equal("ikey-a", telemetryItem.InstrumentationKey);
            Assert.Equal("relay-host", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("relay-instance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }

        [Fact]
        public void ResetReusesGroupsAndItemListsAcrossExports()
        {
            var routeBatch = new EndpointRouteBatch();

            TraceHelper.OtelToAzureMonitorTraceMultiTenant(CreateBatch(CreateActivity("ikey-a", EastUs)), null, 100, routeBatch);
            var firstGroup = routeBatch[0];
            var firstItems = firstGroup.TelemetryItems;
            routeBatch.Reset();

            Assert.Equal(0, routeBatch.Count);
            Assert.Empty(firstItems);

            TraceHelper.OtelToAzureMonitorTraceMultiTenant(CreateBatch(CreateActivity("ikey-b", WestUs)), null, 100, routeBatch);

            Assert.Equal(1, routeBatch.Count);
            Assert.Same(firstGroup, routeBatch[0]);
            Assert.Same(firstItems, routeBatch[0].TelemetryItems);
            Assert.Equal(WestUs, routeBatch[0].IngestionEndpoint);
        }

        /// <summary>
        /// Nothing consumes the routing slots outside the multi-tenant conversion, so claiming them
        /// on the single-tenant path would take these attributes out of custom dimensions and drop
        /// them entirely. They must survive as ordinary custom dimensions when the gate is off.
        /// </summary>
        [Fact]
        public void SingleTenantPathKeepsRoutingTagsAsCustomDimensions()
        {
            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(
                CreateBatch(CreateActivity("ikey-a", EastUs)),
                null,
                "exporter-ikey",
                sampleRate: 100);

            var telemetryItem = telemetryItems.Single();
            Assert.Equal("exporter-ikey", telemetryItem.InstrumentationKey);

            var properties = ((RequestData)telemetryItem.Data!.BaseData).Properties;
            Assert.Equal("ikey-a", properties[SemanticConventions.AttributeMicrosoftInstrumentationKey]);
            Assert.Equal(EastUs, properties[SemanticConventions.AttributeMicrosoftIngestionEndpoint]);
        }

        /// <summary>
        /// On the routed path they are consumed, so they must not also appear as dimensions.
        /// </summary>
        [Fact]
        public void RoutedTelemetryDoesNotCarryTheRoutingTagsAsCustomDimensions()
        {
            var routeBatch = Convert(CreateActivity("ikey-a", EastUs));

            var properties = ((RequestData)routeBatch[0].TelemetryItems.Single().Data!.BaseData).Properties;
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftInstrumentationKey, properties.Keys);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftIngestionEndpoint, properties.Keys);
        }

        /// <summary>
        /// The credential is scoped to the exporter's own audience, and the bearer token policy sits
        /// in the shared pipeline, so it would be attached to requests addressed to hosts named by
        /// telemetry. The combination is refused rather than disclosing the token.
        /// </summary>
        [Fact]
        public void MultiTenantRefusesToStartWithEntraCredentials()
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000001;IngestionEndpoint={EastUs}",
                Credential = new StubCredential(),
                DisableOfflineStorage = true,
            };

            var exception = Assert.Throws<NotSupportedException>(
                () => new AzureMonitorTransmitter(options, new MockPlatform(), multiTenantEnabled: true));

            Assert.Contains("Entra", exception.Message, StringComparison.Ordinal);
        }

        /// <summary>
        /// With the gate off, the exporter takes the single-tenant path even for Activities that
        /// carry routing tags.
        /// </summary>
        [Fact]
        public void GateOffKeepsTheSingleTenantPath()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: false);

            var result = exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs)));

            Assert.Equal(ExportResult.Success, result);
            Assert.Equal(1, transmitter.TrackAsyncCallCount);
            Assert.Equal(transmitter.InstrumentationKey, transmitter.TelemetryItems.Single().InstrumentationKey);
        }

        /// <summary>
        /// The data-boundary contract: routed telemetry must never reach the exporter's own
        /// connection string.
        /// </summary>
        [Fact]
        public void GateOnNeverFallsBackToTheExportersOwnTransmitter()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);

            var result = exporter.Export(CreateBatch(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", WestUs)));

            Assert.Equal(ExportResult.Success, result);
            Assert.Equal(0, transmitter.TrackAsyncCallCount);
            Assert.Empty(transmitter.TelemetryItems);
        }

        [Fact]
        public void EachEndpointGroupIsSentToItsOwnEndpoint()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", WestUs),
                CreateActivity("ikey-c", EastUs)));

            Assert.Equal(2, transmitter.Sends.Count);

            var eastUs = transmitter.Sends.Single(send => send.IngestionEndpoint == EastUs);
            Assert.Equal(new[] { "ikey-a", "ikey-c" }, eastUs.TelemetryItems.Select(item => item.InstrumentationKey));

            var westUs = transmitter.Sends.Single(send => send.IngestionEndpoint == WestUs);
            Assert.Equal(new[] { "ikey-b" }, westUs.TelemetryItems.Select(item => item.InstrumentationKey));
        }

        [Fact]
        public void ManyTenantsInOneRegionBecomeOneSend()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-a", EastUs),
                CreateActivity("ikey-b", EastUs),
                CreateActivity("ikey-c", EastUs)));

            Assert.Single(transmitter.Sends);
            Assert.Equal(3, transmitter.Sends[0].TelemetryItems.Length);
        }

        [Fact]
        public void TransmissionFailureIsReportedToTheProvider()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);
            transmitter.MultiTenantResult = ExportResult.Failure;

            var result = exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs)));

            Assert.Equal(ExportResult.Failure, result);
            Assert.Single(transmitter.Sends);
        }

        /// <summary>
        /// The route batch is reset after every export, so the transmitter must see the items while
        /// they are still populated.
        /// </summary>
        [Fact]
        public void GroupsAreStillPopulatedWhenTheTransmitterRuns()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs)));
            exporter.Export(CreateBatch(CreateActivity("ikey-b", WestUs)));

            // Asserted first: Assert.All succeeds on an empty list, so without this the test would
            // pass if the transmitter were never called at all.
            Assert.Equal(2, transmitter.Sends.Count);
            Assert.All(transmitter.Sends, send => Assert.NotEmpty(send.TelemetryItems));
        }

        [Fact]
        public void MultiTenantExportRequiresAMultiTenantTransmitter()
        {
            var transmitter = new SingleTenantOnlyTransmitter();

            Assert.Throws<NotSupportedException>(
                () => new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), transmitter, multiTenantEnabled: true));

            Assert.True(transmitter.Disposed);
        }

        [Theory]
        [InlineData("https://eastus-1.in.applicationinsights.azure.com/", "https://eastus-1.in.applicationinsights.azure.com/v2.1/track")]
        [InlineData("https://gateway.example:8443/ingest/", "https://gateway.example:8443/ingest/v2.1/track")]
        public void TrackUriIsBuiltFromTheGroupEndpoint(string ingestionEndpoint, string expected)
        {
            Assert.Equal(expected, ApplicationInsightsRestClient.CreateTrackUri(ingestionEndpoint).AbsoluteUri);
        }

        /// <summary>
        /// The gate is off unless an operator opts in.
        /// </summary>
        [Fact]
        public void GateDefaultsToOff()
        {
            Assert.False(MultiTenantConfig.Enabled);

            // The documented opt-in; a typo here silently disables the feature for everyone.
            Assert.Equal("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", MultiTenantConfig.EnableMultiTenantExportSwitchName);

            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            using var exporter = new AzureMonitorTraceExporter(new AzureMonitorExporterOptions(), transmitter);

            Assert.Equal(ExportResult.Success, exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs))));
            Assert.Equal(1, transmitter.TrackAsyncCallCount);
        }

        /// <summary>
        /// Most tenants do not enable observability, so a batch with no routing tags is routine and
        /// must not be reported as a failed export.
        /// </summary>
        [Fact]
        public void GateOnWithNoRoutableActivityReportsSuccess()
        {
            var (exporter, transmitter) = CreateExporter(multiTenantEnabled: true);

            var result = exporter.Export(CreateBatch(CreateActivity(instrumentationKey: null, ingestionEndpoint: null)));

            Assert.Equal(ExportResult.Success, result);
            Assert.Equal(0, transmitter.TrackAsyncCallCount);
        }

        [Fact]
        public void GateOnWithAnEmptyBatchReportsSuccess()
        {
            var (exporter, _) = CreateExporter(multiTenantEnabled: true);

            Assert.Equal(ExportResult.Success, exporter.Export(new Batch<Activity>(Array.Empty<Activity>(), 0)));
        }

        [Fact]
        public void RepeatedExportsLeaveTheCachedRouteBatchEmpty()
        {
            var (exporter, _) = CreateExporter(multiTenantEnabled: true);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs), CreateActivity("ikey-b", EastUs)));
            exporter.Export(CreateBatch(CreateActivity("ikey-c", WestUs)));

            var routeBatch = (EndpointRouteBatch?)typeof(AzureMonitorTraceExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(exporter);

            Assert.NotNull(routeBatch);
            Assert.Equal(0, routeBatch!.Count);
        }

        /// <summary>
        /// The non-negotiable constraint: with the gate off nothing about the exported payload
        /// changes, and with it on only the instrumentation key and the consumed routing tags differ.
        /// </summary>
        [Fact]
        public void EnvelopesMatchSingleTenantExceptForTheInstrumentationKey()
        {
            var corpus = new Func<Activity>[]
            {
                () => CreateActivity("ikey-a", EastUs, ActivityKind.Server),
                () => CreateActivity("ikey-a", EastUs, ActivityKind.Client),
                () => CreateActivity("ikey-a", EastUs, ActivityKind.Internal),
            };

            // Without the routing tags the two paths see identical input, so any remaining difference
            // is the conversion itself rather than the tags one path consumes.
            var (singleTenantItems, _) = TraceHelper.OtelToAzureMonitorTrace(
                CreateBatch(corpus.Select(create => StripRoutingTags(create())).ToArray()),
                null,
                "ikey-a",
                sampleRate: 100);

            var routeBatch = Convert(corpus.Select(create => create()).ToArray());

            var singleTenant = Encoding.UTF8.GetString(HttpPipelineHelper.GetSerializedContent(singleTenantItems));
            var multiTenant = Encoding.UTF8.GetString(HttpPipelineHelper.GetSerializedContent(routeBatch[0].TelemetryItems));

            Assert.Equal(Normalize(singleTenant), Normalize(multiTenant));
        }

        private static Activity StripRoutingTags(Activity activity)
        {
            activity.SetTag(SemanticConventions.AttributeMicrosoftInstrumentationKey, null);
            activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionEndpoint, null);

            return activity;
        }

        /// <summary>
        /// Timestamps, durations, and identifiers differ between two runs of the same corpus;
        /// nothing else may.
        /// </summary>
        private static string Normalize(string payload) => Regex.Replace(
            payload,
            "\"(time|duration|id|operation_Id|operation_ParentId|ai\\.operation\\.id|ai\\.operation\\.parentId)\":\"[^\"]*\"",
            "\"$1\":\"\"");

        /// <summary>
        /// With the gate off the multi-tenant machinery must not even be allocated.
        /// </summary>
        [Fact]
        public void GateOffAllocatesNoRouteBatch()
        {
            var (exporter, _) = CreateExporter(multiTenantEnabled: false);

            exporter.Export(CreateBatch(CreateActivity("ikey-a", EastUs)));

            var routeBatch = typeof(AzureMonitorTraceExporter)
                .GetField("_routeBatch", BindingFlags.Instance | BindingFlags.NonPublic)!
                .GetValue(exporter);

            Assert.Null(routeBatch);
        }

        /// <summary>
        /// Everything downstream turns the grouping key back into a <see cref="Uri"/>. IdnHost strips
        /// the brackets from an IPv6 literal, so a naive rebuild produces a key that cannot be parsed.
        /// </summary>
        [Theory]
        [InlineData("https://[::1]/", "https://[::1]/")]
        [InlineData("https://[2001:db8::1]/", "https://[2001:db8::1]/")]
        [InlineData("https://[2001:db8::1]:8443/", "https://[2001:db8::1]:8443/")]
        public void IPv6EndpointsProduceAParseableKey(string ingestionEndpoint, string expected)
        {
            var normalized = TenantRouting.NormalizeEndpoint(ingestionEndpoint);

            Assert.Equal(expected, normalized);
            Assert.Equal(expected, new Uri(normalized!).AbsoluteUri);
        }

        /// <summary>
        /// A key that cannot round-trip would fail long after validation accepted the endpoint, in
        /// code that assumes it already parses.
        /// </summary>
        [Fact]
        public void EveryAcceptedEndpointKeyRoundTripsThroughUri()
        {
            var endpoints = new[]
            {
                EastUs,
                "https://[::1]/",
                "https://gateway.example:8443/ingest",
                "https://eastus-1.in.applicationinsights.azure\u3002com/",
                "https://eastus-1.in.applicationinsights.azure.com./",
            };

            foreach (var endpoint in endpoints)
            {
                var normalized = TenantRouting.NormalizeEndpoint(endpoint);

                Assert.NotNull(normalized);
                Assert.True(Uri.TryCreate(normalized, UriKind.Absolute, out _), $"'{normalized}' from '{endpoint}' is not a parseable Uri");
            }
        }

        private static EndpointRouteBatch Convert(params Activity[] activities)
        {
            var routeBatch = new EndpointRouteBatch();
            TraceHelper.OtelToAzureMonitorTraceMultiTenant(CreateBatch(activities), null, sampleRate: 100, routeBatch);
            return routeBatch;
        }

        private static (AzureMonitorTraceExporter Exporter, MockTransmitter Transmitter) CreateExporter(bool multiTenantEnabled)
        {
            var transmitter = new MockTransmitter(new List<TelemetryItem>());
            var options = new AzureMonitorExporterOptions();
            return (new AzureMonitorTraceExporter(options, transmitter, multiTenantEnabled), transmitter);
        }

        private static Batch<Activity> CreateBatch(params Activity[] activities) => new(activities, activities.Length);

        private static Activity CreateActivity(string? instrumentationKey, string? ingestionEndpoint, ActivityKind kind = ActivityKind.Server)
        {
            var activity = s_activitySource.StartActivity("Test", kind)!;

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

        /// <summary>Enough of a credential to make the exporter treat Entra as configured.</summary>
        private sealed class StubCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("token", DateTimeOffset.UtcNow.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }

        private sealed class SingleTenantOnlyTransmitter : ITransmitter
        {
            public string InstrumentationKey => "single-tenant-ikey";

            public bool Disposed { get; private set; }

            public ValueTask<ExportResult> TrackAsync(IEnumerable<TelemetryItem> telemetryItems, TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, TelemetryItemOrigin origin, bool async, CancellationToken cancellationToken)
                => new(ExportResult.Success);

            public IDisposable BeginPersistOnlyScope() => new NoopScope();

            public void DrainStorage(int waitMilliseconds)
            {
            }

            public void Dispose() => Disposed = true;

            private sealed class NoopScope : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
