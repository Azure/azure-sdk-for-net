# Release History

## 1.4.0 (2024-02-21)

### Features Added

- Added a new property 'virtualMachineId' to the 'GalleryArtifactVersionFullSource'.
- Updated the api-version tag from 'package-2023-10-02' to the newer 'package-2023-07-03'. This is for the latest Gallery RP release (Galleries, CommunityGalleries, etc).

## 1.4.0-beta.1 (2024-01-26)

### Features Added

- Upgraded api-version tag from 'package-2023-09-01' to 'package-2023-10-02'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ce47f9b775ec53750f37def0402ecacf3f1d661b/specification/compute/resource-manager/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.0.

## 1.3.0 (2023-12-29)

### Features Added

- Compute RP to `2023-09-01` (AvailabilitySets, VirtualMachines, VirtualMachineScaleSets, etc)

## 1.2.1 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0 (2023-09-15)

### Features Added

- Compute RP to `2023-03-01` (AvailabilitySets, VirtualMachines, VirtualMachineScaleSets, etc)
  - Added new parameter `DomainNameLabelScope` to VM and VMSS Public IP Dns Settings.
  - Added new parameter `TimeCreated` to VMSS VM properties.
  - Added new parameters `AuxiliaryMode` and `AuxiliarySku` to VM and VMSS Network Configuration Properties.

## 1.2.0-beta.3 (2023-08-14)

### Features Added

- Make `ComputeArmClientMockingExtension`, `ComputeResourceGroupMockingExtension`, `ComputeSubscriptionMockingExtension` public for mocking the extension methods.

## 1.2.0-beta.2 (2023-07-28)

### Features Added

- Disk RP to `2023-01-02`
    - Added new property class `DiskImageFileFormat` to `GrantAccessData` class

## 1.2.0-beta.1 (2023-06-01)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Added new properties `ComputerName`, `OSName`, `OSVersion` and `HyperVGeneration` to `VirtualMachineScaleSetVmInstanceView` class
- Added new value `StandardSsdLrs` to `ImageStorageAccountType`
- Compute RP to `2023-03-01` (AvailabilitySets, VirtualMachines, VirtualMachineScaleSets, etc)
  - Added new method `Reapply` for `VirtualMachineScaleSet` class.
  - Added new method `ListAvailabeSizes` for `DedicatedHost` class.
  - Added new parameter `expand` for `VirtualMachine` List methods.
  - Added new parameter `hibernate` for `VirtualMachineScaleSet` deallocate methods.
  - Added new parameters `PriorityMixPolicy` and `SpotRestorePolicy` for `VirtualMachineScaleSet` update methods.
  - Added new property `BypassPlatformSafetyChecksOnUserSchedule` for `VirtualMachine` class.
  - Added new property `SecurityPostureReference` to `VirtualMachineScaleSet` class.
  - Added new properties `OutputBlobManagedIdentity` and `ErrorBlobManagedIdentity` to `RunCommand` class.
  - Added new properties `RestorePointEncryption`, `SourceDiskRestorePoint` , `HyperVGeneration` and `WriteAcceleratorEnabled` for `RestorePoint` class.

### Breaking Changes

- Class `VirtualMachineScaleSetNetworkConfiguration` and `VirtualMachineScaleSetIPConfiguration` no longer have the property `Id`

### Other Changes

- Upgraded dependent `Azure.Core` to 1.32.0.
- Upgraded dependent `Azure.ResourceManager` to 1.6.0.

## 1.1.0 (2023-02-16)

### Features Added

Bumps the api-version

- Compute RP to `2022-11-01` (AvailabilitySets, VirtualMachines, VirtualMachineScaleSets, etc)
- Disk RP to `2022-07-02` (ManagedDisks, Snapshots, etc)
- Gallery RP to `2022-03-03` (Galleries, CommunityGalleries, etc)
- CloudService RP to `2022-09-04` (CloudServices, etc)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.1 (2022-11-29)

### Bugs Fixed

