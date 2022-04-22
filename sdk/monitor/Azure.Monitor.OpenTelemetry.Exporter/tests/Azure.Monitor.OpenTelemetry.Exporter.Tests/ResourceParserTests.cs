// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using OpenTelemetry.Resources;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ResourceParserTests
    {
        [Fact]
        public void NullResource()
        {
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(null);

            Assert.Null(resourceParser.RoleName);
            Assert.Null(resourceParser.RoleInstance);
        }

        [Fact]
        public void DefaultResource()
        {
            var resource = CreateTestResource();
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.StartsWith("unknown_service", resourceParser.RoleName);
            Assert.Equal(Dns.GetHostName(), resourceParser.RoleInstance);
        }

        [Fact]
        public void RoleNameAndInstanceIsAssignedOnce()
        {
            var resource1 = CreateTestResource(serviceName: "my-service1", serviceInstance: "my-instance1");
            var resource2 = CreateTestResource(serviceName: "my-service2", serviceInstance: "my-instance2");

            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource1);
            resourceParser.UpdateRoleNameAndInstance(resource2);

            Assert.Equal("my-service1", resourceParser.RoleName);
            Assert.Equal("my-instance1", resourceParser.RoleInstance);
        }

        [Fact]
        public void ServiceNameFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service");
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.Equal("my-service", resourceParser.RoleName);
            Assert.Equal(Dns.GetHostName(), resourceParser.RoleInstance);
        }

        [Fact]
        public void ServiceInstanceFromResource()
        {
            var resource = CreateTestResource(serviceInstance: "my-instance");
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.StartsWith("unknown_service", resourceParser.RoleName);
            Assert.Equal("my-instance", resourceParser.RoleInstance);
        }

        [Fact]
        public void ServiceNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceNamespace: "my-namespace");
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.StartsWith("my-namespace.unknown_service", resourceParser.RoleName);
            Assert.Equal(Dns.GetHostName(), resourceParser.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceInstance: "my-instance");
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.Equal("my-service", resourceParser.RoleName);
            Assert.Equal("my-instance", resourceParser.RoleInstance);
        }

        [Fact]
        public void ServiceNameAndInstanceAndNamespaceFromResource()
        {
            var resource = CreateTestResource(serviceName: "my-service", serviceNamespace: "my-namespace", serviceInstance: "my-instance");
            var resourceParser = new ResourceParser();
            resourceParser.UpdateRoleNameAndInstance(resource);

            Assert.Equal("my-namespace.my-service", resourceParser.RoleName);
            Assert.Equal("my-instance", resourceParser.RoleInstance);
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
