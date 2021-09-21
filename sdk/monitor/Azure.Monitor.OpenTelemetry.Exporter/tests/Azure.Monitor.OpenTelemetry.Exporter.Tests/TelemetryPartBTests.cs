// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class TelemetryPartBTests
    {
        private const string ActivitySourceName = "TelemetryPartBTests";
        private const string ActivityName = "TestActivity";

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
        public void ValidateHttpRequestData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(Status.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in HttpHelperTests.
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, null);

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var requestData = TelemetryPartB.GetRequestData(activity, ref monitorTags);

            Assert.Equal($"GET {activity.DisplayName}", requestData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), requestData.Id);
            Assert.Equal(httpUrl, requestData.Url);
            Assert.Equal("0", requestData.ResponseCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), requestData.Duration);
            Assert.Equal(activity.GetStatus() != Status.Error, requestData.Success);
            Assert.Null(requestData.Source);
            Assert.True(requestData.Properties.Count == 1); //Because of otel_statuscode attribute for activity status. todo: do not add all tags to PartC
            Assert.True(requestData.Measurements.Count == 0);
        }

        [Theory]
        [InlineData("200")]
        [InlineData(null)]
        public void ValidateHttpRequestDataResponseCode(string httpStatusCode)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            var httpResponseCode = httpStatusCode ?? "0";
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/search");
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, httpStatusCode);

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var requestData = TelemetryPartB.GetRequestData(activity, ref monitorTags);

            Assert.Equal(httpResponseCode, requestData.ResponseCode);
        }

        [Theory]
        [InlineData("Ok", null)]
        [InlineData("Error", null)]
        [InlineData("Unset", null)]
        [InlineData("Ok", "statusdescription")]
        [InlineData("Error", "statusdescription")]
        [InlineData("Unset", "statusdescription")]
        public void ValidateSuccessForRequestAndRemoteDependency(string activityStatusCode, string activityStatusDescription)
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

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var requestData = TelemetryPartB.GetRequestData(activity, ref monitorTags);
            var remoteDependencyData = TelemetryPartB.GetRequestData(activity, ref monitorTags);

            Assert.Equal(activity.GetStatus().StatusCode != StatusCode.Error, requestData.Success);
            Assert.Equal(activity.GetStatus().StatusCode != StatusCode.Error, remoteDependencyData.Success);
        }

        [Theory]
        [InlineData("mssql")]
        [InlineData("redis")]
        public void ValidateDBDependencyType(string dbSystem)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            activity.SetTag(SemanticConventions.AttributeDbSystem, dbSystem);

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var remoteDependencyDataType = TelemetryPartB.GetRemoteDependencyData(activity, ref monitorTags).Type;
            var expectedType = TelemetryPartB.SqlDbs.Contains(dbSystem) ? "SQL" : dbSystem;

            Assert.Equal(expectedType, remoteDependencyDataType);
        }

        [Fact]
        public void DependencyTypeisSetToInProcForInternalSpanWithParent()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var parentActivity = activitySource.StartActivity("ParentActivity", ActivityKind.Internal);
            using var childActivity = activitySource.StartActivity("ChildActivity", ActivityKind.Internal);

            var monitorTagsParent = AzureMonitorConverter.EnumerateActivityTags(parentActivity);

            var remoteDependencyDataTypeForParent = TelemetryPartB.GetRemoteDependencyData(parentActivity, ref monitorTagsParent).Type;

            Assert.Null(remoteDependencyDataTypeForParent);

            var monitorTagsChild = AzureMonitorConverter.EnumerateActivityTags(childActivity);

            var remoteDependencyDataTypeForChild = TelemetryPartB.GetRemoteDependencyData(childActivity, ref monitorTagsChild).Type;

            Assert.Equal("InProc", remoteDependencyDataTypeForChild);
        }
    }
}
