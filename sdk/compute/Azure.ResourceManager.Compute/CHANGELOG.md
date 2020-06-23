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
await resourceClient.ResourceGroups.CreateOrUpdateAsync(resourceGroup, new ResourceGroup(location));

// Create Availability Set
var availabilitySet = new AvailabilitySet(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Sku("Aligned"),
};

availabilitySet = await computeClient.AvailabilitySets
    .CreateOrUpdateAsync(resourceGroup, vmName + "_aSet", availabilitySet);

// Create IP Address
var ipAddress = new PublicIPAddress()
{
    PublicIPAddressVersion = IPVersion.IPv4,
    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
    Location = location,
};

ipAddress = await networkClient
    .PublicIPAddresses.BeginCreateOrUpdateAsync(resourceGroup, vmName + "_ip", ipAddress);

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
    .BeginCreateOrUpdateAsync(resourceGroup, vmName + "_vent", vnet);

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
    .BeginCreateOrUpdateAsync(resourceGroup, vmName + "_nic", nic);

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

await computeClient.VirtualMachines.BeginCreateOrUpdateAsync(resourceGroup, vmName, vm);

```

After upgrade:
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;


var computeClient = new ComputeManagementClient(subscriptionId, new DefaultAzureCredential());
var networkClient = new NetworkManagementClient(subscriptionId, new DefaultAzureCredential());

var availabilitySetsClient = computeClient.AvailabilitySets;
var virtualNetworksClient = networkClient.VirtualNetworks;
var networkInterfaceClient = networkClient.NetworkInterfaces;
var virtualMachinesClient = computeClient.VirtualMachines;

var location = "westus";
// Create AvailabilitySet
var availabilitySet = new AvailabilitySet(location)
{
    PlatformUpdateDomainCount = 5,
    PlatformFaultDomainCount = 2,
    Sku = new Sku() { Name = "Aligned" }  // TODO. Verify new codegen on AvailabilitySetSkuTypes.Aligned
};

availabilitySet = await availabilitySetsClient.CreateOrUpdateAsync(resourceGroup, vmName + "_aSet", availabilitySet);

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

vnet = await virtualNetworksClient
    .StartCreateOrUpdate(resourceGroup, vmName + "_vent", vnet)
    .WaitForCompletionAsync();

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
        }
    }
};

nic = await networkInterfaceClient
    .StartCreateOrUpdate(resourceGroup, vmName + "_nic", nic)
    .WaitForCompletionAsync();

var vm = new VirtualMachine(location)
{
    NetworkProfile = new Compute.Models.NetworkProfile { NetworkInterfaces = new[] { new NetworkInterfaceReference() { Id = nic.Id } } },
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
        },
        DataDisks = new List<DataDisk>()
    },
    HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
};
vm.AvailabilitySet.Id = availabilitySet.Id;

var operaiontion = await virtualMachinesClient.StartCreateOrUpdateAsync(resourceGroup, vmName, vm);
await operaiontion.WaitForCompletionAsync();

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
var vmExtension = new VirtualMachineExtension(
                null,
                "vmext01",
                "Microsoft.Compute/virtualMachines/extensions",
                "westus",
                new Dictionary<string, string>() { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                "RerunExtension",
                "Microsoft.Compute",
                "VMAccessAgent", "2.0", true, "{}", "{}", null, null
                );
```
