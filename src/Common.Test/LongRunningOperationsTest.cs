// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;
using Microsoft.Azure.Common.Test.Fakes;
using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Xunit;

namespace Microsoft.Azure.Common.Test
{
    public class LongRunningOperationsTest
    {
        [Fact]
        public void TestCreateOrUpdate()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(MockCreateOrUpdateWithTwoTries());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
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
        public void TestCreateOrUpdateNoAsyncHeader()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(MockCreateOrUpdateWithNoAsyncHeader());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
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
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(MockCreateOrUpdateWithFailedStatus());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal("Long running operation failed.", ex.Message);
                Assert.Contains("Failed", ex.Response.Content.ReadAsStringAsync().Result);
            }

        }

        [Fact]
        public void TestCreateOrUpdateErrorHandling()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(MockCreateOrUpdateWithImmediateServerError());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
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
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var handler = new LROTestHandler(MockCreateOrUpdateWithNoErrorBody());
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            try
            {
                fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234");
                Assert.False(true, "Expected exception was not thrown.");
            }
            catch (CloudException ex)
            {
                Assert.Equal("", ex.Message);
                Assert.Equal(HttpStatusCode.InternalServerError, ex.Response.StatusCode);
            }
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
    }
}
