// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    [Collection("ManipulatesEnvironmentVariable")]
    public class ResourcePrecedenceTests : IDisposable
    {
        private const string OtelServiceName = "OTEL_SERVICE_NAME";
        private const string OtelResourceAttributes = "OTEL_RESOURCE_ATTRIBUTES";
        private const string AppServiceSiteName = "WEBSITE_SITE_NAME";
        private const string AppServiceInstanceId = "WEBSITE_INSTANCE_ID";
        private const string ContainerAppName = "CONTAINER_APP_NAME";
        private const string ContainerAppReplicaName = "CONTAINER_APP_REPLICA_NAME";

        private static readonly string[] EnvironmentVariableNames =
        [
            OtelServiceName,
            OtelResourceAttributes,
            AppServiceSiteName,
            AppServiceInstanceId,
            ContainerAppName,
            ContainerAppReplicaName,
        ];

        private readonly Dictionary<string, string?> _originalEnvironmentVariables = [];

        public ResourcePrecedenceTests()
        {
            foreach (var name in EnvironmentVariableNames)
            {
                _originalEnvironmentVariables[name] = Environment.GetEnvironmentVariable(name);
                Environment.SetEnvironmentVariable(name, null);
            }
        }

        public void Dispose()
        {
            foreach (var variable in _originalEnvironmentVariables)
            {
                Environment.SetEnvironmentVariable(variable.Key, variable.Value);
            }
        }

        [Fact]
        public void OtelServiceNameTakesPrecedenceOverAppServiceSiteName()
        {
            Environment.SetEnvironmentVariable(OtelServiceName, "otel-service-name");
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");

            var resource = CreateResource();

            AssertAttribute(resource, "service.name", "otel-service-name");
            AssertAttribute(resource, "cloud.platform", "azure_app_service");
        }

        [Fact]
        public void AppServiceSiteNameIsUsedWhenOtelServiceNameIsNotSet()
        {
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");

            AssertAttribute(CreateResource(), "service.name", "app-service-site-name");
        }

        [Fact]
        public void OtelResourceAttributesServiceNameTakesPrecedenceOverAppServiceSiteName()
        {
            Environment.SetEnvironmentVariable(OtelResourceAttributes, "service.name=resource-service-name");
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");

            AssertAttribute(CreateResource(), "service.name", "resource-service-name");
        }

        [Fact]
        public void OtelServiceNameTakesPrecedenceOverOtelResourceAttributesServiceName()
        {
            Environment.SetEnvironmentVariable(OtelServiceName, "otel-service-name");
            Environment.SetEnvironmentVariable(OtelResourceAttributes, "service.name=resource-service-name");
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");

            AssertAttribute(CreateResource(), "service.name", "otel-service-name");
        }

        [Theory]
        [InlineData(null, "container-app-name")]
        [InlineData("otel-service-name", "otel-service-name")]
        public void OtelServiceNameTakesPrecedenceOverContainerAppName(string? otelServiceName, string expectedServiceName)
        {
            Environment.SetEnvironmentVariable(OtelServiceName, otelServiceName);
            Environment.SetEnvironmentVariable(ContainerAppName, "container-app-name");
            Environment.SetEnvironmentVariable(ContainerAppReplicaName, "container-app-replica");

            var resource = CreateResource();

            AssertAttribute(resource, "service.name", expectedServiceName);
            AssertAttribute(resource, "cloud.platform", "azure_container_apps");
        }

        [Fact]
        public void OtelResourceAttributesInstanceIdTakesPrecedenceOverAppServiceInstanceId()
        {
            Environment.SetEnvironmentVariable(OtelResourceAttributes, "service.instance.id=resource-instance");
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");
            Environment.SetEnvironmentVariable(AppServiceInstanceId, "app-service-instance");

            AssertAttribute(CreateResource(), "service.instance.id", "resource-instance");
        }

        [Fact]
        public void OtelServiceNameFromConfigurationTakesPrecedenceOverAppServiceSiteName()
        {
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    [OtelServiceName] = "configured-service-name",
                })
                .Build();

            AssertAttribute(CreateResource(configuration), "service.name", "configured-service-name");
        }

        [Fact]
        public void ResourceConfiguredAfterUseAzureMonitorTakesPrecedenceOverOtelServiceName()
        {
            Environment.SetEnvironmentVariable(OtelServiceName, "otel-service-name");
            Environment.SetEnvironmentVariable(AppServiceSiteName, "app-service-site-name");

            AssertAttribute(
                CreateResource(configureBuilder: builder => builder.ConfigureResource(resource => resource.AddService("code-name"))),
                "service.name",
                "code-name");
        }

        private static Resource CreateResource(IConfiguration? configuration = null, Action<OpenTelemetryBuilder>? configureBuilder = null)
        {
            var services = new ServiceCollection();
            if (configuration != null)
            {
                services.AddSingleton(configuration);
            }

            var builder = services.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = "InstrumentationKey=unitTest";
                    options.EnableLiveMetrics = false;
                });
            configureBuilder?.Invoke(builder);

            using var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetRequiredService<TracerProvider>().GetResource();
        }

        private static void AssertAttribute(Resource resource, string key, string expectedValue)
        {
            Assert.Equal(expectedValue, resource.Attributes.Single(attribute => attribute.Key == key).Value);
        }
    }
}
