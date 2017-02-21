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

﻿namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Rest.Azure;
    using Xunit;

    internal static class ApplicationIntegrationCommon
    {
        internal const string ApplicationId = "integration-tests-fake";

        internal const string Version = "beta";

        public static async Task UploadTestApplicationPackageIfNotAlreadyUploadedAsync(
            string appPackageName,
            string applicationVersion,
            string accountName,
            string resourceGroupName)
        {
            using (BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                IPage<Application> applicationSummaries =
                    await mgmtClient.Application.ListAsync(resourceGroupName, accountName).ConfigureAwait(false);

                bool testPackageAlreadyUploaded =
                    applicationSummaries.Any(a => string.Equals(appPackageName, a.Id, StringComparison.OrdinalIgnoreCase));

                if (!testPackageAlreadyUploaded)
                {
                    const string format = "zip";

                    var addResponse =
                        await
                        mgmtClient.ApplicationPackage.CreateAsync(resourceGroupName, accountName, appPackageName, applicationVersion)
                                  .ConfigureAwait(false);
                    var storageUrl = addResponse.StorageUrl;

                    await TestCommon.UploadTestApplicationAsync(storageUrl).ConfigureAwait(false);

                    await
                        mgmtClient.ApplicationPackage.ActivateAsync(
                            resourceGroupName,
                            accountName,
                            appPackageName,
                            applicationVersion,
                            format).ConfigureAwait(false);
                }
            }
        }
        public static async Task DeleteApplicationAsync(string applicationPackage, string resourceGroupName, string accountName)
        {
            using (BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                await mgmtClient.ApplicationPackage.DeleteAsync(resourceGroupName, accountName, applicationPackage, Version).ConfigureAwait(false);

                await mgmtClient.Application.DeleteAsync(resourceGroupName, accountName, applicationPackage).ConfigureAwait(false);
            }
        }
    }
}