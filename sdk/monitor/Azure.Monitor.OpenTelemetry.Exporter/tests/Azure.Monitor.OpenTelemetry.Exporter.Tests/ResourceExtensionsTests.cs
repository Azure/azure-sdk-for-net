// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System.Collections.Generic;
using System.Net;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ResourceExtensionsTests
    {
        [Fact]
        public void NullResource()
        {
            Resource resource = null;
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.Null(azMonResource);
        }

        [Fact]
        public void DefaultResource()
        {
            var resource = CreateTestResource();
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.StartsWith("unknown_service", azMonResource.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource.RoleInstance);
        }

        [Fact]
        public void ServiceNameFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service");
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.Equal("my-service", azMonResource.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource.RoleInstance);
        }

        [Fact]
        public void ServiceInstanceFromResource()
        {
            var resource = CreateTestResource(serviceInstance: "my-instance");
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.StartsWith("unknown_service", azMonResource.RoleName);
            Assert.Equal("my-instance", azMonResource.RoleInstance);
        }

        [Fact]
        public void ServiceNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceNamespace: "my-namespace");
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.StartsWith("[my-namespace]/unknown_service", azMonResource.RoleName);
            Assert.Equal(Dns.GetHostName(), azMonResource.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.Equal("my-service", azMonResource.RoleName);
            Assert.Equal("my-instance", azMonResource.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceAndNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceNamespace: "my-namespace", serviceInstance: "my-instance");
            var azMonResource = resource.UpdateRoleNameAndInstance();

            Assert.Equal("[my-namespace]/my-service", azMonResource.RoleName);
            Assert.Equal("my-instance", azMonResource.RoleInstance);
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
