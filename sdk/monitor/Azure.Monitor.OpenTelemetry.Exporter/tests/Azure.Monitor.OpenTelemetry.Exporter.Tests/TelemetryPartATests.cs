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
        private const string ActivitySourceName = "TelemetryPartATests";
        private const string ActivityName = "TestActivity";

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
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            var resource = CreateTestResource();

            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, resource, null);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(TelemetryPartA.FormatUtcTimestamp(activity.StartTimeUtc), telemetryItem.Time);
            Assert.StartsWith("unknown_service", telemetryItem.Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Null(telemetryItem.Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiOperationId.ToString()]);
            Assert.NotNull(telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()]);
            Assert.Throws<KeyNotFoundException>(() => telemetryItem.Tags[ContextTagKeys.AiOperationParentId.ToString()]);
        }

        [Fact]
        public void GeneratePartAEnvelope_Activity_WithResource()
        {
            using ActivitySource activitySource = new ActivitySource(ActivitySourceName);
            using var activity = activitySource.StartActivity(
                ActivityName,
                ActivityKind.Client,
                parentContext: default,
                startTime: DateTime.UtcNow);

            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");

            var telemetryItem = TelemetryPartA.GetTelemetryItem(activity, resource, null);

            Assert.Equal("RemoteDependency", telemetryItem.Name);
            Assert.Equal(TelemetryPartA.FormatUtcTimestamp(activity.StartTimeUtc), telemetryItem.Time);
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
    }
}
