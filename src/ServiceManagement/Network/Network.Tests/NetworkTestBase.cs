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

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Testing;
using Network.Tests.Networks.TestOperations;
using AZT = Microsoft.Azure.Test;
using Xunit;

namespace Network.Tests
{
    public class NetworkTestBase : TestBase, IDisposable
    {
        private const string CloudServiceNamingExtension = ".cloudapp.net";
        private const string TestArtifactsNamePrefix = "NetworkTest";

        //needed for test artifacts cleaning up
        private object _syncObject = new object();
        private StringCollection _networkSecurityGroupsToCleanup = new StringCollection();
        private string _defaultLocation;

        public NetworkTestBase()
        {
            NetworkClient = GetServiceClient<NetworkManagementClient>();
            ManagementClient = GetServiceClient<ManagementClient>();
            ComputeClient = GetServiceClient<ComputeManagementClient>();
            StorageClient = GetServiceClient<StorageManagementClient>();
            _defaultLocation = ManagementTestUtilities.GetDefaultLocation(ManagementClient, "Compute");
        }

        public NetworkManagementClient NetworkClient { get; private set; }
        public ManagementClient ManagementClient { get; private set; }
        public ComputeManagementClient ComputeClient { get; private set; }
        public StorageManagementClient StorageClient { get; private set; }
        public string DefaultLocation
        {
            get
            {
                return _defaultLocation;
            }
        }

        private void RegisterToCleanup(string artifactName, StringCollection cleanupList)
        {
            lock (_syncObject)
            {
                cleanupList.Add(artifactName);
            }
        }

        private void UnregisterToCleanup(string artifactName, StringCollection cleanupList)
        {
            lock (_syncObject)
            {
                cleanupList.Remove(artifactName);
            }
        }

        public void CreateNetworkSecurityGroup(string name, string label, string location)
        {
            NetworkSecurityGroupCreateParameters parameters = new NetworkSecurityGroupCreateParameters()
            {
                Name = name,
                Label = label,
                Location = location
            };

            NetworkClient.NetworkSecurityGroups.Create(parameters);
            RegisterToCleanup(name, _networkSecurityGroupsToCleanup);
        }

        public void SetRuleToSecurityGroup(
            string securityGroupName,
            string ruleName,
            string action,
            string sourceAddressPrefix,
            string sourcePortRange,
            string destinationAddressPrefix,
            string destinationPortRange,
            int priority,
            string protocol,
            string type)
        {
            NetworkSecuritySetRuleParameters parameters = new NetworkSecuritySetRuleParameters()
            {
                Action = "Allow",
                SourceAddressPrefix = sourceAddressPrefix,
                SourcePortRange = sourcePortRange,
                DestinationAddressPrefix = destinationAddressPrefix,
                DestinationPortRange = destinationPortRange,
                Priority = priority,
                Protocol = protocol,
                Type = type
            };

            NetworkClient.NetworkSecurityGroups.SetRule(securityGroupName, ruleName, parameters);
        }

        public string GenerateRandomNetworkSecurityGroupName()
        {
            return GenerateRandomName(TestArtifactType.NetworkSecurityGroup);
        }

        public string GenerateRandomName()
        {
            return TestUtilities.GenerateName(TestArtifactsNamePrefix);
        }

        private string GenerateRandomName(TestArtifactType artifact)
        {
            return TestUtilities.GenerateName(TestArtifactsNamePrefix);
        }

        public void DeleteNetworkSecurityGroup(string securityGroupName)
        {
            NetworkClient.NetworkSecurityGroups.Delete(securityGroupName);
            UnregisterToCleanup(securityGroupName, _networkSecurityGroupsToCleanup);
        }

        public void SetSimpleVirtualNetwork()
        {
            SetNetworkConfiguration testOperation = new SetNetworkConfiguration(NetworkClient, NetworkTestConstants.SimpleNetworkConfigurationParameters);
            testOperation.Invoke();
        }

