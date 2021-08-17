# Release History

## 1.0.0-beta.1 (Unreleased)

### Migration from Previous Version of Azure Management SDK

#### Package Name

The package name has been changed from `Microsoft.Azure.Management.Network` to `Azure.ResourceManager.Network`

#### Management Client Changes

Example: Create a VNet:

Before upgrade:

```csharp
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest;

var credentials = new TokenCredentials("YOUR ACCESS TOKEN");;
var networkClient = new NetworkManagementClient(credentials);
networkClient.SubscriptionId = subscriptionId;

// Create VNet
var vnet = new VirtualNetwork()
{
    Location = "westus",
    AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16" } },
    Subnets = new List<Subnet>()
    {
        new Subnet()
        {
            Name = "mySubnet",
            AddressPrefix = "10.0.0.0/24",
        }
    },
};

vnet = await networkClient.VirtualNetworks
    .BeginCreateOrUpdateAsync(resourceGroup, vmName + "_vent", vnet);
```

After upgrade:

```csharp
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;

var armClient = new ArmClient(new DefaultAzureCredential());
var resourceGroup = (await armClient.DefaultSubscription.GetResourceGroups().GetAsync("abc")).Value;
var virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

// Create VNet
var vnet = new VirtualNetworkData()
{
    Location = "westus",
};
vnet.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
vnet.Subnets.Add(new SubnetData {
    Name = "mySubnet",
    AddressPrefix = "10.0.0.0/24",
});

var virtualNetwork = (await virtualNetworkContainer.CreateOrUpdateAsync("_vent", vnet)).Value;
```

#### Object Model Changes

Example: Create a IpsecPolicy Model

Before upgrade:

```csharp
var policy = new IpsecPolicy()
            {
                SaLifeTimeSeconds = 300,
                SaDataSizeKilobytes = 1024,
                IpsecEncryption = IpsecEncryption.AES128,
                IpsecIntegrity = IpsecIntegrity.SHA256,
                IkeEncryption = IkeEncryption.AES192,
                IkeIntegrity = IkeIntegrity.SHA1,
                DhGroup = DhGroup.DHGroup2,
                PfsGroup = PfsGroup.PFS1,
            }
```

After upgrade:

```csharp
var policy = new IpsecPolicy(
    300,
    1024,
    IpsecEncryption.AES128,
    IpsecIntegrity.SHA256,
    IkeEncryption.AES192,
    IkeIntegrity.SHA1,
    DhGroup.DHGroup2,
    PfsGroup.PFS1)
```
