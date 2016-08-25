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
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
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
        protected const string DefaultLinuxAdminUsername = "acsLinuxAdmin";
        protected const string ContainerServiceType = "Microsoft.ContainerService/ContainerServices";
        private const string DefaultSshPublicKey =
            "MIIDszCCApugAwIBAgIJALBV9YJCF/tAMA0GCSqGSIb3DQEBBQUAMEUxCzAJBgNV" +
            "BAYTAkFVMRMwEQYDVQQIEwpTb21lLVN0YXRlMSEwHwYDVQQKExhJbnRlcm5ldCBX" +
            "aWRnaXRzIFB0eSBMdGQwHhcNMTUwMzIyMjI1NDQ5WhcNMTYwMzIxMjI1NDQ5WjBF" +
            "MQswCQYDVQQGEwJBVTETMBEGA1UECBMKU29tZS1TdGF0ZTEhMB8GA1UEChMYSW50" +
            "ZXJuZXQgV2lkZ2l0cyBQdHkgTHRkMIIBIDANBgkqhkiG9w0BAQEFAAOCAQ0AMIIB" +
            "CAKCAQEAxDC+OfmB+tQ+P1MLmuuW2hJLdcK8m4DLgAk5l8bQDNBcVezt+bt/ZFMs" +
            "CHBhfTZG9O9yqMn8IRUh7/7jfQm6DmXCgtxj/uFiwT+F3out5uWvMV9SjFYvu9kJ" +
            "NXiDC2u3l4lHV8eHde6SbKiZB9Jji9FYQV4YiWrBa91j9I3hZzbTL0UCiJ+1PPoL" +
            "Rx/T1s9KT5Wn8m/z2EDrHWpetYu45OA7nzyIFOyQup5oWadWNnpk6HkCGutl9t9b" +
            "cLdjXjXPm9wcy1yxIB3Dj/Y8Hnulr80GJlUtUboDm8TExGc4YaPJxdn0u5igo5gZ" +
            "c6qnqH/BMd1nsyICx6AZnKBXBycoSQIBI6OBpzCBpDAdBgNVHQ4EFgQUzWhrCCDs" +
            "ClANCGlKZ64rHp2BDn0wdQYDVR0jBG4wbIAUzWhrCCDsClANCGlKZ64rHp2BDn2h" +
            "SaRHMEUxCzAJBgNVBAYTAkFVMRMwEQYDVQQIEwpTb21lLVN0YXRlMSEwHwYDVQQK" +
            "ExhJbnRlcm5ldCBXaWRnaXRzIFB0eSBMdGSCCQCwVfWCQhf7QDAMBgNVHRMEBTAD" +
            "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCUaJnX0aBzwBkbJrBS5YvkZnNKLdc4oHgC" +
            "/Nsr/9pwXzFYYXkdqpTw2nygH0C0WuPVVrG3Y3EGx/UIGDtLbwMvZJhQN9mZH3oX" +
            "+c3HGqBnXGuDRrtsfsK1ywAofx9amZfKNk/04/Rt3POdbyD1/AOADw2zMokbIapX" +
            "+nMDUtD/Tew9+0qU9+dcFMrFE1N4utlrFHlrLFbiCA/eSegP6gOeu9mqZv7UHIz2" +
            "oe6IQTw7zJF7xuBIzTYwjOCM197GKW7xc4GU4JZIN+faZ7njl/fxfUNdlqvgZUUn" +
            "kfdrzU3PZPl0w9NuncgEje/PZ+YtZvIsnH7MLSPeIGNQwW6V2kc8";

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
                VmSize = DefaultVmSize
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
                    OrchestratorType = ContainerServiceOchestratorTypes.DCOS
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
                var getResponse = m_CrpClient.ContainerService.Get(rgName, csName);
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
            var createOrUpdateResponse = m_CrpClient.ContainerService.CreateOrUpdate(rgName, vmssName, inputContainerService);
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

            var createOrUpdateResponse = m_CrpClient.ContainerService.CreateOrUpdate(rgName, csName, inputContainerService);

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
                Assert.Equal(containerService.AgentPoolProfiles[i].Count ?? 1, containerServiceOut.AgentPoolProfiles[i].Count);
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
            Assert.Equal(containerService.LinuxProfile.AdminUsername, containerServiceOut.LinuxProfile.AdminUsername);
            Assert.Equal(containerService.LinuxProfile.Ssh.PublicKeys.Count, containerServiceOut.LinuxProfile.Ssh.PublicKeys.Count);
            for (var i = 0; i < containerService.LinuxProfile.Ssh.PublicKeys.Count; i++)
            {
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

