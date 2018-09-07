// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using CloudJob = Microsoft.Azure.Batch.CloudJob;
    using CloudJobSchedule = Microsoft.Azure.Batch.CloudJobSchedule;
    using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;


    public class RetryPolicyUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        private readonly Microsoft.Azure.Batch.Auth.BatchSharedKeyCredentials credentials;

        public RetryPolicyUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            this.credentials = ClientUnitTestCommon.CreateDummySharedKeyCredential();
        }

        #region Built in Retry Policy Tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void LinearRetryPropertiesSetCorrect()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;
            LinearRetry linearRetry = new LinearRetry(interval, maxRetries);

            Assert.Equal(interval, linearRetry.DeltaBackoff);
            Assert.Equal(maxRetries, linearRetry.MaximumRetries);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task LinearRetryRetriesOnNonBatchException()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;
            LinearRetry linearRetry = new LinearRetry(interval, maxRetries);

            TimeoutException timeoutException = new TimeoutException();

            RetryDecision retryDecision = await linearRetry.ShouldRetryAsync(timeoutException, new OperationContext());

            Assert.Equal(interval, retryDecision.RetryDelay);
            Assert.True(retryDecision.ShouldRetry);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task LinearRetryRetriesOnBatchException()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;
            LinearRetry linearRetry = new LinearRetry(interval, maxRetries);

            RequestInformation reqInfo = new RequestInformation() {HttpStatusCode = HttpStatusCode.InternalServerError};
            BatchException batchException = new BatchException(reqInfo, "Message", null);

            RetryDecision retryDecision = await linearRetry.ShouldRetryAsync(batchException, new OperationContext());

            Assert.Equal(interval, retryDecision.RetryDelay);
            Assert.True(retryDecision.ShouldRetry);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task LinearRetryAbortsRetriesAfterMaxRetryCount()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 5;
            LinearRetry linearRetry = new LinearRetry(interval, maxRetries);

            TimeoutException timeoutException = new TimeoutException();

            OperationContext context = new OperationContext();

            RetryDecision retryDecision = null;
            int requestCount = 0;
            while (retryDecision == null || retryDecision.ShouldRetry)
            {
                context.RequestResults.Add(new RequestResult(new RequestInformation(), timeoutException));
                retryDecision = await linearRetry.ShouldRetryAsync(timeoutException, context);

                Assert.NotNull(retryDecision);
                if (retryDecision.ShouldRetry)
                {
                    Assert.Equal(interval, retryDecision.RetryDelay);
                }
                ++requestCount;
            }

            Assert.Equal(maxRetries, requestCount - 1); //request count is retry count + 1
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void LinearRetryThrowsOnInvalidMaxRetry()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = -1;
            ArgumentOutOfRangeException e = Assert.Throws<ArgumentOutOfRangeException>(() => { new LinearRetry(interval, maxRetries); });

            Assert.Equal("maxRetries", e.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void LinearRetryThrowsOnInvalidInterval()
        {
            TimeSpan interval = TimeSpan.FromSeconds(-3);
            const int maxRetries = 0;
            ArgumentOutOfRangeException e = Assert.Throws<ArgumentOutOfRangeException>(() => { new LinearRetry(interval, maxRetries); });

            Assert.Equal("deltaBackoff", e.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task LinearRetryDoesNotRetryOnValidationExceptions()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(1);
            const int maxRetries = 3;

            IRetryPolicy policy = new LinearRetry(deltaBackoff, maxRetries);

            await this.AssertPolicyDoesNotRetryOnValidationExceptions(policy);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ExponentialRetryPropertiesSetCorrect()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;
            ExponentialRetry exponentialRetry = new ExponentialRetry(interval, maxRetries);

            Assert.Equal(interval, exponentialRetry.DeltaBackoff);
            Assert.Equal(maxRetries, exponentialRetry.MaximumRetries);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ExponentialRetryRetriesOnNonBatchException()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;

            ExponentialRetry exponentialRetry = new ExponentialRetry(interval, maxRetries);

            TimeoutException timeoutException = new TimeoutException();
            OperationContext context = new OperationContext();
            context.RequestResults.Add(new RequestResult(new RequestInformation(), timeoutException));
            RetryDecision retryDecision = await exponentialRetry.ShouldRetryAsync(timeoutException, context);

            Assert.Equal(interval, retryDecision.RetryDelay);
            Assert.True(retryDecision.ShouldRetry);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ExponentialRetryRetriesOnBatchException()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = 10;
            ExponentialRetry exponentialRetry = new ExponentialRetry(interval, maxRetries);

            RequestInformation reqInfo = new RequestInformation() { HttpStatusCode = HttpStatusCode.InternalServerError };
            BatchException batchException = new BatchException(reqInfo, "Message", null);

            OperationContext context = new OperationContext();
            context.RequestResults.Add(new RequestResult(new RequestInformation(), batchException));

            RetryDecision retryDecision = await exponentialRetry.ShouldRetryAsync(batchException, context);

            Assert.Equal(interval, retryDecision.RetryDelay);
            Assert.True(retryDecision.ShouldRetry);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ExponentialRetryAbortsRetriesAfterMaxRetryCount()
        {
            const int delayInSeconds = 3;
            TimeSpan interval = TimeSpan.FromSeconds(delayInSeconds);
            const int maxRetries = 5;
            ExponentialRetry exponentialRetry = new ExponentialRetry(interval, maxRetries);

            TimeoutException timeoutException = new TimeoutException();

            OperationContext context = new OperationContext();
            RetryDecision retryDecision = null;
            int requestCount = 0;
            while (retryDecision == null || retryDecision.ShouldRetry)
            {
                context.RequestResults.Add(new RequestResult(new RequestInformation(), timeoutException));
                retryDecision = await exponentialRetry.ShouldRetryAsync(timeoutException, context);

                Assert.NotNull(retryDecision);

                if (retryDecision.ShouldRetry)
                {
                    TimeSpan expectedDelay = TimeSpan.FromSeconds(Math.Pow(2, requestCount) * delayInSeconds);
                    Assert.Equal(expectedDelay, retryDecision.RetryDelay);
                }

                ++requestCount;
            }

            Assert.Equal(maxRetries, requestCount - 1); //request count is retry count + 1
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ExponentialRetryThrowsOnInvalidMaxRetry()
        {
            TimeSpan interval = TimeSpan.FromSeconds(5);
            const int maxRetries = -1;
            ArgumentOutOfRangeException e = Assert.Throws<ArgumentOutOfRangeException>(() => { new ExponentialRetry(interval, maxRetries); });

            Assert.Equal("maxRetries", e.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ExponentialRetryThrowsOnInvalidInterval()
        {
            TimeSpan interval = TimeSpan.FromSeconds(-3);
            const int maxRetries = 0;
            ArgumentOutOfRangeException e = Assert.Throws<ArgumentOutOfRangeException>(() => { new ExponentialRetry(interval, maxRetries); });

            Assert.Equal("deltaBackoff", e.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ExponentialRetryDoesNotRetryOnValidationExceptions()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(1);
            const int maxRetries = 3;

            IRetryPolicy policy = new ExponentialRetry(deltaBackoff, maxRetries);

            await this.AssertPolicyDoesNotRetryOnValidationExceptions(policy);
        }

        #endregion

        #region BatchRequest RetryPolicy tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestNoRetriesWithNonBatchException()
        {
            int serviceRequestFuncCallCount = 0;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = (token) =>
            {
                ++serviceRequestFuncCallCount;
                throw new TimeoutException();
            };

            IRetryPolicy policy = new NoRetry();
            request.RetryPolicy = policy;

            TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => { await request.ExecuteRequestAsync(); });

            Assert.Equal(1, serviceRequestFuncCallCount);
            Assert.Equal(1, request.OperationContext.RequestResults.Count);

            foreach (RequestResult requestResult in request.OperationContext.RequestResults)
            {
                Assert.IsType<TimeoutException>(requestResult.Exception);
                Assert.Null(requestResult.RequestInformation.BatchError);
                Assert.Null(requestResult.RequestInformation.HttpStatusCode);
                Assert.Null(requestResult.RequestInformation.HttpStatusMessage);
                Assert.Null(requestResult.RequestInformation.ServiceRequestId);
                Assert.NotEqual(Guid.Empty, requestResult.RequestInformation.ClientRequestId);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestRetriesExecutedWithNonBatchException()
        {
            TimeSpan deltaBackoff = TimeSpan.FromMilliseconds(100);
            const int maxRetries = 5;
            int serviceRequestFuncCallCount = 0;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = (token) =>
            {
                ++serviceRequestFuncCallCount;
                throw new TimeoutException();
            };

            IRetryPolicy policy = new LinearRetry(deltaBackoff, maxRetries);
            request.RetryPolicy = policy;

            TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => { await request.ExecuteRequestAsync(); });

            Assert.Equal(maxRetries + 1, serviceRequestFuncCallCount);
            Assert.Equal(maxRetries + 1, request.OperationContext.RequestResults.Count);

            foreach (RequestResult requestResult in request.OperationContext.RequestResults)
            {
                Assert.IsType<TimeoutException>(requestResult.Exception);
                Assert.Null(requestResult.RequestInformation.BatchError);
                Assert.Null(requestResult.RequestInformation.HttpStatusCode);
                Assert.Null(requestResult.RequestInformation.HttpStatusMessage);
                Assert.Null(requestResult.RequestInformation.ServiceRequestId);
                Assert.NotEqual(Guid.Empty, requestResult.RequestInformation.ClientRequestId);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestRetriesExecutedWithAggregateException()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(0);
            const int maxRetries = 5;
            int serviceRequestFuncCallCount = 0;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = async (token) =>
            {
                ++serviceRequestFuncCallCount;
                
                Action throwsAction = () => { throw new InvalidOperationException(); };
                Task throwsTask1 = Task.Factory.StartNew(throwsAction);
                Task throwsTask2 = Task.Factory.StartNew(throwsAction);
                await Task.WhenAll(throwsTask1, throwsTask2); //This will throw

                return null;
            };

            IRetryPolicy policy = new LinearRetry(deltaBackoff, maxRetries);
            request.RetryPolicy = policy;

            Task executeRequestTask = request.ExecuteRequestAsync();

            //We will observe only 1 exception (not an Aggregate) from the throw
            InvalidOperationException e = await Assert.ThrowsAsync<InvalidOperationException>(async () => { await executeRequestTask; });

            //But the task itself should have the full set of exceptions which were hit
            AggregateException aggregateException = executeRequestTask.Exception;

            //TODO: Why can't this be 2?
            //Assert.Equal(2, aggregateException.InnerExceptions.Count);
            Assert.Equal(1, aggregateException.InnerExceptions.Count);

            Assert.Equal(maxRetries + 1, serviceRequestFuncCallCount);
            Assert.Equal(maxRetries + 1, request.OperationContext.RequestResults.Count);

            foreach (RequestResult requestResult in request.OperationContext.RequestResults)
            {
                Assert.IsType<InvalidOperationException>(requestResult.Exception);
                Assert.Null(requestResult.RequestInformation.BatchError);
                Assert.Null(requestResult.RequestInformation.HttpStatusCode);
                Assert.Null(requestResult.RequestInformation.HttpStatusMessage);
                Assert.Null(requestResult.RequestInformation.ServiceRequestId);
                Assert.NotEqual(Guid.Empty, requestResult.RequestInformation.ClientRequestId);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestNoRetryPolicyNoRetriesExecutedWithAggregateException()
        {
            int serviceRequestFuncCallCount = 0;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = async (token) =>
            {
                ++serviceRequestFuncCallCount;

                Action throwsAction = () => { throw new ArgumentException(); };
                Task throwsTask1 = Task.Factory.StartNew(throwsAction);
                Task throwsTask2 = Task.Factory.StartNew(throwsAction);
                await Task.WhenAll(throwsTask1, throwsTask2); //This will throw

                return null;
            };

            Task executeRequestTask = request.ExecuteRequestAsync();

            //We will observe only 1 exception (not an Aggregate) from the throw
            ArgumentException e = await Assert.ThrowsAsync<ArgumentException>(async () => { await executeRequestTask; });

            //But the task itself should have the full set of exceptions which were hit
            AggregateException aggregateException = executeRequestTask.Exception;

            //TODO: Why can't this be 2?
            //Assert.Equal(2, aggregateException.InnerExceptions.Count);
            Assert.Equal(1, aggregateException.InnerExceptions.Count);

            Assert.Equal(1, serviceRequestFuncCallCount);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestNoRetryStackTracePreserved()
        {
            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = (token) =>
            {
                throw new TimeoutException();
            };

            TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => { await request.ExecuteRequestAsync(); });

            //The StackTrace should contain this method
            Assert.Contains("BatchRequestNoRetryStackTracePreserved", e.StackTrace);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestRetryStackTracePreserved()
        {
            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = (token) =>
            {
                throw new TimeoutException();
            };

            IRetryPolicy policy = new ExponentialRetry(TimeSpan.FromSeconds(0), 3);
            request.RetryPolicy = policy;

            TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => { await request.ExecuteRequestAsync(); });

            //The StackTrace should contain this method
            Assert.Contains("BatchRequestRetryStackTracePreserved", e.StackTrace);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestRetryPolicyNoExceptionNoRetries()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(0);
            const int maxRetries = 5;
            int serviceRequestFuncCallCount = 0;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            request.ServiceRequestFunc = (token) =>
            {
                ++serviceRequestFuncCallCount;
                return Task.FromResult(default(AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>));
            };

            IRetryPolicy policy = new ExponentialRetry(deltaBackoff, maxRetries);
            request.RetryPolicy = policy;

            AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>> result = await request.ExecuteRequestAsync();

            Assert.Null(result);
            Assert.Equal(1, serviceRequestFuncCallCount);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task BatchRequestSetClientRequestIdOnRetries()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(0);
            const int maxRetries = 5;

            var request = new BatchRequest<
                JobScheduleListOptions,
                AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>>>(null, CancellationToken.None);

            List<Guid> generatedGuidList = new List<Guid>();
            request.ClientRequestIdProvider = new ClientRequestIdProvider(br =>
                                                                        {
                                                                            Guid generatedGuid = Guid.NewGuid();
                                                                            generatedGuidList.Add(generatedGuid);

                                                                            return generatedGuid;
                                                                        });
            request.ServiceRequestFunc = (token) =>
            {
                throw new TimeoutException();
            };

            IRetryPolicy policy = new ExponentialRetry(deltaBackoff, maxRetries);
            request.RetryPolicy = policy;

            TimeoutException e = await Assert.ThrowsAsync<TimeoutException>(async () => { await request.ExecuteRequestAsync(); });

            Assert.Equal(maxRetries + 1, request.OperationContext.RequestResults.Count);

            for (int i = 0; i < generatedGuidList.Count; i++)
            {
                Guid generatedGuid = generatedGuidList[i];
                Assert.Equal(generatedGuid, request.OperationContext.RequestResults[i].RequestInformation.ClientRequestId);
            }
        }

        #endregion

        #region End to end

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ListJobSchedulesWithRetry()
        {
            TimeSpan deltaBackoff = TimeSpan.FromSeconds(1);
            const int maxRetries = 3;

            int callCount = 0;

            using (var client = BatchClient.Open(this.credentials))
            {
                client.JobScheduleOperations.CustomBehaviors.Add(new RequestInterceptor(
                    (req) =>
                    {
                        //I wish I didn't have to cast here
                        var stronglyTypedRequest = (BatchRequest<
                            JobScheduleListOptions,
                            AzureOperationResponse<IPage<ProxyModels.CloudJobSchedule>, JobScheduleListHeaders>>)req;

                        stronglyTypedRequest.ServiceRequestFunc = (token) =>
                                                                  {
                                                                      ++callCount;
                                                                      throw new TimeoutException();
                                                                  };
                    }));

                client.JobScheduleOperations.CustomBehaviors.Add(new RetryPolicyProvider(new LinearRetry(deltaBackoff, maxRetries)));

                await Assert.ThrowsAsync<TimeoutException>(async () =>
                                                     {
                                                         IPagedEnumerable<CloudJobSchedule> schedules = client.JobScheduleOperations.ListJobSchedules();
                                                         await schedules.GetPagedEnumerator().MoveNextAsync();
                                                     });

                Assert.Equal(maxRetries + 1, callCount);
            }
        }

        #endregion

        private async Task AssertPolicyDoesNotRetryOnValidationExceptions(IRetryPolicy policy)
        {
            int callCount = 0;

            using (BatchClient client = BatchClient.Open(this.credentials))
            {
                client.CustomBehaviors.Add(new RequestInterceptor(
                    (req) =>
                    {
                        var stronglyTypedRequest = (Microsoft.Azure.Batch.Protocol.BatchRequests.JobAddBatchRequest)req;

                        stronglyTypedRequest.ServiceRequestFunc = (token) =>
                        {
                            ++callCount;
                            throw new Microsoft.Rest.ValidationException();
                        };
                    }));

                client.CustomBehaviors.Add(new RetryPolicyProvider(policy));

                CloudJob job = client.JobOperations.CreateJob();
                await Assert.ThrowsAsync<Microsoft.Rest.ValidationException>(async () => await job.CommitAsync());

                Assert.Equal(1, callCount);
            }
        }

    }
}