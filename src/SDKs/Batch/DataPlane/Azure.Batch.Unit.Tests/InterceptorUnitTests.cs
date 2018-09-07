// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Azure.Batch.Protocol.Models;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using CloudPool = Microsoft.Azure.Batch.Protocol.Models.CloudPool;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class InterceptorUnitTests
    {
        private ITestOutputHelper testOutputHelper;
        private const int DefaultServerTimeoutInSeconds = 30;
        private static readonly TimeSpan DefaultClientTimeout = TimeSpan.FromSeconds(60);

        public InterceptorUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        #region Batch Request Timeout interceptor tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestSetBatchRequestServerTimeout()
        {
            await this.TestSetBatchRequestServerTimeoutHelperAsync(null, null);
            await this.TestSetBatchRequestServerTimeoutHelperAsync(null, 45);
            await this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.FromMilliseconds(14020), null);
            await this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.FromMinutes(1), 22);
            await this.TestSetBatchRequestServerTimeoutHelperAsync(null, -15);

            await this.TestSetBatchRequestServerTimeoutHelperAsync(null, int.MaxValue);
            await this.TestSetBatchRequestServerTimeoutHelperAsync(null, int.MinValue);

            await this.TestSetBatchRequestServerTimeoutHelperAsync(Timeout.InfiniteTimeSpan, null);

            //CancellationTokenSource doesn't support TimeSpans outside the range of IntMax, or any negative TimeSpans.
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.MaxValue, null));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.FromSeconds(-44), null));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.FromMinutes(-120), -60));
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => this.TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan.MinValue, null));
        }

        #endregion

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestRequestWhichDoesntSupportFilter()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                BatchClientBehavior behavior = new Protocol.RequestInterceptor(request =>
                    {
                        PoolGetBatchRequest poolGetRequest = request as PoolGetBatchRequest;
                        poolGetRequest.ServiceRequestFunc = t =>
                            {
                                return Task.FromResult(new AzureOperationResponse<CloudPool, PoolGetHeaders>() { Body = new CloudPool() });
                            };
                    });
                const string dummyPoolId = "dummy";
                DetailLevel detailLevel = new ODATADetailLevel(filterClause: "foo");
                ArgumentException e = await Assert.ThrowsAsync<ArgumentException>(async () => await client.PoolOperations.GetPoolAsync(dummyPoolId, detailLevel, new [] { behavior }));
                Assert.Contains("Type Microsoft.Azure.Batch.Protocol.BatchRequests.PoolGetBatchRequest does not support a filter clause.", e.Message);
                Assert.Equal("detailLevel", e.ParamName);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestRequestWhichDoesSupportSelect()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                ODATADetailLevel detailLevel = new ODATADetailLevel(selectClause: "foo");
                bool wasHit = false;
                BatchClientBehavior behavior = new Protocol.RequestInterceptor(request =>
                {
                    PoolGetBatchRequest poolGetRequest = request as PoolGetBatchRequest;

                    poolGetRequest.ServiceRequestFunc = t =>
                    {
                        Assert.Equal(detailLevel.SelectClause, poolGetRequest.Options.Select);
                        wasHit = true; //Ensure the interceptor was hit
                        return Task.FromResult(new AzureOperationResponse<CloudPool, PoolGetHeaders>() { Body = new CloudPool() });
                    };
                });
                const string dummyPoolId = "dummy";
                
                await client.PoolOperations.GetPoolAsync(dummyPoolId, detailLevel, new[] {behavior});

                Assert.True(wasHit);
            }
        } 

        #region Private helpers

        private async Task TestSetBatchRequestServerTimeoutHelperAsync(TimeSpan? clientTimeout, int? serverTimeoutInSeconds)
        {
            TimeSpan expectedClientTimeout = clientTimeout ?? DefaultClientTimeout;
            int expectedServerTimeoutInSeconds = serverTimeoutInSeconds ?? DefaultServerTimeoutInSeconds;
            TimeSpan? serverTimeout = serverTimeoutInSeconds.HasValue
                ? TimeSpan.FromSeconds(serverTimeoutInSeconds.Value)
                : TimeSpan.FromSeconds(DefaultServerTimeoutInSeconds);

            using (BatchClient batchCli = ClientUnitTestCommon.CreateDummyClient())
            {
                batchCli.CustomBehaviors.Add(new BatchRequestTimeout(serverTimeout, clientTimeout));
                batchCli.CustomBehaviors.Add(new Protocol.RequestInterceptor((req) => ConfirmTimeoutWasSetInterceptor(req, expectedClientTimeout, expectedServerTimeoutInSeconds)));

                await batchCli.PoolOperations.GetPoolAsync("Foo");
            }
        }

        private static void ConfirmTimeoutWasSetInterceptor(Protocol.IBatchRequest request, TimeSpan expectedClientTimeout, int expectedServerTimoutInSeconds)
        {
            //We know the request wil be a GetPool request
            var getPoolRequest = (Protocol.BatchRequest<
                Protocol.Models.PoolGetOptions,
                AzureOperationResponse<Protocol.Models.CloudPool, Protocol.Models.PoolGetHeaders>>)request;

            //Override the service requset function to avoid actually going to the server
            getPoolRequest.ServiceRequestFunc = (token) =>
                {
                    Assert.Equal(expectedServerTimoutInSeconds, getPoolRequest.Options.Timeout);
                    Assert.Equal(expectedClientTimeout, request.Timeout);

                    return Task.FromResult(new AzureOperationResponse<Protocol.Models.CloudPool, Protocol.Models.PoolGetHeaders> { Body = new Protocol.Models.CloudPool() });
                };
        }

        #endregion
    }
}
