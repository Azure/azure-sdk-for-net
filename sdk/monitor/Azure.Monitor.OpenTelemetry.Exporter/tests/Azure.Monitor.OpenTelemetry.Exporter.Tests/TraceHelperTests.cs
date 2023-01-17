﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TraceHelperTests
    {
        private const string ActivitySourceName = "AzureMonitorTraceHelperTests";
        private const string ActivityName = "AzureMonitorTraceHelperTestsActivity";
        private const string msLinks = "_MS.links";
        private const int MaxLinksAllowed = 100;
        private const int MaxLength = 8192;

        static TraceHelperTests()
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
        public void PropertiesDoesNotContainMSLinksWhenActivityHasNoLinks(string telemetryType)
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
                var requestData = new RequestData(2, activity, ref monitorTags);
                Assert.False(requestData.Properties.TryGetValue(msLinks, out var mslinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var remoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.False(remoteDependencyData.Properties.TryGetValue(msLinks, out var mslinks));
            }
        }

        [Theory]
        [InlineData("RequestData")]
        [InlineData("RemoteDependencyData")]
        public void PropertiesContainMSLinksWhenActivityHasLinks(string telemetryType)
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
                var requestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(requestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var remoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(remoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
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

            // Arbitrary number > 100
            int numberOfLinks = 150;

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
                var requestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(requestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var remoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(remoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
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
                var requestData = new RequestData(2, activity, ref monitorTags);
                Assert.True(requestData.Properties.TryGetValue(msLinks, out actualMSlinks));
            }
            if (telemetryType == "RemoteDependencyData")
            {
                var remoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);
                Assert.True(remoteDependencyData.Properties.TryGetValue(msLinks, out actualMSlinks));
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

        [Fact]
        public void ActivityWithExceptionEventCreatesExceptionTelemetry()
        {
            var exceptionMessage = "Exception Message";
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
               ActivityName,
               ActivityKind.Server);

            activity.RecordException(new Exception(exceptionMessage));

            Activity[] activityList = new Activity[1];
            activityList[0] = activity;
            Batch<Activity> batch = new Batch<Activity>(activityList, 1);

            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, "roleName", "roleInstance", "00000000-0000-0000-0000-000000000000");

            Assert.Equal(2, telemetryItems.Count());
            Assert.Equal("Exception", telemetryItems[0].Name);
            Assert.Equal("Request", telemetryItems[1].Name);
            Assert.Equal(exceptionMessage, (telemetryItems[0].Data.BaseData as TelemetryExceptionData).Exceptions.First().Message);
            Assert.Equal("System.Exception", (telemetryItems[0].Data.BaseData as TelemetryExceptionData).Exceptions.First().TypeName);
            Assert.Equal("System.Exception: Exception Message", (telemetryItems[0].Data.BaseData as TelemetryExceptionData).Exceptions.First().Stack);
        }

        [Fact]
        public void ActivityWithEventCreatesTraceTelemetry()
        {
            var eventName = "Custom Event";
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
               ActivityName,
               ActivityKind.Server);

            var tagsCollection = new ActivityTagsCollection
            {
                { "key1", "value1" },
            };

            var activityEvent = new ActivityEvent(eventName, default, tagsCollection);

            activity.AddEvent(activityEvent);

            Activity[] activityList = new Activity[1];
            activityList[0] = activity;
            Batch<Activity> batch = new Batch<Activity>(activityList, 1);

            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, "roleName", "roleInstance", "00000000-0000-0000-0000-000000000000");

            Assert.Equal(2, telemetryItems.Count());
            Assert.Equal("Message", telemetryItems[0].Name);
            Assert.Equal("Request", telemetryItems[1].Name);
            Assert.Equal(eventName, (telemetryItems[0].Data.BaseData as MessageData).Message);
            Assert.True((telemetryItems[0].Data.BaseData as MessageData).Properties.TryGetValue("key1", out var value));
            Assert.Equal("value1", value);
            Assert.Null((telemetryItems[0].Data.BaseData as MessageData).SeverityLevel);
        }

        [Fact]
        public void ActivityWithExceptionEventDoesNotCreateExceptionTelemetryWhenExceptionMessageIsNotPresent()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
               ActivityName,
               ActivityKind.Server);

            // Checking with empty string here as OTel
            // adds the exception only if it non-null and non-empty.
            // https://github.com/open-telemetry/opentelemetry-dotnet/blob/872a52f5291804c7af19e90307b5cc097b2da709/src/OpenTelemetry.Api/Trace/ActivityExtensions.cs#L102-L104
            activity.RecordException(new Exception(""));

            Activity[] activityList = new Activity[1];
            activityList[0] = activity;
            Batch<Activity> batch = new Batch<Activity>(activityList, 1);

            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, "roleName", "roleInstance", "00000000 - 0000 - 0000 - 0000 - 000000000000");

            Assert.Single(telemetryItems);
            Assert.Equal("Request", (IEnumerable<char>)telemetryItems[0].Name);
        }

        [Fact]
        public void ActivityWithExceptionEventDoesNotCreateExceptionTelemetryWhenTypeNameIsNotPresent()
        {
            var exceptionMessage = "Exception Message";
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
               ActivityName,
               ActivityKind.Server);

            // Type is not null when using RecordException so creating the event manually
            // similar to https://github.com/open-telemetry/opentelemetry-dotnet/blob/872a52f5291804c7af19e90307b5cc097b2da709/src/OpenTelemetry.Api/Trace/ActivityExtensions.cs#L96-L113
            var tagsCollection = new ActivityTagsCollection
            {
                { SemanticConventions.AttributeExceptionStacktrace, "StackTrace" },
            };

            tagsCollection.Add(SemanticConventions.AttributeExceptionMessage, exceptionMessage);

            activity.AddEvent(new ActivityEvent(SemanticConventions.AttributeExceptionEventName, default, tagsCollection));

            Activity[] activityList = new Activity[1];
            activityList[0] = activity;
            Batch<Activity> batch = new Batch<Activity>(activityList, 1);

            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, "roleName", "roleInstance", "00000000 - 0000 - 0000 - 0000 - 000000000000");

            Assert.Single(telemetryItems);
            Assert.Equal("Request", telemetryItems[0].Name);
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
