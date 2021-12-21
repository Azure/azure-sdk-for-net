# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System.Linq;

var armClient = new ArmClient(new DefaultAzureCredential());

var location = Location.WestUS;
// Create ResourceGroup
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCreateOrUpdateOperation rgOperation = await subscription.GetResourceGroups().CreateOrUpdateAsync("myResourceGroup", new ResourceGroupData(location));
ResourceGroup resourceGroup = rgOperation.Value;

// Create AvailabilitySet
var availabilitySetData = new AvailabilitySetData(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Compute.Models.Sku() { Name = "Aligned" }
};
AvailabilitySetCreateOrUpdateOperation asetOperation = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync("myAvailabilitySet", availabilitySetData);
AvailabilitySet availabilitySet = asetOperation.Value;

// Create VNet
var vnetData = new VirtualNetworkData()
{
    Location = location,
    AddressSpace = new AddressSpace() { AddressPrefixes = { "10.0.0.0/16" } },
    Subnets =
    {
        new SubnetData()
        {
            Name = "mySubnet",
            AddressPrefix = "10.0.0.0/24",
        }
    },
};
VirtualNetworkCreateOrUpdateOperation vnetOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync("myVirtualNetwork", vnetData);
VirtualNetwork vnet = vnetOperation.Value;

// Create Network interface
var nicData = new NetworkInterfaceData()
{
    Location = location,
    IpConfigurations =
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
NetworkInterfaceCreateOrUpdateOperation nicOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync("myNetworkInterface", nicData);
NetworkInterface nic = nicOperation.Value;

var vmData = new VirtualMachineData(location)
{
    AvailabilitySet = new WritableSubResource() { Id = availabilitySet.Id },
    NetworkProfile = new Compute.Models.NetworkProfile { NetworkInterfaces = { new NetworkInterfaceReference() { Id = nic.Id } } },
    OsProfile = new OSProfile
    {
        ComputerName = "testVM",
        AdminUsername = "username",
        AdminPassword = "(YourPassword)",
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
        }
    },
    HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
};
VirtualMachineCreateOrUpdateOperation vmOperation = await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync("myVirtualMachine", vmData);
VirtualMachine vm = vmOperation.Value;
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
var vmExtension = new VirtualMachineExtensionData(Location.WestUS)
{
    Tags = { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
    Publisher = "Microsoft.Compute",
    TypePropertiesType = "VMAccessAgent",
    TypeHandlerVersion = "2.0",
    AutoUpgradeMinorVersion = true,
    ForceUpdateTag = "RerunExtension",
    Settings = "{}",
    ProtectedSettings = "{}"
};
```
