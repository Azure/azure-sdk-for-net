// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Globalization;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class RemoteDependencyDataNewTests
    {
        private const string ActivityName = "RemoteDependencyDataNewActivity";

        [Fact]
        public void DependencyTypeIsSetToInProcForInternalSpan()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(DependencyTypeIsSetToInProcForInternalSpan)).Build();
            using var activitySource = new ActivitySource(nameof(DependencyTypeIsSetToInProcForInternalSpan));
            using var activity = activitySource.StartActivity("Activity", ActivityKind.Internal);

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyDataType = new RemoteDependencyData(2, activity, ref activityTagsProcessor).Type;

            Assert.Equal("InProc", remoteDependencyDataType);
        }

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Internal)]
        public void RemoteDependencyTypeReflectsAzureNamespace(ActivityKind activityKind)
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(RemoteDependencyTypeReflectsAzureNamespace)).Build();
            using var activitySource = new ActivitySource(nameof(RemoteDependencyTypeReflectsAzureNamespace));
            using var activity = activitySource.StartActivity("Activity", activityKind);
            activity?.AddTag("az.namespace", "DemoAzureResource");

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("DemoAzureResource", activityTagsProcessor.AzureNamespace);
            if (activity.Kind == ActivityKind.Internal)
            {
                Assert.Equal("InProc | DemoAzureResource", remoteDependencyData.Type);
            }
            else if (activity.Kind == ActivityKind.Producer)
            {
                Assert.Equal("Queue Message | DemoAzureResource", remoteDependencyData.Type);
            }
            else
            {
                Assert.Equal("DemoAzureResource", remoteDependencyData.Type);
            }
        }

        [Fact]
        public void ValidateHttpRemoteDependencyData()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateHttpRemoteDependencyData)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateHttpRemoteDependencyData));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            var httpUrl = "https://www.foo.bar/search";
            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeUrlFull, httpUrl);
            activity.SetTag(SemanticConventions.AttributeServerAddress, "www.foo.bar");
            activity.SetTag(SemanticConventions.AttributeHttpResponseStatusCode, "200");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("GET /search", remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal(httpUrl, remoteDependencyData.Data);
            Assert.Equal("www.foo.bar", remoteDependencyData.Target);
            Assert.Equal("200", remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal(activity.Status != ActivityStatusCode.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 0);
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }

        [Fact]
        public void HttpDependencyNameIsActivityDisplayNameByDefault()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(HttpDependencyNameIsActivityDisplayNameByDefault)).Build();
            using var activitySource = new ActivitySource(nameof(HttpDependencyNameIsActivityDisplayNameByDefault));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");

            activity.DisplayName = "HTTP GET";

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyDataName = new RemoteDependencyData(2, activity, ref activityTagsProcessor).Name;

            Assert.Equal(activity.DisplayName, remoteDependencyDataName);
        }

        [Fact]
        public void ValidateMessagingRemoteDependencyData()
        {
            using var tracerProvider = Sdk.CreateTracerProviderBuilder().AddSource(nameof(ValidateMessagingRemoteDependencyData)).Build();
            using var activitySource = new ActivitySource(nameof(ValidateMessagingRemoteDependencyData));
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Producer,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);
            Assert.NotNull(activity);
            activity.Stop();

            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetTag(SemanticConventions.AttributeMessagingSystem, "servicebus");
            activity.SetTag(SemanticConventions.AttributeServerAddress, "my.servicebus.windows.net");
            activity.SetTag(SemanticConventions.AttributeMessagingDestinationName, "queueName");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal("RemoteDependencyDataNewActivity", remoteDependencyData.Name);
            Assert.Equal(activity.Context.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal("my.servicebus.windows.net/queueName", remoteDependencyData.Data);
            Assert.Null(remoteDependencyData.ResultCode);
            Assert.Equal(activity.Duration.ToString("c", CultureInfo.InvariantCulture), remoteDependencyData.Duration);
            Assert.Equal("my.servicebus.windows.net/queueName", remoteDependencyData.Target);
            Assert.Equal(activity.Status != ActivityStatusCode.Error, remoteDependencyData.Success);
            Assert.True(remoteDependencyData.Properties.Count == 0);
            Assert.True(remoteDependencyData.Measurements.Count == 0);
        }
    }
}
