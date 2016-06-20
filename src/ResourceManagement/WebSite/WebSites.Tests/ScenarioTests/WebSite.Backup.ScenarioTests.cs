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

using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using WebSites.Tests.Helpers;
using Xunit;
using System;

namespace WebSites.Tests.ScenarioTests
{
    public class BackupRestoreScenarioTests
    {
        public WebSiteManagementClient GetWebSitesClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<WebSiteManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        public ResourceManagementClient GetResourcesClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory()).WithHandler(handler);
        }

        [Fact(Skip = "Backup/Restore feature is not allowed in current site mode.")]
        public void ListBackupsAndScheduledBackupRoundTrip()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var webSitesClient = GetWebSitesClient(handler);
                var resourcesClient = GetResourcesClient(handler);

                string farmName = TestUtilities.GenerateName("csmsf");
                string resourceGroupName = TestUtilities.GenerateName("csmrg");

                string locationName = "West US";
                string siteName = TestUtilities.GenerateName("csmws");

                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = locationName
                    });

                webSitesClient.WebHostingPlans.CreateOrUpdate(resourceGroupName, new WebHostingPlanCreateOrUpdateParameters
                {
                    WebHostingPlan = new WebHostingPlan
                    {
                        Name = farmName,
                        Location = locationName,
                        Properties = new WebHostingPlanProperties
                        {
                            NumberOfWorkers = 1,
                            WorkerSize = WorkerSizeOptions.Small
                        }
                    }
                });

                webSitesClient.WebSites.CreateOrUpdate(resourceGroupName, siteName, null, new WebSiteCreateOrUpdateParameters()
                {
                    WebSite = new WebSiteBase()
                    {
                        Name = siteName,
                        Location = locationName,
                        Properties = new WebSiteBaseProperties()
                        {
                            ServerFarm = farmName
                        }
                    }
                });

                var backupResponse = webSitesClient.WebSites.ListBackups(resourceGroupName, siteName, null);
                Assert.Equal(0, backupResponse.BackupList.Properties.Count); // , "Backup list should be empty"

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
                    Name = "abc",
                    StorageAccountUrl = storageUrl
                };

                webSitesClient.WebSites.UpdateBackupConfiguration(resourceGroupName, siteName, null, new BackupRequestEnvelope()
                {
                    Location = locationName,
                    Request = sr
                });

                var backupConfiguration = webSitesClient.WebSites.GetBackupConfiguration(resourceGroupName, siteName, null);

                Assert.Equal(sr.Enabled, backupConfiguration.BackupSchedule.Properties.Enabled);
                Assert.Equal(sr.BackupSchedule.FrequencyInterval, backupConfiguration.BackupSchedule.Properties.BackupSchedule.FrequencyInterval);
                Assert.Equal(sr.BackupSchedule.FrequencyUnit, backupConfiguration.BackupSchedule.Properties.BackupSchedule.FrequencyUnit);
                Assert.Equal(sr.BackupSchedule.KeepAtLeastOneBackup, backupConfiguration.BackupSchedule.Properties.BackupSchedule.KeepAtLeastOneBackup);
                Assert.Equal(sr.Name, backupConfiguration.BackupSchedule.Properties.Name);

                webSitesClient.WebSites.Delete(resourceGroupName, siteName, null, new WebSiteDeleteParameters()
                {
                    DeleteAllSlots = true,
                    DeleteMetrics = true
                });

                webSitesClient.WebHostingPlans.Delete(resourceGroupName, farmName);

                var serverFarmResponse = webSitesClient.WebHostingPlans.List(resourceGroupName);

                Assert.Equal(0, serverFarmResponse.WebHostingPlans.Count);
            }
        }
    }
}
