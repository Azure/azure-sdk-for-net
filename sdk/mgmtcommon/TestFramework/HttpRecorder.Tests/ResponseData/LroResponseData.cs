using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace HttpRecorder.Tests.ResponseData
{
    internal class LroResponseData
    {
        #region Fields
        internal static string LroAsyncHeaderName = "Azure-AsyncOperation";
        internal static string LroLocationHeaderName = "Location";

        internal static string LroAsyncHeaderValue = "Http://custom/status";
        internal static string LroLocationHeaderValue = "https://management.azure.com:090/subscriptions/947c-43bc-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview";
        #endregion

        internal class PutResponse
        {
            internal static string Put_AsyncHeaderValue_1 = "https://management.azure.com/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/providers/Microsoft.Compute/locations/southeastasia/DiskOperations/a467a7f3-d2e3-493c-9996-9b212a941154?api-version=2017-03-30";
            internal static string Put_LocationHeaderValue_1 = "https://management.azure.com:893/subscriptions/947c-4345t-83d3-6b318c6c7305/resourceGroups/VMSS2345/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview";

            internal static string EmptyInitialResponse = @"";

            #region initialResponse
            internal static string InitalResponse = @"
            {
                ""name"": ""pip4477"",
                ""id"": ""/subscriptions/24fb23e3-6bf0-9b6e-e41131d5d61e/resourceGroups/crptestar2207/providers/Microsoft.Network/publicIPAddresses/pip4477"",
                ""etag"": ""0147dbca-57cd-4e6e-bbf7-084fd1c05c"",
                ""location"": ""southeastasia"",
                ""tags"": {
                    ""key"": ""value""
                },
                ""properties"": {
                    ""provisioningState"": ""Updating"",
                    ""resourceGuid"": ""a410e4f1-3daf-41-a486-c419103ec996"",
                    ""publicIPAddressVersion"": ""IPv4"",
                    ""publicIPAllocationMethod"": ""Dynamic"",
                    ""idleTimeoutInMinutes"": 4,
                    ""dnsSettings"": {
                        ""domainNameLabel"": ""dn2871"",
                        ""fqdn"": ""zr4tg71.southeasia.cloudapp.azure.net""
                    }
                },
                ""type"": ""Microsoft.Network/publicIPAddresses""
            }";
            #endregion

            internal static HttpResponseMessage GetResponse(string responseContent, HttpStatusCode statusCode, LroHeaders headersToAdd)
            {
                HttpResponseMessage res = new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(responseContent)
                };
                res = PutAddHeaders(res, headersToAdd);

                return res;
            }

            internal static IEnumerable<HttpResponseMessage> PollingResponse(LroHeaders header, int pollingCount, HttpStatusCode pollingStatusCode)
            {
                string pollResponse = string.Empty;
                string pollEndResponse = string.Empty;
                string finalGetResponse = string.Empty;

                List<HttpResponseMessage> responseList = new List<HttpResponseMessage>();

                switch (header)
                {
                    case LroHeaders.AzureAsync:
                        {
                            pollResponse = AsyncOperationHeader.IntrimPollingResponse;
                            pollEndResponse = AsyncOperationHeader.PollingCompletedResponse;
                        }
                        break;

                    case LroHeaders.Location:
                        {
                            pollResponse = LocationHeader.IntrimPollingResponse_1;
                            pollEndResponse = LocationHeader.PollingCompletedResponse;
                            finalGetResponse = LocationHeader.LH_FinalResource;
                        }
                        break;

                    case LroHeaders.Location_And_AzureAsync:
                        {
                            pollResponse = AsyncOperationHeader.IntrimPollingResponse;
                            pollEndResponse = AsyncOperationHeader.PollingCompletedResponse;
                            finalGetResponse = LocationHeader.LH_FinalResource;
                        }
                        break;
                }

                for (int i = 0; i <= pollingCount - 1; i++)
                {
                    HttpResponseMessage res = new HttpResponseMessage(pollingStatusCode)
                    {
                        Content = new StringContent(pollResponse)
                    };
                    res = PutAddHeaders(res, header);

                    responseList.Add(res);
                }

                if (!string.IsNullOrEmpty(pollEndResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(pollEndResponse)
                    };

                    responseList.Add(res);
                }

                if (!string.IsNullOrEmpty(finalGetResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(finalGetResponse)
                    };

                    responseList.Add(res);
                }

                return responseList;
            }

            static HttpResponseMessage PutAddHeaders(HttpResponseMessage response, LroHeaders headersToAdd)
            {
                switch (headersToAdd)
                {
                    case LroHeaders.AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Put_AsyncHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location:
                        {
                            response.Headers.Add(LroLocationHeaderName, Put_LocationHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location_And_AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Put_AsyncHeaderValue_1);
                            response.Headers.Add(LroLocationHeaderName, Put_LocationHeaderValue_1);
                            break;
                        }
                }

                return response;
            }

            //internal static HttpResponseMessage PostPollingResponse(LroHeaders header, HttpStatusCode finalGetStatusCode)
            //{
            //    string postPollResponse = string.Empty;

            //    switch (header)
            //    {
            //        case LroHeaders.AzureAsync:
            //            {
            //                postPollResponse = AsyncOperationHeader.AsyncOperationHeaderFinalResource;
            //            }
            //            break;

            //        case LroHeaders.Location:
            //            {
            //                postPollResponse = LocationHeader.LH_FinalResource;
            //            }
            //            break;

            //        case LroHeaders.Location_And_AzureAsync:
            //            {
            //                postPollResponse = LocationHeader.LH_FinalResource;
            //            }
            //            break;
            //    }

            //    HttpResponseMessage res = new HttpResponseMessage(finalGetStatusCode)
            //    {
            //        Content = new StringContent(postPollResponse)
            //    };

            //    return res;
            //}
        }


        internal class PostResponse
        {
            internal static string Post_AsyncHeaderValue_1 = "https://management.azure.net/subscriptions/popo23e3-6ba3-41f0-9b6e-e41131d5d61e/providers/Microsoft.Compute/locations/southeastasia/DiskOperations/a467a7f3-d2e3-493c-9996-9b212a941154?api-version=2017-01-11";
            internal static string Post_LocationHeaderValue_1 = "https://management.azure.com:893/subscriptions/post-4345t-83d3-6b318c6c7305/resourceGroups/VMSS2345/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview";

            internal static string EmptyInitialResponse = @"";

            #region initialResponse
            internal static string InitalResponse = @"
            {
                ""name"": ""pip4477"",
                ""id"": ""/subscriptions/24fb23e3-6bf0-9b6e-e41131d5d61e/resourceGroups/crptestar2207/providers/Microsoft.Network/publicIPAddresses/pip4477"",
                ""etag"": ""0147dbca-57cd-4e6e-bbf7-084fd1c05c"",
                ""location"": ""southeastasia"",
                ""tags"": {
                    ""key"": ""value""
                },
                ""properties"": {
                    ""provisioningState"": ""Updating"",
                    ""resourceGuid"": ""a410e4f1-3daf-41-a486-c419103ec996"",
                    ""publicIPAddressVersion"": ""IPv4"",
                    ""publicIPAllocationMethod"": ""Dynamic"",
                    ""idleTimeoutInMinutes"": 4,
                    ""dnsSettings"": {
                        ""domainNameLabel"": ""dn2871"",
                        ""fqdn"": ""zr4tg71.southeasia.cloudapp.azure.net""
                    }
                },
                ""type"": ""Microsoft.Network/publicIPAddresses""
            }";
            #endregion

            internal static HttpResponseMessage GetResponse(string responseContent, HttpStatusCode statusCode, LroHeaders headersToAdd)
            {
                HttpResponseMessage res = new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(responseContent)
                };
                res = PostAddHeaders(res, headersToAdd);

                return res;
            }

            internal static IEnumerable<HttpResponseMessage> PollingResponse(LroHeaders header, int pollingCount, HttpStatusCode pollingStatusCode)
            {
                string pollResponse = string.Empty;
                string pollEndResponse = string.Empty;
                string finalGetResponse = string.Empty;

                List<HttpResponseMessage> responseList = new List<HttpResponseMessage>();

                switch (header)
                {
                    case LroHeaders.AzureAsync:
                        {
                            pollResponse = AsyncOperationHeader.IntrimPollingResponse;
                            pollEndResponse = AsyncOperationHeader.PollingCompletedResponse;
                        }
                        break;

                    case LroHeaders.Location:
                        {
                            pollResponse = LocationHeader.IntrimPollingResponse_1;
                            pollEndResponse = LocationHeader.PollingCompletedResponse;
                            finalGetResponse = LocationHeader.LH_FinalResource;
                        }
                        break;

                    case LroHeaders.Location_And_AzureAsync:
                        {
                            pollResponse = AsyncOperationHeader.IntrimPollingResponse;
                            pollEndResponse = AsyncOperationHeader.PollingCompletedResponse;
                            finalGetResponse = LocationHeader.LH_FinalResource;
                        }
                        break;
                }

                for (int i = 0; i <= pollingCount - 1; i++)
                {
                    HttpResponseMessage res = new HttpResponseMessage(pollingStatusCode)
                    {
                        Content = new StringContent(pollResponse)
                    };
                    res = PostAddHeaders(res, header);

                    responseList.Add(res);
                }

                if (!string.IsNullOrEmpty(pollEndResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(pollEndResponse)
                    };

                    responseList.Add(res);
                }

                if (!string.IsNullOrEmpty(finalGetResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(finalGetResponse)
                    };

                    responseList.Add(res);
                }

                return responseList;
            }

            static HttpResponseMessage PostAddHeaders(HttpResponseMessage response, LroHeaders headersToAdd)
            {
                switch (headersToAdd)
                {
                    case LroHeaders.AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Post_AsyncHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location:
                        {
                            response.Headers.Add(LroLocationHeaderName, Post_LocationHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location_And_AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Post_AsyncHeaderValue_1);
                            response.Headers.Add(LroLocationHeaderName, Post_LocationHeaderValue_1);
                            break;
                        }
                }

                return response;
            }
        }




        internal static class DeleteResponse
        {
            internal static string Delete_AsyncHeaderValue_1 = "https://management.azure.com:090/subscriptions/434c10bb-83d3-6b318c6c7305/resourceGroups/hdisdk1706/providers/Microsoft.HDInsight/clusters/hdisdk-fail/azureasyncoperations/create?api-version=2015-03-01-preview";
            internal static string Delete_LocationHeaderValue_1 = "https://management.azure.com/subscriptions/fffc-4345t-83d3-6b318c6c7305/resourceGroups/testgrp3569/providers/Microsoft.Compute/clusters/hdisdk-fail/azureasyncoperations/patch?api-version=2019-03-01";

            #region Responses
            internal static string Initial_EmptyResponse = @"";

            internal static string Intrim_AzAsyncHeaderStatusInProgress = @"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }";

            internal static string Intrim_AzAsyncHeaderSuccessResponse = @"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ";

            internal static string Intrim_LocationInProgress = @"
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
                ";

            internal static string Intrim_LocationSuccess = @"{}";

            internal static string Final_LocationSucess = @"{}";
            #endregion

            internal static HttpResponseMessage GetResponse(string responseContent, HttpStatusCode statusCode, LroHeaders headersToAdd)
            {
                HttpResponseMessage res = new HttpResponseMessage(statusCode)
                {
                    Content = new StringContent(responseContent)
                };
                res = DeleteAddHeaders(res, headersToAdd);

                return res;
            }

            internal static IEnumerable<HttpResponseMessage> PollingResponse(LroHeaders header, int pollingCount, HttpStatusCode pollingStatusCode)
            {
                string pollResponse = string.Empty;
                string pollEndResponse = string.Empty;
                string finalGetResponse = string.Empty;
                List<HttpResponseMessage> responseList = new List<HttpResponseMessage>();

                switch (header)
                {
                    case LroHeaders.AzureAsync:
                        {
                            pollResponse = Intrim_AzAsyncHeaderStatusInProgress;
                            pollEndResponse = Intrim_AzAsyncHeaderSuccessResponse;
                        }
                        break;

                    case LroHeaders.Location:
                        {
                            pollResponse = Intrim_LocationInProgress;
                            pollEndResponse = Intrim_LocationSuccess;
                            finalGetResponse = Intrim_LocationSuccess;
                        }
                        break;

                    case LroHeaders.Location_And_AzureAsync:
                        {
                            pollResponse = Intrim_AzAsyncHeaderStatusInProgress;
                            pollEndResponse = Intrim_AzAsyncHeaderSuccessResponse;
                            finalGetResponse = Intrim_LocationSuccess;
                        }
                        break;
                }

                for (int i = 0; i <= pollingCount - 1; i++)
                {
                    HttpResponseMessage res = new HttpResponseMessage(pollingStatusCode)
                    {
                        Content = new StringContent(pollResponse)
                    };
                    res = DeleteAddHeaders(res, header);

                    responseList.Add(res);
                }

                if (!string.IsNullOrEmpty(pollEndResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(pollEndResponse)
                    };

                    responseList.Add(res);
                }

                if(!string.IsNullOrEmpty(finalGetResponse))
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(finalGetResponse)
                    };

                    responseList.Add(res);
                }

                return responseList;
            }

            static HttpResponseMessage DeleteAddHeaders(HttpResponseMessage response, LroHeaders headersToAdd)
            {
                switch (headersToAdd)
                {
                    case LroHeaders.AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Delete_AsyncHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location:
                        {
                            response.Headers.Add(LroLocationHeaderName, Delete_LocationHeaderValue_1);
                            break;
                        }
                    case LroHeaders.Location_And_AzureAsync:
                        {
                            response.Headers.Add(LroAsyncHeaderName, Delete_AsyncHeaderValue_1);
                            response.Headers.Add(LroLocationHeaderName, Delete_LocationHeaderValue_1);
                            break;
                        }
                }

                return response;
            }
        }

        internal class AsyncOperationHeader
        {
            #region Initial Response
            internal static string InitialResponse = @"
                        {
                          ""type"": ""Microsoft.ContainerService/ContainerServices"",
                          ""location"": ""australiasoutheast"",
                          ""tags"": {
                            ""RG"": ""rg"",
                            ""testTag"": ""1""
                          },
                          ""id"": ""/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/crptestar9541/providers/Microsoft.ContainerService/containerServices/cs8150"",
                          ""name"": ""cs8150"",
                          ""properties"": {
                            ""provisioningState"": ""Creating"",
                            ""orchestratorProfile"": {
                              ""orchestratorType"": ""DCOS""
                            },
                            ""masterProfile"": {
                              ""count"": 1,
                              ""dnsPrefix"": ""mdp8680"",
                              ""vmSize"": ""Standard_D2""
                            },
                            ""agentPoolProfiles"": [
                              {
                                ""name"": ""AgentPool1"",
                                ""count"": 1,
                                ""vmSize"": ""Standard_A1"",
                                ""dnsPrefix"": ""apdp2498"",
                                ""osType"": ""Linux""
                              }
                            ],
                            ""linuxProfile"": {
                              ""ssh"": {
                                ""publicKeys"": [
                                  {
                                    ""keyData"": ""SomeKeyData""
                                  }
                                ]
                              },
                              ""adminUsername"": ""azureuser""
                            },
                            ""diagnosticsProfile"": {
                              ""vmDiagnostics"": {
                                ""enabled"": ""true""
                              }
                            }
                          }
                        }
                    ";
            #endregion

            #region Intrim Response

            internal static string IntrimPollingResponse = @"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ";

            internal static string PollingCompletedResponse = @"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ";
            #endregion

            #region Final Response
            internal static string AsyncOperationHeaderFinalResource = @"
                    {
                      ""type"": ""Microsoft.ContainerService/ContainerServices"",
                      ""location"": ""australiasoutheast"",
                      ""tags"": {
                        ""RG"": ""rg"",
                        ""testTag"": ""1""
                      },
                      ""id"": ""/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/crptestar9541/providers/Microsoft.ContainerService/containerServices/cs8150"",
                      ""name"": ""cs8150"",
                      ""properties"": {
                        ""provisioningState"": ""Succeeded"",
                        ""orchestratorProfile"": {
                          ""orchestratorType"": ""DCOS""
                        },
                        ""masterProfile"": {
                          ""count"": 1,
                          ""dnsPrefix"": ""mdp8680"",
                          ""fqdn"": ""mdp8680.australiasoutheast.cloudapp.azure.com"",
                          ""vmSize"": ""Standard_D2""
                        },
                        ""agentPoolProfiles"": [
                          {
                            ""name"": ""AgentPool1"",
                            ""count"": 1,
                            ""vmSize"": ""Standard_A1"",
                            ""dnsPrefix"": ""apdp2498"",
                            ""fqdn"": ""apdp2498.australiasoutheast.cloudapp.azure.com"",
                            ""osType"": ""Linux""
                          }
                        ],
                        ""linuxProfile"": {
                          ""ssh"": {
                            ""publicKeys"": [
                              {
                                ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
                              }
                            ]
                          },
                          ""adminUsername"": ""azureuser""
                        },
                        ""diagnosticsProfile"": {
                          ""vmDiagnostics"": {
                            ""enabled"": true,
                            ""storageUri"": ""https:\/\/anh36lyni2ra2diag0.blob.core.windows.net/""      
                          }    
                        }  
                      }
                    }
                ";
            #endregion

            internal static HttpResponseMessage GetResponse(HttpStatusCode statusCode, ResponseKind resKind)
            {
                HttpResponseMessage res = new HttpResponseMessage();
                switch(resKind)
                {
                    case ResponseKind.Initial:
                        res.Content = new StringContent(InitialResponse);
                        break;

                    case ResponseKind.IntrimPolling:
                        res.Content = new StringContent(IntrimPollingResponse);
                        break;

                    case ResponseKind.PostPolling:
                        res.Content = new StringContent(AsyncOperationHeaderFinalResource);
                        break;
                }

                return res;
            }

            internal static HttpResponseMessage GetResponse(HttpStatusCode statusCode, ResponseKind resKind, LroHeaders headers)
            {
                HttpResponseMessage res = GetResponse(statusCode, resKind);
                //res = AddHeaders(res, headers);

                return res;
            }
        }

        internal static class LocationHeader
        {
            #region Initial Response
            internal static string InitialResponse = @"
                        {
                            ""ResponseOrder"": ""1"",
                            ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                            ""location"": ""West Central US"",
                            ""name"": ""RedisCreateUpdate7534"",
                            ""type"": ""Microsoft.Cache/Redis"",
                            ""tags"": {},
                            ""properties"": {
                                ""provisioningState"": ""Creating"",
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
                                ""accessKeys"": {
                                    ""primaryKey"": ""e77DIxNC9kfKnAH0imMFNILFHSCW6BinwFGvHvpOj5U="",
                                    ""secondaryKey"": ""NVzdWjgyhvoOjETlvj5JN+vK8qTXjqGUGYxpfguB8cM=""
                                },
                                ""hostName"": ""RedisCreateUpdate7534.redis.cache.windows.net"",
                                ""port"": 6379,
                                ""sslPort"": 6380,
                                ""linkedServers"": []
                            }
                        }
                    ";
            #endregion

            #region Intrim Response
            internal static string IntrimPollingResponse_1 = @"
                    {
                    ""ResponseOrder"": ""2"",
                    ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                    ""location"": ""West Central US"",
                    ""name"": ""RedisCreateUpdate7534"",
                    ""type"": ""Microsoft.Cache/Redis"",
                    ""tags"": {},
                    ""properties"": {
                        ""provisioningState"": ""Creating"",
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
                ";

            internal static string IntrimPollingResponse_2 = @"
            {
                ""id"": ""https://management.azure.com/subscriptions/1cba1da6-5a83-45e1-a88e-8b397eb84356/providers/Microsoft.BatchAI/locations/eastus/operationresults/b183d70f-25fb-47b3-875e-c3c7b7095823"",
                ""name"": ""b183d70f-25fb-47b3-875e-c3c7b7095823"",
                ""status"": ""InProgress"",
                ""startTime"": ""2018-06-20T22:04:36.271Z""
            }";

            internal static string PollingCompletedResponse = @"
                    {
                        ""ResponseOrder"": ""3"",
                        ""id"": ""/subscriptions/592cc9de-a3cd-4d70-9bc1-c1a28a3625b5/resourceGroups/RedisCreateUpdate3324/providers/Microsoft.Cache/Redis/RedisCreateUpdate7534"",
                        ""location"": ""West Central US"",
                        ""name"": ""RedisCreateUpdate7534"",
                        ""type"": ""Microsoft.Cache/Redis"",
                        ""tags"": {},
                        ""properties"": {
                            ""provisioningState"": ""Succeeded"",
                            ""redisVersion"": ""3.2.7"",
                            ""sku"": {
                                ""name"": ""Basic"",
                                ""family"": ""C"",
                                ""capacity"": 0
                            },
                            ""enableNonSslPort"": false,
                            ""tenantSettings"": {
                                ""InternalDependencyList"": [
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https://wcus2554052479.blob.core.windows.net/""
                                    },
                                    {
                                        ""Type"": ""StorageQueue"",
                                        ""Value"": ""https://wcus2554052479.queue.core.windows.net/""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https://wcusscaleunit5435222359.blob.core.windows.net/""
                                    },
                                    {
                                        ""Type"": ""StorageQueue"",
                                        ""Value"": ""https://wcusscaleunit5435222359.queue.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https://wcusgenevasa834343247016.blob.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""ServiceBus"",
                                        ""Value"": ""wcusgenevasb832359349008.servicebus.windows.net""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https:\/\/wcusgenevasa923230976597.blob.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""ServiceBus"",
                                        ""Value"": ""wcusgenevasb929002419042.servicebus.windows.net""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https:\/\/wcusgenevasa056552918724.blob.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""ServiceBus"",
                                        ""Value"": ""wcusgenevasb058229963395.servicebus.windows.net""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https:\/\/wcusgenevasa951612516970.blob.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""ServiceBus"",
                                        ""Value"": ""wcusgenevasb952816101216.servicebus.windows.net""
                                    },
                                    {
                                        ""Type"": ""StorageBlob"",
                                        ""Value"": ""https:\/\/wcusgenevasa394407896818.blob.core.windows.net""
                                    },
                                    {
                                        ""Type"": ""ServiceBus"",
                                        ""Value"": ""wcusgenevasb398857595686.servicebus.windows.net""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/prod.warmpath.msftcloudes.com""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/WarmPathFEProdWUSc1.cloudapp.net""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/WarmPathFEProdCUSc1.cloudapp.net""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/WarmPathFEProdEUSc1.cloudapp.net""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/WarmPathFEProdWEURc1.cloudapp.net""
                                    },
                                    {
                                        ""Type"": ""MetricsConfigurationService"",
                                        ""Value"": ""https:\/\/WarmPathFEProdEASc1.cloudapp.net""
                                    }
                                ]
                            },
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
                ";
            #endregion

            #region Final Response
            internal static string LH_FinalResource = @"
            {
                ""location"": ""SoutheastAsia"",
                ""properties"": {
                    ""accountType"": ""Standard_GRS""
                }
            }";

            #endregion


            internal static HttpResponseMessage GetResponse(HttpStatusCode statusCode, ResponseKind resKind)
            {
                HttpResponseMessage res = new HttpResponseMessage();
                switch (resKind)
                {
                    case ResponseKind.Initial:
                        res.Content = new StringContent(InitialResponse);
                        break;

                    case ResponseKind.IntrimPolling:
                        res.Content = new StringContent(IntrimPollingResponse_1);
                        break;

                    case ResponseKind.PostPolling:
                        res.Content = new StringContent(LH_FinalResource);
                        break;
                }

                return res;
            }

            internal static HttpResponseMessage GetResponse(HttpStatusCode statusCode, ResponseKind resKind, LroHeaders headers)
            {
                HttpResponseMessage res = GetResponse(statusCode, resKind);
                //res = AddHeaders(res, headers);

                return res;
            }
        }

        internal LroResponseData() { }

        //internal IEnumerable<HttpResponseMessage> GetLroPUTResponse(int pollingResponseCount, bool includeAsyncOperationHeader, 
        //    bool includeLocationHeader, bool includeFinalResponse, 
        //    HttpStatusCode finalResponseStatusCode)
        //{
        //    HttpResponseMessage res = null;

        //    #region Initial Response
        //    res = new HttpResponseMessage(HttpStatusCode.Created)
        //    {
        //        Content = new StringContent(AsyncOperationHeader.InitialResponse)
        //    };
        //    res.Headers.Add(LroAsyncHeaderName, LroAsyncHeaderValue);
        //    #endregion

        //    #region polling
        //    for (int i = 0; i <= pollingResponseCount - 1; i++)
        //    {
        //        if (includeAsyncOperationHeader == true)
        //        {
        //            res = new HttpResponseMessage(HttpStatusCode.Created)
        //            {
        //                Content = new StringContent(AsyncOperationHeader.IntrimPollingResponse)
        //            };
        //            res.Headers.Add(LroAsyncHeaderName, LroAsyncHeaderValue);
        //        }

        //        if (includeLocationHeader == true)
        //        {
        //            res.Headers.Add(LroLocationHeaderName, LroLocationHeaderValue);
        //        }

        //        yield return res;
        //    }

        //    res = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(AsyncOperationHeader.PollingCompletedResponse)
        //    };
        //    yield return res;
        //    #endregion

        //    #region Final Response


        //    #endregion

        //    res = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(AsyncOperationHeader.AsyncOperationHeaderFinalResource)
        //    };
        //    yield return res;
        //}


        internal IEnumerable<HttpResponseMessage> PutLroResponse(int pollingCount, LroHeaders header)
        {
            List<HttpResponseMessage> lroResList = new List<HttpResponseMessage>();
            lroResList.Add(PutResponse.GetResponse(PutResponse.EmptyInitialResponse, HttpStatusCode.Created, header));

            var lroResponses = PutResponse.PollingResponse(header, pollingCount, HttpStatusCode.Created);
            lroResList.AddRange(lroResponses);

            //lroResList.Add(PutResponse.PostPollingResponse(header, HttpStatusCode.OK));
            return lroResList;
        }


        internal IEnumerable<HttpResponseMessage> DeleteLroResponse(int pollingCount, LroHeaders header)
        {
            List<HttpResponseMessage> lroResList = new List<HttpResponseMessage>();

            lroResList.Add(DeleteResponse.GetResponse(DeleteResponse.Initial_EmptyResponse, HttpStatusCode.Accepted, header));
            var deleteLroResponses = DeleteResponse.PollingResponse(header, pollingCount, HttpStatusCode.Accepted);

            lroResList.AddRange(deleteLroResponses);

            return lroResList;
        }

        internal IEnumerable<HttpResponseMessage> PostLroResponse(int pollingCount, LroHeaders header)
        {
            List<HttpResponseMessage> lroResList = new List<HttpResponseMessage>();

            lroResList.Add(PostResponse.GetResponse(PostResponse.EmptyInitialResponse, HttpStatusCode.Accepted, header));
            var postLroResponses = PostResponse.PollingResponse(header, pollingCount, HttpStatusCode.Accepted);

            lroResList.AddRange(postLroResponses);

            return lroResList;
        }

        //static HttpResponseMessage AddHeaders(HttpResponseMessage response, LroHeaders headersToAdd)
        //{
        //    switch (headersToAdd)
        //    {
        //        case LroHeaders.AzureAsync:
        //            {
        //                response.Headers.Add(LroAsyncHeaderName, LroAsyncHeaderValue);
        //                break;
        //            }
        //        case LroHeaders.Location:
        //            {
        //                response.Headers.Add(LroLocationHeaderName, LroLocationHeaderValue);
        //                break;
        //            }
        //        case LroHeaders.Location_And_AzureAsync:
        //            {
        //                response.Headers.Add(LroAsyncHeaderName, LroAsyncHeaderValue);
        //                response.Headers.Add(LroLocationHeaderName, LroLocationHeaderValue);
        //                break;
        //            }
        //    }

        //    return response;
        //}
    }


    enum LroHeaders
    {
        Location,
        AzureAsync,
        Location_And_AzureAsync
    }

    enum ResponseKind
    {
        Initial,
        IntrimPolling,
        PostPolling
    }

}
