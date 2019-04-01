// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using WebSites.Tests.Helpers;
using Xunit;

namespace WebSites.Tests.ScenarioTests
{
    public class BackupRestoreScenarioTests : TestBase
    {
        [Fact]
        public void ListBackupsAndScheduledBackupRoundTrip()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var webSitesClient = this.GetWebSiteManagementClient(context);
                var resourcesClient = this.GetResourceManagementClient(context);

                string farmName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                string locationName = "West US";
                string siteName = TestUtilities.GenerateName("csmws");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = locationName
                    });

                webSitesClient.AppServicePlans.CreateOrUpdate(resourceGroupName, farmName, new AppServicePlan
                {
                    Location = locationName,
                    Sku = new SkuDescription
                    {
                        Name = "S1",
                        Tier = "Standard",
                        Capacity = 1
                    }
                });

                var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, farmName);
                webSitesClient.WebApps.CreateOrUpdate(resourceGroupName, siteName, new Site
                {
                    Location = locationName,
                    ServerFarmId = serverfarmId
                });

                var backupResponse = webSitesClient.WebApps.ListBackups(resourceGroupName, siteName);
                Assert.Equal(0, backupResponse.Count()); // , "Backup list should be empty"

                // the following URL just have a proper format, but it is not valid - for an API test it is not needed to be valid,
                // since we are just testing a roundtrip here
                // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                string storageUrl = "https://nonexistingusername3567.blob.core.windows.net/backup/?sv=2012-02-12&st=2013-12-05T19%3A30%3A45Z&se=2017-12-04T19%3A30%3A45Z&sr=c&sp=rwdl&sig=3BY5sbzQ2NeKvdaelzxc8inxJgE1mGq2a%2BaqUeFGJYo%3D";

                var sr = new BackupRequest()
                {
                    Enabled = false,
                    BackupSchedule = new BackupSchedule()
                    {
                        FrequencyInterval = 17,
                        FrequencyUnit = FrequencyUnit.Day,
                        KeepAtLeastOneBackup = true,
                        RetentionPeriodInDays = 26,
                        StartTime = DateTime.Now.AddDays(5)
                    },
                    BackupName = "abc",
                    StorageAccountUrl = storageUrl
                };

                webSitesClient.WebApps.UpdateBackupConfiguration(resourceGroupName, siteName, sr);

                var backupConfiguration = webSitesClient.WebApps.GetBackupConfiguration(resourceGroupName, siteName);

                Assert.Equal(sr.Enabled, backupConfiguration.Enabled);
                Assert.Equal(sr.BackupSchedule.FrequencyInterval, backupConfiguration.BackupSchedule.FrequencyInterval);
                Assert.Equal(sr.BackupSchedule.FrequencyUnit, backupConfiguration.BackupSchedule.FrequencyUnit);
                Assert.Equal(sr.BackupSchedule.KeepAtLeastOneBackup, backupConfiguration.BackupSchedule.KeepAtLeastOneBackup);
                Assert.Equal(sr.BackupName, backupConfiguration.BackupName);

                webSitesClient.WebApps.Delete(resourceGroupName, siteName, deleteMetrics: true);

                webSitesClient.AppServicePlans.Delete(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.AppServicePlans.ListByResourceGroup(resourceGroupName);

                Assert.Equal(0, serverFarmResponse.Count());
            }
        }
    }
}
