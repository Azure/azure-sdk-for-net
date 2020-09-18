// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.Demo.Tracing
{
    public class AzureMonitorTransmitterTests
    {
        [Fact]
        public void GetRoleInfo_NullResource()
        {
            AzureMonitorTransmitter.GetRoleInfo(null, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void GetRoleInfo_Empty()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null);
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void GetRoleInfo_ServiceName()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service");
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.True(Guid.TryParse(roleInstance, out var guid));
        }

        [Fact]
        public void GetRoleInfo_ServiceInstance()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null, "roleInstance_1");
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void GetRoleInfo_ServiceNamespace()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource(null, null, "my-namespace");
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Empty(resource.Attributes);
            Assert.Null(roleName);
            Assert.Null(roleInstance);
        }

        [Fact]
        public void GetRoleInfo_ServiceNameAndInstance()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service", "roleInstance_1");
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }

        [Fact]
        public void GetRoleInfo_ServiceNameAndInstanceAndNamespace()
        {
            var resource = OpenTelemetry.Resources.Resources.CreateServiceResource("my-service", "roleInstance_1", "my-namespace");
            AzureMonitorTransmitter.GetRoleInfo(resource, out var roleName, out var roleInstance);
            Assert.Equal("my-namespace.my-service", roleName);
            Assert.Equal("roleInstance_1", roleInstance);
        }
    }
}
