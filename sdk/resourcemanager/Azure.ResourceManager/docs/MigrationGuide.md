# Migrating from old to new management SDK

If you are using the old Azure management SDK for .Net, you may need to make some changes to your code to take advantage of the new features and improvements in the new Track 2 Azure management SDK. Here are some examples that show you how to migrate your code to the new Azure management SDK for .Net.

* [Migrating from Track 1 SDK to Track 2 SDK](#migrating-from-track-1-sdk-to-track-2-sdk)
    * [Import the namespaces](#import-the-namespaces)
    * [Setting up the clients](#setting-up-the-clients)
    * [Create a Resource Group](#create-a-resource-group)
    * [Create an Availability Set](#create-an-availability-set)
    * [Create a Security Group](#create-a-security-group)
    * [Create a Virtual Network and Subnet](#create-a-virtual-network-and-subnet)
    * [Create a Network Interface](#create-a-network-interface)
    * [Create a Virtual Machine](#create-a-virtual-machine)
* [Migrating from Track 1 Fluent SDK to Track 2 SDK](#migrating-from-track-1-fluent-sdk-to-track-2-sdk)
    * [Import the namespaces](#import-the-namespaces-1)
    * [Setting up the clients](#setting-up-the-clients-1)
    * [Create a Security Group](#create-a-security-group-1)
    * [Create a Virtual Network and Subnet](#create-a-virtual-network-and-subnet-1)
    * [Create a Virtual Machine](#create-a-virtual-machine-1)
    * [List all Virtual Networks](#list-all-virtual-networks)
    * [Delete a Virtual Network](#delete-a-virtual-network)

## Migrating from Track 1 SDK to Track 2 SDK

The old Track 1 SDK uses package names that start with `Microsoft.Azure.Management` and without `Fluent` suffix.
To assist you with the migration process, we have prepared some examples for you.

### Import the namespaces

**Old (Microsoft.Azure.Management._)**
```C#
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
...
```
**New (Azure.ResourceManager._)**
```C# Snippet:Using_Statements
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

### Setting up the clients

**Old**
```C#
ServiceClientCredentials credentials = getMyCredentials();
ComputeManagementClient computeClient = new ComputeManagementClient(credentials);
NetworkManagementClient networkClient = new NetworkManagementClient(credentials);
ManagedServiceIdentityClient managedServiceIdentityClient = new ManagedServiceIdentityClient(credentials);
```
**New**
```C# Snippet:Construct_Client
ArmClient client = new ArmClient(new DefaultAzureCredential());
```
As you can see, now authentication is handled by Azure.Identity, and just a single client is needed, from which you can get the default subscription and start managing your resources.

### Create a Resource Group

**Old**
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
**New**
```C# Snippet:Create_ResourceGroup
SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

string resourceGroupName = "QuickStartRG";

ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
ArmOperation<ResourceGroupResource> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
ResourceGroupResource resourceGroup = resourceGroupOperation.Value;
```
The main difference is that the previous libraries represent all operations as flat, while the new libraries respresents the hierarchy of resources. In that way, you can use a `subscriptionCollection` to manage the resources in a particular subscription. In this example, a `resourceGroupCollection` is used to manage the resources in a particular resource group. In the example above, a new resource group is created from a resourceGroupCollection. With that `ResourceGroup` you will be able to get the resource collections to manage all the resources that will be inside it, as it is shown in the next part of this guide.

The new SDK also provides some common classes to represent commonly-used constructs, like `Location`, and allows you to use them directly throughout the APIs, making it easier to discover how to properly configure resources.

### Create an Availability Set

**Old**
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
**New**
```C# Snippet:Create_AvailabilitySet
string availabilitySetName = "QuickstartAvailabilitySet";

AvailabilitySetData availabilitySetData = new AvailabilitySetData(resourceGroup.Data.Location);
AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
ArmOperation<AvailabilitySetResource> availabilitySetOperation = await availabilitySets.CreateOrUpdateAsync(WaitUntil.Completed, availabilitySetName + "_aSet", availabilitySetData);
AvailabilitySetResource availabilitySet = availabilitySetOperation.Value;
```

Parameters can be specified via the `AvailabilitySetData` object, in here, the basic default only requires the location. The availability set is created using  the AvailabilitySetsCollection returned from the `GetAvailabilitySets()` extension method instead of using another client. 

### Create a Security Group

**Old**
```C#
string nsgName = vmName + "_nsg";
NetworkSecurityGroup nsgParameters = new NetworkSecurityGroup()
{
    Location = location
};

NetworkSecurityGroup putNSgResponse = networkClient.NetworkSecurityGroups.CreateOrUpdate(rgName, nsgName, nsgParameters);
NetworkSecurityGroup nsg = networkClient.NetworkSecurityGroups.Get(rgName, nsgName);
```
**New**
```C# Snippet:Create_NetworkSecurityGroup
string networkSecurityGroupName = "QuickstartNsg";

NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData() { Location = resourceGroup.Data.Location };
NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);
NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
```

### Create a Virtual Network and Subnet

**Old**
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
**New**
```C# Snippet:Create_Vnet_and_Subnet
string virtualNetworkName = "QuickstartVnet";
string subnetName = "QuickstartSubnet";

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
virtualNetworkData.AddressPrefixes.Add("10.0.0.0/16");
VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
```

In both libraries, subnets are defined inside virtual networks, however, with the new SDK you can get a subnet collection using `.GetSubnets()`, and from there create any subnet in the virtual network from which the method is being called.

### Create a Network Interface

**Old**
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
**New**
```C# Snippet:Create_NetworkInterface
string networkInterfaceName = "QuickstartNic";

NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
{
    Name = "Primary",
    Primary = true,
    Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
    PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
};

NetworkInterfaceData nicData = new NetworkInterfaceData() { Location = resourceGroup.Data.Location };
nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;
```

This step is similar to the old SDK, however, notice that the `CreateOrUpdateAsync()` method returns the network interface that has been created. 

### Create a Virtual Machine

**Old**
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
**New**
```C# Snippet:Create_VirtualMachine
string virtualMachineName = "QuickstartVm";

VirtualMachineData virutalMachineData = new VirtualMachineData(resourceGroup.Data.Location)
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
```

Finally, as it can be seen here, from the resource group you can get the Virtual Machine collection and create a new one using the `VirtualMachineData` for the parameters.

## Migrating from Track 1 Fluent SDK to Track 2 SDK

The old Track 1 Fluent  SDK uses package names that start with `Microsoft.Azure.Management` and end with `Fluent` suffix.
To assist you with the migration process, we have prepared some examples for you.

### Import the namespaces

**Old (Microsoft.Azure.Management._.Fluent)**
```C#
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
...
```
**New (Azure.ResourceManager._)**
```C# Snippet:Using_Statements
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

### Setting up the clients

**Old**
```C#
var credentials = SdkContext.AzureCredentialsFactory.FromFile("Filename");
var azure = Azure.Configure()
    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
    .Authenticate(credentials)
    .WithDefaultSubscription();
```
**New**
```C# Snippet:Construct_CreateClient
string clientId = "CLIENT_ID";
string clientSecret = "CLIENT_SECRET";
string tenantId = "TENANT_ID";
string subscription = "SUBSCRIPTION_ID";
ClientSecretCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
ArmClient client = new ArmClient(credential, subscription);
```
As you can see, now authentication is handled by Azure.Identity, and just a single client is needed, from which you can get the default subscription and start managing your resources.

### Create a Security Group

**Old**
```C#
var networkNsg = azure.NetworkSecurityGroups
        .Define(VNet1BackEndSubnetNsgName)
        .WithRegion(Region.USEast)
        .WithNewResourceGroup(ResourceGroupName)
        .DefineRule("DenyInternetInComing")
            .DenyInbound()
            .FromAddress("INTERNET")
            .FromAnyPort()
            .ToAnyAddress()
            .ToAnyPort()
            .WithAnyProtocol()
            .Attach()
        .DefineRule("DenyInternetOutGoing")
            .DenyOutbound()
            .FromAnyAddress()
            .FromAnyPort()
            .ToAddress("INTERNET")
            .ToAnyPort()
            .WithAnyProtocol()
            .Attach()
        .Create();
```
**New**
```C# Snippet:Create_Fluent_Nsg
string networkNsgName = "QuickstartNsg";

NetworkSecurityGroupData networkNsgData = new NetworkSecurityGroupData()
{
    Location = resourceGroup.Data.Location,
    SecurityRules =
        {
            new SecurityRuleData()
            {
                Name = "DenyInternetInComing",
                Protocol = SecurityRuleProtocol.Asterisk,
                SourcePortRange = "*",
                DestinationPortRange = "*",
                SourceAddressPrefix = "INTERNET",
                DestinationAddressPrefix = "*",
                Access = SecurityRuleAccess.Deny,
                Priority = 100,
                Direction = SecurityRuleDirection.Inbound,
            },
            new SecurityRuleData()
            {
                Name = "DenyInternetOutGoing",
                Protocol = SecurityRuleProtocol.Asterisk,
                SourcePortRange = "*",
                DestinationPortRange = "*",
                SourceAddressPrefix = "*",
                DestinationAddressPrefix = "internet",
                Access = SecurityRuleAccess.Deny,
                Priority = 200,
                Direction = SecurityRuleDirection.Outbound,
            }
        }
};
NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkNsgName, networkNsgData);
NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
```

### Create a Virtual Network and Subnet

**Old**
```C#
var virtualNetwork = azure.Networks.Define(virtualNetworkName)
        .WithRegion(Region.USEast)
        .WithExistingResourceGroup(ResourceGroupName)
        .WithAddressSpace("192.168.0.0/16")
        .WithSubnet("subnet1", "192.168.1.0/24")
        .DefineSubnet(subnetName)
            .WithAddressPrefix("192.168.2.0/24")
            .WithExistingNetworkSecurityGroup(backEndSubnetNsg)
            .Attach()
        .Create();
```
**New**
```C# Snippet:Create_Fluent_Vnet_and_Subnet
string virtualNetworkName = "QuickstartVnet";
string subnetName = "QuickstartSubnet";

VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
    {
        Location = AzureLocation.EastUS,
        AddressPrefixes = { "192.168.0.0/16" },
        Subnets =
        {
            new SubnetData()
                {
                    AddressPrefix = "192.168.2.0/24",
                    Name = subnetName,
                    NetworkSecurityGroup = networkSecurityGroup.Data
                },
            new SubnetData()
                {
                    AddressPrefix = "192.168.1.0/24",
                    Name = "subnet1"
                }
        },
    };
VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
```

In both libraries, subnets are defined inside virtual networks, however, with the new SDK you can get a subnets collection using `.GetSubnets()`, and from there create any subnet in the virtual network from which the method is being called.

### Create a Virtual Machine

**Old**
```C#
var virutalMachine = azure.VirtualMachines.Define(virtualMachineName)
        .WithRegion(Region.USEast)
        .WithExistingResourceGroup(ResourceGroupName)
        .WithExistingPrimaryNetwork(virtualNetwork)
        .WithSubnet(subnetName)
        .WithPrimaryPrivateIPAddressDynamic()
        .WithNewPrimaryPublicIPAddress(publicIpAddress)
        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
        .WithRootUsername(UserName)
        .WithSsh(SshKey)
        .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"))
        .Create();
```
**New**
```C# Snippet:Create_Fluent_VirtualMachine
// Create Nic
string networkInterfaceName = "QuickstartNic";

NetworkInterfaceData nicData = new NetworkInterfaceData()
{
    Location = AzureLocation.EastUS,
    IPConfigurations =
    {
        new NetworkInterfaceIPConfigurationData()
        {
            Name = "default-config",
            PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
            Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
        }
    }
};
NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;

// Create VM
string virtualMachineName = "QuickstartVm";

VirtualMachineData virutalMachineData = new VirtualMachineData(AzureLocation.EastUS)
{
    HardwareProfile = new VirtualMachineHardwareProfile()
    {
        VmSize = VirtualMachineSizeType.StandardD2V3
    },
    StorageProfile = new VirtualMachineStorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Publisher = "Canonical",
            Offer = "0001-com-ubuntu-server-jammy",
            Sku = "22_04-lts-gen2",
            Version = "latest",
        },
        OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
        {
            OSType = SupportedOperatingSystemType.Windows,
            Name = "QuickstartVmOSDisk",
            Caching = CachingType.ReadOnly,
            ManagedDisk = new VirtualMachineManagedDisk()
            {
                StorageAccountType = StorageAccountType.StandardLrs,
            },
        },
    },
    OSProfile = new VirtualMachineOSProfile()
    {
        AdminUsername = "admin-username",
        AdminPassword = "admin-p4$$w0rd",
        ComputerName = "computer-name"
    },
    NetworkProfile = new VirtualMachineNetworkProfile()
    {
        NetworkInterfaces =
        {
            new VirtualMachineNetworkInterfaceReference()
            {
                Id = networkInterface.Id,
                Primary = true,
            }
        }
    },
};
VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
ArmOperation<VirtualMachineResource> virtualMachineOperation = await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, virutalMachineData);
VirtualMachineResource virtualMachine = virtualMachineOperation.Value;
```

Finally, as it can be seen here, from the resource group you can get the Virtual Machine collection and create a new one using the `VirtualMachineData` for the parameters.

### Update a Virtual Machine

**Replace or create the virtual machine resource**
```C# Snippet:UpdateByReplace_Fluent_VirtualMachine
var virtualMachineDataToModify = new VirtualMachineData(AzureLocation.EastUS)
{
    HardwareProfile = new VirtualMachineHardwareProfile()
    {
        VmSize = VirtualMachineSizeType.StandardD2V3
    },
    StorageProfile = new VirtualMachineStorageProfile()
    {
        ImageReference = new ImageReference()
        {
            Publisher = "Canonical",
            Offer = "0001-com-ubuntu-server-jammy",
            Sku = "22_04-lts-gen2",
            Version = "latest",
        },
        OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
        {
            OSType = SupportedOperatingSystemType.Windows,
            Name = "QuickstartVmOSDisk",
            Caching = CachingType.ReadOnly,
            ManagedDisk = new VirtualMachineManagedDisk()
            {
                StorageAccountType = StorageAccountType.StandardLrs,
            },
        },
    },
    OSProfile = new VirtualMachineOSProfile()
    {
        AdminUsername = "admin-username",
        AdminPassword = "admin-p4$$w0rd",
        ComputerName = "computer-name"
    },
    NetworkProfile = new VirtualMachineNetworkProfile()
    {
        NetworkInterfaces =
        {
            new VirtualMachineNetworkInterfaceReference()
            {
                Id = networkInterface.Id,
                Primary = false,
            }
        }
    }
};
VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
var virtualMachineModify = (await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachine.Data.Name, virtualMachineDataToModify)).Value;
```
**Update a few properties using `UpdateAsync` method**
```C# Snippet:UpdateByUpdateAsync_Fluent_VirtualMachine
var patch = new VirtualMachinePatch()
{
    NetworkProfile = new VirtualMachineNetworkProfile()
    {
        NetworkInterfaces =
        {
            new VirtualMachineNetworkInterfaceReference()
            {
                Id = networkInterface.Id,
                Primary = false,
            }
        }
    }
};
var virtualMachineModify = (await virtualMachine.UpdateAsync(WaitUntil.Completed, patch)).Value;
```
**Get the virtual machine resource by name and modify its Data property**
```C# Snippet:UpdateByDataProerty_Fluent_VirtualMachine
var virtualMachines = resourceGroup.GetVirtualMachines();
var virtualMachineGet = (await virtualMachines.GetAsync(virtualMachine.Data.Name)).Value;
virtualMachineGet.Data.NetworkProfile = new VirtualMachineNetworkProfile()
{
    NetworkInterfaces =
    {
        new VirtualMachineNetworkInterfaceReference()
        {
            Id = networkInterface.Id,
            Primary = false,
        }
    }
};
var virtualMachineModify = (await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachine.Data.Name, virtualMachineGet.Data)).Value;
```

### List all Virtual Networks

**Old**
```C#
foreach (var virtualNetwork in azure.Networks.ListByResourceGroup(ResourceGroupName))
{
    // Do something
    Console.WriteLine(virtualNetwork.Data.Name);
}
```
**New**
```C# Snippet:Create_Fluent_ListNetworks
await foreach (VirtualNetworkResource virtualNetwork in resourceGroup.GetVirtualNetworks().GetAllAsync())
{
    // Do something
    Console.WriteLine(virtualNetwork.Data.Name);
}
```

### Delete a Virtual Network

**Old**
```C#
azure.Networks.DeleteById(virtualNetwork.Id);
```
**New**
```C# Snippet:Create_Fluent_DeleteNetwork
await virtualNetwork.DeleteAsync(WaitUntil.Completed);
```

## Next steps

Check out [more .NET Management Library Code Samples](https://docs.microsoft.com/samples/browse/?branch=master&languages=csharp&term=managing%20using%20Azure%20.NET%20SDK) we have available.
