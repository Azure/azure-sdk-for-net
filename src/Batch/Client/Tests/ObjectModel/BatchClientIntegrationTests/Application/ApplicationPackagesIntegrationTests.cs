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
    using BatchClientIntegrationTests.IntegrationTestUtilities;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;

    using Xunit;

    public class ApplicationPackagesIntegrationTests : IDisposable
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);
        private const string ApplicationId = "iapt-" + ApplicationIntegrationCommon.ApplicationId;

        public ApplicationPackagesIntegrationTests()
        {


            TestCommon.EnableAutoStorageAsync().Wait();

            ApplicationIntegrationCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(
                ApplicationId,
                ApplicationIntegrationCommon.Version,
                TestCommon.Configuration.BatchAccountName,
                TestCommon.Configuration.BatchAccountResourceGroup).Wait();
        }


        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task IfThereAreApplicationsInTheAccountThenListApplicationSummariesReturnsThem()
        {
            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    List<ApplicationSummary> applicationSummaries = await client.ApplicationOperations.ListApplicationSummaries().ToListAsync().ConfigureAwait(false);
                    var application = applicationSummaries.First(app => app.Id == ApplicationId);

                    Assert.Equal(ApplicationId, application.Id);
                    Assert.Equal(ApplicationIntegrationCommon.Version, application.Versions.FirstOrDefault());

                    ApplicationSummary getApplicationSummary = await client.ApplicationOperations.GetApplicationSummaryAsync(application.Id).ConfigureAwait(false);

                    Assert.Equal(ApplicationId, getApplicationSummary.Id);
                    Assert.Equal(ApplicationIntegrationCommon.Version, getApplicationSummary.Versions.First());
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
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


