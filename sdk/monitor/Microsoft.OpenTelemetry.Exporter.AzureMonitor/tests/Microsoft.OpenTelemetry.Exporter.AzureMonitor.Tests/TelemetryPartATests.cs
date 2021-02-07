// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Xunit;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Resources;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    public class TelemetryPartATests
    {
        private const string ResourcePropertyName = "OTel.Resource";

        static TelemetryPartATests()
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

        public TelemetryPartATests()
        {
            TelemetryPartA.RoleName = null;
            TelemetryPartA.RoleInstance = null;
        }

        [Fact]
        public void InitRoleInfo_NullResource()
        {
            TelemetryPartA.InitRoleInfo(null);

            Assert.Null(TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_Empty()
        {
            using var activity = new Activity("InitRoleInfo_Empty");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource(null));

            TelemetryPartA.InitRoleInfo(activity);
            Assert.Null(TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceName()
        {
            using var activity = new Activity("InitRoleInfo_ServiceName");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource("my-service"));
            TelemetryPartA.InitRoleInfo(activity);
            Assert.Equal("my-service", TelemetryPartA.RoleName);
            Assert.True(Guid.TryParse(TelemetryPartA.RoleInstance, out var guid));
        }

        [Fact]
        public void InitRoleInfo_ServiceInstance()
        {
            using var activity = new Activity("InitRoleInfo_ServiceInstance");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource(null, "roleInstance_1"));
            TelemetryPartA.InitRoleInfo(activity);

            Assert.Null(TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNamespace()
        {
            using var activity = new Activity("InitRoleInfo_ServiceNamespace");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource(null, null, "my-namespace"));
            TelemetryPartA.InitRoleInfo(activity);
            Assert.Null(TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstance()
        {
            using var activity = new Activity("InitRoleInfo_ServiceNameAndInstance");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource("my-service", "roleInstance_1"));
            TelemetryPartA.InitRoleInfo(activity);
            Assert.Equal("my-service", TelemetryPartA.RoleName);
            Assert.Equal("roleInstance_1", TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            using var activity = new Activity("InitRoleInfo_ServiceNameAndInstanceAndNamespace");
            activity.SetCustomProperty(ResourcePropertyName, Resources.CreateServiceResource("my-service", "roleInstance_1", "my-namespace"));
            TelemetryPartA.InitRoleInfo(activity);
            Assert.Equal("my-namespace.my-service", TelemetryPartA.RoleName);
            Assert.Equal("roleInstance_1", TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void GeneratePartAEnvelope_DefaultActivity()
        {
            var activity = CreateTestActivity();
            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, null);
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

            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, null);
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
