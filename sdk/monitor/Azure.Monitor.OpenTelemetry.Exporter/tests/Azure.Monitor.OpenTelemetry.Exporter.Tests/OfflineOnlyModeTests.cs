// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class OfflineOnlyModeTests
    {
        private static readonly ActivitySource activitySource = new ActivitySource("OTel.OfflineOnlyMode");

        private const string testIkey = "test_ikey";
        private const string testEndpoint = "http://localhost:5050";

        static OfflineOnlyModeTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [Fact]
        public void OfflineOnlyMode_PersistsToStorageWithoutNetwork()
        {
            // Arrange: configure offline-only mode — network is bypassed entirely
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            var telemetryItems = new List<TelemetryItem> { telemetryItem };

            using var transmitter = GetTransmitter(enableOfflineOnlyMode: true);
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            // Act
            var result = transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.UnitTest, false, CancellationToken.None).EnsureCompleted();

            // Assert: telemetry was saved to offline storage (not sent via network)
            Assert.Equal(ExportResult.Success, result);
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void OfflineOnlyMode_DoesNotAttemptNetworkTransmission()
        {
            // Arrange: use offline-only mode — even with a transport configured,
            // no network call should be made. We verify this by checking that
            // TransmissionState remains Closed (not set to Open from a failure).
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            var telemetryItems = new List<TelemetryItem> { telemetryItem };

            // Configure with a transport that returns 500 — if network were called,
            // transmission state would go to Open.
            var mockTransport = new MockTransport(new MockResponse(500).SetContent("Error"));
            using var transmitter = GetTransmitter(enableOfflineOnlyMode: true, transport: mockTransport);
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            // Act
            transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.UnitTest, false, CancellationToken.None).EnsureCompleted();

            // Assert: transmission state is still Closed (network was never called)
            Assert.Equal(TransmissionState.Closed, transmitter._transmissionStateManager.State);
            // And telemetry was persisted
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void OfflineOnlyMode_MultipleTelemetryItemsAllPersisted()
        {
            // Arrange
            using var activity1 = CreateActivity("Activity1");
            using var activity2 = CreateActivity("Activity2");
            using var activity3 = CreateActivity("Activity3");
            var telemetryItems = new List<TelemetryItem>
            {
                CreateTelemetryItem(activity1),
                CreateTelemetryItem(activity2),
                CreateTelemetryItem(activity3),
            };

            using var transmitter = GetTransmitter(enableOfflineOnlyMode: true);
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            // Act
            var result = transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.UnitTest, false, CancellationToken.None).EnsureCompleted();

            // Assert: all items persisted in a single blob
            Assert.Equal(ExportResult.Success, result);
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void OfflineOnlyMode_ThrowsWhenStorageDisabled()
        {
            // Arrange & Act & Assert: cannot have both disabled — no destination for telemetry
            Assert.Throws<InvalidOperationException>(() =>
                GetTransmitter(enableOfflineOnlyMode: true, disableStorage: true));
        }

        [Fact]
        public void FlushOfflineStorage_UploadsPersistedTelemetry()
        {
            // Arrange: simulate a failed transmission that persists to storage,
            // then flush it via DrainAll with a successful response configured.
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            var telemetryItems = new List<TelemetryItem> { telemetryItem };

            var mockResponseSuccess = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            var transmitter = GetTransmitter(enableOfflineOnlyMode: false, mockResponses: mockResponseSuccess);
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();

            // First, simulate a failed transmission that persists to storage
            transmitter._transmissionStateManager.OpenTransmission();
            transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.UnitTest, false, CancellationToken.None).EnsureCompleted();

            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            // Reset state so flush can succeed
            transmitter._transmissionStateManager.ResetConsecutiveErrors();
            transmitter._transmissionStateManager.CloseTransmission();

            // Act: call FlushOfflineStorage
            transmitter.FlushOfflineStorage();

            // Assert: blob was uploaded and deleted
            Assert.Empty(transmitter._fileBlobProvider.GetBlobs());

            transmitter.Dispose();
        }

        [Fact]
        public void FlushOfflineStorage_NoOpWhenNoStorageHandler()
        {
            // Arrange: transmitter with no storage handler (DisableOfflineStorage=true)
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                DisableOfflineStorage = true,
                EnableStatsbeat = false,
            };

            var transmitter = new AzureMonitorTransmitter(options, new MockPlatform());

            // Act & Assert: should not throw
            transmitter.FlushOfflineStorage();

            transmitter.Dispose();
        }

        [Fact]
        public void StorageTransmitInterval_DisablesTimerWithInfiniteTimeSpan()
        {
            // Arrange
            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                StorageDirectory = "C:\\test",
                StorageTransmitInterval = Timeout.InfiniteTimeSpan,
                EnableStatsbeat = false,
            };

            var transmitter = new AzureMonitorTransmitter(options, new MockPlatform());

            // Overwrite with mock storage
            transmitter._fileBlobProvider = new MockFileProvider();
            if (transmitter._transmitFromStorageHandler != null)
            {
                transmitter._transmitFromStorageHandler._blobProvider = transmitter._fileBlobProvider;
            }

            // Assert: transmitter was created successfully and handler exists
            // (timer just won't fire automatically)
            Assert.NotNull(transmitter._transmitFromStorageHandler);

            transmitter.Dispose();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-5000)]
        public void StorageTransmitInterval_ThrowsOnInvalidValues(int milliseconds)
        {
            var options = new AzureMonitorExporterOptions();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                options.StorageTransmitInterval = TimeSpan.FromMilliseconds(milliseconds));
        }

        [Fact]
        public void StorageTransmitInterval_ThrowsOnExcessiveValues()
        {
            var options = new AzureMonitorExporterOptions();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                options.StorageTransmitInterval = TimeSpan.MaxValue);
        }

        private static AzureMonitorTransmitter GetTransmitter(
            bool enableOfflineOnlyMode = false,
            bool disableStorage = false,
            MockTransport? transport = null,
            params MockResponse[] mockResponses)
        {
            MockTransport? mockTransport = transport;
            if (mockTransport == null && mockResponses.Length > 0)
            {
                mockTransport = new MockTransport(mockResponses);
            }

            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                StorageDirectory = disableStorage ? null : "C:\\test",
                DisableOfflineStorage = disableStorage,
                DisableNetworkTransmission = enableOfflineOnlyMode,
                EnableStatsbeat = false,
            };

            if (mockTransport != null)
            {
                options.Transport = mockTransport;
            }

            var transmitter = new AzureMonitorTransmitter(options, new MockPlatform());

            if (!disableStorage)
            {
                // Overwrite storage with mock
                transmitter._fileBlobProvider = new MockFileProvider();
                if (transmitter._transmitFromStorageHandler != null)
                {
                    transmitter._transmitFromStorageHandler._blobProvider = transmitter._fileBlobProvider;
                }
            }

            return transmitter;
        }

        private static Activity CreateActivity(string activityName)
        {
            var activity = activitySource.StartActivity(
                activityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            return activity;
        }

        private static TelemetryItem CreateTelemetryItem(Activity activity)
        {
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            return new TelemetryItem(activity, ref activityTagsProcessor, null, string.Empty, 1.0f);
        }

        private class MockFileProvider : PersistentBlobProvider
        {
            private readonly List<PersistentBlob> _mockStorage = new();

            protected override IEnumerable<PersistentBlob> OnGetBlobs()
            {
                return this._mockStorage.AsEnumerable();
            }

            protected override bool OnTryCreateBlob(byte[] buffer, int leasePeriodMilliseconds, out PersistentBlob blob)
            {
                blob = new MockFileBlob(_mockStorage);
                return blob.TryWrite(buffer);
            }

            protected override bool OnTryCreateBlob(byte[] buffer, out PersistentBlob blob)
            {
                blob = new MockFileBlob(_mockStorage);
                return blob.TryWrite(buffer);
            }

            protected override bool OnTryGetBlob(out PersistentBlob blob)
            {
                if (_mockStorage.Any())
                {
                    blob = _mockStorage.First();
                    return true;
                }

                blob = null!;
                return false;
            }
        }

        private class MockFileBlob : PersistentBlob
        {
            private byte[] _buffer = Array.Empty<byte>();
            private readonly List<PersistentBlob> _mockStorage;

            public MockFileBlob(List<PersistentBlob> mockStorage)
            {
                _mockStorage = mockStorage;
            }

            protected override bool OnTryRead(out byte[] buffer)
            {
                buffer = this._buffer;
                return true;
            }

            protected override bool OnTryWrite(byte[] buffer, int leasePeriodMilliseconds = 0)
            {
                this._buffer = buffer;
                _mockStorage.Add(this);
                return true;
            }

            protected override bool OnTryLease(int leasePeriodMilliseconds)
            {
                return true;
            }

            protected override bool OnTryDelete()
            {
                try
                {
                    _mockStorage.Remove(this);
                }
                catch
                {
                    return false;
                }

                return true;
            }
        }
    }
}
