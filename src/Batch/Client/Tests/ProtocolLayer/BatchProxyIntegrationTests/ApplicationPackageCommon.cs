// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO.Compression;
    using System.Text;
    using BatchTestCommon;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.WindowsAzure.Storage.Blob;


    internal static class ApplicationPackageCommon
    {
        public static async Task UpdateApplicationPackageAsync(string applicationId, string defaultVersion, string displayName, bool hasDefaultVersion)
        {
            string accountName = TestCommon.Configuration.BatchAccountName;
            string resourceGroupName = TestCommon.Configuration.BatchAccountResourceGroup;

            BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient();

            if (hasDefaultVersion)
            {
                await mgmtClient.Applications.UpdateApplicationAsync(
                        resourceGroupName,
                        accountName,
                        applicationId,
                        new UpdateApplicationParameters { AllowUpdates = true, DefaultVersion = defaultVersion, DisplayName = displayName });
            }
            else
            {
                await mgmtClient.Applications.UpdateApplicationAsync(
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

            using (BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                ListApplicationsResponse applicationSummaries = await mgmtClient.Applications.ListAsync(resourceGroupName, accountName, new ListApplicationsParameters());

                bool testPackageAlreadyUploaded = applicationSummaries.Applications.Any(a =>
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

            using (BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                var addResponse = await mgmtClient.Applications.AddApplicationPackageAsync(resourceGroupName, accountName, appPackageName, applicationVersion).ConfigureAwait(false);

                var storageUrl = addResponse.StorageUrl;

                await TestCommon.UploadTestApplicationAsync(storageUrl).ConfigureAwait(false);

                await mgmtClient.Applications.ActivateApplicationPackageAsync(resourceGroupName, accountName, appPackageName, applicationVersion, new ActivateApplicationPackageParameters { Format = format }).ConfigureAwait(false);
            }
        }
    }
}
