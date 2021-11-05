// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using IntegrationTestCommon;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Rest.Azure;

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
            using BatchManagementClient mgmtClient = IntegrationTestCommon.OpenBatchManagementClient();
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

                await IntegrationTestCommon.UploadTestApplicationAsync(storageUrl).ConfigureAwait(false);

                await
                    mgmtClient.ApplicationPackage.ActivateAsync(
                        resourceGroupName,
                        accountName,
                        appPackageName,
                        applicationVersion,
                        format).ConfigureAwait(false);
            }
        }

        public static async Task DeleteApplicationAsync(string applicationPackage, string resourceGroupName, string accountName)
        {
            using BatchManagementClient mgmtClient = IntegrationTestCommon.OpenBatchManagementClient();
            await mgmtClient.ApplicationPackage.DeleteAsync(resourceGroupName, accountName, applicationPackage, Version).ConfigureAwait(false);

            await mgmtClient.Application.DeleteAsync(resourceGroupName, accountName, applicationPackage).ConfigureAwait(false);
        }
    }
}