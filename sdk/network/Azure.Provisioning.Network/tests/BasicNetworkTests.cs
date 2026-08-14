// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Network.Tests;

public class BasicNetworkTests
{
    internal static Trycep CreateVNetTwoSubnetsTest()
    {
        return new Trycep().Define(
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
                        new SubnetResource("subnet1")
                        {
                            Name = subnet1Name,
                            AddressPrefix = subnet1Prefix
                        },
                        new SubnetResource("subnet2")
                        {
                            Name = subnet2Name,
                            AddressPrefix = subnet2Prefix
                        }
                    ]
                };
                infra.Add(vnet);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/vnet-two-subnets/main.bicep")]
    public async Task VNetTwoSubnets()
    {
        await using Trycep test = CreateVNetTwoSubnetsTest();
        test.Compare(
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
            """);
    }

    internal static Trycep CreateNatGatewayVNetTest()
    {
        return new Trycep().Define(
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
                        new SubnetResource("subnet")
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
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/nat-gateway-vnet/main.bicep")]
    public async Task NatGatewayVNet()
    {
        await using Trycep test = CreateNatGatewayVNetTest();
        test.Compare(
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
            """);
    }

    internal static Trycep CreateNetworkWatcherFlowLogsCreateTest()
    {
        return new Trycep().Define(
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
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/networkwatcher-flowLogs-create/main.bicep")]
    public async Task NetworkWatcherFlowLogsCreate()
    {
        await using Trycep test = CreateNetworkWatcherFlowLogsCreateTest();
        test.Compare(
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
            """);
    }

    internal static Trycep CreateSecurityGroupCreateTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SecurityGroupCreate
                Infrastructure infra = new();

                ProvisioningParameter addressPrefix = new(nameof(addressPrefix), typeof(string))
                {
                    Description = "Address prefix",
                    Value = "10.0.0.0/16"
                };
                infra.Add(addressPrefix);

                ProvisioningParameter subnetPrefix = new(nameof(subnetPrefix), typeof(string))
                {
                    Description = "Subnet-1 Prefix",
                    Value = "10.0.0.0/24"
                };
                infra.Add(subnetPrefix);

                ProvisioningParameter location = new(nameof(location), typeof(string))
                {
                    Description = "Location for all resources.",
                    Value = BicepFunction.GetResourceGroup().Location
                };
                infra.Add(location);

                ProvisioningVariable networkSecurityGroupName = new(nameof(networkSecurityGroupName), typeof(string))
                {
                    Value = "networkSecurityGroup1"
                };
                infra.Add(networkSecurityGroupName);

                ProvisioningVariable virtualNetworkName = new(nameof(virtualNetworkName), typeof(string))
                {
                    Value = "virtualNetwork1"
                };
                infra.Add(virtualNetworkName);

                ProvisioningVariable subnetName = new(nameof(subnetName), typeof(string))
                {
                    Value = "subnet"
                };
                infra.Add(subnetName);

                NetworkSecurityGroup networkSecurityGroup = new(nameof(networkSecurityGroup), NetworkSecurityGroup.ResourceVersions.V2020_05_01)
                {
                    Name = networkSecurityGroupName,
                    Location = location,
                    SecurityRules =
                    [
                        new SecurityRule("sr")
                        {
                            Name = "first_rule",
                            Description = "This is the first rule",
                            Protocol = SecurityRuleProtocol.Tcp,
                            SourcePortRange = "23-45",
                            DestinationPortRange = "46-56",
                            SourceAddressPrefix = "*",
                            DestinationAddressPrefix = "*",
                            Access = SecurityRuleAccess.Allow,
                            Priority = 123,
                            Direction = SecurityRuleDirection.Inbound
                        }
                    ]
                };
                infra.Add(networkSecurityGroup);

                VirtualNetwork virtualNetwork = new(nameof(virtualNetwork), VirtualNetwork.ResourceVersions.V2020_05_01)
                {
                    Name = virtualNetworkName,
                    Location = location,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes =
                        [
                            addressPrefix
                        ]
                    },
                    Subnets =
                    [
                        new SubnetResource("subnet")
                        {
                            Name = subnetName,
                            AddressPrefix = subnetPrefix,
                            NetworkSecurityGroup = new("nsg")
                            {
                                Id = networkSecurityGroup.Id
                            }
                        }
                    ]
                };
                infra.Add(virtualNetwork);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/2db70d7aed6588333dc10f26bf19618995151018/quickstarts/microsoft.network/security-group-create/azuredeploy.json#L42")]
    public async Task SecurityGroupCreate()
    {
        await using Trycep test = CreateSecurityGroupCreateTest();
        test.Compare(
            """
            @description('Address prefix')
            param addressPrefix string = '10.0.0.0/16'

            @description('Subnet-1 Prefix')
            param subnetPrefix string = '10.0.0.0/24'

            @description('Location for all resources.')
            param location string = resourceGroup().location

            var networkSecurityGroupName = 'networkSecurityGroup1'

            var virtualNetworkName = 'virtualNetwork1'

            var subnetName = 'subnet'

            resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2020-05-01' = {
              name: networkSecurityGroupName
              location: location
              properties: {
                securityRules: [
                  {
                    name: 'first_rule'
                    properties: {
                      access: 'Allow'
                      description: 'This is the first rule'
                      destinationAddressPrefix: '*'
                      destinationPortRange: '46-56'
                      direction: 'Inbound'
                      priority: 123
                      protocol: 'Tcp'
                      sourceAddressPrefix: '*'
                      sourcePortRange: '23-45'
                    }
                  }
                ]
              }
            }

            resource virtualNetwork 'Microsoft.Network/virtualNetworks@2020-05-01' = {
              name: virtualNetworkName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    addressPrefix
                  ]
                }
                subnets: [
                  {
                    name: subnetName
                    properties: {
                      addressPrefix: subnetPrefix
                      networkSecurityGroup: {
                        id: networkSecurityGroup.id
                      }
                    }
                  }
                ]
              }
              location: location
            }
            """);
    }

    internal static Trycep CreateBastionHubSpokeTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter vNetHubName = new(nameof(vNetHubName), typeof(string))
                {
                    Description = "The name of the Hub vNet",
                    Value = "vnet-hub"
                };
                infra.Add(vNetHubName);

                ProvisioningParameter vNetSpokeName = new(nameof(vNetSpokeName), typeof(string))
                {
                    Description = "The name of the Spoke vNet",
                    Value = "vnet-spoke"
                };
                infra.Add(vNetSpokeName);

                ProvisioningParameter bastionHostName = new(nameof(bastionHostName), typeof(string))
                {
                    Description = "The name of the Azure Bastion host",
                    Value = "bastion1"
                };
                infra.Add(bastionHostName);

                VirtualNetwork vNetHub = new(nameof(vNetHub))
                {
                    Name = vNetHubName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes = ["10.0.0.0/16"]
                    },
                    Subnets =
                    [
                        new SubnetResource("bastionSubnet")
                        {
                            Name = "AzureBastionSubnet",
                            AddressPrefix = "10.0.0.0/26"
                        }
                    ]
                };
                infra.Add(vNetHub);

                VirtualNetwork vNetSpoke = new(nameof(vNetSpoke))
                {
                    Name = vNetSpokeName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes = ["10.1.0.0/16"]
                    },
                    Subnets =
                    [
                        new SubnetResource("spokeSubnet")
                        {
                            Name = "Subnet-1",
                            AddressPrefix = "10.1.0.0/24"
                        }
                    ]
                };
                infra.Add(vNetSpoke);

                VirtualNetworkPeering hubToSpoke = new(nameof(hubToSpoke))
                {
                    Name = BicepFunction.Interpolate($"peering-to-{vNetSpokeName}"),
                    Parent = vNetHub,
                    AllowVirtualNetworkAccess = true,
                    AllowForwardedTraffic = false,
                    AllowGatewayTransit = false,
                    UseRemoteGateways = false,
                    RemoteVirtualNetworkId = vNetSpoke.Id
                };
                infra.Add(hubToSpoke);

                VirtualNetworkPeering spokeToHub = new(nameof(spokeToHub))
                {
                    Name = BicepFunction.Interpolate($"peering-to-{vNetHubName}"),
                    Parent = vNetSpoke,
                    AllowVirtualNetworkAccess = true,
                    AllowForwardedTraffic = false,
                    AllowGatewayTransit = false,
                    UseRemoteGateways = false,
                    RemoteVirtualNetworkId = vNetHub.Id
                };
                infra.Add(spokeToHub);

                PublicIPAddress bastionPublicIP = new(nameof(bastionPublicIP))
                {
                    Name = BicepFunction.Interpolate($"{bastionHostName}-pip"),
                    PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                    Sku = new PublicIPAddressSku()
                    {
                        Name = PublicIPAddressSkuName.Standard
                    }
                };
                infra.Add(bastionPublicIP);

                BastionHost bastionHost = new(nameof(bastionHost))
                {
                    Name = bastionHostName,
                    IPConfigurations =
                    [
                        new BastionHostIPConfiguration()
                        {
                            Name = "ipconfig1",
                            PublicIPAddressId = bastionPublicIP.Id,
                            PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic
                        }
                    ]
                };
                infra.Add(bastionHost);

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/bastion-hub-spoke-vnet/main.bicep")]
    public async Task BastionHubSpoke()
    {
        await using Trycep test = CreateBastionHubSpokeTest();
        test.Compare(
            """
            @description('The name of the Hub vNet')
            param vNetHubName string = 'vnet-hub'

