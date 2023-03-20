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
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Extensions.PersistentStorage.Abstractions;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class OfflineStorageTests
    {
        private static readonly ActivitySource activitySource = new ActivitySource("OTel.Storage");

        private const string testIkey = "test_ikey";
        private const string testEndpoint = "http://localhost:5050";

        static OfflineStorageTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            HttpPipelineHelper.MinimumRetryInterval = 6000;
        }

        [Fact]
        public void Success200()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponse = new MockResponse(200).SetContent("Ok");
            using var transmitter = GetTransmitter(mockResponse);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Empty(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void FailureResponseCode500()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponse = new MockResponse(500).SetContent("Internal Server Error");
            using var transmitter = GetTransmitter(mockResponse);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void FailureResponseCode429()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponse = new MockResponse(429)
                                    .AddHeader("Retry-After", "6")
                                    .SetContent("Too Many Requests");
            using var transmitter = GetTransmitter(mockResponse);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void FailureResponseCode206()
        {
            using var activity1 = CreateActivity("TestActivity1");
            using var activity2 = CreateActivity("TestActivity2");
            using var activity3 = CreateActivity("TestActivity3");
            var telemetryItem1 = CreateTelemetryItem(activity1);
            var telemetryItem2 = CreateTelemetryItem(activity2);
            var telemetryItem3 = CreateTelemetryItem(activity3);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem1);
            telemetryItems.Add(telemetryItem2);
            telemetryItems.Add(telemetryItem3);

            // Transmit
            var mockResponse = new MockResponse(206)
                                    .AddHeader("Retry-After", "6")
                                    .SetContent("{\"itemsReceived\": 3,\"itemsAccepted\": 1,\"errors\":[{\"index\": 0,\"statusCode\": 429,\"message\": \"Throttle\"},{\"index\": 1,\"statusCode\": 429,\"message\": \"Throttle\"}]}");
            using var transmitter = GetTransmitter(mockResponse);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
            Assert.True(transmitter._fileBlobProvider.TryGetBlob(out var blob));
            blob.TryRead(out var content);

            Assert.NotNull(content);

            var failedData = System.Text.Encoding.UTF8.GetString(content);

            string[] items = failedData.Split('\n');

            //Assert
            Assert.Equal(2, items.Count());
        }

        // TODO: REWRITE THIS TEST FOR IDISPOSABLE
        [Fact]
        public void TransmitFromStorage()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            //Even though we are using different transmitter instances
            // we need to use the same instance of fileProvider for this test.
            var mockFileProvider = new MockFileProvider();
            // Transmit
            var mockResponse = new MockResponse(500).SetContent("Internal Server Error");
            var transmitter = GetTransmitter(mockResponse);
            transmitter._fileBlobProvider = mockFileProvider;
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            // reset server logic to return 200
            mockResponse = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            transmitter = GetTransmitter(mockResponse);
            transmitter._fileBlobProvider = mockFileProvider;

            transmitter.TransmitFromStorage(1, false, CancellationToken.None).EnsureCompleted();

            // Assert
            // Blob will be deleted on successful transmission
            Assert.Empty(transmitter._fileBlobProvider.GetBlobs());
        }

        // TODO: Remove TransmitFromStorage() test after moving to new implementation
        [Fact]
        public void TransmitFromStorage_New()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            //Even though we are using different transmitter instances
            // we need to use the same instance of fileProvider for this test.
            var mockFileProvider = new MockFileProvider();
            // Transmit
            var mockResponse = new MockResponse(500).SetContent("Internal Server Error");
            var transmitter1 = GetTransmitter(mockResponse);
            transmitter1._fileBlobProvider = mockFileProvider;
            transmitter1.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            //Assert
            Assert.Single(transmitter1._fileBlobProvider.GetBlobs());

            // reset server logic to return 200
            mockResponse = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            var transmitter2 = GetTransmitter(mockResponse);
            transmitter2._fileBlobProvider = mockFileProvider;

            var transmitFromStorageHandler = new TransmitFromStorageHandler(transmitter2._applicationInsightsRestClient, transmitter2._fileBlobProvider);
            transmitFromStorageHandler.TransmitFromStorage(null, null);

            // Assert
            // Blob will be deleted on successful transmission
            Assert.Empty(transmitter2._fileBlobProvider.GetBlobs());

            transmitter1.Dispose();
            transmitter2.Dispose();
        }

        private static AzureMonitorTransmitter GetTransmitter(MockResponse mockResponse)
        {
            MockTransport mockTransport = new MockTransport(mockResponse);
            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                StorageDirectory = StorageHelper.GetDefaultStorageDirectory() + "\\test",
                Transport = mockTransport,
                EnableStatsbeat = false, // disabled in tests.
            };
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);

            // Overwrite storage with mock
            transmitter._fileBlobProvider = new MockFileProvider();

            return transmitter;
        }

        private static Activity CreateActivity(string activityName)
        {
            ActivitySource activitySource = new ActivitySource("OTel.Storage");
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
            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            return new TelemetryItem(activity, ref monitorTags, null, string.Empty);
        }

        private class MockFileProvider : PersistentBlobProvider
        {
            private readonly List<PersistentBlob> _mockStorage = new();

            public IEnumerable<PersistentBlob> TryGetBlobs() => this._mockStorage.AsEnumerable();

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
                blob = this.GetBlobs().First();

                return true;
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
