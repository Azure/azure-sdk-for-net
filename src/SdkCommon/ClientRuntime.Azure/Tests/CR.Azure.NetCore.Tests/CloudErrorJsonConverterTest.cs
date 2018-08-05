// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using CR.Azure.NetCore.Tests.Fakes;
    using CR.Azure.NetCore.Tests.TestClients.Models;
    using CR.Azure.NetCore.Tests.TestClients.RedisClient;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Xunit;

    public class CloudErrorJsonConverterTest
    {  
        [Fact]
        public void TestCloudErrorDeserialization()
        {
            var expected = @"
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
                }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new CloudErrorJsonConverter());
            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializeSettings);

            Assert.Equal("The provided database ‘foo’ has an invalid username.", cloudError.Message);
            Assert.Equal("BadArgument", cloudError.Code);
            Assert.Equal("query", cloudError.Target);
            Assert.Equal(1, cloudError.Details.Count);
            Assert.Equal("301", cloudError.Details[0].Code);
        }

        [Fact]
        public void TestCloudErrorWithDifferentCasing()
        {
            var expected = "{\"Error\":{\"Code\":\"CatalogObjectNotFound\",\"Message\":\"datainsights.blah doesn't exist.\"}} ";

            var deserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            deserializationSettings.Converters.Add(new ResourceJsonConverter());
            deserializationSettings.Converters.Add(new CloudErrorJsonConverter());

            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializationSettings);

            Assert.NotNull(cloudError);
            Assert.Equal("datainsights.blah doesn't exist.", cloudError.Message);
            Assert.Equal("CatalogObjectNotFound", cloudError.Code);
        }

        [Fact]
        public void TestEmptyCloudErrorDeserialization()
        {
            var expected = "{}";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new CloudErrorJsonConverter());
            var cloudError = JsonConvert.DeserializeObject<CloudError>(expected, deserializeSettings);

            Assert.NotNull(cloudError);
            Assert.Null(cloudError.Code);
        }

        [Fact]
        public void CommonErrModel_BasicTests()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler();
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            Assert.Equal<string>("BadArgument", cEx.Body.Code, StringComparison.OrdinalIgnoreCase);
        }


        string RGroupName = "rg";
        string ResourceName = "redis";
        string SubId = "1234";
        RedisCreateOrUpdateParameters _redisCreateUpdateParams;
        RedisCreateOrUpdateParameters RedisCreateUpdateParams
        {
            get
            {
                if(_redisCreateUpdateParams == null)
                {
                    _redisCreateUpdateParams = new RedisCreateOrUpdateParameters();
                }

                return _redisCreateUpdateParams;
            }
        }

        private RedisManagementClient GetRedisClient(DelegatingHandler handler)
        {
            var tokenCredentials = new TokenCredentials("123", "abc");
            var fakeClient = new RedisManagementClient(tokenCredentials, handler);
            fakeClient.LongRunningOperationInitialTimeout = fakeClient.LongRunningOperationRetryTimeout = 0;

            return fakeClient;
        }

    }


    public class CloudErrorTestResponse
    {
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
                    ""location"": ""North US"",
                    ""tags"": {
                        ""key1"": ""value 1"",
                        ""key2"": ""value 2""
                        },
    
                    ""properties"": { 
                        ""provisioningState"": ""Creating"",
                        ""comment"": ""Resource defined structure""
                    }
                }")
            };
            
            yield return response2;


            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Failed"", 
                    ""error"" : {
                        ""code"": ""BadArgument"",  
                        ""message"": ""The provided database ‘foo’ has an invalid username."",
                        ""target"": ""Wrong Resource group""
                    }
                }")
            };

            yield return response3;
        }
    }

}
