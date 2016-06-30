namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
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
                ListApplicationsResponse applicationSummaries =
                    await mgmtClient.Applications.ListAsync(resourceGroupName, accountName, new ListApplicationsParameters()).ConfigureAwait(false);

                bool testPackageAlreadyUploaded =
                    applicationSummaries.Applications.Any(a => string.Equals(appPackageName, a.Id, StringComparison.OrdinalIgnoreCase));

                if (!testPackageAlreadyUploaded)
                {
                    const string format = "zip";

                    var addResponse =
                        await
                        mgmtClient.Applications.AddApplicationPackageAsync(resourceGroupName, accountName, appPackageName, applicationVersion)
                                  .ConfigureAwait(false);
                    var storageUrl = addResponse.StorageUrl;

                    await TestCommon.UploadTestApplicationAsync(storageUrl).ConfigureAwait(false);

                    await
                        mgmtClient.Applications.ActivateApplicationPackageAsync(
                            resourceGroupName,
                            accountName,
                            appPackageName,
                            applicationVersion,
                            new ActivateApplicationPackageParameters { Format = format }).ConfigureAwait(false);
                }
            }
        }
        public static async Task DeleteApplicationAsync(string applicationPackage, string resourceGroupName, string accountName)
        {
            using (BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient())
            {
                var deleteApplicationPackage =
                    await
                    mgmtClient.Applications.DeleteApplicationPackageAsync(resourceGroupName, accountName, applicationPackage, Version).ConfigureAwait(false);

                Assert.Equal(deleteApplicationPackage.StatusCode, HttpStatusCode.NoContent);

                var deleteApplicationResponse =
                    await mgmtClient.Applications.DeleteApplicationAsync(resourceGroupName, accountName, applicationPackage).ConfigureAwait(false);

                Assert.Equal(deleteApplicationResponse.StatusCode, HttpStatusCode.NoContent);
            }
        }
    }
}