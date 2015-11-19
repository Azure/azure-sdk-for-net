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
    public class CustomLinkedServiceJsonSamples : JsonSampleCollection<CustomLinkedServiceJsonSamples>
    {
        [JsonSample(version: "RegisteredVersion")]
        public const string RegisteredTypeLinkedService = @"
{
    name: ""My-Linked-Service"",
    properties:
    {
        type: ""MyCustomLinkedServiceType"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
            extraProperty: ""extraPropertyValue""
        }
    }
}
";

        [JsonSample]
        public const string RegisteredCustomLinkedService = @"
{
    name: ""My-Linked-Service"",
    properties:
    {
        type: ""CustomDataSource"",
        typeProperties:
        {
            type: ""MyCustomLinkedServiceType"",
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
            extraProperty: ""extraPropertyValue""
        }
    }
}
";

        [JsonSample]
        public const string UnregisteredCustomLinkedService = @"
{
    name: ""My-Linked-Service"",
    properties:
    {
        type: ""CustomDataSource"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
            extraProperty: ""extraPropertyValue""
        }
    }
}
";

        [JsonSample("ExtraProperties")]
        public const string UnregisteredTypeLinkedService = @"
{
    name: ""My-Linked-Service"",
    properties:
    {
        type: ""MyCustomLinkedServiceType"",
        typeProperties:
        {
            clusterUri: ""https://MyCluster.azurehdinsight.net/"",
            userName: ""MyUserName"",
            password: ""$EncryptedString$MyEncryptedPassword"",
            linkedServiceName: ""MyStorageAssetName"",
            extraProperty: ""extraPropertyValue""
        }
    }
}
";
    }
}
