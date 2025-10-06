// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using TestUtilities;

    public class BatchRequestUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;
        private const double TimeTolerance = 5; //5 seconds

        public BatchRequestUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        #region Cancellation Tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchClientDefaultHttpClientTimeoutInfinite()
        {
            BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();

            Protocol.BatchServiceClient restClient = (Protocol.BatchServiceClient)typeof(ProtocolLayer).GetField("_client", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(batchClient.ProtocolLayer);
            Assert.Equal(Timeout.InfiniteTimeSpan, restClient.HttpClient.Timeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestTimeoutCancellation()
        {
            await this.BatchRequestCancellationViaInterceptorTestAsync(null, TimeSpan.FromSeconds(1));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestUserCancellation()
        {
            await this.BatchRequestCancellationViaInterceptorTestAsync(TimeSpan.FromSeconds(1), null);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestUserTokenAndTimeoutSetUserTokenWins()
        {
            await this.BatchRequestCancellationViaInterceptorTestAsync(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(10));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestUserTokenAndTimeoutSetTimeoutWins()
        {
            await this.BatchRequestCancellationViaInterceptorTestAsync(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(1));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestTimeoutCancellationWithRetries()
        {
            const int maxRetries = 3;
            TimeSpan retryInterval = TimeSpan.FromSeconds(.1);

            LinearRetry retryPolicy = new LinearRetry(retryInterval, maxRetries);
            await this.BatchRequestCancellationViaInterceptorTestAsync(null, TimeSpan.FromSeconds(0), retryPolicy, maxRetries);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestUserTokenCancellationWithRetries()
        {
            const int maxRetries = 3;
            TimeSpan retryInterval = TimeSpan.FromSeconds(.1);

            LinearRetry retryPolicy = new LinearRetry(retryInterval, maxRetries);
            await this.BatchRequestCancellationViaInterceptorTestAsync(TimeSpan.FromSeconds(1), null, retryPolicy, maxRetries);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestDefaultBatchRequestTimeoutSet()
        {
            TimeSpan requestTimeout = TimeSpan.MinValue;
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(req =>
                {
                    requestTimeout = req.Timeout;
                    var castRequest = (Protocol.BatchRequest<
                        Protocol.Models.JobGetOptions,
                        AzureOperationResponse<Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>>)req;
                    castRequest.ServiceRequestFunc = (token) =>
                        {
                            return Task.FromResult(new AzureOperationResponse<Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>() { Body = new Protocol.Models.CloudJob() });
                        };
                });
            await client.JobOperations.GetJobAsync("foo", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal(Constants.DefaultSingleRestRequestClientTimeout, requestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestRetryPolicyNotCalledOnCustomTokenTimeout()
        {
            DummyRetryPolicy dummyPolicy = new DummyRetryPolicy();
            await this.BatchRequestCancellationViaInterceptorTestAsync(TimeSpan.FromSeconds(1), null, dummyPolicy, 0);

            Assert.Equal(0, dummyPolicy.RetryCallCount);
        }

        #endregion

        #region Cancellation via Parameters

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestCancellationViaParameter()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            List<IInheritedBehaviors> objectsToExamineForMethods = new List<IInheritedBehaviors>()
                    {
                        client.JobOperations,
                        client.JobScheduleOperations,
                        client.CertificateOperations,
                        client.PoolOperations,
                    };

            foreach (IInheritedBehaviors o in objectsToExamineForMethods)
            {
                List<MethodInfo> methodsToCall = DiscoverCancellableMethods(o.GetType());
                foreach (MethodInfo method in methodsToCall)
                {
                    foreach (IInheritedBehaviors behaviorContainer in objectsToExamineForMethods)
                    {
                        behaviorContainer.CustomBehaviors.Clear();
                        behaviorContainer.CustomBehaviors.Add(CreateRequestInterceptorForCancellationMonitoring());
                    }

                    await this.BatchRequestCancellationViaParameterTestAsync(method, o, TimeSpan.FromSeconds(0));
                }
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.ShortDuration)]
        public async Task TestCancellationViaParameterForLists()
        {
            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            List<IInheritedBehaviors> objectsToExamineForMethods = new List<IInheritedBehaviors>()
                    {
                        client.JobOperations,
                        client.JobScheduleOperations,
                        client.CertificateOperations,
                        client.PoolOperations,
                    };

            foreach (IInheritedBehaviors behaviorContainer in objectsToExamineForMethods)
            {
                List<MethodInfo> listMethods = DiscoverListMethods(behaviorContainer.GetType());

                //Call the list methods to build the enumerable
                foreach (MethodInfo listMethod in listMethods)
                {
                    behaviorContainer.CustomBehaviors.Clear();
                    behaviorContainer.CustomBehaviors.Add(CreateRequestInterceptorForCancellationMonitoring());

                    object pagedEnumerable = ReflectionHelpers.InvokeMethodWithDefaultArguments(listMethod, behaviorContainer);

                    //PagedEnumerable will have a method called: "GetPagedEnumerator"
                    MethodInfo getEnumeratorMethod = pagedEnumerable.GetType().GetMethod("GetPagedEnumerator");
                    object pagedEnumerator = getEnumeratorMethod.Invoke(pagedEnumerable, null);

                    //pagedEnumerator has the method to call "MoveNextAsync"
                    MethodInfo moveNextAsyncMethod = pagedEnumerator.GetType().GetMethod("MoveNextAsync");

                    await this.BatchRequestCancellationViaParameterTestAsync(moveNextAsyncMethod, pagedEnumerator, TimeSpan.FromSeconds(0));
                }
            }
        }

        #endregion

        #region Exception related tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchExceptionCreatedFromBatchErrorWithNoBody()
        {
            Protocol.Models.BatchErrorException batchErrorException = new Protocol.Models.BatchErrorException()
                {
                    Body = null, //Body is null
                    Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Accepted), string.Empty)
                };
            BatchException batchException = new BatchException(batchErrorException);

            Assert.Null(batchException.RequestInformation.BatchError);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchExceptionCreatedWithRetryAfterDuration()
        {
            Protocol.Models.BatchErrorException batchErrorException = new Protocol.Models.BatchErrorException()
            {
                Body = null, //Body is null
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Accepted), string.Empty)
            };
            batchErrorException.Response.Headers.Add(InternalConstants.RetryAfterHeader, new List<string> { "10" });
            BatchException batchException = new BatchException(batchErrorException);

            Assert.Equal(TimeSpan.FromSeconds(10), batchException.RequestInformation.RetryAfter);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestBatchExceptionCreatedWithRetryAfterDateTime()
        {
            DateTime retryAfter = DateTime.UtcNow.Add(TimeSpan.FromSeconds(10));
            string retryAfterString = retryAfter.ToString("r");
            Protocol.Models.BatchErrorException batchErrorException = new Protocol.Models.BatchErrorException()
            {
                Body = null, //Body is null
                Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Accepted), string.Empty)
            };
            batchErrorException.Response.Headers.Add(InternalConstants.RetryAfterHeader, new List<string> { retryAfterString });
            BatchException batchException = new BatchException(batchErrorException);

            this.testOutputHelper.WriteLine($"RetryAfter: {batchException.RequestInformation.RetryAfter}");
            // Give some wiggle room in case tests are running slow
            Assert.True(batchException.RequestInformation.RetryAfter <= TimeSpan.FromSeconds(10));
        }

        #endregion

        #region BatchRequest immutability tests

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task TestBatchRequestCannotBeModifiedAfterExecutionStarted()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(req =>
                {
                    PoolAddBatchRequest addPoolRequest = req as PoolAddBatchRequest;
                    addPoolRequest.ServiceRequestFunc = token =>
                        {
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.CancellationToken = CancellationToken.None);
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.Options = null);
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.RetryPolicy = null);
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.ServiceRequestFunc = null);
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.Timeout = TimeSpan.FromSeconds(0));
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.ClientRequestIdProvider = null);
                            Assert.Throws<InvalidOperationException>(() => addPoolRequest.Parameters = null);

                            return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.PoolAddHeaders>());
                        };
                });

            CloudPool pool = batchClient.PoolOperations.CreatePool("dummy", "small", default(VirtualMachineConfiguration), targetDedicatedComputeNodes: 0);
            await pool.CommitAsync(additionalBehaviors: new[] { interceptor });
        }

        #endregion

        #region Private helpers

        private class DummyRetryPolicy : IRetryPolicy
        {
            public int RetryCallCount { get; private set; }

            public Task<RetryDecision> ShouldRetryAsync(Exception exception, OperationContext operationContext)
            {
                this.RetryCallCount++;

                return Task.FromResult(RetryDecision.RetryWithDelay(TimeSpan.FromSeconds(0)));
            }
        }

        private async Task BatchRequestCancellationViaInterceptorTestAsync(
            TimeSpan? clientRequestTimeoutViaCustomToken,
            TimeSpan? clientRequestTimeoutViaTimeout,
            IRetryPolicy retryPolicy = null,
            int? expectedMaxRetries = null)
        {
            TimeSpan timeoutViaCancellationTokenValue = clientRequestTimeoutViaCustomToken ?? TimeSpan.Zero;
            TimeSpan? cancellationDuration = null;

            DateTime startTime = DateTime.UtcNow;
            bool expectedCustomTokenTimeoutToHitFirst = false;

            int observedRequestCount = 0;
            CancellationToken customToken = CancellationToken.None;
            using CancellationTokenSource source = new CancellationTokenSource(timeoutViaCancellationTokenValue);
            if (clientRequestTimeoutViaCustomToken.HasValue)
            {
                customToken = source.Token;
            }

            //Determine which timeout should hit first and create the requestCancellationOptions object
            if (clientRequestTimeoutViaCustomToken.HasValue && clientRequestTimeoutViaTimeout.HasValue)
            {
                expectedCustomTokenTimeoutToHitFirst = clientRequestTimeoutViaCustomToken < clientRequestTimeoutViaTimeout;
            }
            else if (clientRequestTimeoutViaCustomToken.HasValue)
            {
                expectedCustomTokenTimeoutToHitFirst = true;
            }
            else if (clientRequestTimeoutViaTimeout.HasValue)
            {
                expectedCustomTokenTimeoutToHitFirst = false;
            }
            else
            {
                Assert.True(false, "Both clientRequestTimeoutViaCustomToken and clientRequestTimeoutViaTimeout cannot be null");
            }

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                //Add a retry policy to the client if required
                if (retryPolicy != null)
                {
                    client.CustomBehaviors.Add(new RetryPolicyProvider(retryPolicy));
                }

                //
                // Set the interceptor to catch the request before it really goes to the Batch service and hook the cancellation token to find when it times out
                //
                Protocol.RequestInterceptor requestInterceptor = new Protocol.RequestInterceptor(req =>
                {
                    if (clientRequestTimeoutViaTimeout.HasValue)
                    {
                        req.Timeout = clientRequestTimeoutViaTimeout.Value;
                    }

                    req.CancellationToken = customToken;

                    var castRequest = (Protocol.BatchRequests.JobGetBatchRequest)req;
                    castRequest.ServiceRequestFunc = async (token) =>
                    {
                        TaskCompletionSource<TimeSpan> taskCompletionSource = new TaskCompletionSource<TimeSpan>();
                        observedRequestCount++;
                        if (!expectedCustomTokenTimeoutToHitFirst)
                        {
                            startTime = DateTime.UtcNow;
                        }

                        token.Register(() =>
                        {
                            DateTime endTime = DateTime.UtcNow;
                            TimeSpan duration = endTime.Subtract(startTime);
                            taskCompletionSource.SetResult(duration);
                        });

                        cancellationDuration = await taskCompletionSource.Task;

                        token.ThrowIfCancellationRequested(); //Force an exception

                            return new AzureOperationResponse<Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>() { Body = new Protocol.Models.CloudJob() };
                    };
                });

                await Assert.ThrowsAsync<OperationCanceledException>(async () => await client.JobOperations.GetJobAsync("dummy", additionalBehaviors: new List<BatchClientBehavior> { requestInterceptor }));
            }
            this.testOutputHelper.WriteLine("There were {0} requests executed", observedRequestCount);
            this.testOutputHelper.WriteLine("Took {0} to cancel task", cancellationDuration);

            Assert.NotNull(cancellationDuration);
            if (expectedCustomTokenTimeoutToHitFirst)
            {
                this.testOutputHelper.WriteLine("Expected custom token timeout to hit first");
                Assert.True(Math.Abs(clientRequestTimeoutViaCustomToken.Value.TotalSeconds - cancellationDuration.Value.TotalSeconds) < TimeTolerance,
                    string.Format("Expected timeout: {0}, Observed timeout: {1}", clientRequestTimeoutViaCustomToken, cancellationDuration));
            }
            else
            {
                this.testOutputHelper.WriteLine("Expected client side timeout to hit first");
                Assert.True(Math.Abs(clientRequestTimeoutViaTimeout.Value.TotalSeconds - cancellationDuration.Value.TotalSeconds) < TimeTolerance,
                    string.Format("Expected timeout: {0}, Observed timeout: {1}", clientRequestTimeoutViaTimeout, cancellationDuration));
            }

            //Confirm the right number of retries were reached (if applicable)
            if (retryPolicy != null)
            {
                if (expectedCustomTokenTimeoutToHitFirst)
                {
                    //This terminates the retry so there should just be 1 request (0 retries)
                    Assert.Equal(0, observedRequestCount - 1);
                }
                else
                {
                    Assert.Equal(expectedMaxRetries, observedRequestCount - 1);
                }
            }
        }


        private static Protocol.RequestInterceptor CreateRequestInterceptorForCancellationMonitoring()
        {
            DateTime startTime = DateTime.UtcNow;
            int observedRequestCount = 0;

            Protocol.RequestInterceptor requestInterceptor = new Protocol.RequestInterceptor(req =>
            {
                TaskCompletionSource<TimeSpan> source = new TaskCompletionSource<TimeSpan>();

                req.CancellationToken.Register(() =>
                {
                    DateTime endTime = DateTime.UtcNow;
                    TimeSpan duration = endTime.Subtract(startTime);

                    source.SetResult(duration);
                });
                Interlocked.Increment(ref observedRequestCount);

                TimeSpan cancellationDuration = source.Task.Result;

                //Force an exception -- so the real request is never called
                throw new BatchUnitTestCancellationException(observedRequestCount, cancellationDuration);
            });

            return requestInterceptor;
        }

        private class BatchUnitTestCancellationException : Exception
        {
            public int ObservedRequestCount { get; private set; }

            public TimeSpan CancellationDuration { get; private set; }

            public BatchUnitTestCancellationException(int observedRequestCount, TimeSpan cancellationDuration)
            {
                this.ObservedRequestCount = observedRequestCount;
                this.CancellationDuration = cancellationDuration;
            }
        }

        private async Task BatchRequestCancellationViaParameterTestAsync(MethodInfo method, object o, TimeSpan? clientRequestTimeoutViaCustomToken)
        {
            Assert.NotNull(clientRequestTimeoutViaCustomToken);

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(clientRequestTimeoutViaCustomToken.Value);
            this.testOutputHelper.WriteLine("Invoking {0}", method.Name);

            //Invoke the method with default parameters and a cancellationToken
            BatchUnitTestCancellationException e = await Assert.ThrowsAsync<BatchUnitTestCancellationException>(
                        async () => await InvokeCancellationTokenMethodAsync(method, o, cancellationTokenSource.Token));

            this.testOutputHelper.WriteLine("There were {0} requests executed", e.ObservedRequestCount);
            this.testOutputHelper.WriteLine("Took {0} to cancel task", e.CancellationDuration);

            Assert.NotNull(e.CancellationDuration);

            Assert.True(Math.Abs(clientRequestTimeoutViaCustomToken.Value.TotalSeconds - e.CancellationDuration.TotalSeconds) < TimeTolerance,
                string.Format("Expected timeout: {0}, Observed timeout: {1}", clientRequestTimeoutViaCustomToken, e.CancellationDuration));
        }

        /// <summary>
        /// On the given type, finds and returns all methods which take a CancellationToken as a parameter
        /// </summary>
        private static List<MethodInfo> DiscoverCancellableMethods(Type typeToExamine)
        {
            List<MethodInfo> result = new List<MethodInfo>();

            IEnumerable<MethodInfo> methods = typeToExamine.GetMethods();
            foreach (MethodInfo method in methods)
            {
                IEnumerable<ParameterInfo> parameters = method.GetParameters();
                bool hasCancellationTokenParameter = false;
                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.ParameterType == typeof(CancellationToken))
                    {
                        hasCancellationTokenParameter = true;
                    }
                }

                if (hasCancellationTokenParameter)
                {
                    result.Add(method);
                }
            }

            return result;
        }

        /// <summary>
        /// On the given type, finds and returns all methods which have a return type of IPagedEnumerable
        /// </summary>
        private static List<MethodInfo> DiscoverListMethods(Type typeToExamine)
        {
            List<MethodInfo> result = new List<MethodInfo>();

            IEnumerable<MethodInfo> methods = typeToExamine.GetMethods();
            foreach (MethodInfo method in methods)
            {
                if (method.ReturnType.GetTypeInfo().IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof (IPagedEnumerable<>))
                {
                    result.Add(method);
                }
            }

            return result;
        }

        private static async Task InvokeCancellationTokenMethodAsync(MethodInfo method, object objectInstance, CancellationToken cancellationToken)
        {
            object objectCreationFunc(ParameterInfo parameter)
            {
                object result;

                if (parameter.ParameterType == typeof(CancellationToken))
                {
                    result = cancellationToken;
                }
                else if (parameter.ParameterType.GetTypeInfo().IsValueType)
                {
                    result = Activator.CreateInstance(parameter.ParameterType);
                }
                //The below list is a list of types which are null-checked in some methods and so must not be null
                //This is a bit of a hack but it's the easiest way currecntly...
                else if (parameter.ParameterType == typeof(CloudTask))
                {
                    result = new CloudTask("bar", "baz");
                }
                else if (parameter.Name == "computeNodeIds")
                {
                    result = new List<string>();
                }
                else if (parameter.Name == "computeNodes")
                {
                    result = new List<ComputeNode>();
                }
                else if (parameter.Name == "rdpFileNameToCreate")
                {
                    result = "temp";
                }
                //Default to null if there is no special handling required
                else
                {
                    result = null;
                }

                return result;
            }

            await (Task)ReflectionHelpers.InvokeMethodWithDefaultArguments(method, objectInstance, objectCreationFunc);
        }

        #endregion
    }
}
