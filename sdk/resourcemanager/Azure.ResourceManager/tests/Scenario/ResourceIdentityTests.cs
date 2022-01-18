using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ResourceIdentityTests : ResourceManagerTestBase
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";
        protected AzureLocation DefaultLocation => AzureLocation.WestUS2;
        protected Subscription _subscription;
        protected ResourceGroup _resourceGroup;
        protected GenericResourceCollection _genericResourceCollection;

        public ResourceIdentityTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
            _genericResourceCollection = _subscription.GetGenericResources();
            _resourceGroup = await CreateResourceGroupAsync();
            var userAssignedIdentity1 = await CreateUserAssignedIdentityAsync();
            await _resourceGroup.DeleteAsync();
            //string rgName = Recording.GenerateAssetName("testRg-");
            // var vmCollection = _resourceGroup.GetVirtualMachines();
            // var vmName = Recording.GenerateAssetName("testVM-");
            // var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            // var input = GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            // var lro = await vmCollection.CreateOrUpdateAsync(vmName, input);
            // VirtualMachine virtualMachine = lro.Value;
            // Assert.AreEqual(vmName, virtualMachine.Data.Name);
        }

        protected async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testRi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData(DefaultLocation);
            var response = await _genericResourceCollection.CreateOrUpdateAsync(userIdentityId, input);
            return response.Value;
        }

        protected async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await _subscription.GetResourceGroups().CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }

        protected async Task<GenericResource> CreateVirtualNetwork()
        {
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier vnetId = new ResourceIdentifier($"/subscriptions/9abff005-2afc-4de1-b39c-344b9de2cc9c/resourcegroups/feng-mi-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/feng-mi-1");
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(vnetId, input);
            return operation.Value;
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties as IDictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return new ResourceIdentifier(subnet["id"] as string);
        }

        // WEIRD: second level resources cannot use GenericResourceCollection to create.
        // Exception thrown: System.InvalidOperationException : An invalid resource id was given /subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/testRG-4544/providers/Microsoft.Network/virtualNetworks/testVNet-9796/subnets/testSubnet-1786
        private async Task<GenericResource> CreateSubnet(ResourceIdentifier vnetId)
        {
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier subnetId = new ResourceIdentifier($"{vnetId}/subnets/{subnetName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "addressPrefixes", new List<string>() { "10.0.2.0/24" } }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(subnetId, input);
            return operation.Value;
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceIdentifier subnetId)
        {
            var nicName = Recording.GenerateAssetName("testNic-");
            ResourceIdentifier nicId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}");
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "ipConfigurations", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "name", "internal" },
                                { "properties", new Dictionary<string, object>()
                                    {
                                        { "subnet", new Dictionary<string, object>() { { "id", subnetId.ToString() } } }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var operation = await _genericResourceCollection.CreateOrUpdateAsync(nicId, input);
            return operation.Value;
        }

        protected async Task<GenericResource> CreateBasicDependenciesOfVirtualMachineAsync()
        {
            var vnet = await CreateVirtualNetwork();
            //var subnet = await CreateSubnet(vnet.Id as ResourceGroupResourceIdentifier);
            var nic = await CreateNetworkInterface(GetSubnetId(vnet));
            return nic;
        }

        protected static VirtualMachineData GetBasicLinuxVirtualMachineData(AzureLocation location, string computerName, ResourceIdentifier nicID, string adminUsername = "adminuser")
        {
            return new VirtualMachineData(location)
            {
                HardwareProfile = new HardwareProfile()
                {
                    VmSize = VirtualMachineSizeTypes.StandardF2
                },
                OsProfile = new OSProfile()
                {
                    AdminUsername = adminUsername,
                    ComputerName = computerName,
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = true,
                        Ssh = new SshConfiguration()
                        {
                            PublicKeys = {
                                new SshPublicKeyInfo()
                                {
                                    Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                    KeyData = dummySSHKey,
                                }
                            }
                        }
                    }
                },
                NetworkProfile = new NetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new NetworkInterfaceReference()
                        {
                            Id = nicID,
                            Primary = true,
                        }
                    }
                },
                StorageProfile = new StorageProfile()
                {
                    OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                    {
                        OsType = OperatingSystemTypes.Linux,
                        Caching = CachingTypes.ReadWrite,
                        ManagedDisk = new ManagedDiskParameters()
                        {
                            StorageAccountType = StorageAccountTypes.StandardLRS
                        }
                    },
                    ImageReference = new ImageReference()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };
        }
    }
}
