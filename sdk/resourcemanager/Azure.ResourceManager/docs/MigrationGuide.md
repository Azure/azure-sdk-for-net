# Migrating from old to preview management SDK.

There are several differences between the old sdk and this preview. Here's an example of how to create a Virtual Machine with both SDKs:

## Create a Virtual Machine example

### Import the namespaces
#### Old (Microsoft.Azure.Management._)
```C#
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;
using System;
using System.Threading.Tasks;
```
#### New (Azure.ResourceManager._ Preview)
```C#
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Network;
using System;
using System.Threading.Tasks;
```

### Setting up the clients
#### Old
```C#
ServiceClientCredentials credentials = getMyCredentials();
var computeClient = new ComputeManagementClient(credentials);
var networkClient = new NetworkManagementClient(credentials);
var managedServiceIdentityClient = new ManagedServiceIdentityClient(credentials);
```
#### New
```C#
var armClient = new ArmClient(new DefaultAzureCredential());
```
As you can see, authentication is now handled by Azure.Identity, and now just a single client is needed, from which you can get the `DefaultSubscription` and start managing your resources. 

### Create a Resource Group
#### Old
```C#
ServiceClientCredentials credentials = getMyCredentials(); 
var resourcesClient = new ResourceManagementClient(credentials);

string rgName = "QuickStartRG";
string location = "WestUS2";
resourcesClient.ResourceGroups.CreateOrUpdate(
    rgName,
    new ResourceGroup
    {
        Location = location,
        Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
    });
```
#### New
```C#
var armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = armClient.DefaultSubscription;
ResourceGroupContainer rgContainer = subscription.GetResourceGroups();

Location location = Location.WestUS2;
string rgName = "QuickStartRG";
ResourceGroup resourceGroup = await rgContainer.Construct(location).CreateOrUpdateAsync(rgName)
```

In the new libraries, the Resource Group is created trought a container that came from the subscription. Also, public locations are provided trought the `Location` object, but it can be specified as a string as well. Additionally, there's no need to create a `ResourceGroup` object to send parameters when creating a resource group, since tags can be added directly from the resource group variable and the location is specified in the `Construct()` method.

### Create an Availability Set
#### Old
```C#
var inputAvailabilitySet = new AvailabilitySet
{
    Location = location,
    Tags = new Dictionary<string, string>()
    {
        { "RG", "rg" },
        { "testTag", "1" }
    },
    PlatformFaultDomainCount = 1,
    PlatformUpdateDomainCount = 1,
    Sku = new CM.Sku
    {
        Name = AvailabilitySetSkuTypes.Aligned 
    }
};
string aSetName = "quickstartvm_aSet";

var asCreateOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(
    rgName,
    aSetName,
    inputAvailabilitySet
);
string aSetID = $"/subscriptions/{computeClient.SubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Compute/availabilitySets/{aSetName}";
```
#### New
```C#
string vmName = "quickstartvm";
var aset = await resourceGroup.GetAvailabilitySets().Construct("Aligned").CreateOrUpdateAsync(vmName + "_aSet");
```

Now there's no need to create an `AvailabilitySet` object, thus less code is needed. The availability set is created using  the `GetAvailabilitySets()` extension method instead of using another client. 

### Create a Virtual Network and Subnet
#### Old
```C#
string vnetName = vmName + "_vnet";
string subnetName = "mySubnet";

var vnet = new VirtualNetwork()
{
    Location = location,
    AddressSpace = new AddressSpace()
    {
        AddressPrefixes = new List<string>()
                {
                    "10.0.0.0/16",
                }
    },
    Subnets = new List<Subnet>()
            {
                new Subnet()
                {
                    Name = subnetName,
                    AddressPrefix = "10.0.0.0/24",
                }
            }
};
var putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
var subnetResponse = networkClient.Subnets.Get(rgName, vnetName, subnetName);
```
#### New
```C#
string vnetName = vmName + "_vnet";
string subnetName = "mySubnet";
var vnet = await resourceGroup.GetVirtualNetworks().Construct("10.0.0.0/16").CreateOrUpdateAsync(vnetName);
var subnet = await vnet.GetSubnets().Construct("10.0.0.0/24").CreateOrUpdateAsync(subnetName);
```

