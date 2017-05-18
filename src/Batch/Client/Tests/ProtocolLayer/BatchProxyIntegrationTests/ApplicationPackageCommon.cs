// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO.Compression;
    using System.Text;
    using BatchTestCommon;
    using IntegrationTestCommon;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.WindowsAzure.Storage.Blob;


    internal static class ApplicationPackageCommon
    {
        public static async Task UpdateApplicationPackageAsync(string applicationId, string defaultVersion, string displayName, bool hasDefaultVersion)
        {
            string accountName = TestCommon.Configuration.BatchAccountName;
            string resourceGroupName = TestCommon.Configuration.BatchAccountResourceGroup;

            BatchManagementClient mgmtClient = IntegrationTestCommon.OpenBatchManagementClient();

            if (hasDefaultVersion)
            {
                await mgmtClient.Application.UpdateAsync(
                        resourceGroupName,
                        accountName,
                        applicationId,
                        new UpdateApplicationParameters { AllowUpdates = true, DefaultVersion = defaultVersion, DisplayName = displayName });
            }
            else
            {
                await mgmtClient.Application.UpdateAsync(
                        resourceGroupName,
                        accountName,
                        applicationId,
                        new UpdateApplicationParameters { AllowUpdates = true, DisplayName = displayName });
            }
        }

        public static async Task UploadTestApplicationPackageIfNotAlreadyUploadedAsync(string appPackageName, string applicationVersion)
        {
            string accountName = TestCommon.Configuration.BatchAccountName;
            string resourceGroupName = TestCommon.Configuration.BatchAccountResourceGroup;

            using (BatchManagementClient mgmtClient = IntegrationTestCommon.OpenBatchManagementClient())
            {
                var applicationSummaries = await mgmtClient.Application.ListAsync(resourceGroupName, accountName);

                bool testPackageAlreadyUploaded = applicationSummaries.Any(a =>
                        string.Equals(appPackageName, a.Id, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(applicationVersion, a.DefaultVersion, StringComparison.OrdinalIgnoreCase));

                if (!testPackageAlreadyUploaded)
                {
                    await UploadTestApplicationAndActivateAsync(appPackageName, applicationVersion, resourceGroupName, accountName).ConfigureAwait(false);
                }
            }
        }

        private static async Task UploadTestApplicationAndActivateAsync(string appPackageName, string applicationVersion, string resourceGroupName, string accountName)
        {
            const string format = "zip";

            using (BatchManagementClient mgmtClient = IntegrationTestCommon.OpenBatchManagementClient())
            {
                var addResponse = await mgmtClient.ApplicationPackage.CreateAsync(resourceGroupName, accountName, appPackageName, applicationVersion).ConfigureAwait(false);

                var storageUrl = addResponse.StorageUrl;

                await IntegrationTestCommon.UploadTestApplicationAsync(storageUrl).ConfigureAwait(false);

                await mgmtClient.ApplicationPackage.ActivateAsync(resourceGroupName, accountName, appPackageName, applicationVersion, format).ConfigureAwait(false);
            }
        }
    }
}
