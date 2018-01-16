﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    static class ExceptionsTestsSuite
    {
        static internal IEnumerable<HttpResponseMessage> MockLROAsyncOperationFailedWith200()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                    {
                    ""location"": ""East US"",
                      ""etag"": ""9d8d7ed9-7422-46be-82b3-94c5345f6099"",
                      ""tags"": {},
                      ""properties"": {
                            ""clusterVersion"": ""0.0.1000.0"",
                            ""osType"": ""Linux"",                            
                            ""provisioningState"": ""InProgress"",
                            ""clusterState"": ""Accepted"",
                            ""createdDate"": ""2017-07-25T21:48:17.427"",
                            ""quotaInfo"": 
                                {
                                    ""coresUsed"": ""200""
                                },
                            }
                    }
            ")
            };
            response1.Headers.Add("Azure-AsyncOperation", "https://management.azure.com:090/subscriptions/434c10bb-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                  ""status"": ""Failed"",
                  ""error"":
                    {
                                ""code"": ""InvalidDocumentErrorCode"",
                                ""message"": ""DeploymentDocument 'HiveConfigurationValidator' failed the validation.Error: 'Cannot connect to Hive metastore using user provided connection string'""
                    }
                }
            ")
            };

            yield return response2;

        }

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithTwoTries()
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

        static internal IEnumerable<HttpResponseMessage> MockLROLocationHeaderFailedWith200()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""location"": ""East US"",
                      ""etag"": ""9d8d7ed9-7422-46be-82b3-94c5345f6099"",
                      ""tags"": {},
                      ""properties"": {
                            ""clusterVersion"": ""0.0.1000.0"",
                            ""osType"": ""Linux"",                            
                            ""provisioningState"": ""InProgress"",
                            ""clusterState"": ""Accepted"",
                            ""createdDate"": ""2017-07-25T21:48:17.427"",
                            ""quotaInfo"": 
                                {
                                    ""coresUsed"": ""200""
                                },
                            }
                    }
            ")
            };
            response1.Headers.Add("Location", "https://management.azure.com:090/subscriptions/947c-43bc-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                  ""status"": ""Failed"",
                  ""error"":
                    {
                                ""code"": ""InvalidDocumentErrorCode"",
                                ""message"": ""DeploymentDocument 'HiveConfigurationValidator' failed the validation.Error: 'Cannot connect to Hive metastore using user provided connection string'""
                    }
                }
            ")
            };

            yield return response2;

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
            var ex = Assert.Throws<CloudLroException>(() => fakeClient.RedisOperations.CreateOrUpdate("rg", "redis", new RedisCreateOrUpdateParameters(), "1234"));
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
            var error = Assert.Throws<CloudLroException>(() => fakeClient.RedisOperations.Delete("rg", "redis", "1234"));
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
            catch (CloudLroException ex)
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
