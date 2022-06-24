// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StatusTests
    {
        private const string ActivitySourceName = "StatusTests";
        private const string ActivityName = "StatusActivity";

        static StatusTests()
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
        [InlineData("Ok", null)]
        [InlineData("Error", null)]
        [InlineData("Unset", null)]
        [InlineData("Ok", "statusdescription")]
        [InlineData("Error", "statusdescription")]
        [InlineData("Unset", "statusdescription")]
        public void ValidateStatusForAzureMonitorTrace(string activityStatusCode, string activityStatusDescription)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            activity.SetTag("otel.status_code", activityStatusCode);
            activity.SetTag("otel.status_description", activityStatusDescription);

            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/search");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref monitorTags);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref monitorTags);

            Assert.Equal(activity.GetStatus().StatusCode != StatusCode.Error, requestData.Success);
            Assert.Equal(activity.GetStatus().StatusCode != StatusCode.Error, remoteDependencyData.Success);
        }
    }
}
