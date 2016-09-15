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

﻿namespace BatchClientIntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Azure.Batch.Protocol.Models;
    using IntegrationTestUtilities;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using CloudJob = Microsoft.Azure.Batch.CloudJob;

    public class BatchRequestIntegrationTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(10);

        public BatchRequestIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        #region Cancellation

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task BatchRequestWithShortClientSideTimeout()
        {
            //The ThrowsAnyAsync must be outside the RunTestAsync or it will deadlock
            await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
                await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient client = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                    {
                        List<BatchClientBehavior> customBehaviors = new List<BatchClientBehavior>();
                        customBehaviors.Add(new RequestInterceptor((req) =>
                        {
                            //Set the timeout to something small so it is guaranteed to expire before the service has responded
                            req.Timeout = TimeSpan.FromMilliseconds(25);
                        }));

                        await client.JobOperations.GetJobAsync("Foo", additionalBehaviors: customBehaviors).ConfigureAwait(false);
                    }
                },
                TestTimeout));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task BatchRequestWithShortClientSideTimeoutAndRetries()
        {
            const int maxRetries = 5;
            int actualRequestCount = 0;

            //The ThrowsAnyAsync must be outside the RunTestAsync or it will deadlock
            await Assert.ThrowsAnyAsync<OperationCanceledException>(async () =>
                await SynchronizationContextHelper.RunTestAsync(async () =>
                {
                    using (BatchClient client = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                    {
                        client.CustomBehaviors.Add(RetryPolicyProvider.LinearRetryProvider(TimeSpan.FromMilliseconds(250), maxRetries));
                        List<BatchClientBehavior> customBehaviors = new List<BatchClientBehavior>();
                        customBehaviors.Add(new RequestInterceptor((req) =>
                        {
                            //Set the timeout to something small so it is guaranteed to expire before the service has responded
                            req.Timeout = TimeSpan.FromMilliseconds(25);

                            var castRequest = (JobGetBatchRequest)req;
                            Func<CancellationToken, Task<AzureOperationResponse<Microsoft.Azure.Batch.Protocol.Models.CloudJob, Microsoft.Azure.Batch.Protocol.Models.JobGetHeaders>>> oldFunc = castRequest.ServiceRequestFunc;
                            castRequest.ServiceRequestFunc = async (token) =>
                                                                   {
                                                                       actualRequestCount++; //Count the number of calls to the func
                                                                       return await oldFunc(token).ConfigureAwait(false);
                                                                   };
                        }));

                        await client.JobOperations.GetJobAsync("Foo", additionalBehaviors: customBehaviors).ConfigureAwait(false);
                    }
                },
                TestTimeout));

            Assert.Equal(maxRetries, actualRequestCount - 1); //Ensure that the number of retries is as expected
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task BatchRequestWithShortUserCancellationToken()
        {
            await SynchronizationContextHelper.RunTestAsync(async () =>
            {
                //Set the timeout to something small so it is guaranteed to expire before the service has responded
                using(CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromMilliseconds(25)))
                {
                    using (BatchClient client = await TestUtilities.OpenBatchClientAsync(TestUtilities.GetCredentialsFromEnvironment(), addDefaultRetryPolicy: false))
                    {
                        List<BatchClientBehavior> customBehaviors = new List<BatchClientBehavior>();
                        customBehaviors.Add(new RequestInterceptor((req) =>
                        {
                            req.CancellationToken = tokenSource.Token;
                        }));

                        await TestUtilities.AssertThrowsAsync<OperationCanceledException>(async () =>
                            await client.JobOperations.GetJobAsync("Foo", additionalBehaviors: customBehaviors).ConfigureAwait(false)).ConfigureAwait(false);
                    }
                }
            },
            TestTimeout);
        }

        #endregion
    }
}
