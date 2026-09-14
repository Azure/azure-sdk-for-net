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
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

using OpenTelemetry;

using Xunit;

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
            Assert.Single(transmitter._multiEndpointStorage!.Partitions);

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
            Assert.Equal(TransmissionState.Closed, transmitter._multiEndpointStorage!.TryGet(WestUs)!.TransmissionStateManager.State);

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

        /// <summary>
        /// The header applies to a whole request, so one endpoint's two auth modes cannot share a
        /// partition: a blob is re-POSTed long after the telemetry that asked to be authenticated.
        /// </summary>
        [Fact]
        public void EachAuthModeGetsItsOwnPartition()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using (var exporter = CreateExporter(ingestion, new StorageStubCredential(), out var transmitter))
            {
                exporter.Export(CreateBatch(
                    CreateActivity("ikey-auth", EastUs, useAadAuth: true),
                    CreateActivity("ikey-key-only", EastUs)));

                var authenticated = transmitter._multiEndpointStorage!.TryGet(EastUs, useAadAuth: true);
                var unauthenticated = transmitter._multiEndpointStorage!.TryGet(EastUs, useAadAuth: false);

                Assert.NotNull(authenticated);
                Assert.NotNull(unauthenticated);
                Assert.NotEqual(authenticated!.Directory, unauthenticated!.Directory);

                Assert.Contains("ikey-auth", ReadBlobs(authenticated), StringComparison.Ordinal);
                Assert.Contains("ikey-key-only", ReadBlobs(unauthenticated), StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// The directory for unauthenticated telemetry must not move, or every blob written by an
        /// earlier version is orphaned on upgrade.
        /// </summary>
        [Fact]
        public void TheUnauthenticatedPartitionKeepsItsPreExistingDirectory()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            using var exporter = CreateExporter(ingestion, out var transmitter);
            exporter.Export(CreateBatch(CreateActivity("ikey-east", EastUs)));

            var partition = transmitter._multiEndpointStorage!.TryGet(EastUs)!;
            var expected = Path.Combine(
                GetHostStorageDirectory(transmitter) + MultiEndpointStorage.RootDirectorySuffix,
                HashHelper.GetSHA256Hash(EastUs));

            Assert.Equal(expected, partition.Directory);
        }

        /// <summary>
        /// Once an endpoint opts in, nothing else opens the partition its earlier telemetry was
        /// written to, so without an explicit probe that backlog is never transmitted.
        /// </summary>
        [Fact]
        public void APartitionLeftByTheOtherAuthModeIsStillDrained()
        {
            var ingestion = new MockIngestion();
            ingestion.SetStatus(EastUs, 500);

            string strandedDirectory;

            using (var exporter = CreateExporter(ingestion, out var transmitter))
            {
                exporter.Export(CreateBatch(CreateActivity("ikey-key-only", EastUs)));
                strandedDirectory = transmitter._multiEndpointStorage!.TryGet(EastUs)!.Directory;
                Assert.NotEmpty(Directory.GetFiles(strandedDirectory, "*.blob"));
            }

            // A new process, now stamping the flag, must still find the old partition.
            using (var exporter = CreateExporter(ingestion, new StorageStubCredential(), out var transmitter))
            {
                exporter.Export(CreateBatch(CreateActivity("ikey-auth", EastUs, useAadAuth: true)));

                Assert.Contains(
                    transmitter._multiEndpointStorage!.Partitions,
                    partition => partition.Directory == strandedDirectory);
            }
        }

        private static string ReadBlobs(MultiEndpointStorage.EndpointStorage partition)
        {
            var contents = new StringBuilder();

            foreach (var blob in Directory.GetFiles(partition.Directory, "*.blob"))
            {
                contents.Append(Encoding.UTF8.GetString(File.ReadAllBytes(blob)));
            }

            return contents.ToString();
        }

        private sealed class StorageStubCredential : Azure.Core.TokenCredential
        {
            public override Azure.Core.AccessToken GetToken(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken)
                => new("storage-token", DateTimeOffset.UtcNow.AddHours(1));

            public override System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.TokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }

        private static string? GetHostStorageDirectory(AzureMonitorTransmitter transmitter) =>
            typeof(AzureMonitorTransmitter)
                .GetField("_storageDirectory", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.GetValue(transmitter) as string;

        private AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, out AzureMonitorTransmitter transmitter)
            => CreateExporter(ingestion, credential: null, out transmitter);

        private AzureMonitorTraceExporter CreateExporter(MockIngestion ingestion, Azure.Core.TokenCredential? credential, out AzureMonitorTransmitter transmitter)
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

        private static Activity CreateActivity(string instrumentationKey, string ingestionEndpoint, bool useAadAuth = false)
        {
            var activity = s_activitySource.StartActivity("StorageIntegrationTest", ActivityKind.Server)!;
            activity.SetTag(SemanticConventions.AttributeMicrosoftInstrumentationKey, instrumentationKey);
            activity.SetTag(SemanticConventions.AttributeMicrosoftIngestionEndpoint, ingestionEndpoint);

            if (useAadAuth)
            {
                activity.SetTag(SemanticConventions.AttributeMicrosoftUseAadAuth, true);
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
                    Requests.Add(new CapturedRequest(request.Uri.ToString(), ReadBody(request)));
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
