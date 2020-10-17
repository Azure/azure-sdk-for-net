// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Xunit;

using Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
{
    public class AzureMonitorConverterTests
    {
        private const string ResourcePropertyName = "OTel.Resource";

        static AzureMonitorConverterTests()
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
        public void ExtractRoleInfo_NullResource()
        {
            AzureMonitorConverter.ExtractRoleInfo(null, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_Empty()
        {
            var resource = Resources.CreateServiceResource(null);
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceName()
        {
            var resource = Resources.CreateServiceResource("my-service");
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.True(Guid.TryParse(roleInstance, out var guid));
        }

        [Fact]
        public void ExtractRoleInfo_ServiceInstance()
        {
            var resource = Resources.CreateServiceResource(null, "roleInstance_1");
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNamespace()
        {
            var resource = Resources.CreateServiceResource(null, null, "my-namespace");
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNameAndInstance()
        {
            var resource = Resources.CreateServiceResource("my-service", "roleInstance_1");
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            var resource = Resources.CreateServiceResource("my-service", "roleInstance_1", "my-namespace");
            AzureMonitorConverter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-namespace.my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }

        [Fact]
        public void GetMessagingUrl_Success()
        {
            Assert.Equal("test", AzureMonitorConverter.GetMessagingUrl(new Dictionary<string, string> { [SemanticConventions.AttributeMessagingUrl] = "test" }));
            Assert.Null(AzureMonitorConverter.GetMessagingUrl(new Dictionary<string, string> { [SemanticConventions.AttributeMessagingUrl] = null }));
        }

        [Fact]
        public void GetMessagingUrl_Failure()
        {
            Assert.Null(AzureMonitorConverter.GetMessagingUrl(null));
            Assert.Null(AzureMonitorConverter.GetMessagingUrl(new Dictionary<string, string>()));
        }

        [Fact]
        public void GeneratePartAEnvelope_DefaultActivity()
        {
            var activity = CreateTestActivity();
            var telemetryItem = AzureMonitorConverter.GeneratePartAEnvelope(activity);
            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture), telemetryItem.Time);
            Assert.Null(telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Null(telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Fact]
        public void GeneratePartAEnvelope_ActivityWithRoleInformation()
        {
            var activity = CreateTestActivity(
                resource: Resources.CreateServiceResource("BusyWorker", "TEST3650724"));

            var telemetryItem = AzureMonitorConverter.GeneratePartAEnvelope(activity);
            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture), telemetryItem.Time);
            Assert.Equal("BusyWorker", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("TEST3650724", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.Equal(activity.TraceId.ToHexString(), telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.Equal(SdkVersionUtils.SdkVersion, telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        // TODO: GeneratePartAEnvelope_WithActivityParent

        private static Activity CreateTestActivity(
            bool setAttributes = true,
            Dictionary<string, object> additionalAttributes = null,
            bool addEvents = true,
            bool addLinks = true,
            Resource resource = null,
            ActivityKind kind = ActivityKind.Client)
        {
            var startTimestamp = DateTime.UtcNow;
            var endTimestamp = startTimestamp.AddSeconds(60);
            var eventTimestamp = DateTime.UtcNow;
            var traceId = ActivityTraceId.CreateRandom();

            var parentSpanId = ActivitySpanId.CreateRandom();

            var attributes = new Dictionary<string, object>
            {
                { "stringKey", "value" },
                { "longKey", 1L },
                { "longKey2", 1 },
                { "doubleKey", 1D },
                { "doubleKey2", 1F },
                { "boolKey", true },
                { "int_array", new int[] { 1, 2 } },
                { "bool_array", new bool[] { true, false } },
                { "double_array", new double[] { 1.0, 1.1 } },
                { "string_array", new string[] { "a", "b" } },
            };
            if (additionalAttributes != null)
            {
                foreach (var attribute in additionalAttributes)
                {
                    attributes.Add(attribute.Key, attribute.Value);
                }
            }

            var events = new List<ActivityEvent>
            {
                new ActivityEvent(
                    "Event1",
                    eventTimestamp,
                    new ActivityTagsCollection(new Dictionary<string, object>
                    {
                        { "key", "value" },
                    })),
                new ActivityEvent(
                    "Event2",
                    eventTimestamp,
                    new ActivityTagsCollection(new Dictionary<string, object>
                    {
                        { "key", "value" },
                    })),
            };

            var linkedSpanId = ActivitySpanId.CreateRandom();

            var activitySource = new ActivitySource(nameof(CreateTestActivity));

            var tags = setAttributes ?
                    attributes
                    : null;
            var links = addLinks ?
                    new[]
                    {
                        new ActivityLink(new ActivityContext(
                            traceId,
                            linkedSpanId,
                            ActivityTraceFlags.Recorded)),
                    }
                    : null;

            var activity = activitySource.StartActivity(
                "Name",
                kind,
                parentContext: new ActivityContext(traceId, parentSpanId, ActivityTraceFlags.Recorded),
                tags,
                links,
                startTime: startTimestamp);

            if (addEvents)
            {
                foreach (var evnt in events)
                {
                    activity.AddEvent(evnt);
                }
            }

            if (resource != null)
            {
                activity.SetCustomProperty(ResourcePropertyName, resource);
            }

            activity.SetEndTime(endTimestamp);
            activity.Stop();

            return activity;
        }
    }
}
