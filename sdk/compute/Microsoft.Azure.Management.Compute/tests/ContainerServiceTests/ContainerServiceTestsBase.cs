// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class ContainerServiceTestsBase : VMTestBase
    {
        protected const string ContainerServiceNamePrefix = "cs";
        protected const string AgentPoolProfileDnsPrefix = "apdp";
        protected const string MasterProfileDnsPrefix = "mdp";

        protected const string MesosOrchestratorType = "Mesos";
        protected const string DefaultAgentPoolProfileName = "AgentPool1";
        
        protected string DefaultVmSize = VirtualMachineSizeTypes.StandardA1;
        protected const string DefaultLinuxAdminUsername = "azureuser";
        protected const string ContainerServiceType = "Microsoft.ContainerService/ContainerServices";
        private const string DefaultSshPublicKey =
            "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2" +
            "MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2" +
            "oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgE" +
            "Sgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h" +
            "9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417" + 
            "u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4" +
            "bL acs-bot@microsoft.com";

        protected ContainerService CreateDefaultContainerServiceInput(string rgName, string masterDnsPrefix, string agentPoolDnsPrefix)
        {
            var publicKeys = new ContainerServiceSshPublicKey
            {
                KeyData = DefaultSshPublicKey
            };

            var agentPoolProfiles = new ContainerServiceAgentPoolProfile
            {
                DnsPrefix = agentPoolDnsPrefix,
                Name = DefaultAgentPoolProfileName,
                VmSize = DefaultVmSize,
                Count = 1 // This should be added because of AutoRest bug.
            };

            return new ContainerService
            {
                Location = m_location,
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                AgentPoolProfiles = new [] { agentPoolProfiles },

                // Todo: DiagnosticsProfile will be available in GA
                //DiagnosticsProfile = new ContainerServiceDiagnosticsProfile
                //{
                //    VmDiagnostics = new ContainerServiceVMDiagnostics
                //    {
                //        Enabled = true
                //    }
                //},
                
                LinuxProfile = new ContainerServiceLinuxProfile
                {
                    AdminUsername = DefaultLinuxAdminUsername,
                    Ssh = new ContainerServiceSshConfiguration
                    {
                        PublicKeys = new [] { publicKeys}
                    }
                },
                MasterProfile = new ContainerServiceMasterProfile
                {
                    DnsPrefix = masterDnsPrefix
                },
                OrchestratorProfile = new ContainerServiceOrchestratorProfile
                {
                    OrchestratorType = ContainerServiceOrchestratorTypes.DCOS
                }
            };
        }

        protected ContainerService CreateContainerService_NoAsyncTracking(
            string rgName,
            string csName,
            string masterDnsPrefix,
            string agentPoolDnsPrefix,
            out ContainerService inputContainerService,
            Action<ContainerService> containerServiceCustomizer = null)
        {
            try
            {
                var createOrUpdateResponse = CreateContainerServiceAndGetOperationResponse(
                    rgName,
                    csName,
                    masterDnsPrefix,
                    agentPoolDnsPrefix,
                    out inputContainerService,
                    containerServiceCustomizer);
                var getResponse = m_CrpClient.ContainerServices.Get(rgName, csName);
                ValidateContainerService(createOrUpdateResponse, getResponse);
                return getResponse;
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(rgName);
                throw;
            }
        }

        protected void UpdateContainerService(string rgName, string vmssName, ContainerService inputContainerService)
        {
            var createOrUpdateResponse = m_CrpClient.ContainerServices.CreateOrUpdate(rgName, vmssName, inputContainerService);
        }

        private ContainerService CreateContainerServiceAndGetOperationResponse(
            string rgName,
            string csName,
            string masterDnsPrefix,
            string agentPoolDnsPrefix,
            out ContainerService inputContainerService,
            Action<ContainerService> containerServiceCustomizer = null)
        {
            var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = m_location
                });

            inputContainerService = CreateDefaultContainerServiceInput(rgName, masterDnsPrefix, agentPoolDnsPrefix);
            if (containerServiceCustomizer != null)
            {
                containerServiceCustomizer(inputContainerService);
            }

            var createOrUpdateResponse = m_CrpClient.ContainerServices.CreateOrUpdate(rgName, csName, inputContainerService);

            Assert.Equal(csName, createOrUpdateResponse.Name);
            Assert.Equal(inputContainerService.Location.ToLower().Replace(" ", ""), createOrUpdateResponse.Location.ToLower());
            Assert.Equal(ContainerServiceType, createOrUpdateResponse.Type);

            ValidateContainerService(inputContainerService, createOrUpdateResponse);

            return createOrUpdateResponse;
        }

        protected void ValidateContainerService(ContainerService containerService, ContainerService containerServiceOut)
        {
            Assert.True(!string.IsNullOrEmpty(containerServiceOut.ProvisioningState));

            // Verify DiagnosticsProfile
            if (containerService.DiagnosticsProfile != null)
            {
                Assert.Equal(containerService.DiagnosticsProfile.VmDiagnostics.Enabled,
                    containerServiceOut.DiagnosticsProfile.VmDiagnostics.Enabled);
            }

            // Verify AgentPoolProfiles
            Assert.NotNull(containerServiceOut.AgentPoolProfiles);
            Assert.Equal(containerService.AgentPoolProfiles.Count, containerServiceOut.AgentPoolProfiles.Count);
            for (var i = 0; i < containerService.AgentPoolProfiles.Count; i++)
            {
                Assert.Equal(containerService.AgentPoolProfiles[i].Name, containerServiceOut.AgentPoolProfiles[i].Name);
                Assert.Equal(containerService.AgentPoolProfiles[i].Count, containerServiceOut.AgentPoolProfiles[i].Count);
                Assert.Equal(containerService.AgentPoolProfiles[i].DnsPrefix, containerServiceOut.AgentPoolProfiles[i].DnsPrefix);
                Assert.Equal(containerService.AgentPoolProfiles[i].VmSize, containerServiceOut.AgentPoolProfiles[i].VmSize);
                Assert.NotNull(containerServiceOut.AgentPoolProfiles[i].Fqdn);
            }

            // Verify MasterProfile
            Assert.NotNull(containerServiceOut.MasterProfile);
            Assert.Equal(containerService.MasterProfile.Count ?? 1, containerServiceOut.MasterProfile.Count);
            Assert.Equal(containerService.MasterProfile.DnsPrefix, containerServiceOut.MasterProfile.DnsPrefix);
            Assert.NotNull(containerServiceOut.MasterProfile.Fqdn);

            // Verify LinuxProfile
            Assert.NotNull(containerServiceOut.LinuxProfile);
            Assert.Equal(containerService.LinuxProfile.AdminUsername.ToLowerInvariant(), containerServiceOut.LinuxProfile.AdminUsername.ToLowerInvariant());
            Assert.Equal(containerService.LinuxProfile.Ssh.PublicKeys.Count, containerServiceOut.LinuxProfile.Ssh.PublicKeys.Count);

            for (var i = 0; i < containerService.LinuxProfile.Ssh.PublicKeys.Count; i++)
            {
                // Remove key data validation because it is caught by cred scan.
                Assert.Equal(containerService.LinuxProfile.Ssh.PublicKeys[i].KeyData,
                    containerServiceOut.LinuxProfile.Ssh.PublicKeys[i].KeyData);
            }

            // Verify WindowsProfile
            if (containerService.WindowsProfile != null)
            {
                Assert.Equal(containerService.WindowsProfile.AdminUsername, containerServiceOut.WindowsProfile.AdminUsername);
            }
        }
    }
}


