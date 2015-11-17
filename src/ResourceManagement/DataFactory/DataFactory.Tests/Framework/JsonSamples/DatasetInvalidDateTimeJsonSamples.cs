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
    public class DatasetInvalidDateTimeJsonSamples : JsonSampleCollection<DatasetInvalidDateTimeJsonSamples>
    {
        [JsonSample]
        public const string HDISDataset = @"
{
    name: ""TestOut"",
    properties:
    {
        location:
        {
            type: ""OnPremisesSqlServerTableLocation"",
            tableName: ""$EncryptedString$MyEncryptedTableName"",
            linkedServiceName: ""MyLinkedServiceName""
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""02/27/2013"",
            frequency: ""Hour""
        },
        createTime: ""2014-02-27T12:00:00""
    }
}
";

        [JsonSample]
        public const string ExternalDataset = @"
{
    name: ""External"",
    properties:
    {
    location:
    {
            type: ""AzureBlobLocation"",
        blobPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time"",
        blobName: ""TestBlobName"",
        linkedServiceName: ""MyLinkedServiceName"",
    },
    availability:
    {
        offset: ""01:00:00"",
        interval: 1,
        anchorDateTime: ""2014.02.27"",
        frequency: ""Hour"",
        waitOnExternal:
        {
            dataDelay: ""00:10:00"",
            retryInterval: ""00:01:00"",
            retryTimeout: ""00:10:00"",
            maximumRetry: 3
        },
    },
    policy:
    {
        validation:
        {
            minimumSizeMB: 10.0,
        }
    }
    }
}";

        [JsonSample]
        public const string ExternalDataset2 = @"
{
    name: ""External"",
    properties:
    {
        location:
        {
                type: ""AzureBlobLocation"",
            blobPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time"",
            blobName: ""TestBlobName"",
            linkedServiceName: ""MyLinkedServiceName"",
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T00:00"",
            frequency: ""Hour"",
            waitOnExternal:
            {
            },
        },
        policy:
        {
            validation:
            {
                minimumSizeMB: 10.0,
            }
        }
    }
}";
    }
}
