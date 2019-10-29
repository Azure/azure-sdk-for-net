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
    using Microsoft.Rest.ClientRuntime.Azure.CommonModels;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class CloudErrorJsonConverterTest
    {
        #region fields
        RedisCreateOrUpdateParameters _redisCreateUpdateParams;
        const string RGroupName = "rg";
        const string ResourceName = "redis";
        const string SubId = "1234";
        #endregion
        
        RedisCreateOrUpdateParameters RedisCreateUpdateParams
        {
            get
            {
                if (_redisCreateUpdateParams == null)
                {
                    _redisCreateUpdateParams = new RedisCreateOrUpdateParameters();
                }

                return _redisCreateUpdateParams;
            }
        }


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

        #region AdditionalInfo Tests
        [Fact]
        public void CommonErrModel_BasicTests()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler(CloudErrorTestResponse.MockCreateOrUpdateWithTwoTries());
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            Assert.Equal("BadArgument", cEx.Body.Code);
        }

        [Fact]
        public void CommonErrModel_AdditionalInfo()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler(CloudErrorTestResponse.CreateUpdate_ErrWithAdditionalInfo());
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            Assert.Equal("BadArgument", cEx.Body.Code);
            Assert.Equal(0, cEx.Body.AdditionalInfo.Count);
        }

        [Fact]
        public void CommonErrModel_NonEmptyAdditionalInfo()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler(CloudErrorTestResponse.CreateUpdate_ErrWithNonEmptyAdditionalInfo());
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            Assert.Equal("BadArgument", cEx.Body.Code);
            Assert.Equal(1, cEx.Body.AdditionalInfo.Count);
            Assert.Equal("PolicyViolation", cEx.Body.AdditionalInfo[0].Type);
        }


        [Fact]
        public void CommonErrModel_DetailsWithAdditionalInfo()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler(CloudErrorTestResponse.CreateUpdate_DetailsWithAdditionalInfo());
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            CloudError ce = cEx.Body;

            Assert.Equal(1, ce.Details.Count);
            Assert.Equal("PolicyViolation", ce.Details[0].AdditionalInfo[0].Type);

            AdditionalErrorInfo aInfo = ce.Details[0].AdditionalInfo[0];
            JObject jo = aInfo.Info;
            Assert.NotNull(jo);

            string infoVal = jo.Value<string>("policySetDefinitionDisplayName");
            Assert.Equal("Secure the environment", infoVal);
        }

        [Fact]
        public void CommonErrModel_DetailsWithMultipleAdditionalInfo()
        {
            PlaybackTestHandler testHandler = new PlaybackTestHandler(CloudErrorTestResponse.CreateUpdate_DetailsWithMultipleAdditionalInfo());
            RedisManagementClient redisClient = GetRedisClient(testHandler);

            CloudException cEx = Assert.Throws<CloudException>(() =>
                redisClient.RedisOperations.CreateOrUpdate(RGroupName, ResourceName, RedisCreateUpdateParams, SubId)
            );

            CloudError ce = cEx.Body;
            Assert.Equal(1, ce.Details.Count);
            List<AdditionalErrorInfo> detailsAdditionalInfoList = ce.Details[0].AdditionalInfo as List<AdditionalErrorInfo>;

            Assert.Equal(2, detailsAdditionalInfoList.Count);
            Assert.Equal("PolicyViolation", detailsAdditionalInfoList[0].Type);
            Assert.Equal("SecurityViolation", detailsAdditionalInfoList[1].Type);


            JObject jo = detailsAdditionalInfoList[0].Info;
            Assert.NotNull(jo);

            string infoVal = jo.Value<string>("policySetDefinitionDisplayName");
            Assert.Equal("Secure the environment", infoVal);
        }
        #endregion

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
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
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

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Creating"", 
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

        static internal IEnumerable<HttpResponseMessage> CreateUpdate_ErrWithAdditionalInfo()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
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

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Creating"", 
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
                        ""target"": ""Wrong Resource group"",
                        ""additionalInfo"":[]
                    }
                }")
            };

            yield return response3;
        }

        static internal IEnumerable<HttpResponseMessage> CreateUpdate_ErrWithNonEmptyAdditionalInfo()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
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

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Creating"", 
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
                        ""target"": ""Wrong Resource group"",
                        ""additionalInfo"":[
                        {
                            ""type"": ""PolicyViolation"",
                            ""info"": {}
                        }
                        ]
                    }
                }")
            };

            yield return response3;
        }

        static internal IEnumerable<HttpResponseMessage> CreateUpdate_DetailsWithAdditionalInfo()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
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

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Creating"", 
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
                        ""target"": ""Wrong Resource group"",
                        ""additionalInfo"":[
                            {
                            ""type"": ""PolicyViolation"",
                            ""info"": {}
                            }
                        ],
                        ""Details"":[
                            {
                            ""code"": ""BadArgument"",  
                            ""message"": ""The provided database ‘foo’ has an invalid username."",
                            ""target"": ""Wrong Resource group"",
                            ""additionalInfo"":[
                                    {
                                    ""type"": ""PolicyViolation"",
                                    ""info"": {
                                                ""policySetDefinitionDisplayName"": ""Secure the environment"",
                                                ""policySetDefinitionId"":""/subscriptions/7400bec1d56043e88080ab09fc9c02cb/providers/Microsoft.Authorization/policySetDefinitions/TestPolicySet""
                                            }
                                    }
                                ]
                            }
                        ]
                    }
                }")
            };

            yield return response3;
        }

        static internal IEnumerable<HttpResponseMessage> CreateUpdate_DetailsWithMultipleAdditionalInfo()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
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

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Creating"", 
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
                        ""target"": ""Wrong Resource group"",
                        ""additionalInfo"":[
                            {
                            ""type"": ""PolicyViolation"",
                            ""info"": {}
                            }
                        ],
                        ""Details"":[
                            {
                            ""code"": ""BadArgument"",  
                            ""message"": ""The provided database ‘foo’ has an invalid username."",
                            ""target"": ""Wrong Resource group"",
                            ""additionalInfo"":[
                                    {
                                    ""type"": ""PolicyViolation"",
                                    ""info"": {
                                                ""policySetDefinitionDisplayName"": ""Secure the environment"",
                                                ""policySetDefinitionId"":""/subscriptions/1d56043e88080ab093e8808/providers/Microsoft.Authorization/policySetDefinitions/TestPolicySet""
                                            }
                                    },
                                    {
                                    ""type"": ""SecurityViolation"",
                                    ""info"": {
                                                ""SecurityPolicyDisplayName"": ""Corporate Login Policy"",
                                                ""PolicyId"":""/subscriptions/7400080ab09fc9c02cb/providers/Microsoft.Authorization/policySetDefinitions/TestPolicySet""
                                            }
                                    }
                                ]
                            }
                        ]
                    }
                }")
            };

            yield return response3;
        }
    }
}
