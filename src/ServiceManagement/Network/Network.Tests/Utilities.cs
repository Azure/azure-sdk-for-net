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

namespace Network.Tests
{
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using System;
    using Xunit;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.WindowsAzure.Testing;
    using System.IO;
    using AZT = Microsoft.Azure.Test;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Auth;
    using System.Collections.Generic;

    public static class Utilities
    {
        public static void CreateStorageAccount(string location, StorageManagementClient storageClient,
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

        public static void CreateHostedService(string location, ComputeManagementClient computeClient, string serviceName,
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

        public static string GetTestLocation(ManagementClient managementClient)
        {
            string location = managementClient.GetDefaultLocation("Storage", "Compute");
            const string usWestLocStr = "West US";
            if (managementClient.Locations.List().Any(
                c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
            {
                location = usWestLocStr;
            }
            return location;
        }

        public static void CreateAzureVirtualMachine(ComputeManagementClient computeClient, string serviceName, string deploymentName, string storageAccountName, string blobUrl)
        {
            VirtualMachineOSImageListResponse imagesList = computeClient.VirtualMachineOSImages.List();

            VirtualMachineOSImageListResponse.VirtualMachineOSImage imageToGet =
                imagesList.Images.FirstOrDefault(i => string.Equals(i.OperatingSystemType, "Windows", StringComparison.OrdinalIgnoreCase));

            VirtualMachineOSImageGetResponse gottenImage = computeClient.VirtualMachineOSImages.Get(imageToGet.Name);

            VirtualMachineCreateDeploymentParameters parameters = CreateVMParameters(gottenImage, deploymentName, storageAccountName, "SampleLabel", blobUrl);

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
                computeClient.VirtualMachines.CreateDeployment(serviceName, parameters);

            Assert.Equal(opResp.Status, OperationStatus.Succeeded);
        }

        public static VirtualMachineCreateDeploymentParameters CreateVMParameters(VirtualMachineOSImageGetResponse image, string deploymentName, string storageAccount, string deploymentLabel, string blobUri)
        {
            var blobUrl = GetUriForVMVhd(deploymentName, storageAccount, blobUri);
            string roleName = AZT.TestUtilities.GenerateName("role");
            VirtualMachineCreateDeploymentParameters parameters = new VirtualMachineCreateDeploymentParameters
            {
                DeploymentSlot = DeploymentSlot.Production,
                Label = deploymentLabel,
                Name = deploymentName
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
                RoleName = roleName,
                RoleType = VirtualMachineRoleType.PersistentVMRole.ToString(),
                RoleSize = VirtualMachineRoleSize.Large.ToString(),
            });

            return parameters;
        }

        private static Uri GetUriForVMVhd(string serviceName, string storageAccount, string blobUri)
        {
            string blobDiskFormat = "http://{1}.{2}/myvhds/{0}.vhd";
            Uri blobUrl = new Uri(string.Format(blobDiskFormat, serviceName, storageAccount, blobUri));
            return blobUrl;
        }

        public static VirtualMachineUpdateParameters GetVMUpdateParameters(Role roleToUpdate, string storageAccount,
            IEnumerable<ConfigurationSet> configSets, bool preserveOriginalConfigSets)
        {
            VirtualMachineUpdateParameters updateParameters = new VirtualMachineUpdateParameters
            {
                Label = roleToUpdate.Label,
                RoleName = roleToUpdate.RoleName,
                AvailabilitySetName = roleToUpdate.AvailabilitySetName,
                ConfigurationSets = preserveOriginalConfigSets ? roleToUpdate.ConfigurationSets : new List<ConfigurationSet>(),
                DataVirtualHardDisks = new List<DataVirtualHardDisk>(),
                OSVirtualHardDisk = new OSVirtualHardDisk(),
                ProvisionGuestAgent = roleToUpdate.ProvisionGuestAgent,
                ResourceExtensionReferences = roleToUpdate.ResourceExtensionReferences,
                RoleSize = roleToUpdate.RoleSize
            };
            if (updateParameters.ConfigurationSets == null)
            {
                updateParameters.ConfigurationSets = configSets.ToList();
            }
            else
            {
                foreach (var configurationSet in configSets)
                {
                    updateParameters.ConfigurationSets.Add(configurationSet);
                }
            }
            return updateParameters;
        }

        public static DeploymentGetResponse AssertLogicalVipWithoutIPPresentOrAbsent(ComputeManagementClient computeClient,
            string serviceName, string deploymentName, string virtualIPName, int expectedVipCount, bool present)
        {
            DeploymentGetResponse deploymentResponse =
                computeClient.Deployments.GetByName(serviceName: serviceName, deploymentName: deploymentName);

            var addedVip1 =
                deploymentResponse.VirtualIPAddresses.FirstOrDefault(vip => vip.Name == virtualIPName);
            if (present)
            {
                Assert.NotNull(addedVip1);
                Assert.True(string.IsNullOrEmpty(addedVip1.Address));
            }
            else
            {
                Assert.Null(addedVip1);
            }
            return deploymentResponse;
        }

        public static DeploymentGetResponse AssertLogicalVipWithIPPresent(ComputeManagementClient computeClient,
            string serviceName, string deploymentName, string virtualIPName, int expectedVipCount)
        {
            DeploymentGetResponse deploymentResponse =
                computeClient.Deployments.GetByName(serviceName: serviceName, deploymentName: deploymentName);

            var addedVip1 =
                deploymentResponse.VirtualIPAddresses.FirstOrDefault(vip => vip.Name == virtualIPName);
            Assert.NotNull(addedVip1);
            Assert.True(!string.IsNullOrEmpty(addedVip1.Address));

            return deploymentResponse;
        }

        public static void StopDeallocateRoles(ComputeManagementClient computeClient, string serviceName, string deploymentName)
        {
            var vmList = computeClient.Deployments.GetByName(serviceName, deploymentName).Roles;
            for (int i = 0; i < vmList.Count; i++)
            {
                var vm = vmList[i];
                var pa = i < vmList.Count - 1
                       ? PostShutdownAction.StoppedDeallocated : PostShutdownAction.Stopped;
                computeClient.VirtualMachines.Shutdown(
                    serviceName,
                    deploymentName,
                    vm.RoleName,
                    new VirtualMachineShutdownParameters
                    {
                        PostShutdownAction = pa
                    });

                if (i < vmList.Count - 1)
                {
                    computeClient.VirtualMachines.Delete(serviceName, deploymentName, vm.RoleName, true);
                }
                else
                {
                    computeClient.Deployments.DeleteByName(serviceName, deploymentName, true);
                }
            }
        }

        public static void DeleteContainerFromBlobStorage(StorageManagementClient storageClient, string storageAccount, string container)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                var service = storageClient.StorageAccounts.Get(storageAccount);
                var keys = storageClient.StorageAccounts.GetKeys(storageAccount);
                var account = new CloudStorageAccount(
                    new StorageCredentials(storageAccount, keys.PrimaryKey),
                    service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".blob.")),
                    service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".queue.")),
                    service.StorageAccount.Properties.Endpoints.First(e => e.ToString().ToLower().Contains(".table.")),
                    service.StorageAccount.Properties.Endpoints.FirstOrDefault(
                        e => e.ToString().ToLower().Contains(".file.")));
                var blobClient = account.CreateCloudBlobClient();
                var containerClient = blobClient.GetContainerReference(container);
                containerClient.DeleteIfExists();
            }
        }
    }
}
