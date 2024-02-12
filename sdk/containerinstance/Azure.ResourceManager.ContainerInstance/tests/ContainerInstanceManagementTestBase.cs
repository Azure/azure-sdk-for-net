// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ContainerInstance.Tests
{
    public class ContainerInstanceManagementTestBase : ManagementRecordedTestBase<ContainerInstanceManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected ContainerInstanceManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ContainerInstanceManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ContainerGroupResource> CreateContainerGroupAsync(string containerGroupName, ContainerGroupData containerGroupData, ResourceGroupResource rg)
        {
            var containerGroups = rg.GetContainerGroups();
            ContainerGroupResource containerGroup = (await containerGroups.CreateOrUpdateAsync(WaitUntil.Completed, containerGroupName, containerGroupData)).Value;
            return containerGroup;
        }

        protected static ContainerGroupData CreateContainerGroupData(string containerGroupName, string priority = null, bool isConfidentialSku = false, string ccepolicy = null, bool doNotEncrypt = false)
        {
            var containers = new ContainerInstanceContainer[]
            {
                new Models.ContainerInstanceContainer(
                    name: containerGroupName,
                    image: "alpine",
                    resources: new ContainerResourceRequirements(
                        new ContainerResourceRequestsContent(
                            memoryInGB: 1.5,
                            cpu: 1.0))
                )
                {
                    Ports =
                    {
                        new ContainerPort(80)
                    },
                    Command =
                    {
                        "/bin/sh", "-c", "while true; do sleep 10; done"
                    },
                    EnvironmentVariables =
                    {
                        new ContainerEnvironmentVariable("secretEnv")
                        {
                            SecureValue = "secretValue1"
                        }
                    },
                    LivenessProbe = new ContainerProbe()
                    {
                        Exec = new ContainerExec()
                        {
                            Command =
                            {
                                "ls"
                            }
                        },
                        PeriodInSeconds = 20,
                    }
                }
            };

            var encryptionProps = doNotEncrypt ? null : new ContainerGroupEncryptionProperties(
                vaultBaseUri: new Uri("https://cloudaci-cloudtest.vault.azure.net/"),
                keyName: "testencryptionkey",
                keyVersion: "804d3f1d5ce2456b9bc3dc9e35aaa67e");

            if (priority == "Spot")
            {
                var priorityContainerGroup = new ContainerGroupData(
                    location: "westus",
                    containers: containers,
                    osType: ContainerInstanceOperatingSystemType.Linux)
                {
                    RestartPolicy = ContainerGroupRestartPolicy.Never,
                    //Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                    InitContainers = {
                        new InitContainerDefinitionContent($"{containerGroupName}init")
                        {
                            Image = "alpine",
                            Command =
                            {
                                "/bin/sh", "-c", "sleep 5"
                            },
                            EnvironmentVariables =
                            {
                                new ContainerEnvironmentVariable("secretEnv")
                                {
                                    SecureValue = "secretValue1"
                                }
                            },
                        }
                    },
                    EncryptionProperties = encryptionProps,
                    Priority = ContainerGroupPriority.Spot,
                    Sku = ContainerGroupSku.Standard
                };
                return priorityContainerGroup;
            }

            var confidentialComputeProperties = new ConfidentialComputeProperties();
            var sku = new ContainerGroupSku("Standard");
            if (isConfidentialSku)
            {
                containers = new ContainerInstanceContainer[]
                {
                    new Models.ContainerInstanceContainer(
                        name: containerGroupName,
                        image: "alpine",
                        resources: new ContainerResourceRequirements(
                          new ContainerResourceRequestsContent(
                                memoryInGB: 1.5,
                                cpu: 1.0))
                    )
                    {
                	Ports =
                        {
                            new ContainerPort(80)
                        },
                        Command =
                        {
                            "/bin/sh", "-c", "while true; do sleep 10; done"
                        },
                        EnvironmentVariables =
                        {
                            new ContainerEnvironmentVariable("secretEnv")
                            {
                                SecureValue = "secretValue1"
                            }
                        },
			            SecurityContext = new ContainerSecurityContextDefinition()
			            {
			                IsPrivileged = false
			            }
                    }
                };

                var confContainerGroup = new ContainerGroupData(
                    location: "westus",
                    containers: containers,
                    osType: ContainerInstanceOperatingSystemType.Linux)
                {
                    IPAddress = new ContainerGroupIPAddress(
                            ports: new[] { new ContainerGroupPort(80) { Protocol = ContainerGroupNetworkProtocol.Tcp } },
                            addressType: ContainerGroupIPAddressType.Public),
                    RestartPolicy = ContainerGroupRestartPolicy.Never,
                    Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                    InitContainers = {
                        new InitContainerDefinitionContent($"{containerGroupName}init")
                        {
                            Image = "alpine",
                            Command =
                            {
                                "/bin/sh", "-c", "sleep 5"
                            },
                            EnvironmentVariables =
                            {
                                new ContainerEnvironmentVariable("secretEnv")
                                {
                                    SecureValue = "secretValue1"
                                }
                            },
			                SecurityContext = new ContainerSecurityContextDefinition()
			                {
			                    IsPrivileged = false
			                }
                        }
                    },
                    Sku = ContainerGroupSku.Confidential
                };
                return confContainerGroup;
            }

            var containerGroup = new ContainerGroupData(
                location: "westus",
                containers: containers,
                osType: ContainerInstanceOperatingSystemType.Linux)
            {
                IPAddress = new ContainerGroupIPAddress(
                        ports: new[] { new ContainerGroupPort(80) { Protocol = ContainerGroupNetworkProtocol.Tcp } },
                        addressType: ContainerGroupIPAddressType.Public)
                {
                    DnsNameLabel = containerGroupName
                },
                RestartPolicy = ContainerGroupRestartPolicy.Never,
                //Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Diagnostics = new ContainerGroupDiagnostics(
                        logAnalytics: new ContainerGroupLogAnalytics(
                            workspaceId: "workspaceid",
                            workspaceKey: "workspacekey"), null),
                InitContainers = {
                    new InitContainerDefinitionContent($"{containerGroupName}init")
                    {
                        Image = "alpine",
                        Command =
                        {
                            "/bin/sh", "-c", "sleep 5"
                        },
                        EnvironmentVariables =
                        {
                            new ContainerEnvironmentVariable("secretEnv")
                            {
                                SecureValue = "secretValue1"
                            }
                        },
                    }
                },
                EncryptionProperties = encryptionProps,
                Sku = ContainerGroupSku.Standard
            };
            return containerGroup;
        }

        protected void VerifyContainerGroupProperties(ContainerGroupData expected, ContainerGroupData actual)
        {
            Assert.NotNull(actual);
            if (expected.Name != null)
                Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Location, actual.Location);
            Assert.AreEqual(expected.OSType, actual.OSType);
            Assert.AreEqual(expected.RestartPolicy, actual.RestartPolicy);
            Assert.AreEqual(expected.Identity?.ManagedServiceIdentityType, actual.Identity?.ManagedServiceIdentityType);
            Assert.AreEqual(expected.Sku, actual.Sku);
            Assert.AreEqual(expected.Diagnostics?.LogAnalytics.WorkspaceId, actual.Diagnostics?.LogAnalytics.WorkspaceId);
            Assert.NotNull(actual.Containers);
            Assert.AreEqual(1, actual.Containers.Count);
            if (expected.Priority != ContainerGroupPriority.Spot)
            {
                Assert.NotNull(actual.IPAddress);
                Assert.NotNull(actual.IPAddress.IP);
            }
            Assert.AreEqual(expected.EncryptionProperties?.KeyName, actual.EncryptionProperties?.KeyName);
            Assert.AreEqual(expected.EncryptionProperties?.KeyVersion, actual.EncryptionProperties?.KeyVersion);
            Assert.AreEqual(expected.EncryptionProperties?.VaultBaseUri, actual.EncryptionProperties?.VaultBaseUri);
            Assert.AreEqual(expected.IPAddress?.DnsNameLabel, actual.IPAddress?.DnsNameLabel);
            Assert.AreEqual(expected.Containers[0].Name, actual.Containers[0].Name);
            Assert.AreEqual(expected.Containers[0].Image, actual.Containers[0].Image);
            Assert.AreEqual(expected.Containers[0].LivenessProbe?.PeriodInSeconds, actual.Containers[0].LivenessProbe?.PeriodInSeconds);
            Assert.AreEqual(expected.Containers[0].EnvironmentVariables[0].Name, actual.Containers[0].EnvironmentVariables[0].Name);
            Assert.AreEqual(expected.Containers[0].Resources.Requests.Cpu, actual.Containers[0].Resources.Requests.Cpu);
            Assert.AreEqual(expected.Containers[0].Resources.Requests.MemoryInGB, actual.Containers[0].Resources.Requests.MemoryInGB);
            Assert.AreEqual(expected.InitContainers[0].Name, actual.InitContainers[0].Name);
            Assert.AreEqual(expected.InitContainers[0].Image, actual.InitContainers[0].Image);
            Assert.AreEqual(expected.Priority, actual.Priority);
            if (expected.Sku == ContainerGroupSku.Confidential)
            {
                Assert.NotNull(actual.ConfidentialComputeProperties?.CcePolicy);
		Assert.AreEqual(expected.Containers[0].SecurityContext?.IsPrivileged, actual.Containers[0].SecurityContext?.IsPrivileged);
		Assert.AreEqual(expected.InitContainers[0].SecurityContext?.IsPrivileged, actual.InitContainers[0].SecurityContext?.IsPrivileged);
            }
        }
    }
}
