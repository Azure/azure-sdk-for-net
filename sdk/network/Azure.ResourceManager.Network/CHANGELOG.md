# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2022-11-02)

### Features Added

Supported following methods:
- Get available SSL options info
- Get specified SSL predefined policy
- Get all SSL predefined policies

## 1.0.1 (2022-09-13)

### Breaking Changes

Modified the following classes to abstract classes and changed their constructors from public to protected:
- `FirewallPolicyRule`
- `FirewallPolicyRuleCollectionInfo`

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0 (2022-07-11)

This release is the first stable release of the Network Management client library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Network` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.7 (2022-04-08)

### Breaking Changes

- Simplified `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it's only used as input.

### Other Changes

- Upgraded dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.6 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously doesn't have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.5 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResource` in `SubscriptionExtensions`

### Bugs Fixed

- Fixed comments for `FirstPageFunc` of each pageable resource class

## 1.0.0-beta.4 (2021-12-07)

### Breaking Changes

- Unified the identification rule of detecting resources, therefore some resources might become non-resources, and vice versa.

### Bugs Fixed

- Fixed problematic internal parameter invocation from the context `Id` property to the corresponding `RestOperations`.

## 1.0.0-beta.3 (2021-10-28)

### Breaking Changes

- Renamed [Resource]Container to [Resource]Collection and added the IEnumerable<T> and IAsyncEnumerable<T> interfaces to them making it easier to iterate over the list in the simple case.

## 1.0.0-beta.2 (2021-09-14)

### Features Added

- Added ArmClient extension methods to support [start from the middle scenario](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#managing-existing-resources-by-id).

## 1.0.0-beta.1 (2021-08-31)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Network` to `Azure.ResourceManager.Network`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Management Client Changes

Example: Create a VNet:

Before upgrade:

```C#
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

```C# Snippet:Changelog_NewCode
using System;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync("abc");
VirtualNetworkCollection virtualNetworkContainer = resourceGroup.GetVirtualNetworks();

// Create VNet
VirtualNetworkData vnet = new VirtualNetworkData()
{
    Location = "westus",
};
vnet.AddressSpace.AddressPrefixes.Add("10.0.0.0/16");
vnet.Subnets.Add(new SubnetData
{
    Name = "mySubnet",
    AddressPrefix = "10.0.0.0/24",
});

ArmOperation<VirtualNetworkResource> vnetOperation = await virtualNetworkContainer.CreateOrUpdateAsync(WaitUntil.Completed, "_vent", vnet);
VirtualNetworkResource virtualNetwork = vnetOperation.Value;
```

#### Object Model Changes

Example: Create a IpsecPolicy Model

Before upgrade:

```C#
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
    };
```

After upgrade:

```C# Snippet:Changelog_CreateModel
IPsecPolicy policy = new IPsecPolicy(
   300,
   1024,
   IPsecEncryption.Aes128,
   IPsecIntegrity.Sha256,
   IkeEncryption.Aes192,
   IkeIntegrity.Sha1,
   DHGroup.DHGroup2,
   PfsGroup.Pfs1);
```
