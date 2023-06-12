﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ResourceExtensionsTests
    {
        private const string InstrumentationKey = "00000000-0000-0000-0000-000000000000";

        [Theory]
        [InlineData(null)]
        [InlineData(InstrumentationKey)]
        public void NullResource(string? instrumentationKey)
        {
            Resource? resource = null;
            var azMonResource = resource!.CreateAzureMonitorResource(instrumentationKey);

            Assert.Null(azMonResource);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(InstrumentationKey)]
        public void DefaultResource(string? instrumentationKey)
        {
            var resource = CreateTestResource();
            var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

            Assert.StartsWith("unknown_service", azMonResource?.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource?.RoleInstance);
            Assert.Equal(instrumentationKey != null, azMonResource?.MetricTelemetry != null);
        }

        [Fact]
        public void ServiceNameFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service");
            var azMonResource = resource.CreateAzureMonitorResource();

            Assert.Equal("my-service", azMonResource?.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource?.RoleInstance);
        }

        [Fact]
        public void ServiceInstanceFromResource()
        {
            var resource = CreateTestResource(serviceInstance: "my-instance");
            var azMonResource = resource.CreateAzureMonitorResource();

            Assert.StartsWith("unknown_service", azMonResource?.RoleName);
            Assert.Equal("my-instance", azMonResource?.RoleInstance);
        }

        [Fact]
        public void ServiceNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceNamespace: "my-namespace");
            var azMonResource = resource.CreateAzureMonitorResource();

            Assert.StartsWith("[my-namespace]/unknown_service", azMonResource?.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource?.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");
            var azMonResource = resource.CreateAzureMonitorResource();

            Assert.Equal("my-service", azMonResource?.RoleName);
            Assert.Equal("my-instance", azMonResource?.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceAndNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceNamespace: "my-namespace", serviceInstance: "my-instance");
            var azMonResource = resource.CreateAzureMonitorResource();

            Assert.Equal("[my-namespace]/my-service", azMonResource?.RoleName);
            Assert.Equal("my-instance", azMonResource?.RoleInstance);
        }

        [Fact]
        public void SetsSdkVersionPrefixFromResource()
        {
            // SDK version is static, preserve to clean up later.
            var sdkVersion = SdkVersionUtils.s_sdkVersion;
            var testAttributes = new Dictionary<string, object>
            {
                { "ai.sdk.prefix", "pre_" }
            };

            var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
            _ = resource.CreateAzureMonitorResource();

            Assert.StartsWith("pre_", SdkVersionUtils.s_sdkVersion);

            // Clean up
            SdkVersionUtils.s_sdkVersion = sdkVersion;
        }

        [Fact]
        public void MissingPrefixResourceDoesNotSetSdkPrefix()
        {
            // SDK version is static, preserve to clean up later.
            var sdkVersion = SdkVersionUtils.s_sdkVersion;

            var resource = ResourceBuilder.CreateDefault().Build();
            _ = resource.CreateAzureMonitorResource();

            Assert.NotNull(SdkVersionUtils.s_sdkVersion);
            Assert.DoesNotContain("_", SdkVersionUtils.s_sdkVersion);

            // Clean up
            SdkVersionUtils.s_sdkVersion = sdkVersion;
        }

        [Fact]
        public void EmptyPrefixResourceDoesNotSetSdkPrefix()
        {
            // SDK version is static, preserve to clean up later.
            var sdkVersion = SdkVersionUtils.s_sdkVersion;

            var testAttributes = new Dictionary<string, object>
            {
                { "ai.sdk.prefix", string.Empty }
            };

            var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
            _ = resource.CreateAzureMonitorResource();

            Assert.NotNull(SdkVersionUtils.s_sdkVersion);
            Assert.DoesNotContain("_", SdkVersionUtils.s_sdkVersion);

            // Clean up
            SdkVersionUtils.s_sdkVersion = sdkVersion;
        }

        [Fact]
        public void SdkPrefixIsNotInResourceMetrics()
        {
            // SDK version is static, preserve to clean up later.
            var sdkVersion = SdkVersionUtils.s_sdkVersion;
            var testAttributes = new Dictionary<string, object>
            {
                {"foo", "bar" },
                { "ai.sdk.prefix", "pre_" }
            };

            var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
            var azMonResource = resource.CreateAzureMonitorResource(InstrumentationKey);

            Assert.Equal("Metric", azMonResource!.MetricTelemetry!.Name);

            var monitorBase = azMonResource.MetricTelemetry.Data;
            var metricsData = monitorBase.BaseData as MetricsData;

            var metricDataPoint = metricsData?.Metrics[0];
            Assert.Equal("bar", metricsData?.Properties["foo"]);
            Assert.False(metricsData?.Properties.ContainsKey("ai.sdk.prefix"));

            // Clean up
            SdkVersionUtils.s_sdkVersion = sdkVersion;
        }

        [Theory]
        [InlineData(null)]
        [InlineData(InstrumentationKey)]
        public void MetricTelemetryHasAllResourceAttributes(string? instrumentationKey)
        {
            var testAttributes = new Dictionary<string, object>
            {
                {"service.name", "my-service" },
                {"service.namespace", "my-namespace" },
                {"service.instance.id", "my-instance" },
                { "foo", "bar" }
            };

            var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
            var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

            Assert.Equal(instrumentationKey != null, azMonResource?.MetricTelemetry != null);

            if (instrumentationKey != null)
            {
                Assert.Equal("Metric", azMonResource!.MetricTelemetry!.Name);
                Assert.Equal(3, azMonResource.MetricTelemetry.Tags.Count);
                Assert.NotNull(azMonResource.MetricTelemetry.Data);

                var monitorBase = azMonResource.MetricTelemetry.Data;
                var metricsData = monitorBase.BaseData as MetricsData;

                Assert.NotNull(metricsData?.Metrics);

                var metricDataPoint = metricsData?.Metrics[0];
                Assert.Equal("_OTELRESOURCE_", metricDataPoint?.Name);
                Assert.Equal(0, metricDataPoint?.Value);

                Assert.Equal(4, metricsData?.Properties.Count);

                Assert.Equal("my-service", metricsData?.Properties["service.name"]);
                Assert.Equal("my-namespace", metricsData?.Properties["service.namespace"]);
                Assert.Equal("my-instance", metricsData?.Properties["service.instance.id"]);
                Assert.Equal("bar", metricsData?.Properties["foo"]);
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
