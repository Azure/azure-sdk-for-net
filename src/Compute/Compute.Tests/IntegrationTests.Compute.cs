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
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.Azure.Test;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Xunit;

    /// <summary>
    /// TODO: Fix these tests
    /// </summary>
    public class IntegrationTests : IUseFixture<IntegrationTestFixtureData>
    {
        private IntegrationTestFixtureData fixture;

        public void SetFixture(IntegrationTestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }


        [Fact(Skip = "TODO: Re-record the entire fixture")]
        public void CanCreateStorageAccount()
        {
            TestUtilities.StartTest();
            var accountListResult = fixture.StorageManagementClient.StorageAccounts.List();
            Assert.True(accountListResult.StorageAccounts.Any(x => x.Name == fixture.NewStorageAccountName));
            TestUtilities.EndTest();
        }

        [Fact(Skip = "TODO: Re-record the entire fixture")]
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

        [Fact (Skip = "TODO: Re-record the entire fixture")]
        public void CanCreateHostedService()
        {
            TestUtilities.StartTest();
            // verify the service was created
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var getResult = computeMgmtClient.HostedServices.Get(fixture.NewServiceName);
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

        [Fact(Skip = "TODO: Re-record the entire fixture")]
        public void CanServicesBeDeployed()
        {
            TestUtilities.StartTest();
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var deploymentResult = computeMgmtClient.Deployments.GetByName(fixture.NewServiceName, string.Format(fixture.DeploymentNameTemplate, fixture.NewServiceName));
            Assert.Equal(deploymentResult.StatusCode, HttpStatusCode.OK);
            TestUtilities.EndTest();
        }

        [Fact(Skip = "TODO: Re-record the entire fixture")]
        public void DeploymentHasExtensionConfiguration()
        {
            TestUtilities.StartTest();
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var deploymentResult = computeMgmtClient.Deployments.GetByName(fixture.NewServiceName, string.Format(fixture.DeploymentNameTemplate, fixture.NewServiceName));
            Assert.NotNull(deploymentResult.ExtensionConfiguration);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles.Count, 1);
            Assert.Equal(deploymentResult.ExtensionConfiguration.AllRoles[0].Id, "RDPExtensionTest");
            TestUtilities.EndTest();
        }

        [Fact(Skip = "TODO: Re-record the entire fixture")]
        public void CanUpdateStatusByDeploymentName()
        {
            TestUtilities.StartTest();
            var computeMgmtClient = fixture.GetComputeManagementClient();
            var r = computeMgmtClient.Deployments.UpdateStatusByDeploymentName(
                fixture.NewServiceName,
                fixture.ServiceDeploymentName,
                new DeploymentUpdateStatusParameters
                {
                    Status = UpdatedDeploymentStatus.Suspended
                });

            Assert.Equal(r.Status, OperationStatus.Succeeded);
            TestUtilities.EndTest();
        }
    }

    public class IntegrationTestFixtureData : TestBase, IDisposable
    {
        private ManagementClient managementClient;
        private ComputeManagementClient computeMgmtClient;
        private StorageManagementClient storageMgmtClient;

        private string _storageConnectionStringTemplate = "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1}";
        private string _storageAccountConnectionString = string.Empty;
        public string DeploymentNameTemplate;
        private string _testDeploymentsBlobStorageContainerName = "deployments";
        public string NewServiceName;
        private string _serviceDeploymentName = string.Empty;
        public string NewStorageAccountName;
        public string DefaultLocation;

        private Uri _blobUri;
        
        public void Instantiate(string className)
        {
            try
            {
                using (UndoContext context = UndoContext.Current)
                {
                    context.Start(className, "FixtureSetup");

                    this.managementClient = this.GetManagementClient();
                    this.computeMgmtClient = this.GetComputeManagementClient();
                    this.storageMgmtClient = this.GetStorageManagementClient();

                    NewStorageAccountName = TestUtilities.GenerateName();
                    NewServiceName = TestUtilities.GenerateName();
                    DeploymentNameTemplate = TestUtilities.GenerateName();
                    this.DefaultLocation = managementClient.GetDefaultLocation("Compute", "Storage");
                    // create a storage account
                    var storageAccountResult = storageMgmtClient.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = this.DefaultLocation,
                            Name = NewStorageAccountName,
                            AccountType = "Standard_LRS"
                        });

                    // get the storage account
                    var keyResult = storageMgmtClient.StorageAccounts.GetKeys(NewStorageAccountName);

                    // build the connection string
                    _storageAccountConnectionString = string.Format(_storageConnectionStringTemplate,
                        NewStorageAccountName, keyResult.PrimaryKey);

                    _blobUri = StorageTestUtilities.UploadFileToBlobStorage(NewStorageAccountName,
                        _testDeploymentsBlobStorageContainerName, @"SampleService\SMNetTestAppProject.cspkg");
                    // upload the compute service package file
                    // persist the XML of the configuration file to a variable
                    var configXml = File.ReadAllText(@"SampleService\ServiceConfiguration.Cloud.cscfg");

                    // create a hosted service for the tests to use
                    var result = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
                    {
                        Location = this.DefaultLocation,
                        Label = NewServiceName,
                        ServiceName = NewServiceName
                    });

                    // assert that the call worked
                    Assert.Equal(result.StatusCode, HttpStatusCode.Created);

                    // Get an extension for our deployment
                    computeMgmtClient.HostedServices.AddExtension(
                        NewServiceName,
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
                    _serviceDeploymentName = string.Format(DeploymentNameTemplate, NewServiceName);

                    // create the hosted service deployment
                    var deploymentResult = computeMgmtClient.Deployments.Create(NewServiceName,
                        DeploymentSlot.Production,
                        new DeploymentCreateParameters
                        {
                            Configuration = configXml,
                            Name = _serviceDeploymentName,
                            Label = _serviceDeploymentName,
                            StartDeployment = true,
                            ExtensionConfiguration = extensionConfig,
                            PackageUri = _blobUri
                        });

                    // assert that nothing went wrong
                    var error = deploymentResult.Error;
                    Assert.True(error == null, "Unexpected error: " + (error == null ? "" : error.Message));
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
            computeMgmtClient.Dispose();
            storageMgmtClient.Dispose();
            managementClient.Dispose();
        }

        public StorageManagementClient StorageManagementClient { get { return storageMgmtClient; } }
        public ComputeManagementClient ComputeManagementClient { get { return computeMgmtClient; } }
        public ManagementClient ManagementClient { get { return managementClient; } }
        public string ServiceDeploymentName { get { return _serviceDeploymentName; } }
    }
}
