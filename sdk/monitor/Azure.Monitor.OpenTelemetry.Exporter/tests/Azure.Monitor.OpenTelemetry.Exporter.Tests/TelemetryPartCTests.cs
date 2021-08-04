// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class TelemetryPartCTests
    {
        private const string ActivitySourceName = "TelemetryPartCTests";
        private const string ActivityName = "TestActivity";
        private const string msLinks = "_MS.links";

        static TelemetryPartCTests()
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
        public void RequestDataPropertiesDoesNotContainMSLinksWhenActivityHasNoLinks()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            var telemetryPartBRequestData = TelemetryPartB.GetRequestData(activity);
            Assert.False(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out var mslinks));
        }

        [Fact]
        public void RequestDataPropertiesContainsMSLinksWhenActivityHasLinks()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            ActivityLink activityLink = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);

            List<ActivityLink> links = new List<ActivityLink>();
            links.Add(activityLink);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            string expectedMSlinks = $"[{{\"operation_Id\":\"{activityLink.Context.TraceId}\",\"id\":\"{activityLink.Context.SpanId}\"}}]";
            var telemetryPartBRequestData = TelemetryPartB.GetRequestData(activity);

            Assert.True(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out var actualMSlinks));
            Assert.Equal(expectedMSlinks, actualMSlinks);
        }

        [Fact]
        public void RemoteDependencyDataPropertiesDoesNotContainMSLinksWhenActivityHasNoLinks()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            var telemetryPartBRemoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity);
            Assert.False(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out var mslinks));
        }

        [Fact]
        public void RemoteDependencyDataPropertiesContainsMSLinksWhenActivityHasLinks()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            ActivityLink activityLink = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);

            List<ActivityLink> links = new List<ActivityLink>();
            links.Add(activityLink);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            string expectedMSlinks = $"[{{\"operation_Id\":\"{activityLink.Context.TraceId}\",\"id\":\"{activityLink.Context.SpanId}\"}}]";
            var telemetryPartBRemoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity);

            Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out var actualMSlinks));
            Assert.Equal(expectedMSlinks, actualMSlinks);
        }

        [Fact]
        public void LinksareTruncatedWhenCannotFitInMaxLength()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink> links = new List<ActivityLink>();

            int maxLength = 8192;

            for (int i = 0; i < maxLength; i++)
            {
                ActivityLink activityLink = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);
                links.Add(activityLink);
            }

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            // Only checking dependency here. The flow will be same for other telemetry types.
            var telemetryPartBRemoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity);

            Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out var actualMSlinks));
            try
            {
                JsonDocument document = JsonDocument.Parse(actualMSlinks);
                Assert.Equal(1, 1);
            }
            catch (Exception)
            {
                Assert.Equal(0, 1);
            }
            Assert.True(actualMSlinks.Length <= maxLength);
        }
    }
}
