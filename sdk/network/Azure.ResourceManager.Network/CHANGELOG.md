# Release History

## 1.8.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.7.0 (2024-01-12)

### Features Added

- Upgraded api-version tag from 'package-2023-06' to 'package-2023-09'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2f74f79b243484837a6d7b6dfa78b3e16274d006/specification/network/resource-manager/readme.md
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

## 1.6.0 (2023-11-21)

### Features Added

- Upgraded api-version tag from 'package-2023-05' to 'package-2023-06'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/4b55e2d0e29fb2e829985485c9150f46157c3b80/specification/network/resource-manager/readme.md
- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Bugs Fixed

- Fix an issue that the `DeserializeHopLink` can't handle empty `resourceId`.

### Other Changes

- Upgraded Azure.ResourceManager to 1.9.0.

## 1.6.0-beta.1 (2023-09-25)

### Features Added
- Add support to VMSS features.

## 1.5.0 (2023-09-16)

### Features Added

- Upgraded api-version tag from 'package-2023-04' to 'package-2023-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/0762e82bcccef4a032e29dda5e4c07fd7cc822a6/specification/network/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.34.0 to 1.35.0

## 1.5.0-beta.1 (2023-08-14)

### Features Added

- Make `NetworkArmClientMockingExtension`, `NetworkManagementGroupMockingExtension`, `NetworkResourceGroupMockingExtension`, `NetworkSubscriptionMockingExtension` public for mocking the extension methods.

## 1.4.0 (2023-07-31)

### Features Added

- Upgraded api-version tag from 'package-2023-02' to 'package-2023-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f5cb37608399dd19760b9ef985a707294e32fbda/specification/network/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.33.0 to 1.34.0.
- Upgraded Azure.ResourceManager from 1.6.0 to 1.7.0.
- Obsoleted method 'ArmOperation<VpnProfileResponse> Generatevirtualwanvpnserverconfigurationvpnprofile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualWanResource.
- Obsoleted method 'Task<ArmOperation<VpnProfileResponse>> GeneratevirtualwanvpnserverconfigurationvpnprofileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualWanResource.

## 1.3.0 (2023-06-30)

### Features Added

- Upgraded api-version tag from 'package-2022-09' to 'package-2023-02'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/0b4a0a3f4bfc198df608f373784505e42e248c2c/specification/network/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.31.0 to 1.33.0.
- Upgraded Azure.ResourceManager from 1.5.0 to 1.6.0.
- Obsoleted method 'ArmOperation<PeerRouteList> GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.BgpConnectionResource.
- Obsoleted method 'Task<ArmOperation<PeerRouteList>> GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.BgpConnectionResource.
- Obsoleted method 'ArmOperation<PeerRouteList> GetLearnedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.BgpConnectionResource.
- Obsoleted method 'Task<ArmOperation<PeerRouteList>> GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.BgpConnectionResource.
- Obsoleted method 'ArmOperation GetEffectiveVirtualHubRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted method 'Task<ArmOperation> GetEffectiveVirtualHubRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted method 'ArmOperation GetInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted method 'Task<ArmOperation> GetInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted method 'ArmOperation GetOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted method 'Task<ArmOperation> GetOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken)' in type Azure.ResourceManager.Network.VirtualHubResource.
- Obsoleted property 'ApplicationGatewayCustomErrorStatusCode HttpStatus499' in type Azure.ResourceManager.Network.Models.ApplicationGatewayCustomErrorStatusCode.
- Obsoleted property 'LoadBalancerBackendAddressAdminState Drain' in type Azure.ResourceManager.Network.Models.LoadBalancerBackendAddressAdminState.
- Obsoleted type 'Azure.ResourceManager.Network.Models.PeerRouteList'.

## 1.3.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.2.0 (2023-04-28)

### Features Added

Add new resources:
- `AdminRuleGroupResource`
- `ApplicationGatewayWafDynamicManifestResource`
- `BaseAdminRuleResource`
- `ConnectivityConfigurationResource`
- `ExpressRoutePortAuthorizationResource`
- `ExpressRouteProviderPortResource`
- `ManagementGroupNetworkManagerConnectionResource`
- `NetworkGroupResource`
- `NetworkManagerResource`
- `NetworkManagerConnectionResource`
- `RouteMapResource`
- `RoutingIntentResource`
- `ScopeConnectionResource`
- `SecurityAdminConfigurationResource`
- `PolicySignaturesOverridesForIdpsResource`
- `NetworkGroupStaticMemberResource`
- `NetworkManagerConnectionResource`
- `CloudServiceSwapResource`
- `VpnServerConfigurationPolicyResource`

### Breaking Changes

- Method `NetworkExtensions.GetApplicationGatewayAvailableWafRuleSetsAsyncAsync` and `NetworkExtensions.GetApplicationGatewayAvailableWafRuleSetsAsync` were deprecated because it does not follow the guidelines of Azure SDKs. Please use `NetworkExtensions.GetAppGatewayAvailableWafRuleSetsAsync` and `NetworkExtensions.GetAppGatewayAvailableWafRuleSets` instead.

### Bugs Fixed

- Fixed issue https://github.com/Azure/azure-sdk-for-net/issues/34094. Please use `EffectiveNetworkSecurityGroup.TagToIPAddresses` instead of `EffectiveNetworkSecurityGroup.TagMap`.

### Other Changes

- Upgraded API version to `2022-09-01`.
- Upgraded dependent `Azure.Core` to `1.31.0`.

## 1.1.1 (2023-02-13)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

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
```C# Snippet:Changelog_NewCode_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

```C# Snippet:Changelog_NewCode
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