        public void DeleteNetworkConfiguration()
        {
            SetNetworkConfiguration testOperation = new SetNetworkConfiguration(NetworkClient, NetworkTestConstants.DeleteNetworkConfigurationParameters);
            testOperation.Invoke();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            foreach (string group in _networkSecurityGroupsToCleanup)
            {
                try
                {
                    NetworkClient.NetworkSecurityGroups.Delete(group);
                }
                catch { }
            }

            DeleteNetworkConfiguration();

            NetworkClient.Dispose();
            ManagementClient.Dispose();
        }

        private enum TestArtifactType
        {
            NetworkSecurityGroup
        }

        public OSVirtualHardDisk GetOSVirtualHardDisk(string storageAccountName, string serviceName)
        {
            VirtualMachineOSImageListResponse imagesList = this.ComputeClient.VirtualMachineOSImages.List();

            VirtualMachineOSImageListResponse.VirtualMachineOSImage image =
                imagesList.Images.FirstOrDefault(i => string.Equals(i.OperatingSystemType, "Windows", StringComparison.OrdinalIgnoreCase));

            string blobDiskFormat = "http://{0}.blob.core.test-cint.azure-test.net/myvhds/{1}.vhd";

            Uri blobUrl = new Uri(string.Format(blobDiskFormat, storageAccountName, serviceName));

            return new OSVirtualHardDisk()
            {
                HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                MediaLink = blobUrl,
                SourceImageName = image.Name
            };
        }

        public VirtualMachineCreateDeploymentParameters CreateMultiNICIaaSDeploymentParameters(
            string serviceName,
            string deploymentName,
            string roleName,
            string networkInterfaceName,
            string storageAccountName,
            string virtualNetworkName,
            string subnetName)
        {
            return new VirtualMachineCreateDeploymentParameters()
            {
                DeploymentSlot = DeploymentSlot.Production,
                Label = "Random Label",
                Name = deploymentName,
                VirtualNetworkName = virtualNetworkName,
                Roles = new List<Role>()
                {
                    new Role()
                    {
                        RoleName = roleName,
                        RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                        RoleSize = VirtualMachineRoleSize.Large.ToString(),
                        OSVirtualHardDisk = GetOSVirtualHardDisk(storageAccountName, serviceName),
                        ConfigurationSets = new List<ConfigurationSet>()
                        {
                            new ConfigurationSet()
                            {
                                AdminUserName = "testuser",
                                AdminPassword = "@zur3R0ck5",
                                ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                                ComputerName = serviceName,
                                HostName = string.Format("{0}.cloudapp.net", serviceName),
                                EnableAutomaticUpdates = false,
                                TimeZone = "Pacific Standard Time"
                            },
                            new ConfigurationSet()
                            {
                                ConfigurationSetType = ConfigurationSetTypes.NetworkConfiguration,
                                SubnetNames = new List<string>()
                                {
                                    subnetName
                                },
                                NetworkInterfaces = new List<NetworkInterface>()
                                {
                                    new NetworkInterface()
                                    {
                                        Name = networkInterfaceName,
                                        IPConfigurations = new List<IPConfiguration>()
                                        {
                                            new IPConfiguration()
                                            {
                                                SubnetName = subnetName,
                                            }
                                        }
                                    }
                                }
                            },

                        }
                    }
                }
            };
        }

