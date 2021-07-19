// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class TelemetryPartBTests
    {
        private const string ActivitySourceName = "TelemetryPartBTests";
        private const string ActivityName = "TestActivity";
        private const string msLinks = "_MS.links";

        static TelemetryPartBTests()
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
            ActivityLink activityLink1 = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);
            ActivityLink activityLink2 = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);

            List<ActivityLink> links = new List<ActivityLink>();
            links.Add(activityLink1);
            links.Add(activityLink2);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            string expectedMSlinks = $"[{{\"operation_Id\":\"{activityLink1.Context.TraceId}\",\"id\":\"{activityLink1.Context.SpanId}\"}},{{\"operation_Id\":\"{activityLink2.Context.TraceId}\",\"id\":\"{activityLink2.Context.SpanId}\"}}]";
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
            ActivityLink activityLink1 = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);
            ActivityLink activityLink2 = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);

            List<ActivityLink> links = new List<ActivityLink>();
            links.Add(activityLink1);
            links.Add(activityLink2);

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            string expectedMSlinks = $"[{{\"operation_Id\":\"{activityLink1.Context.TraceId}\",\"id\":\"{activityLink1.Context.SpanId}\"}},{{\"operation_Id\":\"{activityLink2.Context.TraceId}\",\"id\":\"{activityLink2.Context.SpanId}\"}}]";
            var telemetryPartBRemoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity);

            Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out var actualMSlinks));
            Assert.Equal(expectedMSlinks, actualMSlinks);
        }
    }
}