            @description('The name of the Spoke vNet')
            param vNetSpokeName string = 'vnet-spoke'

            @description('The name of the Azure Bastion host')
            param bastionHostName string = 'bastion1'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource vNetHub 'Microsoft.Network/virtualNetworks@2025-05-01' = {
              name: vNetHubName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    '10.0.0.0/16'
                  ]
                }
                subnets: [
                  {
                    name: 'AzureBastionSubnet'
                    properties: {
                      addressPrefix: '10.0.0.0/26'
                    }
                  }
                ]
              }
              location: location
            }

            resource vNetSpoke 'Microsoft.Network/virtualNetworks@2025-05-01' = {
              name: vNetSpokeName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    '10.1.0.0/16'
                  ]
                }
                subnets: [
                  {
                    name: 'Subnet-1'
                    properties: {
                      addressPrefix: '10.1.0.0/24'
                    }
                  }
                ]
              }
              location: location
            }

            resource hubToSpoke 'Microsoft.Network/virtualNetworks/virtualNetworkPeerings@2025-05-01' = {
              name: 'peering-to-${vNetSpokeName}'
              properties: {
                allowForwardedTraffic: false
                allowGatewayTransit: false
                allowVirtualNetworkAccess: true
                remoteVirtualNetwork: {
                  id: vNetSpoke.id
                }
                useRemoteGateways: false
              }
              parent: vNetHub
            }

            resource spokeToHub 'Microsoft.Network/virtualNetworks/virtualNetworkPeerings@2025-05-01' = {
              name: 'peering-to-${vNetHubName}'
              properties: {
                allowForwardedTraffic: false
                allowGatewayTransit: false
                allowVirtualNetworkAccess: true
                remoteVirtualNetwork: {
                  id: vNetHub.id
                }
                useRemoteGateways: false
              }
              parent: vNetSpoke
            }

            resource bastionPublicIP 'Microsoft.Network/publicIPAddresses@2025-05-01' = {
              name: '${bastionHostName}-pip'
              location: location
              properties: {
                publicIPAllocationMethod: 'Static'
              }
              sku: {
                name: 'Standard'
              }
            }

            resource bastionHost 'Microsoft.Network/bastionHosts@2025-05-01' = {
              name: bastionHostName
              properties: {
                ipConfigurations: [
                  {
                    properties: {
                      publicIPAddress: {
                        id: bastionPublicIP.id
                      }
                      privateIPAllocationMethod: 'Dynamic'
                    }
                    name: 'ipconfig1'
                  }
                ]
              }
              location: location
            }
            """);
    }

    internal static Trycep CreateFirewallWithPolicyTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter virtualNetworkName = new(nameof(virtualNetworkName), typeof(string))
                {
                    Description = "Virtual network name",
                    Value = BicepFunction.Interpolate($"vnet{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(virtualNetworkName);

                ProvisioningParameter firewallName = new(nameof(firewallName), typeof(string))
                {
                    Description = "Azure Firewall name",
                    Value = BicepFunction.Interpolate($"fw{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}")
                };
                infra.Add(firewallName);

                ProvisioningVariable firewallPolicyName = new(nameof(firewallPolicyName), typeof(string))
                {
                    Value = BicepFunction.Interpolate($"{firewallName}-firewallPolicy")
                };
                infra.Add(firewallPolicyName);

                IPGroup workloadIpGroup = new(nameof(workloadIpGroup))
                {
                    Name = BicepFunction.Interpolate($"workload-ipgroup-{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}"),
                    IPAddresses = ["10.20.0.0/24", "10.30.0.0/24"]
                };
                infra.Add(workloadIpGroup);

                IPGroup infraIpGroup = new(nameof(infraIpGroup))
                {
                    Name = BicepFunction.Interpolate($"infra-ipgroup-{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}"),
                    IPAddresses = ["10.40.0.0/24", "10.50.0.0/24"]
                };
                infra.Add(infraIpGroup);

                VirtualNetwork vnet = new(nameof(vnet))
                {
                    Name = virtualNetworkName,
                    AddressSpace = new VirtualNetworkAddressSpace()
                    {
                        AddressPrefixes = ["10.10.0.0/24"]
                    },
                    Subnets =
                    [
                        new SubnetResource("firewallSubnet")
                        {
                            Name = "AzureFirewallSubnet",
                            AddressPrefix = "10.10.0.0/25"
                        }
                    ]
                };
                infra.Add(vnet);

                PublicIPAddress publicIP = new(nameof(publicIP))
                {
                    Name = "publicIP1",
                    PublicIPAllocationMethod = NetworkIPAllocationMethod.Static,
                    PublicIPAddressVersion = NetworkIPVersion.IPv4,
                    Sku = new PublicIPAddressSku()
                    {
                        Name = PublicIPAddressSkuName.Standard
                    }
                };
                infra.Add(publicIP);

                FirewallPolicy firewallPolicy = new(nameof(firewallPolicy))
                {
                    Name = firewallPolicyName,
                    ThreatIntelMode = AzureFirewallThreatIntelMode.Alert
                };
                infra.Add(firewallPolicy);

                AzureFirewall firewall = new(nameof(firewall))
                {
                    Name = firewallName,
                    FirewallPolicyId = firewallPolicy.Id,
                    IPConfigurations =
                    [
                        new AzureFirewallIPConfiguration()
                        {
                            Name = "IpConf0",
                            PublicIPAddressId = publicIP.Id
                        }
                    ]
                };
                infra.Add(firewall);

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/azurefirewall-create-with-firewallpolicy-apprule-netrule-ipgroups/main.bicep")]
    public async Task FirewallWithPolicy()
    {
        await using Trycep test = CreateFirewallWithPolicyTest();
        test.Compare(
            """
            @description('Virtual network name')
            param virtualNetworkName string = 'vnet${uniqueString(resourceGroup().id)}'

            @description('Azure Firewall name')
            param firewallName string = 'fw${uniqueString(resourceGroup().id)}'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            var firewallPolicyName = '${firewallName}-firewallPolicy'

            resource workloadIpGroup 'Microsoft.Network/ipGroups@2025-05-01' = {
              name: 'workload-ipgroup-${uniqueString(resourceGroup().id)}'
              properties: {
                ipAddresses: [
                  '10.20.0.0/24'
                  '10.30.0.0/24'
                ]
              }
              location: location
            }

            resource infraIpGroup 'Microsoft.Network/ipGroups@2025-05-01' = {
              name: 'infra-ipgroup-${uniqueString(resourceGroup().id)}'
              properties: {
                ipAddresses: [
                  '10.40.0.0/24'
                  '10.50.0.0/24'
                ]
              }
              location: location
            }

            resource vnet 'Microsoft.Network/virtualNetworks@2025-05-01' = {
              name: virtualNetworkName
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    '10.10.0.0/24'
                  ]
                }
                subnets: [
                  {
                    name: 'AzureFirewallSubnet'
                    properties: {
                      addressPrefix: '10.10.0.0/25'
                    }
                  }
                ]
              }
              location: location
            }

            resource publicIP 'Microsoft.Network/publicIPAddresses@2025-05-01' = {
              name: 'publicIP1'
              location: location
              properties: {
                publicIPAddressVersion: 'IPv4'
                publicIPAllocationMethod: 'Static'
              }
              sku: {
                name: 'Standard'
              }
            }

            resource firewallPolicy 'Microsoft.Network/firewallPolicies@2025-05-01' = {
              name: firewallPolicyName
              location: location
              properties: {
                threatIntelMode: 'Alert'
              }
            }

            resource firewall 'Microsoft.Network/azureFirewalls@2025-05-01' = {
              name: firewallName
              properties: {
                firewallPolicy: {
                  id: firewallPolicy.id
                }
                ipConfigurations: [
                  {
                    properties: {
                      publicIPAddress: {
                        id: publicIP.id
                      }
                    }
                    name: 'IpConf0'
                  }
                ]
              }
              location: location
            }
            """);
    }
}
