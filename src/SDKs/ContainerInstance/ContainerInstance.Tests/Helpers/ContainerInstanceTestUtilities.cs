// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Azure.Management.ContainerInstance;
using Microsoft.Azure.Management.ContainerInstance.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ContainerInstance.Tests
{
    public class ContainerInstanceTestUtilities
    {
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static ContainerInstanceManagementClient GetContainerInstanceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ContainerInstanceManagementClient>(handlers: handler);
            return client;
        }

        public static ResourceGroup CreateResourceGroup(ResourceManagementClient client)
        {
            var resourceGroupName = TestUtilities.GenerateName("aci_rg");

            return client.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup
            {
                Location = "westus"
            });
        }

        public static ContainerGroup CreateTestContainerGroup(string containerGroupName)
        {
            var containers = new Container[]
            {
                new Container(
                    name: containerGroupName,
                    image: "alpine",
                    ports: new List<ContainerPort>() { new ContainerPort(80) },
                    command: new List<string>() { "/bin/sh", "-c", "while true; do sleep 10; done" },
                    resources: new ResourceRequirements(requests: new ResourceRequests(memoryInGB: 1.5, cpu: 1.0)))
            };

            var ipAddress = new IpAddress(
                ports: new List<Port>() { new Port(80, "TCP") },
                dnsNameLabel: containerGroupName);

            var containerGroup = new ContainerGroup(
                name: containerGroupName,
                location: "westus",
                osType: OperatingSystemTypes.Linux,
                ipAddress: ipAddress,
                restartPolicy: "Never",
                containers: containers);

            return containerGroup;
        }

        public static void VerifyContainerGroupProperties(ContainerGroup expected, ContainerGroup actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.OsType, actual.OsType);
            Assert.Equal(expected.RestartPolicy, actual.RestartPolicy);
            Assert.NotNull(actual.Containers);
            Assert.Equal(1, actual.Containers.Count);
            Assert.NotNull(actual.IpAddress);
            Assert.NotNull(actual.IpAddress.Ip);
            Assert.Equal(expected.IpAddress.DnsNameLabel, actual.IpAddress.DnsNameLabel);
            Assert.Equal(expected.Containers[0].Name, actual.Containers[0].Name);
            Assert.Equal(expected.Containers[0].Image, actual.Containers[0].Image);
            Assert.Equal(expected.Containers[0].Resources.Requests.Cpu, actual.Containers[0].Resources.Requests.Cpu);
            Assert.Equal(expected.Containers[0].Resources.Requests.MemoryInGB, actual.Containers[0].Resources.Requests.MemoryInGB);
        }
    }
}
