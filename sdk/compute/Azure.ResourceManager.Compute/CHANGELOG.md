# Release History

## 1.0.0-beta.9 (Unreleased)

### Features Added

### Breaking Changes

- Rename plenty of classes and property names.

### Bugs Fixed

### Other Changes

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

### Breaking Changes

Guidance to migrate from Previous Version of Azure Management SDK

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.Compute` to `Azure.ResourceManager.Compute`

#### Management Client Changes

Example: Create a VM:

Before upgrade:
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
```C# Snippet:Changelog_New
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using System;
using System.Linq;

var armClient = new ArmClient(new DefaultAzureCredential());

var location = AzureLocation.WestUS;
// Create ResourceGroupResource
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ArmOperation<ResourceGroupResource> rgOperation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, "myResourceGroup", new ResourceGroupData(location));
ResourceGroupResource resourceGroup = rgOperation.Value;

// Create AvailabilitySet
var availabilitySetData = new AvailabilitySetData(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new ComputeSku() { Name = "Aligned" }
};
ArmOperation<AvailabilitySetResource> asetOperation = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync(WaitUntil.Completed, "myAvailabilitySet", availabilitySetData);
AvailabilitySetResource availabilitySet = asetOperation.Value;

// Create VNet
var vnetData = new VirtualNetworkData()
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
};
vnetData.AddressPrefixes.Add("10.0.0.0/16");
ArmOperation<VirtualNetworkResource> vnetOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, "myVirtualNetwork", vnetData);
VirtualNetworkResource vnet = vnetOperation.Value;

// Create Network interface
var nicData = new NetworkInterfaceData()
{
    Location = location,
    IPConfigurations =
    {
        new NetworkInterfaceIPConfigurationData()
        {
            Name = "Primary",
            Primary = true,
            Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
        }
    }
};
ArmOperation<NetworkInterfaceResource> nicOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, "myNetworkInterface", nicData);
NetworkInterfaceResource nic = nicOperation.Value;

var vmData = new VirtualMachineData(location)
{
    AvailabilitySet = new WritableSubResource() { Id = availabilitySet.Id },
    NetworkProfile = new Compute.Models.NetworkProfile { NetworkInterfaces = { new NetworkInterfaceReference() { Id = nic.Id } } },
    OSProfile = new OSProfile
    {
        ComputerName = "testVM",
        AdminUsername = "username",
        AdminPassword = "(YourPassword)",
        LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVmAgent = true }
    },
    StorageProfile = new StorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Offer = "UbuntuServer",
            Publisher = "Canonical",
            Sku = "18.04-LTS",
            Version = "latest"
        }
    },
    HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
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
