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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Testing;
    using Xunit;
    using AZT = Microsoft.Azure.Test;


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

                        var deployment = _testFixture.CreatePaaSDeployment(storageAccountName, serviceName, deploymentName, NetworkTestConstants.OneWebOneWorkerPkgFilePath, "OneWebOneWorker.cscfg", startDeployment: true);

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
                    string location = "West US";
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
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

        [Fact]
        [Trait("Feature", "Rnm")]
        [Trait("Operation", "ReservedIPTests")]
        public void TestReserveIPWithIPTagsSimple()
        {
            using (var undoContext = AZT.UndoContext.Current)
          {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    var managementClient = _testFixture.ManagementClient;
                    bool storageAccountCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string reserveIpName = HttpMockServer.GetAssetName("res", "testresIPtag").ToLower();
                    string location = "West Central US";
                    bool reservedIpCreated = false;

                    IPTag iptag = new IPTag();
                    iptag.IPTagType = "FirstPartyUsage";
                    iptag.Value = "/tagTypes/SystemService/operators/Microsoft/platforms/Azure/services/Microsoft.AzureAD";
                    List<IPTag> iptags = new List<IPTag>();
                    iptags.Add(iptag);

                    try
                    {
                        _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);

                           NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
                        {
                            Name = reserveIpName,
                            Label = "TestResTagLabel",
                            Location = location,
                            IPTags = iptags
                        };

                        OperationStatusResponse reserveIpCreate = _testFixture.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);
                        Assert.True(reserveIpCreate.StatusCode == HttpStatusCode.OK);

                        reservedIpCreated = true;
                        NetworkReservedIPGetResponse reserveIpCreationResponse =
                            _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

                        Assert.True(reserveIpCreationResponse.StatusCode == HttpStatusCode.OK);
                        Assert.True(reserveIpCreationResponse.IPTags.Count == iptags.Count);

                        foreach (var iptag1 in iptags)
                        {
                            Assert.True(reserveIpCreationResponse.IPTags.Any(x => x.IPTagType == iptag1.IPTagType && x.Value == iptag1.Value));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("TestReserveIPWithIPTagsSimple test did not succeed with error being ," + ex.Message);
                        throw;
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            _testFixture.StorageClient.StorageAccounts.Delete(storageAccountName);
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
        [Trait("Operation", "ReservedIPTests")]
        public void TestReserveIPWithIPTagsNegative()
        {
            using (var undoContext = AZT.UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    var managementClient = _testFixture.ManagementClient;
                    bool storageAccountCreated = false;
                    string storageAccountName = HttpMockServer.GetAssetName("tststr1234", "tststr").ToLower();
                    string reserveIpName = HttpMockServer.GetAssetName("res", "testresIPtagNegative").ToLower();
                    string location = managementClient.GetDefaultLocation("Storage", "Compute");

                    // Create an IPTag Value that doesn't exist
                    IPTag iptag = new IPTag();
                    iptag.IPTagType = "FirstPartyUsage";
                    iptag.Value = "MyVip";
                    List<IPTag> iptags = new List<IPTag>();
                    iptags.Add(iptag);

                    try
                    {
                        _testFixture.CreateStorageAccount(location, storageAccountName, out storageAccountCreated);

                        NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
                        {
                            Name = reserveIpName,
                            Label = "TestResTagNegLabel",
                            Location = location,
                            IPTags = iptags
                        };

                        OperationStatusResponse reserveIpCreate = _testFixture.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("TestReserveIPWithIPTagsNegative test did not succeed with error being ," + ex.Message);
                        Assert.NotNull(ex);
                    }
                    finally
                    {
                        if (storageAccountCreated)
                        {
                            _testFixture.StorageClient.StorageAccounts.Delete(storageAccountName);
                        }
                    }
                }
            }
        }
    }
}
