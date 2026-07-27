// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.ContainerInstance;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Network;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.StandbyPool.Tests;

public class BasicStandbyPoolTests
{
    internal static Trycep CreateStandbyVirtualMachinePoolTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:StandbyPoolBasic
                Infrastructure infra = new();

                StandbyVirtualMachinePool pool =
                    new(nameof(pool), StandbyVirtualMachinePool.ResourceVersions.V2025_10_01)
                    {
                        Tags = { ["environment"] = "test" },
                        Properties = new StandbyVirtualMachinePoolProperties
                        {
                            ElasticityProfile = new StandbyVirtualMachinePoolElasticityProfile
                            {
                                MaxReadyCapacity = 2,
                                MinReadyCapacity = 1,
                            },
                            VirtualMachineState = StandbyVirtualMachineState.Running,
                            AttachedVirtualMachineScaleSetId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.Compute/virtualMachineScaleSets/sample-vmss"),
                        },
                    };
                infra.Add(pool);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.standbypool/standbyvirtualmachinepools?pivots=deployment-language-terraform#usage-examples")]
    public async Task CreateStandbyVirtualMachinePool()
    {
        await using Trycep test = CreateStandbyVirtualMachinePoolTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource pool 'Microsoft.StandbyPool/standbyVirtualMachinePools@2025-10-01' = {
              name: take('pool-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                elasticityProfile: {
                  maxReadyCapacity: 2
                  minReadyCapacity: 1
                }
                virtualMachineState: 'Running'
                attachedVirtualMachineScaleSetId: '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-rg/providers/Microsoft.Compute/virtualMachineScaleSets/sample-vmss'
              }
            }
            """);
    }

    internal static Trycep CreateStandbyContainerGroupPoolTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter resourceName = new(nameof(resourceName), typeof(string))
                {
                    Value = "acctest0001"
                };
                infra.Add(resourceName);

                ContainerGroupProfile containerGroupProfile =
                    new(nameof(containerGroupProfile), ContainerGroupProfile.ResourceVersions.V2025_09_01)
                    {
                        Name = BicepFunction.Interpolate($"{resourceName}-containerGroup"),
                        Containers =
                        {
                            new ContainerInstanceContainer
                            {
                                Name = "mycontainergroupprofile",
                                Image = "mcr.microsoft.com/azuredocs/aci-helloworld:latest",
                                Ports =
                                {
                                    new ContainerPort { Port = 8000 }
                                },
                                Resources = new ContainerResourceRequirements
                                {
                                    Requests = new ContainerResourceRequestsContent
                                    {
                                        Cpu = 1,
                                        MemoryInGB = 1.5,
                                    },
                                },
                            }
                        },
                        IPAddress = new ContainerGroupIPAddress
                        {
                            AddressType = ContainerGroupIPAddressType.Public,
                            Ports =
                            {
                                new ContainerGroupPort { Port = 8000, Protocol = ContainerGroupNetworkProtocol.Tcp }
                            },
                        },
                        OSType = ContainerInstanceOperatingSystemType.Linux,
                        Sku = ContainerGroupSku.Standard,
                    };
                infra.Add(containerGroupProfile);

                SubnetResource subnet = new(nameof(subnet))
                {
                    Name = BicepFunction.Interpolate($"{resourceName}-subnet"),
                    AddressPrefix = "10.0.2.0/24",
                };

                VirtualNetwork virtualNetwork = new(nameof(virtualNetwork), VirtualNetwork.ResourceVersions.V2022_07_01)
                {
                    Name = BicepFunction.Interpolate($"{resourceName}-vnet"),
                    AddressSpace = new VirtualNetworkAddressSpace
                    {
                        AddressPrefixes = ["10.0.0.0/16"]
                    },
                    Subnets =
                    {
                      subnet
                    },
                };
                infra.Add(virtualNetwork);

                StandbyContainerGroupPool standbyContainerGroupPool =
                    new(nameof(standbyContainerGroupPool), StandbyContainerGroupPool.ResourceVersions.V2025_10_01)
                    {
                        Name = BicepFunction.Interpolate($"{resourceName}-CGPool"),
                        Properties = new StandbyContainerGroupPoolProperties
                        {
                            ContainerGroupProperties = new StandbyContainerGroupProperties
                            {
                                ContainerGroupProfile = new StandbyContainerGroupProfile
                                {
                                    Id = containerGroupProfile.Id,
                                    Revision = 1,
                                },
                                SubnetIds =
                                {
                                    new WritableSubResource
                                    {
                                    Id = subnet.Id,
                                    }
                                },
                            },
                            ElasticityProfile = new StandbyContainerGroupPoolElasticityProfile
                            {
                                MaxReadyCapacity = 5,
                                RefillPolicy = StandbyRefillPolicy.Always,
                            },
                            Zones = { "1", "2", "3" },
                        },
                    };
                infra.Add(standbyContainerGroupPool);

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.standbypool/standbycontainergrouppools?pivots=deployment-language-bicep#usage-examples")]
    public async Task CreateStandbyContainerGroupPool()
    {
        await using Trycep test = CreateStandbyContainerGroupPoolTest();
        test.Compare(
            """
            param resourceName string = 'acctest0001'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource containerGroupProfile 'Microsoft.ContainerInstance/containerGroupProfiles@2025-09-01' = {
              name: '${resourceName}-containerGroup'
              location: location
              properties: {
                sku: 'Standard'
                containers: [
                  {
                    name: 'mycontainergroupprofile'
                    properties: {
                      image: 'mcr.microsoft.com/azuredocs/aci-helloworld:latest'
                      ports: [
                        {
                          port: 8000
                        }
                      ]
                      resources: {
                        requests: {
                          memoryInGB: json('1.5')
                          cpu: 1
                        }
                      }
                    }
                  }
                ]
                ipAddress: {
                  ports: [
                    {
                      protocol: 'TCP'
                      port: 8000
                    }
                  ]
                  type: 'Public'
                }
                osType: 'Linux'
              }
            }

            resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-07-01' = {
              name: '${resourceName}-vnet'
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    '10.0.0.0/16'
                  ]
                }
                subnets: [
                  {
                    name: '${resourceName}-subnet'
                    properties: {
                      addressPrefix: '10.0.2.0/24'
                    }
                  }
                ]
              }
              location: location
            }

            resource standbyContainerGroupPool 'Microsoft.StandbyPool/standbyContainerGroupPools@2025-10-01' = {
              name: '${resourceName}-CGPool'
              location: location
              properties: {
                elasticityProfile: {
                  maxReadyCapacity: 5
                  refillPolicy: 'always'
                }
                containerGroupProperties: {
                  containerGroupProfile: {
                    id: containerGroupProfile.id
                    revision: 1
                  }
                  subnetIds: [
                    {
                      id: virtualNetwork.properties.subnets[0].id
                    }
                  ]
                }
                zones: [
                  '1'
                  '2'
                  '3'
                ]
              }
            }
            """);
    }
}
