// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using CR.Azure.NetCore.Tests.Redis;
    //using CR.Azure.NetCore.Tests.Redis.Models;
    using CR.Azure.NetCore.Tests.Fakes;
    using Xunit;
    using Microsoft.Rest.Azure;
    using LROResponse = CR.Azure.NetCore.Tests.LROOpertionTestResponses;
    using LROPatchResponses = CR.Azure.NetCore.Tests.LROOperationPatchTestResponses;
    using LROFailedResponses = CR.Azure.NetCore.Tests.LROOperationFailedTestResponses;
    using LROMultipleHeaders = CR.Azure.NetCore.Tests.LROOperationMultipleHeaderResponses;
    using Xunit.Abstractions;
    using CR.Azure.NetCore.Tests;
    using CR.Azure.NetCore.Tests.TestClients.RedisClient;
    using CR.Azure.NetCore.Tests.TestClients.Models;

    /// <summary>
    /// 
    /// </summary>
    public class LongRunningOperationsTest
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithoutHeaderInResponses()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithoutHeaderInResponses());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[2].RequestUri.ToString());
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[3].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithNoPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithNoBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => 
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithEmptyPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithEmptyBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithNullBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithNullBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithBadPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithBadPayload());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithMissingProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithMissingProvisioningState());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestAsyncOperationWithNonSuccessStatusAndInvalidResponseContent()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockAsyncOperaionWithNonSuccessStatusAndInvalidResponseContent());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Null(error.Body);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithoutProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWithoutProvisioningStateInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithNonResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWitNonResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            Sku sku = fakeClient.RedisOperations.CreateOrUpdateNonResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("foo", sku.Name);
            Assert.Equal(3, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithSubResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWitSubResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdateSubResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
            Assert.Equal(3, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutOperationWithImmediateSuccess()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutOperaionWithImmediateSuccess());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var sku = fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
            Assert.Equal("Family", sku.Family);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostOperationWithBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostOperaionWithBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithNonRetryableErrorInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithNoRetryableErrorInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http call returns status code OK for Azure-AsyncOperation.
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithoutHeaderInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithoutHeaderInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal("http://custom/status", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http call returns status code OK, Created or NoContent for Location.
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithoutLocationHeaderInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteOperaionWithoutLocationHeaderInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(4, handler.Requests.Count);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal("http://custom/status", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// It's assumed that the same pattern is used throughout the long running operation and
        /// the final http request return an object with successfull state.
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithLocationHeaderWith202()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithLocationHeaderAnd202());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(4, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("http://custom/locationstatus", handler.Requests[2].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[3].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[3].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithAsyncHeaderWith202()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithAsyncHeaderAnd202());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateWithWith202AndResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithWith202AndResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", 
                handler.Requests[2].RequestUri.ToString());
            Assert.Equal("Succeeded", resource.ProvisioningState);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPostWithResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPostWithResourceSku());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.Post("rg", "redis", "1234");

            Assert.Equal(3, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal("Family", resource.Family);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateNoAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithNoAsyncHeader());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateFailedStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithFailedStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal("Long running operation failed with status 'Failed'.", ex.Message);
                Assert.Contains(AzureAsyncOperation.FailedStatus, ex.Response.Content);
            }

        }


        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithAsyncHeaderTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");

            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");

            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/location/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(3, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandlingSecondTime()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderErrorInSecondCall());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            var ex = Assert.Throws<CloudException>(()=>fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'InternalServerError'.", ex.Message);
        }
        

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROWithNonStandardTerminalStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROLocHdrNonStandardTerminalStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            var foo = fakeClient.RedisOperations.PostWithHttpMessagesAsync("rg", "redis", "1234").ConfigureAwait(false).GetAwaiter().GetResult();            
            Assert.Equal<string>("OK", foo.Response.StatusCode.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPutForWebAppLRO()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPutWebAppLRO());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 2;
            var webAppResponse = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal("webapp1-35965806af0", webAppResponse.Name);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
        }

        #region Provisiong State Tests
        [Fact]
        public void TestDeleteWithEmptyStringProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location201FinalGet404WithEmptyStringProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

            Assert.Equal(4, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithEmptyProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location201FinalGet404WithEmptyProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

            Assert.Equal(4, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithNoValueProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location201FinalGet404WithNoValueProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

            Assert.Equal(4, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithNullStringProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location201FinalGet404WithNullStringProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

            Assert.Equal(4, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithLocation200NullProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location200WithNullProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            Assert.Equal(1, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithMissingProvisioningState()
        {
            string DeleteOriginalResourceRequestUrl = @"https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redist";
            string Delete201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            var handler = new PlaybackTestHandler(LROOpertionTestResponses.Location201FinalGet404WithMissingProviState());
            var fakeClient = GetClient(handler);
            fakeClient.RedisOperations.Delete("rg", "redist", "1234");

            VerifyHttpMethod("DELETE", handler, requestIndex: 0);
            VerifyRequestUrl(DeleteOriginalResourceRequestUrl, handler, 0);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 1);
            VerifyRequestUrl(Delete201_LocationHeaderUrl, handler, requestIndex: 2);

            Assert.Equal(4, handler.Requests.Count);
        }

        private static RedisManagementClient GetClient(DelegatingHandler handlerToAdd)
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var fakeClient = new RedisManagementClient(tokenCredentials, handlerToAdd);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            return fakeClient;
        }

        private static void VerifyRequestCount(string httpStrMethod, PlaybackTestHandler handler, int putCount = 0, int patchCount = 0)
        {
            if (httpStrMethod.Equals("PUT"))
                Assert.Equal(putCount, handler.Requests.Count);
            else if (httpStrMethod.Equals("PATCH"))
                Assert.Equal(patchCount, handler.Requests.Count);
        }

        private static void VerifyHttpMethod(string expectedStrMethod, PlaybackTestHandler handler, int requestIndex = 0)
        {
            HttpMethod expMethod = null;

            switch (expectedStrMethod)
            {
                case "PUT":
                    expMethod = HttpMethod.Put;
                    break;

                case "PATCH":
                    expMethod = new HttpMethod("PATCH");
                    break;

                case "POST":
                    expMethod = HttpMethod.Post;
                    break;

                case "DELETE":
                    expMethod = HttpMethod.Delete;
                    break;
            }

            Assert.Equal(expMethod, handler.Requests[requestIndex].Method);
        }

        private static void VerifyRequestUrl(string expectedUrl, PlaybackTestHandler handler, int requestIndex = 0)
        {
            Assert.Equal(expectedUrl, handler.Requests[requestIndex].RequestUri.ToString());
        }

        #endregion

    }

    /// <summary>
    /// Tests for Retry-After header
    /// </summary>
    public class LRO_RetryAfterTests
    {
        private readonly ITestOutputHelper output;

        public LRO_RetryAfterTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact(Skip="Asserts needs to be fixed")]
        public void TestCreateOrUpdateWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 2;
            var before = DateTime.Now;
            output.WriteLine("Before: {0}", before.ToString());
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            var after = DateTime.Now;
            output.WriteLine("After: {0}", after.ToString());
            output.WriteLine("After - Before {0} seconds", (after - before).Seconds.ToString());

            Assert.True(after - before >= TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 1;    // Set LRO retry time out to 1, so that Retry-After can be set during test mode
            var now = DateTime.Now;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");               

            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPatchWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockPatchWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 1;    // Set LRO retry time out to 1, so that Retry-After can be set during test mode
            var now = DateTime.Now;
            fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateWithDifferentRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithDifferentRetryAfterValues());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 1;    // Set LRO retry time out to 1, so that Retry-After can be set during test mode
            var before = DateTime.Now;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.True(DateTime.Now - before >= TimeSpan.FromSeconds(6));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestCreateWithRetryAfterDefaultMin()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateWithRetryAfterDefaultMin());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 1;    // Set LRO retry time out to 1, so that Retry-After can be set during test mode
            var before = DateTime.Now;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.True(DateTime.Now - before >= TimeSpan.FromSeconds(0));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestCreateWithRetryAfterDefaultMax()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateWithRetryAfterDefaultMax());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationRetryTimeout = 1;    // Set LRO retry time out to 1, so that Retry-After can be set during test mode
            var before = DateTime.Now;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.True(DateTime.Now - before >= TimeSpan.FromSeconds(40));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LRO_PatchTests
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPatchWithAsyncHeaderServiceCustomResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROPatchResponses.ServiceCustomResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 2;
            fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "76fc5-4d01-b462-9f01b2d77");

            Assert.Equal(new HttpMethod("PATCH"), handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/76fc5-4d01-b462-9f01b2d77/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/76fc5-4d01-b462-9f01b2d77/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }


        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPatchWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROPatchResponses.MockPatchWithAzureAsyncOperationHeader());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 2;
            fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(new HttpMethod("PATCH"), handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[2].RequestUri.ToString());
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestPatchWithLocationHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROPatchResponses.MockPatchWithLocationHeader());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 2;
            fakeClient.RedisOperations.Patch("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.Equal(new HttpMethod("PATCH"), handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("https://management.azure.com:90/subscriptions/947c-43bc-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview",
                handler.Requests[1].RequestUri.ToString());
        }
    }

    /// <summary>
    /// LOR Failed test scenrios
    /// </summary>
    public class LRO_FailedTests
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestLROAsynOperationFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROFailedResponses.MockLROAsyncOperationFailedOnlyStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var result = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.NotNull(result);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithImmediateServerError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateNoErrorBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockCreateOrUpdateWithNoErrorBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal(HttpStatusCode.InternalServerError, ex.Response.StatusCode);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockDeleteWithLocationHeaderError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            try
            {
                fakeClient.RedisOperations.Delete("rg", "redis", "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Null(ex.Body);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROWithLocationHeaderFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROLocationHeaderFailedWith200());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            Assert.Throws<CloudException>(() =>
            {
                try
                {
                    fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                }
                catch(Exception ex)
                {
                    Assert.Contains("DeploymentDocument", ex.Message);
                    throw ex;
                }
            });
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROPUTWithCanceledState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROResponse.MockLROPUTWithCanceledStateResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                var foo = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            }
            catch (Exception ex)
            {
                Assert.Contains("preempted", ex.Message);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LRO_MultipleHeaders
    {
        /// <summary>
        /// 
        /// </summary>
        //[Fact(Skip ="Disabling this scenario for now")]
        [Fact]
        public void TestPUT_WithMultipleHeaders()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROMultipleHeaders.MockLROLocationHeaderAndAsyncOperation());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 1;
            var now = DateTime.Now;
            var foo = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(12));

            Assert.Equal(4, handler.Requests.Count);
            Assert.Equal(HttpMethod.Put, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("https://management.azure.com:90/subscriptions/947c-43bc-83d3-6b3186c7305/resourceGroups/hdisdk106/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview", 
                handler.Requests[1].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[2].Method);
            Assert.Equal("http://custom/AsyncOperation", handler.Requests[2].RequestUri.ToString());

            Assert.Equal(HttpMethod.Get, handler.Requests[3].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis", handler.Requests[3].RequestUri.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestDelete_WithLocHeaderFinalGetNotFound()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROMultipleHeaders.MockLRO_DeleteSuccessWithLocationHeaderFinalGetNotFound());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var now = DateTime.Now;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(4, handler.Requests.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestDelete_WithLocHeaderFinalGetNoContent()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROMultipleHeaders.MockLRO_DeleteSuccessWithLocationHeaderFinalGetNotFound());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var now = DateTime.Now;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(4, handler.Requests.Count);
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void TestPost_AsyncLocHeadersFinalGetSuccess()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(LROMultipleHeaders.MockLRO_POST_LocAsyncHeaderFinalGetSuccess());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var result = fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(5, handler.Requests.Count);
            Assert.Equal("foo", result.Name);
        }
    }
}
