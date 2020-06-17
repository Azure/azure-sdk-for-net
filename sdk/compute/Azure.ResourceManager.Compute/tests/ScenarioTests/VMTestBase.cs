// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Network;
using Azure.Management.Network.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.Management.Storage;
using Azure.Management.Storage.Models;
using NUnit.Framework;
using CM = Azure.ResourceManager.Compute.Models;
using NM = Azure.Management.Network.Models;
using Sku = Azure.Management.Storage.Models.Sku;

namespace Azure.ResourceManager.Compute.Tests
{
    public class VMTestBase : ComputeClientBase
    {
        public VMTestBase(bool isAsync)
           : base(isAsync)
        {
        }
        protected const string TestPrefix = "crptestar";
        protected const string PLACEHOLDER = "[PLACEHOLDEr1]";
        protected const string ComputerName = "Test";
        protected bool m_initialized = false;
        protected object m_lock = new object();
        protected string m_subId;
        protected string m_location;
        protected ImageReference m_windowsImageReference, m_linuxImageReference;

        protected void EnsureClientsInitialized(string location)
        {
            m_subId = TestEnvironment.SubscriptionId;

            m_location = location;
        }

        protected async Task<ImageReference> FindVMImage(string publisher, string offer, string sku)
        {
            var images = await VirtualMachineImagesOperations.ListAsync(
                location: m_location, publisherName: publisher, offer: offer, skus: sku,
                top: 1);
            var image = images.Value.First();
            return new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = image.Name
            };
        }
        protected async Task<ImageReference> GetPlatformVMImage(bool useWindowsImage)
        {
            if (useWindowsImage)
            {
                Trace.TraceInformation("Querying available Windows Server image from PIR...");
                m_windowsImageReference = await FindVMImage("MicrosoftWindowsServer", "WindowsServer", "2012-R2-Datacenter");
                return m_windowsImageReference;
            }

            Trace.TraceInformation("Querying available Ubuntu image from PIR...");
            // If this sku disappears, query latest with
            // GET https://management.azure.com/subscriptions/<subId>/providers/Microsoft.Compute/locations/SoutheastAsia/publishers/Canonical/artifacttypes/vmimage/offers/UbuntuServer/skus?api-version=2015-06-15
            m_linuxImageReference = await FindVMImage("Canonical", "UbuntuServer", "19.04");
            return m_linuxImageReference;
        }

        protected DiagnosticsProfile GetDiagnosticsProfile(string storageAccountName)
        {
            return new DiagnosticsProfile
            {
                BootDiagnostics = new BootDiagnostics
                {
                    Enabled = true,
                    StorageUri = string.Format(Constants.StorageAccountBlobUriTemplate, storageAccountName)
                }
            };
        }

        protected DiskEncryptionSettings GetEncryptionSettings(bool addKek = false)
        {
            string testVaultId =
                @"/subscriptions/" + this.m_subId + @"/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";
            string encryptionKeyFakeUri = @"https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bdd703272";

            DiskEncryptionSettings diskEncryptionSettings = new DiskEncryptionSettings
            {
                DiskEncryptionKey = new KeyVaultSecretReference(encryptionKeyFakeUri, new Azure.ResourceManager.Compute.Models.SubResource(testVaultId))
            };

            if (addKek)
            {
                string nonExistentKekUri = @"https://testvault123.vault.azure.net/keys/TestKey/514ceb769c984379a7e0230bdd703272";
                diskEncryptionSettings.KeyEncryptionKey = new KeyVaultKeyReference(nonExistentKekUri, new Azure.ResourceManager.Compute.Models.SubResource(testVaultId));
            }
            return diskEncryptionSettings;
        }

        protected string getDefaultDiskEncryptionSetId()
        {
            //must create first
            return "/subscriptions/0296790d-427c-48ca-b204-8b729bbd8670/resourceGroups/longrunningrg-centraluseuap/providers/Microsoft.Compute/diskEncryptionSets/longlivedBvtDES";
        }

