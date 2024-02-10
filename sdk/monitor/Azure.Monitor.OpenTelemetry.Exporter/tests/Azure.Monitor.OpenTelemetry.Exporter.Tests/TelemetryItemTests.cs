// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TelemetryItemTests
    {
        private const string ActivitySourceName = "TelemetryItemTests";
        private const string ActivityName = "TestActivity";

        static TelemetryItemTests()
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
        public void ValidateTelemetryItem_DefaultActivity_DefaultResource()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            var resource = CreateTestResource();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.CreateAzureMonitorResource();
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, traceResource, "00000000-0000-0000-0000-000000000000", 1.0f);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(TelemetryItem.FormatUtcTimestamp(activity.StartTimeUtc), telemetryItem.Time);
            Assert.StartsWith("unknown_service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal(Dns.GetHostName(), telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Fact]
        public void ValidateTelemetryItem_Activity_WithResource()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);

            var traceResource = resource.CreateAzureMonitorResource();
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, traceResource, "00000000-0000-0000-0000-000000000000", 1.0f);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(TelemetryItem.FormatUtcTimestamp(activity.StartTimeUtc), telemetryItem.Time);
            Assert.Equal("my-service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("my-instance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.Equal(activity.TraceId.ToHexString(), telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.Equal(SdkVersionUtils.s_sdkVersion, telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Fact]
        public void ValidateTelemetryItem_Activity_WithParentSpanId()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var resource = CreateTestResource();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.CreateAzureMonitorResource();
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, traceResource, "00000000-0000-0000-0000-000000000000", 1.0f);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(TelemetryItem.FormatUtcTimestamp(activity.StartTimeUtc), telemetryItem.Time);
            Assert.StartsWith("unknown_service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal(Dns.GetHostName(), telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Equal(activity.ParentSpanId.ToHexString(), telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Theory]
        [InlineData("/route")]
        [InlineData("{controller}/{action}/{id}")]
        [InlineData(null)]
        public void HttpMethodAndHttpRouteIsUsedForHttpRequestOperationName(string? route)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "/getaction";

            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpRoute, route);
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/search");

            string expectedOperationName;
            if (route == "{controller}/{action}/{id}" || route == null)
            {
                expectedOperationName = "GET /search";
            }
            else
            {
                expectedOperationName = $"GET {route}";
            }

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.Equal(expectedOperationName, telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void HttpMethodAndHttpUrlPathIsUsedForHttpRequestOperationName()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "displayname";

            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/path?id=1");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.Equal("GET /path", telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void ActivityNameIsUsedByDefaultForRequestOperationName()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "displayname";
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.Equal("displayname", telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void AiLocationIpIsSetAsHttpClientIpForHttpServerSpans()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.SetTag(SemanticConventions.AttributeClientAddress, "127.0.0.1");
            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.Equal("127.0.0.1", telemetryItem?.Tags[ContextTagKeys.AiLocationIp.ToString()]);
        }

        [Fact]
        public void AiUserAgentIsSetAsHttpUserAgent()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var userAgent = "Mozilla / 5.0(Windows NT 10.0;WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 91.0.4472.101 Safari / 537.36";
            activity.SetTag(SemanticConventions.AttributeHttpUserAgent, userAgent);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.Equal(userAgent, telemetryItem?.Tags["ai.user.userAgent"]);
        }

        [Fact]
        public void AiUserAgentIsSetAsUserAgentOriginal()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var userAgent = "Mozilla / 5.0(Windows NT 10.0;WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 91.0.4472.101 Safari / 537.36";
            activity.SetTag(SemanticConventions.AttributeUserAgentOriginal, userAgent);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, string.Empty, 1.0f);

            Assert.Equal(userAgent, telemetryItem.Tags["ai.user.userAgent"]);
        }

        [Fact]
        public void AiLocationIpIsNotSetByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);
            activity?.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();

            Assert.False(telemetryItem?.Tags.TryGetValue(ContextTagKeys.AiLocationIp.ToString(), out _));
        }

        [Fact]
        public void AiUserAgentIsNotTransmittedByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, null, string.Empty, 1.0f);

            Assert.False(telemetryItem.Tags.TryGetValue("ai.user.userAgent", out var userAgent));
        }

        [Fact]
        public void RoleInstanceIsSetToHostNameByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var resource = CreateTestResource();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.CreateAzureMonitorResource();
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, traceResource, "00000000-0000-0000-0000-000000000000", 1.0f);

            Assert.Equal(Dns.GetHostName(), telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }

        [Fact]
        public void RoleInstanceIsNotOverwrittenIfSetViaServiceInstanceId()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            var resource = CreateTestResource(null, null, "serviceinstance");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.CreateAzureMonitorResource();
            var telemetryItem = new TelemetryItem(activity, ref activityTagsProcessor, traceResource, "00000000-0000-0000-0000-000000000000", 1.0f);

            Assert.Equal("serviceinstance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }

        [Fact]
        public void RequestNameMatchesOperationName()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "displayname";

            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpRoute, "/api/test");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();
            var requestData = telemetryItem?.Data.BaseData as RequestData;

            Assert.NotNull(requestData);
            Assert.Equal("GET /api/test", requestData.Name);
            Assert.Equal(requestData.Name, telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void RequestNameMatchesOperationNameV2()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "displayname";

            activity.SetTag(SemanticConventions.AttributeHttpRequestMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpRoute, "/api/test");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();
            var requestData = telemetryItem?.Data.BaseData as RequestData;

            Assert.NotNull(requestData);
            Assert.Equal("GET /api/test", requestData.Name);
            Assert.Equal(requestData.Name, telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void RequestNameMatchesOperationNameForConsumerSpans()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Consumer,
                null,
                startTime: DateTime.UtcNow);

            Assert.NotNull(activity);
            activity.DisplayName = "displayname";

            activity.SetTag(SemanticConventions.AttributeMessagingSystem, "Eventhub");

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var telemetryItem = telemetryItems.FirstOrDefault();
            var requestData = telemetryItem?.Data.BaseData as RequestData;

            Assert.NotNull(requestData);
            Assert.Equal("displayname", requestData.Name);
            Assert.Equal(requestData.Name, telemetryItem?.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void OTelResourceMetricTelemetryHasAllResourceAttributes()
        {
            try
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, "true");
                var instrumentationKey = "00000000-0000-0000-0000-000000000000";

                var testAttributes = new Dictionary<string, object>
                {
                    {SemanticConventions.AttributeServiceName, "my-service" },
                    {SemanticConventions.AttributeServiceNamespace, "my-namespace" },
                    {SemanticConventions.AttributeServiceInstance, "my-instance" },
                    {SemanticConventions.AttributeK8sDeployment, "my-deployment" },
                    {SemanticConventions.AttributeK8sPod, "my-pod" },
                    { "foo", "bar" }
                };

                using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
                using var activity = activitySource.StartActivity(
                    ActivityName,
                    ActivityKind.Server,
                    null,
                    startTime: DateTime.UtcNow);

                Assert.NotNull(activity);

                var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
                var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, instrumentationKey, 1.0f);
                var telemetryItem = telemetryItems.FirstOrDefault();

                var monitorBase = telemetryItem?.Data;
                var metricsData = monitorBase?.BaseData as MetricsData;

                Assert.NotNull(metricsData?.Metrics);

                var metricDataPoint = metricsData?.Metrics[0];
                Assert.Equal("_OTELRESOURCE_", metricDataPoint?.Name);
                Assert.Equal(0, metricDataPoint?.Value);

                Assert.Equal(6, metricsData?.Properties.Count);

                Assert.Equal("my-service", metricsData?.Properties[SemanticConventions.AttributeServiceName]);
                Assert.Equal("my-namespace", metricsData?.Properties[SemanticConventions.AttributeServiceNamespace]);
                Assert.Equal("my-instance", metricsData?.Properties[SemanticConventions.AttributeServiceInstance]);
                Assert.Equal("my-deployment", metricsData?.Properties[SemanticConventions.AttributeK8sDeployment]);
                Assert.Equal("my-pod", metricsData?.Properties[SemanticConventions.AttributeK8sPod]);
                Assert.Equal("bar", metricsData?.Properties["foo"]);
            }
            catch (Exception)
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, null);
            }
        }

        [Fact]
        public void OTelResourceMetricTimesAreDifferent()
        {
            try
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, "true");
                var instrumentationKey = "00000000-0000-0000-0000-000000000000";

                var testAttributes = new Dictionary<string, object>
                {
                    { "foo", "bar" }
                };

                using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
                using var activity1 = activitySource.StartActivity(
                    ActivityName,
                    ActivityKind.Server,
                    null,
                    startTime: DateTime.UtcNow);

                Assert.NotNull(activity1);

                var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
                var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity1 }, 1), null, instrumentationKey, 1.0f);
                var telemetryItem1 = telemetryItems.FirstOrDefault();

                var monitorBase = telemetryItem1?.Data;
                var metricsData = monitorBase?.BaseData as MetricsData;

                Assert.NotNull(metricsData?.Metrics);

                var metricDataPoint = metricsData?.Metrics[0];
                Assert.Equal("_OTELRESOURCE_", metricDataPoint?.Name);
                Assert.Equal(1, metricsData?.Properties.Count);
                Assert.Equal("bar", metricsData?.Properties["foo"]);

                using var activity2 = activitySource.StartActivity(
                    ActivityName,
                    ActivityKind.Server,
                    null,
                    startTime: DateTime.UtcNow);

                Assert.NotNull(activity2);

                telemetryItems = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity2 }, 1), null, instrumentationKey, 1.0f);
                var telemetryItem2 = telemetryItems.FirstOrDefault();

                Assert.NotEqual(telemetryItem1?.Time, telemetryItem2?.Time);
            }
            catch (Exception)
            {
                Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, null);
            }
        }

        /// <summary>
        /// If SERVICE.NAME is not defined, it will fall-back to "unknown_service".
        /// (https://github.com/open-telemetry/opentelemetry-specification/tree/main/specification/resource/semantic_conventions#semantic-attributes-with-sdk-provided-default-value).
        /// </summary>
        /// <remarks>
        /// An alternative way to get an instance of a Resource is as follows:
        /// <code>
        /// var resourceAttributes = new Dictionary<string, object> { { "service.name", "my-service" }, { "service.namespace", "my-namespace" }, { "service.instance.id", "my-instance" } };
        /// var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);
        /// var tracerProvider = Sdk.CreateTracerProviderBuilder().SetResourceBuilder(resourceBuilder).Build();
        /// var resource = tracerProvider.GetResource();
        /// </code>
        /// </remarks>
        private static Resource CreateTestResource(string? serviceName = null, string? serviceNamespace = null, string? serviceInstance = null)
        {
            var testAttributes = new Dictionary<string, object>();

            if (serviceName != null)
                testAttributes.Add("service.name", serviceName);
            if (serviceNamespace != null)
                testAttributes.Add("service.namespace", serviceNamespace);
            if (serviceInstance != null)
                testAttributes.Add("service.instance.id", serviceInstance);

            return ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
        }
    }
}
