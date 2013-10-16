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
    public class VirtualMachineTests
    {
        private static ComputeManagementClient _computeMgmtClient;
        private static StorageManagementClient _storageMgmtClient;

        private static string _storageConnectionStringTemplate = "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1}";
        private static string _storageAccountConnectionString = string.Empty;
        private static string _newServiceName = "test" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        private static string _serviceDeploymentName = string.Empty;
        private static string _newStorageAccountName = "test" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        private static string _deploymentLabel;

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
                // create the compute management client
                _computeMgmtClient = GetComputeManagementTestingClient();

                // create the storage management client
                _storageMgmtClient = GetStorageManagementTestingClient();

                // create a hosted service for the tests to use
                var result = _computeMgmtClient.HostedServices.Create(new HostedServiceCreateParameters
                {
                    Location = LocationNames.WestUS,
                    Label = _newServiceName,
                    ServiceName = _newServiceName
                });

                // assert that the call worked
                Assert.AreEqual(result.StatusCode, HttpStatusCode.Created);

                // create a storage account
                var strgAcctResult = _storageMgmtClient.StorageAccounts.Create(new StorageAccountCreateParameters
                {
                    Location = LocationNames.WestUS,
                    Label = Convert.ToBase64String(Encoding.ASCII.GetBytes(_newStorageAccountName)),
                    ServiceName = _newStorageAccountName
                });

                Assert.AreEqual(strgAcctResult.StatusCode, HttpStatusCode.OK);

                // get the storage account
                var keyResult = _storageMgmtClient.StorageAccounts.GetKeys(_newStorageAccountName);

                // build the connection string
                _storageAccountConnectionString = string.Format(_storageConnectionStringTemplate, _newStorageAccountName, keyResult.PrimaryKey);
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

            ignoreNotFound(() => _computeMgmtClient.VirtualMachines.Delete(_newServiceName, _deploymentLabel, _newServiceName));

            //cleanup will fail due to vm not having been deleted at this point
            //ignoreNotFound(() => _computeMgmtClient.HostedServices.Delete(_newServiceName));
            //ignoreNotFound(() => _storageMgmtClient.StorageAccounts.Delete(_newStorageAccountName));

            if (_computeMgmtClient != null)
            {
                _computeMgmtClient.Dispose();
                _computeMgmtClient = null;
            }

            if (_storageMgmtClient != null)
            {
                _storageMgmtClient.Dispose();
                _storageMgmtClient = null;
            }
        }

        [TestMethod]
        public void CanCreateVirtualMachine()
        {
            VirtualMachineImageListResponse imagesList = _computeMgmtClient.VirtualMachineImages.List();

            VirtualMachineImageListResponse.VirtualMachineImage imageToGet = 
                imagesList.Images.FirstOrDefault<VirtualMachineImageListResponse.VirtualMachineImage>();

            VirtualMachineImageGetResponse gottenImage = _computeMgmtClient.VirtualMachineImages.Get(imageToGet.Name);

            string blobDiskFormat = "http://{1}.blob.core.windows.net/myvhds/{0}.vhd";

            Uri blobUrl = new Uri(string.Format(blobDiskFormat, _newServiceName, _newStorageAccountName));

            _deploymentLabel = string.Format("Virtual machine {0}:{1}  label",
                _newServiceName, DeploymentSlot.Production);

            VirtualMachineCreateDeploymentParameters parameters = new VirtualMachineCreateDeploymentParameters
            {
                DeploymentSlot = DeploymentSlot.Production,
                Label = _deploymentLabel,
                Name = _newServiceName
            };

            parameters.Roles.Add(new Role
            {
                OSVirtualHardDisk = new OSVirtualHardDisk
                {
                    HostCaching = VirtualHardDiskHostCaching.ReadWrite,
                    MediaLink = blobUrl,
                    SourceImageName = gottenImage.Name
                },
                RoleName = _newServiceName,
                RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                RoleSize = VirtualMachineRoleSize.Large
            });

            parameters.Roles[0].ConfigurationSets.Add(new ConfigurationSet
            {
                AdminUserName = "scottgu",
                AdminPassword = "@zur3R0ck5",
                ConfigurationSetType = ConfigurationSetTypes.WindowsProvisioningConfiguration,
                ComputerName = _newServiceName,
                HostName = string.Format("{0}.cloudapp.net", _newServiceName),
                EnableAutomaticUpdates = false,
                TimeZone = "Pacific Standard Time"
            });
            
            ComputeOperationStatusResponse opResp =
                _computeMgmtClient.VirtualMachines.CreateDeployment(_newServiceName, parameters);

            Assert.AreEqual(opResp.Status, Management.Compute.Models.OperationStatus.Succeeded);
        }
    }
}
