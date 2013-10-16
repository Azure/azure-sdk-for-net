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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Microsoft.WindowsAzure.Management.Testing.Compute
{
    [TestClass]
    public class IntegrationTests
    {
        private static ComputeManagementClient computeMgmtClient;
        private static StorageManagementClient storageMgmtClient;

        private static string _storageConnectionStringTemplate = "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1}";
        private static string _storageAccountConnectionString = string.Empty;
        private static string _deploymentNameTemplate = "{0}TestServiceToBeDeleted01";
        private static string _testDeploymentsBlobStorageContainerName = "deployments";
        private static string _newServiceName = "test" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        private static string _serviceDeploymentName = string.Empty;
        private static string _newStorageAccountName = "test" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        
        private static Uri _blobUri;

        private static ComputeManagementClient GetComputeManagementTestingClient()
        {
            return new ComputeManagementClient(
                Microsoft.WindowsAzure.Management.Testing.Tests.GetCredentials()
                );
        }

        private static StorageManagementClient GetStorageManagementTestingClient()
        {
            return new StorageManagementClient(
                Microsoft.WindowsAzure.Management.Testing.Tests.GetCredentials()
                );
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            try
            {
                // create the storage management client
                StorageManagementClient storageMgmtClient = GetStorageManagementTestingClient();

                // create a storage account
                var storageAccountResult = storageMgmtClient.StorageAccounts.Create(
                    new StorageAccountCreateParameters
                    {
                        Location = LocationNames.WestUS,
                        ServiceName = "scottgustorage"
                    });

                Assert.AreEqual(storageAccountResult.StatusCode, HttpStatusCode.OK);

                // get the storage account
                var keyResult = storageMgmtClient.StorageAccounts.GetKeys(_newStorageAccountName);

                // build the connection string
                _storageAccountConnectionString = string.Format(_storageConnectionStringTemplate, _newStorageAccountName, keyResult.PrimaryKey);

                // upload the compute service package file
                using (var filestream = File.OpenRead(@"SampleService\SMNetTestAppProject.cspkg"))
                {
                    var account = CloudStorageAccount.Parse(_storageAccountConnectionString);
                    var blobClient = account.CreateCloudBlobClient();
                    var container = blobClient.GetContainerReference(_testDeploymentsBlobStorageContainerName);
                    container.CreateIfNotExists();
                    container.SetPermissions(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });
                    var blob = container.GetBlockBlobReference("SMNetTestAppProject.cspkg");
                    blob.UploadFromStream(filestream);

                    _blobUri = blob.Uri;
                }

                // persist the XML of the configuration file to a variable
                var configXml = File.ReadAllText(@"SampleService\ServiceConfiguration.Cloud.cscfg");

                // create the compute management client
                computeMgmtClient = GetComputeManagementTestingClient();

                // create a hosted service for the tests to use
                var result = computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = LocationNames.WestUS,
                    Label = _newServiceName,
                    ServiceName = _newServiceName
                });

                // assert that the call worked
                Assert.AreEqual(result.StatusCode, HttpStatusCode.Created);

                // Get an extension for our deployment
                computeMgmtClient.HostedServices.AddExtension(
                    _newServiceName,
                    new HostedServiceAddExtensionParameters
                    {
                        Id = "RDPExtensionTest",
                        Type = "RDP",
                        ProviderNamespace = "Microsoft.Windows.Azure.Extensions",
                        PublicConfiguration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><PublicConfig><UserName>WilliamGatesIII</UserName><Expiration>2020-11-20</Expiration></PublicConfig>",
                        PrivateConfiguration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><PrivateConfig><Password>WindowsAzure1277!</Password></PrivateConfig>"
                    });
                ExtensionConfiguration extensionConfig = new ExtensionConfiguration();
                extensionConfig.AllRoles.Add(new ExtensionConfiguration.Extension() { Id = "RDPExtensionTest" });
                _serviceDeploymentName = string.Format(_deploymentNameTemplate, _newServiceName);

                // create the hosted service deployment
                var deploymentResult = computeMgmtClient.Deployments.Create(_newServiceName,
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
                Assert.IsNull(error, "Unexpected error: " + (error == null ? "" : error.Message));
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Action<Action> ignoreNotFound =
                operation =>
                {
                    try
                    {
                        operation();
                    }
                    catch (CloudException ex)
                    {
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                };

            ignoreNotFound(() => computeMgmtClient.Deployments.DeleteByName(_newServiceName, string.Format(_deploymentNameTemplate, _newServiceName)));
            ignoreNotFound(() => computeMgmtClient.HostedServices.Delete(_newServiceName));
            ignoreNotFound(() => storageMgmtClient.StorageAccounts.Delete(_newStorageAccountName));

            if (computeMgmtClient != null)
            {
                computeMgmtClient.Dispose();
                computeMgmtClient = null;
            }

            if (storageMgmtClient != null)
            {
                storageMgmtClient.Dispose();
                storageMgmtClient = null;
            }
        }

        [TestMethod]
        public void CanCreateStorageAccount()
        {
            var accountListResult = storageMgmtClient.StorageAccounts.List();
            Assert.IsTrue(accountListResult.StorageServices.Any(x => x.ServiceName == _newStorageAccountName));
        }

        [TestMethod]
        public void CanGetHostedServiceList()
        {
            // get the list of services
            var result = computeMgmtClient.HostedServices.List();

            // make sure we got back a list
            Assert.IsTrue(result.HostedServices.Count > 0);
        }

        [TestMethod]
        public void CanCreateHostedService()
        {
            // verify the service was created
            var getResult = computeMgmtClient.HostedServices.Get(_newServiceName);
            Assert.AreEqual(getResult.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void CanServicesBeDeployed()
        {
            var deploymentResult = computeMgmtClient.Deployments.GetByName(_newServiceName, string.Format(_deploymentNameTemplate, _newServiceName));
            Assert.AreEqual(deploymentResult.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeploymentHasExtensionConfiguration()
        {
            var deploymentResult = computeMgmtClient.Deployments.GetByName(_newServiceName, string.Format(_deploymentNameTemplate, _newServiceName));
            Assert.IsNotNull(deploymentResult.ExtensionConfiguration);
            Assert.AreEqual(deploymentResult.ExtensionConfiguration.AllRoles.Count, 1);
            Assert.AreEqual(deploymentResult.ExtensionConfiguration.AllRoles[0].Id, "RDPExtensionTest");
        }

        [TestMethod]
        public void CanUpdateStatusByDeploymentName()
        {
            var r = computeMgmtClient.Deployments.UpdateStatusByDeploymentName(
                _newServiceName,
                _serviceDeploymentName,
                new DeploymentUpdateStatusParameters
                {
                    Status = UpdatedDeploymentStatus.Suspended
                });

            Assert.AreEqual(r.StatusCode, HttpStatusCode.OK);
        }
    }
}
