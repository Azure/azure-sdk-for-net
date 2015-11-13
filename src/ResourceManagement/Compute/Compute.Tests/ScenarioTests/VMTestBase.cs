//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMTestBase
    {
        protected const string TestPrefix = "crptestar";

        protected ResourceManagementClient m_ResourcesClient;
        protected ComputeManagementClient m_CrpClient;
        protected StorageManagementClient m_SrpClient;
        protected NetworkManagementClient m_NrpClient;

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

                        m_subId = m_CrpClient.SubscriptionId;
                        m_location = ComputeManagementTestUtilities.DefaultLocation;
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
                Publisher = publisher, Offer = offer, Sku = sku, Version = image.Name
            };
        }

        protected ImageReference GetPlatformVMImage(bool useWindowsImage)
        {
            if (useWindowsImage)
            {
                if (m_windowsImageReference == null)
                {
                    Trace.TraceInformation("Querying available Windows Server image from PIR...");
                    m_windowsImageReference = FindVMImage("MicrosoftWindowsServer", "WindowsServer", "2012-R2-Datacenter");
                }
                return m_windowsImageReference;
            }

            if (m_linuxImageReference == null)
            {
                Trace.TraceInformation("Querying available Ubuntu image from PIR...");
                // If this sku disappears, query latest with 
                // GET https://management.azure.com/subscriptions/<subId>/providers/Microsoft.Compute/locations/SoutheastAsia/publishers/Canonical/artifacttypes/vmimage/offers/UbuntuServer/skus?api-version=2015-06-15
                m_linuxImageReference = FindVMImage("Canonical", "UbuntuServer", "15.04");
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

        protected DiskEncryptionSettings GetEncryptionSettings(bool addKek = false)
        {
            string testVaultId =
                @"/subscriptions/21466899-20b2-463c-8c30-b8fb28a43248/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123";
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

        protected VirtualMachine CreateVM_NoAsyncTracking(
            string rgName, string asName, StorageAccount storageAccount, ImageReference imageRef, 
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false,
            bool waitOperation = true)
        {
            try
            {
                // Create the resource Group, it might have been already created during StorageAccount creation.
                var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgName,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                    });

                PublicIPAddress getPublicIpAddressResponse = createWithPublicIpAddress ? null : CreatePublicIP(rgName);
                
                Subnet subnetResponse = CreateVNET(rgName);

                NetworkInterface nicResponse = CreateNIC(
                    rgName, 
                    subnetResponse, 
                    getPublicIpAddressResponse != null ? getPublicIpAddressResponse.IpAddress : null);

                string asetId = CreateAvailabilitySet(rgName, asName);

                inputVM = CreateDefaultVMInput(rgName, storageAccount.Name, imageRef, asetId, nicResponse.Id);
                if (vmCustomizer != null)
                {
                    vmCustomizer(inputVM);
                }

                string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                VirtualMachine createOrUpdateResponse = null;
                if (waitOperation)
                {
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, inputVM.Name, inputVM);
                }
                else
                {
                    createOrUpdateResponse = m_CrpClient.VirtualMachines.BeginCreateOrUpdate(rgName, inputVM.Name, inputVM);
                }

                Assert.True(createOrUpdateResponse.Name == inputVM.Name);
                Assert.True(createOrUpdateResponse.Location == inputVM.Location.ToLower().Replace(" ", "") || 
                    createOrUpdateResponse.Location.ToLower() == inputVM.Location.ToLower());

                Assert.True(
                    createOrUpdateResponse.AvailabilitySet.Id
                        .ToLowerInvariant() == asetId.ToLowerInvariant());
                ValidateVM(inputVM, createOrUpdateResponse, expectedVMReferenceId);

                // CONSIDER dropping this Get and ValidateVM call. Nothing changes in the VM model after it's accepted.
                // There might have been intent to track the async operation to completion and then check the VM is
                // still this and okay, but that's not what the code above does and still doesn't make much sense.
                var getResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                ValidateVM(inputVM, getResponse, expectedVMReferenceId);

                return getResponse;
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(rgName);
                throw;
            }
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

        protected Subnet CreateVNET(string rgName)
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
                DhcpOptions = new DhcpOptions()
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
            var putVnetResponse = m_NrpClient.VirtualNetworks.CreateOrUpdate(rgName, vnetName, vnet);
            var getSubnetResponse = m_NrpClient.Subnets.Get(rgName, vnetName, subnetName);
            return getSubnetResponse;
        }

        protected NetworkInterface CreateNIC(string rgName, Subnet subnet, string publicIPaddress, string nicname = null)
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
                }
            };

            if (publicIPaddress != null)
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new Microsoft.Azure.Management.Network.Models.PublicIPAddress() { Id = publicIPaddress };
            }

            var putNicResponse = m_NrpClient.NetworkInterfaces.CreateOrUpdate(rgName, nicname, nicParameters);
            var getNicResponse = m_NrpClient.NetworkInterfaces.Get(rgName, nicname);
            return getNicResponse;
        }

        protected string CreateAvailabilitySet(string rgName, string asName)
        {
            // Setup availability set
            var inputAvailabilitySet = new AvailabilitySet
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"}
                    }
            };

            // Create an Availability Set and then create a VM inside this availability set
            var asCreateOrUpdateResponse = m_CrpClient.AvailabilitySets.CreateOrUpdate(
                rgName,
                asName,
                inputAvailabilitySet
            );
            var asetId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asCreateOrUpdateResponse.Name);
            return asetId;
        }

        protected VirtualMachine CreateDefaultVMInput(string rgName, string storageAccountName, ImageReference imageRef, string asetId, string nicId)
        {
            // Generate Container name to hold disk VHds
            string containerName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vhduri = vhdContainer + string.Format("/{0}.vhd", ComputeManagementTestUtilities.GenerateName(TestPrefix));
            var osVhduri = vhdContainer + string.Format("/os{0}.vhd", ComputeManagementTestUtilities.GenerateName(TestPrefix));

            var vm = new VirtualMachine
            {
                Location = m_location,
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
                        Vhd = new VirtualHardDisk
                        {
                            Uri = osVhduri
                        }
                    },
                    DataDisks = null,
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

            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetProperty("Name").SetValue(vm, ComputeManagementTestUtilities.GenerateName("vm"));
            typeof(Microsoft.Azure.Management.Compute.Models.Resource).GetProperty("Type").SetValue(vm, ComputeManagementTestUtilities.GenerateName("Microsoft.Compute/virtualMachines"));
            return vm;
        }

        protected void ValidateVM(VirtualMachine vm, VirtualMachine vmOut, string expectedVMReferenceId)
        {
            Assert.True(!string.IsNullOrEmpty(vmOut.ProvisioningState));

            Assert.True(vmOut.HardwareProfile.VmSize
                     == vm.HardwareProfile.VmSize);

            Assert.NotNull(vmOut.StorageProfile.OsDisk);

            if (vm.StorageProfile.OsDisk != null)
            {
                Assert.True(vmOut.StorageProfile.OsDisk.Name
                         == vm.StorageProfile.OsDisk.Name);

                Assert.True(vmOut.StorageProfile.OsDisk.Vhd.Uri
                == vm.StorageProfile.OsDisk.Vhd.Uri);

                Assert.True(vmOut.StorageProfile.OsDisk.Caching
                         == vm.StorageProfile.OsDisk.Caching);
            }

            if (vm.StorageProfile.DataDisks != null &&
                vm.StorageProfile.DataDisks.Any())
            {
                foreach (var dataDisk in vm.StorageProfile.DataDisks)
                {
                    var dataDiskOut = vmOut.StorageProfile.DataDisks.FirstOrDefault(
                            d => string.Equals(dataDisk.Name, d.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(dataDiskOut);

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

            Assert.NotNull(vmOut.AvailabilitySet);
            Assert.True(vm.AvailabilitySet.Id.ToLowerInvariant() == vmOut.AvailabilitySet.Id.ToLowerInvariant());
            ValidatePlan(vm.Plan, vmOut.Plan);
            // TODO: it's null somtimes.
            //Assert.NotNull(vmOut.Properties.Id);
            //Assert.True(expectedVMReferenceId.ToLowerInvariant() == vmOut.Properties.Id.ToLowerInvariant());
        }

        protected void ValidateVMInstanceView(VirtualMachine vmIn, VirtualMachine vmOut)
        {
            Assert.NotNull(vmOut.InstanceView);
            Assert.True(vmOut.InstanceView.Statuses.Any(s => !string.IsNullOrEmpty(s.Code)));

            var instanceView = vmOut.InstanceView;
            Assert.NotNull(instanceView.Disks);
            Assert.True(instanceView.Disks.Any());

            if (vmIn.StorageProfile.OsDisk != null)
            {
                Assert.True(instanceView.Disks.Any(x => x.Name == vmIn.StorageProfile.OsDisk.Name));
            }

            DiskInstanceView diskInstanceView = instanceView.Disks.First();
            Assert.NotNull(diskInstanceView);
            Assert.NotNull(diskInstanceView.Statuses[0].DisplayStatus);
            Assert.NotNull(diskInstanceView.Statuses[0].Code);
            Assert.NotNull(diskInstanceView.Statuses[0].Level);
            //Assert.NotNull(diskInstanceView.Statuses[0].Message); // TODO: it's null somtimes.
            //Assert.NotNull(diskInstanceView.Statuses[0].Time);    // TODO: it's null somtimes.
        }

        protected void ValidatePlan(Microsoft.Azure.Management.Compute.Models.Plan inputPlan, Microsoft.Azure.Management.Compute.Models.Plan outPutPlan)
        {
            if (    inputPlan == null
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
        

    }
}
