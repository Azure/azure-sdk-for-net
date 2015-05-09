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

using Compute.Tests;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMTestBase
    {
        protected const string TestPrefix = "pslibtest";

        protected ResourceManagementClient m_ResourcesClient;
        protected ComputeManagementClient m_CrpClient;
        protected StorageManagementClient m_SrpClient;
        protected NetworkResourceProviderClient m_NrpClient;

        protected bool m_initialized = false;
        protected object m_lock = new object();
        protected string m_subId;
        protected string m_location;

        protected void EnsureClientsInitialized()
        {
            if (!m_initialized)
            {
                lock (m_lock)
                {
                    if (!m_initialized)
                    {
                        var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                        m_ResourcesClient = ComputeManagementTestUtilities.GetResourceManagementClient(handler);
                        m_CrpClient = ComputeManagementTestUtilities.GetComputeManagementClient(handler);
                        m_SrpClient = ComputeManagementTestUtilities.GetStorageManagementClient(handler);
                        m_NrpClient = ComputeManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                        m_subId = m_CrpClient.Credentials.SubscriptionId;
                        m_location = ComputeManagementTestUtilities.DefaultLocation;
                    }
                }
            }
        }
        
        protected string GetPlatformOSImage(bool useWindowsImage)
        {
            return useWindowsImage ?
                "/" + m_subId + "/services/images/a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-Datacenter-201503.01-en.us-127GB.vhd" :
                "/" + m_subId + "/services/images/b4590d9e3ed742e4a1d46e5424aa335e__sles12-azure-guest-priority.x86-64-0.4.3-build1.1";
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
                        Location = m_location
                    });

                var stoInput = new StorageAccountCreateParameters
                {
                    Location = m_location,
                    AccountType = AccountType.StandardGRS
                };

                StorageAccount storageAccountOutput = m_SrpClient.StorageAccounts.Create(rgName,
                    storageAccountName, stoInput).StorageAccount;
                bool created = false;
                while (!created)
                {
                    ComputeManagementTestUtilities.WaitSeconds(10);
                    var stos = m_SrpClient.StorageAccounts.ListByResourceGroup(rgName);
                    created =
                        stos.StorageAccounts.Any(
                            t =>
                                StringComparer.OrdinalIgnoreCase.Equals(t.Name, storageAccountName));
                }

                storageAccountOutput.Name = storageAccountName; // TODO: try to remove this in a future recording

                return storageAccountOutput;
            }
            catch
            {
                var deleteRg1Response = m_ResourcesClient.ResourceGroups.Delete(rgName);
                Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.OK);
                throw;
            }
        }

        protected VirtualMachine CreateVM(string rgName, string asName, StorageAccount storageAccount, string imgRefId, 
            out VirtualMachine inputVM,
            Action<VirtualMachine> vmCustomizer = null,
            bool createWithPublicIpAddress = false)
        {
            try
            {
                // Create the resource Group, it might have been already created during StorageAccount creation.
                var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    rgName,
                    new ResourceGroup
                    {
                        Location = m_location
                    });

                PublicIpAddressGetResponse getPublicIpAddressResponse = createWithPublicIpAddress ? null : CreatePublicIP(rgName);
                
                SubnetGetResponse subnetResponse = CreateVNET(rgName);

                NetworkInterfaceGetResponse nicResponse = CreateNIC(rgName, subnetResponse.Subnet, getPublicIpAddressResponse.PublicIpAddress);

                string asetId = CreateAvailabilitySet(rgName, asName);

                inputVM = CreateDefaultVMInput(rgName, storageAccount.Name, imgRefId, asetId, nicResponse.NetworkInterface.Id);
                if (vmCustomizer != null)
                {
                    vmCustomizer(inputVM);
                }

                string expectedVMReferenceId = Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name);

                var createOrUpdateResponse = m_CrpClient.VirtualMachines.BeginCreatingOrUpdating (
                     rgName,  inputVM);

                Assert.True(createOrUpdateResponse.StatusCode == HttpStatusCode.Created);

                Assert.True(createOrUpdateResponse.VirtualMachine.Name == inputVM.Name);
                Assert.True(createOrUpdateResponse.VirtualMachine.Location == inputVM.Location.ToLower().Replace(" ", "") || createOrUpdateResponse.VirtualMachine.Location.ToLower() == inputVM.Location.ToLower());

                Assert.True(
                    createOrUpdateResponse.VirtualMachine.AvailabilitySetReference.ReferenceUri
                        .ToLowerInvariant() == asetId.ToLowerInvariant());
                ValidateVM(inputVM, createOrUpdateResponse.VirtualMachine, expectedVMReferenceId);

                var operationUri = new Uri(createOrUpdateResponse.AzureAsyncOperation);
                string operationId = operationUri.Segments.LastOrDefault();
                var lroResponse =
                    m_CrpClient.GetLongRunningOperationStatus(createOrUpdateResponse.AzureAsyncOperation.ToString());
                ValidateLROResponse(lroResponse, operationId);

                var getResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name);
                Assert.True(getResponse.StatusCode == HttpStatusCode.OK);
                ValidateVM(inputVM, getResponse.VirtualMachine, expectedVMReferenceId);

                return getResponse.VirtualMachine;
            }
            catch
            {
                var deleteRg1Response = m_ResourcesClient.ResourceGroups.Delete(rgName);
                Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.OK);
                throw;
            }
        }

        protected PublicIpAddressGetResponse CreatePublicIP(string rgName)
        {
            // Create publicIP
            string publicIpName = TestUtilities.GenerateName();
            string domainNameLabel = TestUtilities.GenerateName();

            var publicIp = new PublicIpAddress()
            {
                Location = m_location,
                Tags = new Dictionary<string, string>()
                    {
                        {"key", "value"}
                    },
                PublicIpAllocationMethod = IpAllocationMethod.Dynamic,
                DnsSettings = new PublicIpAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            var putPublicIpAddressResponse = m_NrpClient.PublicIpAddresses.CreateOrUpdate(rgName, publicIpName, publicIp);
            var getPublicIpAddressResponse = m_NrpClient.PublicIpAddresses.Get(rgName, publicIpName);
            return getPublicIpAddressResponse;
        }

        protected SubnetGetResponse CreateVNET(string rgName)
        {
            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = TestUtilities.GenerateName();
            string subnetName = TestUtilities.GenerateName();

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

        protected NetworkInterfaceGetResponse CreateNIC(string rgName, Subnet subnet, PublicIpAddress publicIPaddress, string nicname = null)
        {
            // Create Nic
            nicname = nicname ?? TestUtilities.GenerateName();
            string ipConfigName = TestUtilities.GenerateName();

            var nicParameters = new NetworkInterface()
            {
                Location = m_location,
                Name = nicname,
                Tags = new Dictionary<string, string>()
                {
                    { "key" ,"value" }
                },
                IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                {
                    new NetworkInterfaceIpConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                        Subnet = subnet,
                    }
                }
            };

            if (publicIPaddress != null)
            {
                nicParameters.IpConfigurations[0].PublicIpAddress = new ResourceId { Id = publicIPaddress.Id };
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
                Name = asName,
                Tags = new Dictionary<string, string>()
                    {
                        {"RG", "rg"},
                        {"testTag", "1"}
                    }
            };

            // Create an Availability Set and then create a VM inside this availability set
            var asCreateOrUpdateResponse = m_CrpClient.AvailabilitySets.CreateOrUpdate(
                rgName,
                inputAvailabilitySet
            );
            var asetId = Helpers.GetAvailabilitySetRef(m_subId, rgName, asCreateOrUpdateResponse.AvailabilitySet.Name);
            Assert.True(asCreateOrUpdateResponse.StatusCode == HttpStatusCode.OK);
            return asetId;
        }

        protected VirtualMachine CreateDefaultVMInput(string rgName, string storageAccountName, string imgRefId, string asetId, string nicId)
        {
            // Generate Container name to hold disk VHds
            string containerName = TestUtilities.GenerateName(TestPrefix);
            var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
            var vhduri = vhdContainer + string.Format("/{0}.vhd", TestUtilities.GenerateName(TestPrefix));
            var osVhduri = vhdContainer + string.Format("/os{0}.vhd", TestUtilities.GenerateName(TestPrefix));

            return new VirtualMachine
            {
                Name = TestUtilities.GenerateName("vm"),
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                Type = "Microsoft.Compute/virtualMachines",
                AvailabilitySetReference = new AvailabilitySetReference { ReferenceUri = asetId },
                HardwareProfile = new HardwareProfile
                {
                    VirtualMachineSize = VirtualMachineSizeTypes.StandardA0
                },
                StorageProfile = new StorageProfile
                {
                    SourceImage = new SourceImageReference
                    {
                        ReferenceUri = imgRefId
                    },
                    OSDisk = new OSDisk
                    {
                        Caching = CachingTypes.None,
                        CreateOption = DiskCreateOptionTypes.FromImage,
                        Name = "test",
                        VirtualHardDisk = new VirtualHardDisk
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
                                ReferenceUri = nicId
                            }
                        }
                },
                OSProfile = new OSProfile
                {
                    AdminUsername = "Foo12",
                    AdminPassword = "BaR@123" + rgName,
                    ComputerName = "test"
                }
            };
        }
        
        protected void ValidateLROResponse(ComputeLongRunningOperationResponse lroResponse, string operationId)
        {
            Assert.NotNull(lroResponse);
            Assert.NotNull(lroResponse.Status);
            Assert.Equal(operationId, lroResponse.TrackingOperationId);
            Assert.NotNull(lroResponse.StartTime);
            //Assert.NotNull(lroResponse.EndTime); // TODO: it's null somtimes.
        }

        protected void ValidateVM(VirtualMachine vm, VirtualMachine vmOut, string expectedVMReferenceId)
        {
            Assert.True(!string.IsNullOrEmpty(vmOut.ProvisioningState));

            Assert.True(vmOut.HardwareProfile.VirtualMachineSize
                     == vm.HardwareProfile.VirtualMachineSize);

            Assert.True(vmOut.StorageProfile.OSDisk != null);

            if (vm.StorageProfile.OSDisk != null)
            {
                Assert.True(vmOut.StorageProfile.OSDisk.Name
                         == vm.StorageProfile.OSDisk.Name);

                Assert.True(vmOut.StorageProfile.OSDisk.VirtualHardDisk.Uri
                == vm.StorageProfile.OSDisk.VirtualHardDisk.Uri);

                Assert.True(vmOut.StorageProfile.OSDisk.Caching
                         == vm.StorageProfile.OSDisk.Caching);
            }

            if (vm.StorageProfile.DataDisks != null &&
                vm.StorageProfile.DataDisks.Any())
            {
                foreach (var dataDisk in vm.StorageProfile.DataDisks)
                {
                    var dataDiskOut = vmOut.StorageProfile.DataDisks.FirstOrDefault(
                            d => string.Equals(dataDisk.Name, d.Name, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(dataDiskOut);

                    Assert.NotNull(dataDiskOut.VirtualHardDisk);
                    Assert.NotNull(dataDiskOut.VirtualHardDisk.Uri);

                    if (dataDisk.SourceImage != null && dataDisk.SourceImage.Uri != null)
                    {
                        Assert.NotNull(dataDiskOut.SourceImage);
                        Assert.Equal(dataDisk.SourceImage.Uri, dataDiskOut.SourceImage.Uri);
                    }
                }
            }

            if(vm.OSProfile != null &&
               vm.OSProfile.Secrets != null &&
               vm.OSProfile.Secrets.Any())
            {
                foreach (var secret in vm.OSProfile.Secrets)
                {
                    var secretOut = vmOut.OSProfile.Secrets.FirstOrDefault( s => string.Equals(secret.SourceVault.ReferenceUri, s.SourceVault.ReferenceUri));
                    var VaultCertComparer = new VaultCertComparer();
                    Assert.True(secretOut.VaultCertificates.SequenceEqual(secret.VaultCertificates, VaultCertComparer));
                }
            }

            Assert.NotNull(vmOut.AvailabilitySetReference);
            Assert.True(vm.AvailabilitySetReference.ReferenceUri.ToLowerInvariant() == vmOut.AvailabilitySetReference.ReferenceUri.ToLowerInvariant());
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

            if (vmIn.StorageProfile.OSDisk != null)
            {
                Assert.True(instanceView.Disks.Any(x => x.Name == vmIn.StorageProfile.OSDisk.Name));
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
