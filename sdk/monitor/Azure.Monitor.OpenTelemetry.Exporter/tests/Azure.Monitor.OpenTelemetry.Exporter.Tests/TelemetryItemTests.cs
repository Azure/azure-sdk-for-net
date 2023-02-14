// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Xunit;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

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

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.UpdateRoleNameAndInstance();
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, traceResource, "00000000-0000-0000-0000-000000000000");

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

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);

            var traceResource = resource.UpdateRoleNameAndInstance();
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, traceResource, "00000000-0000-0000-0000-000000000000");

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
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");
            var resource = CreateTestResource();

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.UpdateRoleNameAndInstance();
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, traceResource, "00000000-0000-0000-0000-000000000000");

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
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

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

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal(expectedOperationName, telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void HttpMethodAndHttpUrlPathIsUsedForHttpRequestOperationName()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            activity.DisplayName = "displayname";

            activity.SetTag(SemanticConventions.AttributeHttpMethod, "GET");
            activity.SetTag(SemanticConventions.AttributeHttpUrl, "https://www.foo.bar/path?id=1");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal("GET /path", telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void ActivityNameIsUsedByDefaultForRequestOperationName()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            activity.DisplayName = "displayname";

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal("displayname", telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()]);
        }

        [Fact]
        public void AiLocationIpisSetAsHttpClientIpforHttpServerSpans()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            activity.SetTag(SemanticConventions.AttributeHttpClientIP, "127.0.0.1");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal("127.0.0.1", telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()]);
        }

        [Fact]
        public void AiLocationIpisSetAsNetPeerIpForServerSpans()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            activity.SetTag(SemanticConventions.AttributeNetPeerIp, "127.0.0.1");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal("127.0.0.1", telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()]);
        }

        [Fact]
        public void AiUserAgentisSetAsHttpUserAgent()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            var userAgent = "Mozilla / 5.0(Windows NT 10.0;WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 91.0.4472.101 Safari / 537.36";
            activity.SetTag(SemanticConventions.AttributeHttpUserAgent, userAgent);

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Equal(userAgent, telemetryItem.Tags["ai.user.userAgent"]);
        }

        [Fact]
        public void AiLocationIpIsNullByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

            Assert.Null(telemetryItem.Tags[ContextTagKeys.AiLocationIp.ToString()]);
        }

        [Fact]
        public void AiUserAgentIsNotTransmittedByDefault()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);

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
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");
            var resource = CreateTestResource();

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.UpdateRoleNameAndInstance();
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, traceResource, "00000000-0000-0000-0000-000000000000");

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
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");
            var resource = CreateTestResource(null, null, "serviceinstance");

            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var traceResource = resource.UpdateRoleNameAndInstance();
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, traceResource, "00000000-0000-0000-0000-000000000000");

            Assert.Equal("serviceinstance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }

        [Theory]
        [InlineData("GET")]
        [InlineData(null)]
        public void RequestNameMatchesOperationName(string? httpMethod)
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Server,
                null,
                startTime: DateTime.UtcNow)
                ?? throw new Exception("Failed to create Activity");

            activity.DisplayName = "displayname";
            if (httpMethod != null)
            {
                activity.SetTag(SemanticConventions.AttributeHttpMethod, httpMethod);
            }
            var monitorTags = TraceHelper.EnumerateActivityTags(activity);
            var telemetryItem = new TelemetryItem(activity, ref monitorTags, null, string.Empty);
            var requestData = new RequestData(2, activity, ref monitorTags);

            Assert.Equal(requestData.Name, telemetryItem.Tags[ContextTagKeys.AiOperationName.ToString()]);
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

            if (serviceName != null) testAttributes.Add("service.name", serviceName);
            if (serviceNamespace != null) testAttributes.Add("service.namespace", serviceNamespace);
            if (serviceInstance != null) testAttributes.Add("service.instance.id", serviceInstance);

            return ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
        }
    }
}
