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
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class IntegrationTests : IUseFixture<IntegrationTestFixtureData>
    {
        private IntegrationTestFixtureData fixture;
        private const string TestDeploymentsBlobStorageContainerName = "deployments";
        private Uri _blobUri;

        public void SetFixture(IntegrationTestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void CanCreateStorageAccount()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            var accountListResult = fixture.GetStorageManagementClient().StorageAccounts.List();
            Assert.True(accountListResult.StorageAccounts.Any(x => x.Name == newStorageAccountName));
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanGetHostedServiceList()
        {
            TestUtilities.StartTest();
            // get the list of services
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var result = computeMgmtClient.HostedServices.List();

            // make sure we got back a list
            Assert.True(result.HostedServices.Count > 0);
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanCreateHostedService()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            var newServiceName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            CreateHostedService(newServiceName);

            // verify the service was created
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var getResult = computeMgmtClient.HostedServices.Get(newServiceName);
            Assert.Equal(getResult.StatusCode, HttpStatusCode.OK);
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanCreateHostedServiceWithReverseDns()
        {
            TestUtilities.StartTest();

            // Setup
            var computeMgmtClient = fixture.GetComputeManagementClient();
            string newServiceName = TestUtilities.GenerateName();
            string reverseDnsFqdn = string.Format("{0}.cloudapp.net.", newServiceName);

            // Action
            var createResp = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
            {
                ReverseDnsFqdn = reverseDnsFqdn,
                Location = fixture.DefaultLocation,
                ServiceName = newServiceName
            });

            // Assert
            Assert.Equal(HttpStatusCode.Created, createResp.StatusCode);

            var getResponse = computeMgmtClient.HostedServices.Get(newServiceName);

            Assert.Equal(newServiceName, getResponse.ServiceName);
            Assert.Equal(reverseDnsFqdn, getResponse.Properties.ReverseDnsFqdn);

            TestUtilities.EndTest();
        }

        [Fact]
        public void CanUpdateHostedServiceWithReverseDns()
        {
            TestUtilities.StartTest();

            var computeMgmtClient = fixture.GetComputeManagementClient();
            // Setup
            string newServiceName = TestUtilities.GenerateName();
            string reverseDnsFqdn = string.Format("{0}.cloudapp.net.", newServiceName);

            var createResp = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
            {
                Location = fixture.DefaultLocation,
                ServiceName = newServiceName
            });

            var getResponse = computeMgmtClient.HostedServices.Get(newServiceName);

            Assert.Equal(HttpStatusCode.Created, createResp.StatusCode);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
            Assert.NotEqual(reverseDnsFqdn, getResponse.Properties.ReverseDnsFqdn);

            // Action
            var updateResp = computeMgmtClient.HostedServices.Update(
                newServiceName,
                new HostedServiceUpdateParameters
                {
                    ReverseDnsFqdn = reverseDnsFqdn,

                });

            var updatedService = computeMgmtClient.HostedServices.Get(newServiceName);

            // Assert
            Assert.Equal(HttpStatusCode.OK, updateResp.StatusCode);
            Assert.Equal(newServiceName, updatedService.ServiceName);
            Assert.Equal(reverseDnsFqdn, updatedService.Properties.ReverseDnsFqdn);
     
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanListHostedServiceWithReverseDns()
        {
            TestUtilities.StartTest();

            var computeMgmtClient = fixture.GetComputeManagementClient();
            // Setup
            string newServiceName = TestUtilities.GenerateName();
            string reverseDnsFqdn = string.Format("{0}.cloudapp.net.", newServiceName);

            // Action
            var createResp = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
            {
                ReverseDnsFqdn = reverseDnsFqdn,
                Location = fixture.DefaultLocation,
                ServiceName = newServiceName
            });

            var listResp = computeMgmtClient.HostedServices.List();

            // Assert
            Assert.Equal(HttpStatusCode.Created, createResp.StatusCode);
            Assert.Equal(HttpStatusCode.OK, listResp.StatusCode);

            var hostedService = listResp.HostedServices.FirstOrDefault(hs => hs.ServiceName == newServiceName);
            Assert.NotNull(hostedService);
            Assert.Equal(reverseDnsFqdn, hostedService.Properties.ReverseDnsFqdn);
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanServicesBeDeployed()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            var newServiceName = TestUtilities.GenerateName();
            var newDeploymentName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            CreateHostedService(newServiceName);
            CreateDeployment(newStorageAccountName, newServiceName, newDeploymentName);

            var computeMgmtClient = fixture.GetComputeManagementClient();
            var deploymentResult = computeMgmtClient.Deployments.GetByName(newServiceName, newDeploymentName);
            Assert.Equal(deploymentResult.StatusCode, HttpStatusCode.OK);
            TestUtilities.EndTest();
        }

        [Fact]
        public void DeploymentHasExtensionConfiguration()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            var newServiceName = TestUtilities.GenerateName();
            var newDeploymentName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            CreateHostedService(newServiceName);
            CreateDeployment(newStorageAccountName, newServiceName, newDeploymentName);

            var computeMgmtClient = fixture.GetComputeManagementClient();
            var deploymentResult = computeMgmtClient.Deployments.GetByName(newServiceName, newDeploymentName);
            Assert.NotNull(deploymentResult.ExtensionConfiguration);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles.Count, 1);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles[0].Id, "RDPExtensionTest");
            TestUtilities.EndTest();
        }

        [Fact]
        public void DeploymentUpgradeWithUninstallExtension()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            var newServiceName = TestUtilities.GenerateName();
            var newDeploymentName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            CreateHostedService(newServiceName);
            CreateDeployment(newStorageAccountName, newServiceName, newDeploymentName);

            var computeMgmtClient = fixture.GetComputeManagementClient();
            var deploymentResult = computeMgmtClient.Deployments.GetByName(newServiceName, newDeploymentName);
            Assert.NotNull(deploymentResult.ExtensionConfiguration);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles.Count, 1);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles[0].Id, "RDPExtensionTest");

            var extension = new ExtensionConfiguration.Extension
            {
                Id = "RDPExtensionTest",
                State = "Uninstall"
            };

            var extensionList = new List<ExtensionConfiguration.Extension>();
            extensionList.Add(extension);
            var _blobUri = StorageTestUtilities.UploadFileToBlobStorage(newStorageAccountName,
                        "deployments", @"SampleService\SMNetTestAppProject.cspkg");

            computeMgmtClient.Deployments.UpgradeBySlot(newServiceName, DeploymentSlot.Production,
                new DeploymentUpgradeParameters
                {
                    Configuration = File.ReadAllText(@"SampleService\ServiceConfiguration.Cloud.cscfg"),
                    PackageUri = _blobUri,
                    Label = "UpgradeBySlot",
                    Force = true,
                    Mode = DeploymentUpgradeMode.Auto,
                    ExtensionConfiguration = new ExtensionConfiguration
                    {
                        AllRoles = extensionList
                    }
                });
            deploymentResult = computeMgmtClient.Deployments.GetBySlot(newServiceName, DeploymentSlot.Production);
            TestUtilities.EndTest();
        }

        [Fact]
        public void CanUpdateStatusByDeploymentName()
        {
            TestUtilities.StartTest();
            var newStorageAccountName = TestUtilities.GenerateName();
            var newServiceName = TestUtilities.GenerateName();
            var newDeploymentName = TestUtilities.GenerateName();
            CreateStorageAccount(newStorageAccountName);
            CreateHostedService(newServiceName);
            CreateDeployment(newStorageAccountName, newServiceName, newDeploymentName);

            var computeMgmtClient = fixture.GetComputeManagementClient();
            var r = computeMgmtClient.Deployments.UpdateStatusByDeploymentName(
                newServiceName,
                newDeploymentName,
                new DeploymentUpdateStatusParameters
                {
                    Status = UpdatedDeploymentStatus.Suspended
                });

            Assert.Equal(r.Status, OperationStatus.Succeeded);
            TestUtilities.EndTest();
        }

        private void CreateStorageAccount(string storageAccountName)
        {
            using (var storageMgmtClient = fixture.GetStorageManagementClient())
            {
                // create a storage account
                var storageAccountResult = storageMgmtClient.StorageAccounts.Create(
                    new StorageAccountCreateParameters
                    {
                        Location = fixture.DefaultLocation,
                        Name = storageAccountName,
                        AccountType = "Standard_LRS"
                    });
            }
        }

        private void CreateHostedService(string serviceName)
        {
            using (var computeMgmtClient = fixture.GetComputeManagementClient())
            {
                // create a storage account
                var result = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = fixture.DefaultLocation,
                    Label = serviceName,
                    ServiceName = serviceName
                });

                // assert that the call worked
                Assert.Equal(result.StatusCode, HttpStatusCode.Created);
            }
        }

        private void CreateDeployment(string storageAccountName, string serviceName, string deploymentName)
        {
            using (var computeMgmtClient = fixture.GetComputeManagementClient())
            {
                _blobUri = StorageTestUtilities.UploadFileToBlobStorage(storageAccountName,
                    TestDeploymentsBlobStorageContainerName, @"SampleService\SMNetTestAppProject.cspkg");
                // upload the compute service package file
                // persist the XML of the configuration file to a variable
                var configXml = File.ReadAllText(@"SampleService\ServiceConfiguration.Cloud.cscfg");

                // Get an extension for our deployment
                computeMgmtClient.HostedServices.AddExtension(
                    serviceName,
                    new HostedServiceAddExtensionParameters
                    {
                        Id = "RDPExtensionTest",
                        Type = "RDP",
                        ProviderNamespace = "Microsoft.Windows.Azure.Extensions",
                        PublicConfiguration =
                            "<?xml version=\"1.0\" encoding=\"UTF-8\"?><PublicConfig><UserName>WilliamGatesIII</UserName><Expiration>2020-11-20</Expiration></PublicConfig>",
                        PrivateConfiguration =
                            "<?xml version=\"1.0\" encoding=\"UTF-8\"?><PrivateConfig><Password>WindowsAzure1277!</Password></PrivateConfig>",
                        Version = "*"
                    });
                ExtensionConfiguration extensionConfig = new ExtensionConfiguration();
                extensionConfig.AllRoles.Add(new ExtensionConfiguration.Extension() {Id = "RDPExtensionTest"});

                // create the hosted service deployment
                var deploymentResult = computeMgmtClient.Deployments.Create(serviceName,
                    DeploymentSlot.Production,
                    new DeploymentCreateParameters
                    {
                        Configuration = configXml,
                        Name = deploymentName,
                        Label = deploymentName,
                        StartDeployment = true,
                        ExtensionConfiguration = extensionConfig,
                        PackageUri = _blobUri
                    });

                // assert that nothing went wrong
                var error = deploymentResult.Error;
                Assert.True(error == null, "Unexpected error: " + (error == null ? "" : error.Message));
            }
        }
    }

    public class IntegrationTestFixtureData : TestBase, IDisposable
    {
        private ManagementClient managementClient;
        public string DefaultLocation;

        public void Instantiate(string className)
        {
            try
            {
                using (UndoContext context = UndoContext.Current)
                {
                    context.Start(className, "FixtureSetup");
                    this.managementClient = this.GetManagementClient();
                    this.DefaultLocation = managementClient.GetDefaultLocation("Compute", "Storage");
                }
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            UndoContext.Current.UndoAll();
            managementClient.Dispose();
        }
    }
}
