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

using System.Collections.Generic;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Testing;

namespace Network.Tests
{
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using System.Net;
    using Xunit;
    using AZT = Microsoft.Azure.Test;
    using System.Linq;
    using System;
    using Microsoft.Azure;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class MultiVipTests
    {
        /// <summary>
        /// Add three logical vips and delete them
        /// </summary>
        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "MultivipTests")]
        public void TestAddAndRemoveVip()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    bool hostedServiceCreated = false;
                    bool storageAccountCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testser");
                    string virtualIPName1 = AZT.TestUtilities.GenerateName("vip1");
                    string virtualIPName2 = AZT.TestUtilities.GenerateName("vip2");
                    string virtualIPName3 = AZT.TestUtilities.GenerateName("vip2");
                    string deploymentName = AZT.TestUtilities.GenerateName("dep");

                    ComputeManagementClient computeClient = _testFixture.GetComputeManagementClient();
                    ManagementClient managementClient = _testFixture.ManagementClient;
                    StorageManagementClient storageClient = _testFixture.GetStorageManagementClient();

                    try
                    {
                        string location = Utilities.GetTestLocation(managementClient);
                        Assert.True(!string.IsNullOrEmpty(location));

                        // Create hosted service
                        Utilities.CreateHostedService(location, computeClient, serviceName, out hostedServiceCreated);
                        Assert.True(hostedServiceCreated);

                        // Create storage account
                        storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                        Utilities.CreateStorageAccount(location, storageClient, storageAccountName,
                            out storageAccountCreated);
                        Assert.True(storageAccountCreated);

                        // Create a new VM
                        Utilities.CreateAzureVirtualMachine(computeClient, serviceName, deploymentName, storageAccountName,
                            "blob.core.windows.net");

                        // Add and assert vip status
                        OperationStatusResponse virtualIPCreate1 =
                            _testFixture.NetworkClient.VirtualIPs.Add(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName1);

                        Assert.True(virtualIPCreate1.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 2,
                            present: true);

                        OperationStatusResponse virtualIPCreate2 =
                            _testFixture.NetworkClient.VirtualIPs.Add(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName2);

                        Assert.True(virtualIPCreate2.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName2, expectedVipCount: 3,
                            present: true);

                        OperationStatusResponse virtualIPCreate3 =
                            _testFixture.NetworkClient.VirtualIPs.Add(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName3);

                        Assert.True(virtualIPCreate3.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName3, expectedVipCount: 4,
                            present: true);

                        // Remove and assert vip status
                        OperationStatusResponse virtualIPRemove1 =
                            _testFixture.NetworkClient.VirtualIPs.Remove(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName1);

                        Assert.True(virtualIPRemove1.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 3,
                            present: false);

                        OperationStatusResponse virtualIPRemove3 =
                            _testFixture.NetworkClient.VirtualIPs.Remove(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName3);

                        Assert.True(virtualIPRemove3.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName3, expectedVipCount: 2,
                            present: false);

                        OperationStatusResponse virtualIPRemove2 =
                            _testFixture.NetworkClient.VirtualIPs.Remove(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName2);

                        Assert.True(virtualIPRemove2.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName2, expectedVipCount: 1,
                            present: false);
                    }
                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            computeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "MultivipTests")]
        public void TestAssociateDisassociateOnMultivipIaaSDeployment()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    bool hostedServiceCreated = false;
                    bool storageAccountCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testser");
                    string deploymentName = AZT.TestUtilities.GenerateName("dep");

                    ComputeManagementClient computeClient = _testFixture.GetComputeManagementClient();
                    ManagementClient managementClient = _testFixture.ManagementClient;
                    StorageManagementClient storageClient = _testFixture.GetStorageManagementClient();
                    List<string> createdRips = new List<string>();

                    try
                    {
                        string location = Utilities.GetTestLocation(managementClient);
                        Assert.True(!string.IsNullOrEmpty(location));

                        // Create hosted service
                        Utilities.CreateHostedService(location, computeClient, serviceName, out hostedServiceCreated);
                        Assert.True(hostedServiceCreated);

                        // Create storage account
                        storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                        Utilities.CreateStorageAccount(location, storageClient, storageAccountName,
                            out storageAccountCreated);
                        Assert.True(storageAccountCreated);


                        List<string> vipNames = new List<string>()
                        {
                            AZT.TestUtilities.GenerateName("VipA"),
                            AZT.TestUtilities.GenerateName("VipB"),
                            AZT.TestUtilities.GenerateName("VipC"),
                            AZT.TestUtilities.GenerateName("VipD"),
                            AZT.TestUtilities.GenerateName("VipE")
                        };

                        List<string> reservedIPNames = new List<string>()
                        {
                            AZT.TestUtilities.GenerateName("RipA"),
                            AZT.TestUtilities.GenerateName("RipB"),
                            AZT.TestUtilities.GenerateName("RipC"),
                            AZT.TestUtilities.GenerateName("RipD"),
                            AZT.TestUtilities.GenerateName("RipE")
                        };

                        CreateMultivipDeploymentAndAssertSuccess(_testFixture.NetworkClient, computeClient,
                            vipNames, serviceName, deploymentName, storageAccountName, location);

                        // Associate 5 reserved IPs
                        for (int i = 0; i < 5; i++)
                        {
                            string reserveIpName = reservedIPNames[i];
                            string vipName = vipNames[i];
                            NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
                            {
                                Name = reserveIpName,
                                Location = location,
                                Label = "SampleReserveIPLabel"
                            };

                            OperationStatusResponse reserveIpCreate = _testFixture.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);
                            Assert.True(reserveIpCreate.StatusCode == HttpStatusCode.OK);
                            createdRips.Add(reserveIpName);

                            NetworkReservedIPGetResponse reserveIpCreationResponse =
                                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

                            Assert.True(reserveIpCreationResponse.StatusCode == HttpStatusCode.OK);

                            NetworkReservedIPMobilityParameters pars = new NetworkReservedIPMobilityParameters
                            {
                                ServiceName = serviceName,
                                DeploymentName = deploymentName,
                                VirtualIPName = vipName
                            };
                            OperationStatusResponse responseAssociateRip = _testFixture.NetworkClient.ReservedIPs.Associate(reserveIpName, pars);
                            Assert.True(responseAssociateRip.StatusCode == HttpStatusCode.OK);
                            DeploymentGetResponse deploymentResponse =
                                computeClient.Deployments.GetByName(serviceName: serviceName,
                                    deploymentName: deploymentName);

                            NetworkReservedIPGetResponse receivedReservedIpFromRdfe =
                                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

                            Assert.True(receivedReservedIpFromRdfe.StatusCode == HttpStatusCode.OK);

                            Assert.True(serviceName == receivedReservedIpFromRdfe.ServiceName);
                            Assert.True(receivedReservedIpFromRdfe.InUse == true);
                            Assert.True(deploymentName == receivedReservedIpFromRdfe.DeploymentName);
                            Assert.True(reserveIpName == receivedReservedIpFromRdfe.Name);
                            Assert.True(vipName == receivedReservedIpFromRdfe.VirtualIPName);
                            var vipAssociated = deploymentResponse.VirtualIPAddresses.FirstOrDefault(vip => vip.Name == vipName);
                            Assert.NotNull(vipAssociated);
                            Assert.True(vipAssociated.ReservedIPName == reserveIpName);
                        }

                        // Disassociate the associated IPs
                        for (int i = 0; i < 5; i++)
                        {
                            string reserveIpName = reservedIPNames[i];
                            string vipName = vipNames[i];

                            NetworkReservedIPMobilityParameters pars = new NetworkReservedIPMobilityParameters
                            {
                                ServiceName = serviceName,
                                DeploymentName = deploymentName,
                                VirtualIPName = vipName
                            };

                            OperationStatusResponse responseDisassociateRip = _testFixture.NetworkClient.ReservedIPs.Disassociate(reserveIpName, pars);
                            Assert.True(responseDisassociateRip.StatusCode == HttpStatusCode.OK);
                            DeploymentGetResponse deploymentResponse =
                                computeClient.Deployments.GetByName(serviceName: serviceName,
                                    deploymentName: deploymentName);

                            NetworkReservedIPGetResponse receivedReservedIpFromRdfe =
                                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

                            Assert.True(receivedReservedIpFromRdfe.StatusCode == HttpStatusCode.OK);

                            Assert.True(string.IsNullOrEmpty(receivedReservedIpFromRdfe.ServiceName));
                            Assert.True(receivedReservedIpFromRdfe.InUse == false);
                            Assert.True(string.IsNullOrEmpty(receivedReservedIpFromRdfe.DeploymentName));
                            Assert.True(reserveIpName == receivedReservedIpFromRdfe.Name);
                            Assert.True(string.IsNullOrEmpty(receivedReservedIpFromRdfe.VirtualIPName));
                            var vipAssociated = deploymentResponse.VirtualIPAddresses.FirstOrDefault(vip => vip.Name == vipName);
                            Assert.NotNull(vipAssociated);
                            Assert.True(string.IsNullOrEmpty(vipAssociated.ReservedIPName));
                        }
                    }
                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            computeClient.HostedServices.DeleteAll(serviceName);
                        }
                        if (createdRips.Any())
                        {
                            foreach (var rip in createdRips)
                            {
                                // Clean up created Reserved IPs
                                _testFixture.NetworkClient.ReservedIPs.Delete(rip);
                            }
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "MultivipTests")]
        public void TestAdditionalVipLifeCycle()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    bool hostedServiceCreated = false;
                    bool storageAccountCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testser");
                    string virtualIPName1 = AZT.TestUtilities.GenerateName("vip1");
                    string deploymentName = AZT.TestUtilities.GenerateName("dep");

                    ComputeManagementClient computeClient = _testFixture.GetComputeManagementClient();
                    ManagementClient managementClient = _testFixture.ManagementClient;
                    StorageManagementClient storageClient = _testFixture.GetStorageManagementClient();

                    try
                    {
                        string location = Utilities.GetTestLocation(managementClient);
                        Assert.True(!string.IsNullOrEmpty(location));

                        // Create hosted service
                        Utilities.CreateHostedService(location, computeClient, serviceName, out hostedServiceCreated);
                        Assert.True(hostedServiceCreated);

                        // Create storage account
                        storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                        Utilities.CreateStorageAccount(location, storageClient, storageAccountName,
                            out storageAccountCreated);
                        Assert.True(storageAccountCreated);

                        // Create a new VM
                        Utilities.CreateAzureVirtualMachine(computeClient, serviceName, deploymentName,
                            storageAccountName, "blob.core.windows.net");

                        DeploymentGetResponse depRetrieved =
                            computeClient.Deployments.GetByName(serviceName: serviceName, deploymentName: deploymentName);

                        IEnumerable<ConfigurationSet> endpointCfgSets = new List<ConfigurationSet>
                        {
                            new ConfigurationSet
                            {
                                ConfigurationSetType = "NetworkConfiguration",
                                InputEndpoints =
                                    new List<InputEndpoint>
                                    {
                                        new InputEndpoint()
                                        {
                                            LocalPort = 3387,
                                            Name = "RDP2",
                                            Port = 52777,
                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                            EnableDirectServerReturn = false
                                        },
                                    }
                            }
                        };

                        // Update with single endpoint

                        var updateParams = Utilities.GetVMUpdateParameters(depRetrieved.Roles.First(),
                            storageAccountName, endpointCfgSets, preserveOriginalConfigSets: false);

                        computeClient.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        depRetrieved.Roles.First().RoleName,
                        updateParams);

                        // Add and assert vip status
                        OperationStatusResponse virtualIPCreate1 =
                            _testFixture.NetworkClient.VirtualIPs.Add(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName1);

                        Assert.True(virtualIPCreate1.StatusCode == HttpStatusCode.OK);

                        depRetrieved = Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 2,
                            present: true);

                        endpointCfgSets = new List<ConfigurationSet>
                        {
                            new ConfigurationSet
                            {
                                ConfigurationSetType = "NetworkConfiguration",
                                InputEndpoints =
                                    new List<InputEndpoint>
                                    {
                                        new InputEndpoint()
                                        {
                                            LocalPort = 3387,
                                            Name = "RDP2",
                                            Port = 52777,
                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                            EnableDirectServerReturn = false,
                                        },
                                        new InputEndpoint()
                                        {
                                            LocalPort = 3379,
                                            Name = "RDP",
                                            Port = 52728,
                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                            EnableDirectServerReturn = false,
                                            VirtualIPName = virtualIPName1,
                                        }
                                    
                                    }
                            }
                        };

                        updateParams = Utilities.GetVMUpdateParameters(depRetrieved.Roles.First(),
                            storageAccountName, endpointCfgSets, preserveOriginalConfigSets: false);

                        computeClient.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        depRetrieved.Roles.First().RoleName,
                        updateParams);

                        var depRetrievedAfterUpdate = Utilities.AssertLogicalVipWithIPPresent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 2);

                        endpointCfgSets = new List<ConfigurationSet>
                        {
                            new ConfigurationSet
                            {
                                ConfigurationSetType = "NetworkConfiguration",
                                InputEndpoints =
                                    new List<InputEndpoint>
                                    {
                                        new InputEndpoint()
                                        {
                                            LocalPort = 3387,
                                            Name = "RDP2",
                                            Port = 52777,
                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                            EnableDirectServerReturn = false,
                                        },
                                    }
                            }
                        };

                        updateParams = Utilities.GetVMUpdateParameters(depRetrieved.Roles.First(),
                            storageAccountName, endpointCfgSets, preserveOriginalConfigSets: false);
                        computeClient.VirtualMachines.Update(
                        serviceName,
                        deploymentName,
                        depRetrieved.Roles.First().RoleName,
                        updateParams);

                        depRetrieved = Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient,
                            serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 2,
                            present: true);

                        // Remove and assert vip status
                        OperationStatusResponse virtualIPRemove1 =
                            _testFixture.NetworkClient.VirtualIPs.Remove(serviceName: serviceName,
                                deploymentName: deploymentName, virtualIPName: virtualIPName1);

                        Assert.True(virtualIPRemove1.StatusCode == HttpStatusCode.OK);

                        Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                            deploymentName: deploymentName, virtualIPName: virtualIPName1, expectedVipCount: 3,
                            present: false);
                    }
                    finally
                    {
                        if (hostedServiceCreated)
                        {
                            computeClient.HostedServices.DeleteAll(serviceName);
                        }
                    }
                }
            }
        }

        #region utils

        public DeploymentGetResponse CreateMultivipDeploymentAndAssertSuccess(NetworkManagementClient networkClient, ComputeManagementClient computeClient, List<string> vipNames, string serviceName, string deploymentName, string storageAccountName, string location)
        {
            Utilities.CreateAzureVirtualMachine(computeClient, serviceName, deploymentName,
                            storageAccountName, "blob.core.windows.net");

            DeploymentGetResponse depRetrieved =
                computeClient.Deployments.GetByName(serviceName: serviceName, deploymentName: deploymentName);

            List<ConfigurationSet> endpointCfgSets = new List<ConfigurationSet>
                        {
                            new ConfigurationSet
                            {
                                ConfigurationSetType = "NetworkConfiguration",
                                InputEndpoints =
                                    new List<InputEndpoint>
                                    {
                                        new InputEndpoint()
                                        {
                                            LocalPort = 3387,
                                            Name = "RDP2",
                                            Port = 52777,
                                            Protocol = InputEndpointTransportProtocol.Tcp,
                                            EnableDirectServerReturn = false
                                        },
                                    }
                            }
                        };

            // Update with single endpoint

            var updateParams = Utilities.GetVMUpdateParameters(depRetrieved.Roles.First(),
                storageAccountName, endpointCfgSets, preserveOriginalConfigSets: false);

            computeClient.VirtualMachines.Update(
            serviceName,
            deploymentName,
            depRetrieved.Roles.First().RoleName,
            updateParams);
            int i = 1;
            foreach (var vip in vipNames)
            {
                i++;
                OperationStatusResponse virtualIPCreate =
                           networkClient.VirtualIPs.Add(serviceName: serviceName,
                               deploymentName: deploymentName, virtualIPName: vip);

                Assert.True(virtualIPCreate.StatusCode == HttpStatusCode.OK);

                depRetrieved = Utilities.AssertLogicalVipWithoutIPPresentOrAbsent(computeClient, serviceName: serviceName,
                    deploymentName: deploymentName, virtualIPName: vip, expectedVipCount: i, present: true);

                endpointCfgSets.First().InputEndpoints.Add(
                    new InputEndpoint()
                    {
                        LocalPort = 3387 + i,
                        Name = "RDPS" + i,
                        Port = 52777 + i,
                        Protocol = InputEndpointTransportProtocol.Tcp,
                        EnableDirectServerReturn = false,
                        VirtualIPName = vip
                    });
            }

            updateParams = Utilities.GetVMUpdateParameters(depRetrieved.Roles.First(),
               storageAccountName, endpointCfgSets, preserveOriginalConfigSets: false);

            computeClient.VirtualMachines.Update(
            serviceName,
            deploymentName,
            depRetrieved.Roles.First().RoleName,
            updateParams);

            depRetrieved =
                computeClient.Deployments.GetByName(serviceName: serviceName, deploymentName: deploymentName);

            Assert.NotNull(depRetrieved);
            Assert.NotNull(depRetrieved.VirtualIPAddresses);
            Assert.True(depRetrieved.VirtualIPAddresses.Count == vipNames.Count + 1);
            foreach (var virtualIpAddress in depRetrieved.VirtualIPAddresses)
            {
                Assert.NotNull(virtualIpAddress.Address);
            }
            return depRetrieved;
        }

        #endregion

    }
}
