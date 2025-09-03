# Azure Provisioning Network client library for .NET

Azure.Provisioning.Network simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Network
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Virtual Network with two Subnets

This template allows you to create a Virtual Network with two subnets.

```C# Snippet:VNetTwoSubnets
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
```

### Virtual Network NAT

This template deploys a NAT gateway and virtual network with a single subnet and public IP resource for the NAT gateway.

```C# Snippet:NatGatewayVNet
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
```

### Create a Network Security Group

This template creates a subnet, a Network Security Group and attaches it to the subnet in the VNET.

```C# Snippet:SecurityGroupCreate
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
```

### Enable NSG Flow Logs

This template deploys an NSG flow logs resource inside the Network Watcher resource group.

```C# Snippet:NetworkWatcherFlowLogsCreate
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
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/