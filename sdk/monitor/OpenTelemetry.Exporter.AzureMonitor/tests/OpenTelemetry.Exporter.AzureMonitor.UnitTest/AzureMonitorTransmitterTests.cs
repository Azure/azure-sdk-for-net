// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    public class AzureMonitorTransmitterTests
    {
        [Fact]
        public void ExtractRoleInfo_NullResource()
        {
            AzureMonitorTransmitter.ExtractRoleInfo(null, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_Empty()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null);
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceName()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service");
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.True(Guid.TryParse(roleInstance, out var guid));
        }

        [Fact]
        public void ExtractRoleInfo_ServiceInstance()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null, "roleInstance_1");
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNamespace()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null, null, "my-namespace");
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNameAndInstance()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service", "roleInstance_1");
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }

        [Fact]
        public void ExtractRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service", "roleInstance_1", "my-namespace");
            AzureMonitorTransmitter.ExtractRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-namespace.my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }
    }
}
