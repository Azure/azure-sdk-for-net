// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class RequestDataTests
    {
        private const string ActivitySourceName = "RequestDataTests";
        private const string ActivityName = "RequestDataActivity";

        static RequestDataTests()
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
            Assert.NotNull(activity);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpRoute, "/search");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, httpUrl); // only adding test via http.url. all possible combinations are covered in AzMonListExtensionsTests.
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, "200");
            activity.SetTag("foo", "bar");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            // Name is set later via operation name on TelemetryItem
            Assert.Null(requestData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), requestData.Id);
            Assert.Equal(httpUrl, requestData.Url);
            Assert.Equal("200", requestData.ResponseCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), requestData.Duration);
            Assert.True(requestData.Success);
            Assert.Null(requestData.Source);
            Assert.True(requestData.Properties.Count == 1);
            Assert.Equal("bar", requestData.Properties["foo"]);
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
            Assert.NotNull(activity);

            var httpResponseCode = httpStatusCode ?? "0";
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, httpStatusCode);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.Equal(httpResponseCode, requestData.ResponseCode);
        }

        [Theory]
        [InlineData("200", ActivityStatusCode.Unset, true)]
        [InlineData("200", ActivityStatusCode.Ok, true)]
        [InlineData("200", ActivityStatusCode.Error, false)]
        [InlineData("400", ActivityStatusCode.Unset, false)]
        [InlineData("400", ActivityStatusCode.Ok, true)]
        [InlineData("400", ActivityStatusCode.Error, false)]
        [InlineData("500", ActivityStatusCode.Unset, false)]
        [InlineData("500", ActivityStatusCode.Ok, true)]
        [InlineData("500", ActivityStatusCode.Error, false)]
        [InlineData("0", ActivityStatusCode.Unset, false)]
        [InlineData("0", ActivityStatusCode.Ok, true)]
        [InlineData("0", ActivityStatusCode.Error, false)]
        public void ValidateHttpRequestSuccess(string httpStatusCode, ActivityStatusCode activityStatus, bool isSuccess)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);

            var httpResponseCode = httpStatusCode ?? "0";
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/search");
            activity.SetTag(SemanticConventions.AttributeHttpStatusCode, httpStatusCode);
            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetStatus(activityStatus);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.Equal(httpResponseCode, requestData.ResponseCode);
            Assert.Equal(isSuccess, requestData.Success);
        }

        [Fact]
        public void RequestDataContainsAzureNamespace()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity("Activity", ActivityKind.Server);
            activity?.AddTag("az.namespace", "DemoAzureResource");

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.Equal("DemoAzureResource", activityTagsProcessor.AzureNamespace);
        }

        [Fact]
        public void RequestDataContainsTimeSinceEnqueuedForConsumerSpans()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink>? links = new List<ActivityLink>();
            long enqueued0 = DateTimeOffset.UtcNow.AddMilliseconds(-100).ToUnixTimeMilliseconds();
            long enqueued1 = DateTimeOffset.UtcNow.AddMilliseconds(-200).ToUnixTimeMilliseconds();
            long enqueued2 = DateTimeOffset.UtcNow.AddMilliseconds(-300).ToUnixTimeMilliseconds();

            links.Add(AddActivityLink(enqueued0));
            links.Add(AddActivityLink(enqueued1));
            links.Add(AddActivityLink(enqueued2));

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            DateTimeOffset startTime = activity.StartTimeUtc;
            var startTimeEpoch = startTime.ToUnixTimeMilliseconds();

            long expectedTimeInQueue = ((startTimeEpoch - enqueued0) +
                                      (startTimeEpoch - enqueued1) +
                                      (startTimeEpoch - enqueued2)) / 3; // avg diff with request start time across links

            Assert.True(requestData.Measurements.TryGetValue("timeSinceEnqueued", out var timeInQueue));

            Assert.Equal(expectedTimeInQueue, timeInQueue);
        }

        [Fact]
        public void RequestDataTimeSinceEnqueuedNegative()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink>? links = new List<ActivityLink>();
            long enqueued0 = DateTimeOffset.UtcNow.AddMilliseconds(-100).ToUnixTimeMilliseconds();
            long enqueued1 = DateTimeOffset.UtcNow.AddMilliseconds(-200).ToUnixTimeMilliseconds();
            long enqueued2 = DateTimeOffset.UtcNow.AddMilliseconds(300).ToUnixTimeMilliseconds(); // ignored

            links.Add(AddActivityLink(enqueued0));
            links.Add(AddActivityLink(enqueued1));
            links.Add(AddActivityLink(enqueued2));

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            DateTimeOffset startTime = activity.StartTimeUtc;
            var startTimeEpoch = startTime.ToUnixTimeMilliseconds();

            long expectedTimeInQueue = ((startTimeEpoch - enqueued0) +
                                      (startTimeEpoch - enqueued1)) / 3; // avg diff with request start time across links

            Assert.True(requestData.Measurements.TryGetValue("timeSinceEnqueued", out var timeInQueue));

            Assert.Equal(expectedTimeInQueue, timeInQueue);
        }

        [Fact]
        public void RequestDataTimeSinceEnqueuedInvalidEmqueuedTime()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            List<ActivityLink>? links = new List<ActivityLink>();

            ActivityTagsCollection tags = new ActivityTagsCollection();
            tags.Add("enqueuedTime", "Invalid");
            var link = new ActivityLink(new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None, null), tags);
            links.Add(link);

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            DateTimeOffset startTime = activity.StartTimeUtc;
            var startTimeEpoch = startTime.ToUnixTimeMilliseconds();

            Assert.False(requestData.Measurements.TryGetValue("timeSinceEnqueued", out var timeInQueue));
        }

        private ActivityLink AddActivityLink(long enqueuedTime)
        {
            ActivityTagsCollection tags = new ActivityTagsCollection
            {
                { "enqueuedTime", enqueuedTime.ToString() }
            };
            var link = new ActivityLink(new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None, null), tags);

            return link;
        }
    }
}
