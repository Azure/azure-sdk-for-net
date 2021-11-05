// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests.Application
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Fixtures;
    using IntegrationTestUtilities;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Xunit;

    public class ApplicationPackagesReferencesOnTasksIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task ApplicationPackageReferencesOnCloudTaskAreRoundtripped()
        {
            string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-APROnCloudTaskAreRoundtripped";
            string taskId = "task-id";

            const string applicationId = "blender";
            const string applicationVerson = "beta";

            async Task test()
            {
                using BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                var poolInfo = new PoolInformation
                {
                    AutoPoolSpecification = new AutoPoolSpecification
                    {
                        PoolSpecification = new PoolSpecification
                        {
                            CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                            VirtualMachineSize = PoolFixture.VMSize,
                        },
                        PoolLifetimeOption = PoolLifetimeOption.Job
                    }
                };

                try
                {
                    CloudJob job = client.JobOperations.CreateJob(jobId, poolInfo);
                    await job.CommitAsync().ConfigureAwait(false);

                    var boundJob = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                    CloudTask cloudTask = new CloudTask(taskId, "cmd /c ping 127.0.0.1")
                    {
                        ApplicationPackageReferences = new[]
                        {
                                new ApplicationPackageReference
                                {
                                    ApplicationId = applicationId,
                                    Version = applicationVerson
                                }
                            }
                    };

                    await boundJob.AddTaskAsync(cloudTask).ConfigureAwait(false);

                    CloudTask boundCloudTask = await boundJob.GetTaskAsync(taskId).ConfigureAwait(false);
                    Assert.Equal(applicationId, boundCloudTask.ApplicationPackageReferences.Single().ApplicationId);
                    Assert.Equal(applicationVerson, boundCloudTask.ApplicationPackageReferences.Single().Version);

                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task ApplicationPackageReferencesOnJobManagerTaskAreRoundtripped()
        {
            string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-APROnJobManagerTaskAreRoundtripped";
            const string applicationId = "blender";
            const string applicationVersion = "beta";

            async Task test()
            {
                using BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
                var poolInfo = new PoolInformation
                {
                    AutoPoolSpecification = new AutoPoolSpecification
                    {
                        PoolSpecification = new PoolSpecification
                        {
                            CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                            VirtualMachineSize = PoolFixture.VMSize,
                        },
                        PoolLifetimeOption = PoolLifetimeOption.Job
                    }
                };

                try
                {
                    CloudJob job = client.JobOperations.CreateJob(jobId, poolInfo);
                    job.JobManagerTask = new JobManagerTask
                    {
                        Id = jobId,
                        CommandLine = "cmd /c ping 127.0.0.1",
                        ApplicationPackageReferences = new[]{ new ApplicationPackageReference
                            {
                                ApplicationId = applicationId,
                                Version = applicationVersion
                            }}
                    };

                    await job.CommitAsync().ConfigureAwait(false);

                    var boundJob = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                    Assert.Equal(applicationId, boundJob.JobManagerTask.ApplicationPackageReferences.Single().ApplicationId);
                    Assert.Equal(applicationVersion, boundJob.JobManagerTask.ApplicationPackageReferences.Single().Version);

                }
                finally
                {
                    TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }
    }
}
