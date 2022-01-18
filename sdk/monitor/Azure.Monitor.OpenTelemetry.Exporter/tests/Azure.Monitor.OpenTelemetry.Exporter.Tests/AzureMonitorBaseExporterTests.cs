// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class AzureMonitorBaseExporterTests
    {
        [Fact]
        public void InitRoleInfo_NullResource()
        {
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance();

            Assert.Null(traceExporter.RoleName);
            Assert.Null(traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_Default()
        {
            var resource = CreateTestResource();
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.StartsWith("unknown_service", traceExporter.RoleName);
            Assert.Equal(Dns.GetHostName(), traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceName()
        {
            var resource = CreateTestResource(serviceName: "my-service");
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.Equal("my-service", traceExporter.RoleName);
            Assert.Equal(Dns.GetHostName(), traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceInstance()
        {
            var resource = CreateTestResource(serviceInstance: "my-instance");
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.StartsWith("unknown_service", traceExporter.RoleName);
            Assert.Equal("my-instance", traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNamespace()
        {
            var resource = CreateTestResource(serviceNamespace: "my-namespace");
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.StartsWith("my-namespace.unknown_service", traceExporter.RoleName);
            Assert.Equal(Dns.GetHostName(), traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstance()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.Equal("my-service", traceExporter.RoleName);
            Assert.Equal("my-instance", traceExporter.RoleInstance);
        }

        [Fact]
        public void InitRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceNamespace: "my-namespace", serviceInstance: "my-instance");
            AzureMonitorTestTraceExporter<Activity> traceExporter = new AzureMonitorTestTraceExporter<Activity>();
            traceExporter.InitRoleNameAndInstance(resource);

            Assert.Equal("my-namespace.my-service", traceExporter.RoleName);
            Assert.Equal("my-instance", traceExporter.RoleInstance);
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
        private static Resource CreateTestResource(string serviceName = null, string serviceNamespace = null, string serviceInstance = null)
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
