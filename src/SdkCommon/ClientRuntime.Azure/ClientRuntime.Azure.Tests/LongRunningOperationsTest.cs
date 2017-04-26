// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.ClientRuntime.Azure.Test.Fakes;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Xunit;
using Microsoft.Azure;
using Microsoft.Rest.Azure;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    public class LongRunningOperationsTest
    {
        [Fact]
        public void TestCreateOrUpdateWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithTwoTries());
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

        [Fact]
        public void TestCreateOrUpdateWithoutHeaderInResponses()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithoutHeaderInResponses());
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

        [Fact]
        public void TestAsyncOperationWithNoPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockAsyncOperaionWithNoBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => 
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        [Fact]
        public void TestAsyncOperationWithEmptyPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockAsyncOperaionWithEmptyBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("The response from long running operation does not contain a body.", error.Message);
        }

        [Fact]
        public void TestAsyncOperationWithBadPayload()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockAsyncOperaionWithBadPayload());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        [Fact]
        public void TestAsyncOperationWithMissingProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockAsyncOperaionWithMissingProvisioningState());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        [Fact]
        public void TestAsyncOperationWithNonSuccessStatusAndInvalidResponseContent()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockAsyncOperaionWithNonSuccessStatusAndInvalidResponseContent());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() =>
                fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Null(error.Body);
        }

        [Fact]
        public void TestPutOperationWithoutProvisioningState()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPutOperaionWithoutProvisioningStateInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
        }

        [Fact]
        public void TestPutOperationWithNonResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPutOperaionWitNonResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            Sku sku = fakeClient.RedisOperations.CreateOrUpdateNonResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("foo", sku.Name);
            Assert.Equal(3, handler.Requests.Count);
        }

        [Fact]
        public void TestPutOperationWithSubResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPutOperaionWitSubResource());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.CreateOrUpdateSubResource("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal("100", resource.Id);
            Assert.Equal(3, handler.Requests.Count);
        }

        [Fact]
        public void TestPutOperationWithImmediateSuccess()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPutOperaionWithImmediateSuccess());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        [Fact]
        public void TestPostOperationWithImmediateSuccessAndOkStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPostOperaionWithImmediateSuccessOKStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var sku = fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
            Assert.Equal("Family", sku.Family);
        }

        [Fact]
        public void TestPostOperationWithImmediateSuccessAndNoContentStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockOperaionWithImmediateSuccessNoContentStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(1, handler.Requests.Count);
        }

        [Fact]
        public void TestPostOperationWithBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPostOperaionWithBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Post("rg", "redis", "1234");
            Assert.Equal(2, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status", handler.Requests[1].RequestUri.ToString());
        }

        [Fact]
        public void TestDeleteOperationWithNonRetryableErrorInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteOperaionWithNoRetryableErrorInResponse());
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
            var handler = new PlaybackTestHandler(MockDeleteOperaionWithoutHeaderInResponse());
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
            var handler = new PlaybackTestHandler(MockDeleteOperaionWithoutLocationHeaderInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            Assert.Equal(3, handler.Requests.Count);
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
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithLocationHeaderAnd202());
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

        [Fact]
        public void TestCreateOrUpdateWithAsyncHeaderWith202()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithAsyncHeaderAnd202());
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

        [Fact]
        public void TestCreateOrUpdateWithWith202AndResource()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithWith202AndResource());
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

        [Fact]
        public void TestPostWithResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockPostWithResourceSku());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var resource = fakeClient.RedisOperations.Post("rg", "redis", "1234");

            Assert.Equal(2, handler.Requests.Count);
            Assert.Equal(HttpMethod.Post, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal("Family", resource.Family);
        }

        [Fact]
        public void TestCreateOrUpdateNoAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithNoAsyncHeader());
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

        [Fact]
        public void TestCreateOrUpdateFailedStatus()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithFailedStatus());
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

        [Fact]
        public void TestCreateOrUpdateErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithImmediateServerError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch(CloudException ex)
            {
                Assert.Equal("The provided database ‘foo’ has an invalid username.", ex.Message);
            }
        }

        [Fact]
        public void TestCreateOrUpdateNoErrorBody()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithNoErrorBody());
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

        [Fact]
        public void TestCreateOrUpdateWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockCreateOrUpdateWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            var now = DateTime.Now;
            fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");

            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void TestDeleteWithAsyncHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteWithAsyncHeaderTwoTries());
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

        [Fact]
        public void TestDeleteWithLocationHeader()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteWithLocationHeaderTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");

            Assert.Equal(HttpMethod.Delete, handler.Requests[0].Method);
            Assert.Equal("https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis",
                handler.Requests[0].RequestUri.ToString());
            Assert.Equal(HttpMethod.Get, handler.Requests[1].Method);
            Assert.Equal("http://custom/location/status",
                handler.Requests[1].RequestUri.ToString());
            Assert.Equal(2, handler.Requests.Count);
        }

        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteWithLocationHeaderError());
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

        [Fact]
        public void TestDeleteWithLocationHeaderErrorHandlingSecondTime()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteWithLocationHeaderErrorInSecondCall());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            var ex = Assert.Throws<CloudException>(()=>fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'InternalServerError'.", ex.Message);
        }

        [Fact]
        public void TestDeleteWithRetryAfter()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(MockDeleteWithRetryAfterTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            var now = DateTime.Now;
            fakeClient.RedisOperations.Delete("rg", "redis", "1234");
            
            Assert.True(DateTime.Now - now >= TimeSpan.FromSeconds(2));
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithoutHeaderInResponses()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""InProgress"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response4;
        }

        private IEnumerable<HttpResponseMessage> MockAsyncOperaionWithNoBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockAsyncOperaionWithEmptyBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{}")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockAsyncOperaionWithBadPayload()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response2.Headers.Add("Location", "http://custom/status2");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { \"provisioningState\" : \"Succeeded\" }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockAsyncOperaionWithMissingProvisioningState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response2.Headers.Add("Location", "http://custom/status2");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockAsyncOperaionWithNonSuccessStatusAndInvalidResponseContent()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("<")
            };
            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockPutOperaionWithoutProvisioningStateInResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };
            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockPutOperaionWitNonResource()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""name"": ""foo""
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockPutOperaionWitSubResource()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("{ \"properties\": { \"provisioningState\": \"InProgress\"}, \"id\": \"100\", \"name\": \"foo\" }")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""100""
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockPutOperaionWithImmediateSuccess()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { \"provisioningState\": \"Succeeded\"}, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockOperaionWithImmediateSuccessOKStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockPostOperaionWithImmediateSuccessOKStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"Capacity\":1,\"Family\":\"Family\"}")
            };

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockOperaionWithImmediateSuccessNoContentStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockPostOperaionWithBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { \"provisioningState\": \"Succeeded\"}, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteOperaionWithNoRetryableErrorInResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent("")
            };
            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteOperaionWithoutHeaderInResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""InProgress"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };
            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteOperaionWithoutLocationHeaderInResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "http://custom/status");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent("")
            };
            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithLocationHeaderAnd202()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response2.Headers.Add("Location", "http://custom/locationstatus");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response3.Headers.Add("Location", "https://management.azure.com/subscriptions/1234/resourceGroups/rg/providers/Microsoft.Cache/Redis/redis");

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response4;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithAsyncHeaderAnd202()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithWith202AndResource()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockPostWithResourceSku()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("null")
            };
            response1.Headers.Add("Location", "http://custom/status");

            yield return response1;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""Capacity"": ""1"",
                    ""Family"": ""Family""
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithNoAsyncHeader()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Anything other than Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithFailedStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Anything other than Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Failed"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithImmediateServerError()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"
                {
                    ""error"": {
                        ""code"": ""BadArgument"",
                        ""message"": ""The provided database ‘foo’ has an invalid username."",
                        ""target"": ""query"",
                        ""details"": [
                        {
                            ""code"": ""301"",
                            ""target"": ""$search"",
                            ""message"": ""$search query option not supported""
                        }
                        ]
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithNoErrorBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithRetryAfterTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""InProgress"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");
            response1.Headers.Add("Retry-After", "2");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Succeeded"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };

            yield return response3;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteWithAsyncHeaderTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."" 
                    }
                }")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderError()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");

            yield return response1;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderErrorInSecondCall()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"")
            };

            yield return response2;
        }

        private IEnumerable<HttpResponseMessage> MockDeleteWithRetryAfterTwoTries()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");
            response1.Headers.Add("Retry-After", "3");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"")
            };

            yield return response2;
        }
    }
}
