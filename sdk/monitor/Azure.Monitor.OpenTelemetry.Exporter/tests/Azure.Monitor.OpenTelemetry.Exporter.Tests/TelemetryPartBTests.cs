// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            var httpResponsCode = "0";
            activity.SetStatus(Status.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in HttpHelperTests.
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, null);
            var requestData = TelemetryPartB.GetRequestData(activity);
            Assert.Equal(requestData.Name, activity.DisplayName);
            Assert.Equal(requestData.Id, activity.Context.SpanId.ToHexString());
            Assert.Equal(requestData.Url, httpUrl);
            Assert.Equal(requestData.ResponseCode, httpResponsCode);
            Assert.Equal(requestData.Duration, activity.Duration.ToString("c", CultureInfo.InvariantCulture));
            Assert.Equal(requestData.Success, activity.GetStatus() != Status.Error);
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
            activity.Stop();
            var httpUrl = "https://www.foo.bar/search";
            var httpResponsCode = httpStatusCode ?? "0";
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl);
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, httpStatusCode);
            var requestData = TelemetryPartB.GetRequestData(activity);
            Assert.Equal(requestData.ResponseCode, httpResponsCode);
        }

        [Theory]
        [InlineData("Ok")]
        [InlineData("Error")]
        [InlineData("Unset")]
        public void ValidateRequestDataSuccess(string activityStatus)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            if (activityStatus == "Ok")
            {
                activity.SetStatus(Status.Ok);
            }
            else if (activityStatus == "Error")
            {
                activity.SetStatus(Status.Error);
            }
            else
            {
                activity.SetStatus(Status.Unset);
            }
            var httpUrl = "https://www.foo.bar/search";
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl);
            var requestData = TelemetryPartB.GetRequestData(activity);
            Assert.Equal(requestData.Success, activity.GetStatus() != Status.Error);
        }
    }
}
