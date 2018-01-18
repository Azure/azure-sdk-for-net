// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.Test.Fakes;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Azure.Tests
{
    static class ExceptionsTestsSuite
    {
        static internal IEnumerable<HttpResponseMessage> MockLROAsyncOperationFailedWith200()
        {
            return LROOperationTestResponses.MockLROAsyncOperationFailedWith200();
        }

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithTwoTries()
        {
            return LROOperationTestResponses.MockCreateOrUpdateWithTwoTries();
        }

        static internal IEnumerable<HttpResponseMessage> MockLROLocationHeaderFailedWith200()
        {
            return LROOperationTestResponses.MockLROLocationHeaderFailedWith200();
        }

        static internal IEnumerable<HttpResponseMessage> MockDeleteOperaionWithNoRetryableErrorInResponse()
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

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithImmediateServerError()
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

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithNoErrorBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;
        }

        static internal IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderError()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");

            yield return response1;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTests
    {
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROAsynOperationFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockLROAsyncOperationFailedWith200());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var ex = Assert.Throws<CloudException>(() => fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            Assert.Contains("DeploymentDocument", ex.Message);
        }
        
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestLROWithLocationHeaderFailureWith200()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockLROLocationHeaderFailedWith200());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var ex = Assert.Throws<CloudLroException>(() => fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
            // If the message changes in the response, this assert will also have to be updated.
            Assert.Contains("DeploymentDocument", ex.Message);
        }
        
        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestDeleteOperationWithNonRetryableErrorInResponse()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockDeleteOperaionWithNoRetryableErrorInResponse());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            var error = Assert.Throws<CloudException>(() => fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
            Assert.Equal("Long running operation failed with status 'BadRequest'.", error.Message);
            Assert.Equal(2, handler.Requests.Count);
        }

        /// <summary>
        /// Test
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateErrorHandling()
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockCreateOrUpdateWithImmediateServerError());
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
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockCreateOrUpdateWithNoErrorBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudLroException ex)
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
            var handler = new PlaybackTestHandler(ExceptionsTestsSuite.MockDeleteWithLocationHeaderError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            try
            {
                fakeClient.RedisOperations.Delete("rg", "redis", "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudLroException ex)
            {
                Assert.Null(ex.ErrorBody);
            }
        }
    }
}
