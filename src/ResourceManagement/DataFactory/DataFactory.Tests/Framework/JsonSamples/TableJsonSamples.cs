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
    public class TableJsonSamples
    {
        [JsonSample]
        public const string CustomTable = @"
{
    name: ""CustomTable"",
    properties:
    {
        type: ""CustomDataSet"",
        linkedServiceName: ""MyCustomServiceName"",
        typeProperties:
        {   
            PropertyBagPropertyName1: ""PropertyBagPropertyValue1"",
            propertyBagPropertyName2: ""PropertyBagPropertyValue2""
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        }
    }
}
";

        [JsonSample]
        public const string HDISTable = @"
{
    name: ""TestOut"",
    properties:
    {
        type: ""SqlServerTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        }
    }
}
";

        [JsonSample]
        public const string HDISOracleTable = @"
{
    name: ""TestOut"",
    properties:
    {
        type: ""OracleTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        }
    }
}
";

        [JsonSample]
        public const string PublishedTrueTable = @"
{
    name: ""TestOut"",
    properties:
    {
        type: ""AzureSqlTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        published: ""True"",
        structure:  
        [ 
            { name: ""Id"", type: ""Guid"" },
            { name: ""Username"", type: ""String"" },
            { name: ""Alias"", type: ""String"" },
            { name: ""CreatedTime"", type: ""DateTime"", culture:""en-US"", format: ""MM/dd/yyyy"" },
            { name: ""TotalCount1"", type: ""Int16"" },
            { name: ""TotalCount2"", type: ""Intt32"" },
            { name: ""TotalCount3"", type: ""Int64"" },
            { name: ""somevalue1"", type: ""Decimal"" },
            { name: ""somevalue2"", type: ""Single"" },
            { name: ""somevalue3"", type: ""Timespan"" },
            { name: ""somevalue4"", type: ""DateTimeOffset"" },
            { name: ""somevalue5"", type: ""Enum"" },
            { name: ""somevalue6"", type: ""Boolean"" }
        ],
        typeProperties: 
        {            
            tableName: ""mytablename"",            
        },
        availability: 
        {
            interval: 1, 
            frequency: ""Hour"",
        },
    }
}
";

        [JsonSample]
        public const string PublishedFalseTable = @"
{
    name: ""TestOut"",
    properties:
    {
        type: ""AzureSqlTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        published: ""False"",
        structure:  
        [ 
            { name: ""somecol"", type: ""String"" }
        ],
        typeProperties:
        {            
            tableName: ""mytablename""            
        },
        availability: 
        {
            interval: 1, 
            frequency: ""Hour"",
        },
    }
}
";

        [JsonSample]
        public const string BlobTable = @"
{
    name: ""MyDemoBlob"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: ""MyLinkedServiceName"",
        structure:
        [
            { name: ""PartitionKey"", type: ""Guid"" },
            { name: ""RowKey"", type: ""String"" }, 
            { name: ""Timestamp"", type: ""String"" },
            { name: ""game_id "", type: ""String"" },
        ],
        typeProperties:
        {        
            folderPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time\\{PartitionKey}"",
            fileName: ""TestBlobName"",       

            format:
            {
                type: ""TextFormat"",
                columnDelimiter: "","",
                rowDelimiter: "";"",
                escapeChar: ""#"",
                nullValue: ""\\N"",
                encodingName: ""utf-8""
            },
            partitionedBy:
            [
		        { name: ""PartitionKey"", value: { type: ""DateTime"", date: ""SliceStart"", format: ""yyyy-MM-dd"" } },
            ]
        },
        availability:
        {
            interval: 1, 
            frequency: ""Hour"",
            style: ""StartOfInterval""     
        },
        policy:
        {
                validation:
                {   
                    minimumSizeMB: 200.0
                }
        }
    }
}";

        [JsonSample]
        public const string ExternalTable = @"
{
    name: ""External"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            folderPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time"",
            fileName: ""TestBlobName""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        },
        policy:
        {
            validation:
            {
                minimumSizeMB: 10.0,
            },
            externalData:
            {
                dataDelay: ""00:10:00"",
                retryInterval: ""00:01:00"",
                retryTimeout: ""00:10:00"",
                maximumRetry: 3
            }
        }
    }
}";

        [JsonSample]
        public const string ExternalTable2 = @"
{
    name: ""External"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {                
            folderPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time"",
            fileName: ""TestBlobName""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        },
        external: true,
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
        public const string TableWithValidation = @"
{
    name: ""TableWithValidation"",
    properties:
    {
        type: ""AzureTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            tableName: ""table$Date$Time""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        },
        policy:
        {
            validation:
            {
                minimumRows: 10,
            }
        }
    }
}";

        [JsonSample]
        public const string TableWithLatency = @"
{
    name: ""TableWithLatency"",
    properties:
    {
        type: ""AzureTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            tableName: ""table$Date$Time""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour""
        },
        policy:
        {
            validation:
            {
                minimumRows: 10,
            },
            latency:
            {
                latencyLength: ""00:50:00"",
            }
        }
    }
}";

        [JsonSample]
        public const string TableWithStyle = @"
{
    name: ""TableWithStyle"",
    properties:
    {
        type: ""AzureTable"",
        linkedServiceName: ""MyLinkedServiceName"",
        typeProperties:
        {            
            tableName: ""table$Date$Time""            
        },
        availability:
        {
            offset: ""01:00:00"",
            interval: 1,
            anchorDateTime: ""2014-02-27T12:00:00"",
            frequency: ""Hour"",
            style: ""EndOfInterval""
        },
        policy:
        {
            validation:
            {
                minimumRows: 10
            }
        }
    }
}";

        [JsonSample]
        public const string PartitionTableSample = @"
{
    name: ""DA_PartitionTest"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: ""LinkedService-CuratedWikiData"",
        structure:  
        [ 
            { name: ""slicetimestamp"", type: ""String""},
            { name: ""projectname"", type: ""String""},
            { name: ""pageviews"", type: ""Decimal""}
        ],
        typeProperties:
        {            
            folderPath: ""wikidatagateway/wikisampledataout/{Year}/{Month}/{Day}"",
			fileName: ""{Hour}.csv"",
			partitionedBy: 
			[
				{ name: ""Year"", value: { type: ""DateTime"", date: ""SliceStart"", format: ""yyyy"" } },
				{ name: ""Month"", value: { type: ""DateTime"", date: ""SliceStart"", format: ""MM"" } }, 
				{ name: ""Day"", value: { type: ""DateTime"", date: ""SliceStart"", format: ""dd"" } }, 
				{ name: ""Hour"", value: { type: ""DateTime"", date: ""SliceStart"", format: ""hh"" } } 
			]            
        },
        availability: 
        {
            frequency: ""Hour"",
            interval: 1
        }
    }
}";

        [JsonSample]
        public const string FolderPathTableSample = @"
{
    name: ""DA_PartitionTest"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: ""LinkedService-CuratedWikiData"",
        typeProperties:
        {            
            folderPath: ""wikidatagateway/wikisampledataout/"",
            tableRootLocation: ""wikidatagateway/wikisampledataout/""            
        },
        structure:  
        [ 
            { name: ""slicetimestamp"", type: ""String""},
            { name: ""projectname"", type: ""String""},
            { name: ""pageviews"", type: ""Decimal""}
        ],
        availability: 
        {
            frequency: ""Hour"",
            interval: 1
        }
    }
}";
    }
}
