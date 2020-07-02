// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ContainerServiceTestsBase : VMTestBase
    {
        public ContainerServiceTestsBase(bool isAsync)
           : base(isAsync)
        {
        }

        protected const string ContainerServiceNamePrefix = "cs";
        protected const string AgentPoolProfileDnsPrefix = "apdp";
        protected const string MasterProfileDnsPrefix = "mdp";
        protected const string MesosOrchestratorType = "Mesos";
        protected const string DefaultAgentPoolProfileName = "agentpool1";
        protected string DefaultVmSize = VirtualMachineSizeTypes.StandardA1.ToString();
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
            var publicKeys = new ContainerServiceSshPublicKey(DefaultSshPublicKey);

            var agentPoolProfiles = new ContainerServiceAgentPoolProfile(DefaultAgentPoolProfileName,1, DefaultVmSize, agentPoolDnsPrefix){
            };

            return new ContainerService(m_location)
            {
                Tags = new Dictionary<string, string>() { { "RG", "rg" }, { "testTag", "1" } },
                AgentPoolProfiles = new[] { agentPoolProfiles },
                // Todo: DiagnosticsProfile will be available in GA
                //DiagnosticsProfile = new ContainerServiceDiagnosticsProfile
                //{
                //    VmDiagnostics = new ContainerServiceVMDiagnostics
                //    {
                //        Enabled = true
                //    }
                //},

                LinuxProfile = new ContainerServiceLinuxProfile(DefaultLinuxAdminUsername, new ContainerServiceSshConfiguration( new[] { publicKeys })
                {
                }),
                MasterProfile = new ContainerServiceMasterProfile(masterDnsPrefix)
                {
                },
                OrchestratorProfile = new ContainerServiceOrchestratorProfile(ContainerServiceOrchestratorTypes.Dcos)
                {
                }
            };
        }

        protected async Task<(ContainerService, ContainerService)> CreateContainerService_NoAsyncTracking(
            string rgName,
            string csName,
            string masterDnsPrefix,
            string agentPoolDnsPrefix,
            //out ContainerService inputContainerService,
            Action<ContainerService> containerServiceCustomizer = null)
        {
            try
            {
                var getTwoServiceOpera =await CreateContainerServiceAndGetOperationResponse(
                    rgName,
                    csName,
                    masterDnsPrefix,
                    agentPoolDnsPrefix,
                    //out inputContainerService,
                    containerServiceCustomizer);
                var createOrUpdateResponse = getTwoServiceOpera.Item1;
                var inputContainerService = getTwoServiceOpera.Item2;
                var getResponse = await ContainerServicesOperations.GetAsync(rgName, csName);
                ValidateContainerService(createOrUpdateResponse, getResponse);
                return (getResponse, inputContainerService);
            }
            catch
            {
                throw;
            }
        }

        protected async void UpdateContainerService(string rgName, string vmssName, ContainerService inputContainerService)
        {
            var createOrUpdateResponse = await WaitForCompletionAsync(await ContainerServicesOperations.StartCreateOrUpdateAsync(rgName, vmssName, inputContainerService));
        }

        private async Task<(ContainerService, ContainerService)> CreateContainerServiceAndGetOperationResponse(
            string rgName,
            string csName,
            string masterDnsPrefix,
            string agentPoolDnsPrefix,
            //out ContainerService inputContainerService,
            Action<ContainerService> containerServiceCustomizer = null)
        {
            var resourceGroup = await ResourceGroupsOperations.CreateOrUpdateAsync(
                rgName,
                new ResourceGroup(m_location));
            var inputContainerService = CreateDefaultContainerServiceInput(rgName, masterDnsPrefix, agentPoolDnsPrefix);
            if (containerServiceCustomizer != null)
            {
                containerServiceCustomizer(inputContainerService);
            }
            var createOrUpdateResponse = await WaitForCompletionAsync(await ContainerServicesOperations.StartCreateOrUpdateAsync(rgName, csName, inputContainerService));
            Assert.AreEqual(csName, createOrUpdateResponse.Value.Name);
            Assert.AreEqual(inputContainerService.Location.ToLower().Replace(" ", ""), createOrUpdateResponse.Value.Location.ToLower());
            Assert.AreEqual(ContainerServiceType, createOrUpdateResponse.Value.Type);

            ValidateContainerService(inputContainerService, createOrUpdateResponse.Value);

            return (createOrUpdateResponse,inputContainerService);
            ;
        }

        protected void ValidateContainerService(ContainerService containerService, ContainerService containerServiceOut)
        {
            Assert.True(!string.IsNullOrEmpty(containerServiceOut.ProvisioningState));

            // Verify DiagnosticsProfile
            if (containerService.DiagnosticsProfile != null)
            {
                Assert.AreEqual(containerService.DiagnosticsProfile.VmDiagnostics.Enabled,
                    containerServiceOut.DiagnosticsProfile.VmDiagnostics.Enabled);
            }

            // Verify AgentPoolProfiles
            Assert.NotNull(containerServiceOut.AgentPoolProfiles);
            Assert.AreEqual(containerService.AgentPoolProfiles.Count, containerServiceOut.AgentPoolProfiles.Count);
            for (var i = 0; i < containerService.AgentPoolProfiles.Count; i++)
            {
                Assert.AreEqual(containerService.AgentPoolProfiles[i].Name, containerServiceOut.AgentPoolProfiles[i].Name);
                Assert.AreEqual(containerService.AgentPoolProfiles[i].Count, containerServiceOut.AgentPoolProfiles[i].Count);
                Assert.AreEqual(containerService.AgentPoolProfiles[i].DnsPrefix, containerServiceOut.AgentPoolProfiles[i].DnsPrefix);
                Assert.AreEqual(containerService.AgentPoolProfiles[i].VmSize, containerServiceOut.AgentPoolProfiles[i].VmSize);
                Assert.NotNull(containerServiceOut.AgentPoolProfiles[i].Fqdn);
            }

            // Verify MasterProfile
            Assert.NotNull(containerServiceOut.MasterProfile);
            Assert.AreEqual(containerService.MasterProfile.Count ?? 1, containerServiceOut.MasterProfile.Count);
            Assert.AreEqual(containerService.MasterProfile.DnsPrefix, containerServiceOut.MasterProfile.DnsPrefix);
            Assert.NotNull(containerServiceOut.MasterProfile.Fqdn);

            // Verify LinuxProfile
            Assert.NotNull(containerServiceOut.LinuxProfile);
            Assert.AreEqual(containerService.LinuxProfile.AdminUsername.ToLowerInvariant(), containerServiceOut.LinuxProfile.AdminUsername.ToLowerInvariant());
            Assert.AreEqual(containerService.LinuxProfile.Ssh.PublicKeys.Count, containerServiceOut.LinuxProfile.Ssh.PublicKeys.Count);

            for (var i = 0; i < containerService.LinuxProfile.Ssh.PublicKeys.Count; i++)
            {
                // Remove key data validation because it is caught by cred scan.
                Assert.AreEqual(containerService.LinuxProfile.Ssh.PublicKeys[i].KeyData,
                    containerServiceOut.LinuxProfile.Ssh.PublicKeys[i].KeyData);
            }

            // Verify WindowsProfile
            if (containerService.WindowsProfile != null)
            {
                Assert.AreEqual(containerService.WindowsProfile.AdminUsername, containerServiceOut.WindowsProfile.AdminUsername);
            }
        }
    }
}
