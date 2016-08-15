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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchClientIntegrationTests.Fixtures;
    using BatchClientIntegrationTests.IntegrationTestUtilities;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Xunit;

    public class ApplicationManagementIntegrationTests : IDisposable
    {
        private static readonly TimeSpan LongRunningTestTimeout = TimeSpan.FromMinutes(8);
        private const string ApplicationId = "end-to-end" + ApplicationIntegrationCommon.ApplicationId;
        private const string DisplayName = "test-app-beta";

        public ApplicationManagementIntegrationTests()
        {
            TestCommon.EnableAutoStorageAsync().Wait();

            ApplicationIntegrationCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(ApplicationId,
                ApplicationIntegrationCommon.Version,
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountResourceGroup).Wait();
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.LongDuration)]
        public async Task End2EndApplicationPackageScenario()
        {
            string accountName = TestCommon.Configuration.BatchAccountName;

            Func<Task> test = async () =>
                {
                    var poolId = "app-ref-test" + Guid.NewGuid();
                    using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                    {
                        using (var mgmtClient = TestCommon.OpenBatchManagementClient())
                        {
                            // Give the application a display name
                            await mgmtClient.Applications.UpdateApplicationAsync(TestCommon.Configuration.BatchAccountResourceGroup, accountName, ApplicationId, new UpdateApplicationParameters
                            {
                                AllowUpdates = true,
                                DefaultVersion = ApplicationIntegrationCommon.Version,
                                DisplayName = DisplayName
                            }).ConfigureAwait(false);

                            List<ApplicationSummary> applicationSummaries = await client.ApplicationOperations.ListApplicationSummaries().ToListAsync().ConfigureAwait(false);

                            ApplicationSummary applicationSummary = applicationSummaries.First();
                            Assert.Equal(ApplicationIntegrationCommon.Version, applicationSummary.Versions.First());
                            Assert.Equal(ApplicationId, applicationSummary.Id);
                            Assert.Equal(DisplayName, applicationSummary.DisplayName);


                            ApplicationSummary getApplicationSummary = await client.ApplicationOperations.GetApplicationSummaryAsync(applicationSummary.Id).ConfigureAwait(false);

                            Assert.Equal(getApplicationSummary.Id, applicationSummary.Id);
                            Assert.Equal(getApplicationSummary.Versions.Count(), applicationSummary.Versions.Count());
                            Assert.Equal(getApplicationSummary.DisplayName, applicationSummary.DisplayName);

                            var appPackage = await mgmtClient.Applications.GetApplicationPackageAsync(
                                    TestCommon.Configuration.BatchAccountResourceGroup,
                                    accountName,
                                    ApplicationId,
                                    ApplicationIntegrationCommon.Version).ConfigureAwait(false);

                            Assert.Equal(PackageState.Active, appPackage.State);
                            Assert.Equal(ApplicationIntegrationCommon.Version, appPackage.Version);
                            Assert.Equal(ApplicationId, appPackage.Id);

                            var getApplication = await mgmtClient.Applications.GetApplicationAsync(TestCommon.Configuration.BatchAccountResourceGroup, accountName, ApplicationId).ConfigureAwait(false);

                            Assert.Equal(ApplicationIntegrationCommon.Version, getApplication.Application.DefaultVersion);
                            Assert.Equal(ApplicationId, getApplication.Application.Id);

                            await AssertPoolWasCreatedWithApplicationReferences(client, poolId, ApplicationId).ConfigureAwait(false);
                        }
                    }
                };

            await SynchronizationContextHelper.RunTestAsync(test, LongRunningTestTimeout);
        }


        private static async Task AssertPoolWasCreatedWithApplicationReferences(BatchClient client, string poolId, string applicationId)
        {
            CloudPool referenceToPool = null;
            try
            {
                CloudPool pool = client.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));

                pool.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = applicationId, Version = ApplicationIntegrationCommon.Version } };

                await pool.CommitAsync().ConfigureAwait(false);

                referenceToPool = await client.PoolOperations.GetPoolAsync(poolId).ConfigureAwait(false);

                ApplicationPackageReference apr = referenceToPool.ApplicationPackageReferences.First();

                // Check to see if the pool had an application reference.
                Assert.Equal(apr.ApplicationId, applicationId);
                Assert.Equal(apr.Version, ApplicationIntegrationCommon.Version);
            }
            finally
            {
                TestUtilities.DeletePoolIfExistsAsync(client, poolId).Wait();
            }
        }

        public void Dispose()
        {
            Task.Run(async () => await ApplicationIntegrationCommon.DeleteApplicationAsync(
                ApplicationId,
                TestCommon.Configuration.BatchAccountResourceGroup,
                TestCommon.Configuration.BatchAccountName)).GetAwaiter().GetResult();
        }
    }
}
