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
    using AZT=Microsoft.Azure.Test;
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
                    ComputeManagementClient computeClient = _testFixture.GetComputeManagementClient();
                    StorageManagementClient storageClient = _testFixture.GetStorageManagementClient();
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
                        CreateStorageAccount(location, storageClient, storageAccountName, out storageAccountCreated);

                        CreateHostedService(location, computeClient, serviceName, out hostedServiceCreated);

                        var deployment = CreatePaaSDeployment(storageAccountName, computeClient, serviceName, deploymentName);

                        NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
                        {
                            Name = reserveIpName,
                            Label = "TestLabel",
                            DeploymentName = deploymentName,
                            ServiceName = serviceName,
                            Location = "uswest"
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
                            storageClient.StorageAccounts.Delete(storageAccountName);
                        }
                        if (hostedServiceCreated)
                        {
                            computeClient.HostedServices.DeleteAll(serviceName);
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
                        AssociateReservedIP(managementClient, usWestLocStr, location, storageClient, storageAccountName, ref storageAccountCreated, computeClient, serviceName, deploymentName, reserveIpName, _testFixture, ref hostedServiceCreated, ref reserveIpCreated);
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
                        AssociateReservedIP(managementClient, usWestLocStr, location, storageClient, storageAccountName,
                            ref storageAccountCreated, computeClient, serviceName, deploymentName, reserveIpName,
                            _testFixture, ref hostedServiceCreated, ref reserveIpCreated);
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

        private static void AssociateReservedIP(ManagementClient managementClient, string usWestLocStr, string location,
            StorageManagementClient storageClient, string storageAccountName, ref bool storageAccountCreated,
            ComputeManagementClient computeClient, string serviceName, string deploymentName, string reserveIpName,
            NetworkTestBase _testFixture, ref bool hostedServiceCreated, ref bool reserveIpCreated)
        {
            if (managementClient.Locations.List().Any(
                c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
            {
                location = usWestLocStr;
            }

            CreateStorageAccount(location, storageClient, storageAccountName, out storageAccountCreated);

            CreateHostedService(location, computeClient, serviceName, out hostedServiceCreated);

            CreatePaaSDeployment(storageAccountName, computeClient, serviceName, deploymentName);

            NetworkReservedIPCreateParameters reservedIpCreatePars = new NetworkReservedIPCreateParameters
            {
                Name = reserveIpName,
                Location = "uswest",
                Label = "SampleReserveIPLabel"
            };

            OperationStatusResponse reserveIpCreate = _testFixture.NetworkClient.ReservedIPs.Create(reservedIpCreatePars);
            Assert.True(reserveIpCreate.StatusCode == HttpStatusCode.OK);
            reserveIpCreated = true;

            NetworkReservedIPGetResponse reserveIpCreationResponse =
                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

            Assert.True(reserveIpCreationResponse.StatusCode == HttpStatusCode.OK);


            NetworkReservedIPMobilityParameters pars = new NetworkReservedIPMobilityParameters
            {
                ServiceName = serviceName,
                DeploymentName = deploymentName
            };
            OperationStatusResponse responseAssociateRip = _testFixture.NetworkClient.ReservedIPs.Associate(reserveIpName, pars);
            Assert.True(responseAssociateRip.StatusCode == HttpStatusCode.OK);

            NetworkReservedIPGetResponse receivedReservedIpFromRdfe =
                _testFixture.NetworkClient.ReservedIPs.Get(reserveIpName);

            Assert.True(receivedReservedIpFromRdfe.StatusCode == HttpStatusCode.OK);

            Assert.True(serviceName == receivedReservedIpFromRdfe.ServiceName);
            Assert.True(receivedReservedIpFromRdfe.InUse == true);
            Assert.True(deploymentName == receivedReservedIpFromRdfe.DeploymentName);
        }

        private static DeploymentGetResponse CreatePaaSDeployment(string storageAccountName, ComputeManagementClient computeClient,
            string serviceName, string deploymentName)
        {
            var cfgFilePath = "OneWebOneWorker.cscfg";
            var containerStr = AZT.TestUtilities.GenerateName("cspkg");
            var pkgFileName = "OneWebOneWorker.cspkg";
            var pkgFilePath = ".\\" + pkgFileName;

            var blobUri = StorageTestUtilities.UploadFileToBlobStorage(
                storageAccountName,
                containerStr,
                pkgFilePath);
            var blobUriStr = blobUri.ToString();
            var containerUriStr = blobUriStr.Substring(0, blobUriStr.IndexOf("/" + pkgFileName));
            containerUriStr = containerUriStr.Replace("https", "http");
            var containerUri = new Uri(containerUriStr);

            var deploymentCreate = computeClient.Deployments.Create(
                serviceName,
                DeploymentSlot.Production,
                new DeploymentCreateParameters
                {
                    Configuration = File.ReadAllText(cfgFilePath),
                    PackageUri = blobUri,
                    Name = deploymentName,
                    Label = serviceName,
                    ExtendedProperties = null,
                    StartDeployment = false,
                    TreatWarningsAsError = false,
                    ExtensionConfiguration = null
                });

            Assert.True(deploymentCreate.StatusCode == HttpStatusCode.OK);

            var deploymentReceived = computeClient.Deployments.GetByName(serviceName, deploymentName);
            return deploymentReceived;
        }

        private static void CreateHostedService(string location, ComputeManagementClient computeClient, string serviceName,
            out bool hostedServiceCreated)
        {
                AzureOperationResponse hostedServiceCreate = computeClient.HostedServices.Create(
                new HostedServiceCreateParameters
                {
                    Location = location,
                    Label = serviceName,
                    ServiceName = serviceName
                });

            Assert.True(hostedServiceCreate.StatusCode == HttpStatusCode.Created);

            hostedServiceCreated = true;
        }

        private static void CreateStorageAccount(string location, StorageManagementClient storageClient,
            string storageAccountName, out bool storageAccountCreated)
        {
            AzureOperationResponse storageCreate = storageClient.StorageAccounts.Create(
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
    }
}
