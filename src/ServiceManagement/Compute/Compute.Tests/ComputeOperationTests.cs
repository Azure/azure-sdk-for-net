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

using Microsoft.Azure;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Collections.Generic;
    using Xunit;

    public class ComputeOperationsTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact(Skip="TODO, Debug and enable Test")]
        public void CanCreateVirtualMachine()
        {
            TestUtilities.StartTest();
            using (fixture.ComputeClient = fixture.GetComputeManagementClient())
            {
                var serviceName = TestUtilities.GenerateName();
                var result = fixture.ComputeClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = fixture.Location,
                    Label = serviceName,
                    ServiceName = serviceName
                });

                // assert that the call worked
                Assert.Equal(result.StatusCode, HttpStatusCode.Created);

                VirtualMachineOSImageListResponse imagesList = fixture.ComputeClient.VirtualMachineOSImages.List();

                VirtualMachineOSImageListResponse.VirtualMachineOSImage imageToGet =
                    imagesList.Images.FirstOrDefault(i => string.Equals(i.OperatingSystemType, "Windows", StringComparison.OrdinalIgnoreCase));

                VirtualMachineOSImageGetResponse gottenImage = fixture.ComputeClient.VirtualMachineOSImages.Get(imageToGet.Name);

                VirtualMachineCreateDeploymentParameters parameters = CreateVMParameters(gottenImage, serviceName);

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    AdminUserName = "testuser",
                    AdminPassword = "@zur3R0ck5",
                    ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                    ComputerName = serviceName,
                    HostName = string.Format("{0}.cloudapp.net", serviceName),
                    EnableAutomaticUpdates = false,
                    TimeZone = "Pacific Standard Time"
                });

                OperationStatusResponse opResp =
                    fixture.ComputeClient.VirtualMachines.CreateDeployment(serviceName, parameters);

                Assert.Equal(opResp.Status, OperationStatus.Succeeded);
            }

            TestUtilities.EndTest();
        }

        private VirtualMachineOSImageGetResponse FindVMImage(string imageType)
        {
            VirtualMachineOSImageListResponse imagesList = fixture.ComputeClient.VirtualMachineOSImages.List();

            VirtualMachineOSImageListResponse.VirtualMachineOSImage imageToGet =
                imagesList.Images.FirstOrDefault(i => i.ImageFamily == null ? false : i.ImageFamily.Contains(imageType));
            
            return fixture.ComputeClient.VirtualMachineOSImages.Get(imageToGet.Name);
        }

        private VirtualMachineCreateDeploymentParameters CreateVMParameters(VirtualMachineOSImageGetResponse image, string serviceName)
        {
            string blobDiskFormat = "http://{1}.blob.core.windows.net/myvhds/{0}.vhd";

            Uri blobUrl = new Uri(string.Format(blobDiskFormat, serviceName, fixture.NewStorageAccountName));

            VirtualMachineCreateDeploymentParameters parameters = new VirtualMachineCreateDeploymentParameters
            {
                DeploymentSlot = DeploymentSlot.Production,
                Label = fixture.DeploymentLabel,
                Name = serviceName
            };
            parameters.Roles.Add(new Role
            {
                OSVirtualHardDisk = new OSVirtualHardDisk
                {
                    HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                    MediaLink = blobUrl,
                    SourceImageName = image.Name
                },
                ProvisionGuestAgent = true,
                RoleName = serviceName,
                RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                RoleSize = VirtualMachineRoleSize.Large.ToString(),
            });

            return parameters;
        }

        [Fact]
        public void CanCreateVMWithCustomData()
        {
            const int idleTimeoutInputEndpoint = 5;
            const int idleTimeoutPublicIp = 6;
            const string loadBalancerDistribution = "sourceIP";
            
            TestUtilities.StartTest();
            using (fixture.ComputeClient = fixture.GetComputeManagementClient())
            {
                var serviceName = TestUtilities.GenerateName();
                var result = fixture.ComputeClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = fixture.Location,
                    Label = serviceName,
                    ServiceName = serviceName
                });

                // assert that the call worked
                Assert.Equal(result.StatusCode, HttpStatusCode.Created);
                VirtualMachineCreateDeploymentParameters parameters = CreateVMParameters(FindVMImage("Ubuntu Server 14"), serviceName);

                string customdataBase64 = Convert.ToBase64String(File.ReadAllBytes(@"SampleService\CustomData.sh"));

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    UserName = "testuser",
                    UserPassword = "@zur3R0ck5",
                    ConfigurationSetType = ConfigurationSetTypes.LinuxProvisioningConfiguration,
                    ComputerName = serviceName,
                    HostName = string.Format("{0}.cloudapp.net", serviceName),
                    EnableAutomaticUpdates = false,
                    TimeZone = "Pacific Standard Time",
                    CustomData = customdataBase64,
                    DisableSshPasswordAuthentication = false
                });

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    ConfigurationSetType = ConfigurationSetTypes.NetworkConfiguration,
                    InputEndpoints = new List<InputEndpoint>
                {
                    new InputEndpoint()
                    {
                        LocalPort = 22,
                        Name = "SSH",
                        Port = 52222,
                        Protocol = InputEndpointTransportProtocol.Tcp,
                        IdleTimeoutInMinutes = idleTimeoutInputEndpoint,
                        LoadBalancerDistribution = loadBalancerDistribution
                    },
                    new InputEndpoint()
                    {
                        LocalPort = 24,
                        Name = "SSH1",
                        Port = 52224,
                        Protocol = InputEndpointTransportProtocol.Tcp,
                        IdleTimeoutInMinutes = idleTimeoutInputEndpoint,
                        LoadBalancerDistribution = loadBalancerDistribution
                    }
                },
                    PublicIPs = new List<ConfigurationSet.PublicIP>()
                {
                    new ConfigurationSet.PublicIP()
                    {
                        Name = "publicip1",
                        IdleTimeoutInMinutes = idleTimeoutPublicIp
                    }
                }
                });

                OperationStatusResponse opResp =
                    fixture.ComputeClient.VirtualMachines.CreateDeployment(serviceName, parameters);

                Assert.Equal(opResp.Status, OperationStatus.Succeeded);

                #region IdleTimeoutVerifications
                var deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);

                // Retrieve and verify the Timeouts in the configurationSet
                var configrationSet = deploymentResponse.Roles.First().ConfigurationSets.First();

                // Verify the timeout for PublicIP
                Assert.Equal("publicip1", configrationSet.PublicIPs.First().Name);
                Assert.Equal(idleTimeoutPublicIp, configrationSet.PublicIPs.First().IdleTimeoutInMinutes);

                // Verify the InputEndpoint timeouts
                foreach (var endpoint in configrationSet.InputEndpoints)
                {
                    Assert.Equal(idleTimeoutInputEndpoint, endpoint.IdleTimeoutInMinutes);
                    Assert.Equal(loadBalancerDistribution, endpoint.LoadBalancerDistribution);
                }

                // Retrieve and verify the Timeouts in the InstanceRole
                var instanceRole = deploymentResponse.RoleInstances.First();

                // Verify the timeout for PublicIP
                Assert.Equal("publicip1", instanceRole.PublicIPs.First().Name);
                Assert.Equal(idleTimeoutPublicIp, instanceRole.PublicIPs.First().IdleTimeoutInMinutes);

                // Verify the InstanceEndpoint timeouts
                foreach (var endpoint in instanceRole.InstanceEndpoints)
                {
                    Assert.Equal(idleTimeoutInputEndpoint, endpoint.IdleTimeoutInMinutes);
                }
                #endregion
            }

            TestUtilities.EndTest();
        }

        [Fact]
        public void CanCreateVMWithPublicIPDnsName()
        {
            const string loadBalancerDistribution = "sourceIP";
            
            TestUtilities.StartTest();
            string dnsName = TestUtilities.GenerateName();
            
            using (fixture.ComputeClient = fixture.GetComputeManagementClient())
            {
                var serviceName = TestUtilities.GenerateName();
                var result = fixture.ComputeClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = fixture.Location,
                    Label = serviceName,
                    ServiceName = serviceName
                });

                // assert that the call worked
                Assert.Equal(result.StatusCode, HttpStatusCode.Created);
                VirtualMachineCreateDeploymentParameters parameters = CreateVMParameters(FindVMImage("Ubuntu Server 14"), serviceName);

                string customdataBase64 = Convert.ToBase64String(File.ReadAllBytes(@"SampleService\CustomData.sh"));

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    UserName = "testuser",
                    UserPassword = "@zur3R0ck5",
                    ConfigurationSetType = ConfigurationSetTypes.LinuxProvisioningConfiguration,
                    ComputerName = serviceName,
                    HostName = string.Format("{0}.cloudapp.net", serviceName),
                    EnableAutomaticUpdates = false,
                    TimeZone = "Pacific Standard Time",
                    CustomData = customdataBase64,
                    DisableSshPasswordAuthentication = false
                });

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    ConfigurationSetType = ConfigurationSetTypes.NetworkConfiguration,
                    InputEndpoints = new List<InputEndpoint>
                    {
                        new InputEndpoint()
                        {
                            LocalPort = 22,
                            Name = "SSH",
                            Port = 52222,
                            Protocol = InputEndpointTransportProtocol.Tcp,
                            LoadBalancerDistribution = loadBalancerDistribution
                        }
                    },
                    PublicIPs = new List<ConfigurationSet.PublicIP>()
                    {
                        new ConfigurationSet.PublicIP()
                        {
                            Name = "publicip1",
                            DomainNameLabel = dnsName,
                        }
                    }
                });

                OperationStatusResponse opResp =
                    fixture.ComputeClient.VirtualMachines.CreateDeployment(serviceName, parameters);

                Assert.Equal(opResp.Status, OperationStatus.Succeeded);

                #region IdleTimeoutVerifications
                var deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);

                var configrationSet = deploymentResponse.Roles.First().ConfigurationSets.First();

                // Verify the dns name for PublicIP
                Assert.Equal("publicip1", configrationSet.PublicIPs.First().Name);
                Assert.Equal(dnsName, configrationSet.PublicIPs.First().DomainNameLabel);
                
                var instanceRole = deploymentResponse.RoleInstances.First();

                Assert.Equal("publicip1", instanceRole.PublicIPs.First().Name);
                Assert.Equal(dnsName, instanceRole.PublicIPs.First().DomainNameLabel);

                Assert.Equal(string.Format("{0}.{1}.cloudapp.net", dnsName, serviceName), instanceRole.PublicIPs.First().Fqdns[0]);
                Assert.Equal(string.Format("{0}.0.{1}.cloudapp.net", dnsName, serviceName), instanceRole.PublicIPs.First().Fqdns[1]);
                #endregion
            }

            TestUtilities.EndTest();
        }

        /// <summary>
        /// Test to verify that we are able to add/update/get/Delete 
        /// DNS Servers in a deployment
        /// </summary>
        [Fact]
        public void DNSServerOperationsTest()
        {
            TestUtilities.StartTest();
            using (fixture.ComputeClient = fixture.GetComputeManagementClient())
            {
                var serviceName = TestUtilities.GenerateName();
                var result = fixture.ComputeClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = fixture.Location,
                    Label = serviceName,
                    ServiceName = serviceName
                });

                // assert that the call worked
                Assert.Equal(result.StatusCode, HttpStatusCode.Created);
                // Create the deployment with a VM
                VirtualMachineCreateDeploymentParameters parameters = CreateVMParameters(FindVMImage("Ubuntu Server 14"), serviceName);

                string customdataBase64 = Convert.ToBase64String(File.ReadAllBytes(@"SampleService\CustomData.sh"));

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    UserName = "testuser",
                    UserPassword = "@zur3R0ck5",
                    ConfigurationSetType = ConfigurationSetTypes.LinuxProvisioningConfiguration,
                    ComputerName = serviceName,
                    HostName = string.Format("{0}.cloudapp.net", serviceName),
                    EnableAutomaticUpdates = false,
                    TimeZone = "Pacific Standard Time",
                    CustomData = customdataBase64,
                    DisableSshPasswordAuthentication = false
                });

                parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
                {
                    ConfigurationSetType = ConfigurationSetTypes.NetworkConfiguration,
                    InputEndpoints = new List<InputEndpoint>
                {
                    new InputEndpoint()
                    {
                        LocalPort = 22,
                        Name = "SSH",
                        Port = 52222,
                        Protocol = InputEndpointTransportProtocol.Tcp
                    }
                }
                });

                OperationStatusResponse opResp =
                    fixture.ComputeClient.VirtualMachines.CreateDeployment(serviceName, parameters);
                Assert.Equal(opResp.Status, OperationStatus.Succeeded);

                // Verify that there are no DNS servers present
                var deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);
                Assert.Null(deploymentResponse.DnsSettings);

                const string dnsServerName = "DnsServer";
                const string dnsServerAddress = "10.1.1.4";
                // Add a DNS server
                fixture.ComputeClient.DnsServer.AddDNSServer(serviceName,
                    parameters.Name,
                    new DNSAddParameters
                    {
                        Address = dnsServerAddress,
                        Name = dnsServerName
                    });

                // Get the DNS server added above
                deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);

                Assert.NotNull(deploymentResponse.DnsSettings);
                Assert.Equal(1, deploymentResponse.DnsSettings.DnsServers.Count());

                Assert.Equal(dnsServerName, deploymentResponse.DnsSettings.DnsServers.First().Name);
                Assert.Equal(dnsServerAddress, deploymentResponse.DnsSettings.DnsServers.First().Address);

                // Update the DNS server
                fixture.ComputeClient.DnsServer.UpdateDNSServer(serviceName,
                    parameters.Name,
                    dnsServerName,
                    new DNSUpdateParameters
                    {
                        Address = "10.1.1.6",
                        Name = dnsServerName
                    });

                // Get the updated DNS server
                deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);

                Assert.NotNull(deploymentResponse.DnsSettings);
                Assert.Equal(1, deploymentResponse.DnsSettings.DnsServers.Count());

                Assert.Equal(dnsServerName, deploymentResponse.DnsSettings.DnsServers.First().Name);
                Assert.Equal("10.1.1.6", deploymentResponse.DnsSettings.DnsServers.First().Address);

                // Delete the DNS server
                fixture.ComputeClient.DnsServer.DeleteDNSServer(serviceName,
                    parameters.Name,
                    dnsServerName);

                // Verify the Delete op
                deploymentResponse = fixture.ComputeClient.Deployments.GetByName(serviceName,
                    parameters.Name);
                Assert.Null(deploymentResponse.DnsSettings);
            }

            TestUtilities.EndTest();
        }
    }
}