        protected async Task<StorageAccount> CreateStorageAccount(string rgName, string storageAccountName)
        {
            try
            {
                //Create the resource Group.
                var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                    rgName,
                    new ResourceGroup(m_location)
                    {
                        Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                    });
                var stoInput = new StorageAccountCreateParameters(new Sku(SkuName.StandardGRS), Kind.Storage, m_location);

                StorageAccount storageAccountOutput = await WaitForCompletionAsync(await StorageAccountsOperations.StartCreateAsync(rgName,
                    storageAccountName, stoInput));

                var stos = await getAllstos(rgName);
                bool created = false;
                while (!created)
                {
                    //WaitSeconds(10);
                    //var stos =await (StorageAccountsClient.ListByResourceGroupAsync(rgName)).ToEnumerableAsync();
                    created = stos.Any(t => t.Name == storageAccountName);
                    //stos.Any(
                    //    t =>
                    //        StringComparer.OrdinalIgnoreCase.Equals(t.Name, storageAccountName));
                }
                return await StorageAccountsOperations.GetPropertiesAsync(rgName, storageAccountName);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<StorageAccount>> getAllstos(string rgName)
        {
            return await (StorageAccountsOperations.ListByResourceGroupAsync(rgName)).ToEnumerableAsync();
        }

        protected async Task<(VirtualMachine,VirtualMachine)> CreateVM(
            string rgName, string asName, StorageAccount storageAccount, ImageReference imageRef,
            //out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitForCompletion = true,
            bool hasManagedDisks = false)
        {
            return await CreateVM(rgName, asName, storageAccount.Name, imageRef, vmCustomizer, createWithPublicIpAddress, waitForCompletion, hasManagedDisks);
        }

        protected async Task<(VirtualMachine, VirtualMachine)> CreateVM(
            string rgName, string asName, string storageAccountName, ImageReference imageRef,
            //out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitForCompletion = true,
            bool hasManagedDisks = false,
            bool hasDiffDisks = false,
            //string vmSize = VirtualMachineSizeTypes.StandardA0.ToString(),
            string vmSize = "Standard_A0",
            string osDiskStorageAccountType = "Standard_LRS",
            string dataDiskStorageAccountType = "Standard_LRS",
            bool? writeAcceleratorEnabled = null,
            IList<string> zones = null,
            string ppgName = null,
            string diskEncryptionSetId = null)
        {
            try
            {
                // Create the resource Group, it might have been already created during StorageAccount creation.
                await ResourceGroupsOperations.CreateOrUpdateAsync(
                    rgName,
                    new ResourceGroup(m_location)
                    {
                        Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                    });

                PublicIPAddress getPublicIpAddressResponse = createWithPublicIpAddress ? null : await CreatePublicIP(rgName);

                // Do not add Dns server for managed disks, as they cannot resolve managed disk url ( https://md-xyz ) without
                // explicitly setting up the rules for resolution. The VMs upon booting would need to contact the
                // DNS server to access the VMStatus agent blob. Without proper Dns resolution, The VMs cannot access the
                // VMStatus agent blob and there by fail to boot.
                bool addDnsServer = !hasManagedDisks;
                Subnet subnetResponse = await CreateVNET(rgName, addDnsServer);

                NetworkInterface nicResponse = await CreateNIC(
                    rgName,
                    subnetResponse,
                    getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

                string ppgId = ((ppgName != null) ? await CreateProximityPlacementGroup(rgName, ppgName) : null);

                string asetId = await CreateAvailabilitySet(rgName, asName, hasManagedDisks, ppgId: ppgId);

                var inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id, hasManagedDisks, vmSize, osDiskStorageAccountType,
                    dataDiskStorageAccountType, writeAcceleratorEnabled, diskEncryptionSetId);

                if (hasDiffDisks)
                {
                    OSDisk osDisk = inputVM.StorageProfile.OsDisk;
                    osDisk.Caching = CachingTypes.ReadOnly;
                    osDisk.DiffDiskSettings = new DiffDiskSettings
                    {
                        Option = "Local",
                        //The value of 'placement' may not be given
                        //Placement = DiffDiskPlacement.ResourceDisk
                    };
                }

                if (zones != null)
                {
                    inputVM.AvailabilitySet = null;
                    // If no vmSize is provided and we are using the default value, change the default value for VMs with Zones.
                    if (vmSize == VirtualMachineSizeTypes.StandardA0)
                    {
                        vmSize = VirtualMachineSizeTypes.StandardA1V2.ToString();
                    }
                    inputVM.HardwareProfile.VmSize = vmSize;
                    inputVM.Zones = zones;
                }

                if (vmCustomizer != null)
                {
                    vmCustomizer(inputVM);
                }

                string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                VirtualMachine createOrUpdateResponse = null;
                if (waitForCompletion)
                {
                    // CreateOrUpdate polls for the operation completion and returns once the operation reaches a terminal state
                    createOrUpdateResponse = (await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, inputVM.Name, inputVM))).Value;
                }
                else
                {
                    // BeginCreateOrUpdate returns immediately after the request is accepted by CRP
                    createOrUpdateResponse = (await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, inputVM.Name, inputVM))).Value;
                }

                Assert.True(createOrUpdateResponse.Name == inputVM.Name);
                Assert.True(createOrUpdateResponse.Location == inputVM.Location.ToLower().Replace(" ", "") ||
                    createOrUpdateResponse.Location.ToLower() == inputVM.Location.ToLower());

                bool hasUserDefinedAvSet = zones == null && !(VirtualMachinePriorityTypes.Spot.Equals(inputVM.Priority) || VirtualMachinePriorityTypes.Low.Equals(inputVM.Priority));
                //if (hasUserDefinedAvSet)
                //{
                //    Assert.True(createOrUpdateResponse.AvailabilitySet.Id.ToLowerInvariant() == asetId.ToLowerInvariant());
                //}
                //else if (zones != null)
                //{
                //    Assert.True(createOrUpdateResponse.Zones.Count == 1);
                //    Assert.True(createOrUpdateResponse.Zones.FirstOrDefault() == zones.FirstOrDefault());
                //}

                // The intent here is to validate that the GET response is as expected.
                var getResponse = await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name);
                ValidateVM(inputVM, getResponse, expectedVMReferenceId, hasManagedDisks, writeAcceleratorEnabled: writeAcceleratorEnabled, hasDiffDisks: hasDiffDisks, hasUserDefinedAS: hasUserDefinedAvSet, expectedPpgReferenceId: ppgId);

                return (getResponse,inputVM);
            }
            catch
            {
                // Just trigger DeleteRG, rest would be taken care of by ARM
                throw;
            }
        }

        protected async Task<PublicIPPrefix> CreatePublicIPPrefix(string rgName, int prefixLength)
        {
            string publicIpPrefixName = Recording.GenerateAssetName("piprefix");

            var publicIpPrefix = new PublicIPPrefix()
            {
                Sku = new PublicIPPrefixSku() { Name ="Standard" },
                Location = m_location,
                PrefixLength = prefixLength
            };

            var putPublicIpPrefixResponse = await WaitForCompletionAsync(await PublicIPPrefixesOperations.StartCreateOrUpdateAsync(rgName, publicIpPrefixName, publicIpPrefix));
            var getPublicIpPrefixResponse = await PublicIPPrefixesOperations.GetAsync(rgName, publicIpPrefixName);

            return getPublicIpPrefixResponse;
        }

        protected async Task<PublicIPAddress> CreatePublicIP(string rgName)
        {
            // Create publicIP
            string publicIpName = Recording.GenerateAssetName("pip");
            string domainNameLabel = Recording.GenerateAssetName("dn");

            var publicIp = new PublicIPAddress()
            {
                Location = m_location,
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

            var putPublicIpAddressResponse = await WaitForCompletionAsync(await PublicIPAddressesOperations.StartCreateOrUpdateAsync(rgName, publicIpName, publicIp));
            var getPublicIpAddressResponse = await PublicIPAddressesOperations.GetAsync(rgName, publicIpName);
            return getPublicIpAddressResponse;
        }

        protected async Task<Subnet> CreateVNET(string rgName, bool addDnsServer = true)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("vn");
            string subnetName = Recording.GenerateAssetName("sn");

            var vnet = new VirtualNetwork()
            {
                Location = m_location,
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
            VirtualNetwork putVnetResponse = (await WaitForCompletionAsync(await VirtualNetworksOperations.StartCreateOrUpdateAsync(rgName, vnetName, vnet))).Value;
            var getSubnetResponse = await SubnetsOperations.GetAsync(rgName, vnetName, subnetName);
            return getSubnetResponse;
        }

        protected async Task<VirtualNetwork> CreateVNETWithSubnets(string rgName, int subnetCount = 2)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("vn");

            var vnet = new VirtualNetwork()
            {
                Location = m_location,
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
                    Name = Recording.GenerateAssetName("sn" + i),
                    AddressPrefix = "10.0." + i + ".0/24",
                };
                vnet.Subnets.Add(subnet);
            }

            var putVnetResponse = await WaitForCompletionAsync(await VirtualNetworksOperations.StartCreateOrUpdateAsync(rgName, vnetName, vnet));
            return putVnetResponse;
        }

        protected async Task<NetworkSecurityGroup> CreateNsg(string rgName, string nsgName = null)
        {
            nsgName = nsgName ?? Recording.GenerateAssetName("nsg");
            var nsgParameters = new NetworkSecurityGroup()
            {
                Location = m_location
            };

            var putNSgResponse = await WaitForCompletionAsync(await NetworkSecurityGroupsOperations.StartCreateOrUpdateAsync(rgName, nsgName, nsgParameters));
            var getNsgResponse = await NetworkSecurityGroupsOperations.GetAsync(rgName, nsgName);

            return getNsgResponse;
        }

        protected async Task<NetworkInterface> CreateNIC(string rgName, Subnet subnet, string publicIPaddress, string nicname = null, NetworkSecurityGroup nsg = null)
        {
            // Create Nic
            nicname = nicname ?? Recording.GenerateAssetName("nic");
            string ipConfigName = Recording.GenerateAssetName("ip");

            var nicParameters = new NetworkInterface()
            {
                Location = m_location,
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
                nicParameters.IpConfigurations[0].PublicIPAddress = new Azure.Management.Network.Models.PublicIPAddress() { Id = publicIPaddress };
            }

            var putNicResponse = await WaitForCompletionAsync(await NetworkInterfacesOperations.StartCreateOrUpdateAsync(rgName, nicname, nicParameters));
            var getNicResponse = await NetworkInterfacesOperations.GetAsync(rgName, nicname);
            return getNicResponse;
        }

        protected async Task<NetworkInterface> CreateMultiIpConfigNIC(string rgName, Subnet subnet, string nicname)
        {
            // Create Nic
            nicname = nicname ?? Recording.GenerateAssetName("nic");

            string ipConfigName = Recording.GenerateAssetName("ip");
            string ipConfigName2 = Recording.GenerateAssetName("ip2");

            var nicParameters = new NetworkInterface()
            {
                Location = m_location,
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

            var putNicResponse = await WaitForCompletionAsync(await NetworkInterfacesOperations.StartCreateOrUpdateAsync(rgName, nicname, nicParameters));
            var getNicResponse = await NetworkInterfacesOperations.GetAsync(rgName, nicname);
            return getNicResponse;
        }

        private static string GetChildAppGwResourceId(string subscriptionId,
                                                        string resourceGroupName,
                                                        string appGwname,
                                                        string childResourceType,
                                                        string childResourceName)
        {
            return string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/applicationGateways/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    appGwname,
                    childResourceType,
                    childResourceName);
        }

        protected async Task<ApplicationGateway> CreateApplicationGateway(string rgName, Subnet subnet, string gatewayName = null)
        {
            gatewayName = gatewayName ?? Recording.GenerateAssetName("gw");
            var gatewayIPConfigName = Recording.GenerateAssetName("gwIp");
            var frontendIPConfigName = Recording.GenerateAssetName("fIp");
            var frontendPortName = Recording.GenerateAssetName("fPort");
            var backendAddressPoolName = Recording.GenerateAssetName("pool");
            var backendHttpSettingsName = Recording.GenerateAssetName("setting");
            var requestRoutingRuleName = Recording.GenerateAssetName("rule");
            var httpListenerName = Recording.GenerateAssetName("listener");

            var gatewayIPConfig = new ApplicationGatewayIPConfiguration()
            {
                Name = gatewayIPConfigName,
                Subnet = new Azure.Management.Network.Models.SubResource { Id = subnet.Id },
            };

            var frontendIPConfig = new ApplicationGatewayFrontendIPConfiguration()
            {
                Name = frontendIPConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new Azure.Management.Network.Models.SubResource { Id = subnet.Id }
            };

            ApplicationGatewayFrontendPort frontendPort = new ApplicationGatewayFrontendPort()
            {
                Name = frontendPortName,
                Port = 80
            };

            var backendAddressPool = new ApplicationGatewayBackendAddressPool()
            {
                Name = backendAddressPoolName,
            };

            var backendHttpSettings = new ApplicationGatewayBackendHttpSettings()
            {
                Name = backendHttpSettingsName,
                Port = 80,
                Protocol = ApplicationGatewayProtocol.Http,
                CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled,
            };

            var httpListener = new ApplicationGatewayHttpListener()
            {
                Name = httpListenerName,
                FrontendPort = new Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "frontendPorts", frontendPortName)
                },
                FrontendIPConfiguration = new Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "frontendIPConfigurations", frontendIPConfigName)
                },
                SslCertificate = null,
                Protocol = ApplicationGatewayProtocol.Http
            };

            var requestRoutingRules = new ApplicationGatewayRequestRoutingRule()
            {
                Name = requestRoutingRuleName,
                RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                HttpListener = new Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "httpListeners", httpListenerName)
                },
                BackendAddressPool = new Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "backendAddressPools", backendAddressPoolName)
                },
                BackendHttpSettings = new Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "backendHttpSettingsCollection", backendHttpSettingsName)
                }
            };

            var appGw = new ApplicationGateway()
            {
                Location = m_location,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.StandardSmall,
                    Tier = ApplicationGatewayTier.Standard,
                    Capacity = 2
                },
                GatewayIPConfigurations = new List<ApplicationGatewayIPConfiguration>()
                {
                    gatewayIPConfig,
                },
                FrontendIPConfigurations = new List<ApplicationGatewayFrontendIPConfiguration>()
                {
                    frontendIPConfig,
                },
                FrontendPorts = new List<ApplicationGatewayFrontendPort>
                {
                    frontendPort,
                },
                BackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                {
                    backendAddressPool,
                },
                BackendHttpSettingsCollection = new List<ApplicationGatewayBackendHttpSettings>
                {
                    backendHttpSettings,
                },
                HttpListeners = new List<ApplicationGatewayHttpListener>
                {
                    httpListener,
                },
                RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                {
                    requestRoutingRules,
                }
            };

            var putGwResponse = await WaitForCompletionAsync(await ApplicationGatewaysOperations.StartCreateOrUpdateAsync(rgName, gatewayName, appGw));
            var getGwResponse = await ApplicationGatewaysOperations.GetAsync(rgName, gatewayName);
            return getGwResponse;
        }

        protected async Task<LoadBalancer> CreatePublicLoadBalancerWithProbe(string rgName, PublicIPAddress publicIPAddress)
        {
            var loadBalancerName = Recording.GenerateAssetName("lb");
            var frontendIPConfigName = Recording.GenerateAssetName("feip");
            var backendAddressPoolName = Recording.GenerateAssetName("beap");
            var loadBalancingRuleName = Recording.GenerateAssetName("lbr");
            var loadBalancerProbeName = Recording.GenerateAssetName("lbp");

            var frontendIPConfigId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/frontendIPConfigurations/{frontendIPConfigName}";
            var backendAddressPoolId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/backendAddressPools/{backendAddressPoolName}";
            var probeId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{loadBalancerProbeName}";

            var putLBResponse = await WaitForCompletionAsync(await LoadBalancersOperations.StartCreateOrUpdateAsync(rgName, loadBalancerName, new LoadBalancer
            {
                Location = m_location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>
                {
                    new FrontendIPConfiguration
                    {
                        Name = frontendIPConfigName,
                        PublicIPAddress = publicIPAddress
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>
                {
                    new BackendAddressPool
                    {
                        Name = backendAddressPoolName
                    }
                },
                LoadBalancingRules = new List<LoadBalancingRule>
                {
                    new LoadBalancingRule
                    {
                        Name = loadBalancingRuleName,
                        LoadDistribution = "Default",
                        FrontendIPConfiguration = new NM.SubResource
                        {
                            Id = frontendIPConfigId
                        },
                        BackendAddressPool = new NM.SubResource
                        {
                            Id = backendAddressPoolId
                        },
                        Protocol = "Tcp",
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
                        IdleTimeoutInMinutes = 5,
                        Probe = new NM.SubResource
                        {
                            Id = probeId
                        }
                    }
                },
                Probes = new List<Probe>
                {
                    new Probe
                    {
                        Port = 3389, // RDP port
                        IntervalInSeconds = 5,
                        NumberOfProbes = 2,
                        Name = loadBalancerProbeName,
                        Protocol = "Tcp",
                    }
                }
            }));

            var getLBResponse = await LoadBalancersOperations.GetAsync(rgName, loadBalancerName);
            return getLBResponse;
        }

        protected async Task<string> CreateAvailabilitySet(string rgName, string asName, bool hasManagedDisks = false, string ppgId = null)
        {
            // Setup availability set
            var inputAvailabilitySet = new AvailabilitySet(m_location)
            {
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"}
                    },
                PlatformFaultDomainCount = hasManagedDisks ? 1 : 3,
                PlatformUpdateDomainCount = hasManagedDisks ? 1 : 5,
                Sku = new CM.Sku
                {
                    Name = hasManagedDisks ? AvailabilitySetSkuTypes.Aligned.ToString() : AvailabilitySetSkuTypes.Classic.ToString()
                }
            };

            if (ppgId != null)
            {
                inputAvailabilitySet.ProximityPlacementGroup = new Azure.ResourceManager.Compute.Models.SubResource() { Id = ppgId };
            }

            // Create an Availability Set and then create a VM inside this availability set
            var asCreateOrUpdateResponse = await AvailabilitySetsOperations.CreateOrUpdateAsync(
                rgName,
                asName,
                inputAvailabilitySet
            );
            var asetId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asCreateOrUpdateResponse.Value.Name);
            return asetId;
        }

        public async Task<string> CreateProximityPlacementGroup(string subId, string rgName, string ppgName, ComputeManagementClient client, string location)
        {
            // Setup ProximityPlacementGroup
            var inputProximityPlacementGroup = new ProximityPlacementGroup(location)
            {
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                ProximityPlacementGroupType = ProximityPlacementGroupType.Standard
            };

            // Create a ProximityPlacementGroup and then create a VM inside this ProximityPlacementGroup
            ProximityPlacementGroup ppgCreateOrUpdateResponse = await ProximityPlacementGroupsOperations.CreateOrUpdateAsync(
                rgName,
                ppgName,
                inputProximityPlacementGroup
            );

            return Helpers.GetProximityPlacementGroupRef(subId, rgName, ppgCreateOrUpdateResponse.Name);
        }

        protected async Task<string> CreateProximityPlacementGroup(string rgName, string ppgName)
        {
            return await CreateProximityPlacementGroup(m_subId, rgName, ppgName, ComputeManagementClient, m_location);
        }

        protected VirtualMachine CreateDefaultVMInput(string rgName, string storageAccountName, ImageReference imageRef, string asetId, string nicId, bool hasManagedDisks = false,
            string vmSize = "Standard_A0", string osDiskStorageAccountType = "Standard_LRS", string dataDiskStorageAccountType = "Standard_LRS", bool? writeAcceleratorEnabled = null,
            string diskEncryptionSetId = null)
        {
            // Generate Container name to hold disk VHds
            string containerName = Recording.GenerateAssetName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vhduri = vhdContainer + string.Format("/{0}.vhd", Recording.GenerateAssetName(TestPrefix));
            var osVhduri = vhdContainer + string.Format("/os{0}.vhd", Recording.GenerateAssetName(TestPrefix));

            if (writeAcceleratorEnabled.HasValue)
            {
                // WriteAccelerator is only allowed on VMs with Managed disks
                Assert.True(hasManagedDisks);
            }
            var vm = new VirtualMachine(
                null, Recording.GenerateAssetName("vm"),"Microsoft.Compute/virtualMachines", m_location,
                new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } }, null,null, null, null,
                new HardwareProfile
                {
                    VmSize = vmSize
                },
                new StorageProfile
                {
                    ImageReference = imageRef,
                    OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
                    {
                        Caching = CachingTypes.None,
                        WriteAcceleratorEnabled = writeAcceleratorEnabled,
                        Name = "test",
                        Vhd = hasManagedDisks ? null : new VirtualHardDisk
                        {
                            Uri = osVhduri
                        },
                        ManagedDisk = !hasManagedDisks ? null : new ManagedDiskParameters
                        {
                            StorageAccountType = osDiskStorageAccountType,
                            DiskEncryptionSet = diskEncryptionSetId == null ? null :
                                new DiskEncryptionSetParameters()
                                {
                                    Id = diskEncryptionSetId
                                }
                        }
                    },
                    DataDisks = !hasManagedDisks ? null : new List<DataDisk>()
                    {
                        new DataDisk(0, DiskCreateOptionTypes.Empty)
                        {
                            Caching = CachingTypes.None,
                            WriteAcceleratorEnabled = writeAcceleratorEnabled,
                            DiskSizeGB = 30,
                            ManagedDisk = new ManagedDiskParameters()
                            {
                                StorageAccountType = dataDiskStorageAccountType,
                                DiskEncryptionSet = diskEncryptionSetId == null ? null :
                                    new DiskEncryptionSetParameters()
                                    {
                                        Id = diskEncryptionSetId
                                    }
                            }
                        }
                    },
                }, null,
                new OSProfile
                {
                    AdminUsername = "Foo12",
                    AdminPassword = PLACEHOLDER,
                    ComputerName = ComputerName
                },
                new CM.NetworkProfile
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>
                        {
                            new NetworkInterfaceReference
                            {
                                Id = nicId
                            }
                        }
                }, null, null, null, null, null, null, null, null, null, null, null, null);
            //var vm = new VirtualMachine(m_location)
            //{
            //    Location = m_location,
            //    Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
            //    AvailabilitySet = new Azure.ResourceManager.Compute.Models.SubResource() { Id = asetId },
            //    HardwareProfile = new HardwareProfile
            //    {
            //        VmSize = vmSize
            //    },
            //    StorageProfile = new StorageProfile
            //    {
            //        ImageReference = imageRef,
            //        OsDisk = new OSDisk(DiskCreateOptionTypes.FromImage)
            //        {
            //            Caching = CachingTypes.None,
            //            WriteAcceleratorEnabled = writeAcceleratorEnabled,
            //            Name = "test",
            //            Vhd = hasManagedDisks ? null : new VirtualHardDisk
            //            {
            //                Uri = osVhduri
            //            },
            //            ManagedDisk = !hasManagedDisks ? null : new ManagedDiskParameters
            //            {
            //                StorageAccountType = osDiskStorageAccountType,
            //                DiskEncryptionSet = diskEncryptionSetId == null ? null :
            //                    new DiskEncryptionSetParameters()
            //                    {
            //                        Id = diskEncryptionSetId
            //                    }
            //            }
            //        },
            //        DataDisks = !hasManagedDisks ? null : new List<DataDisk>()
            //        {
            //            new DataDisk(0, DiskCreateOptionTypes.Empty)
            //            {
            //                Caching = CachingTypes.None,
            //                WriteAcceleratorEnabled = writeAcceleratorEnabled,
            //                DiskSizeGB = 30,
            //                ManagedDisk = new ManagedDiskParameters()
            //                {
            //                    StorageAccountType = dataDiskStorageAccountType,
            //                    DiskEncryptionSet = diskEncryptionSetId == null ? null :
            //                        new DiskEncryptionSetParameters()
            //                        {
            //                            Id = diskEncryptionSetId
            //                        }
            //                }
            //            }
            //        },
            //    },
            //    NetworkProfile = new CM.NetworkProfile
            //    {
            //        NetworkInterfaces = new List<NetworkInterfaceReference>
            //            {
            //                new NetworkInterfaceReference
            //                {
            //                    Id = nicId
            //                }
            //            }
            //    },
            //    OsProfile = new OSProfile
            //    {
            //        AdminUsername = "Foo12",
            //        AdminPassword = PLACEHOLDER,
            //        ComputerName = ComputerName
            //    }
            //};

            if (dataDiskStorageAccountType == StorageAccountTypes.UltraSSDLRS)
            {
                vm.AdditionalCapabilities = new AdditionalCapabilities
                {
                    UltraSSDEnabled = true
                };
            }
            //typeof( Azure.ResourceManager.Compute.Models.Resource).GetProperty("Name").SetValue(vm, Recording.GenerateAssetName("vm"));
            //typeof( Azure.ResourceManager.Compute.Models.Resource).GetProperty("Type").SetValue(vm, Recording.GenerateAssetName("Microsoft.Compute/virtualMachines"));
            return vm;
        }

        protected async Task<DedicatedHostGroup> CreateDedicatedHostGroup(string rgName, string dedicatedHostGroupName)
        {
            await ResourceGroupsOperations.CreateOrUpdateAsync(
                   rgName,
                   new ResourceGroup(m_location)
                   {
                       Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                   });

            DedicatedHostGroup dedicatedHostGroup = new DedicatedHostGroup(m_location)
            {
                Zones = new List<string> { "1" },
                PlatformFaultDomainCount = 1
            };
            return await DedicatedHostGroupsOperations.CreateOrUpdateAsync(rgName, dedicatedHostGroupName, dedicatedHostGroup);
        }

        protected async Task<DedicatedHost> CreateDedicatedHost(string rgName, string dedicatedHostGroupName, string dedicatedHostName)
        {
            //Check if DedicatedHostGroup already exist and if does not exist, create one.
            DedicatedHostGroup existingDHG = await DedicatedHostGroupsOperations.GetAsync(rgName, dedicatedHostGroupName);
            if (existingDHG == null)
            {
                existingDHG = await CreateDedicatedHostGroup(rgName, dedicatedHostGroupName);
            }
            var response =await DedicatedHostsOperations.StartCreateOrUpdateAsync(rgName, dedicatedHostGroupName, dedicatedHostName,
                new DedicatedHost(m_location, new CM.Sku() { Name= "ESv3-Type1"})
                {
                    Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
                });
            //var xx = return await response.WaitForCompletionAsync()
            return await WaitForCompletionAsync(response);
            //return await DedicatedHostsClient.StartCreateOrUpdateAsync(rgName, dedicatedHostGroupName, dedicatedHostName,
            //    new DedicatedHost(m_location,new Sku() { Name= "ESv3-Type1" })
            //    {
            //        Tags = new Dictionary<string, string>() { { rgName, Recording.UtcNow.ToString("u") } }
            //    });
        }

        protected void ValidateVM(VirtualMachine vm, VirtualMachine vmOut, string expectedVMReferenceId, bool hasManagedDisks = false, bool hasUserDefinedAS = true,
            bool? writeAcceleratorEnabled = null, bool hasDiffDisks = false, string expectedLocation = null, string expectedPpgReferenceId = null)
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

                if (hasManagedDisks)
                {
                    // vhd is null for managed disks
                    Assert.NotNull(vmOut.StorageProfile.OsDisk.ManagedDisk);
                    Assert.NotNull(vmOut.StorageProfile.OsDisk.ManagedDisk.StorageAccountType);
                    if (vm.StorageProfile.OsDisk.ManagedDisk != null
                        && vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType != null)
                    {
                        Assert.True(vmOut.StorageProfile.OsDisk.ManagedDisk.StorageAccountType
                                    == vm.StorageProfile.OsDisk.ManagedDisk.StorageAccountType);
                    }
                    else
                    {
                        Assert.NotNull(vmOut.StorageProfile.OsDisk.ManagedDisk.StorageAccountType);
                    }

                    if (vm.StorageProfile.OsDisk.ManagedDisk != null
                        && vm.StorageProfile.OsDisk.ManagedDisk.Id != null)
                    {
                        Assert.True(vmOut.StorageProfile.OsDisk.ManagedDisk.Id
                                    == vm.StorageProfile.OsDisk.ManagedDisk.Id);
                    }
                    else
                    {
                        Assert.NotNull(vmOut.StorageProfile.OsDisk.ManagedDisk.Id);
                    }

                    //if (hasDiffDisks)
                    //{
                    //    Assert.True(vmOut.StorageProfile.OsDisk.DiffDiskSettings.Option == vm.StorageProfile.OsDisk.DiffDiskSettings.Option);
                    //}
                    //else
                    //{
                    //    Assert.Null(vm.StorageProfile.OsDisk.DiffDiskSettings);
                    //}

                    if (writeAcceleratorEnabled.HasValue)
                    {
                        Assert.AreEqual(writeAcceleratorEnabled.Value, vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                    else
                    {
                        Assert.Null(vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                }
                else
                {
                    Assert.NotNull(vmOut.StorageProfile.OsDisk.Vhd);
                    Assert.AreEqual(vm.StorageProfile.OsDisk.Vhd.Uri, vmOut.StorageProfile.OsDisk.Vhd.Uri);
                    if (vm.StorageProfile.OsDisk.Image != null && vm.StorageProfile.OsDisk.Image.Uri != null)
                    {
                        Assert.AreEqual(vm.StorageProfile.OsDisk.Image.Uri, vmOut.StorageProfile.OsDisk.Image.Uri);
                    }
                }
            }

            if (vm.StorageProfile.DataDisks != null &&
                vm.StorageProfile.DataDisks.Any())
            {
                if (vm.StorageProfile.DataDisks.Any(dd => dd.ManagedDisk != null && dd.ManagedDisk.StorageAccountType == StorageAccountTypes.UltraSSDLRS))
                {
                    Assert.NotNull(vm.AdditionalCapabilities);
                    Assert.NotNull(vm.AdditionalCapabilities.UltraSSDEnabled);
                    Assert.True(vm.AdditionalCapabilities.UltraSSDEnabled.Value);
                }
                else
                {
                    Assert.Null(vm.AdditionalCapabilities);
                }

                foreach (var dataDisk in vm.StorageProfile.DataDisks)
                {
                    var dataDiskOut = vmOut.StorageProfile.DataDisks.FirstOrDefault(d => dataDisk.Lun == d.Lun);

                    Assert.NotNull(dataDiskOut);
                    Assert.AreEqual(dataDiskOut.DiskSizeGB, dataDisk.DiskSizeGB);
                    Assert.AreEqual(dataDiskOut.CreateOption, dataDisk.CreateOption);
                    if (dataDisk.Caching != null)
                    {
                        Assert.AreEqual(dataDiskOut.Caching, dataDisk.Caching);
                    }

                    if (dataDisk.Name != null)
                    {
                        Assert.AreEqual(dataDiskOut.Name, dataDisk.Name);
                    }

                    // Disabling resharper null-ref check as it doesn't seem to understand the not-null assert above.
                    // ReSharper disable PossibleNullReferenceException

                    if (hasManagedDisks)
                    {
                        Assert.NotNull(dataDiskOut.ManagedDisk);
                        Assert.NotNull(dataDiskOut.ManagedDisk.StorageAccountType);
                        if (dataDisk.ManagedDisk != null && dataDisk.ManagedDisk.StorageAccountType != null)
                        {
                            Assert.True(dataDiskOut.ManagedDisk.StorageAccountType ==
                                        dataDisk.ManagedDisk.StorageAccountType);
                        }
                        Assert.NotNull(dataDiskOut.ManagedDisk.Id);
                        if (writeAcceleratorEnabled.HasValue)
                        {
                            Assert.AreEqual(writeAcceleratorEnabled.Value, dataDiskOut.WriteAcceleratorEnabled);
                        }
                        else
                        {
                            Assert.Null(vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                        }
                    }
                    else
                    {
                        Assert.NotNull(dataDiskOut.Vhd);
                        Assert.NotNull(dataDiskOut.Vhd.Uri);
                        if (dataDisk.Image != null && dataDisk.Image.Uri != null)
                        {
                            Assert.NotNull(dataDiskOut.Image);
                            Assert.AreEqual(dataDisk.Image.Uri, dataDiskOut.Image.Uri);
                        }
                        Assert.Null(vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                    // ReSharper enable PossibleNullReferenceException
                }
            }

            if (vm.OsProfile != null &&
               vm.OsProfile.Secrets != null &&
               vm.OsProfile.Secrets.Any())
            {
                foreach (var secret in vm.OsProfile.Secrets)
                {
                    Assert.NotNull(secret.VaultCertificates);
                    var secretOut = vmOut.OsProfile.Secrets.FirstOrDefault(s => string.Equals(secret.SourceVault.Id, s.SourceVault.Id));
                    Assert.NotNull(secretOut);

                    // Disabling resharper null-ref check as it doesn't seem to understand the not-null assert above.
                    // ReSharper disable PossibleNullReferenceException

                    Assert.NotNull(secretOut.VaultCertificates);
                    var VaultCertComparer = new VaultCertComparer();
                    Assert.True(secretOut.VaultCertificates.SequenceEqual(secret.VaultCertificates, VaultCertComparer));

                    // ReSharper enable PossibleNullReferenceException
                }
            }

            //if (hasUserDefinedAS)
            //{
            //    Assert.NotNull(vmOut.AvailabilitySet);
            //    Assert.True(vm.AvailabilitySet.Id.ToLowerInvariant() == vmOut.AvailabilitySet.Id.ToLowerInvariant());
            //}

            Assert.AreEqual(vm.Location, vmOut.Location);

            ValidatePlan(vm.Plan, vmOut.Plan);
            Assert.NotNull(vmOut.VmId);

            if (expectedPpgReferenceId != null)
            {
                Assert.NotNull(vmOut.ProximityPlacementGroup);
                Assert.AreEqual(expectedPpgReferenceId, vmOut.ProximityPlacementGroup.Id);
            }
            else
            {
                Assert.Null(vmOut.ProximityPlacementGroup);
            }
        }

        protected void ValidateVMInstanceView(VirtualMachine vmIn, VirtualMachine vmOut, bool hasManagedDisks = false,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null)
        {
            Assert.NotNull(vmOut.InstanceView);
            ValidateVMInstanceView(vmIn, vmOut.InstanceView, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion);
        }

        protected void ValidateVMInstanceView(VirtualMachine vmIn, VirtualMachineInstanceView vmInstanceView, bool hasManagedDisks = false,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null)
        {
            ValidateVMInstanceView(vmInstanceView, hasManagedDisks,
                !hasManagedDisks ? vmIn.StorageProfile.OsDisk.Name : null,
                expectedComputerName, expectedOSName, expectedOSVersion);
        }

        private void ValidateVMInstanceView(VirtualMachineInstanceView vmInstanceView, bool hasManagedDisks = false, string osDiskName = null,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null)
        {
            bool haveNotNull= false;
            foreach (var eachStatuse in vmInstanceView.Statuses)
            {
                if (!string.IsNullOrEmpty(eachStatuse.Code))
                {
                    haveNotNull = true;
                    break;
                }
            }
            Assert.IsTrue(haveNotNull);
            //Assert.Contains(vmInstanceView.Statuses, s => !string.IsNullOrEmpty(s.Code));

            if (!hasManagedDisks)
            {
                Assert.NotNull(vmInstanceView.Disks);
                Assert.True(vmInstanceView.Disks.Any());

                if (osDiskName != null)
                {
                    bool containosDiskName = false;
                    foreach (var eachDisk in vmInstanceView.Disks)
                    {
                        if (eachDisk.Name== osDiskName)
                        {
                            containosDiskName = true;
                            break;
                        }
                    }
                    Assert.IsTrue(containosDiskName);
                    //Assert.Contains(vmInstanceView.Disks, x => x.Name == osDiskName);
                }

                DiskInstanceView diskInstanceView = vmInstanceView.Disks.First();
                Assert.NotNull(diskInstanceView);
                Assert.NotNull(diskInstanceView.Statuses[0].DisplayStatus);
                Assert.NotNull(diskInstanceView.Statuses[0].Code);
                Assert.NotNull(diskInstanceView.Statuses[0].Level);
                //Assert.NotNull(diskInstanceView.Statuses[0].Message); // TODO: it's null somtimes.
                //Assert.NotNull(diskInstanceView.Statuses[0].Time);    // TODO: it's null somtimes.
            }

            if (expectedComputerName != null)
            {
                Assert.AreEqual(expectedComputerName, vmInstanceView.ComputerName);
            }
            if (expectedOSName != null)
            {
                Assert.AreEqual(expectedOSName, vmInstanceView.OsName);
            }
            if (expectedOSVersion != null)
            {
                Assert.AreEqual(expectedOSVersion, vmInstanceView.OsVersion);
            }
        }

        protected void ValidatePlan(Azure.ResourceManager.Compute.Models.Plan inputPlan, Azure.ResourceManager.Compute.Models.Plan outPutPlan)
        {
            if (inputPlan == null
                 || outPutPlan == null
               )
            {
                Assert.AreEqual(inputPlan, outPutPlan);
                return;
            }

            Assert.AreEqual(inputPlan.Name, outPutPlan.Name);
            Assert.AreEqual(inputPlan.Publisher, outPutPlan.Publisher);
            Assert.AreEqual(inputPlan.Product, outPutPlan.Product);
            Assert.AreEqual(inputPlan.PromotionCode, outPutPlan.PromotionCode);
        }

        protected void ValidateBootDiagnosticsInstanceView(BootDiagnosticsInstanceView bootDiagnosticsInstanceView, bool hasError)
        {
            if (hasError)
            {
                Assert.Null(bootDiagnosticsInstanceView.ConsoleScreenshotBlobUri);
                Assert.Null(bootDiagnosticsInstanceView.SerialConsoleLogBlobUri);
                Assert.NotNull(bootDiagnosticsInstanceView.Status);
            }
            else
            {
                Assert.NotNull(bootDiagnosticsInstanceView.ConsoleScreenshotBlobUri);
                Assert.NotNull(bootDiagnosticsInstanceView.SerialConsoleLogBlobUri);
                Assert.Null(bootDiagnosticsInstanceView.Status);
            }
        }
    }
}
