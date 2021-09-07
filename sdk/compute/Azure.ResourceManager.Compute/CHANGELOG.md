# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2021-08-31)

### Breaking Changes

Guidance to migrate from Previous Version of Azure Management SDK

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.Compute` to `Azure.ResourceManager.Compute`

#### Management Client Changes

Example: Create a VM:

Before upgrade:
```csharp
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
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;

var armClient = new ArmClient(new DefaultAzureCredential());

var location = Location.WestUS;
// Create ResourceGroup
ResourceGroup resourceGroup = await armClient.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));

// Create AvailabilitySet
var availabilitySetData = new AvailabilitySetData(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Compute.Models.Sku() { Name = "Aligned" }
};
AvailabilitySet availabilitySet = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync(vmName + "_aSet", availabilitySetData);

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
VirtualNetwork vnet = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vmName + "_vent", vnetData);

// Create Network interface
var nicData = new NetworkInterfaceData()
{
    Location = location,
    IpConfigurations =
    {
        new NetworkInterfaceIPConfiguration()
        {
            Name = "Primary",
            Primary = true,
            Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
        }
    }
};
NetworkInterface nic = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(vmName + "_nic", nicData);

var vmData = new VirtualMachineData(location)
{
    AvailabilitySet = new Compute.Models.SubResource() { Id = availabilitySet.Id },
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
VirtualMachine vm = await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync(vmName, vmData);
```

#### Object Model Changes

Example: Create a Virtual Machine Extension

Before upgrade:
```csharp
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
```csharp
var vmExtension = new VirtualMachineExtensionData(Location.WestUS)
{
    Tags = { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
    Publisher = "Microsoft.Compute",
    VirtualMachineExtensionType = "VMAccessAgent",
    TypeHandlerVersion = "2.0",
    AutoUpgradeMinorVersion = true,
    ForceUpdateTag = "RerunExtension",
    Settings = "{}",
    ProtectedSettings = "{}"
};
```
