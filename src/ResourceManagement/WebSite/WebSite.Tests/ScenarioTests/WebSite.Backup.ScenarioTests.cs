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

using System;
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
        [Fact(Skip = "Backup/Restore feature is not allowed in current site mode.")]
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

                webSitesClient.ServerFarms.CreateOrUpdateServerFarm(resourceGroupName, farmName, new ServerFarmWithRichSku
                {
                    ServerFarmWithRichSkuName = farmName,
                    Location = locationName,
                    Sku = new SkuDescription
                    {
                        Name = "F1",
                        Tier = "Free",
                        Capacity = 1
                    }
                });

                var serverfarmId = ResourceGroupHelper.GetServerFarmId(webSitesClient.SubscriptionId, resourceGroupName, farmName);
                webSitesClient.Sites.CreateOrUpdateSite(resourceGroupName, siteName, new Site
                {
                    SiteName = siteName,
                    Location = locationName,
                    ServerFarmId = serverfarmId
                });

                var backupResponse = webSitesClient.Sites.ListSiteBackups(resourceGroupName, siteName);
                Assert.Equal(0, backupResponse.Value.Count); // , "Backup list should be empty"

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
                    BackupRequestName = "abc",
                    StorageAccountUrl = storageUrl
                };

                webSitesClient.Sites.UpdateSiteBackupConfiguration(resourceGroupName, siteName, sr);

                var backupConfiguration = webSitesClient.Sites.GetSiteBackupConfiguration(resourceGroupName, siteName);

                Assert.Equal(sr.Enabled, backupConfiguration.Enabled);
                Assert.Equal(sr.BackupSchedule.FrequencyInterval, backupConfiguration.BackupSchedule.FrequencyInterval);
                Assert.Equal(sr.BackupSchedule.FrequencyUnit, backupConfiguration.BackupSchedule.FrequencyUnit);
                Assert.Equal(sr.BackupSchedule.KeepAtLeastOneBackup, backupConfiguration.BackupSchedule.KeepAtLeastOneBackup);
                Assert.Equal(sr.Name, backupConfiguration.BackupRequestName);

                webSitesClient.Sites.DeleteSite(resourceGroupName, siteName, deleteAllSlots: true.ToString(), deleteMetrics: true.ToString());

                webSitesClient.ServerFarms.DeleteServerFarm(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.ServerFarms.GetServerFarms(resourceGroupName);

                Assert.Equal(0, serverFarmResponse.Value.Count);
            }
        }
    }
}
