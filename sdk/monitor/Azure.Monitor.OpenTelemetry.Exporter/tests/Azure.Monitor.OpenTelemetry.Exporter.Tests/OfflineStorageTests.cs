// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.AspNetCore.Http;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter
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
        }

        [Fact]
        public void Success200()
        {
            var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            using var testServer = new LocalServer(testEndpoint);
            testServer.ServerLogic = async (httpContext) =>
            {
                httpContext.Response.StatusCode = 200;
                await httpContext.Response.WriteAsync("Ok");
            };

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
            // Sleep so that lease period on blob ends.
            // todo: Reduce sleep time
            Thread.Sleep(70000);

            //Assert
            Assert.Empty(transmitter.storage.GetBlobs());
        }

        [Fact]
        public void FailureResponseCode500()
        {
            var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            using var testServer = new LocalServer(testEndpoint);
            testServer.ServerLogic = async (httpContext) =>
            {
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Internal Server Error");
            };

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
            // Sleep so that lease period on blob ends.
            // todo: Reduce sleep time
            Thread.Sleep(70000);

            //Assert
            Assert.Single(transmitter.storage.GetBlobs());
            // Delete the blob
            transmitter.storage.GetBlob().Lease(1000).Delete();
        }

        [Fact]
        public void FailureResponseCode429()
        {
            var activity = CreateActivity("TestActivity");
            var telemetryItem = CreateTelemetryItem(activity);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem);

            using var testServer = new LocalServer(testEndpoint);
            testServer.ServerLogic = async (httpContext) =>
            {
                httpContext.Response.StatusCode = 429;
                httpContext.Response.Headers.Add("Retry-After", "60");
                await httpContext.Response.WriteAsync("Too Many Requests");
            };

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
            // Sleep so that lease period on blob ends.
            // todo: Reduce sleep time
            Thread.Sleep(70000);

            //Assert
            Assert.Single(transmitter.storage.GetBlobs());
            // Delete the blob
            transmitter.storage.GetBlob().Lease(1000).Delete();
        }

        [Fact]
        public void FailureResponseCode206()
        {
            var activity1 = CreateActivity("TestActivity1");
            var activity2 = CreateActivity("TestActivity1");
            var activity3 = CreateActivity("TestActivity1");
            var telemetryItem1 = CreateTelemetryItem(activity1);
            var telemetryItem2 = CreateTelemetryItem(activity1);
            var telemetryItem3 = CreateTelemetryItem(activity1);
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            telemetryItems.Add(telemetryItem1);
            telemetryItems.Add(telemetryItem2);
            telemetryItems.Add(telemetryItem3);

            using var testServer = new LocalServer(testEndpoint);
            testServer.ServerLogic = async (httpContext) =>
            {
                httpContext.Response.StatusCode = 206;
                httpContext.Response.Headers.Add("Retry-After", "60");
                await httpContext.Response.WriteAsync("{\"itemsReceived\": 3,\"itemsAccepted\": 1,\"errors\":[{\"index\": 0,\"statusCode\": 429,\"message\": \"Throttle\"},{\"index\": 1,\"statusCode\": 429,\"message\": \"Throttle\"}]}");
            };

            AzureMonitorExporterOptions options = new AzureMonitorExporterOptions();
            options.ConnectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";
            AzureMonitorTransmitter transmitter = new AzureMonitorTransmitter(options);
            transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

            // Wait for lease period to finish before reading blob.
            // todo: Reduce sleep time
            Thread.Sleep(70000);

            //Assert
            Assert.Single(transmitter.storage.GetBlobs());

            var failedData = System.Text.Encoding.UTF8.GetString(transmitter.storage.GetBlob().Read());

            string[] items = failedData.Split('\n');

            //Assert
            Assert.Equal(2, items.Count());

            // Delete the blob
            transmitter.storage.GetBlob().Lease(1000).Delete();
        }

        private static Resource CreateTestResource(string serviceName = null, string serviceNamespace = null, string serviceInstance = null)
        {
            var testAttributes = new Dictionary<string, object>();

            if (serviceName != null)
                testAttributes.Add("service.name", serviceName);
            if (serviceNamespace != null)
                testAttributes.Add("service.namespace", serviceNamespace);
            if (serviceInstance != null)
                testAttributes.Add("service.instance.id", serviceInstance);

            return ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
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
            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);
            var resource = CreateTestResource();

            return TelemetryPartA.GetTelemetryItem(activity, ref monitorTags, resource, null);
        }
    }
}
