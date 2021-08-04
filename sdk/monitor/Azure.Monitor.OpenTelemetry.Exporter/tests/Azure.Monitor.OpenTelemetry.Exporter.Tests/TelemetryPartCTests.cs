// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
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
        public void LinksAreTruncatedWhenCannotFitInMaxLength()
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

        [Fact]
        public void LinksAreNotTruncatedWhenCanBeFitInMaxLength()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink> links = new List<ActivityLink>();

            int maxLinks = 107; // based on assumption that traceId and SpanId will be of fixed length 32 and 16 respectively.
            int maxLength = 8192;

            for (int i = 0; i < maxLinks; i++)
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

            string expectedMslinks = GetExpectedMSlinks(links);

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
            Assert.Equal(expectedMslinks, actualMSlinks);
        }

        private string GetExpectedMSlinks(IEnumerable<ActivityLink> links)
        {
            if (links != null && links.Any())
            {
                var linksJson = new StringBuilder();
                linksJson.Append('[');
                foreach (var link in links)
                {
                    linksJson
                        .Append('{')
                        .Append("\"operation_Id\":")
                        .Append('\"')
                        .Append(link.Context.TraceId.ToHexString())
                        .Append('\"')
                        .Append(',');
                    linksJson
                        .Append("\"id\":")
                        .Append('\"')
                        .Append(link.Context.SpanId.ToHexString())
                        .Append('\"');
                    linksJson.Append("},");
                }

                if (linksJson.Length > 0)
                {
                    // trim trailing comma - json does not support it
                    linksJson.Remove(linksJson.Length - 1, 1);
                }

                linksJson.Append(']');

                return linksJson.ToString();
            }

            return null;
        }
    }
}
