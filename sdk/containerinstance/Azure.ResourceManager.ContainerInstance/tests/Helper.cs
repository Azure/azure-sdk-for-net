// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.ResourceManager.ContainerInstance.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using ResourceIdentityType = Azure.ResourceManager.ContainerInstance.Models.ResourceIdentityType;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    public class Helper
    {
        internal const string ResourceGroupPrefix = "containerInstance-rg-test";
        internal const string ContainerGroupPrefix = "sdk-containergroup-";

        public static string GenerateRandomKey()
        {
            byte[] key256 = new byte[32];
            using (var rngCryptoServiceProvider = RandomNumberGenerator.Create())
            {
                rngCryptoServiceProvider.GetBytes(key256);
            }

            return Convert.ToBase64String(key256);
        }
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupsOperations resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
        }
        public static ContainerGroup CreateTestContainerGroup(string containerGroupName, string location = "eastus", bool doNotEncrypt = false)
        {
            var containers = new Container[]
            {
                new Container(
                    name: containerGroupName,
                    image: "alpine",
                    resources: new ResourceRequirements(requests: new ResourceRequests(memoryInGB: 1.5, cpu: 1.0)))
                    {
                        LivenessProbe =  new ContainerProbe()
                        {
                            Exec =  new ContainerExec(command: new List<string> { "ls" }),
                            PeriodSeconds = 20
                        },
                        Ports = { new ContainerPort(8000) },
                        Command = { "/bin/sh", "-c", "while true; do sleep 10; done" },
                        EnvironmentVariables = { new Models.EnvironmentVariable("secretEnv") { SecureValue = "secretValue1" } }
                    }
            };

            var ipAddress = new IpAddress(
                ports: new List<Port>() { new Port(8000) { Protocol = ContainerGroupNetworkProtocol.TCP } },
                type: ContainerGroupIpAddressType.Public)
            {
                DnsNameLabel = containerGroupName
            };

            var logAnalytics = new LogAnalytics(
                workspaceId: "workspaceid",
                workspaceKey: "workspacekey");

            var msiIdentity = new ContainerGroupIdentity() { Type = ResourceIdentityType.SystemAssigned };

            var encryptionProps = doNotEncrypt ? null : new EncryptionProperties(
                vaultBaseUrl: "https://cloudaci-cloudtest.vault.azure.net/",
                keyName: "testencryptionkey",
                keyVersion: "804d3f1d5ce2456b9bc3dc9e35aaa67e");

            var containerGroup = new ContainerGroup(containers: containers, osType: OperatingSystemTypes.Linux)
            {
                IpAddress = ipAddress,
                RestartPolicy = ContainerGroupRestartPolicy.Never,
                Identity = msiIdentity,
                Diagnostics = new ContainerGroupDiagnostics(logAnalytics: logAnalytics),
                Sku = ContainerGroupSku.Standard,
                EncryptionProperties = encryptionProps,
                Location = location,
                InitContainers = {new InitContainerDefinition(name: $"{containerGroupName}init")
                {
                    Image = "alpine",
                }}
            };

            return containerGroup;
        }

        public static void VerifyContainerGroupProperties(ContainerGroup expected, ContainerGroup actual)
        {
            Assert.NotNull(actual);
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreEqual(expected.OsType, actual.OsType);
            Assert.AreEqual(expected.RestartPolicy, actual.RestartPolicy);
            Assert.AreEqual(expected.Identity.Type, actual.Identity.Type);
            Assert.AreEqual(expected.Sku, actual.Sku);
            Assert.AreEqual(expected.Diagnostics.LogAnalytics.WorkspaceId, actual.Diagnostics.LogAnalytics.WorkspaceId);
            Assert.NotNull(actual.Containers);
            Assert.AreEqual(1, actual.Containers.Count);
            Assert.NotNull(actual.IpAddress);
            Assert.NotNull(actual.IpAddress.Ip);
            Assert.AreEqual(expected.EncryptionProperties?.KeyName, actual.EncryptionProperties?.KeyName);
            Assert.AreEqual(expected.EncryptionProperties?.KeyVersion, actual.EncryptionProperties?.KeyVersion);
            Assert.AreEqual(expected.EncryptionProperties?.VaultBaseUrl, actual.EncryptionProperties?.VaultBaseUrl);
            Assert.AreEqual(expected.IpAddress.DnsNameLabel, actual.IpAddress.DnsNameLabel);
            Assert.AreEqual(expected.Containers[0].Name, actual.Containers[0].Name);
            Assert.AreEqual(expected.Containers[0].Image, actual.Containers[0].Image);
            Assert.AreEqual(expected.Containers[0].LivenessProbe.PeriodSeconds, actual.Containers[0].LivenessProbe.PeriodSeconds);
            Assert.AreEqual(expected.Containers[0].EnvironmentVariables[0].Name, actual.Containers[0].EnvironmentVariables[0].Name);
            Assert.AreEqual(expected.Containers[0].Resources.Requests.Cpu, actual.Containers[0].Resources.Requests.Cpu);
            Assert.AreEqual(expected.Containers[0].Resources.Requests.MemoryInGB, actual.Containers[0].Resources.Requests.MemoryInGB);
            Assert.AreEqual(expected.InitContainers[0].Name, actual.InitContainers[0].Name);
            Assert.AreEqual(expected.InitContainers[0].Image, actual.InitContainers[0].Image);
        }
    }
}
