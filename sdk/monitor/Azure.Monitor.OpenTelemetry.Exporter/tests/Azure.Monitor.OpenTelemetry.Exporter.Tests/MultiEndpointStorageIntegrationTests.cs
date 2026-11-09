// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;

using OpenTelemetry;

using Xunit;

using TestEventListener = Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework.TestEventListener;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// Multi-endpoint routing with offline storage enabled: what happens to a group that cannot be
    /// delivered, and whether it later reaches the endpoint it was routed to.
    /// </summary>
    public class MultiEndpointStorageIntegrationTests : IDisposable
    {
        private const string ActivitySourceName = nameof(MultiEndpointStorageIntegrationTests);

        private const string EastUs = "https://eastus-1.in.applicationinsights.azure.com/";
        private const string WestUs = "https://westus-2.in.applicationinsights.azure.com/";

        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static readonly ActivityListener s_listener = CreateListener();

        private readonly string _storageDirectory = Path.Combine(Path.GetTempPath(), $"mt-int-{Guid.NewGuid():N}");
        private readonly bool _eagerDrainWasDisabled = TransmitFromStorageHandler.DisableEagerDrainForTesting;

        public MultiEndpointStorageIntegrationTests()
        {
            // A background drain would race every assertion about what is on disk.
            TransmitFromStorageHandler.DisableEagerDrainForTesting = true;
        }

        [Fact]
        public void AFailedGroupIsPersistedToItsOwnEndpointPartition()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using (var exporter = CreateExporter(ingestion, out var transmitter))
            {
                exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

                var partition = transmitter._multiEndpointStorage!.TryGet(EastUs);
                Assert.NotNull(partition);
                Assert.NotEmpty(Directory.GetFiles(partition!.Directory));
            }
        }

        /// <summary>
        /// The whole point of partitioning by endpoint: a blob written for one stamp must be replayed
        /// to that stamp, carrying the same destination's telemetry.
        /// </summary>
        [Fact]
        public void APersistedGroupIsReplayedToTheEndpointItWasRoutedTo()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));
            Assert.Single(ingestion.Requests);

            // The stamp recovers, and the partition drains what the failed export left behind.
            ingestion.SetStatus(EastUs, 200);
            var partition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();

            // Asserted before reading the last request: the failed export already carries the same
            // endpoint and key, so without this a drain that did nothing would pass.
            Assert.Equal(2, ingestion.Requests.Count);

            var replay = ingestion.Requests.Last();
            Assert.Equal(EastUs + "v2.1/track", replay.Uri);
            Assert.Contains("ikey-east", replay.Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// Applications sharing an ingestion endpoint share a partition and a blob.
        /// Both must come back in the single replay that blob produces.
        /// </summary>
        [Fact]
        public void ApplicationsSharingAnEndpointArePersistedAndReplayedTogether()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east-a", EastUs),
                CreateActivity("ikey-east-b", EastUs)));

            // One endpoint, so one partition holding one blob for both applications.
            var partition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            Assert.Single(transmitter._multiEndpointStorage.Partitions);

            var blob = Directory.GetFiles(partition.Directory, "*.blob").Single();
            var persisted = Encoding.UTF8.GetString(File.ReadAllBytes(blob));
            Assert.Contains("ikey-east-a", persisted, StringComparison.Ordinal);
            Assert.Contains("ikey-east-b", persisted, StringComparison.Ordinal);

            ingestion.SetStatus(EastUs, 200);
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();
            partition.TransmitFromStorageHandler.Drain();

            Assert.Equal(2, ingestion.Requests.Count);

            var replay = ingestion.Requests.Last();
            Assert.Equal(EastUs + "v2.1/track", replay.Uri);
            Assert.Contains("ikey-east-a", replay.Body, StringComparison.Ordinal);
            Assert.Contains("ikey-east-b", replay.Body, StringComparison.Ordinal);
        }

        /// <summary>
        /// Back-off is per endpoint, so a throttled stamp must not stop a healthy one.
        /// </summary>
        [Fact]
        public void BackOffOnOneEndpointDoesNotStopAnother()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 429);

            using var exporter = CreateExporter(ingestion, out var transmitter);

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs)));

            Assert.Equal(TransmissionState.Open, transmitter._multiEndpointStorage!.TryGet(EastUs)!.TransmissionStateManager.State);
            Assert.Equal(TransmissionState.Closed, transmitter._multiEndpointStorage.TryGet(WestUs)!.TransmissionStateManager.State);

            ingestion.Requests.Clear();

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("ikey-west", WestUs)));

            // East is backed off and goes to disk; West is unaffected and still transmits.
            var request = Assert.Single(ingestion.Requests);
            Assert.Equal(WestUs + "v2.1/track", request.Uri);
            Assert.Contains("ikey-west", request.Body, StringComparison.Ordinal);
        }

        [Fact]
        public void AadAndInstrumentationKeyGroupsForOneEndpointArePersistedSeparately()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter, new RecordingCredential());

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

            Assert.Equal(2, ingestion.Requests.Count);
            Assert.All(ingestion.Requests, request => Assert.Equal(EastUs + "v2.1/track", request.Uri));

            var ikeyPartition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            var aadPartition = transmitter._multiEndpointStorage.TryGet(EastUs, isAad: true)!;
            Assert.Equal(2, transmitter._multiEndpointStorage.Partitions.Count());
            Assert.NotEqual(ikeyPartition.Directory, aadPartition.Directory);

            var ikeyBlob = Encoding.UTF8.GetString(File.ReadAllBytes(Directory.GetFiles(ikeyPartition.Directory, "*.blob").Single()));
            var aadBlob = Encoding.UTF8.GetString(File.ReadAllBytes(Directory.GetFiles(aadPartition.Directory, "*.blob").Single()));

            Assert.Contains("ikey-east", ikeyBlob, StringComparison.Ordinal);
            Assert.DoesNotContain("aad-east", ikeyBlob, StringComparison.Ordinal);
            Assert.Contains("aad-east", aadBlob, StringComparison.Ordinal);
            Assert.DoesNotContain("ikey-east", aadBlob, StringComparison.Ordinal);
        }

        [Fact]
        public void BackOffOnAnAadRouteDoesNotStopTheInstrumentationKeyRouteToTheSameEndpoint()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out var transmitter, new RecordingCredential());

            transmitter._multiEndpointStorage!.TryGet(EastUs, isAad: true)!.TransmissionStateManager.OpenTransmission();

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

            // The AAD route is backed off and goes to disk; the instrumentation-key route still transmits.
            var request = Assert.Single(ingestion.Requests);
            Assert.Contains("ikey-east", request.Body, StringComparison.Ordinal);
            Assert.DoesNotContain("aad-east", request.Body, StringComparison.Ordinal);
        }

        [Fact]
        public void OnlyTheAadRouteCarriesAToken()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out _, new RecordingCredential());

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("aad-east", EastUs, ingestionAuth: "aad"),
                CreateActivity("ikey-west", WestUs)));

            Assert.Equal(3, ingestion.Requests.Count);

            var aad = Assert.Single(ingestion.Requests.Where(r => r.Body.Contains("aad-east")));
            Assert.Equal("Bearer " + RecordingCredential.Token, aad.Authorization);

            Assert.All(
                ingestion.Requests.Where(r => !r.Body.Contains("aad-east")),
                request => Assert.Null(request.Authorization));
        }

        [Fact]
        public void TheAadRouteTokenUsesThePublicCloudScopeByDefault()
        {
            var ingestion = new MockIngestion();
            var credential = new RecordingCredential();
            using var exporter = CreateExporter(ingestion, out _, credential);

            exporter.Export(CreateBatch(CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

            Assert.Equal(new[] { AadHelper.DefaultAadScope }, credential.RequestedScopes.Distinct());
        }

        // AppContext data is process-wide, so it is always cleared; tests in this assembly run serially.
        [Fact]
        public void TheAadRouteTokenUsesTheConfiguredAudience()
        {
            AppDomain.CurrentDomain.SetData(MultiEndpointConfig.AadAudienceName, " https://monitor.azure.cn/ ");

            try
            {
                var ingestion = new MockIngestion();
                var credential = new RecordingCredential();
                using var exporter = CreateExporter(ingestion, out _, credential);

                exporter.Export(CreateBatch(CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

                Assert.Equal(new[] { "https://monitor.azure.cn//.default" }, credential.RequestedScopes.Distinct());
            }
            finally
            {
                AppDomain.CurrentDomain.SetData(MultiEndpointConfig.AadAudienceName, null);
            }
        }

        [Fact]
        public void ANonStringAudienceIsIgnoredInFavourOfThePublicCloud()
        {
            AppDomain.CurrentDomain.SetData(MultiEndpointConfig.AadAudienceName, 42);

            try
            {
                using var listener = new TestEventListener();
                listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

                Assert.Equal(AadHelper.DefaultAadScope, MultiEndpointConfig.GetAadScope());

                var ignored = Assert.Single(listener.Messages.Where(e => e.EventName == "MultiEndpointAadAudienceIgnored"));
                Assert.Equal(MultiEndpointConfig.AadAudienceName, ignored.Payload![0]);
            }
            finally
            {
                AppDomain.CurrentDomain.SetData(MultiEndpointConfig.AadAudienceName, null);
            }
        }

        [Fact]
        public void EachPartitionDrainsWithItsRoutesAuthentication()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter, new RecordingCredential());

            exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

            ingestion.SetStatus(EastUs, 200);
            ingestion.Requests.Clear();

            foreach (var isAad in new[] { false, true })
            {
                var partition = transmitter._multiEndpointStorage!.TryGet(EastUs, isAad)!;
                partition.TransmissionStateManager.ResetConsecutiveErrors();
                partition.TransmissionStateManager.CloseTransmission();
                partition.TransmitFromStorageHandler.Drain();
            }

            Assert.Equal(2, ingestion.Requests.Count);

            var aadReplay = Assert.Single(ingestion.Requests.Where(r => r.Body.Contains("aad-east")));
            Assert.Equal("Bearer " + RecordingCredential.Token, aadReplay.Authorization);

            var ikeyReplay = Assert.Single(ingestion.Requests.Where(r => r.Body.Contains("ikey-east")));
            Assert.Null(ikeyReplay.Authorization);
        }

        [Fact]
        public void AadTelemetryIsDroppedWhenNoCredentialIsConfigured()
        {
            var ingestion = new MockIngestion();
            using var exporter = CreateExporter(ingestion, out var transmitter);
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            var result = exporter.Export(CreateBatch(
                CreateActivity("ikey-east", EastUs),
                CreateActivity("aad-east", EastUs, ingestionAuth: "aad")));

            Assert.Equal(ExportResult.Failure, result);

            var request = Assert.Single(ingestion.Requests);
            Assert.Contains("ikey-east", request.Body, StringComparison.Ordinal);
            Assert.DoesNotContain("aad-east", request.Body, StringComparison.Ordinal);
            Assert.Null(request.Authorization);

            Assert.Null(transmitter._multiEndpointStorage!.TryGet(EastUs, isAad: true));
            Assert.DoesNotContain(transmitter._multiEndpointStorage.Partitions, p => p.Directory.EndsWith(HashHelper.GetSHA256Hash(MultiEndpointStorage.AadPartitionKeyPrefix + EastUs), StringComparison.Ordinal));

            var dropped = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedAadTelemetryDroppedWithoutCredential"));
            Assert.Equal(1, dropped.Payload![1]);
            Assert.Equal(EastUs + EndpointRouting.AadRouteSuffix, dropped.Payload[2]);
        }

        [Theory]
        [InlineData(false, 401, "microsoft.ingestion_auth")]
        [InlineData(true, 403, "Monitoring Metrics Publisher")]
        [InlineData(true, 401, "MultiEndpointAadAudience")]
        public void AnAuthenticationFailureNamesTheRouteAndTheLikelyFix(bool isAad, int statusCode, string hint)
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, statusCode);
            using var exporter = CreateExporter(ingestion, out _, isAad ? new RecordingCredential() : null);
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs, ingestionAuth: isAad ? "aad" : null)));

            var failed = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedAuthenticationFailed"));
            Assert.Equal(isAad ? EastUs + EndpointRouting.AadRouteSuffix : EastUs, failed.Payload![0]);
            Assert.Equal(statusCode, failed.Payload[1]);
            Assert.Contains(hint, (string)failed.Payload[2]!, StringComparison.Ordinal);
        }

        [Fact]
        public void OtherFailuresDoNotReportAnAuthenticationFailure()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);
            using var exporter = CreateExporter(ingestion, out _);
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            Assert.DoesNotContain(listener.Messages, e => e.EventName == "RoutedAuthenticationFailed");
        }

        [Fact]
        public void AnAuthenticationFailureOnReplayNamesTheRoute()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);
            using var exporter = CreateExporter(ingestion, out var transmitter);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            ingestion.SetStatus(EastUs, 401);
            var partition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            partition.TransmissionStateManager.ResetConsecutiveErrors();
            partition.TransmissionStateManager.CloseTransmission();

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            partition.TransmitFromStorageHandler.Drain();

            var failed = Assert.Single(listener.Messages.Where(e => e.EventName == "RoutedAuthenticationFailed"));
            Assert.Equal(EastUs, failed.Payload![0]);
            Assert.Equal(401, failed.Payload[1]);
        }

        [Fact]
        public void TransmissionFailureWithoutAConnectionStringShowsNoConfiguredDestination()
        {
            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Critical, EventKeywords.All);

            AzureMonitorExporterEventSource.Log.TransmissionFailed(500, TelemetryItemOrigin.UnitTest, isAadEnabled: false, willRetry: false, ConnectionVars.CreateUnconfigured(), "eastus-1.in.applicationinsights.azure.com", response: null);

            var failed = Assert.Single(listener.Messages.Where(e => e.EventId == 8));
            Assert.Equal("none", failed.Payload![5]);
            Assert.Equal("none", failed.Payload[6]);
        }

        [Fact]
        public void PartitionsAreCreatedOutsideTheHostStorageDirectory()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter);

            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            var partition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            var hostDirectory = transmitter._fileBlobProvider == null ? null : GetHostStorageDirectory(transmitter);

            Assert.NotNull(hostDirectory);
            Assert.False(partition.Directory.StartsWith(hostDirectory + Path.DirectorySeparatorChar, StringComparison.Ordinal));
        }

        public void Dispose()
        {
            TransmitFromStorageHandler.DisableEagerDrainForTesting = _eagerDrainWasDisabled;

            try
            {
                // Partitions live in a sibling root, so deleting only the host directory leaves the
                // routed blobs behind on every run.
                foreach (var directory in new[] { _storageDirectory, _storageDirectory + MultiEndpointStorage.RootDirectorySuffix })
                {
                    if (Directory.Exists(directory))
                    {
                        Directory.Delete(directory, recursive: true);
                    }
                }
            }
            catch (IOException)
            {
                // A handle may still be open; the temp directory ages out either way.
            }

            GC.SuppressFinalize(this);
        }

        private static string? GetHostStorageDirectory(AzureMonitorTransmitter transmitter) =>
            typeof(AzureMonitorTransmitter)
                .GetField("_storageDirectory", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.GetValue(transmitter) as string;

        private AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, out AzureMonitorTransmitter transmitter, TokenCredential? credential = null)
        {
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-0000000000ff;IngestionEndpoint={EastUs}",
                Transport = ingestion.Transport,
                StorageDirectory = _storageDirectory,
                EnableStatsbeat = false,
                Credential = credential,
            };

            transmitter = new AzureMonitorTransmitter(options, DefaultPlatform.Instance, multiEndpointEnabled: true);

            return new AzureMonitorTraceExporter(options, transmitter, multiEndpointEnabled: true);
        }

        private static Batch<Activity> CreateBatch(params Activity[] activities) => new(activities, activities.Length);

        private static Activity CreateActivity(string instrumentationKey, string ingestionEndpoint, string? ingestionAuth = null)
        {
            var activity = s_activitySource.StartActivity("StorageIntegrationTest", ActivityKind.Server)!;
            activity.SetTag(SemanticConventions.AttributeMicrosoftInstrumentationKey, instrumentationKey);
            activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionEndpoint, ingestionEndpoint);

            if (ingestionAuth != null)
            {
                activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionAuth, ingestionAuth);
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

        private sealed class MockIngestion
        {
            private readonly Dictionary<string, int> _statusByEndpoint = new(StringComparer.Ordinal);

            internal MockIngestion()
            {
                Transport = new MockTransport(Respond);
            }

            internal MockTransport Transport { get; }

            internal List<CapturedRequest> Requests { get; } = new();

            internal void SetStatus(string ingestionEndpoint, int statusCode) => _statusByEndpoint[new Uri(ingestionEndpoint).Host] = statusCode;

            private MockResponse Respond(Request request)
            {
                var host = request.Uri.Host ?? string.Empty;

                lock (Requests)
                {
                    request.Headers.TryGetValue("Authorization", out var authorization);
                    Requests.Add(new CapturedRequest(request.Uri.ToString(), ReadBody(request), authorization));
                }

                return new MockResponse(_statusByEndpoint.TryGetValue(host, out var status) ? status : 200);
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
            internal CapturedRequest(string uri, string body, string? authorization)
            {
                Uri = uri;
                Body = body;
                Authorization = authorization;
            }

            internal string Uri { get; }

            internal string Body { get; }

            internal string? Authorization { get; }
        }

        /// <summary>Issues a fixed token and records every scope it was asked for.</summary>
        private sealed class RecordingCredential : TokenCredential
        {
            internal const string Token = "routed-aad-token";

            private readonly List<string> _requestedScopes = new();

            internal IReadOnlyList<string> RequestedScopes
            {
                get
                {
                    lock (_requestedScopes)
                    {
                        return _requestedScopes.ToArray();
                    }
                }
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                lock (_requestedScopes)
                {
                    _requestedScopes.AddRange(requestContext.Scopes);
                }

                return new AccessToken(Token, DateTimeOffset.UtcNow.AddHours(1));
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}
