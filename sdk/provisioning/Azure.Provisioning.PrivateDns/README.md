# Azure Provisioning PrivateDns client library for .NET

Azure.Provisioning.PrivateDns simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.PrivateDns --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Basic Private Azure DNS Zone

This is a starter template that shows how to create a private Azure DNS zone and link it to a Virtual Network.

```C# Snippet:PrivateDnsZoneBasic
Infrastructure infra = new();
ProvisioningParameter privateDnsZoneName = new(nameof(privateDnsZoneName), typeof(string))
    {
        Description = "Private DNS zone name"
    };
infra.Add(privateDnsZoneName);
ProvisioningParameter vmRegistration = new(nameof(vmRegistration), typeof(bool))
    {
        Description = "Enable automatic VM DNS registration in the zone",
        Value = true
    };
infra.Add(vmRegistration);
ProvisioningParameter vnetName = new(nameof(vnetName), typeof(string))
    {
        Description = "VNet name",
        Value = "VNet"
    };
infra.Add(vnetName);
ProvisioningParameter vnetAddressPrefix = new(nameof(vnetAddressPrefix), typeof(string))
    {
        Description = "VNet Address prefix",
        Value = "10.0.0.0/16"
    };
infra.Add(vnetAddressPrefix);
ProvisioningParameter subnetPrefix = new(nameof(subnetPrefix), typeof(string))
    {
        Description = "Subnet Prefix",
        Value = "10.0.0.0/24"
    };
infra.Add(subnetPrefix);
ProvisioningParameter subnetName = new(nameof(subnetName), typeof(string))
    {
        Description = "Subnet Name",
        Value = "App"
    };
infra.Add(subnetName);
VirtualNetwork vnet =
    new(nameof(vnet), VirtualNetwork.ResourceVersions.V2021_03_01)
    {
        Name = vnetName,
        AddressSpace = new()
        {
            AddressPrefixes = { vnetAddressPrefix }
        },
        Subnets =
        {
            new SubnetResource("subnet")
            {
                Name = subnetName,
                AddressPrefix = subnetPrefix
            }
        }
    };
infra.Add(vnet);
PrivateDnsZone privateDnsZone =
    new(nameof(privateDnsZone), PrivateDnsZone.ResourceVersions.V2020_06_01)
    {
        Name = privateDnsZoneName,
        Location = new AzureLocation("global")
    };
infra.Add(privateDnsZone);
VirtualNetworkLink privateDnsZoneLink =
    new(nameof(privateDnsZoneLink), VirtualNetworkLink.ResourceVersions.V2020_06_01)
    {
        Parent = privateDnsZone,
        Name = BicepFunction.Interpolate($"{vnet.Name.ToBicepExpression()}-link"),
        Location = new AzureLocation("global"),
        RegistrationEnabled = vmRegistration,
        VirtualNetworkId = vnet.Id
    };
infra.Add(privateDnsZoneLink);
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
