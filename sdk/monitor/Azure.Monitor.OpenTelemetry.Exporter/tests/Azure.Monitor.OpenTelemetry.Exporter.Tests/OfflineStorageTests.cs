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
using OpenTelemetry.PersistentStorage.Abstractions;
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
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

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
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

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
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());
        }

        [Fact]
        public void NetworkFailure()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            using var transmitter = GetTransmitter(null);
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

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
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

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

        [Fact]
        public void TelemetryIsTransmittedSuccessfullyFromStorage()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponseError = new MockResponse(500).SetContent("Internal Server Error");
            var mockResponseSuccess = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            var transmitter = GetTransmitter(mockResponseError, mockResponseSuccess);

            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            Assert.Equal(TransmissionState.Open, transmitter._transmissionStateManager.State);

            // Reset transmission state
            transmitter._transmissionStateManager.ResetConsecutiveErrors();
            transmitter._transmissionStateManager.CloseTransmission();

            transmitter._transmitFromStorageHandler?.TransmitFromStorage(null, null);

            // Assert
            // Blob will be deleted on successful transmission
            Assert.Empty(transmitter._fileBlobProvider.GetBlobs());

            transmitter.Dispose();
        }

        [Fact]
        public void TelemetryIsNotTransmittedWhenTransmissionStateIsOpen()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponseError = new MockResponse(500).SetContent("Internal Server Error");
            var mockResponseSuccess = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            var transmitter = GetTransmitter(mockResponseError, mockResponseSuccess);

            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            Assert.Equal(TransmissionState.Open, transmitter._transmissionStateManager.State);

            transmitter._transmitFromStorageHandler?.TransmitFromStorage(null, null);

            // Assert
            // Blob will not be deleted as the transmission state is open.
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            transmitter.Dispose();
        }

        [Fact]
        public void TransmissionStateIsSetToOpenOnFailedRequest()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponse = new MockResponse(500).SetContent("Internal Server Error");
            var transmitter = GetTransmitter(mockResponse, mockResponse);
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

            //Assert
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            Assert.Equal(TransmissionState.Open, transmitter._transmissionStateManager.State);

            // Reset transmission state
            transmitter._transmissionStateManager.ResetConsecutiveErrors();
            transmitter._transmissionStateManager.CloseTransmission();

            transmitter._transmitFromStorageHandler?.TransmitFromStorage(null, null);

            // Assert
            // Blob will not be deleted as the transmission state is open.
            Assert.Equal(TransmissionState.Open, transmitter._transmissionStateManager.State);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            transmitter.Dispose();
        }

        [Fact]
        public void TelemetryIsStoredOfflineWhenTransmissionStateIsSetToOpen()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>
            {
                telemetryItem
            };

            var mockResponse = new MockResponse(200).SetContent("Ok");
            var transmitter = GetTransmitter(mockResponse);

            // Set the state to Open
            transmitter._transmissionStateManager.OpenTransmission();
            Assert.Equal(TransmissionState.Open, transmitter._transmissionStateManager.State);

            // Transmit
            var telemetryCounter = new TelemetryCounter();
            transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.UnitTest, false, CancellationToken.None, telemetryCounter).EnsureCompleted();

            //Assert
            // Telemetry should be stored offline as the state is open.
            Assert.NotNull(transmitter._fileBlobProvider);
            Assert.Single(transmitter._fileBlobProvider.GetBlobs());

            transmitter.Dispose();
        }

        private static AzureMonitorTransmitter GetTransmitter(params MockResponse[]? mockResponse)
        {
            AzureMonitorTransmitter transmitter;
            AzureMonitorExporterOptions options;
            if (mockResponse == null)
            {
                options = new AzureMonitorExporterOptions
                {
                    ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                    StorageDirectory = "C:\\test",
                    EnableStatsbeat = false, // disabled in tests.
                };
            }
            else
            {
                MockTransport mockTransport = new MockTransport(mockResponse);
                options = new AzureMonitorExporterOptions
                {
                    ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}",
                    StorageDirectory = "C:\\test",
                    Transport = mockTransport,
                    EnableStatsbeat = false, // disabled in tests.
                };
            }

            transmitter = new AzureMonitorTransmitter(options, new MockPlatform());

            // Overwrite storage with mock
            transmitter._fileBlobProvider = new MockFileProvider();
            if (transmitter._transmitFromStorageHandler != null)
            {
                transmitter._transmitFromStorageHandler._blobProvider = transmitter._fileBlobProvider;
            }

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
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            return new TelemetryItem(activity, ref activityTagsProcessor, null, string.Empty, 1.0f);
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
