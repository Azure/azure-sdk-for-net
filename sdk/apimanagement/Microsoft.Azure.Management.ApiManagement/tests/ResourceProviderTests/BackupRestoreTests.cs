// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using System.Linq;
using Xunit;
using System;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public void BackupAndRestoreService()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                var storageAccountName = TestUtilities.GenerateName("sdkapimbackup");
                Assert.True(testBase.storageClient.StorageAccounts.CheckNameAvailability(storageAccountName).NameAvailable);

                var storageAccountCreate = new StorageAccountCreateParameters()
                {
                    Location = testBase.location,
                    Sku = new Sku { Name = SkuName.StandardGRS },
                    Kind = Kind.Storage
                };

                testBase.storageClient.StorageAccounts.Create(testBase.rgName, storageAccountName, storageAccountCreate);
                var storageKeys = testBase.storageClient.StorageAccounts.ListKeys(testBase.rgName, storageAccountName);

                const string apimBackupContainerName = "apimbackupcontainer";
                const string apimBackupName = "apimbackup.zip";
                var parameters = new ApiManagementServiceBackupRestoreParameters()
                {
                    StorageAccount = storageAccountName,
                    AccessKey = storageKeys.Keys.First().Value,
                    BackupName = apimBackupName,
                    ContainerName = apimBackupContainerName
                };

                var backupServiceResponse = testBase.client.ApiManagementService.Backup(testBase.rgName, testBase.serviceName, parameters);
                Assert.NotNull(backupServiceResponse);
                ValidateService(backupServiceResponse,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);

                var restoreServiceResponse = testBase.client.ApiManagementService.Restore(testBase.rgName, testBase.serviceName, parameters);
                Assert.NotNull(restoreServiceResponse);
                ValidateService(restoreServiceResponse,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);
            }
        }
    }
}