- Fixes [a bug](https://github.com/Azure/azure-sdk-for-net/issues/32599) that exceptions are thrown during serialization when constructor `VirtualMachineScaleSetExtensionData(string name)` is called

## 1.0.0 (2022-07-11)

This release is the first stable release of the Compute Management client library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Compute` / `VirtualMachine` prefix to all single / simple model names.
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
- Correct inherits
  - Base type of `VirtualMachineScaleSetVmExtensionData` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `GalleryApplicationPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `GalleryImagePatch` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `GalleryPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `GalleryPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Type `GalleryUpdateResourceData` was removed.
  - Base type of `VirtualMachineScaleSetExtensionPatch ` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `VirtualMachineScaleSetVmExtensionPatch  ` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Type `ApiError` renamed to `ComputeApiError`.
  - Type `ApiErrorBase` renamed to `ComputeApiErrorBase`.
  - Type `DeleteOption` renamed to `ComputeDeleteOption`.
  - Type `UsageName` renamed to `ComputeUsageName`.
  - Type `UsageUnit` renamed to `ComputeUsageUnit`.
  - Type `UserArtifactManage` renamed to `UserArtifactManagement`.
- Method `CloudServiceCollection.CreateOrUpdate` and `CloudServiceCollection.CreateOrUpdateAsync` now required the parameter `data`.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.9 (2022-06-13)

### Breaking Changes

- Rename plenty of classes and property names according to the architecture board's review.

### Other Changes

- Updated API version of compute RP to `2022-03-01`.
- Updated API version of disk RP to `2022-03-02`.
- Updated API version of gallery RP to `2022-01-03`.

## 1.0.0-beta.8 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.7 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- Removed `GetIfExists` methods from all the resource classes.
- All properties of the type `object` were changed to `BinaryData`.

## 1.0.0-beta.6 (2022-01-29)

### Breaking Changes

- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- Removed GetAllAsGenericResources in [Resource]Collections.
- Added Resource constructor to use ArmClient for ClientContext information and removed previous constructors with parameters.
- Couple of renamings.

## 1.0.0-beta.5 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class
- Class `OSFamilyCollection` and `OSVersionCollection` now implement the `IEnumerable<T>` and `IAsyncEnumerable<T>`
- Class `VirtualMachineExtensionImageCollection` now implements the `IEnumerable<T>`

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`
- Constructor of `OSFamilyCollection`, `OSVersionCollection` no longer accept `location` as their first parameter
- Constructor of `VirtualMachineExtensionImageCollection` no longer accepts `location` and `publisher` as its first two parameters
- Method `GetOSFamilies` and `GetOSVersions` in `SubscriptionExtensions` now accept an extra parameter `location`
- Method `GetVirtualMachineExtensionImages` in `SubscriptionExtensions` now accepts two extra parameters `location` and `publisher`

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

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.Compute` to `Azure.ResourceManager.Compute`

### Breaking Changes

New design of track 2 initial commit.

Example: Create a VM:

Before upgrade:

You need the following using statements:
```C#
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Models;
using IPVersion = Microsoft.Azure.Management.Network.Models.IPVersion;
using ResourceManagementClient = Microsoft.Azure.Management.ResourceManager.ResourceManagementClient;
using Sku = Microsoft.Azure.Management.Compute.Models.Sku;
using SubResource = Microsoft.Azure.Management.Compute.Models.SubResource;
```

The code looks like:
```C#
var credentials = new TokenCredentials("YOUR ACCESS TOKEN");;

var resourceClient = new ResourceManagementClient(credentials);
var networkClient = new NetworkManagementClient(credentials);
var computeClient = new ComputeManagementClient(credentials);

resourceClient.SubscriptionId = subscriptionId;
networkClient.SubscriptionId = subscriptionId;
computeClient.SubscriptionId = subscriptionId;

var location = "westus";
// Create Resource Group
await resourceClient.ResourceGroups.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

// Create Availability Set
var availabilitySet = new AvailabilitySet(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Sku("Aligned"),
};

availabilitySet = await computeClient.AvailabilitySets
    .CreateOrUpdateAsync(resourceGroupName, vmName + "_aSet", availabilitySet);

// Create IP Address
var ipAddress = new PublicIPAddress()
{
    PublicIPAddressVersion = IPVersion.IPv4,
    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
    Location = location,
};

ipAddress = await networkClient
    .PublicIPAddresses.BeginCreateOrUpdateAsync(resourceGroupName, vmName + "_ip", ipAddress);

// Create VNet
var vnet = new VirtualNetwork()
{
    Location = location,
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
    .BeginCreateOrUpdateAsync(resourceGroupName, vmName + "_vent", vnet);

// Create Network interface
var nic = new NetworkInterface()
{
    Location = location,
    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
    {
        new NetworkInterfaceIPConfiguration()
        {
            Name = "Primary",
            Primary = true,
            Subnet = new Subnet() { Id = vnet.Subnets.First().Id },
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            PublicIPAddress = new PublicIPAddress() { Id = ipAddress.Id }
        }
    }
};

nic = await networkClient.NetworkInterfaces
    .BeginCreateOrUpdateAsync(resourceGroupName, vmName + "_nic", nic);

var vm = new VirtualMachine(location)
{
    NetworkProfile = new NetworkProfile { NetworkInterfaces = new[] { new NetworkInterfaceReference() { Id = nic.Id } } },
    AvailabilitySet = new SubResource { Id = availabilitySet.Id },
    OsProfile = new OSProfile
    {
        ComputerName = "testVM",
        AdminUsername = "azureUser",
        AdminPassword = "azure12345QWE!",
        LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVMAgent = true }
    },
    StorageProfile = new StorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Offer = "UbuntuServer",
            Publisher = "Canonical",
            Sku = "18.04-LTS",
            Version = "latest"
        },
        DataDisks = new List<DataDisk>()
    },
    HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1ms },
};

await computeClient.VirtualMachines.BeginCreateOrUpdateAsync(resourceGroupName, vmName, vm);

```

After upgrade:

You need the following using statements:
```C# Snippet:Changelog_NewUsing
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using System;
using System.Linq;
```

The code looks like:
```C# Snippet:Changelog_New
ArmClient armClient = new ArmClient(new DefaultAzureCredential());

AzureLocation location = AzureLocation.WestUS;
// Create ResourceGroupResource
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ArmOperation<ResourceGroupResource> rgOperation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, "myResourceGroup", new ResourceGroupData(location));
ResourceGroupResource resourceGroup = rgOperation.Value;

// Create AvailabilitySet
AvailabilitySetData availabilitySetData = new AvailabilitySetData(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new ComputeSku() { Name = "Aligned" }
};
ArmOperation<AvailabilitySetResource> asetOperation = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync(WaitUntil.Completed, "myAvailabilitySet", availabilitySetData);
AvailabilitySetResource availabilitySet = asetOperation.Value;

// Create VNet
VirtualNetworkData vnetData = new VirtualNetworkData()
{
    Location = location,
    Subnets =
    {
        new SubnetData()
        {
            Name = "mySubnet",
            AddressPrefix = "10.0.0.0/24",
        }
    },
    AddressPrefixes =
    {
        "10.0.0.0/16"
    }
};
ArmOperation<VirtualNetworkResource> vnetOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, "myVirtualNetwork", vnetData);
VirtualNetworkResource vnet = vnetOperation.Value;

// Create Network interface
NetworkInterfaceData nicData = new NetworkInterfaceData()
{
    Location = location,
    IPConfigurations =
    {
        new NetworkInterfaceIPConfigurationData()
        {
            Name = "Primary",
            Primary = true,
            Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
            PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
        }
    }
};
ArmOperation<NetworkInterfaceResource> nicOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, "myNetworkInterface", nicData);
NetworkInterfaceResource nic = nicOperation.Value;

VirtualMachineData vmData = new VirtualMachineData(location)
{
    AvailabilitySet = new WritableSubResource() { Id = availabilitySet.Id },
    NetworkProfile = new VirtualMachineNetworkProfile
    {
        NetworkInterfaces = { new VirtualMachineNetworkInterfaceReference() { Id = nic.Id } }
    },
    OSProfile = new VirtualMachineOSProfile()
    {
        ComputerName = "testVM",
        AdminUsername = "username",
        AdminPassword = "(YourPassword)",
        LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVmAgent = true }
    },
    StorageProfile = new VirtualMachineStorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Offer = "UbuntuServer",
            Publisher = "Canonical",
            Sku = "18.04-LTS",
            Version = "latest"
        }
    },
    HardwareProfile = new VirtualMachineHardwareProfile() { VmSize = VirtualMachineSizeType.StandardB1Ms },
};
ArmOperation<VirtualMachineResource> vmOperation = await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync(WaitUntil.Completed, "myVirtualMachine", vmData);
VirtualMachineResource vm = vmOperation.Value;
```

#### Object Model Changes

Example: Create a Virtual Machine Extension

Before upgrade:
```C#
var vmExtension = new VirtualMachineExtension
            {
                Location = "westus",
                Tags = new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Publisher = "Microsoft.Compute",
                VirtualMachineExtensionType = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                ForceUpdateTag = "RerunExtension",
                Settings = "{}",
                ProtectedSettings = "{}"
            };
            typeof(Resource).GetRuntimeProperty("Name").SetValue(vmExtension, "vmext01");
            typeof(Resource).GetRuntimeProperty("Type").SetValue(vmExtension, "Microsoft.Compute/virtualMachines/extensions");
```

After upgrade:
```C# Snippet:Changelog_CreateVMExtension
var vmExtension = new VirtualMachineExtensionData(AzureLocation.WestUS)
{
    Tags = { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
    Publisher = "Microsoft.Compute",
    ExtensionType = "VMAccessAgent",
    TypeHandlerVersion = "2.0",
    AutoUpgradeMinorVersion = true,
    ForceUpdateTag = "RerunExtension",
    Settings = BinaryData.FromObjectAsJson(new { }),
    ProtectedSettings = BinaryData.FromObjectAsJson(new { })
};
```
