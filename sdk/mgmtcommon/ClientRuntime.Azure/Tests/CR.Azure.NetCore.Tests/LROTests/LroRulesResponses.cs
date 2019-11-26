// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.LROTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public class LroRules
    {
        /// <summary>
        /// 
        /// </summary>
        public class PUTResponses
        {
            #region const
            /// <summary>
            /// 
            /// </summary>
            public const string status201_AzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.ContainerService/locations/australiasoutheast/operations/0adae43a-6224-4e9b-9452-89809d7e41f5?api-version=2017-01-31";

            /// <summary>
            /// 
            /// </summary>
            public const string status201_LocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_AzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?api-version=2017-03-30";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_LocationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?monitor=true&api-version=2017-03-30";
            //"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.Storage/locations/southeastasia/asyncoperations/45bc1627-1cc1-4df7-9209-56f9a77bc04e?monitor=true&api-version=2015-06-15"

            /// <summary>
            /// 
            /// </summary>
            public const string AltLocationHeaderUrl = @"https://custom.com";
            #endregion

            #region Case 1 (201 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
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
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status201_AzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }

            #endregion

            #region Case 2 (201 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
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
                    ")
                };
                response1.Headers.Add("Location", status201_LocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 3 (201 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                response1.Headers.Add("Location", AltLocationHeaderUrl);
                response1.Headers.Add("Azure-AsyncOperation", status201_AzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }

            #endregion

            #region Case 4 (201 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeaders201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""properties"": { 
                              ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                              ""provisioningState"": ""InProgress"",
                              ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                         }
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }

            #endregion


            #region Case 5 (202 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                       {
                          ""sku"": {
                            ""name"": ""Standard_LRS""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https: \/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""provisioningState"": ""Updating"",
                            ""isArmResource"": true
                          },
                          ""location"": ""westcentralus""
                        }
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_AzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2017-04-21T11: 39: 23.6625047-07: 00"",
                      ""endTime"": ""2017-04-21T11: 39: 24.4129092-07: 00"",
                      ""status"": ""Succeeded"",
                      ""properties"": {
                        ""output"": {
                          ""sku"": {
                            ""name"": ""Standard_LRS"",
                            ""tier"": ""Standard""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                            ""provisioningState"": ""Succeeded"",
                            ""diskState"": ""Unattached""
                          },
                          ""type"": ""Microsoft.Compute/disks"",
                          ""location"": ""westcentralus"",
                          ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                          ""name"": ""diskrp2765""
                        }
                      },
                      ""name"": ""2e1f6b10-a489-466c-a471-934f5271e918""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""sku"": {
                        ""name"": ""Standard_LRS"",
                        ""tier"": ""Standard""
                      },
                      ""properties"": {
                        ""osType"": ""Windows"",
                        ""creationData"": {
                          ""createOption"": ""Empty""
                        },
                        ""diskSizeGB"": 10,
                        ""encryptionSettings"": {
                          ""enabled"": true,
                          ""diskEncryptionKey"": {
                            ""sourceVault"": {
                              ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                            },
                            ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                          }
                        },
                        ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                        ""provisioningState"": ""Succeeded"",
                        ""diskState"": ""Unattached""
                      },
                      ""type"": ""Microsoft.Compute/disks"",
                      ""location"": ""westcentralus"",
                      ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                      ""name"": ""diskrp2765""
                    }
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 6 (202 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                        {}                          
                    ")
                };
                response1.Headers.Add("Location", status202_LocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""location"": ""SoutheastAsia"",
                          ""properties"": {
                            ""accountType"": ""Standard_GRS""
                          }
                    }
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 7 (202 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                       {
                          ""sku"": {
                            ""name"": ""Standard_LRS""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https: \/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""provisioningState"": ""Updating"",
                            ""isArmResource"": true
                          },
                          ""location"": ""westcentralus""
                        }
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_AzureAsyncOperationHeaderUrl);
                response1.Headers.Add("Location", status202_LocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2017-04-21T11: 39: 23.6625047-07: 00"",
                      ""endTime"": ""2017-04-21T11: 39: 24.4129092-07: 00"",
                      ""status"": ""Succeeded"",
                      ""properties"": {
                        ""output"": {
                          ""sku"": {
                            ""name"": ""Standard_LRS"",
                            ""tier"": ""Standard""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                            ""provisioningState"": ""Succeeded"",
                            ""diskState"": ""Unattached""
                          },
                          ""type"": ""Microsoft.Compute/disks"",
                          ""location"": ""westcentralus"",
                          ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                          ""name"": ""diskrp2765""
                        }
                      },
                      ""name"": ""2e1f6b10-a489-466c-a471-934f5271e918""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""sku"": {
                        ""name"": ""Standard_LRS"",
                        ""tier"": ""Standard""
                      },
                      ""properties"": {
                        ""osType"": ""Windows"",
                        ""creationData"": {
                          ""createOption"": ""Empty""
                        },
                        ""diskSizeGB"": 10,
                        ""encryptionSettings"": {
                          ""enabled"": true,
                          ""diskEncryptionKey"": {
                            ""sourceVault"": {
                              ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                            },
                            ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                          }
                        },
                        ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                        ""provisioningState"": ""Succeeded"",
                        ""diskState"": ""Unattached""
                      },
                      ""type"": ""Microsoft.Compute/disks"",
                      ""location"": ""westcentralus"",
                      ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                      ""name"": ""diskrp2765""
                    }
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 8 (202 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeaders202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""properties"": { 
                              ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                              ""provisioningState"": ""InProgress"",
                              ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                         }
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }

            #endregion


            #region Case 9 (200 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync200()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_AzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                    }            
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2017-04-21T11: 39: 23.6625047-07: 00"",
                      ""endTime"": ""2017-04-21T11: 39: 24.4129092-07: 00"",
                      ""status"": ""Succeeded"",
                      ""properties"": {
                        ""output"": {
                          ""sku"": {
                            ""name"": ""Standard_LRS"",
                            ""tier"": ""Standard""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                            ""provisioningState"": ""Succeeded"",
                            ""diskState"": ""Unattached""
                          },
                          ""type"": ""Microsoft.Compute/disks"",
                          ""location"": ""westcentralus"",
                          ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                          ""name"": ""diskrp2765""
                        }
                      },
                      ""name"": ""2e1f6b10-a489-466c-a471-934f5271e918""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""sku"": {
                        ""name"": ""Standard_LRS"",
                        ""tier"": ""Standard""
                      },
                      ""properties"": {
                        ""osType"": ""Windows"",
                        ""creationData"": {
                          ""createOption"": ""Empty""
                        },
                        ""diskSizeGB"": 10,
                        ""encryptionSettings"": {
                          ""enabled"": true,
                          ""diskEncryptionKey"": {
                            ""sourceVault"": {
                              ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                            },
                            ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                          }
                        },
                        ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                        ""provisioningState"": ""Succeeded"",
                        ""diskState"": ""Unattached""
                      },
                      ""type"": ""Microsoft.Compute/disks"",
                      ""location"": ""westcentralus"",
                      ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                      ""name"": ""diskrp2765""
                    }
                ")
                };
                yield return response4;
            }

            #endregion

            #region Case 10 (200 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location200()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                response1.Headers.Add("Location", status202_LocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""location"": ""SoutheastAsia"",
                          ""properties"": {
                            ""accountType"": ""Standard_GRS""
                          }
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""location"": ""SoutheastAsia"",
                          ""properties"": {
                            ""accountType"": ""Standard_GRS""
                          }
                    }
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 11 (200 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync200()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                response1.Headers.Add("Location", AltLocationHeaderUrl);
                response1.Headers.Add("Azure-AsyncOperation", status202_AzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2017-04-21T11: 39: 23.6625047-07: 00"",
                      ""endTime"": ""2017-04-21T11: 39: 24.4129092-07: 00"",
                      ""status"": ""Succeeded"",
                      ""properties"": {
                        ""output"": {
                          ""sku"": {
                            ""name"": ""Standard_LRS"",
                            ""tier"": ""Standard""
                          },
                          ""properties"": {
                            ""osType"": ""Windows"",
                            ""creationData"": {
                              ""createOption"": ""Empty""
                            },
                            ""diskSizeGB"": 10,
                            ""encryptionSettings"": {
                              ""enabled"": true,
                              ""diskEncryptionKey"": {
                                ""sourceVault"": {
                                  ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                                },
                                ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                              }
                            },
                            ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                            ""provisioningState"": ""Succeeded"",
                            ""diskState"": ""Unattached""
                          },
                          ""type"": ""Microsoft.Compute/disks"",
                          ""location"": ""westcentralus"",
                          ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                          ""name"": ""diskrp2765""
                        }
                      },
                      ""name"": ""2e1f6b10-a489-466c-a471-934f5271e918""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""sku"": {
                        ""name"": ""Standard_LRS"",
                        ""tier"": ""Standard""
                      },
                      ""properties"": {
                        ""osType"": ""Windows"",
                        ""creationData"": {
                          ""createOption"": ""Empty""
                        },
                        ""diskSizeGB"": 10,
                        ""encryptionSettings"": {
                          ""enabled"": true,
                          ""diskEncryptionKey"": {
                            ""sourceVault"": {
                              ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault""
                            },
                            ""secretUrl"": ""https:\/\/swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088""
                          }
                        },
                        ""timeCreated"": ""2017-04-21T11: 39: 24.2722176-07: 00"",
                        ""provisioningState"": ""Succeeded"",
                        ""diskState"": ""Unattached""
                      },
                      ""type"": ""Microsoft.Compute/disks"",
                      ""location"": ""westcentralus"",
                      ""id"": ""/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crptestar3104/providers/Microsoft.Compute/disks/diskrp2765"",
                      ""name"": ""diskrp2765""
                    }
                ")
                };
                yield return response3;
            }

            #endregion

            #region Case 12 (200 + No Header provided but responses are similar to Azure-AsyncOperation)
            internal static IEnumerable<HttpResponseMessage> NoHeaders200Success()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""properties"": {
                              ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                              ""provisioningState"": ""InProgress"",
                              ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                            }
                        }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }

            #endregion

            #region Case 13 (200 + No Header pass through)
            internal static IEnumerable<HttpResponseMessage> NoHeader200PassThrough()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                                    ""keyData"": ""ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgESgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4bL acs-bot@microsoft.com""
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
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                          ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                          ""status"": ""InProgress"",
                          ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                        }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                            ""startTime"": ""2018-02-08T17: 17: 43.4257988-08: 00"",
                            ""endTime"": ""2018-02-08T17: 24: 28.3142823-08: 00"",
                            ""status"": ""Succeeded"",
                            ""name"": ""0adae43a-6224-4e9b-9452-89809d7e41f5""
                        }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
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
                ")
                };
                yield return response4;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public class POSTResponses
        {
            #region const
            /// <summary>
            /// 
            /// </summary>
            public const string status201_PostAzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.ContainerService/locations/australiasoutheast/operations/0adae43a-6224-4e9b-9452-89809d7e41f5?api-version=2017-01-31";

            /// <summary>
            /// 
            /// </summary>
            public const string status201_PostLocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_PostAzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?api-version=2017-03-30";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_PostLocationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?monitor=true&api-version=2017-03-30";

            /// <summary>
            /// 
            /// </summary>
            public const string AltLocationHeaderUrl = @"https://custom.com";

            #endregion

            #region Case 1 (201 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 2 (201 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {
                          ""odata.metadata"": ""https:\/\/graph.windows.net/1273adef-00a3-4086-a51a-dbcce1857d36/$metadata#directoryObjects/Microsoft.DirectoryServices.Group/@Element"",
                          ""odata.type"": ""Microsoft.DirectoryServices.Group"",
                          ""objectType"": ""Group"",
                          ""objectId"": ""cd3a90e9-f8c5-4f6a-847c-55693727d37b"",
                          ""deletionTimestamp"": null,
                          ""description"": null,
                          ""dirSyncEnabled"": null,
                          ""displayName"": ""testGroup005e51afb-ea56-4276-b1cb-dde04de6318b"",
                          ""lastDirSyncTime"": null,
                          ""mail"": null,
                          ""mailNickname"": ""testGroup005e51afb-ea56-4276-b1cb-dde04de6318btester"",
                          ""mailEnabled"": false,
                          ""onPremisesSecurityIdentifier"": null,
                          ""provisioningErrors"": [],
                          ""proxyAddresses"": [],
                          ""securityEnabled"": true
                        }
                    ")
                };
                response1.Headers.Add("Location", status201_PostLocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                    {
                      ""odata.metadata"": ""https:\/\/graph.windows.net/1273adef-00a3-4086-a51a-dbcce1857d36/$metadata#directoryObjects/Microsoft.DirectoryServices.Group/@Element"",
                      ""odata.type"": ""Microsoft.DirectoryServices.Group"",
                      ""objectType"": ""Group"",
                      ""objectId"": ""ac9297d4-5ec6-470b-9f77-466b3767094a"",
                      ""deletionTimestamp"": null,
                      ""description"": null,
                      ""dirSyncEnabled"": null,
                      ""displayName"": ""testGroup18d7444f3-3f4c-457f-8ace-c67a5f096e86"",
                      ""lastDirSyncTime"": null,
                      ""mail"": null,
                      ""mailNickname"": ""testGroup18d7444f3-3f4c-457f-8ace-c67a5f096e86tester"",
                      ""mailEnabled"": false,
                      ""onPremisesSecurityIdentifier"": null,
                      ""provisioningErrors"": [],
                      ""proxyAddresses"": [],
                      ""securityEnabled"": true
                    }
                ")
                };
                response1.Headers.Add("Location", status201_PostLocationHeaderUrl);
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 3 (201 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 4 (201 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeader201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion


            #region Case 5 (202 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_PostAzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response3;
            }
            #endregion

            #region Case 6 (202 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                        {""Id"": ""5a8dbc9350f4b8121cab0000""}                          
                    ")
                };
                response1.Headers.Add("Location", status202_PostLocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    { }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                        ""id"": ""/subscriptions/bab08e11-7b12-4354-9fd1-4b5d64d40b68/resourceGroups/Api-Default-CentralUS/providers/Microsoft.ApiManagement/service/sdktestservice"",
                        ""name"": ""sdktestservice"",
                        ""type"": ""Microsoft.ApiManagement/service"",
                        ""tags"": {
                        ""tag1"": ""value1"",
                        ""tag2"": ""value2"",
                        ""tag3"": ""value3""
                        },
                        ""location"": ""Central US"",
                        ""etag"": ""AAAAAADgrmk="",
                        ""properties"": {
                        ""publisherEmail"": ""apim@autorestsdk.com"",
                        ""publisherName"": ""autorestsdk"",
                        ""notificationSenderEmail"": ""apimgmt-noreply@mail.windowsazure.com"",
                        ""provisioningState"": ""Succeeded"",
                        ""targetProvisioningState"": """",
                        ""createdAtUtc"": ""2017-06-16T19: 08: 53.4371217Z"",
                        ""gatewayUrl"": ""https:\/\/sdktestservice.azure-api.net"",
                        ""gatewayRegionalUrl"": ""https:\/\/sdktestservice-centralus-01.regional.azure-api.net"",
                        ""portalUrl"": ""https:\/\/sdktestservice.portal.azure-api.net"",
                        ""managementApiUrl"": ""https:\/\/sdktestservice.management.azure-api.net"",
                        ""scmUrl"": ""https:\/\/sdktestservice.scm.azure-api.net"",
                        ""hostnameConfigurations"": [],
                        ""publicIPAddresses"": [
                            ""52.173.77.113""
                        ],
                        ""privateIPAddresses"": null,
                        ""additionalLocations"": null,
                        ""virtualNetworkConfiguration"": null,
                        ""customProperties"": null,
                        ""virtualNetworkType"": ""None"",
                        ""certificates"": null
                        },
                        ""sku"": {
                        ""name"": ""Developer"",
                        ""capacity"": 1
                        },
                        ""identity"": null
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                   {
                      ""id"": ""/subscriptions/bab08e11-7b12-4354-9fd1-4b5d64d40b68/resourceGroups/Api-Default-CentralUS/providers/Microsoft.ApiManagement/service/sdktestservice"",
                      ""name"": ""sdktestservice"",
                      ""type"": ""Microsoft.ApiManagement/service"",
                      ""tags"": {
                        ""tag1"": ""value1"",
                        ""tag2"": ""value2"",
                        ""tag3"": ""value3""
                      },
                      ""location"": ""Central US"",
                      ""etag"": ""AAAAAADgrmk="",
                      ""properties"": {
                        ""publisherEmail"": ""apim@autorestsdk.com"",
                        ""publisherName"": ""autorestsdk"",
                        ""notificationSenderEmail"": ""apimgmt-noreply@mail.windowsazure.com"",
                        ""provisioningState"": ""Succeeded"",
                        ""targetProvisioningState"": """",
                        ""createdAtUtc"": ""2017-06-16T19: 08: 53.4371217Z"",
                        ""gatewayUrl"": ""https:\/\/sdktestservice.azure-api.net"",
                        ""gatewayRegionalUrl"": ""https:\/\/sdktestservice-centralus-01.regional.azure-api.net"",
                        ""portalUrl"": ""https:\/\/sdktestservice.portal.azure-api.net"",
                        ""managementApiUrl"": ""https:\/\/sdktestservice.management.azure-api.net"",
                        ""scmUrl"": ""https:\/\/sdktestservice.scm.azure-api.net"",
                        ""hostnameConfigurations"": [],
                        ""publicIPAddresses"": [
                          ""52.173.77.113""
                        ],
                        ""privateIPAddresses"": null,
                        ""additionalLocations"": null,
                        ""virtualNetworkConfiguration"": null,
                        ""customProperties"": null,
                        ""virtualNetworkType"": ""None"",
                        ""certificates"": null
                      },
                      ""sku"": {
                        ""name"": ""Developer"",
                        ""capacity"": 1
                      },
                      ""identity"": null
                    }
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 7 (202 + Location and Azure-AsyncOperation Header)
            //SDKs\SqlManagement\Sql.Tests\SessionRecords\Sql.Tests.DatabaseActivationScenarioTests\TestPauseResumeDatabase.json
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {
                          ""operation"": ""DeactivateDatabaseAsync"",
                          ""startTime"": ""2018-02-09T06: 12: 41.178Z""
                        }
                    ")
                };
                response1.Headers.Add("Location", AltLocationHeaderUrl);
                response1.Headers.Add("Azure-AsyncOperation", status201_PostAzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""operationId"": ""b1362f58-d06b-46cc-8258-d29b54f91a2c"",
                      ""status"": ""InProgress"",
                      ""error"": null
                    }
                ")
                };
                response2.Headers.Add("Azure-AsyncOperation", status201_PostAzureAsyncOperationHeaderUrl);
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""operationId"": ""b1362f58-d06b-46cc-8258-d29b54f91a2c"",
                      ""status"": ""InProgress"",
                      ""error"": null
                    }
                ")
                };
                response2.Headers.Add("Azure-AsyncOperation", status201_PostAzureAsyncOperationHeaderUrl);
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                                        {
                      ""operationId"": ""b1362f58-d06b-46cc-8258-d29b54f91a2c"",
                      ""status"": ""Succeeded"",
                      ""error"": null
                    }
                ")
                };
                yield return response4;

                var response5 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                        {
                          ""id"": ""/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/sqlcrudtest-5038/providers/Microsoft.Sql/servers/sqlcrudtest-1103/databases/sqlcrudtest-5439"",
                          ""name"": ""sqlcrudtest-5439"",
                          ""type"": ""Microsoft.Sql/servers/databases"",
                          ""location"": ""Japan East"",
                          ""kind"": ""v12.0,user,datawarehouse"",
                          ""properties"": {
                            ""databaseId"": ""00f3e474-516f-4b26-ab59-8364978ec99e"",
                            ""edition"": ""DataWarehouse"",
                            ""status"": ""Paused"",
                            ""serviceLevelObjective"": ""DW100"",
                            ""collation"": ""SQL_Latin1_General_CP1_CI_AS"",
                            ""maxSizeBytes"": ""263882790666240"",
                            ""creationDate"": ""2018-02-09T06: 10: 09.527Z"",
                            ""currentServiceObjectiveId"": ""4e63cb0e-91b9-46fd-b05c-51fdd2367618"",
                            ""requestedServiceObjectiveId"": ""4e63cb0e-91b9-46fd-b05c-51fdd2367618"",
                            ""requestedServiceObjectiveName"": ""DW100"",
                            ""sampleName"": null,
                            ""defaultSecondaryLocation"": ""Japan West"",
                            ""earliestRestoreDate"": null,
                            ""elasticPoolName"": null,
                            ""containmentState"": 2,
                            ""readScale"": ""Disabled"",
                            ""failoverGroupId"": null,
                            ""zoneRedundant"": false,
                            ""isUpgradeRequested"": false
                          },
                          ""operationId"": ""b1362f58-d06b-46cc-8258-d29b54f91a2c""
                        }
                ")
                };
                yield return response5;
            }
            #endregion

            #region Case 8 (202 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeader202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion


            #region Case 9 (202 + Location and Azure-AsyncOperation Header with empty responses)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync202EmptyResponse()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Location", AltLocationHeaderUrl);
                response1.Headers.Add("Azure-AsyncOperation", status201_PostAzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T15: 58: 53.0355309-08: 00"",
                      ""endTime"": ""2018-02-08T15: 59: 05.9579892-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""97a8befb-bb51-48a3-941b-f483ea09e43f""
                    }
                ")
                };
                yield return response3;

                //var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new StringContent(@"
                //    {
                //      ""startTime"": ""2018-02-08T15: 58: 53.0355309-08: 00"",
                //      ""endTime"": ""2018-02-08T15: 59: 05.9579892-08: 00"",
                //      ""status"": ""Succeeded"",
                //      ""name"": ""97a8befb-bb51-48a3-941b-f483ea09e43f""
                //    }
                //")
                //};
                //yield return response4;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        public class DELETEResponses
        {
            #region const
            /// <summary>
            /// 
            /// </summary>
            public const string status201_DelAzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.ContainerService/locations/australiasoutheast/operations/0adae43a-6224-4e9b-9452-89809d7e41f5?api-version=2017-01-31";

            /// <summary>
            /// 
            /// </summary>
            public const string status201_DelLocationHeaderUrl = @"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/resourceGroups/RedisCreateUpdate2536/providers/Microsoft.Cache/redis/RedisCreateUpdate9076?api-version=2017-10-01";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_DelAzureAsyncOperationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?api-version=2017-03-30";

            /// <summary>
            /// 
            /// </summary>
            public const string status202_DelLocationHeaderUrl = @"https://management.azure.com/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/providers/Microsoft.Compute/locations/westcentralus/DiskOperations/2e1f6b10-a489-466c-a471-934f5271e918?monitor=true&api-version=2017-03-30";
            //"https://management.azure.com/subscriptions/c9cbd920-c00c-427c-852b-8aaf38badaeb/providers/Microsoft.Storage/locations/southeastasia/asyncoperations/45bc1627-1cc1-4df7-9209-56f9a77bc04e?monitor=true&api-version=2015-06-15"

            /// <summary>
            /// 
            /// </summary>
            public const string AltLocationHeaderUrl = @"https://custom.com";

            #endregion

            #region Case 1 (201 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status201_DelAzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response3;
            }
            #endregion

            #region Case 2 (201 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Location", status201_DelLocationHeaderUrl);
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
                        ""provisioningState"": ""Succeeded"",
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

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 3 (201 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Location", status201_DelLocationHeaderUrl);
                response1.Headers.Add("Azure-AsyncOperation", status201_DelAzureAsyncOperationHeaderUrl);
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
                        ""provisioningState"": ""Succeeded"",
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

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 4 (201 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeader201()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case (201 + Location Header + Final GET 404)
            internal static IEnumerable<HttpResponseMessage> Location201FinalGet404()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Location", status201_DelLocationHeaderUrl);
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
                        ""provisioningState"": ""Succeeded"",
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

            #region Case 5 (202 + Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> AzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_DelAzureAsyncOperationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response3;
            }
            #endregion

            #region Case 6 (202 + Location Header)
            internal static IEnumerable<HttpResponseMessage> Location202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Location", status202_DelLocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 7 (202 + Location and Azure-AsyncOperation Header)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_DelAzureAsyncOperationHeaderUrl);
                response1.Headers.Add("Location", status202_DelLocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion

            #region Case 8 (202 + No Header provided)
            internal static IEnumerable<HttpResponseMessage> NoHeader202()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response3;

                var response4 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {}
                ")
                };
                yield return response4;
            }
            #endregion


            #region Case 9 (202 + Location and Azure-AsyncOperation Header + Final GET 404)
            internal static IEnumerable<HttpResponseMessage> LocationAndAzAsync202FinalGet404()
            {
                var response1 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                      {}  
                    ")
                };
                response1.Headers.Add("Azure-AsyncOperation", status202_DelAzureAsyncOperationHeaderUrl);
                response1.Headers.Add("Location", status202_DelLocationHeaderUrl);
                yield return response1;

                var response2 = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""status"": ""InProgress"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
                    }
                ")
                };
                yield return response2;

                var response3 = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(@"
                    {
                      ""startTime"": ""2018-02-08T10: 16: 58.8457489-08: 00"",
                      ""endTime"": ""2018-02-08T10: 20: 09.9419477-08: 00"",
                      ""status"": ""Succeeded"",
                      ""name"": ""64a21a0a-1d9f-43fb-aa97-17a80e232636""
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
            
        }
    }
}
