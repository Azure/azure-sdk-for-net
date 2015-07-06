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

namespace Network.Tests
{
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.WindowsAzure.Testing;
    using System;
    using System.IO;
    using System.Net;
    using Xunit;
    using System.Linq;
    using Microsoft.Azure.Test.HttpRecorder;
    using AZT = Microsoft.Azure.Test;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.Network;


    public class VipMobilityTests
    {
        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "VipMobilityTests")]
        public void TestReservingExistingDeploymentIP()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    var managementClient = _testFixture.ManagementClient;
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testser");
                    string deploymentName = string.Format("{0}Prd", serviceName);
                    string reserveIpName = HttpMockServer.GetAssetName("res", "testres").ToLower();
                    string location = managementClient.GetDefaultLocation("Storage", "Compute");
                    bool reservedIpCreated = false;
                    try
                    {
                        _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);

                        _testFixture.CreateHostedService(location, serviceName, out hostedServiceCreated);

                        var deployment = _testFixture.CreatePaaSDeployment(storageAccountName, serviceName, deploymentName, NetworkTestConstants.OneWebOneWorkerPkgFilePath, "OneWebOneWorker.cscfg");

                        NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
                        {
                            Name = reserveIpName,
                            Label = "TestLabel",
                            DeploymentName = deploymentName,
                            ServiceName = serviceName,
                            Location = location
                        };

                        OperationStatusResponse reserveIpCreate = _testFixture.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);
                        Assert.True(reserveIpCreate.StatusCode == HttpStatusCode.OK);

                        reservedIpCreated = true;
                        NetworkReservedIPGetResponse reserveIpCreationResponse =
                            _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);


                        Assert.True(reserveIpCreationResponse.StatusCode == HttpStatusCode.OK);

                        Assert.True(reserveIpCreationResponse.ServiceName == serviceName);
                        Assert.True(reserveIpCreationResponse.DeploymentName == deploymentName);
                        Assert.True(reserveIpCreationResponse.InUse == true);
                        Assert.True(reserveIpCreationResponse.Address == deployment.VirtualIPAddresses[0].Address);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            _testFixture.StorageClient.StorageAccounts.Delete(storageAccountName);
                        }
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                        if (reservedIpCreated)
                        {
                            _testFixture.NetworkClient.ReservedIPs.Delete(reserveIpName);
                        }
                    }
                }
            }
        }


        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "VipMobilityTests")]
        public void TestAssociateReserveIP()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    var managementClient = _testFixture.ManagementClient;
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;
                    bool reserveIpCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("teststorage1234", "teststorage").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testsvc");
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string reserveIpName = HttpMockServer.GetAssetName("rip", "testrip").ToLower();
                    string location = managementClient.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    try
                    {
                        _testFixture.AssociateReservedIP(
                            usWestLocStr,
                            location,
                            storageAccountName,
                            ref storageAccountCreated,
                            serviceName,
                            deploymentName,
                            reserveIpName,
                            ref hostedServiceCreated,
                            ref reserveIpCreated);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            _testFixture.StorageClient.StorageAccounts.Delete(storageAccountName);
                        }
                        if (hostedServiceCreated)
                        {
                            _testFixture.ComputeClient.HostedServices.DeleteAll(serviceName);
                        }
                        if (reserveIpCreated)
                        {
                            _testFixture.NetworkClient.ReservedIPs.Delete(reserveIpName);
                        }
                    }
                }
            }
        }

        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "VipMobilityTests")]
        public void TestDisassociateReserveIP()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    ComputeManagementClient computeClient = _testFixture.GetComputeManagementClient();
                    StorageManagementClient storageClient = _testFixture.GetStorageManagementClient();
                    var managementClient = _testFixture.ManagementClient;
                    bool storageAccountCreated = false;
                    bool hostedServiceCreated = false;
                    bool reserveIpCreated = false;

                    string storageAccountName = HttpMockServer.GetAssetName("teststorage1234", "teststorage").ToLower();
                    string serviceName = AZT.TestUtilities.GenerateName("testsvc");
                    string deploymentName = string.Format("{0}Prod", serviceName);
                    string reserveIpName = HttpMockServer.GetAssetName("rip", "testrip").ToLower();
                    string location = managementClient.GetDefaultLocation("Storage", "Compute");
                    const string usWestLocStr = "West US";
                    try
                    {
                        _testFixture.AssociateReservedIP(
                            usWestLocStr,
                            location,
                            storageAccountName,
                            ref storageAccountCreated,
                            serviceName,
                            deploymentName,
                            reserveIpName,
                            ref hostedServiceCreated,
                            ref reserveIpCreated);

                        Assert.True(storageAccountCreated);
                        Assert.True(hostedServiceCreated);
                        Assert.True(reserveIpCreated);
                        DisassociateReservedIP(_testFixture, reserveIpName, serviceName, deploymentName);

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            storageClient.StorageAccounts.Delete(storageAccountName);
                        }
                        if (hostedServiceCreated)
                        {
                            computeClient.HostedServices.DeleteAll(serviceName);
                        }
                        if (reserveIpCreated)
                        {
                            _testFixture.NetworkClient.ReservedIPs.Delete(reserveIpName);
                        }
                    }
                }
            }
        }

        private static void DisassociateReservedIP(NetworkTestBase _testFixture, string reserveIpName, string serviceName, string deploymentName)
        {
            NetworkReservedIPMobilityParameters pars = new NetworkReservedIPMobilityParameters
            {
                ServiceName = serviceName,
                DeploymentName = deploymentName
            };
            OperationStatusResponse responseDisassociateRip = _testFixture.NetworkClient.ReservedIPs.Disassociate(reserveIpName, pars);
            Assert.True(responseDisassociateRip.StatusCode == HttpStatusCode.OK);

            NetworkReservedIPGetResponse receivedReservedIpFromRdfe =
                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

            Assert.True(receivedReservedIpFromRdfe.StatusCode == HttpStatusCode.OK);

            Assert.True(string.IsNullOrEmpty(receivedReservedIpFromRdfe.ServiceName));
            Assert.True(receivedReservedIpFromRdfe.InUse == false);
            Assert.True(string.IsNullOrEmpty(receivedReservedIpFromRdfe.DeploymentName));
        }

    }
}
