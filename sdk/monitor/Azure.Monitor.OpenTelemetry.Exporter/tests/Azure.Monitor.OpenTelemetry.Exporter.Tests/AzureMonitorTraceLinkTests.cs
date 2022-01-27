// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class AzureMonitorTraceLinkTests
    {
        private const string ActivitySourceName = "AzureMonitorTraceLinkTests";
        private const string ActivityName = "AzureMonitorTraceLinkTestsActivity";
        private const string msLinks = "_MS.links";
        private const int MaxLinksAllowed = 100;
        private const int MaxLength = 8192;

        static AzureMonitorTraceLinkTests()
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

        [Theory]
        [InlineData("RequestData")]
        [InlineData("RemoteDependencyData")]
        public void TelemetryPartBPropertiesDoesNotContainMSLinksWhenActivityHasNoLinks(string telemetryType)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            if (telemetryType == "RequestData")
            {
                var telemetryPartBRequestData = new RequestData(2, activity, ref monitorTags);
                Assert.False(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out var mslinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var telemetryPartBRemoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.False(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out var mslinks));
            }
        }

        [Theory]
        [InlineData("RequestData")]
        [InlineData("RemoteDependencyData")]
        public void TelemetryPartBPropertiesContainsMSLinksWhenActivityHasLinks(string telemetryType)
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

            string expectedMSlinks = GetExpectedMSlinks(links);
            string actualMSlinks = null;

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            if (telemetryType == "RequestData")
            {
                var telemetryPartBRequestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var telemetryPartBRemoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }

            Assert.Equal(expectedMSlinks, actualMSlinks);
        }

        [Theory]
        [InlineData("RequestData")]
        [InlineData("RemoteDependencyData")]
        public void LinksAreTruncatedWhenCannotFitInMaxLength(string telemetryType)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink> links = new List<ActivityLink>();

            int numberOfLinks = 150; //arbitrary number > 100

            for (int i = 0; i < numberOfLinks; i++)
            {
                ActivityLink activityLink = new ActivityLink(new ActivityContext(
                ActivityTraceId.CreateRandom(),
                ActivitySpanId.CreateRandom(),
                ActivityTraceFlags.None), null);
                links.Add(activityLink);
            }

            string expectedMSlinks = GetExpectedMSlinks(links.GetRange(0, MaxLinksAllowed));
            string actualMSlinks = null;

            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                null,
                links,
                startTime: DateTime.UtcNow);

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            if (telemetryType == "RequestData")
            {
                var telemetryPartBRequestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var telemetryPartBRemoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }

            // Check for valid JSON string
            try
            {
                JsonDocument document = JsonDocument.Parse(actualMSlinks);
            }
            catch (Exception)
            {
                Assert.True(false, "_MSlinks should be a JSON formatted string");
            }

            Assert.True(actualMSlinks.Length <= MaxLength);
            Assert.Equal(actualMSlinks, expectedMSlinks);
        }

        [Theory]
        [InlineData("RequestData")]
        [InlineData("RemoteDependencyData")]
        public void LinksAreNotTruncatedWhenCanBeFitInMaxLength(string telemetryType)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink> links = new List<ActivityLink>();

            for (int i = 0; i < MaxLinksAllowed; i++)
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
            string actualMSlinks = null;

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            if (telemetryType == "RequestData")
            {
                var telemetryPartBRequestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRequestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var telemetryPartBRemoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(telemetryPartBRemoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }

            // Check for valid JSON string
            try
            {
                JsonDocument document = JsonDocument.Parse(actualMSlinks);
            }
            catch (Exception)
            {
                Assert.True(false, "_MSlinks should be a JSON formatted string");
            }

            Assert.True(actualMSlinks.Length <= MaxLength);
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