        public DeploymentGetResponse CreatePaaSDeployment(
            string storageAccountName,
            string serviceName,
            string deploymentName,
            string pkgFileName,
            string cscfgFilePath)
        {
            var containerStr = AZT.TestUtilities.GenerateName("cspkg");
            var pkgFilePath = ".\\" + pkgFileName;

            var blobUri = StorageTestUtilities.UploadFileToBlobStorage(
                storageAccountName,
                containerStr,
                pkgFilePath);
            var blobUriStr = blobUri.ToString();
            var containerUriStr = blobUriStr.Substring(0, blobUriStr.IndexOf("/" + pkgFileName));
            containerUriStr = containerUriStr.Replace("https", "http");
            var containerUri = new Uri(containerUriStr);

            var deploymentCreate = this.ComputeClient.Deployments.Create(
                serviceName,
                DeploymentSlot.Production,
                new DeploymentCreateParameters
                {
                    Configuration = File.ReadAllText(cscfgFilePath),
                    PackageUri = blobUri,
                    Name = deploymentName,
                    Label = serviceName,
                    ExtendedProperties = null,
                    StartDeployment = false,
                    TreatWarningsAsError = false,
                    ExtensionConfiguration = null
                });

            Assert.True(deploymentCreate.StatusCode == HttpStatusCode.OK);

            var deploymentReceived = this.ComputeClient.Deployments.GetByName(serviceName, deploymentName);
            return deploymentReceived;
        }

        public void CreateHostedService(string location, string serviceName, out bool hostedServiceCreated)
        {
            AzureOperationResponse hostedServiceCreate = this.ComputeClient.HostedServices.Create(
            new HostedServiceCreateParameters
            {
                Location = location,
                Label = serviceName,
                ServiceName = serviceName
            });

            Assert.True(hostedServiceCreate.StatusCode == HttpStatusCode.Created);

            hostedServiceCreated = true;
        }

        public void CreateStorageAccount(string location, string storageAccountName, out bool storageAccountCreated)
        {
            AzureOperationResponse storageCreate = this.StorageClient.StorageAccounts.Create(
                new StorageAccountCreateParameters
                {
                    Location = location,
                    Label = storageAccountName,
                    Name = storageAccountName,
                    AccountType = "Standard_LRS"
                });
            Assert.True(storageCreate.StatusCode == HttpStatusCode.OK);
            storageAccountCreated = true;
        }

        public void AssociateReservedIP(
            string usWestLocStr,
            string location,
            string storageAccountName,
            ref bool storageAccountCreated,
            string serviceName,
            string deploymentName,
            string reserveIpName,
            ref bool hostedServiceCreated,
            ref bool reserveIpCreated)
        {
            if (this.ManagementClient.Locations.List().Any(
                c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
            {
                location = usWestLocStr;
            }

            this.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);

            this.CreateHostedService(location, serviceName, out hostedServiceCreated);

            this.CreatePaaSDeployment(storageAccountName, serviceName, deploymentName, NetworkTestConstants.OneWebOneWorkerPkgFilePath, "OneWebOneWorker.cscfg");

            NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
            {
                Name = reserveIpName,
                Location = "uswest",
                Label = "SampleReserveIPLabel"
            };

            OperationStatusResponse reserveIpCreate = this.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);
            Assert.True(reserveIpCreate.StatusCode == HttpStatusCode.OK);
            reserveIpCreated = true;

            NetworkReservedIPGetResponse reserveIpCreationResponse =
                this.NetworkClient.ReservedIPs.Get(reserveIpName);

            Assert.True(reserveIpCreationResponse.StatusCode == HttpStatusCode.OK);


            NetworkReservedIPMobilityParameters pars = new NetworkReservedIPMobilityParameters
            {
                ServiceName = serviceName,
                DeploymentName = deploymentName
            };
            OperationStatusResponse responseAssociateRip = this.NetworkClient.ReservedIPs.Associate(reserveIpName, pars);
            Assert.True(responseAssociateRip.StatusCode == HttpStatusCode.OK);

            NetworkReservedIPGetResponse receivedReservedIpFromRdfe =
                this.NetworkClient.ReservedIPs.Get(reserveIpName);

            Assert.True(receivedReservedIpFromRdfe.StatusCode == HttpStatusCode.OK);

            Assert.True(serviceName == receivedReservedIpFromRdfe.ServiceName);
            Assert.True(receivedReservedIpFromRdfe.InUse == true);
            Assert.True(deploymentName == receivedReservedIpFromRdfe.DeploymentName);
        }

    }
}
