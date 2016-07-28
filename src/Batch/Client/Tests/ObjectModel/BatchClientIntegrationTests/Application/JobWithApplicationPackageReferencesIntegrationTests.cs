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
    using BatchClientIntegrationTests.Fixtures;
    using BatchClientIntegrationTests.IntegrationTestUtilities;

    using BatchTestCommon;

    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;

    using Xunit;

    using ApplicationPackageReference = Microsoft.Azure.Batch.ApplicationPackageReference;
    using AutoPoolSpecification = Microsoft.Azure.Batch.AutoPoolSpecification;
    using PoolSpecification = Microsoft.Azure.Batch.PoolSpecification;

    public class JobWithApplicationPackageReferencesIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateJobAndAutoPoolWithAppPackageReferences()
        {
            var jobId = Guid.NewGuid().ToString();
            const string applicationId = "blender";

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
                                ApplicationPackageReferences = new[]
                                {
                                    new ApplicationPackageReference
                                    {
                                        ApplicationId = applicationId,
                                        Version = PoolFixture.VMSize,
                                    }
                                },
                                CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                                VirtualMachineSize = PoolFixture.VMSize,
                            },
                            PoolLifetimeOption = PoolLifetimeOption.Job
                        }
                    };

                    CloudJob response = null;
                    try
                    {
                        CloudJob job = client.JobOperations.CreateJob(jobId, poolInfo);
                        await job.CommitAsync().ConfigureAwait(false);

                        response = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                        Assert.Equal(response.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().ApplicationId, applicationId);
                    }
                    finally
                    {
                        if (response != null)
                        {
                            TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                        }
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }
    }
}
