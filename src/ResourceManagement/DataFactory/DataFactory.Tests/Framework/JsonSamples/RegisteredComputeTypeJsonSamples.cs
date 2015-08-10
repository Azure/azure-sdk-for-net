// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

namespace DataFactory.Tests.Framework.JsonSamples
{
    /// <summary>
    /// Contains Registerd ComputeType JSON samples. Samples added here will automatically be hit by the serialization unit tests. 
    /// </summary>
    public class RegisteredComputeTypeJsonSamples : JsonSampleCollection<RegisteredComputeTypeJsonSamples>
    {
        [JsonSample(propertyBagKeys: new string[]
             {
                "properties.schema.properties.KeyPairName",
                "properties.schema.properties.KeyPairKey"
             })]
        public const string AmazonEMRCompute_ServiceBusTransport = @"
{ 
    ""name"": ""AmazonEMR"", 
    ""properties"": { 
        ""scope"": ""Subscription"",
        ""transport"": {
            ""type"": ""ServiceBus"",
            ""transportProtocolVersion"": ""2.0-preview"",
            ""serviceBusEndpoint"": ""sb://azuredatafactory.servicebus.windows.net/"",
            ""serviceBusSharedAccessKeyName"": ""RootManageSharedAccessKey"",
            ""serviceBusSharedAccessKey"": ""FTTa0PM8="",
            ""activityRequestQueue"": ""http://request.queue.azure.com"",
            ""activityStatusQueue"": ""http://response.queue.azure.com""
        },
        ""supportedActivities"": [
            ""HadoopActivity""
        ],
        ""schema"": {
            ""properties"":{
                ""KeyPairName"": {
                    ""type"": ""string"",
                    ""default"": ""HadoopClusterKey""
                },
                ""KeyPairKey"": {
                    ""type"": ""string""
                }
            },
            ""required"": [ ""KeyPairName"", ""KeyPairKey"" ]
        }
    }
}";

        [JsonSample(propertyBagKeys: new string[]
             {
                "properties.schema.properties.KeyPairName",
                "properties.schema.properties.KeyPairKey"
             })]
        public const string AmazonEMRCompute_ServiceBusTransport_NestedPropertiesAndDefinitions = @"
{ 
    ""name"": ""AmazonEMR"", 
    ""properties"": { 
        ""scope"": ""Subscription"",
        ""transport"": {
            ""type"": ""ServiceBus"",
            ""transportProtocolVersion"": ""2.0-preview"",
            ""serviceBusEndpoint"": ""sb://azuredatafactory.servicebus.windows.net/"",
            ""serviceBusSharedAccessKeyName"": ""RootManageSharedAccessKey"",
            ""serviceBusSharedAccessKey"": ""FTTa0PM8="",
            ""activityRequestQueue"": ""http://request.queue.azure.com"",
            ""activityStatusQueue"": ""http://response.queue.azure.com""
        },
        ""supportedActivities"": [
            ""HadoopActivity""
        ],
        ""schema"": {
            ""properties"":{
                ""KeyPairName"": {
                    ""type"": ""object"",
                    ""properties"":{
                        ""prop1"":
                            {   
                                ""type"": ""string"",
                                ""default"":""HadoopClusterKey"",
                            }
                    },
                    ""required"":[ ""prop1"" ],
                    ""type"": ""string"",
                    ""default"": ""HadoopClusterKey""
                },
                ""KeyPairKey"": {
                    ""type"": ""string""
                },
                ""switches"":{
                }
            },
            ""required"": [ ""KeyPairName"", ""KeyPairKey"" ],
            ""definitions"":{
                ""switches"" :{
                    ""type"": ""object"",
                    ""properties"":{
                        ""switchProp"":{
                            ""type"": ""integer"",
                            ""default"": 1
                        }
                    },
                    ""required"": [ ""switchProp"" ]
                }
            }
        }
    }
}";
    }
}
