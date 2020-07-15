// Copyright (c) Microsoft Corporation. All rights reserved.
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
        public const string AzureSqlMITable = @"
{
    name: ""AzureSqlMITable"",
    properties:
    {
        type: ""AzureSqlMITable"",
        linkedServiceName:
        {
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {
            schema: ""dbo"",
            table: ""test""
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
        public const string CosmosDbSqlApiCollection = @"
{ 
    name: ""CosmosDbSqlApiCollection"", 
    properties: { 
        type: ""CosmosDbSqlApiCollection"", 
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties: { 
            collectionName: ""fake collection""
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
        public const string SalesforceServiceCloudDataset = @"
{
    name: ""SalesforceServiceCloudDataset"",
    properties:
    {
        type: ""SalesforceServiceCloudObject"",
        typeProperties:
        {
            objectApiName: ""fakeObjectApiName""
        },
        linkedServiceName:
        {
            referenceName: ""SalesforceServiceCloudLinkedService"",
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

        [JsonSample]
        public const string SapCloudForCustomerResourceDataset = @"
{
    name: ""SapCloudForCustomerResourceDataset"",
    properties:
    {
        type: ""SapCloudForCustomerResource"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            path: ""LeadCollection""
        }
    }
}
";
        [JsonSample]
        public const string AmazonMWSDataset = @"
{
    name: ""AmazonMWSDataset"",
    properties: {
        type: ""AmazonMWSObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string AzurePostgreSqlDataset = @"
{
    name: ""AzurePostgreSqlDataset"",
    properties: {
        type: ""AzurePostgreSqlTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string ConcurDataset = @"
{
    name: ""ConcurDataset"",
    properties: {
        type: ""ConcurObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string CouchbaseDataset = @"
{
    name: ""CouchbaseDataset"",
    properties: {
        type: ""CouchbaseTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string DrillDataset = @"
{
    name: ""DrillDataset"",
    properties: {
        type: ""DrillTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string EloquaDataset = @"
{
    name: ""EloquaDataset"",
    properties: {
        type: ""EloquaObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string GoogleBigQueryDataset = @"
{
    name: ""GoogleBigQueryDataset"",
    properties: {
        type: ""GoogleBigQueryObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string GreenplumDataset = @"
{
    name: ""GreenplumDataset"",
    properties: {
        type: ""GreenplumTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string HBaseDataset = @"
{
    name: ""HBaseDataset"",
    properties: {
        type: ""HBaseObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string HiveDataset = @"
{
    name: ""HiveDataset"",
    properties: {
        type: ""HiveObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string HubspotDataset = @"
{
    name: ""HubspotDataset"",
    properties: {
        type: ""HubspotObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string ImpalaDataset = @"
{
    name: ""ImpalaDataset"",
    properties: {
        type: ""ImpalaObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string JiraDataset = @"
{
    name: ""JiraDataset"",
    properties: {
        type: ""JiraObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string MagentoDataset = @"
{
    name: ""MagentoDataset"",
    properties: {
        type: ""MagentoObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string MariaDBDataset = @"
{
    name: ""MariaDBDataset"",
    properties: {
        type: ""MariaDBTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string AzureMariaDBDataset = @"
{
    name: ""AzureMariaDBDataset"",
    properties: {
        type: ""AzureMariaDBTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string MarketoDataset = @"
{
    name: ""MarketoDataset"",
    properties: {
        type: ""MarketoObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string PaypalDataset = @"
{
    name: ""PaypalDataset"",
    properties: {
        type: ""PaypalObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string PhoenixDataset = @"
{
    name: ""PhoenixDataset"",
    properties: {
        type: ""PhoenixObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string PrestoDataset = @"
{
    name: ""PrestoDataset"",
    properties: {
        type: ""PrestoObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string QuickBooksDataset = @"
{
    name: ""QuickBooksDataset"",
    properties: {
        type: ""QuickBooksObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string ServiceNowDataset = @"
{
    name: ""ServiceNowDataset"",
    properties: {
        type: ""ServiceNowObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string ShopifyDataset = @"
{
    name: ""ShopifyDataset"",
    properties: {
        type: ""ShopifyObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string SparkDataset = @"
{
    name: ""SparkDataset"",
    properties: {
        type: ""SparkObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string SquareDataset = @"
{
    name: ""SquareDataset"",
    properties: {
        type: ""SquareObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string XeroDataset = @"
{
    name: ""XeroDataset"",
    properties: {
        type: ""XeroObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string ZohoDataset = @"
{
    name: ""ZohoDataset"",
    properties: {
        type: ""ZohoObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";

        [JsonSample]
        public const string SapEccResourceDataset = @"
{
    name: ""SapEccResourceDataset"",
    properties:
    {
        type: ""SapEccResource"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            path: ""dd04tentitySet""
        }
    }
}
";
        [JsonSample]
        public const string NetezzaDataset = @"
{
    name: ""NetezzaDataset"",
    properties: {
        type: ""NetezzaTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string VerticaDataset = @"
{
    name: ""VerticaDataset"",
    properties: {
        type: ""VerticaTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        }
    }
}
";
        [JsonSample]
        public const string SapOpenHubDataset = @"
{
     ""name"": ""SAPBWOpenHubDataset"",
    ""properties"": {
        ""type"": ""SapOpenHubTable"",
        ""linkedServiceName"": {
            ""referenceName"": ""OpenHubLinkedService"",
            ""type"": ""LinkedServiceReference""
        },
        ""typeProperties"": {
            ""openHubDestinationName"": ""fakeOhdName"",
            ""excludeLastRequest"": true,
            ""baseRequestId"": 231
        }
    }
}
";

        [JsonSample]
        public const string RestDataset = @"
{
    ""name"": ""RESTDataset"",
    ""properties"": {
        ""type"": ""RestResource"",
        ""linkedServiceName"": {
            ""referenceName"": ""RestLinkedService"",
            ""type"": ""LinkedServiceReference""
        },
        ""typeProperties"": {
            ""relativeUrl"": ""https://fakeurl/"",
            ""additionalHeaders"": {
                ""x-user-defined"": ""helloworld""
            },
            ""paginationRules"": {
                ""AbsoluteUrl"": ""$.paging.next""
            }
        }
    }
}
";

        [JsonSample]
        public const string AvroDataset = @"
{
  ""name"": ""MyDataset"",
  ""properties"": {
	""type"": ""Avro"",
	""typeProperties"": {
	  ""location"": {
		""type"": ""AzureBlobStorageLocation"",
		""folderPath"": ""fakedContainerName"",
		""fileName"": ""*.avro""
	  },
	  ""avroCompressionCodec"": ""deflate"",
	  ""avroCompressionLevel"": 4
	},
	""linkedServiceName"": {
	  ""referenceName"": ""MyLinkedService"",
	  ""type"": ""LinkedServiceReference""
	},
	""schema"": {
	  ""type"": ""record"",
	  ""namespace"": ""com.example"",
	  ""name"": ""test"",
	  ""fields"": [
		{
		  ""name"": ""first"",
		  ""type"": ""string""
		},
		{
		  ""name"": ""last"",
		  ""type"": ""int""
		},
		{
		  ""name"": ""Hobby"",
		  ""type"": {
			""type"": ""array"",
			""items"": ""string""
		  }
		}
	  ]
	}
  }
}";
        [JsonSample]
        public const string ExcelDataset = @"
{
  ""name"": ""ExcelDataset"",
  ""properties"": {
    ""type"": ""Excel"",
    ""typeProperties"": {
      ""location"": {
        ""type"": ""AzureBlobStorageLocation"",
        ""container"": ""exceltest"",
        ""fileName"": ""releases-1.xlsx""
      },
      ""compression"": {
        ""type"": ""GZip"",
        ""level"": ""Fastest""
      },
      ""sheetName"": ""test01"",
      ""firstRowAsHeader"": true,
      ""range"": ""A4:H9"",
      ""nullValue"": ""N/A""
    },
    ""linkedServiceName"": {
      ""referenceName"": ""MyLinkedService"",
      ""type"": ""LinkedServiceReference""
    },
    ""schema"": [
      {
        ""name"": ""title"",
        ""type"": ""string""
      },
      {
        ""name"": ""movieId"",
        ""type"": ""string""
      }
    ]
  }
}";

        [JsonSample]
        public const string ParquetDataset = @"
{
  ""name"": ""ParquetDataset"",
  ""properties"": {
    ""type"": ""Parquet"",
    ""linkedServiceName"": {
      ""referenceName"": ""AzureBlobStorageLinkedService"",
      ""type"": ""LinkedServiceReference""
    },
    ""typeProperties"": {
      ""location"": {
        ""type"": ""AzureBlobStorageLocation"",
        ""container"": ""ContainerName"",
        ""folderPath"": ""dataflow/test/input"",
        ""fileName"": ""data.parquet""
      },
      ""compressionCodec"": ""gzip""
    },
    ""schema"": [
      {
        ""name"": ""col1"",
        ""type"": ""INT_32""
      },
      {
        ""name"": ""col2"",
        ""type"": ""Decimal"",
        ""precision"": ""38"",
        ""scale"": ""2""
      }
    ]
  }
}";

        [JsonSample]
        public const string SapTableDataset = @"
{
     ""name"": ""SAPBWOpenHubDataset"",
    ""properties"": {
        ""type"": ""SapTableResource"",
        ""linkedServiceName"": {
            ""referenceName"": ""SapTableLinkedService"",
            ""type"": ""LinkedServiceReference""
        },
        ""typeProperties"": {
            ""tableName"": ""fakeTableName""
        }
    }
}
";

        [JsonSample]
        public const string DelimitedText = @"
{
  name: ""MyDelimitedText"",
  properties: {
    type: ""DelimitedText"",
    linkedServiceName: 
    {  
        referenceName : ""ls"",
        type : ""LinkedServiceReference""
    },
    schema: [
      {
        name: ""col1"",
        type: ""INT_32""
      },
      {
        name: ""col2"",
        type: ""Decimal"",
        precision: ""38"",
        scale: ""2""
      }
    ],
    typeProperties: {
      location: {
        type: ""AzureBlobStorageLocation"",
        folderPath: ""test"",
        fileName: ""test01"",
        container: ""xxxx""
      },
      columnDelimiter: ""\n"",
      rowDelimiter: ""\t"",
      encodingName: ""UTF-8"",
      compressionCodec: ""bzip2"",
      compressionLevel: ""Farest"",
      quoteChar: """",
      escapeChar: """",
      firstRowAsHeader: false,
      nullValue: """"
    }
  }
}";

        [JsonSample]
        public const string XmlDataset = @"
{
  name: ""MyXml"",
  properties: {
    type: ""Xml"",
    linkedServiceName: 
    {  
        referenceName : ""ls"",
        type : ""LinkedServiceReference""
    },
    typeProperties: {
        location: {
            type: ""AzureBlobStorageLocation"",
            folderPath: ""testFolder"",
            fileName: ""test.json"",
            container: ""MyContainer""
        },
        encodingName: ""UTF-8"",
        nullValue: ""null"",
        compression: {
            type: ""GZip"",
            level: ""Optimal""
        }
    }
  }
}";

        [JsonSample]
        public const string Json = @"
{
  name: ""MyJson"",
  properties: {
    type: ""Json"",
    linkedServiceName: 
    {  
        referenceName : ""ls"",
        type : ""LinkedServiceReference""
    },
    schema: {
        type: ""object"",
        properties: {
          name: {
            type: ""object"",
            properties: {
              firstName: {
                type: ""string""
              },
              lastName: {
                type: ""string""
              }
            }
          },
          age: {
            type: ""integer""
          }
        }
    },
    typeProperties: {
        location: {
            type: ""AzureBlobStorageLocation"",
            folderPath: ""testFolder"",
            fileName: ""test.json"",
            container: ""MyContainer""
        },
        encodingName: ""UTF-8"",
        compression: {
            type: ""GZip"",
            level: ""Optimal""
        }
    }
  }
}";

        [JsonSample]
        public const string BinaryDataset = @"
{
  ""name"": ""BinaryDataset"",
  ""properties"": {
    ""type"": ""Binary"",
    ""linkedServiceName"": {
      ""referenceName"": ""AzureBlobStorageLinkedService"",
      ""type"": ""LinkedServiceReference""
    },
    ""typeProperties"": {
      ""location"": {
        ""type"": ""AzureBlobStorageLocation"",
        ""container"": ""ContainerName"",
        ""folderPath"": ""dataflow/test/input"",
        ""fileName"": ""data.parquet""
      },
      ""compression"": {
        ""type"": ""Deflate"",
        ""level"": ""Fastest""
      }
    }
  }
}";

        [JsonSample]
        public const string OrcDataset = @"
{
  ""name"": ""OrcDataset"",
  ""properties"": {
    ""type"": ""Orc"",
    ""linkedServiceName"": {
      ""referenceName"": ""AzureBlobStorageLinkedService"",
      ""type"": ""LinkedServiceReference""
    },
    ""typeProperties"": {
      ""location"": {
        ""type"": ""AzureBlobStorageLocation"",
        ""container"": ""ContainerName"",
        ""folderPath"": ""dataflow/test/input"",
        ""fileName"": ""data.orc""
      },
      ""orcCompressionCodec"": ""snappy""
    },
    ""schema"": [
      {
        ""name"": ""col1"",
        ""type"": ""INT_32""
      },
      {
        ""name"": ""col2"",
        ""type"": ""Decimal"",
        ""precision"": ""38"",
        ""scale"": ""2""
      }
    ]
  }
}";

        [JsonSample]
        public const string TeradataDataset = @"
{
  ""name"": ""TeradataDataset"",
  ""properties"": {
    ""type"": ""TeradataTable"",
    ""linkedServiceName"": {
      ""referenceName"": ""TeradataOdbcLinkedService"",
      ""type"": ""LinkedServiceReference""
    },
    ""typeProperties"": {
      ""database"": ""AdventureWorksDW2012"",
      ""table"": ""DimAccount""
    }
  }
}";

        [JsonSample]
        public const string DynamicsCrmEntity = @"
{
  ""name"": ""DynamicsCrmEntity"",
  ""properties"": {
    ""type"": ""DynamicsCrmEntity"",
    ""typeProperties"": {
      ""entityName"": ""test""
    },
    ""linkedServiceName"": {
      ""referenceName"": ""exampleLinkedService"",
      ""type"": ""LinkedServiceReference""
    }
  }
}
";

        [JsonSample]
        public const string CommonDataServiceForAppsEntity = @"
{
  ""name"": ""CommonDataServiceForAppsEntity"",
  ""properties"": {
    ""type"": ""CommonDataServiceForAppsEntity"",
    ""typeProperties"": {
      ""entityName"": ""test""
    },
    ""linkedServiceName"": {
      ""referenceName"": ""exampleLinkedService"",
      ""type"": ""LinkedServiceReference""
    }
  }
}
";

        [JsonSample]
        public const string InformixTable = @"
{
  ""name"": ""InformixTable"",
  ""properties"": {
    ""type"": ""InformixTable"",
    ""typeProperties"": {
      ""tableName"": ""test""
    },
    ""linkedServiceName"": {
      ""referenceName"": ""exampleLinkedService"",
      ""type"": ""LinkedServiceReference""
    }
  }
}
";

        [JsonSample]
        public const string MicrosoftAccessTable = @"
{
  ""name"": ""MicrosoftAccessTable"",
  ""properties"": {
    ""type"": ""MicrosoftAccessTable"",
    ""typeProperties"": {
      ""tableName"": ""test""
    },
    ""linkedServiceName"": {
      ""referenceName"": ""exampleLinkedService"",
      ""type"": ""LinkedServiceReference""
    }
  }
}
";

        [JsonSample]
        public const string AzurePostgreSqlTable = @"
{
    name: ""AzurePostgreSqlTable"",
    properties:
    {
        type: ""AzurePostgreSqlTable"",
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
        public const string MySqlTable = @"
{
    name: ""MySqlTable"",
    properties:
    {
        type: ""MySqlTable"",
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
        public const string AzurePostgreSqlTableAndSchema = @"
        {
            name: ""AzurePostgreSqlTable"",
            properties:
            {
                type: ""AzurePostgreSqlTable"",
                linkedServiceName: 
                {  
                    referenceName : ""ls"",
                    type : ""LinkedServiceReference""
                },
                typeProperties:
                {            
                    table: ""$EncryptedString$MyEncryptedTableName"",
                    schema: ""$EncryptedString$MyEncryptedSchemaName""
                }
            }
        }
        ";

        [JsonSample]
        public const string OdbcTable = @"
        {
            name: ""OdbcTable"",
            properties:
            {
                type: ""OdbcTable"",
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
        public const string AzureDataExplorerTable = @"
        {
            name: ""AzureDataExplorerTable"",
            properties:
            {
                type: ""AzureDataExplorerTable"",
                linkedServiceName: 
                {  
                    referenceName : ""ls"",
                    type : ""LinkedServiceReference""
                }
            }
        }
        ";

        [JsonSample]
        public const string AzureDataExplorerWithTablePropertyTable = @"
        {
            name: ""AzureDataExplorerTable"",
            properties:
            {
                type: ""AzureDataExplorerTable"",
                typeProperties:
                {
                    table: ""myTable""
                },
                linkedServiceName: 
                {  
                    referenceName : ""ls"",
                    type : ""LinkedServiceReference""
                }                
            }
        }
        ";


        [JsonSample]
        public const string SapBwCube = @"
        {
            name: ""SapBwCube"",
            properties:
            {
                type: ""SapBwCube"",
                linkedServiceName: 
                {  
                    referenceName : ""ls"",
                    type : ""LinkedServiceReference""
                }
            }
        }
        ";

        [JsonSample]
        public const string SybaseTable = @"
        {
            name: ""SybaseTable"",
            properties:
            {
                type: ""SybaseTable"",
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
        public const string OracleTableV2 = @"
{
    name: ""OracleTable"",
    properties:
    {
        type: ""OracleTable"",
        description: ""Example of Oracle with parameter, description, and expression"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string AzureSqlTableV2 = @"
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
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string AzureSqlDWTableV2 = @"
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
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";

        [JsonSample]
        public const string SqlServerTableV2 = @"
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
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string DrillDatasetV2 = @"
{
    name: ""DrillDataset"",
    properties: {
        type: ""DrillTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";[JsonSample]
        public const string GoogleBigQueryDatasetV2 = @"
{
    name: ""GoogleBigQueryDataset"",
    properties: {
        type: ""GoogleBigQueryObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            dataset: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string GreenplumDatasetV2 = @"
{
    name: ""GreenplumDataset"",
    properties: {
        type: ""GreenplumTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string HiveDatasetV2 = @"
{
    name: ""HiveDataset"",
    properties: {
        type: ""HiveObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string ImpalaDatasetV2 = @"
{
    name: ""ImpalaDataset"",
    properties: {
        type: ""ImpalaObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string PhoenixDatasetV2 = @"
{
    name: ""PhoenixDataset"",
    properties: {
        type: ""PhoenixObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string PrestoDatasetV2 = @"
{
    name: ""PrestoDataset"",
    properties: {
        type: ""PrestoObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string SparkDatasetV2 = @"
{
    name: ""SparkDataset"",
    properties: {
        type: ""SparkObject"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string VerticaDatasetV2 = @"
{
    name: ""VerticaDataset"",
    properties: {
        type: ""VerticaTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string NetezzaDatasetV2 = @"
{
    name: ""NetezzaDataset"",
    properties: {
        type: ""NetezzaTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string PostgreSqlDataset = @"
{
    name: ""PostgreSqlDataset"",
    properties: {
        type: ""PostgreSqlTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string AmazonRedshiftTableDataset = @"
{
    name: ""AmazonRedshiftTableDataset"",
    properties: {
        type: ""AmazonRedshiftTable"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";
        [JsonSample]
        public const string Db2TableDataset = @"
{
    name: ""Db2TableDataset"",
    properties: {
        type: ""Db2Table"",
        linkedServiceName: {
            referenceName: ""ls"",
            type: ""LinkedServiceReference""
        },
        typeProperties:
        {            
            schema: ""dbo"",
            table: ""testtable""
        }
    }
}
";

        [JsonSample]
        public const string AzureMySqlTableWithTable = @"
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
            table: ""$EncryptedString$MyEncryptedTable""
        }
    }
}
";

        [JsonSample]
        public const string AzureFileStorage = @"
{
    name: ""AzureFileStorageWithTextDataset"",
    properties:
    {
        type: ""DelimitedText"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {
            ""location"": {
                ""type"": ""AzureFileStorageLocation"",
                ""bucketName"": ""bucketname"",
                ""folderPath"": ""folder/subfolder""
            },
            ""columnDelimiter"": "","",
            ""quoteChar"": ""\"""",
            ""firstRowAsHeader"": true,
            ""compressionCodec"": ""gzip""
        },
    }
}";

        [JsonSample]
        public const string GoogleCloudStorageDataset = @"
{
    name: ""GoogleCloudStorageWithTextDataset"",
    properties:
    {
        type: ""DelimitedText"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {
            ""location"": {
                ""type"": ""GoogleCloudStorageLocation"",
                ""bucketName"": ""bucketname"",
                ""folderPath"": ""folder/subfolder""
            },
            ""columnDelimiter"": "","",
            ""quoteChar"": ""\"""",
            ""firstRowAsHeader"": true,
            ""compressionCodec"": ""gzip""
        },
    }
}";

        [JsonSample]
        public const string SharePointOnlineListResource = @"
{
    name: ""SharePointOnlineListResourceDataset"",
    properties:
    {
        type: ""SharePointOnlineListResource"",
        linkedServiceName: 
        {  
            referenceName : ""ls"",
            type : ""LinkedServiceReference""
        },
        typeProperties:
        {            
            listName: ""listName""
        }
    }
}
";
    }
}
