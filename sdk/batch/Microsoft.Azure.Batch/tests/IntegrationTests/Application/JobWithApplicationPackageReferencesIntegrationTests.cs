// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    using Microsoft.Azure.Batch.Integration.Tests.Infrastructure;
    using Xunit;
    using ApplicationPackageReference = Microsoft.Azure.Batch.ApplicationPackageReference;
    using AutoPoolSpecification = Microsoft.Azure.Batch.AutoPoolSpecification;
    using PoolSpecification = Microsoft.Azure.Batch.PoolSpecification;

    public class JobWithApplicationPackageReferencesIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);

        [Fact]
        [LiveTest]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateJobAndAutoPoolWithAppPackageReferences()
        {
            var jobId = Guid.NewGuid().ToString();
            const string applicationId = "blender";

            async Task test()
            {
                using BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false);
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

                    Assert.Equal(applicationId, response.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().ApplicationId);
                }
                finally
                {
                    if (response != null)
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            }

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }
    }
}
