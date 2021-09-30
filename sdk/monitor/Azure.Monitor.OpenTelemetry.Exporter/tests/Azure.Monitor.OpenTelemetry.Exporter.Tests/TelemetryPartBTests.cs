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
            activity.SetTag(SemanticConventions.AttributeHttpRoute, "/search");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in HttpHelperTests.
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, null);

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var requestData = TelemetryPartB.GetRequestData(activity, ref monitorTags);

            Assert.Equal("GET /search", requestData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), requestData.Id);
            Assert.Equal(httpUrl, requestData.Url);
            Assert.Equal("0", requestData.ResponseCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), requestData.Duration);
            Assert.Equal(activity.GetStatus() != Status.Error, requestData.Success);
            Assert.Null(requestData.Source);
            Assert.True(requestData.Properties.Count == 0);
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

        [Fact]
        public void ValidateHttpRemoteDependencyData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(Status.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in HttpHelperTests.
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, null);

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var remoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity, ref monitorTags);

            Assert.Equal("GET /search", remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal(httpUrl, remoteDependencyData.Data);
            Assert.Equal("0", remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.GetStatus() != Status.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 0);
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void ValidateDbRemoteDependencyData()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            activity.Stop();

            activity.SetStatus(Status.Ok);
            activity.SetTag(SemanticConventions.AttributeDbSystem, "mssql");
            activity.SetTag(SemanticConventions.AttributePeerService, "localhost"); // only adding test via peer.service. all possible combinations are covered in HttpHelperTests.
            activity.SetTag(SemanticConventions.AttributeDbStatement, "Select * from table");

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var remoteDependencyData = TelemetryPartB.GetRemoteDependencyData(activity, ref monitorTags);

            Assert.Equal(ActivityName, remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal("Select * from table", remoteDependencyData.Data);
            Assert.Null(remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.GetStatus() != Status.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 0);
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void HttpDependencyNameIsActivityDisplayNameByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");

            activity.DisplayName = "HTTP GET";

            var monitorTags = AzureMonitorConverter.EnumerateActivityTags(activity);

            var remoteDependencyDataName = TelemetryPartB.GetRemoteDependencyData(activity, ref monitorTags).Name;

            Assert.Equal(activity.DisplayName, remoteDependencyDataName);
        }
    }
}
