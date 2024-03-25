// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests;

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
    [InlineData(null, "true")]
    [InlineData(null, "false")]
    [InlineData(null, null)]
    [InlineData(InstrumentationKey, "false")]
    [InlineData(InstrumentationKey, "true")]
    [InlineData(InstrumentationKey, null)]
    public void DefaultResource(string? instrumentationKey, string envVarValue)
    {
        try
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, envVarValue);
            var resource = CreateTestResource();
            var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

            Assert.StartsWith("unknown_service", azMonResource?.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource?.RoleInstance);
            if (envVarValue == "true")
            {
                Assert.Equal(instrumentationKey != null, azMonResource?.MonitorBaseData != null);
            }
            else
            {
                Assert.Null(azMonResource?.MonitorBaseData);
            }
        }
        finally
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, null);
        }
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
    public void SetsSdkDistroSuffixFromResource()
    {
        // SDK version is static, preserve to clean up later.
        var sdkVersion = SdkVersionUtils.s_sdkVersion;
        var testAttributes = new Dictionary<string, object>
        {
            { "telemetry.distro.name", "Azure.Monitor.OpenTelemetry.AspNetCore" }
        };

        var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
        _ = resource.CreateAzureMonitorResource();

        Assert.EndsWith("-d", SdkVersionUtils.s_sdkVersion);

        // Clean up
        SdkVersionUtils.s_sdkVersion = sdkVersion;
    }

    [Fact]
    public void DoesNotSetSdkDistroSuffixForWrongValueFromResource()
    {
        // SDK version is static, preserve to clean up later.
        var sdkVersion = SdkVersionUtils.s_sdkVersion;
        var testAttributes = new Dictionary<string, object>
        {
            { "telemetry.distro.name", "" }
        };

        var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
        _ = resource.CreateAzureMonitorResource();

        Assert.DoesNotContain("-d", SdkVersionUtils.s_sdkVersion);

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
        try
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, "true");

            // SDK version is static, preserve to clean up later.
            var sdkVersion = SdkVersionUtils.s_sdkVersion;
            var testAttributes = new Dictionary<string, object>
            {
                {"foo", "bar" },
                { "ai.sdk.prefix", "pre_" }
            };

            var resource = ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
            var azMonResource = resource.CreateAzureMonitorResource(InstrumentationKey);

            var monitorBase = azMonResource?.MonitorBaseData;
            var metricsData = monitorBase?.BaseData as MetricsData;

            var metricDataPoint = metricsData?.Metrics[0];
            Assert.Equal("bar", metricsData?.Properties["foo"]);
            Assert.False(metricsData?.Properties.ContainsKey("ai.sdk.prefix"));

            // Clean up
            SdkVersionUtils.s_sdkVersion = sdkVersion;
        }
        finally
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, null);
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData(InstrumentationKey)]
    public void MonitorBaseDataHasAllResourceAttributes(string? instrumentationKey)
    {
        try
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, "true");

            var testAttributes = new Dictionary<string, object>
            {
                {SemanticConventions.AttributeServiceName, "my-service" },
                {SemanticConventions.AttributeServiceNamespace, "my-namespace" },
                {SemanticConventions.AttributeServiceInstance, "my-instance" },
                {SemanticConventions.AttributeK8sDeployment, "my-deployment" },
                {SemanticConventions.AttributeK8sPod, "my-pod" },
                { "foo", "bar" }
            };

            var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
            var azMonResource = resource.CreateAzureMonitorResource(instrumentationKey);

            Assert.Equal(instrumentationKey != null, azMonResource?.MonitorBaseData != null);

            if (instrumentationKey != null)
            {
                Assert.NotNull(azMonResource?.MonitorBaseData);

                var monitorBase = azMonResource.MonitorBaseData;
                var metricsData = monitorBase.BaseData as MetricsData;

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
        }
        finally
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, null);
        }
    }

    [Fact]
    public void ResourceWithKubernetesAttributes()
    {
        // Arrange
        var testAttributes = new Dictionary<string, object>
        {
            {SemanticConventions.AttributeK8sDeployment, "my-deployment" },
            {SemanticConventions.AttributeK8sPod, "my-pod" },
        };

        var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
        var azMonResource = resource.CreateAzureMonitorResource();

        // Assert
        Assert.Equal("my-deployment", azMonResource?.RoleName);
        Assert.Equal("my-pod", azMonResource?.RoleInstance);
    }

    [Fact]
    public void ResourceWithKubernetesServiceAndCustomAttributes()
    {
        // Arrange
        var testAttributes = new Dictionary<string, object>
        {
            {SemanticConventions.AttributeServiceName, "my-service" },
            {SemanticConventions.AttributeServiceInstance, "my-instance" },
            {SemanticConventions.AttributeK8sDeployment, "my-deployment" },
            {SemanticConventions.AttributeK8sPod, "my-pod" },
            { "foo", "bar" }
        };

        var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
        var azMonResource = resource.CreateAzureMonitorResource();

        // Assert
        Assert.Equal("my-service", azMonResource?.RoleName);
        Assert.Equal("my-instance", azMonResource?.RoleInstance);
    }

    [Fact]
    public void ResourceWithEmptyKubernetesAttributes()
    {
        // Arrange
        var testAttributes = new Dictionary<string, object>
        {
            {SemanticConventions.AttributeK8sDeployment, string.Empty },
            {SemanticConventions.AttributeK8sPod, string.Empty },
        };

        var resource = ResourceBuilder.CreateEmpty().AddAttributes(testAttributes).Build();
        var azMonResource = resource.CreateAzureMonitorResource();

        // Assert
        Assert.Null(azMonResource?.RoleName);
        Assert.Equal(Dns.GetHostName(), azMonResource?.RoleInstance);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("true")]
    [InlineData("false")]
    public void MetricTelemetryIsAddedToResourceBasedOnEnvVar(string envVarValue)
    {
        try
        {
            Environment.SetEnvironmentVariable(EnvironmentVariableConstants.EXPORT_RESOURCE_METRIC, envVarValue);

            var resource = ResourceBuilder.CreateDefault().Build();
            var azMonResource = resource.CreateAzureMonitorResource(InstrumentationKey);

            if (envVarValue == "true")
            {
                Assert.NotNull(azMonResource?.MonitorBaseData);
            }
            else
            {
                Assert.Null(azMonResource?.MonitorBaseData);
            }
        }
        finally
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
    /// var resourceAttributes = new Dictionary<string, object> { { SemanticConventions.AttributeServiceInstance, "my-service" }, { SemanticConventions.AttributeServiceNamespace, "my-namespace" }, { SemanticConventions.AttributeServiceInstance, "my-instance" } };
    /// var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);
    /// var tracerProvider = Sdk.CreateTracerProviderBuilder().SetResourceBuilder(resourceBuilder).Build();
    /// var resource = tracerProvider.GetResource();
    /// </code>
    /// </remarks>
    private static Resource CreateTestResource(string? serviceName = null, string? serviceNamespace = null, string? serviceInstance = null)
    {
        var testAttributes = new Dictionary<string, object>();

        if (serviceName != null)
            testAttributes.Add(SemanticConventions.AttributeServiceName, serviceName);
        if (serviceNamespace != null)
            testAttributes.Add(SemanticConventions.AttributeServiceNamespace, serviceNamespace);
        if (serviceInstance != null)
            testAttributes.Add(SemanticConventions.AttributeServiceInstance, serviceInstance);

        return ResourceBuilder.CreateDefault().AddAttributes(testAttributes).Build();
    }
}
