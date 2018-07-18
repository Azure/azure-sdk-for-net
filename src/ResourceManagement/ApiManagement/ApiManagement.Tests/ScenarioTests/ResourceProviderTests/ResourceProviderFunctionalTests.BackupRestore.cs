//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.ResourceProviderTests
{
    using System.Net;
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Xunit;

    public partial class ResourceProviderFunctionalTests
    {
        [Fact]
        public void BackupRestore()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "BackupRestore");

                TryCreateApiService();

                // create storage account with blob container for the API Management backup
                var storageManagementClient = GetServiceClient<StorageManagementClient>();

                var storageAccountName = TestUtilities.GenerateName("hydraapimstorage");
                Assert.True(
                    storageManagementClient.StorageAccounts.CheckNameAvailability(storageAccountName).IsAvailable,
                    "Could not generate unique storage account name");

                var storageCreateParams = new StorageAccountCreateParameters
                {
                    Name = storageAccountName,
                    Location = Location,
                    AffinityGroup = null,
                    Label = "ApimHydraBackupRestoreTest",
                    Description = "Api Management hydra client backup/restore test",
                    AccountType = StorageAccountTypes.StandardGRS
                };
                storageManagementClient.StorageAccounts.Create(storageCreateParams);
                var storageKeysResponse = storageManagementClient.StorageAccounts.GetKeys(storageAccountName);

                const string apimBackupContainerName = "apimbackupcontainer";

                // create API Management backup
                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());
                apiManagementClient.RefreshAccessToken();

                const string apimBackupName = "apimbackup.zip";
                var backupRestoreParameters = new ApiServiceBackupRestoreParameters
                {
                    StorageAccount = storageAccountName,
                    AccessKey = storageKeysResponse.PrimaryKey,
                    ContainerName = apimBackupContainerName,
                    BackupName = apimBackupName
                };
                var response =
                    apiManagementClient.ResourceProvider.Backup(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        backupRestoreParameters);

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // restore Api Management service from backup

                apiManagementClient.RefreshAccessToken();

                response =
                    apiManagementClient.ResourceProvider.Restore(
                        ResourceGroupName,
                        ApiManagementServiceName,
                        backupRestoreParameters);

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal("Succeeded", getResponse.Value.Properties.ProvisioningState);
            }
        }
    }
}