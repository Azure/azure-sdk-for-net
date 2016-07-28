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

﻿namespace BatchProxyIntegrationTests
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;

    public class IntegrationJobApplicationPackageReferencesTests : IDisposable
    {
        private readonly string AccountName = TestCommon.Configuration.BatchAccountName;
        private readonly string AccountKey = TestCommon.Configuration.BatchAccountKey;
        private readonly string Url = TestCommon.Configuration.BatchAccountUrl;

        private readonly ITestOutputHelper output;

        private const string AppPackageName = "job-application-package-references-tests";
        private const string Version = "1.0";

        public IntegrationJobApplicationPackageReferencesTests(ITestOutputHelper output)
        {
            this.output = output;

            TestCommon.EnableAutoStorageAsync().Wait();

            ApplicationPackageCommon.UploadTestApplicationPackageIfNotAlreadyUploadedAsync(AppPackageName, Version).Wait();
            ApplicationPackageCommon.UpdateApplicationPackageAsync(AppPackageName, Version, "My First App", false).Wait();
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateJobAndAutoPoolWithAppPackageReferences()
        {
            var jobId = Guid.NewGuid().ToString();

            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolInfo = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification(poolLifetimeOption: PoolLifetimeOption.Job, pool: new PoolSpecification
                {
                    TargetDedicated = 0,
                    ApplicationPackageReferences = new[]
                         {
                             new ApplicationPackageReference { ApplicationId = AppPackageName, Version = Version },
                         },
                    CloudServiceConfiguration = new CloudServiceConfiguration("4"),
                    VmSize = "small",
                })
            };

            try
            {
                AzureOperationHeaderResponse<JobAddHeaders> addResponse = await client.Job.AddWithHttpMessagesAsync(new JobAddParameter(jobId, poolInfo: poolInfo)).ConfigureAwait(false);
                Assert.Equal(HttpStatusCode.Created, addResponse.Response.StatusCode);

                AzureOperationResponse<CloudJob, JobGetHeaders> response = await client.Job.GetWithHttpMessagesAsync(jobId).ConfigureAwait(false);
                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
                Assert.NotNull(response.Body);
                Assert.NotNull(response.Body.PoolInfo.AutoPoolSpecification.Pool.ApplicationPackageReferences);
                Assert.Equal(1, response.Body.PoolInfo.AutoPoolSpecification.Pool.ApplicationPackageReferences.Count);
                Assert.Equal(AppPackageName, response.Body.PoolInfo.AutoPoolSpecification.Pool.ApplicationPackageReferences[0].ApplicationId);
                Assert.Equal(Version, response.Body.PoolInfo.AutoPoolSpecification.Pool.ApplicationPackageReferences[0].Version);
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsNoThrow(client, jobId, output);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task AutoPoolApplicationPackagesFlowThroughToPool()
        {
            var jobId = Guid.NewGuid().ToString();

            var client = new BatchServiceClient(new Uri(Url), new BatchSharedKeyCredential(AccountName, AccountKey));

            var poolInfo = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification(poolLifetimeOption: PoolLifetimeOption.Job, pool: new PoolSpecification
                {
                    TargetDedicated = 0,
                    ApplicationPackageReferences = new[]
                        {
                            new ApplicationPackageReference { ApplicationId = AppPackageName, Version = Version },
                        },
                    CloudServiceConfiguration = new CloudServiceConfiguration("4"),
                    VmSize = "small",
                })
            };

            try
            {
                AzureOperationHeaderResponse<JobAddHeaders> addResponse = await client.Job.AddWithHttpMessagesAsync(new JobAddParameter(jobId, poolInfo: poolInfo)).ConfigureAwait(false);
                
                Assert.Equal(HttpStatusCode.Created, addResponse.Response.StatusCode);

                var autoPoolId = WaitForAutoPool(client, jobId);

                var poolResponse = await client.Pool.GetWithHttpMessagesAsync(autoPoolId).ConfigureAwait(false);

                Assert.Equal(HttpStatusCode.OK, poolResponse.Response.StatusCode);
                Assert.NotNull(poolResponse.Body);
                Assert.Equal(1, poolResponse.Body.ApplicationPackageReferences.Count);
                Assert.Equal(AppPackageName, poolResponse.Body.ApplicationPackageReferences[0].ApplicationId);
                Assert.Equal(Version, poolResponse.Body.ApplicationPackageReferences[0].Version);
            }
            finally
            {
                TestUtilities.DeleteJobIfExistsNoThrow(client, jobId, output);
            }
        }

        private string WaitForAutoPool(BatchServiceClient client, string jobId)
        {
            var stopwatch = Stopwatch.StartNew();

            string poolId = null;

            while (true)
            {
                if (stopwatch.Elapsed > TimeSpan.FromMinutes(1))
                {
                    throw new Exception("Timeout waiting for auto pool for job " + jobId);
                }

                var job = client.Job.GetAsync(jobId).Result;

                if (!string.IsNullOrEmpty(job.ExecutionInfo.PoolId))
                {
                    poolId = job.ExecutionInfo.PoolId;
                    break;
                }

                Thread.Sleep(1000);
            }

            stopwatch.Restart();

            while (true)
            {
                if (stopwatch.Elapsed > TimeSpan.FromMinutes(1))
                {
                    throw new Exception("Timeout waiting for auto pool for job " + jobId);
                }

                try
                {
                    var response = client.Pool.GetAsync(poolId).Result;
                    return poolId;
                }
                catch (Exception)
                {
                    // ignored
                }

                Thread.Sleep(1000);
            }
        }

        public void Dispose()
        {
            BatchManagementClient mgmtClient = TestCommon.OpenBatchManagementClient();
            string accountName = TestCommon.Configuration.BatchAccountName;
            string resourceGroupName = TestCommon.Configuration.BatchAccountResourceGroup;

            Func<Task> cleanupTask = async () =>
                {
                    await mgmtClient.Applications.DeleteApplicationPackageAsync(resourceGroupName, accountName, AppPackageName, Version);
                    await mgmtClient.Applications.DeleteApplicationAsync(resourceGroupName, accountName, AppPackageName);
                };

            Task.Run(cleanupTask).GetAwaiter().GetResult();
        }
    }
}
