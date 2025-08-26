// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class BasicNetworkTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/vnet-two-subnets/main.bicep")]
    public async Task VNetTwoSubnets()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                #region Snippet:VNetTwoSubnets
                Infrastructure infra = new();
                ProvisioningParameter vnetName = new(nameof(vnetName), typeof(string))
                {
                    Description = "VNet name",
                    Value = "VNet1"
                };
                infra.Add(vnetName);
                ProvisioningParameter vnetAddressPrefix = new(nameof(vnetAddressPrefix), typeof(string))
                {
                    Description = "Address prefix",
                    Value = "10.0.0.0/16"
                };
                infra.Add(vnetAddressPrefix);
                ProvisioningParameter subnet1Prefix = new(nameof(subnet1Prefix), typeof(string))
                {
                    Description = "Subnet 1 Prefix",
                    Value = "10.0.0.0/24"
                };
                infra.Add(subnet1Prefix);
                ProvisioningParameter subnet1Name = new(nameof(subnet1Name), typeof(string))
                {
                    Description = "Subnet 1 Name",
                    Value = "Subnet1"
                };
                infra.Add(subnet1Name);
                ProvisioningParameter subnet2Prefix = new(nameof(subnet2Prefix), typeof(string))
                {
                    Description = "Subnet 2 Prefix",
                    Value = "10.0.1.0/24"
                };
                infra.Add(subnet2Prefix);
                ProvisioningParameter subnet2Name = new(nameof(subnet2Name), typeof(string))
                {
                    Description = "Subnet 2 Name",
                    Value = "Subnet2"
                };
                infra.Add(subnet2Name);
                VirtualNetwork vnet = new(nameof(vnet), VirtualNetwork.ResourceVersions.V2021_08_01)
                {
                    Name = vnetName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes =
                        [
                            vnetAddressPrefix
                        ]
                    },
                    Subnets =
                    [
                        new Subnet()
                        {
                            Name = subnet1Name,
                            AddressPrefix = subnet1Prefix
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = subnet2Prefix
                        }
                    ]
                };
                infra.Add(vnet);
                #endregion
                return infra;
            })
        .Compare(
            """
            @description('VNet name')
            param vnetName string = 'VNet1'

            @description('Address prefix')
            param vnetAddressPrefix string = '10.0.0.0/16'

            @description('Subnet 1 Prefix')
            param subnet1Prefix string = '10.0.0.0/24'

            @description('Subnet 1 Name')
            param subnet1Name string = 'Subnet1'

            @description('Subnet 2 Prefix')
            param subnet2Prefix string = '10.0.1.0/24'

            @description('Subnet 2 Name')
            param subnet2Name string = 'Subnet2'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource vnet 'Microsoft.Network/virtualNetworks@2021-08-01' = {
              name: vnetName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    vnetAddressPrefix
                  ]
                }
                subnets: [
                  {
                    name: subnet1Name
                    properties: {
                      addressPrefix: subnet1Prefix
                    }
                  }
                  {
                    name: subnet2Name
                    properties: {
                      addressPrefix: subnet2Prefix
                    }
                  }
                ]
              }
              location: location
            }
            """)
        .Lint()
        .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/nat-gateway-vnet/main.bicep")]
    public async Task NatGatewayVNet()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                #region Snippet:NatGatewayVNet
                Infrastructure infra = new();
                ProvisioningParameter vnetName = new(nameof(vnetName), typeof(string))
                {
                    Description = "Name of the virtual network",
                    Value = "myVnet"
                };
                infra.Add(vnetName);
                ProvisioningParameter subnetName = new(nameof(subnetName), typeof(string))
                {
                    Description = "Name of the subnet for virtual network",
                    Value = "mySubnet"
                };
                infra.Add(subnetName);
                ProvisioningParameter vnetAddressSpace = new(nameof(vnetAddressSpace), typeof(string))
                {
                    Description = "Address space for virtual network",
                    Value = "192.168.0.0/16"
                };
                infra.Add(vnetAddressSpace);
                ProvisioningParameter vnetSubnetPrefix = new(nameof(vnetSubnetPrefix), typeof(string))
                {
                    Description = "Subnet prefix for virtual network",
                    Value = "192.168.0.0/24"
                };
                infra.Add(vnetSubnetPrefix);
                ProvisioningParameter natGatewayName = new(nameof(natGatewayName), typeof(string))
                {
                    Description = "Name of the NAT gateway resource",
                    Value = "myNATgateway"
                };
                infra.Add(natGatewayName);
                ProvisioningParameter publicIpDns = new(nameof(publicIpDns), typeof(string))
                {
                    Description = "dns of the public ip address, leave blank for no dns",
                    Value = BicepFunction.Interpolate($"gw-{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(publicIpDns);
                ProvisioningVariable publicIpName = new(nameof(publicIpName), typeof(string))
                {
                    Value = BicepFunction.Interpolate($"{natGatewayName}-ip")
                };
                infra.Add(publicIpName);
                PublicIPAddress publicIp = new(nameof(publicIp), PublicIPAddress.ResourceVersions.V2020_06_01)
                {
                    Name = publicIpName,
                    Sku = new PublicIPAddressSku()
                    {
                        Name = PublicIPAddressSkuName.Standard
                    },
                    PublicIPAddressVersion = NetworkIPVersion.IPv4,
                    PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                    IdleTimeoutInMinutes = 4,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                        DomainNameLabel = publicIpDns
                    },
                };
                infra.Add(publicIp);
                NatGateway natGateway = new(nameof(natGateway), NatGateway.ResourceVersions.V2020_06_01)
                {
                    Name = natGatewayName,
                    SkuName = NatGatewaySkuName.Standard,
                    IdleTimeoutInMinutes = 4,
                    PublicIPAddresses =
                    [
                        new WritableSubResource()
                        {
                            Id = publicIp.Id
                        }
                    ]
                };
                infra.Add(natGateway);

                // Add the missing VirtualNetwork with subnet linked to NAT gateway
                VirtualNetwork vnet = new(nameof(vnet), VirtualNetwork.ResourceVersions.V2020_06_01)
                {
                    Name = vnetName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes =
                        [
                            vnetAddressSpace
                        ]
                    },
                    Subnets =
                    [
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = vnetSubnetPrefix,
                            NatGatewayId = natGateway.Id,
                            PrivateEndpointNetworkPolicy = VirtualNetworkPrivateEndpointNetworkPolicy.Enabled,
                            PrivateLinkServiceNetworkPolicy = VirtualNetworkPrivateLinkServiceNetworkPolicy.Enabled
                        }
                    ],
                    EnableDdosProtection = false,
                    EnableVmProtection = false
                };
                infra.Add(vnet);
                #endregion
                return infra;
            })
        .Compare(
            """
            @description('Name of the virtual network')
            param vnetName string = 'myVnet'

            @description('Name of the subnet for virtual network')
            param subnetName string = 'mySubnet'

            @description('Address space for virtual network')
            param vnetAddressSpace string = '192.168.0.0/16'

            @description('Subnet prefix for virtual network')
            param vnetSubnetPrefix string = '192.168.0.0/24'

            @description('Name of the NAT gateway resource')
            param natGatewayName string = 'myNATgateway'

            @description('dns of the public ip address, leave blank for no dns')
            param publicIpDns string = 'gw-${uniqueString(resourceGroup().id)}'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            var publicIpName = '${natGatewayName}-ip'

            resource publicIp 'Microsoft.Network/publicIPAddresses@2020-06-01' = {
              name: publicIpName
              properties: {
                dnsSettings: {
                  domainNameLabel: publicIpDns
                }
                idleTimeoutInMinutes: 4
                publicIPAddressVersion: 'IPv4'
                publicIPAllocationMethod: 'Static'
              }
              location: location
              sku: {
                name: 'Standard'
              }
            }

            resource natGateway 'Microsoft.Network/natGateways@2020-06-01' = {
              name: natGatewayName
              properties: {
                idleTimeoutInMinutes: 4
                publicIpAddresses: [
                  {
                    id: publicIp.id
                  }
                ]
              }
              location: location
              sku: {
                name: 'Standard'
              }
            }

            resource vnet 'Microsoft.Network/virtualNetworks@2020-06-01' = {
              name: vnetName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    vnetAddressSpace
                  ]
                }
                enableDdosProtection: false
                enableVmProtection: false
                subnets: [
                  {
                    name: subnetName
                    properties: {
                      addressPrefix: vnetSubnetPrefix
                      natGateway: {
                        id: natGateway.id
                      }
                      privateEndpointNetworkPolicies: 'Enabled'
                      privateLinkServiceNetworkPolicies: 'Enabled'
                    }
                  }
                ]
              }
              location: location
            }
            """)
        .Lint()
        .ValidateAsync();
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/networkwatcher-flowLogs-create/main.bicep")]
    public async Task NetworkWatcherFlowLogsCreate()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                #region Snippet:NetworkWatcherFlowLogsCreate
                Infrastructure infra = new();
                ProvisioningParameter location = new(nameof(location), typeof(string))
                {
                    Description = "The location for the resource(s) to be deployed.",
                    Value = BicepFunction.GetResourceGroup().Location
                };
                ProvisioningParameter networkWatcherName = new(nameof(networkWatcherName), typeof(string))
                {
                    Description = "Name of the Network Watcher attached to your subscription. Format: NetworkWatcher_<region_name>",
                    Value = BicepFunction.Interpolate($"NetworkWatcher_{location}")
                };
                infra.Add(networkWatcherName);
                ProvisioningParameter flowLogName = new(nameof(flowLogName), typeof(string))
                {
                    Description = "Name of your Flow log resource",
                    Value = "FlowLog1"
                };
                infra.Add(flowLogName);
                ProvisioningParameter existingNSG = new(nameof(existingNSG), typeof(string))
                {
                    Description = "Resource ID of the target NSG"
                };
                infra.Add(existingNSG);
                ProvisioningParameter retentionDays = new(nameof(retentionDays), typeof(int))
                {
                    Description = "Retention period in days. Default is zero which stands for permanent retention. Can be any Integer from 0 to 365",
                    Value = 0
                };
                infra.Add(retentionDays);
                ProvisioningParameter flowLogsVersion = new(nameof(flowLogsVersion), typeof(int))
                {
                    Description = "FlowLogs Version. Correct values are 1 or 2 (default)",
                    Value = 2
                };
                infra.Add(flowLogsVersion);
                ProvisioningParameter storageAccountType = new(nameof(storageAccountType), typeof(string))
                {
                    Description = "Storage Account type",
                    Value = "Standard_LRS"
                };
                infra.Add(storageAccountType);
                ProvisioningVariable storageAccountName = new(nameof(storageAccountName), typeof(string))
                {
                    Value = BicepFunction.Interpolate($"flowlogs{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(storageAccountName);

                StorageAccount storageAccount = new(nameof(storageAccount), StorageAccount.ResourceVersions.V2021_09_01)
                {
                    Name = storageAccountName,
                    Sku = new StorageSku()
                    {
                        Name = StorageSkuName.StandardLrs
                    },
                    Kind = StorageKind.StorageV2
                };
                infra.Add(storageAccount);

                NetworkWatcher networkWatcher = new(nameof(networkWatcher), NetworkWatcher.ResourceVersions.V2022_01_01)
                {
                    Name = networkWatcherName
                };
                infra.Add(networkWatcher);

                FlowLog flowLog = new(nameof(flowLog), FlowLog.ResourceVersions.V2022_01_01)
                {
                    Name = BicepFunction.Interpolate($"{networkWatcherName}/{flowLogName}"),
                    Parent = networkWatcher,
                    TargetResourceId = existingNSG,
                    StorageId = storageAccount.Id,
                    Enabled = true,
                    RetentionPolicy = new RetentionPolicyParameters()
                    {
                        Days = retentionDays,
                        Enabled = true
                    },
                    Format = new FlowLogProperties()
                    {
                        FormatType = FlowLogFormatType.Json,
                        Version = flowLogsVersion
                    }
                };
                infra.Add(flowLog);
                #endregion
                return infra;
            })
        .Compare(
            """
            @description('Name of the Network Watcher attached to your subscription. Format: NetworkWatcher_<region_name>')
            param networkWatcherName string = 'NetworkWatcher_${location}'

            @description('Name of your Flow log resource')
            param flowLogName string = 'FlowLog1'

            @description('Resource ID of the target NSG')
            param existingNSG string

            @description('Retention period in days. Default is zero which stands for permanent retention. Can be any Integer from 0 to 365')
            param retentionDays int = 0

            @description('FlowLogs Version. Correct values are 1 or 2 (default)')
            param flowLogsVersion int = 2

            @description('Storage Account type')
            param storageAccountType string = 'Standard_LRS'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            var storageAccountName = 'flowlogs${uniqueString(resourceGroup().id)}'

            resource storageAccount 'Microsoft.Storage/storageAccounts@2021-09-01' = {
              name: storageAccountName
              kind: 'StorageV2'
              location: location
              sku: {
                name: 'Standard_LRS'
              }
            }

            resource networkWatcher 'Microsoft.Network/networkWatchers@2022-01-01' = {
              name: networkWatcherName
              location: location
            }

            resource flowLog 'Microsoft.Network/networkWatchers/flowLogs@2022-01-01' = {
              name: '${networkWatcherName}/${flowLogName}'
              properties: {
                enabled: true
                format: {
                  type: 'JSON'
                  version: flowLogsVersion
                }
                retentionPolicy: {
                  days: retentionDays
                  enabled: true
                }
                storageId: storageAccount.id
                targetResourceId: existingNSG
              }
              location: location
              parent: networkWatcher
            }
            """)
        .Lint()
        .ValidateAsync();
    }
}
