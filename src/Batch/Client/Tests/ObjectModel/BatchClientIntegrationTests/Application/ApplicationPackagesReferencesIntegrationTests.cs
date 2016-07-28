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
    using Microsoft.Azure.Batch.Common;
    using Xunit;

    using ApplicationPackageReference = Microsoft.Azure.Batch.ApplicationPackageReference;
    using CloudPool = Microsoft.Azure.Batch.CloudPool;

    public class ApplicationPackagesReferencesIntegrationTests : IClassFixture<ApplicationPackageFixture>
    {
        private static readonly TimeSpan LongTestTimeout = TimeSpan.FromMinutes(4);
        private const string ApplicationId = "iaprt" + ApplicationIntegrationCommon.ApplicationId;
        private const string Version = ApplicationIntegrationCommon.Version;

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task IfAPoolIsCommittedWithApplicationPackageReferences_ThenThoseReferencesArePersistedInTheService()
        {
            var poolId = "app-ref-test-1-" + Guid.NewGuid();

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    CloudPool newPool = null;
                    try
                    {
                        List<ApplicationSummary> applicationSummaries = await client.ApplicationOperations.ListApplicationSummaries().ToListAsync().ConfigureAwait(false);

                        foreach (var applicationSummary in applicationSummaries.Where(app => app.Id == ApplicationId))
                        {
                            Assert.True(true, string.Format("{0} was found.", applicationSummary.Id));
                        }
                        CloudPool pool = client.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));

                        pool.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = ApplicationId, Version = Version } };

                        await pool.CommitAsync().ConfigureAwait(false);

                        newPool = await client.PoolOperations.GetPoolAsync(poolId).ConfigureAwait(false);

                        ApplicationPackageReference apr = newPool.ApplicationPackageReferences.First();

                        Assert.Equal(ApplicationId, apr.ApplicationId);
                        Assert.Equal(Version, apr.Version);
                    }
                    finally
                    {
                        TestUtilities.DeletePoolIfExistsAsync(client, poolId).Wait();
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task UpdateAnExistingPoolWithNewApplicationPackageReferences_AndChecksTheApplicationPackageReferencesIsOnThePool()
        {
            var poolId = "app-ref-test-2-" + Guid.NewGuid();

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync())
                {
                    try
                    {
                        CloudPool pool = client.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));
                        await pool.CommitAsync().ConfigureAwait(false);

                        pool = await client.PoolOperations.GetPoolAsync(poolId).ConfigureAwait(false);
                        Assert.Null(pool.ApplicationPackageReferences);

                        pool.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = ApplicationId, Version = Version } };

                        await pool.CommitAsync().ConfigureAwait(false);

                        CloudPool updatedPool = await client.PoolOperations.GetPoolAsync(poolId).ConfigureAwait(false);

                        ApplicationPackageReference apr = updatedPool.ApplicationPackageReferences.First();

                        Assert.Equal(ApplicationId, apr.ApplicationId);
                        Assert.Equal(Version, apr.Version);
                    }
                    finally
                    {
                        TestUtilities.DeletePoolIfExistsAsync(client, poolId).Wait();
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task IfAPoolSpecifiesANonExistentApplicationPackage_ThenCommittingThePoolThrowsAnException()
        {
            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                var poolId = "app-ref-test-3-" + Guid.NewGuid();
                using (BatchClient client = TestUtilities.OpenBatchClientFromEnvironmentAsync().Result)
                {
                    CloudPool pool = client.PoolOperations.CreatePool(poolId, PoolFixture.VMSize, new CloudServiceConfiguration(PoolFixture.OSFamily));

                    pool.ApplicationPackageReferences = new[] { new ApplicationPackageReference { ApplicationId = "dud", Version = Version } };

                    await TestUtilities.AssertThrowsAsync<BatchException>(() => pool.CommitAsync()).ConfigureAwait(false);
                }
            }, LongTestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateAndUpdateJobScheduleWithApplicationReferences()
        {
            var jobId = Guid.NewGuid().ToString();

            const string newVersion = "2.0";

            var poolInformation = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification
                {
                    PoolSpecification = new PoolSpecification
                    {
                        ApplicationPackageReferences = new List<ApplicationPackageReference>
                        {
                            new ApplicationPackageReference
                            {
                                    ApplicationId = ApplicationId,
                                    Version = Version
                            }
                        },
                        CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                        VirtualMachineSize = PoolFixture.VMSize,
                    },
                    PoolLifetimeOption = PoolLifetimeOption.JobSchedule,
                    KeepAlive = false,
                }
            };

            Schedule schedule = new Schedule { DoNotRunAfter = DateTime.UtcNow.AddMinutes(5), RecurrenceInterval = TimeSpan.FromMinutes(2) };
            JobSpecification jobSpecification = new JobSpecification(poolInformation);

            using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
            {
                CloudJobSchedule cloudJobSchedule = client.JobScheduleOperations.CreateJobSchedule(jobId, schedule, jobSpecification);

                Func<Task> test = async () =>
                    {
                        CloudJobSchedule updatedBoundJobSchedule = null;

                        try
                        {
                            await cloudJobSchedule.CommitAsync().ConfigureAwait(false);

                            CloudJobSchedule boundJobSchedule = TestUtilities.WaitForJobOnJobSchedule(client.JobScheduleOperations, jobId);

                            ApplicationPackageReference apr = boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First();

                            Assert.Equal(ApplicationId, apr.ApplicationId);
                            Assert.Equal(Version, apr.Version);

                            boundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences = new []
                            {
                                new ApplicationPackageReference()
                                {
                                    ApplicationId = ApplicationId,
                                    Version = newVersion
                                }
                            };

                            await boundJobSchedule.CommitAsync().ConfigureAwait(false);
                            await boundJobSchedule.RefreshAsync().ConfigureAwait(false);

                            updatedBoundJobSchedule = await client.JobScheduleOperations.GetJobScheduleAsync(jobId).ConfigureAwait(false);

                            ApplicationPackageReference updatedApr =
                                updatedBoundJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences
                                                       .First();

                            Assert.Equal(ApplicationId, updatedApr.ApplicationId);
                            Assert.Equal(newVersion, updatedApr.Version);
                        }
                        finally
                        {
                            TestUtilities.DeleteJobScheduleIfExistsAsync(client, jobId).Wait();
                        }
                    };

                await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateJobAndAutoPoolWithAppPackageReferences()
        {
            string jobId = Guid.NewGuid().ToString();

            var poolInformation = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification
                {
                    PoolSpecification = new PoolSpecification
                    {
                        ApplicationPackageReferences = new List <ApplicationPackageReference>
                        {
                            new ApplicationPackageReference
                            {
                                    ApplicationId = ApplicationId,
                                    Version = Version
                            }
                        },
                        CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                        VirtualMachineSize = PoolFixture.VMSize,
                    },
                    PoolLifetimeOption = PoolLifetimeOption.Job
                }
            };

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    try
                    {
                        var job = client.JobOperations.CreateJob(jobId, poolInformation);

                        await job.CommitAsync().ConfigureAwait(false);

                        CloudJob jobResponse = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                        ApplicationPackageReference apr = jobResponse.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First();

                        Assert.Equal(ApplicationId, apr.ApplicationId);
                        Assert.Equal(Version, apr.Version);
                    }
                    finally
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, LongTestTimeout);
        }
    }
}
