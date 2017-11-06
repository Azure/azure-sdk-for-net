﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class DatasetJsonSamples : JsonSampleCollection<DatasetJsonSamples>
    {
        [JsonSample]
        public const string AzureBlob = @"
{
    name: ""MyDemoBlob"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        structure:
        [
            { name: ""PartitionKey"", type: ""Guid"" },
            { name: ""RowKey"", type: ""String"" }, 
            { name: ""Timestamp"", type: ""String"" },
            { name: ""game_id "", type: ""String"" },
            { name: ""date"", type: ""Datetime"" }
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
            }
        }
    }
}";

        [JsonSample]
        public const string AzureTable = @"
{
    name: ""TableWithLatency"",
    properties:
    {
        type: ""AzureTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""table$Date$Time""
        }
    }
}";

        [JsonSample]
        public const string AzureSqlTable = @"
{
    name: ""AzureSqlTable"",
    properties:
    {
        type: ""AzureSqlTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""
        }
    }
}
";

        [JsonSample]
        public const string AzureSqlDWTable = @"
{
    name: ""AzureSqlDWTable"",
    properties:
    {
        type: ""AzureSqlDWTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""
        }
    }
}
";

        [JsonSample]
        public const string SqlServerTable = @"
{
    name: ""SqlServerTable"",
    properties:
    {
        type: ""SqlServerTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""
        }
    }
}
";

        [JsonSample]
        public const string CustomDataset = @"
{
    name: ""CustomTable"",
    properties:
    {
        type: ""CustomDataset"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {   
            PropertyBagPropertyName1: ""PropertyBagPropertyValue1"",
            propertyBagPropertyName2: ""PropertyBagPropertyValue2""
        }
    }
}
";

        [JsonSample]
        public const string OracleTable = @"
{
    name: ""OracleTable"",
    properties:
    {
        type: ""OracleTable"",
        description: ""Example of Oracle with parameter, description, and expression"",
        parameters: {
            StartTime: {
                type: ""String"",
                defaultValue:  ""2017-01-31T00:00:00Z""
            }
        },
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: {
                value: ""@parameters('StartTime')"",
                type: ""Expression""
            }
        }
    }
}
";

        [JsonSample]
        public const string ODataResource = @"
{
    name: ""ODataResourceDataset"",
    properties:
    {
        type: ""ODataResource"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            path: ""path""
        }
    }
}
";

        [JsonSample]
        public const string CassandraTable = @"
{ 
    name: ""CassandraTable"", 
    properties: { 
        type: ""CassandraTable"", 
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            tableName: ""fake table"",
            keyspace: ""fake key space"" 
        }
    }
}
";

        [JsonSample]
        public const string DocumentDbCollection = @"
{ 
    name: ""DocumentDbCollection"", 
    properties: { 
        type: ""DocumentDbCollection"", 
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            collectionName: ""fake table""
        }
    }
}
";

        [JsonSample]
        public const string FileShare = @"
{
    name: ""FileTableWithUseBinaryTransfer"",
    properties:
    {
        type: ""FileShare"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {
            folderPath: ""Root\\MyFolder"",
            fileName: ""TestFileName"",
            format:
            {
                type: ""AvroFormat""
            }
        },
    }
}";

        [JsonSample]
        public const string AmazonS3Dataset = @"
{
    name: ""AmazonS3DatasetforParquet"",
    properties:
    {
        type: ""AmazonS3Object"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            bucketName: ""sample bucket"",
            key: ""sample key"",
            prefix: ""sample prefix"",
            version: ""sample version"",
            format:{
                type:""ParquetFormat""
            },
            compression:
            {
                type: ""Deflate"",
                level: ""Fastest""
            }
        }
    }
}";

        [JsonSample]
        public const string MongoDbCollection = @"
{ 
    name: ""MongoDbTable"", 
    properties: { 
        type: ""MongoDbCollection"", 
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            collectionName: ""fake table""
        }
    }
}
";

        [JsonSample]
        public const string RelationalTable = @"
{
    name: ""RelationalTable"",
    properties:
    {
        type: ""RelationalTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""
        }
    }
}
";

        [JsonSample]
        public const string WebTable = @"
{
    name: ""WebTable"",
    properties:
    {
        type: ""WebTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },        
        typeProperties:
        {        
            index: 1,
            path: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time\\{PartitionKey}""
        }
    }
}";

        [JsonSample]
        public const string AzureDataLakeStoreFile = @"
{ 
    name: ""AzureDataLakeStoreDataset"", 
    properties: { 
        type: ""AzureDataLakeStoreFile"", 
        linkedServiceName:
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            folderPath: ""fakePath"",
            fileName: ""fakeName"",
            format:{
                type:""TextFormat""
            }
        }
    }
}
";
        [JsonSample]
        public const string AzureSearchIndexDataset = @"
{ 
    name: ""AzureSearchIndexDataset"", 
    properties: { 
        type: ""AzureSearchIndex"", 
        linkedServiceName:
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            indexName: ""fakedIndexName""
        }
    }
}
";
        [JsonSample]
        public const string HttpDataset = @"
{ 
    name: ""HttpDataset"", 
    properties: { 
        type: ""HttpFile"", 
        linkedServiceName:
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            relativeUrl: ""fakedUrl"",
            requestMethod: ""get"",
            format:{
                type:""TextFormat""
            }
        }
    }
}
";
        [JsonSample]
        public const string AzureMySqlTable = @"
{
    name: ""AzureMySqlTable"",
    properties:
    {
        type: ""AzureMySqlTable"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            tableName: ""$EncryptedString$MyEncryptedTableName""
        }
    }
}
";
        [JsonSample]
        public const string SalesforceDataset = @"
{
    name: ""SalesforceDataset"",
    properties:
    {
        type: ""SalesforceObject"",
        typeProperties:
        {
            objectApiName: ""fakeObjectApiName""
        },
        linkedServiceName:
        {
            referenceName: ""SalesforceLinkedService"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string BlobTableWithJsonArray = @"
{
    name: ""JsonArrayDataset"",
    properties:
    {
        type: ""AzureBlob"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {        
            folderPath: ""MyContainer\\MySubFolder\\$Date\\$Time\\FileName$Date$Time\\{PartitionKey}"",
            fileName: ""TestBlobName"",
            format:
            {
                type: ""JsonFormat"",
                nestingSeparator: "","",
                filePattern: ""setOfObjects"",
                encodingName: ""utf-8"",
                jsonNodeReference: ""$.root"",
                jsonPathDefinition: {PartitionKey:""$.PartitionKey"", RowKey:""$.RowKey"", p1:""p1"", p2:""p2""}
            }
        }
    }
}";
    }
}
