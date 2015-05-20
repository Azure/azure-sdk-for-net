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
    public class RegisteredComputeTypeJsonSamples
    {
        [JsonSample]
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
        ""typeProperties"": 
            [
                {""name"": ""KeyPairName"", ""required"": ""True"", ""value"":""HadoopClusterKey"", ""type"": ""string""},
                {""name"": ""KeyPairKey"", ""required"": ""True"", ""type"": ""string""}
            ]
    }
}";

        [JsonSample]
        public const string AmazonEMRCompute_WithoutTypeProperties = @"
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
        ]
    }
}";

        [JsonSample]
        public const string AzureHDInsightCompute_BuiltInTransport = @"
{ 
    ""name"": ""AzureHDInsightCompute"", 
    ""properties"": { 
        ""scope"": ""Global"",
        ""transport"": {
            ""type"": ""BuiltIn"", 
            ""transportProtocolVersion"": ""2.0-preview""
        },
        ""supportedActivities"": [
            ""HadoopActivity""
        ]
    }
}";
    }
}
