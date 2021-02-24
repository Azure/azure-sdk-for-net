// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using CM=Microsoft.Azure.Management.Compute.Models;
using NM=Microsoft.Azure.Management.Network.Models;

namespace Compute.Tests
{
    public class VMTestBase
    {
        protected const string TestPrefix = "crptestar";
        protected const string PLACEHOLDER = "[PLACEHOLDEr1]";
        protected const string ComputerName = "Test";

        protected ResourceManagementClient m_ResourcesClient;
        protected ComputeManagementClient m_CrpClient;
        protected StorageManagementClient m_SrpClient;
        protected NetworkManagementClient m_NrpClient;
        protected ManagedServiceIdentityClient m_MsiClient;

        protected bool m_initialized = false;
        protected object m_lock = new object();
        protected string m_subId;
        protected string m_location;
        ImageReference m_windowsImageReference, m_linuxImageReference;

        protected void EnsureClientsInitialized(MockContext context)
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        m_ResourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        m_CrpClient = ComputeManagementTestUtilities.GetComputeManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        m_SrpClient = ComputeManagementTestUtilities.GetStorageManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        m_NrpClient = ComputeManagementTestUtilities.GetNetworkManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        m_MsiClient = ComputeManagementTestUtilities.GetManagedServiceIdentityClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                        m_subId = m_CrpClient.SubscriptionId;
                        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION")))
                        {
                            m_location = ComputeManagementTestUtilities.DefaultLocation;
                        }
                        else
                        {
                            m_location = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION").Replace(" ", "");
                        }
                    }
                }
            }
        }

        protected ImageReference FindVMImage(string publisher, string offer, string sku)
        {
            var images = m_CrpClient.VirtualMachineImages.List(
                location: m_location, publisherName: publisher, offer: offer, skus: sku,
                top: 1);
            var image = images.First();
            return new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = image.Name
            };
        }

        protected ImageReference GetPlatformVMImage(bool useWindowsImage, string sku = null)
        {
            if (useWindowsImage)
            {
                if (m_windowsImageReference == null)
                {
                    Trace.TraceInformation("Querying available Windows Server image from PIR...");
                    m_windowsImageReference = FindVMImage("MicrosoftWindowsServer", "WindowsServer", sku ?? "2012-R2-Datacenter");
                }
                return m_windowsImageReference;
            }

            if (m_linuxImageReference == null)
            {
                Trace.TraceInformation("Querying available Ubuntu image from PIR...");
                // If this sku disappears, query latest with
                // GET https://management.azure.com/subscriptions/<subId>/providers/Microsoft.Compute/locations/SoutheastAsia/publishers/Canonical/artifacttypes/vmimage/offers/UbuntuServer/skus?api-version=2015-06-15
                m_linuxImageReference = FindVMImage("Canonical", "UbuntuServer", sku ?? "19.04");
            }
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

        protected DiagnosticsProfile GetManagedDiagnosticsProfile()
        {
            return new DiagnosticsProfile
            {
                BootDiagnostics = new BootDiagnostics
                {
                    Enabled = true
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
                DiskEncryptionKey = new KeyVaultSecretReference
                {
                    SecretUrl = encryptionKeyFakeUri,
                    SourceVault = new Microsoft.Azure.Management.Compute.Models.SubResource
                    {
                        Id = testVaultId
                    }
                }
            };

            if (addKek)
            {
                string nonExistentKekUri = @"https://testvault123.vault.azure.net/keys/TestKey/514ceb769c984379a7e0230bdd703272";
                diskEncryptionSettings.KeyEncryptionKey = new KeyVaultKeyReference
                {
                    KeyUrl = nonExistentKekUri,
                    SourceVault = new Microsoft.Azure.Management.Compute.Models.SubResource
                    {
                        Id = testVaultId
                    }
                };
            }
            return diskEncryptionSettings;
        }

        protected string getDefaultDiskEncryptionSetId()
        {
            return "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/RGforSDKtestResources/providers/Microsoft.Compute/diskEncryptionSets/EncryptionSetforTest";
        }

        protected StorageAccount CreateStorageAccount(string rgName, string storageAccountName)
        {
            try
            {
                // Create the resource Group.
                var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgName,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                    });

                var stoInput = new StorageAccountCreateParameters
                {
                    Location = m_location,
                    AccountType = AccountType.StandardGRS
                };

                StorageAccount storageAccountOutput = m_SrpClient.StorageAccounts.Create(rgName,
                    storageAccountName, stoInput);
                bool created = false;
                while (!created)
                {
                    ComputeManagementTestUtilities.WaitSeconds(10);
                    var stos = m_SrpClient.StorageAccounts.ListByResourceGroup(rgName);
                    created =
                        stos.Any(
                            t =>
                                StringComparer.OrdinalIgnoreCase.Equals(t.Name, storageAccountName));
                }

                return m_SrpClient.StorageAccounts.GetProperties(rgName, storageAccountName);
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(rgName);
                throw;
            }
        }

        protected VirtualMachine CreateVM(
            string rgName, string asName, StorageAccount storageAccount, ImageReference imageRef,
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitForCompletion = true,
            bool hasManagedDisks = false)
        {
            return CreateVM(rgName, asName, storageAccount.Name, imageRef, out inputVM, vmCustomizer, createWithPublicIpAddress, waitForCompletion, hasManagedDisks);
        }

        protected VirtualMachine CreateVM(
            string rgName, string asName, string storageAccountName, ImageReference imageRef,
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitForCompletion = true,
            bool hasManagedDisks = false,
            bool hasDiffDisks = false,
            string vmSize = VirtualMachineSizeTypes.StandardA1V2,
            string osDiskStorageAccountType = "Standard_LRS",
            string dataDiskStorageAccountType = "Standard_LRS",
            bool? writeAcceleratorEnabled = null,
            IList<string> zones = null,
            string ppgName = null,
            string diskEncryptionSetId = null,
            bool? encryptionAtHostEnabled = null,
            string dedicatedHostGroupReferenceId = null,
            string dedicatedHostGroupName = null,
            string dedicatedHostName = null)
        {
            try
            {
                // Create the resource Group, it might have been already created during StorageAccount creation.
                m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgName,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                    });

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

                string ppgId = ((ppgName != null) ? CreateProximityPlacementGroup(rgName, ppgName): null);

                string asetId = CreateAvailabilitySet(rgName, asName, hasManagedDisks, ppgId: ppgId);

                inputVM = CreateDefaultVMInput(rgName, storageAccountName, imageRef, asetId, nicResponse.Id, hasManagedDisks, vmSize, osDiskStorageAccountType,
                    dataDiskStorageAccountType, writeAcceleratorEnabled, diskEncryptionSetId);

                if (hasDiffDisks)
                {
                    OSDisk osDisk = inputVM.StorageProfile.OsDisk;
                    osDisk.Caching = CachingTypes.ReadOnly;
                    osDisk.DiffDiskSettings = new DiffDiskSettings {
                        Option = DiffDiskOptions.Local,
                        Placement = DiffDiskPlacement.ResourceDisk
                    };
                }

                if (dedicatedHostGroupReferenceId != null)
                {
                    CreateDedicatedHostGroup(rgName, dedicatedHostGroupName, availabilityZone: null);
                    CreateDedicatedHost(rgName, dedicatedHostGroupName, dedicatedHostName, "DSv3-Type1");
                    inputVM.HostGroup = new CM.SubResource { Id = dedicatedHostGroupReferenceId };
                    inputVM.AvailabilitySet = null;
                }

                if (encryptionAtHostEnabled != null)
                {
                    inputVM.SecurityProfile = new SecurityProfile
                    {
                        EncryptionAtHost = encryptionAtHostEnabled.Value
                    };
                }

                if (zones != null)
                {
                    inputVM.AvailabilitySet = null;
                    // If no vmSize is provided and we are using the default value, change the default value for VMs with Zones.
                    if(vmSize == VirtualMachineSizeTypes.StandardA0)
                    {
                        vmSize = VirtualMachineSizeTypes.StandardA1V2;
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
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
                }
                else
                {
                    // BeginCreateOrUpdate returns immediately after the request is accepted by CRP
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.BeginCreateOrUpdate(rgName, inputVM.Name, inputVM);
                }

                Assert.True(createOrUpdateResponse.Name == inputVM.Name);
                Assert.True(createOrUpdateResponse.Location == inputVM.Location.ToLower().Replace(" ", "") ||
                    createOrUpdateResponse.Location.ToLower() == inputVM.Location.ToLower());

                bool hasUserDefinedAvSet = inputVM.AvailabilitySet != null;
                if (hasUserDefinedAvSet)
                {
                    Assert.True(createOrUpdateResponse.AvailabilitySet.Id.ToLowerInvariant() == asetId.ToLowerInvariant());
                }

                if (zones != null)
                {
                    Assert.True(createOrUpdateResponse.Zones.Count == 1);
                    Assert.True(createOrUpdateResponse.Zones.FirstOrDefault() == zones.FirstOrDefault());
                }

                // The intent here is to validate that the GET response is as expected.
                var getResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                ValidateVM(inputVM, getResponse, expectedVMReferenceId, hasManagedDisks, writeAcceleratorEnabled: writeAcceleratorEnabled,
                    hasDiffDisks: hasDiffDisks, hasUserDefinedAS: hasUserDefinedAvSet, expectedPpgReferenceId: ppgId, encryptionAtHostEnabled: encryptionAtHostEnabled,
                    expectedDedicatedHostGroupReferenceId: dedicatedHostGroupReferenceId);

                return getResponse;
            }
            catch
            {
                // Just trigger DeleteRG, rest would be taken care of by ARM
                m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                throw;
            }
        }

        protected PublicIPPrefix CreatePublicIPPrefix(string rgName, int prefixLength)
        {
            string publicIpPrefixName = ComputeManagementTestUtilities.GenerateName("piprefix");

            var publicIpPrefix = new PublicIPPrefix()
            {
                Sku = new PublicIPPrefixSku("Standard"),
                Location = m_location,
                PrefixLength = prefixLength
            };

            var putPublicIpPrefixResponse = m_NrpClient.PublicIPPrefixes.CreateOrUpdate(rgName, publicIpPrefixName, publicIpPrefix);
            var getPublicIpPrefixResponse = m_NrpClient.PublicIPPrefixes.Get(rgName, publicIpPrefixName);

            return getPublicIpPrefixResponse;
        }

        protected PublicIPAddress CreatePublicIP(string rgName)
        {
            // Create publicIP
            string publicIpName = ComputeManagementTestUtilities.GenerateName("pip");
            string domainNameLabel = ComputeManagementTestUtilities.GenerateName("dn");

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

            var putPublicIpAddressResponse = m_NrpClient.PublicIPAddresses.CreateOrUpdate(rgName, publicIpName, publicIp);
            var getPublicIpAddressResponse = m_NrpClient.PublicIPAddresses.Get(rgName, publicIpName);
            return getPublicIpAddressResponse;
        }

        protected Subnet CreateVNET(string rgName, bool addDnsServer = true, bool disablePEPolicies = false)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = ComputeManagementTestUtilities.GenerateName("vn");
            string subnetName = ComputeManagementTestUtilities.GenerateName("sn");

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
                                PrivateEndpointNetworkPolicies = disablePEPolicies ? "Disabled" : null
                            }
                        }
            };
            var putVnetResponse = m_NrpClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
            var getSubnetResponse = m_NrpClient.Subnets.Get(rgName, vnetName, subnetName);
            return getSubnetResponse;
        }

        protected VirtualNetwork CreateVNETWithSubnets(string rgName, int subnetCount = 2)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = ComputeManagementTestUtilities.GenerateName("vn");

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
                    Name = ComputeManagementTestUtilities.GenerateName("sn" + i),
                    AddressPrefix = "10.0." + i + ".0/24",
                };
                vnet.Subnets.Add(subnet);
            }

            var putVnetResponse = m_NrpClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
            return putVnetResponse;
        }

        protected NetworkSecurityGroup CreateNsg(string rgName, string nsgName = null)
        {
            nsgName = nsgName ?? ComputeManagementTestUtilities.GenerateName("nsg");
            var nsgParameters = new NetworkSecurityGroup()
            {
                Location = m_location
            };

            var putNSgResponse = m_NrpClient.NetworkSecurityGroups.CreateOrUpdate(rgName, nsgName, nsgParameters);
            var getNsgResponse = m_NrpClient.NetworkSecurityGroups.Get(rgName, nsgName);

            return getNsgResponse;
        }

        protected NetworkInterface CreateNIC(string rgName, Subnet subnet, string publicIPaddress, string nicname = null, NetworkSecurityGroup nsg = null)
        {
            // Create Nic
            nicname = nicname ?? ComputeManagementTestUtilities.GenerateName("nic");
            string ipConfigName = ComputeManagementTestUtilities.GenerateName("ip");

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
                nicParameters.IpConfigurations[0].PublicIPAddress = new Microsoft.Azure.Management.Network.Models.PublicIPAddress() { Id = publicIPaddress };
            }

            var putNicResponse = m_NrpClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
            var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicname);
            return getNicResponse;
        }

        protected NetworkInterface CreateMultiIpConfigNIC(string rgName, Subnet subnet, string nicname)
        {
            // Create Nic
            nicname = nicname ?? ComputeManagementTestUtilities.GenerateName("nic");

            string ipConfigName = ComputeManagementTestUtilities.GenerateName("ip");
            string ipConfigName2 = ComputeManagementTestUtilities.GenerateName("ip2");

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

            var putNicResponse = m_NrpClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
            var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicname);
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

        protected ApplicationGateway CreateApplicationGateway(string rgName, Subnet subnet, string gatewayName = null)
        {
            gatewayName = gatewayName ?? ComputeManagementTestUtilities.GenerateName("gw");
            var gatewayIPConfigName = ComputeManagementTestUtilities.GenerateName("gwIp");
            var frontendIPConfigName = ComputeManagementTestUtilities.GenerateName("fIp");
            var frontendPortName = ComputeManagementTestUtilities.GenerateName("fPort");
            var backendAddressPoolName = ComputeManagementTestUtilities.GenerateName("pool");
            var backendHttpSettingsName = ComputeManagementTestUtilities.GenerateName("setting");
            var requestRoutingRuleName = ComputeManagementTestUtilities.GenerateName("rule");
            var httpListenerName = ComputeManagementTestUtilities.GenerateName("listener");

            var gatewayIPConfig = new ApplicationGatewayIPConfiguration()
            {
                Name = gatewayIPConfigName,
                Subnet = new Microsoft.Azure.Management.Network.Models.SubResource { Id = subnet.Id },
            };

            var frontendIPConfig = new ApplicationGatewayFrontendIPConfiguration()
            {
                Name = frontendIPConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                Subnet = new Microsoft.Azure.Management.Network.Models.SubResource { Id = subnet.Id }
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
                FrontendPort = new Microsoft.Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "frontendPorts", frontendPortName)
                },
                FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource
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
                HttpListener = new Microsoft.Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "httpListeners", httpListenerName)
                },
                BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource
                {
                    Id = GetChildAppGwResourceId(m_subId, rgName, gatewayName, "backendAddressPools", backendAddressPoolName)
                },
                BackendHttpSettings = new Microsoft.Azure.Management.Network.Models.SubResource
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

            var putGwResponse = m_NrpClient.ApplicationGateways.CreateOrUpdate(rgName, gatewayName, appGw);
            var getGwResponse = m_NrpClient.ApplicationGateways.Get(rgName, gatewayName);
            return getGwResponse;
        }

        protected LoadBalancer CreatePublicLoadBalancerWithProbe(string rgName, PublicIPAddress publicIPAddress)
        {
            var loadBalancerName = ComputeManagementTestUtilities.GenerateName("lb");
            var frontendIPConfigName = ComputeManagementTestUtilities.GenerateName("feip");
            var backendAddressPoolName = ComputeManagementTestUtilities.GenerateName("beap");
            var loadBalancingRuleName = ComputeManagementTestUtilities.GenerateName("lbr");
            var loadBalancerProbeName = ComputeManagementTestUtilities.GenerateName("lbp");

            var frontendIPConfigId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/frontendIPConfigurations/{frontendIPConfigName}";
            var backendAddressPoolId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/backendAddressPools/{backendAddressPoolName}";
            var probeId =
                $"/subscriptions/{m_subId}/resourceGroups/{rgName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{loadBalancerProbeName}";

            var putLBResponse = m_NrpClient.LoadBalancers.CreateOrUpdate(rgName, loadBalancerName, new LoadBalancer
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
            });

            var getLBResponse = m_NrpClient.LoadBalancers.Get(rgName, loadBalancerName);
            return getLBResponse;
        }

        protected string CreateAvailabilitySet(string rgName, string asName, bool hasManagedDisks = false, string ppgId = null)
        {
            // Setup availability set
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"}
                    },
                PlatformFaultDomainCount = hasManagedDisks ? 1 : 3,
                PlatformUpdateDomainCount = hasManagedDisks ? 1 : 5,
                Sku = new CM.Sku
                {
                    Name = hasManagedDisks ? AvailabilitySetSkuTypes.Aligned : AvailabilitySetSkuTypes.Classic
                }
            };

            if(ppgId != null)
            {
                inputAvailabilitySet.ProximityPlacementGroup = new Microsoft.Azure.Management.Compute.Models.SubResource() { Id = ppgId };
            }

            // Create an Availability Set and then create a VM inside this availability set
            var asCreateOrUpdateResponse = m_CrpClient.AvailabilitySets.CreateOrUpdate(
                rgName,
                asName,
                inputAvailabilitySet
            );
            var asetId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asCreateOrUpdateResponse.Name);
            return asetId;
        }

        static string CreateProximityPlacementGroup(string subId, string rgName, string ppgName, ComputeManagementClient client, string location)
        {
            // Setup ProximityPlacementGroup
            var inputProximityPlacementGroup = new ProximityPlacementGroup
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                {
                    {"RG", "rg"},
                    {"testTag", "1"},
                },
                ProximityPlacementGroupType = ProximityPlacementGroupType.Standard
            };

            // Create a ProximityPlacementGroup and then create a VM inside this ProximityPlacementGroup
            ProximityPlacementGroup ppgCreateOrUpdateResponse = client.ProximityPlacementGroups.CreateOrUpdate(
                rgName,
                ppgName,
                inputProximityPlacementGroup
            );

            return Helpers.GetProximityPlacementGroupRef(subId, rgName, ppgCreateOrUpdateResponse.Name);
        }

        protected string CreateProximityPlacementGroup(string rgName, string ppgName)
        {
            return CreateProximityPlacementGroup(m_subId, rgName, ppgName, m_CrpClient, m_location);
        }

        protected VirtualMachine CreateDefaultVMInput(string rgName, string storageAccountName, ImageReference imageRef, string asetId, string nicId, bool hasManagedDisks = false,
            string vmSize = "Standard_A1_v2", string osDiskStorageAccountType = "Standard_LRS", string dataDiskStorageAccountType = "Standard_LRS", bool? writeAcceleratorEnabled = null,
            string diskEncryptionSetId = null)
        {
            // Generate Container name to hold disk VHds
            string containerName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vhduri = vhdContainer + string.Format("/{0}.vhd", ComputeManagementTestUtilities.GenerateName(TestPrefix));
            var osVhduri = vhdContainer + string.Format("/os{0}.vhd", ComputeManagementTestUtilities.GenerateName(TestPrefix));

            if (writeAcceleratorEnabled.HasValue)
            {
                // WriteAccelerator is only allowed on VMs with Managed disks
                Assert.True(hasManagedDisks);
            }

            var vm = new VirtualMachine
            {
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                AvailabilitySet = new Microsoft.Azure.Management.Compute.Models.SubResource() { Id = asetId },
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
                        new DataDisk()
                        {
                            Caching = CachingTypes.None,
                            WriteAcceleratorEnabled = writeAcceleratorEnabled,
                            CreateOption = DiskCreateOptionTypes.Empty,
                            Lun = 0,
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
                },
                NetworkProfile = new CM.NetworkProfile
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
                    AdminPassword = PLACEHOLDER,
                    ComputerName = ComputerName
                }
            };

            if(dataDiskStorageAccountType == StorageAccountTypes.UltraSSDLRS)
            {
                vm.AdditionalCapabilities = new AdditionalCapabilities
                {
                    UltraSSDEnabled = true
                };
            }

            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetRuntimeProperty("Name").SetValue(vm, ComputeManagementTestUtilities.GenerateName("vm"));
            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetRuntimeProperty("Type").SetValue(vm, ComputeManagementTestUtilities.GenerateName("Microsoft.Compute/virtualMachines"));
            return vm;
        }

        protected DedicatedHostGroup CreateDedicatedHostGroup( string rgName, string dedicatedHostGroupName, int? availabilityZone = 1)
        {
            m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                   rgName,
                   new ResourceGroup
                   {
                       Location = m_location,
                       Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                   });

            DedicatedHostGroup dedicatedHostGroup = new DedicatedHostGroup()
            {
                Location = m_location,
                Zones = availabilityZone == null ? null : new List<string> { availabilityZone.ToString() },
                PlatformFaultDomainCount = 1,
                SupportAutomaticPlacement = true
            };
            return m_CrpClient.DedicatedHostGroups.CreateOrUpdate(rgName, dedicatedHostGroupName, dedicatedHostGroup);
        }

        protected DedicatedHost CreateDedicatedHost(string rgName, string dedicatedHostGroupName, string dedicatedHostName, string dedicatedHostSku)
        {
            //Check if DedicatedHostGroup already exist and if does not exist, create one.
            DedicatedHostGroup existingDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dedicatedHostGroupName);
            if (existingDHG == null)
            {
                existingDHG = CreateDedicatedHostGroup(rgName, dedicatedHostGroupName);
            }
            return m_CrpClient.DedicatedHosts.CreateOrUpdate(rgName, dedicatedHostGroupName, dedicatedHostName,
                new DedicatedHost()
                {
                    Location = m_location,
                    Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } },
                    Sku = new CM.Sku() { Name = dedicatedHostSku }
                });
        }

        protected void ValidateVM(VirtualMachine vm, VirtualMachine vmOut, string expectedVMReferenceId, bool hasManagedDisks = false, bool hasUserDefinedAS = true,
            bool? writeAcceleratorEnabled = null, bool hasDiffDisks = false, string expectedLocation = null, string expectedPpgReferenceId = null,
            bool? encryptionAtHostEnabled = null, string expectedDedicatedHostGroupReferenceId = null)
        {
            Assert.True(vmOut.LicenseType == vm.LicenseType);

            Assert.True(!string.IsNullOrEmpty(vmOut.ProvisioningState));

            Assert.True(vmOut.HardwareProfile.VmSize
                     == vm.HardwareProfile.VmSize);

            Assert.True(vmOut.ExtensionsTimeBudget == vm.ExtensionsTimeBudget);

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

                    if (hasDiffDisks)
                    {
                        Assert.True(vmOut.StorageProfile.OsDisk.DiffDiskSettings.Option == vm.StorageProfile.OsDisk.DiffDiskSettings.Option);
                    }
                    else
                    {
                        Assert.Null(vm.StorageProfile.OsDisk.DiffDiskSettings);
                    }

                    if(encryptionAtHostEnabled != null)
                    {
                        Assert.True(vmOut.SecurityProfile.EncryptionAtHost == vm.SecurityProfile.EncryptionAtHost);
                    }
                    else
                    {
                        Assert.Null(vmOut.SecurityProfile?.EncryptionAtHost);
                    }

                    if (writeAcceleratorEnabled.HasValue)
                    {
                        Assert.Equal(writeAcceleratorEnabled.Value, vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                    else
                    {
                        Assert.Null(vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                }
                else
                {
                    Assert.NotNull(vmOut.StorageProfile.OsDisk.Vhd);
                    Assert.Equal(vm.StorageProfile.OsDisk.Vhd.Uri, vmOut.StorageProfile.OsDisk.Vhd.Uri);
                    if (vm.StorageProfile.OsDisk.Image != null && vm.StorageProfile.OsDisk.Image.Uri != null)
                    {
                        Assert.Equal(vm.StorageProfile.OsDisk.Image.Uri, vmOut.StorageProfile.OsDisk.Image.Uri);
                    }
                }
            }

            if (vm.StorageProfile.DataDisks != null &&
                vm.StorageProfile.DataDisks.Any())
            {
                if(vm.StorageProfile.DataDisks.Any(dd => dd.ManagedDisk != null && dd.ManagedDisk.StorageAccountType == StorageAccountTypes.UltraSSDLRS))
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
                            Assert.Equal(writeAcceleratorEnabled.Value, dataDiskOut.WriteAcceleratorEnabled);
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
                            Assert.Equal(dataDisk.Image.Uri, dataDiskOut.Image.Uri);
                        }
                        Assert.Null(vmOut.StorageProfile.OsDisk.WriteAcceleratorEnabled);
                    }
                    // ReSharper enable PossibleNullReferenceException
                }
            }

            if(vm.OsProfile != null &&
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

            if (hasUserDefinedAS)
            {
                Assert.NotNull(vmOut.AvailabilitySet);
                Assert.True(vm.AvailabilitySet.Id.ToLowerInvariant() == vmOut.AvailabilitySet.Id.ToLowerInvariant());
            }

            Assert.Equal(vm.Location, vmOut.Location, StringComparer.OrdinalIgnoreCase);

            ValidatePlan(vm.Plan, vmOut.Plan);
            Assert.NotNull(vmOut.VmId);

            if(expectedPpgReferenceId != null)
            {
                Assert.NotNull(vmOut.ProximityPlacementGroup);
                Assert.Equal(expectedPpgReferenceId, vmOut.ProximityPlacementGroup.Id, StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                Assert.Null(vmOut.ProximityPlacementGroup);
            }

            if (expectedDedicatedHostGroupReferenceId != null)
            {
                Assert.NotNull(vmOut.HostGroup);
                Assert.Equal(expectedDedicatedHostGroupReferenceId, vmOut.HostGroup.Id, StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                Assert.Null(vmOut.HostGroup);
            }
        }

        protected void ValidateVMInstanceView(VirtualMachine vmIn, VirtualMachine vmOut, bool hasManagedDisks = false,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null, string expectedDedicatedHostReferenceId = null)
        {
            Assert.NotNull(vmOut.InstanceView);
            ValidateVMInstanceView(vmIn, vmOut.InstanceView, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion, expectedDedicatedHostReferenceId);
        }

        protected void ValidateVMInstanceView(VirtualMachine vmIn, VirtualMachineInstanceView vmInstanceView, bool hasManagedDisks = false,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null, string expectedDedicatedHostReferenceId = null)
        {
            ValidateVMInstanceView(vmInstanceView, hasManagedDisks,
                !hasManagedDisks ? vmIn.StorageProfile.OsDisk.Name : null,
                expectedComputerName, expectedOSName, expectedOSVersion, expectedDedicatedHostReferenceId: expectedDedicatedHostReferenceId);
        }

        private void ValidateVMInstanceView(VirtualMachineInstanceView vmInstanceView, bool hasManagedDisks = false, string osDiskName = null,
            string expectedComputerName = null, string expectedOSName = null, string expectedOSVersion = null, string expectedDedicatedHostReferenceId = null)
        {
            Assert.Contains(vmInstanceView.Statuses, s => !string.IsNullOrEmpty(s.Code));

            if (!hasManagedDisks)
            {
                Assert.NotNull(vmInstanceView.Disks);
                Assert.True(vmInstanceView.Disks.Any());

                if (osDiskName != null)
                {
                    Assert.Contains(vmInstanceView.Disks, x => x.Name == osDiskName);
                }

                DiskInstanceView diskInstanceView = vmInstanceView.Disks.First();
                Assert.NotNull(diskInstanceView);
                Assert.NotNull(diskInstanceView.Statuses[0].DisplayStatus);
                Assert.NotNull(diskInstanceView.Statuses[0].Code);
                Assert.NotNull(diskInstanceView.Statuses[0].Level);
                //Assert.NotNull(diskInstanceView.Statuses[0].Message); // TODO: it's null somtimes.
                //Assert.NotNull(diskInstanceView.Statuses[0].Time);    // TODO: it's null somtimes.
            }
            // Below three properties might not be populated in time.
            /*
            if (expectedComputerName != null)
            {
                Assert.Equal(expectedComputerName, vmInstanceView.ComputerName, StringComparer.OrdinalIgnoreCase);
            }
            if (expectedOSName != null)
            {
                Assert.Equal(expectedOSName, vmInstanceView.OsName, StringComparer.OrdinalIgnoreCase);
            }
            if (expectedOSVersion != null)
            {
                Assert.Equal(expectedOSVersion, vmInstanceView.OsVersion, StringComparer.OrdinalIgnoreCase);
            }
            */
            if (expectedDedicatedHostReferenceId != null)
            {
                Assert.Equal(expectedDedicatedHostReferenceId, vmInstanceView.AssignedHost, StringComparer.OrdinalIgnoreCase);
            }
        }

        protected void ValidatePlan(Microsoft.Azure.Management.Compute.Models.Plan inputPlan, Microsoft.Azure.Management.Compute.Models.Plan outPutPlan)
        {
            if (inputPlan == null
                 || outPutPlan == null
               )
            {
                Assert.Equal(inputPlan, outPutPlan);
                return;
            }

            Assert.Equal(inputPlan.Name, outPutPlan.Name);
            Assert.Equal(inputPlan.Publisher, outPutPlan.Publisher);
            Assert.Equal(inputPlan.Product, outPutPlan.Product);
            Assert.Equal(inputPlan.PromotionCode, outPutPlan.PromotionCode);
        }

        /// <remarks>
        /// BootDiagnosticsInstanceView properties will be null if VM is enabled with managed boot diagnostics
        /// </remarks>
        protected void ValidateBootDiagnosticsInstanceView(BootDiagnosticsInstanceView bootDiagnosticsInstanceView, bool hasError, bool enabledWithManagedBootDiagnostics = false)
        {
            // VM with managed boot diagnostics will not return blob URIs or status in BootDiagnosticsInstanceView
            if (enabledWithManagedBootDiagnostics)
            {
                Assert.Null(bootDiagnosticsInstanceView.ConsoleScreenshotBlobUri);
                Assert.Null(bootDiagnosticsInstanceView.SerialConsoleLogBlobUri);
                Assert.Null(bootDiagnosticsInstanceView.Status);
                return;
            }

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

        protected static void ValidateBootDiagnosticsData(RetrieveBootDiagnosticsDataResult bootDiagnosticsData)
        {
            Assert.NotNull(bootDiagnosticsData);
            Assert.NotNull(bootDiagnosticsData.ConsoleScreenshotBlobUri);
            Assert.NotNull(bootDiagnosticsData.SerialConsoleLogBlobUri);
        }
    }
}

