// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Xunit;

using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Tracing
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
        public void InitRoleInfo_Default()
        {
            var resource = CreateTestResource();
            TelemetryPartA.InitRoleInfo(resource);

            Assert.StartsWith("unknown_service", TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceName()
        {
            var resource = CreateTestResource(serviceName: "my-service");
            TelemetryPartA.InitRoleInfo(resource);

            Assert.Equal("my-service", TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceInstance()
        {
            var resource = CreateTestResource(serviceInstance: "my-instance");
            TelemetryPartA.InitRoleInfo(resource);

            Assert.StartsWith("unknown_service", TelemetryPartA.RoleName);
            Assert.Equal("my-instance", TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNamespace()
        {
            var resource = CreateTestResource(serviceNamespace: "my-namespace");
            TelemetryPartA.InitRoleInfo(resource);

            Assert.StartsWith("my-namespace.unknown_service", TelemetryPartA.RoleName);
            Assert.Null(TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstance()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");
            TelemetryPartA.InitRoleInfo(resource);

            Assert.Equal("my-service", TelemetryPartA.RoleName);
            Assert.Equal("my-instance", TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceNamespace: "my-namespace", serviceInstance: "my-instance");
            TelemetryPartA.InitRoleInfo(resource);

            Assert.Equal("my-namespace.my-service", TelemetryPartA.RoleName);
            Assert.Equal("my-instance", TelemetryPartA.RoleInstance);
        }

        [Fact]
        public void GeneratePartAEnvelope_DefaultActivity_DefaultResource()
        {
            var activity = CreateTestActivity();
            var resource = CreateTestResource();

            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, resource, null);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture), telemetryItem.Time);
            Assert.StartsWith("unknown_service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Null(telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Fact]
        public void GeneratePartAEnvelope_Activity_WithResource()
        {
            var activity = CreateTestActivity();
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");

            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, resource, null);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(activity.StartTimeUtc.ToString(CultureInfo.InvariantCulture), telemetryItem.Time);
            Assert.Equal("my-service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal("my-instance", telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.Equal(activity.TraceId.ToHexString(), telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.Equal(SdkVersionUtils.SdkVersion, telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        // TODO: GeneratePartAEnvelope_WithActivityParent

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
        private static Resource CreateTestResource(string serviceName = null, string serviceNamespace = null, string serviceInstance = null)
        {
            var testAttributes = new Dictionary<string, object>();

            if (serviceName != null) testAttributes.Add("service.name", serviceName);
            if (serviceNamespace != null) testAttributes.Add("service.namespace", serviceNamespace);
            if (serviceInstance != null) testAttributes.Add("service.instance.id", serviceInstance);

            return ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
        }

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
