// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    static class LROOpertionTestResponses
    {
        #region Async Operations
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

        #endregion

        #region Location Headers
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

        static internal IEnumerable<HttpResponseMessage> MockLROLocHdrNonStandardTerminalStatus()
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
            response1.Headers.Add("Location", "https://management.azure.com:090/subscriptions/56b5e0a9-b645-407d-99b0-c64f86013e3d/resourcegroups/sjrg8116/providers/Microsoft.StreamAnalytics/streamingjobs/sj3215/functions/function5403/OperationResults/f5dca005-e2ba-47d7-bf6e-4b3276e6bff9");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                  ""status"": ""TestFailed"",
                  ""error"":
                    {
                        ""code"": ""BadRequest"",
                        ""message"": ""DeploymentDocument 'HiveConfigurationValidator' failed the validation.Error: 'Cannot connect to Hive metastore using user provided connection string'"",
                        ""details"": null
                    }
                }
            ")
            };

            yield return response2;

        }

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithLocationHeaderAnd202()
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
        #region Provisioning States
        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithMissingProvisioningState()
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
        #endregion

        #endregion

        #region Provisioning States
        internal static IEnumerable<HttpResponseMessage> Location201FinalGet404WithEmptyStringProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                      {}  
                    ")
            };
            response1.Headers.Add("Location", @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Deleting"",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": null,
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"
                    {}
                ")
            };
            yield return response4;
        }

        internal static IEnumerable<HttpResponseMessage> Location201FinalGet404WithEmptyProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                      {}  
                    ")
            };
            response1.Headers.Add("Location", @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Deleting"",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": """",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"
                    {}
                ")
            };
            yield return response4;
        }

        internal static IEnumerable<HttpResponseMessage> Location201FinalGet404WithNoValueProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                      {}  
                    ")
            };
            response1.Headers.Add("Location", @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Deleting"",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ,
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"
                    {}
                ")
            };
            yield return response4;
        }

        internal static IEnumerable<HttpResponseMessage> Location200WithNullProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""/subscriptions/db5eb68e-73e2-4fa8-b18a-46cd1be4cce5/resourceGroups/rgnemv_c08352411e62/providers/Microsoft.Web/serverfarms/jplan1_cf101472"",
                    ""name"": ""jplan1_cf101472"",
                    ""type"": ""Microsoft.Web/serverfarms"",
                    ""kind"": ""linux"",
                    ""location"": ""West US"",
                    ""tags"": {},
                    ""properties"": {
                        ""serverFarmId"": 17852,
                        ""name"": ""jplan1_cf101472"",
                        ""sku"": {
                            ""name"": ""B1"",
                            ""tier"": ""Basic"",
                            ""size"": ""B1"",
                            ""capacity"": 2
                        },
                        ""workerSize"": ""Default"",
                        ""workerSizeId"": 0,
                        ""workerTierName"": null,
                        ""numberOfWorkers"": 2,
                        ""currentWorkerSize"": ""Default"",
                        ""currentWorkerSizeId"": 0,
                        ""currentNumberOfWorkers"": 2,
                        ""status"": ""Ready"",
                        ""webSpace"": ""rgnemv_c08352411e62-WestUSwebspace"",
                        ""subscription"": ""db5eb68e-73e2-4fa8-b18a-46cd1be4cce5"",
                        ""adminSiteName"": null,
                        ""hostingEnvironment"": null,
                        ""hostingEnvironmentProfile"": null,
                        ""maximumNumberOfWorkers"": 3,
                        ""planName"": ""VirtualDedicatedPlan"",
                        ""adminRuntimeSiteName"": null,
                        ""computeMode"": ""Dedicated"",
                        ""siteMode"": null,
                        ""geoRegion"": ""West US"",
                        ""perSiteScaling"": false,
                        ""numberOfSites"": 3,
                        ""hostingEnvironmentId"": null,
                        ""isSpot"": false,
                        ""spotExpirationTime"": null,
                        ""freeOfferExpirationTime"": null,
                        ""tags"": {},
                        ""kind"": ""linux"",
                        ""resourceGroup"": ""rgnemv_c08352411e62"",
                        ""reserved"": true,
                        ""isXenon"": false,
                        ""mdmId"": ""waws-prod-bay-063_17852"",
                        ""targetWorkerCount"": 0,
                        ""targetWorkerSizeId"": 0,
                        ""provisioningState"": null,
                        ""webSiteId"": null
                    },
                    ""sku"": {
                        ""name"": ""B1"",
                        ""tier"": ""Basic"",
                        ""size"": ""B1"",
                        ""capacity"": 2
                    }
                }
             ")
            };
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/db5eb68e-73e2-4fa8-b18a-46cd1be4cce5/resourceGroups/rgnemv_c08352411e62/providers/Microsoft.Web/serverfarms/jplan1_cf101472"",
                    ""name"": ""jplan1_cf101472"",
                    ""type"": ""Microsoft.Web/serverfarms"",
                    ""kind"": ""linux"",
                    ""location"": ""West US"",
                    ""tags"": {},
                    ""properties"": {
                        ""serverFarmId"": 17852,
                        ""name"": ""jplan1_cf101472"",
                        ""sku"": {
                            ""name"": ""B1"",
                            ""tier"": ""Basic"",
                            ""size"": ""B1"",
                            ""capacity"": 2
                        },
                        ""workerSize"": ""Default"",
                        ""workerSizeId"": 0,
                        ""workerTierName"": null,
                        ""numberOfWorkers"": 2,
                        ""currentWorkerSize"": ""Default"",
                        ""currentWorkerSizeId"": 0,
                        ""currentNumberOfWorkers"": 2,
                        ""status"": ""Ready"",
                        ""webSpace"": ""rgnemv_c08352411e62-WestUSwebspace"",
                        ""subscription"": ""db5eb68e-73e2-4fa8-b18a-46cd1be4cce5"",
                        ""adminSiteName"": null,
                        ""hostingEnvironment"": null,
                        ""hostingEnvironmentProfile"": null,
                        ""maximumNumberOfWorkers"": 3,
                        ""planName"": ""VirtualDedicatedPlan"",
                        ""adminRuntimeSiteName"": null,
                        ""computeMode"": ""Dedicated"",
                        ""siteMode"": null,
                        ""geoRegion"": ""West US"",
                        ""perSiteScaling"": false,
                        ""numberOfSites"": 3,
                        ""hostingEnvironmentId"": null,
                        ""isSpot"": false,
                        ""spotExpirationTime"": null,
                        ""freeOfferExpirationTime"": null,
                        ""tags"": {},
                        ""kind"": ""linux"",
                        ""resourceGroup"": ""rgnemv_c08352411e62"",
                        ""reserved"": true,
                        ""isXenon"": false,
                        ""mdmId"": ""waws-prod-bay-063_17852"",
                        ""targetWorkerCount"": 0,
                        ""targetWorkerSizeId"": 0,
                        ""provisioningState"": null,
                        ""webSiteId"": null
                    },
                    ""sku"": {
                        ""name"": ""B1"",
                        ""tier"": ""Basic"",
                        ""size"": ""B1"",
                        ""capacity"": 2
                    }
                }
                ")
            };
            yield return response2;
        }


        internal static IEnumerable<HttpResponseMessage> Location201FinalGet404WithNullStringProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                      {}  
                    ")
            };
            response1.Headers.Add("Location", @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Deleting"",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": null,
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"
                    {}
                ")
            };
            yield return response4;
        }

        internal static IEnumerable<HttpResponseMessage> Location201FinalGet404WithMissingProviState()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                      {}  
                    ")
            };
            response1.Headers.Add("Location", @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01");
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Deleting"",
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""redisVersion"": ""3.2.7"",
                        ""sku"": {
                            ""name"": ""Basic"",
                            ""family"": ""C"",
                            ""capacity"": 0
                        },
                        ""enableNonSslPort"": false,
                        ""redisConfiguration"": {
                            ""maxclients"": ""256"",
                            ""maxmemory-reserved"": ""2"",
                            ""maxfragmentationmemory-reserved"": ""12"",
                            ""maxmemory-delta"": ""2""
                        },
                        ""accessKeys"": null,
                        ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                        ""port"": 6379,
                        ""sslPort"": 6380,
                        ""linkedServers"": []
                        }
                    }        
                ")
            };
            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"
                    {}
                ")
            };
            yield return response4;
        }

        #endregion

        #region PUT responses
        static internal IEnumerable<HttpResponseMessage> MockPutOperaionWithoutProvisioningStateInResponse()
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

        static internal IEnumerable<HttpResponseMessage> MockLROPUTWithCanceledStateResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                { 
                    ""properties"": { }, 
                    ""id"": ""100"", 
                    ""name"": ""foo"" 
                }")
            };

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                { 
                  ""status"": ""Canceled"",
                  ""error"":
                    {
                        ""code"": ""OperationPreempted"",
                        ""message"": ""The operation has been preempted by a more recent operation""
                    }
                }"

                )
            };
            yield return response2;
        }

        #endregion

        #region Retry-After

        static internal IEnumerable<HttpResponseMessage> MockDeleteWithRetryAfterTwoTries()
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

            var response3 = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(@"")
            };

            yield return response3;
        }

        static internal IEnumerable<HttpResponseMessage> MockPatchWithRetryAfterTwoTries()
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
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response2;
        }

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithDifferentRetryAfterValues()
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
                        ""provisioningState"": ""InProgerss"",
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
                    ""status"" : ""InProgerss"", 
                    ""properties"": { 
                        ""provisioningState"": ""InProgerss"",
                        ""comment"": ""Resource getting created""
                    }
                }")
            };
            response2.Headers.Add("Retry-After", "5");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""properties"": {
                        ""id"": ""100"",
                        ""name"": ""foo""
                    }
                }")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"" : ""Succeeded"", 
                    ""properties"": {
                        ""id"": ""100"",
                        ""name"": ""foo""
                    }
                }")
            };

            yield return response4;
        }

        static internal IEnumerable<HttpResponseMessage> MockCreateWithRetryAfterDefaultMin()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");
            response1.Headers.Add("Retry-After", "0");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response2;
        }

        static internal IEnumerable<HttpResponseMessage> MockCreateWithRetryAfterDefaultMax()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"")
            };
            response1.Headers.Add("Location", "http://custom/location/status");
            response1.Headers.Add("Retry-After", "50");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { }, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response2;
        }
        #endregion

        #region other LRO tests
        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithoutHeaderInResponses()
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

        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithNoBody()
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

        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithEmptyBody()
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

        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithNullBody()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = null
            };

            yield return response2;
        }

        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithBadPayload()
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

        static internal IEnumerable<HttpResponseMessage> MockAsyncOperaionWithNonSuccessStatusAndInvalidResponseContent()
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
        
        static internal IEnumerable<HttpResponseMessage> MockPutOperaionWitNonResource()
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

        static internal IEnumerable<HttpResponseMessage> MockPutOperaionWitSubResource()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""properties"": {
                    ""provisioningState"": ""InProgress""
                    },
                    ""id"": ""100"",
                    ""name"": ""foo""
                }
              }")
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

        static internal IEnumerable<HttpResponseMessage> MockPutOperaionWithImmediateSuccess()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ \"properties\": { \"provisioningState\": \"Succeeded\"}, \"id\": \"100\", \"name\": \"foo\" }")
            };

            yield return response1;
        }

        static internal IEnumerable<HttpResponseMessage> MockOperaionWithImmediateSuccessOKStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response1;
        }

        static internal IEnumerable<HttpResponseMessage> MockPostOperaionWithImmediateSuccessOKStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"Capacity\":1,\"Family\":\"Family\"}")
            };

            yield return response1;
        }

        static internal IEnumerable<HttpResponseMessage> MockOperaionWithImmediateSuccessNoContentStatus()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response1;
        }

        static internal IEnumerable<HttpResponseMessage> MockPostOperaionWithBody()
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

            var response3 = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(@"
                {
                    ""name"": ""FooBar""
                }")
            };
            yield return response3;
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

        static internal IEnumerable<HttpResponseMessage> MockDeleteOperaionWithoutHeaderInResponse()
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

        static internal IEnumerable<HttpResponseMessage> MockDeleteOperaionWithoutLocationHeaderInResponse()
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

            var response4 = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent("")
            };
            yield return response4;
        }
        
        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithAsyncHeaderAnd202()
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

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithWith202AndResource()
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

        static internal IEnumerable<HttpResponseMessage> MockPostWithResourceSku()
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

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""Capacity"": ""1"",
                    ""Family"": ""Family""
                }")
            };
            yield return response4;
        }

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithNoAsyncHeader()
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

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithFailedStatus()
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

        static internal IEnumerable<HttpResponseMessage> MockCreateOrUpdateWithRetryAfterTwoTries()
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

        static internal IEnumerable<HttpResponseMessage> MockDeleteWithAsyncHeaderTwoTries()
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

        static internal IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderTwoTries()
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

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("")
            };
            yield return response4;
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

        static internal IEnumerable<HttpResponseMessage> MockDeleteWithLocationHeaderErrorInSecondCall()
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
        
        static internal IEnumerable<HttpResponseMessage> MockPutWebAppLRO()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                {
                    ""id"":""/subscriptions/ffa52f27-be12-b1ea-c2c1b6cceb/resourceGroups/rgnemv_bef11205b7b0/providers/Microsoft.Web/sites/webapp1-35965806af0/sourcecontrols/web"",
                    ""name"":""webapp1-35965806af0"",
                    ""type"":""Microsoft.Web/sites/sourcecontrols"",
                    ""location"":""West US 2"",
                    ""tags"":{},
                    ""properties"":
	                    {
	                    ""repoUrl"":""https://github.com/foo/azure-site-test"",
	                    ""branch"":""master"",
	                    ""isManualIntegration"":true,
	                    ""deploymentRollbackEnabled"":false,
	                    ""isMercurial"":false,
	                    ""provisioningState"":""InProgress""
	                    }
                }")
            };
            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                {
	                ""id"":""/subscriptions/ffa52f27-be12-4cad-b1ea/resourceGroups/rgnemv_bef11205b7b0/providers/Microsoft.Web/sites/webapp1-35965806af0/sourcecontrols/web"",
	                ""name"":""webapp1-35965806af0"",
	                ""type"":""Microsoft.Web/sites/sourcecontrols"",
	                ""location"":""West US 2"",
	                ""tags"":{},
	                ""properties"":
	                {
		                ""repoUrl"":""https://github.com/foo/azure-site-test"",
		                ""branch"":""master"",
		                ""isManualIntegration"":true,
		                ""deploymentRollbackEnabled"":false,
		                ""isMercurial"":false,
		                ""provisioningState"":""InProgress"",
		                ""provisioningDetails"":""2017-08-25T05:49:50.0340330 https://webapp1-359658.azurewebsites.net/api/deployments/latest?deployer=GitHub&time=2017-08-25_05-49-23""
	                }
                }
                ")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
	                ""id"":""/subscriptions/ffa52f27-be12-4cad-b1ea-c2c241b6cceb/resourceGroups/rgnemv_bef11205b7b0/providers/Microsoft.Web/sites/webapp1-35965806af0"",
	                ""name"":""webapp1-35965806af0"",
	                ""type"":""Microsoft.Web/sites"",
	                ""kind"":""app"",
	                ""location"":""West US 2"",
	                ""tags"":{},
	                ""properties"":
	                {
		                ""name"":""webapp1-35965806af0"",
		                ""state"":""Running"",
		                ""hostNames"":[""webapp1-35965806af0.jsdkdemo-62e18289a.com"",
		                ""webapp1-35965806af0.azurewebsites.net""],
		                ""webSpace"":""rgnemv_bef11205b7b0-WestUS2webspace"",
		                ""selfLink"":""https://waws.api.azurewebsites.windows.net/subscriptions/ffa52f27-b1ea-c2c241b6cceb/webspaces/rgnemv_bef11205b7b0-WestUS2webspace/sites/webapp1-35965806af0"",
		                ""repositorySiteName"":""webapp1-35965806af0"",
		                ""owner"":null,
		                ""usageState"":""Normal"",
		                ""enabled"":true,
		                ""adminEnabled"":true,
		                ""enabledHostNames"":[""webapp1-35965806af0.jsdkdemo-62e18289a.com"",
		                ""webapp1-35965806af0.azurewebsites.net"",
		                ""webapp1-35965806af0.scm.azurewebsites.net""],
		                ""siteProperties"":{""metadata"":null,
		                ""properties"":[],
		                ""appSettings"":null},
		                ""availabilityState"":""Normal"",
		                ""sslCertificates"":null,
		                ""csrs"":[],
		                ""cers"":null,
		                ""siteMode"":null,
		                ""hostNameSslStates"":[
			                {
			                ""name"":""webapp1-35965806af0.azurewebsites.net"",
			                ""sslState"":""Disabled"",
			                ""ipBasedSslResult"":null,
			                ""virtualIP"":null,
			                ""thumbprint"":null,
			                ""toUpdate"":null,
			                ""toUpdateIpBasedSsl"":null,
			                ""ipBasedSslState"":""NotConfigured"",
			                ""hostType"":""Standard""
			                },
			                {
			                ""name"":""webapp1-35965806af0.jsdkdemo-62e18289a.com"",
			                ""sslState"":""SniEnabled"",
			                ""ipBasedSslResult"":null,
			                ""virtualIP"":null,
			                ""thumbprint"":""40ECC6C60434CF"",
			                ""toUpdate"":null,
			                ""toUpdateIpBasedSsl"":null,
			                ""ipBasedSslState"":""NotConfigured"",
			                ""hostType"":""Standard""
			                },
			                {
			                ""name"":""webapp.scm.azurewebsites.net"",
			                ""sslState"":""Disabled"",
			                ""ipBasedSslResult"":null,
			                ""virtualIP"":null,
			                ""thumbprint"":null,
			                ""toUpdate"":null,
			                ""toUpdateIpBasedSsl"":null,
			                ""ipBasedSslState"":""NotConfigured"",
			                ""hostType"":""Repository""
			                }],
		                ""computeMode"":null,
		                ""serverFarm"":null,
		                ""serverFarmId"":""/subscriptions/ffa52f27-b1ea-c2c241b6cceb/resourceGroups/rgnemv_bef11205b7b0/providers/Microsoft.Web/serverfarms/jplan1_73a739850"",
		                ""reserved"":false,
		                ""lastModifiedTimeUtc"":""2017-08-25T05:48:34.92"",
		                ""storageRecoveryDefaultState"":""Running"",
		                ""contentAvailabilityState"":""Normal"",
		                ""runtimeAvailabilityState"":""Normal"",
		                ""siteConfig"":null,
		                ""deploymentId"":""webapp1-35965806af0"",
		                ""trafficManagerHostNames"":null,
		                ""sku"":""Basic"",
		                ""scmSiteAlsoStopped"":false,
		                ""targetSwapSlot"":null,
		                ""hostingEnvironment"":null,
		                ""hostingEnvironmentProfile"":null,
		                ""clientAffinityEnabled"":true,
		                ""clientCertEnabled"":false,
		                ""hostNamesDisabled"":false,
		                ""domainVerificationIdentifiers"":null,
		                ""kind"":""app"",
		                ""outboundIpAddresses"":""93.99.231.000,62.66.007.111,36.36.261.144,93.93.282.10"",
		                ""possibleOutboundIpAddresses"":""93.99.231.000,62.66.007.111,36.36.261.144,93.93.282.10"",
		                ""containerSize"":0,
		                ""dailyMemoryTimeQuota"":0,
		                ""suspendedTill"":null,
		                ""siteDisabledReason"":0,
		                ""functionExecutionUnitsCache"":null,
		                ""maxNumberOfWorkers"":null,
		                ""homeStamp"":""waws-wch237-003"",
		                ""cloningInfo"":null,
		                ""hostingEnvironmentId"":null,
		                ""tags"":{},
		                ""resourceGroup"":""rgnemv_bef11205b7b0"",
		                ""defaultHostName"":""webapp1-35965806af0.azurewebsites.net"",
		                ""slotSwapStatus"":null
	                }
               }
               ")
            };

            yield return response3;
        }
        #endregion
    }

    static class LROOperationPatchTestResponses
    {
        static internal IEnumerable<HttpResponseMessage> ServiceCustomResponse()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                {
                     ""properties"": {
                            ""topic"": ""/subscriptions/76fc5-4d01-b462-9f01b2d77/resourceGroups/rg-76fce8d7-1205-4d01-b462-9f01b2d70f67/providers/microsoft.eventgrid/topics/topic-76fce8d7-1205-4d01-b462-9f01b2d70f67"",
                            ""provisioningState"": ""Updating"",
                            ""destination"": {
                              ""properties"": {
                                ""endpointUrl"": null,
                                ""endpointBaseUrl"": ""https://subscriber-76fce8d7-1205-4d01-b462-9f01b2d70f67.eventgrid-int.azure.net:782/""
                              },
                              ""endpointType"": ""WebHook""
                            },
                            ""filter"": {
                              ""subjectBeginsWith"": """",
                              ""subjectEndsWith"": """",
                              ""includedEventTypes"": [ ""All"" ]
                            },
                            ""labels"": null
                          },
                  ""id"": ""/subscriptions/76fc5-4d01-b462-9f01b2d77/resourceGroups/rg-76fce8d7-12d01-b462-9f01b2d70f67/providers/Microsoft.EventGrid/topics/topic-76fce8d7-1205-4d01-b462-9f01b2d70f67/providers/Microsoft.EventGrid/eventSubscriptions/subscription-8da8b80f-a198-42f0-af01-99bc0c08d563"",
                  ""name"": ""subscription-8da8b80f-a198-42f0-af01-99bc0c08d563"",
                  ""type"": ""Microsoft.EventGrid/eventSubscriptions""
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"": ""Succeeded"",
	                ""properties"": {
		                ""provisioningState"": ""Succeeded"",
		                ""state"": ""Active""
                        }
                }
                ")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""34adfa4f-cedf-4dc0-ba29-b6d1a69ab345"",             
	                ""name"": ""test_account"",
	                ""type"": ""test_type"",
	                ""location"": ""test_location"",
	                ""tags"": { 
		                ""test_key"": ""test_value""                    
	                }
                }
                ")
            };
            yield return response3;

        }
        static internal IEnumerable<HttpResponseMessage> MockPatchWithAzureAsyncOperationHeader()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""34adfa4f-cedf-4dc0-ba29-b6d1a69ab345"",             
	                ""name"": ""test_account"",
	                ""type"": ""test_type"",
	                ""location"": ""test_location"",
	                ""tags"": { 
		                ""test_key"": ""test_value"" 
	                },
	                ""properties"": {
		                ""provisioningState"": ""InProgress"",
		                ""state"": ""InActive""
		                }
                }")
            };
            response1.Headers.Add("Azure-AsyncOperation", "http://custom/status");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"": ""Succeeded"",
	                ""properties"": {
		                ""provisioningState"": ""Succeeded"",
		                ""state"": ""Active""
                        }
                }
                ")
            };

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""34adfa4f-cedf-4dc0-ba29-b6d1a69ab345"",             
	                ""name"": ""test_account"",
	                ""type"": ""test_type"",
	                ""location"": ""test_location"",
	                ""tags"": { 
		                ""test_key"": ""test_value""                    
	                }
                }
                ")
            };
            yield return response3;
        }

        static internal IEnumerable<HttpResponseMessage> MockPatchWithLocationHeader()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""id"": ""34adfa4f-cedf-4dc0-ba29-b6d1a69ab345"",             
	                ""name"": ""test_account"",
	                ""type"": ""test_type"",
	                ""location"": ""test_location"",
	                ""tags"": { 
		                ""test_key"": ""test_value"" 
	                },
	                ""properties"": {
		                ""provisioningState"": ""InProgress"",
		                ""state"": ""InActive""
		                }
                }")
            };
            response1.Headers.Add("Location", "https://management.azure.com:090/subscriptions/947c-43bc-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""status"": ""Succeeded"",
	                ""properties"": {
		                ""provisioningState"": ""Succeeded"",
		                ""state"": ""Active""
                        }
                }
                ")
            };

            yield return response2;
        }
    }

    static class LROOperationFailedTestResponses
    {
        static internal IEnumerable<HttpResponseMessage> MockLROAsyncOperationFailedOnlyStatus()
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
            //response1.Headers.Add("Azure-AsyncOperation", "https://management.azure.com:090/subscriptions/434c10bb-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");
            response1.Headers.Add("Location", "https://management.azure.com:090/subscriptions/947c-43bc-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");

            yield return response1;

            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"{}")
            };
            yield return response2;


            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"'https://mdsbrketwprodsn1prod.blob.core.windows.net/cmakexe/abbd1dc4-44eb-4a66-9d90-156f7e5191a7/vpnclientconfiguration.zip?sv=2015-04-05&sr=b&sig=Ec6g2tlP0xktQSipQCTO55mnNjwOxTsge4Ot3sjX8Z8%3D&st=2017-08-28T21%3A25%3A34Z&se=2017-08-28T22%3A25%3A34Z&sp=r&fileExtension=.zip'")

            //    Content = new StringContent(@"
            //    {
            //      ""https://mdsbrketwprodsn1prod.blob.core.windows.net/cmakexe/abbd1dc4-44eb-4a66-9d90-156f7e5191a7/vpnclientconfiguration.zip?sv=2015-04-05&sr=b&sig=Ec6g2tlP0xktQSipQCTO55mnNjwOxTsge4Ot3sjX8Z8%3D&st=2017-08-28T21%3A25%3A34Z&se=2017-08-28T22%3A25%3A34Z&sp=r&fileExtension=.zip""
            //    }
            //")
            };

            yield return response3;

        }
    }

    static class LROOperationMultipleHeaderResponses
    {
        static internal IEnumerable<HttpResponseMessage> MockLROLocationHeaderAndAsyncOperation()
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
            response1.Headers.Add("Location", "https://management.azure.com:090/subscriptions/947c-43bc-83d3-6b3186c7305/resourceGroups/hdisdk106/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview");

            yield return response1;

            // Even if Async-Operation header is passed, but initially LocationHeader was used
            // we cache it and use it because for 202, we prefere Location header over Async-Operation
            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",                    
                    ""id"": ""100"",
                    ""name"": ""foo"",
                    ""properties"": {
                        ""provisioningState"": ""InProgress""
                    }
              }")
            };
            response2.Headers.Add("Azure-AsyncOperation", "http://custom/AsyncOperation");
            response2.Headers.Add("Retry-After", "12");

            yield return response2;
            
            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                    {
                        ""status"": ""Succeeded"",
	                    ""properties"": {
		                    ""provisioningState"": ""Succeeded"",
		                    ""state"": ""Active""
                        }
                    }")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""location"": ""North US"",
                    ""id"": ""100""
                }")
            };

            yield return response4;
        }


        /// <summary>
        /// DELETE operatoin with multiple operations with 202
        /// Location is passed in the first round
        /// AsyncOperaiton header is passed in the second round
        /// This will enable to finish the polling using AsyncOperaiton after second round
        /// 
        /// It will finally use Location header to do final GET and will succeed
        /// </summary>
        /// <returns></returns>
        static internal IEnumerable<HttpResponseMessage> MockLRO_DeleteSuccessWithLocationHeaderFinalGetNotFound()
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
            response1.Headers.Add("Location", "https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/operationresults/eyJqb2JJZCI6IlJFU09VUkNFR1JPVVBERUxFVElPTkpPQi1DUlBURVNUQVI3ODkxLVNPVVRIRUFTVEFTSUEiLCJqb2JMb2NhdGlvbiI6InNvdXRoZWFzdGFzaWEifQ?api-version=2017-05-10");
            response1.Headers.Add("Retry-After", "5");
            yield return response1;

            // Even if Async-Operation header is passed, but initially LocationHeader was used
            // we cache it and use it because for 202, we prefere Location header over Async-Operation
            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            //response2.Headers.Add("Azure-AsyncOperation", "https://management.azure.com/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/providers/Microsoft.Compute/locations/southeastasia/DiskOperations/a467a7f3-d2e3-493c-9996-9b212a941154?api-version=2017-03-30");
            //response2.Headers.Add("Retry-After", "12");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(@"")
            };

            yield return response4;
        }

        /// <summary>
        /// Delete with location header.
        /// Final GET returns NoContent
        /// </summary>
        /// <returns></returns>
        static internal IEnumerable<HttpResponseMessage> MockLRO_DeleteSuccessWithLocationHeaderFinalGetNoContent()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Location", "https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/operationresults/eyJqb2JJZCI6IlJFU09VUkNFR1JPVVBERUxFVElPTkpPQi1DUlBURVNUQVI3ODkxLVNPVVRIRUFTVEFTSUEiLCJqb2JMb2NhdGlvbiI6InNvdXRoZWFzdGFzaWEifQ?api-version=2017-05-10");
            response1.Headers.Add("Retry-After", "5");
            yield return response1;

            // Even if Async-Operation header is passed, but initially LocationHeader was used
            // we cache it and use it because for 202, we prefere Location header over Async-Operation
            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            //response2.Headers.Add("Azure-AsyncOperation", "https://management.azure.com/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/providers/Microsoft.Compute/locations/southeastasia/DiskOperations/a467a7f3-d2e3-493c-9996-9b212a941154?api-version=2017-03-30");
            //response2.Headers.Add("Retry-After", "12");

            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.NoContent)
            {
                Content = new StringContent(@"")
            };

            yield return response4;
        }

        /// <summary>
        /// Pass Azure-async header as well as location header.
        /// </summary>
        /// <returns></returns>
        static internal IEnumerable<HttpResponseMessage> MockLRO_POST_LocAsyncHeaderFinalGetSuccess()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent("")
            };
            response1.Headers.Add("Azure-AsyncOperation", "https://management.azure.com/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/providers/Microsoft.Compute/locations/southeastasia/DiskOperations/a467a7f3-d2e3-493c-9996-9b212a941154?api-version=2017-03-30");
            //response1.Headers.Add("Retry-After", "5");
            yield return response1;
            
            var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(@"
                   {
                    ""startTime"": ""2018-02-08T16:03:10.266925-08:00"",
                    ""status"": ""InProgress"",
                    ""name"": ""ef936d96-9f17-4226-b6ea-0d8590f7bdb5""
                   }")
            };            
            response2.Headers.Add("Location", "https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.Compute/locations/southeastasia/operations/ef936d96-9f17-4226-b6ea-0d8590f7bdb5?monitor=true&api-version=2017-12-01");
            yield return response2;

            var response3 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                   {
                    ""startTime"": ""2018-02-08T16:03:10.266925-08:00"",
                    ""status"": ""InProgress"",
                    ""name"": ""ef936d96-9f17-4226-b6ea-0d8590f7bdb5""
                   }")
            };

            yield return response3;

            var response4 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""startTime"": ""2018-02-08T16:03:10.266925-08:00"",
                    ""endTime"": ""2018-02-08T16:04:25.3955911-08:00"",
                    ""status"": ""Succeeded"",
                    ""name"": ""ef936d96-9f17-4226-b6ea-0d8590f7bdb5""
                }")
            };

            yield return response4;

            var response5 = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"
                {
                    ""name"": ""foo""
                }")
            };

            yield return response5;
        }
    }
}
