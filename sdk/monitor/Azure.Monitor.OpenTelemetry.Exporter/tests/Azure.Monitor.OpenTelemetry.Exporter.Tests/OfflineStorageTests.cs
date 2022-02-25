﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Contrib.Extensions.PersistentStorage;
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
            var transmitter = GetTransmitter(mockResponse);
            // Clean up existing files from previous run if exists.
            ClearFiles(transmitter);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for maintenance job to run atleast once
            Task.Delay(10000).Wait();

            //Assert
            Assert.Empty(transmitter._storage.GetBlobs());
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
            var transmitter = GetTransmitter(mockResponse);
            // Clean up existing files from previous run if exists.
            ClearFiles(transmitter);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for maintenance job to run atleast once
            Task.Delay(10000).Wait();

            //Assert
            Assert.Single(transmitter._storage.GetBlobs());

            // Delete the blob
            transmitter._storage.GetBlob().Lease(1000).Delete();
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
            var transmitter = GetTransmitter(mockResponse);
            // Clean up existing files from previous run if exists.
            ClearFiles(transmitter);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for maintenance job to run atleast once
            Task.Delay(10000).Wait();

            //Assert
            Assert.Single(transmitter._storage.GetBlobs());

            // Delete the blob
            transmitter._storage.GetBlob().Lease(1000).Delete();
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
            var transmitter = GetTransmitter(mockResponse);
            // Clean up existing files from previous run if exists.
            ClearFiles(transmitter);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for maintenance job to run atleast once
            Task.Delay(10000).Wait();

            //Assert
            Assert.Single(transmitter._storage.GetBlobs());

            var failedData = System.Text.Encoding.UTF8.GetString(transmitter._storage.GetBlob().Read());

            string[] items = failedData.Split('\n');

            //Assert
            Assert.Equal(2, items.Count());

            // Delete the blob
            transmitter._storage.GetBlob().Lease(1000).Delete();
        }

        [Fact]
        public void TransmitFromStorage()
        {
            using var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            // Transmit
            var mockResponse = new MockResponse(500).SetContent("Internal Server Error");
            var transmitter = GetTransmitter(mockResponse);
            // Clean up existing files from previous run if exists.
            ClearFiles(transmitter);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for maintenance job to run atleast once
            Task.Delay(10000).Wait();

            //Assert
            Assert.Single(transmitter._storage.GetBlobs());

            // reset server logic to return 200
            mockResponse = new MockResponse(200).SetContent("{\"itemsReceived\": 1,\"itemsAccepted\": 1,\"errors\":[]}");
            transmitter = GetTransmitter(mockResponse);

            transmitter.TransmitFromStorage(1, false, CancellationToken.None).EnsureCompleted();

            // Assert
            // Blob will be deleted on successful transmission
            Assert.Empty(transmitter._storage.GetBlobs());
        }

        private static AzureMonitorTransmitter GetTransmitter(MockResponse mockResponse)
        {
            MockTransport mockTransport = new MockTransport(mockResponse);
            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            options.StorageDirectory = StorageHelper.GetDefaultStorageDirectory() + "\\test";
            options.Transport = mockTransport;
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);

            // Overwrite storage to reduce maintenance period
            var fileStorage = new FileStorage(options.StorageDirectory, 5000, 1000);
            transmitter._storage = fileStorage;

            return transmitter;
        }

        private static void ClearFiles(AzureMonitorTransmitter transmitter)
        {
            // clean if there are files in directory
            var fileBlob = transmitter._storage.GetBlob();
            if (fileBlob != null)
            {
                var blob = (FileBlob)fileBlob;
                Array.ForEach(Directory.GetFiles(Path.GetDirectoryName(blob.FullPath)), File.Delete);
            }
        }

        private static Activity CreateActivity(string activityName)
        {
            ActivitySource activitySource = new ActivitySource("OTel.Storage");
            var activity = activitySource.StartActivity(
                activityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            return activity;
        }

        private static TelemetryItem CreateTelemetryItem(Activity activity)
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            return new TelemetryItem(activity, ref monitorTags);
        }
    }
}
