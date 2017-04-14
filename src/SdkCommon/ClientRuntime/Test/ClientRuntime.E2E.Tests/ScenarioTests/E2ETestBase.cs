// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.E2E.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    //using Microsoft.Azure.Management.ResourceManager;
    //using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Rest.ClientRuntime.E2E.Tests.TestAssets;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using Xunit;

    public class E2ETestBase
    {
        const string DEFAULT_LOCATION = "SoutheastAsia";

        string TEST_PREFIX;
        
        MockContext _mockContext;
        ResourceManagementClient _resourceClient;
        MyComputeClient _computeClient;
        StorageManagementClient _storageClient;
        NetworkManagementClient _networkClient;

        ImageReference m_windowsImageReference, m_linuxImageReference;

        /// <summary>
        /// Constructor for E2ETestBase class
        /// </summary>
        /// <param name="testPrefix"></param>
        public E2ETestBase(string testPrefix = "")
        {
            TEST_PREFIX = testPrefix;
        }

        protected MockContext MockContext
        {
            get
            {
                return _mockContext;

            }

            set
            {
                _mockContext = value;
            }
        }
        protected ResourceManagementClient ResourceClient
        {
            get
            {
                if(_resourceClient == null)
                {
                    var handle = new RecordedDelegatingHandler
                    {
                        StatusCodeToReturn = HttpStatusCode.OK,
                        IsPassThrough = true
                    };

                    _resourceClient = MockContext.GetServiceClient<ResourceManagementClient>(handlers: handle);
                }

                return _resourceClient;
            }
        }

        protected MyComputeClient ComputeClient
        {
            get
            {
                if(_computeClient == null)
                {
                    var handle = new RecordedDelegatingHandler
                    {
                        StatusCodeToReturn = HttpStatusCode.OK,
                        IsPassThrough = true
                    };
                    _computeClient = MockContext.GetServiceClient<MyComputeClient>(handlers: handle);
                }

                return _computeClient;
            }
        }

        protected StorageManagementClient StorageClient
        {
            get
            {
                if (_storageClient == null)
                {
                    var handle = new RecordedDelegatingHandler
                    {
                        StatusCodeToReturn = HttpStatusCode.OK,
                        IsPassThrough = true
                    };

                    _storageClient = MockContext.GetServiceClient<StorageManagementClient>(handlers: handle);
                }

                return _storageClient;
            }
        }

        protected NetworkManagementClient NetworkClient
        {
            get
            {
                if (_networkClient == null)
                {
                    var handle = new RecordedDelegatingHandler
                    {
                        StatusCodeToReturn = HttpStatusCode.OK,
                        IsPassThrough = true
                    };

                    _networkClient = MockContext.GetServiceClient<NetworkManagementClient>(handlers: handle);
                }

                return _networkClient;
            }
        }

        protected StorageAccount CreateStorageAccount(ResourceGroup resGroup, string storageAccountName)
        {
            StorageAccount storageAccountOutput = null;
            string rgName = resGroup.Name;

            try
            {
                var storageAccountList = StorageClient.StorageAccounts.ListByResourceGroup(rgName);
                if (storageAccountList.Any())
                {
                    storageAccountOutput = storageAccountList.Where((sa) => sa.Name.Equals(storageAccountName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                }
            }
            catch { }

            if (storageAccountOutput == null)
            {
                var stoInput = new StorageAccountCreateParameters
                {
                    Location = DEFAULT_LOCATION,
                    Sku = new Microsoft.Azure.Management.Storage.Models.Sku(SkuName.StandardGRS)
                };

                storageAccountOutput = StorageClient.StorageAccounts.Create(rgName,
                    storageAccountName, stoInput);
                bool created = false;
                while (!created)
                {
                    Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities.Wait(TimeSpan.FromSeconds(10));
                    var stos = StorageClient.StorageAccounts.ListByResourceGroup(rgName);
                    created =
                        stos.Any(
                            t =>
                                StringComparer.OrdinalIgnoreCase.Equals(t.Name, storageAccountName));
                }

                storageAccountOutput = StorageClient.StorageAccounts.GetProperties(rgName, storageAccountName);
            }

            return storageAccountOutput;
        }

        protected ResourceGroup CreateResourceGroup(string rgName)
        {
            ResourceGroup resourceGroup = null;
            try
            {
                resourceGroup = ResourceClient.ResourceGroups.Get(rgName);
            }
            catch { }

            if (resourceGroup == null)
            {
                resourceGroup = ResourceClient.ResourceGroups.CreateOrUpdate(
                             rgName,
                             new ResourceGroup
                             {
                                 Location = DEFAULT_LOCATION,
                                 Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                             });
            }
            return resourceGroup;
        }

        public static string GenerateName(string prefix = null,
           [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="GenerateName_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }

        protected ImageReference GetPlatformVMImage(bool useWindowsImage)
        {
            if (useWindowsImage)
            {
                if (m_windowsImageReference == null)
                {
                    m_windowsImageReference = FindVMImage("MicrosoftWindowsServer", "WindowsServer", "2012-R2-Datacenter");
                }
                return m_windowsImageReference;
            }

            if (m_linuxImageReference == null)
            {
                // If this sku disappears, query latest with 
                // GET https://management.azure.com/subscriptions/<subId>/providers/Microsoft.Compute/locations/SoutheastAsia/publishers/Canonical/artifacttypes/vmimage/offers/UbuntuServer/skus?api-version=2015-06-15
                m_linuxImageReference = FindVMImage("Canonical", "UbuntuServer", "15.10");
            }
            return m_linuxImageReference;
        }

        protected ImageReference FindVMImage(string publisher, string offer, string sku)
        {
            var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineImageResource>();
            query.Top = 1;
            var images = ComputeClient.VirtualMachineImages.List(
                location: DEFAULT_LOCATION, publisherName: publisher, offer: offer, skus: sku,
                odataQuery: query);
            var image = images.First();
            return new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = image.Name
            };
        }

        protected VirtualMachine CreateVirtualMachine(
            string rgName, string vmName, string asName, string storageAccountName, ImageReference imageRef,
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitOperation = true,
            bool hasManagedDisks = false)
        {

            VirtualMachine vm = null;
            try
            {
                vm = ComputeClient.VirtualMachines.Get(rgName, vmName);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            try
            {
                if (vm == null)
                {
                    // Create the resource Group, it might have been already created during StorageAccount creation.
                    var resourceGroup = ResourceClient.ResourceGroups.Get(rgName);

                    PublicIPAddress getPublicIpAddressResponse = createWithPublicIpAddress ? null : CreatePublicIP(rgName);

                    // Do not add Dns server for managed disks, as they cannot resolve managed disk url ( https://md-xyz ) without
                    // explicitly setting up the rules for resolution. The VMs upon booting would need to contact the
                    // DNS server to access the VMStatus agent blob. Without proper Dns resolution, The VMs cannot access the
                    // VMStatus agent blob and there by fail to boot.
                    bool addDnsServer = !hasManagedDisks;
                    Subnet subnetResponse = CreateVNET(rgName, addDnsServer);

                    NetworkInterface nicResponse = CreateNIC(
                        rgName,
                        subnetResponse,
                        getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

                    string asetId = CreateAvailabilitySet(rgName, asName, hasManagedDisks);

                    inputVM = CreateDefaultVMInput(rgName, vmName, storageAccountName, imageRef, asetId, nicResponse.Id, hasManagedDisks);

                    string expectedVMReferenceId = GetVMReferenceId(ComputeClient.SubscriptionId, rgName, inputVM.Name);

                    VirtualMachine createOrUpdateResponse = null;
                    if (waitOperation)
                    {
                        createOrUpdateResponse = ComputeClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
                    }
                    else
                    {
                        createOrUpdateResponse = ComputeClient.VirtualMachines.BeginCreateOrUpdate(rgName, inputVM.Name, inputVM);
                    }

                    Assert.True(createOrUpdateResponse.Name == inputVM.Name);
                    Assert.True(createOrUpdateResponse.Location == inputVM.Location.ToLower().Replace(" ", "") ||
                        createOrUpdateResponse.Location.ToLower() == inputVM.Location.ToLower());

                    Assert.True(
                        createOrUpdateResponse.AvailabilitySet.Id
                            .ToLowerInvariant() == asetId.ToLowerInvariant());
                    //ValidateVM(inputVM, createOrUpdateResponse, expectedVMReferenceId, hasManagedDisks);

                    // CONSIDER dropping this Get and ValidateVM call. Nothing changes in the VM model after it's accepted.
                    // There might have been intent to track the async operation to completion and then check the VM is
                    // still this and okay, but that's not what the code above does and still doesn't make much sense.
                    vm = ComputeClient.VirtualMachines.Get(rgName, inputVM.Name);
                    //ValidateVM(inputVM, vm, expectedVMReferenceId, hasManagedDisks);
                }

                inputVM = vm;
            }
            catch
            {
                //ResourceClient.ResourceGroups.Delete(rgName);
                throw;
            }

            return vm;
        }

        protected void ValidateVM(VirtualMachine vm, VirtualMachine vmOut, string expectedVMReferenceId, bool hasManagedDisks = false)
        {
            Assert.True(vmOut.LicenseType == vm.LicenseType);

            Assert.True(!string.IsNullOrEmpty(vmOut.ProvisioningState));

            Assert.True(vmOut.HardwareProfile.VmSize
                     == vm.HardwareProfile.VmSize);

            Assert.NotNull(vmOut.StorageProfile.OsDisk);

            if (vm.StorageProfile.OsDisk != null)
            {
                Assert.True(vmOut.StorageProfile.OsDisk.Name
                         == vm.StorageProfile.OsDisk.Name);

                Assert.True(vmOut.StorageProfile.OsDisk.Caching
                         == vm.StorageProfile.OsDisk.Caching);

                Assert.NotNull(vmOut.StorageProfile.OsDisk.Vhd);
                Assert.Equal(vm.StorageProfile.OsDisk.Vhd.Uri, vmOut.StorageProfile.OsDisk.Vhd.Uri);
                if (vm.StorageProfile.OsDisk.Image != null && vm.StorageProfile.OsDisk.Image.Uri != null)
                {
                    Assert.Equal(vm.StorageProfile.OsDisk.Image.Uri, vmOut.StorageProfile.OsDisk.Image.Uri);
                }
            }

            if (vm.StorageProfile.DataDisks != null &&
                vm.StorageProfile.DataDisks.Any())
            {
                foreach (var dataDisk in vm.StorageProfile.DataDisks)
                {
                    var dataDiskOut = vmOut.StorageProfile.DataDisks.FirstOrDefault(
                            d => dataDisk.Lun == d.Lun);

                    Assert.NotNull(dataDiskOut);
                    Assert.Equal(dataDiskOut.DiskSizeGB, dataDisk.DiskSizeGB);
                    Assert.Equal(dataDiskOut.CreateOption, dataDisk.CreateOption);
                    if (dataDisk.Caching != null)
                    {
                        Assert.Equal(dataDiskOut.Caching, dataDisk.Caching);
                    }

                    if (dataDisk.Name != null)
                    {
                        Assert.Equal(dataDiskOut.Name, dataDisk.Name);
                    }

                    // Disabling resharper null-ref check as it doesn't seem to understand the not-null assert above.
                    // ReSharper disable PossibleNullReferenceException


                    Assert.NotNull(dataDiskOut.Vhd);
                    Assert.NotNull(dataDiskOut.Vhd.Uri);
                    if (dataDisk.Image != null && dataDisk.Image.Uri != null)
                    {
                        Assert.NotNull(dataDiskOut.Image);
                        Assert.Equal(dataDisk.Image.Uri, dataDiskOut.Image.Uri);
                    }
                    // ReSharper enable PossibleNullReferenceException
                }
            }
        }


        protected PublicIPAddress CreatePublicIP(string rgName)
        {
            // Create publicIP
            string publicIpName = "pip5913";
            string domainNameLabel = "dn5913";

            PublicIPAddress publicIp = null;

            try
            {
                publicIp = NetworkClient.PublicIPAddresses.Get(rgName, publicIpName);
            }
            catch { }

            if(publicIp == null)
            {
                publicIp = new PublicIPAddress()
                {
                    Location = DEFAULT_LOCATION,
                    Tags = new Dictionary<string, string>()
                    {
                        {"key", "value"}
                    },
                    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel
                    }
                };

                var putPublicIpAddressResponse = NetworkClient.PublicIPAddresses.CreateOrUpdate(rgName, publicIpName, publicIp);
                var getPublicIpAddressResponse = NetworkClient.PublicIPAddresses.Get(rgName, publicIpName);

                publicIp = getPublicIpAddressResponse;
            }
            
            return publicIp;
        }

        protected string CreateAvailabilitySet(string rgName, string asName, bool hasManagedDisks = false)
        {
            // Setup availability set
            AvailabilitySet inputAvailabilitySet = null;

            try
            {
                inputAvailabilitySet = ComputeClient.AvailabilitySets.Get(rgName, asName);
            }
            catch { }

            if(inputAvailabilitySet == null)
            {
                var aSet = new AvailabilitySet
                {
                    Location = DEFAULT_LOCATION,
                    Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"}
                    },
                    PlatformFaultDomainCount = hasManagedDisks ? 2 : 3,
                    PlatformUpdateDomainCount = 5,
                };

                // Create an Availability Set and then create a VM inside this availability set
                var asCreateOrUpdateResponse = ComputeClient.AvailabilitySets.CreateOrUpdate(
                    rgName,
                    asName,
                    aSet
                );

                inputAvailabilitySet = asCreateOrUpdateResponse;
            }
            
            var asetId = GetAvailabilitySetRef(ComputeClient.SubscriptionId, rgName, inputAvailabilitySet.Name);
            return asetId;
        }

        protected Subnet CreateVNET(string rgName, bool addDnsServer = true)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = "vn5913";
            string subnetName = "sn5913";

            Subnet subnet = null;

            try
            {
                subnet = NetworkClient.Subnets.Get(rgName, vnetName, subnetName);
            }
            catch { }
            

            if (subnet == null)
            {
                var vnet = new VirtualNetwork()
                {
                    Location = DEFAULT_LOCATION,
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                            {
                                "10.0.0.0/16",
                            }
                    },
                    DhcpOptions = !addDnsServer ? null : new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                            {
                                "10.1.1.1",
                                "10.1.2.4"
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
                var putVnetResponse = NetworkClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
                var getSubnetResponse = NetworkClient.Subnets.Get(rgName, vnetName, subnetName);
                subnet = getSubnetResponse;
            }
            return subnet;
        }

        protected VirtualNetwork CreateVNETWithSubnets(string rgName, int subnetCount = 2)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = GenerateName("vn");

            var vnet = new VirtualNetwork()
            {
                Location = DEFAULT_LOCATION,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                            {
                                "10.0.0.0/16",
                            }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>()
                            {
                                "10.1.1.1",
                                "10.1.2.4"
                            }
                },
            };

            vnet.Subnets = new List<Subnet>();
            for (int i = 1; i <= subnetCount; i++)
            {
                Subnet subnet = new Subnet()
                {
                    Name = GenerateName("sn" + i),
                    AddressPrefix = "10.0." + i + ".0/24",
                };
                vnet.Subnets.Add(subnet);
            }

            var putVnetResponse = NetworkClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
            return putVnetResponse;
        }

        protected NetworkSecurityGroup CreateNsg(string rgName, string nsgName = null)
        {
            nsgName = nsgName ?? GenerateName("nsg");
            var nsgParameters = new NetworkSecurityGroup()
            {
                Location = DEFAULT_LOCATION
            };

            var putNSgResponse = NetworkClient.NetworkSecurityGroups.CreateOrUpdate(rgName, nsgName, nsgParameters);
            var getNsgResponse = NetworkClient.NetworkSecurityGroups.Get(rgName, nsgName);

            return getNsgResponse;
        }

        protected NetworkInterface CreateNIC(string rgName, Subnet subnet, string publicIPaddress, string nicname = null, NetworkSecurityGroup nsg = null)
        {
            // Create Nic
            nicname = "nic5913";
            string ipConfigName = "ip5913";
            NetworkInterface netInterface = null;
            try
            {
                netInterface = NetworkClient.NetworkInterfaces.Get(rgName, nicname);
            }
            catch { }

            if(netInterface == null)
            {
                var nicParameters = new NetworkInterface()
                {
                    Location = DEFAULT_LOCATION,
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
                        Subnet = subnet,
                    }
                },
                    NetworkSecurityGroup = nsg
                };

                if (publicIPaddress != null)
                {
                    nicParameters.IpConfigurations[0].PublicIPAddress = new Microsoft.Azure.Management.Network.Models.PublicIPAddress() { Id = publicIPaddress };
                }

                var putNicResponse = NetworkClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
                var getNicResponse = NetworkClient.NetworkInterfaces.Get(rgName, nicname);
                netInterface = getNicResponse;
            }
            return netInterface;
        }

        protected NetworkInterface CreateMultiIpConfigNIC(string rgName, Subnet subnet, string nicname)
        {
            // Create Nic
            nicname = nicname ?? GenerateName("nic");

            string ipConfigName = GenerateName("ip");
            string ipConfigName2 = GenerateName("ip2");

            var nicParameters = new NetworkInterface()
            {
                Location = DEFAULT_LOCATION,
                Tags = new Dictionary<string, string>()
                {
                    { "key" ,"value" }
                },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        Primary = true,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = subnet,
                    },

                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName2,
                        Primary = false,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = subnet,
                    }
                }
            };

            var putNicResponse = NetworkClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
            var getNicResponse = NetworkClient.NetworkInterfaces.Get(rgName, nicname);
            return getNicResponse;
        }

        protected VirtualMachine CreateDefaultVMInput(string rgName, string vmName, string storageAccountName, ImageReference imageRef, string asetId, string nicId, bool hasManagedDisks = false)
        {
            // Generate Container name to hold disk VHds
            string containerName = "cont5913";
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vhduri = vhdContainer + string.Format("/{0}.vhd", "vhd5913");
            var osVhduri = vhdContainer + string.Format("/os{0}.vhd", "vhdcont5913");

            var vm = new VirtualMachine
            {
                Location = DEFAULT_LOCATION,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                AvailabilitySet = new Microsoft.Azure.Management.Compute.Models.SubResource() { Id = asetId },
                HardwareProfile = new HardwareProfile
                {
                    VmSize = VirtualMachineSizeTypes.StandardA0
                },
                StorageProfile = new StorageProfile
                {
                    ImageReference = imageRef,
                    OsDisk = new OSDisk
                    {
                        Caching = CachingTypes.None,
                        CreateOption = DiskCreateOptionTypes.FromImage,
                        Name = "test",
                        Vhd = hasManagedDisks ? null : new VirtualHardDisk
                        {
                            Uri = osVhduri
                        }
                    }
                },
                NetworkProfile = new NetworkProfile
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>
                        {
                            new NetworkInterfaceReference
                            {
                                Id = nicId
                            }
                        }
                },
                OsProfile = new OSProfile
                {
                    AdminUsername = "Foo12",
                    AdminPassword = "BaR@123" + rgName,
                    ComputerName = "test"
                }
            };

            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetRuntimeProperty("Name").SetValue(vm, vmName);
            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetRuntimeProperty("Type").SetValue(vm, GenerateName("Microsoft.Compute/virtualMachines"));
            return vm;
        }

        public static string GetVMReferenceId(string subId, string resourceGrpName, string vmName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VirtualMachines, vmName);
        }

        public static string GetAvailabilitySetRef(string subId, string resourceGrpName, string availabilitySetName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.AvailabilitySets, availabilitySetName);
        }

        private static string GetEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName);
        }

    }

    public static class ApiConstants
    {
        public const string
            Subscriptions = "subscriptions",
            ResourceGroups = "resourceGroups",
            Providers = "providers",
            VirtualMachines = "virtualMachines",
            AvailabilitySets = "availabilitySets",
            ResourceProviderNamespace = "Microsoft.Compute";
    }

    public static class Constants
    {
        public const string StorageAccountBlobUriTemplate = "https://{0}.blob.core.windows.net/";
    }
}
