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

        public static ContainerGroup CreateTestContainerGroup(string containerGroupName, bool doNotEncrypt = false)
        {
            var containers = new Container[]
            {
                new Container(
                    name: containerGroupName,
                    image: "alpine",
                    ports: new List<ContainerPort>() { new ContainerPort(80) },
                    command: new List<string>() { "/bin/sh", "-c", "while true; do sleep 10; done" },
                    environmentVariables: new List<EnvironmentVariable>
                    {
                        new EnvironmentVariable(name: "secretEnv", secureValue: "secretValue1")
                    },
                    livenessProbe: new ContainerProbe(
                        exec: new ContainerExec(command: new List<string>{ "ls" }),
                        periodSeconds: 20),
                    resources: new ResourceRequirements(requests: new ResourceRequests(memoryInGB: 1.5, cpu: 1.0)))
            };

            var initContainers = new InitContainerDefinition[]
            {
                new InitContainerDefinition(
                    name: $"{containerGroupName}init",
                    image: "alpine",
                    command: new List<string>() { "/bin/sh", "-c", "sleep 5" },
                    environmentVariables: new List<EnvironmentVariable>
                    {
                        new EnvironmentVariable(name: "secretEnv", secureValue: "secretValue1")
                    })
            };

            var ipAddress = new IpAddress(
                ports: new List<Port>() { new Port(80, "TCP") },
                dnsNameLabel: containerGroupName,
                type: ContainerGroupIpAddressType.Public);

            var logAnalytics = new LogAnalytics(
                workspaceId: "workspaceid",
                workspaceKey: "workspacekey");

            var msiIdentity = new ContainerGroupIdentity(type: ResourceIdentityType.SystemAssigned);

            var encryptionProps = doNotEncrypt ? null : new EncryptionProperties(
                vaultBaseUrl: "https://cloudaci-cloudtest.vault.azure.net/",
                keyName: "testencryptionkey",
                keyVersion: "804d3f1d5ce2456b9bc3dc9e35aaa67e");

            var containerGroup = new ContainerGroup(
                name: containerGroupName,
                location: "westus",
                osType: OperatingSystemTypes.Linux,
                ipAddress: ipAddress,
                restartPolicy: "Never",
                containers: containers,
                identity: msiIdentity,
                diagnostics: new ContainerGroupDiagnostics(logAnalytics: logAnalytics),
                sku: "Standard",
                initContainers: initContainers,
                encryptionProperties: encryptionProps);

            return containerGroup;
        }

        public static void VerifyContainerGroupProperties(ContainerGroup expected, ContainerGroup actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.OsType, actual.OsType);
            Assert.Equal(expected.RestartPolicy, actual.RestartPolicy);
            Assert.Equal(expected.Identity.Type, actual.Identity.Type);
            Assert.Equal(expected.Sku, actual.Sku);
            Assert.Equal(expected.Diagnostics.LogAnalytics.WorkspaceId, actual.Diagnostics.LogAnalytics.WorkspaceId);
            Assert.NotNull(actual.Containers);
            Assert.Equal(1, actual.Containers.Count);
            Assert.NotNull(actual.IpAddress);
            Assert.NotNull(actual.IpAddress.Ip);
            Assert.Equal(expected.EncryptionProperties?.KeyName, actual.EncryptionProperties?.KeyName);
            Assert.Equal(expected.EncryptionProperties?.KeyVersion, actual.EncryptionProperties?.KeyVersion);
            Assert.Equal(expected.EncryptionProperties?.VaultBaseUrl, actual.EncryptionProperties?.VaultBaseUrl);
            Assert.Equal(expected.IpAddress.DnsNameLabel, actual.IpAddress.DnsNameLabel);
            Assert.Equal(expected.Containers[0].Name, actual.Containers[0].Name);
            Assert.Equal(expected.Containers[0].Image, actual.Containers[0].Image);
            Assert.Equal(expected.Containers[0].LivenessProbe.PeriodSeconds, actual.Containers[0].LivenessProbe.PeriodSeconds);
            Assert.Equal(expected.Containers[0].EnvironmentVariables[0].Name, actual.Containers[0].EnvironmentVariables[0].Name);
            Assert.Equal(expected.Containers[0].Resources.Requests.Cpu, actual.Containers[0].Resources.Requests.Cpu);
            Assert.Equal(expected.Containers[0].Resources.Requests.MemoryInGB, actual.Containers[0].Resources.Requests.MemoryInGB);
            Assert.Equal(expected.InitContainers[0].Name, actual.InitContainers[0].Name);
            Assert.Equal(expected.InitContainers[0].Image, actual.InitContainers[0].Image);
        }
    }
}
