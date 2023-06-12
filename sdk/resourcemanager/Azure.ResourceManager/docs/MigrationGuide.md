# Migrating from old to new management SDK

There are several differences between the old sdk and this new sdk. Here's an example of how to create a Virtual Machine with both SDKs:

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
#### New (Azure.ResourceManager._)
```C# Snippet:Using_Statements
using System;
using System.Linq;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

### Setting up the clients
#### Old
```C#
ServiceClientCredentials credentials = getMyCredentials();
ComputeManagementClient computeClient = new ComputeManagementClient(credentials);
NetworkManagementClient networkClient = new NetworkManagementClient(credentials);
ManagedServiceIdentityClient managedServiceIdentityClient = new ManagedServiceIdentityClient(credentials);
```
#### New
```C# Snippet:Construct_Client
ArmClient client = new ArmClient(new DefaultAzureCredential());
```
As you can see, authentication is now handled by Azure.Identity, and now just a single client is needed, from which you can get the default subscription and start managing your resources.

### Create a Resource Group
#### Old
```C#
ServiceClientCredentials credentials = getMyCredentials(); 
ResourceManagementClient resourcesClient = new ResourceManagementClient(credentials);

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
```C# Snippet:Create_ResourceGroup
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

AzureLocation location = AzureLocation.WestUS2;
string resourceGroupName = "QuickStartRG";

ResourceGroupData resourceGroupData = new ResourceGroupData(location);
ArmOperation<ResourceGroupResource> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
ResourceGroupResource resourceGroup = resourceGroupOperation.Value;
```
The main difference is that the previous libraries represent all operations as flat, while the new libraries respresents the hierarchy of resources. In that way, you can use a `subscriptionCollection` to manage the resources in a particular subscription. In this example, a `resourceGroupCollection` is used to manage the resources in a particular resource group. In the example above, a new resource group is created from a resourceGroupCollection. With that `ResourceGroup` you will be able to get the resource collections to manage all the resources that will be inside it, as it is shown in the next part of this guide.

The new SDK also provides some common classes to represent commonly-used constructs, like `Location`, and allows you to use them directly throughout the APIs, making it easier to discover how to properly configure resources.

### Create an Availability Set
#### Old
```C#
AvailabilitySet inputAvailabilitySet = new AvailabilitySet
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

AvailabilitySet asCreateOrUpdateResponse = computeClient.AvailabilitySets.CreateOrUpdate(rgName,aSetName,inputAvailabilitySet);
string aSetID = $"/subscriptions/{computeClient.SubscriptionId}/resourceGroups/{rgName}/providers/Microsoft.Compute/availabilitySets/{aSetName}";
```
#### New
```C# Snippet:Create_AvailabilitySet
string virtualMachineName = "quickstartvm";
AvailabilitySetData availabilitySetData = new AvailabilitySetData(location);
AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
ArmOperation<AvailabilitySetResource> availabilitySetOperation = await availabilitySets.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName + "_aSet", availabilitySetData);
AvailabilitySetResource availabilitySet = availabilitySetOperation.Value;
```

Parameters can be specified via the `AvailabilitySetData` object, in here, the basic default only requires the location. The availability set is created using  the AvailabilitySetsCollection returned from the `GetAvailabilitySets()` extension method instead of using another client. 

### Create a Virtual Network and Subnet
#### Old
```C#
string vnetName = vmName + "_vnet";
string subnetName = "mySubnet";

VirtualNetwork vnet = new VirtualNetwork()
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
VirtualNetwork putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
VirtualNetwork subnetResponse = networkClient.Subnets.Get(rgName, vnetName, subnetName);
```
#### New
```C# Snippet:Create_Vnet_and_Subnet
string virtualNetworkName = "MYVM" + "_vnet";
string subnetName = "mySubnet";

VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
{
    Subnets =
    {
        new SubnetData()
        {
            Name = subnetName,
            AddressPrefix = "10.0.0.0/24"
        }
    }
};
VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
virtualNetworkData.AddressPrefixes.Add("10.0.0.0/16");
ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
```

In both libraries, subnets are defined inside virtual networks, however, with the new SDK you can get a subnets collection using `.GetSubnets()`, and from there create any subnet in the virtual network from which the method is being called.

### Create a Security Group
#### Old
```C#
string nsgName = vmName + "_nsg";
NetworkSecurityGroup nsgParameters = new NetworkSecurityGroup()
{
    Location = location
};

NetworkSecurityGroup putNSgResponse = networkClient.NetworkSecurityGroups.CreateOrUpdate(rgName, nsgName, nsgParameters);
NetworkSecurityGroup nsg = networkClient.NetworkSecurityGroups.Get(rgName, nsgName);
```
#### New
```C# Snippet:Create_NetworkSecurityGroup
string networkSecurityGroupName = virtualMachineName + "_nsg";
NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData() { Location = location };
NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);
NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
```

### Create a Network Interface
#### Old
```C#
string nicname = vmName + "_nic";
string ipConfigName = vmName + "_IP";

NetworkInterface nicParameters = new NetworkInterface()
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

NetworkInterface putNicResponse = networkClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
NetworkInterface nicResponse = networkClient.NetworkInterfaces.Get(rgName, nicname);
```
#### New
```C# Snippet:Create_NetworkInterface
string networkInterfaceName = virtualMachineName + "_nic";
NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
{
    Name = "Primary",
    Primary = true,
    Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
    PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
};

NetworkInterfaceData nicData = new NetworkInterfaceData();
nicData.Location = location;
nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;
```

This step is similar to the old SDK, however, notice that the `CreateOrUpdateAsync()` method returns the network interface that has been created. 

### Create a Virtual Machine
#### Old
```C#
string vmSize = VirtualMachineSizeTypes.StandardA1V2
VirtualMachine inputVM = new VirtualMachine
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

VirtualMachine vm = VMcomputeClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
```
#### New
```C# Snippet:Create_VirtualMachine
VirtualMachineData virutalMachineData = new VirtualMachineData(location)
{
    OSProfile = new VirtualMachineOSProfile()
    {
        AdminUsername = "admin-username",
        AdminPassword = "admin-p4$$w0rd",
        ComputerName = "computer-name"
    },
    AvailabilitySetId = availabilitySet.Id,
    NetworkProfile = new VirtualMachineNetworkProfile()
    {
        NetworkInterfaces =
        {
            new VirtualMachineNetworkInterfaceReference()
            {
                Id = networkInterface.Id
            }
        }
    }
};

VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
ArmOperation<VirtualMachineResource> virtualMachineOperation = await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, virutalMachineData);
VirtualMachineResource virtualMachine = virtualMachineOperation.Value;
Console.WriteLine("VirtualMachine ID: " + virtualMachine.Id);
```

Finally, as it can be seen here, from the resource group you can get the Virtual Machine collection and create a new one using the `VirtualMachineData` for the parameters.

## Next steps
Check out [more examples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager/samples) we have available.
