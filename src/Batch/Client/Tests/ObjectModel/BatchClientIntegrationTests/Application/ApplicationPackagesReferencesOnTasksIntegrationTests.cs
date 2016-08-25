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
    using System.Threading.Tasks;
    using Fixtures;
    using IntegrationTestUtilities;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Xunit;

    public class ApplicationPackagesReferencesOnTasksIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task ApplicationPackageReferencesOnCloudTaskAreRoundtripped()
        {
            string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-APROnCloudTaskAreRoundtripped";
            string taskId = "task-id";

            const string applicationId = "blender";
            const string applicationVerson = "beta";

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
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
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task ApplicationPackageReferencesOnJobManagerTaskAreRoundtripped()
        {
            string jobId = Constants.DefaultConveniencePrefix + TestUtilities.GetMyName() + "-APROnJobManagerTaskAreRoundtripped";
            const string applicationId = "blender";
            const string applicationVersion = "beta";

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
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
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }
    }
}
