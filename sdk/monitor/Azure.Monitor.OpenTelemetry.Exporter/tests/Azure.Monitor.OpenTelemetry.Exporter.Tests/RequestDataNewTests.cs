// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class RequestDataNewTests
    {
        private const string ActivityName = "RequestDataNewActivity";

        [Fact]
        public void ValidateHttpRequestData()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateHttpRequestData)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateHttpRequestData));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpRoute, "/search");
            activity.SetTag(SemanticConventions.AttributeUrlScheme, "https");
            activity.SetTag(SemanticConventions.AttributeServerAddress, "www.foo.bar");
            activity.SetTag(SemanticConventions.AttributeUrlPath, "/search");
            activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, null);
            activity.SetTag("foo", "bar");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            // Name is set later via operation name on TelemetryItem
            Assert.Null(requestData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), requestData.Id);
            Assert.Equal(httpUrl, requestData.Url);
            Assert.Equal("0", requestData.ResponseCode);
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
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateHttpRequestDataResponseCode)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateHttpRequestDataResponseCode));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            var httpResponseCode = httpStatusCode ?? "0";
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, httpStatusCode);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.Equal(httpResponseCode, requestData.ResponseCode);
        }

        [Theory]
        [InlineData("200", OperationType.Http, true)]
        [InlineData("400", OperationType.Http, false)]
        [InlineData("500", OperationType.Http, false)]
        [InlineData("0", OperationType.Http, false)]
        [InlineData(null, OperationType.Http, true)]
        [InlineData("", OperationType.Http, true)]
        [InlineData("someStatusCode", OperationType.Unknown, false)] // Activity status is set to error in the test code for validation.
        [InlineData("someStatusCode", OperationType.Messaging, true)]
        internal void ValidateHttpRequestSuccess(string httpStatusCode, OperationType operationType, bool isSuccess)
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateHttpRequestSuccess)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateHttpRequestSuccess));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            if (operationType == OperationType.Unknown)
            {
                activity.SetStatus(ActivityStatusCode.Error);
            }

            Assert.Equal(isSuccess, RequestData.IsSuccess(activity, httpStatusCode, operationType));
        }

        [Fact]
        public void RequestDataContainsAzureNamespace()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(RequestDataContainsAzureNamespace)).Build();
            using ActivitySource activitySource = new ActivitySource(nameof(RequestDataContainsAzureNamespace));
            using var activity = activitySource.StartActivity("Activity", ActivityKind.Server);
            activity?.AddTag("az.namespace", "DemoAzureResource");
            activity?.Stop();

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.Equal("DemoAzureResource", activityTagsProcessor.AzureNamespace);
        }

        [Fact]
        public void RequestDataContainsTimeSinceEnqueuedForConsumerSpans()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(RequestDataContainsTimeSinceEnqueuedForConsumerSpans)).Build();
            using ActivitySource activitySource = new ActivitySource(nameof(RequestDataContainsTimeSinceEnqueuedForConsumerSpans));
            List<ActivityLink>? links = new List<ActivityLink>();
            long enqueued0 = DateTimeOffset.UtcNow.AddMilliseconds(-100).ToUnixTimeMilliseconds();
            long enqueued1 = DateTimeOffset.UtcNow.AddMilliseconds(-200).ToUnixTimeMilliseconds();
            long enqueued2 = DateTimeOffset.UtcNow.AddMilliseconds(-300).ToUnixTimeMilliseconds();

            links.Add(AddActivityLink(enqueued0));
            links.Add(AddActivityLink(enqueued1));
            links.Add(AddActivityLink(enqueued2));

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            activity?.Stop();

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
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(RequestDataTimeSinceEnqueuedNegative)).Build();
            using ActivitySource activitySource = new ActivitySource(nameof(RequestDataTimeSinceEnqueuedNegative));
            List<ActivityLink>? links = new List<ActivityLink>();
            long enqueued0 = DateTimeOffset.UtcNow.AddMilliseconds(-100).ToUnixTimeMilliseconds();
            long enqueued1 = DateTimeOffset.UtcNow.AddMilliseconds(-200).ToUnixTimeMilliseconds();
            long enqueued2 = DateTimeOffset.UtcNow.AddMilliseconds(300).ToUnixTimeMilliseconds(); // ignored

            links.Add(AddActivityLink(enqueued0));
            links.Add(AddActivityLink(enqueued1));
            links.Add(AddActivityLink(enqueued2));

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            activity?.Stop();

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
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(RequestDataTimeSinceEnqueuedInvalidEmqueuedTime)).Build();
            using ActivitySource activitySource = new ActivitySource(nameof(RequestDataTimeSinceEnqueuedInvalidEmqueuedTime));
            List<ActivityLink>? links = new List<ActivityLink>();

            ActivityTagsCollection tags = new ActivityTagsCollection();
            tags.Add("enqueuedTime", "Invalid");
            var link = new ActivityLink(new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.None, null), tags);
            links.Add(link);

            using var activity = activitySource.StartActivity("Activity", ActivityKind.Consumer, null, null, links);
            activity?.Stop();

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            DateTimeOffset startTime = activity.StartTimeUtc;
            var startTimeEpoch = startTime.ToUnixTimeMilliseconds();

            Assert.False(requestData.Measurements.TryGetValue("timeSinceEnqueued", out var timeInQueue));
        }

        [Fact]
        public void ValidateMessagingRequestData()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateMessagingRequestData)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateMessagingRequestData));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Consumer,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeMessagingSystem, "servicebus");
            activity.SetTag(SemanticConventions.AttributeServerAddress, "my.servicebus.windows.net");
            activity.SetTag(SemanticConventions.AttributeMessagingDestinationName, "queueName");
            activity.SetTag("foo", "bar");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            // Name is set later via operation name on TelemetryItem
            Assert.Null(requestData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), requestData.Id);
            Assert.Equal("my.servicebus.windows.net/queueName", requestData.Url);
            Assert.Equal("0", requestData.ResponseCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), requestData.Duration);
            Assert.True(requestData.Success);
            Assert.Equal("my.servicebus.windows.net/queueName", requestData.Source);
            Assert.True(requestData.Properties.Count == 1);
            Assert.Equal("bar", requestData.Properties["foo"]);
            Assert.True(requestData.Measurements.Count == 0);
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