The main difference here is that a virtual network object is no longer needed to create a virtual network. One similarity is that subnets are defined inside virtual networks, however, with the new SDK you can get a subnets container using `.GetSubnets()`, and from there create any subnet in the virtual network from which the method is being called.

### Create a Security Group
#### Old
```C#
string nsgName = vmName + "_nsg";
var nsgParameters = new NetworkSecurityGroup()
{
    Location = location
};

var putNSgResponse = networkClient.NetworkSecurityGroups.CreateOrUpdate(rgName, nsgName, nsgParameters);
var nsg = networkClient.NetworkSecurityGroups.Get(rgName, nsgName);
```
#### New
```C#
string nsgName =  vmName + "_nsg";
 _ = await resourceGroup.GetNetworkSecurityGroups().Construct(80).CreateOrUpdateAsync(nsgName);
```

Creating a Network security group does not longer require a `NetworkSecurityGroup` object as a parameter.

### Create a Network Interface
#### Old
```C#
string nicname = vmName + "_nic";
string ipConfigName = vmName + "_IP";

var nicParameters = new NetworkInterface()
{
    Location = location,
    Tags = new Dictionary<string, string>()
    {
        { "key" ,"value" }
    },
    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
    {
        new NetworkInterfaceIPConfiguration()
        {
            Name = ipConfigName,
            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            Subnet = subnetResponse,
        }
    },
    NetworkSecurityGroup = nsg
};

var putNicResponse = networkClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
var nicResponse = networkClient.NetworkInterfaces.Get(rgName, nicname);
```
#### New
```C#
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
nic = await networkInterfaceClient
    .StartCreateOrUpdate(resourceGroupName, vmName + "_nic", nic)
    .WaitForCompletionAsync();
```

This step is similar to the old SDK, however, notice that the `StartCreateOrUpdate()` method returns the network interface that has been created. 

### Create a Virtual Machine
#### Old
```C#
string vmSize = VirtualMachineSizeTypes.StandardA1V2
var inputVM = new VirtualMachine
{
    Location = location,
    Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
    HardwareProfile = new HardwareProfile
    {
        VmSize = vmSize
    },
    StorageProfile = new StorageProfile
    {
        ImageReference = imageRef,
        OsDisk = new OSDisk
        {
            Caching = CachingTypes.None,
            WriteAcceleratorEnabled = writeAcceleratorEnabled,
            CreateOption = DiskCreateOptionTypes.FromImage,
            Name = "test",
            Vhd =  null,
            ManagedDisk = new ManagedDiskParameters
            {
                StorageAccountType = osDiskStorageAccountType,
                DiskEncryptionSet = null,
            }
        },
        DataDisks = null,
    },
    OsProfile = new OSProfile
    {
        AdminUsername = "Foo12",
        AdminPassword = PLACEHOLDER,
        ComputerName = ComputerName
    }
};

inputVM.AvailabilitySet = new Microsoft.Azure.Management.Compute.Models.SubResource() { Id = aSetID };

CM.NetworkProfile vmNetworkProfile = new CM.NetworkProfile();
vmNetworkProfile.NetworkInterfaces = new List<NetworkInterfaceReference>
{
    new NetworkInterfaceReference
    {
        Id = nicResponse.Id
    }
};
inputVM.NetworkProfile = vmNetworkProfile;

var vm = VMcomputeClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
```
#### New
```C#
var vm = await resourceGroup.GetVirtualMachines().Construct("hostname", "admin-user", "p4$$w0rd", nic.Id, aset.Id).CreateOrUpdateAsync(vmName);
Console.WriteLine("VM ID: " + vm.Id);
```

Finally, as it can be seen here, with the new SDK a single virtual machine can be created in just a single line of code. No need to create a `VirtualMachine` object and set it up.

## Next steps
Check out [more examples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager/samples) we have available.