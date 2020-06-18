# Release History

## 1.0.0-preview.1

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

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
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;

var networkClient = new NetworkManagementClient(subscriptionId, new DefaultAzureCredential());
var virtualNetworksOperations = networkClient.VirtualNetworks;

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

var response = await virtualNetworksOperations.StartCreateOrUpdateAsync(resourceGroup, vmName + "_vent", vnet);
vnet = await response.WaitForCompletionAsync();
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
