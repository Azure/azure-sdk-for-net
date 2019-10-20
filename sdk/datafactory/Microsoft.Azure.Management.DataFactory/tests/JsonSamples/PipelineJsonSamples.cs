// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class PipelineJsonSamples : JsonSampleCollection<PipelineJsonSamples>
    {
        [JsonSample]
        public const string CopyActivity = @"
{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""SqlSource""
          },
          ""sink"": {
            ""type"": ""SqlDWSink"",
            ""allowPolyBase"": true,
            ""writeBatchSize"": 0,
            ""writeBatchTimeout"": ""PT0S""
          },
          ""enableStaging"": true,
          ""stagingSettings"": {
            ""linkedServiceName"": {
              ""referenceName"": ""StagingLinkedService"",
              ""type"": ""LinkedServiceReference""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}
";
        [JsonSample]
        public const string CopyActivityWithSkipIncompatibleRows = @" 
{ 
  ""name"": ""MyPipeline"", 
  ""properties"": { 
    ""activities"": [ 
      { 
        ""name"": ""MyActivity"", 
        ""type"": ""Copy"", 
        ""typeProperties"": { 
          ""source"": { 
            ""type"": ""SqlSource"" 
          }, 
          ""sink"": { 
            ""type"": ""SqlDWSink"", 
            ""allowPolyBase"": true, 
            ""writeBatchSize"": 0, 
            ""writeBatchTimeout"": ""PT0S"" 
          }, 
          ""enableStaging"": true, 
          ""stagingSettings"": { 
            ""linkedServiceName"": { 
              ""referenceName"": ""StagingLinkedService"", 
              ""type"": ""LinkedServiceReference"" 
            } 
          }, 
          enableSkipIncompatibleRow: true, 
          redirectIncompatibleRowSettings: { 
            ""linkedServiceName"": { 
              ""referenceName"": ""StagingLinkedService"", 
              ""type"": ""LinkedServiceReference"" 
            }, 
            ""path"": ""fakePath"" 
          } 
        }, 
        ""inputs"": [ 
          { 
            ""referenceName"": ""SourceDataset"", 
            ""type"": ""DatasetReference"" 
          } 
        ], 
        ""outputs"": [ 
          { 
            ""referenceName"": ""SinkDataset"", 
            ""type"": ""DatasetReference"" 
          } 
        ] 
      } 
    ] 
  } 
}";

        [JsonSample]
        public const string HiveActivity = @"
{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""HDInsightHive"",
        ""typeProperties"": {
          ""scriptPath"": ""testing""
        }, 
        ""linkedServiceName"": { ""referenceName"": ""MyLinkedServiceName"", ""type"": ""LinkedServiceReference"" }
      } 
    ]
  }
}
";


        [JsonSample]
        public const string ChainedActivitiesWithParametersPipeline = @"
{
  'properties': {
    'activities': [
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_0_0',
        'inputs': [
          {
            'referenceName': 'MyTestDatasetIn',
            'type': 'DatasetReference'
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS0_0',
            'type': 'DatasetReference'
          }
        ]
      },
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_1_0',
        'dependsOn': [
          {
            'activity': 'MyCopyActivity_0_0',
            'dependencyConditions': [
              'Succeeded'
            ]
          }
        ],
        'inputs': [
          {
            'referenceName': 'MyComplexDS0_0',
            'type': 'DatasetReference'
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS1_0',
            'type': 'DatasetReference'
          }
        ]
      },
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_1_1',
        'dependsOn': [
          {
            'activity': 'MyCopyActivity_0_0',
            'dependencyConditions': [
              'Succeeded', 'Failed', 'Skipped', 'Completed'
            ]
          }
        ],
        'inputs': [
          {
            'referenceName': 'MyComplexDS0_0',
            'type': 'DatasetReference'
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS1_1',
            'type': 'DatasetReference'
          }
        ]
      }
    ],    
    'parameters': {
      'OutputBlobName': {
        'type': 'String'
      }
    }
  }
}
";

        [JsonSample]
        public const string DatasetReferenceArgumentsPipeline = @"
{
  'properties': {
    'activities': [
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_0_0',
        'inputs': [
          {
            'referenceName': 'MyTestDatasetIn',
            'type': 'DatasetReference'
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS',
            'type': 'DatasetReference',
            'parameters': {
              'FileName': {
                'value': ""@concat('variant0_0_', parameters('OutputBlobName'))"",
                'type': 'Expression'
              }
            }
          }
        ]
      },
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_1_0',
        'dependsOn': [
          {
            'activity': 'MyCopyActivity_0_0',
            'dependencyConditions': [
              'Succeeded'
            ]
          }
        ],
        'inputs': [
          {
            'referenceName': 'MyComplexDS',
            'type': 'DatasetReference',
            'parameters': {
              'FileName': {
                'value': ""@concat('variant0_0_', parameters('OutputBlobName'))"",
                'type': 'Expression'
              }
            }
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS',
            'type': 'DatasetReference',
            'parameters': {
              'FileName': {
                'value': ""@concat('variant1_0_', parameters('OutputBlobName'))"",
                'type': 'Expression'
              }
            }
          }
        ]
      },
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity_1_1',
        'dependsOn': [
          {
            'activity': 'MyCopyActivity_0_0',
            'dependencyConditions': [
              'Succeeded', 'Failed', 'Skipped', 'Completed'
            ]
          }
        ],
        'inputs': [
          {
            'referenceName': 'MyComplexDS',
            'type': 'DatasetReference',
            'parameters': {
              'FileName': {
                'value': ""@concat('variant0_0_', parameters('OutputBlobName'))"",
                'type': 'Expression'
              }
            }
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyComplexDS',
            'type': 'DatasetReference',
            'parameters': {
              'FileName': {
                'value': ""@concat('variant1_1_', parameters('OutputBlobName'))"",
                'type': 'Expression'
              }
            }
          }
        ]
      }
    ],
    'parameters': {
      'OutputBlobName': {
        'type': 'String'
      }
    }
  }
}
";

        [JsonSample]
        public const string FullInlinePipeline = @"
{
  'properties': {
    'activities': [
      {
        'type': 'Copy',
        'typeProperties': {
          'source': {
            'type': 'BlobSource'
          },
          'sink': {
            'type': 'BlobSink'
          }
        },
        'name': 'MyCopyActivity',
        'inputs': [
          {
            'referenceName': 'MyTestDatasetIn',
            'type': 'DatasetReference'
          }
        ],
        'outputs': [
          {
            'referenceName': 'MyTestDatasetOut',
            'type': 'DatasetReference'
          }
        ]
      }
    ],
    'parameters': {
      'OutputBlobName': {
        'type': 'String'
      }
    }
  }
}
";

        // Below are adapted from V1 ActivityExtensibleJsonSamples20151001.cs
        // Some systematic differences from V1:
        // 0. no hubName property
        // 1. references to datasets and linked services use objects, not just names
        // 2. activity doesn't have scheduler property
        // 3. activity policy only has timeout, retry, longRetry, longRetryInterval (not concurrency, executionPriorityOrder or delay)
        // 4. pipelines/datasets/linked services can take parameters, pass arguments, and use expressions for most primitive property values
        // 5. pending issue about case sensitivity of property names, see comments about propertyBagKeys
        // 6. no pipeline start, end, isPaused, runtimeInfo properties
        // 7. no inline script for HDI
        // 8. no on-demand HDI

        [JsonSample(version: "Copy")]
        public const string WebTablePipeline = @"
{
    name: ""DataPipeline_WebTableSample"",
    properties:
    {
        activities:
        [
            {
                name: ""WebToBlobCopyActivity"",
                inputs: [ { referenceName: ""DA_Input"", type: ""DatasetReference"" } ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""WebSource"",
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "SqlServerStoredProcedure")]
        // Original had a propertyBagKeys collection for the paths to the sproc params (Text and TEXT) which should be case sensitive
        public const string SprocPipeline = @"
{
    name: ""DataPipeline_SqlServerStoredProcedureSample"",
    properties:
    {
        activities:
        [
            {
                type: ""SqlServerStoredProcedure"",
                typeProperties: {
                    storedProcedureName: ""MERGE_PROC"",
                    storedProcedureParameters: {
                        param1 : { 
                            value: ""test"", 
                            type: ""string""  
                        }
                    }
                },
                name: ""SprocActivitySample""
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlToBlobWithTabularTranslator = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL to Blob"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlSource"",
                        sourceRetryCount: 2,
                        sourceRetryWait: ""00:00:01"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""CopyTestSrcStoredProcedureWithParameters"",
                        storedProcedureParameters: {
                            ""stringData"": { value: ""test"", type: ""String""},
                            ""id"": { value: ""3"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        blobWriterAddHeader: true,
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    },
                    translator:
                    {
                        type: ""TabularTranslator"",
                        columnMappings: ""PartitionKey:PartitionKey""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputBlobDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string MSourcePipeline = @"
{
    name: ""DataPipeline_MSample"",
    properties:
    {
        activities:
        [
            {
                name: ""MySqlToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""RelationalSource"",
                        query: ""select * from northwind_mysql.orders""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "HDInsightPig")]
        // original had propertyBagKeys for PropertyBagPropertyName1
        // original also had inline script, changed to linked service
        public const string HDInsightPipeline = @"
{
    name: ""My HDInsight pipeline"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightPig"",
                typeProperties:
                {
                    scriptPath: ""scripts/script.pig"",
                    scriptLinkedService: { referenceName: ""ScriptLinkedService"", type: ""LinkedServiceReference"" },
                    storageLinkedServices:
                    [
                        { referenceName: ""SA1"", type: ""LinkedServiceReference"" },
                        { referenceName: ""SA2"", type: ""LinkedServiceReference"" }
                    ],
                    defines:
                    {
                        PropertyBagPropertyName1: ""PropertyBagValue1""
                    }
                },
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "HDInsightHive")]
        public const string HDInsightPipeline2 = @"
{
    name: ""My HDInsight pipeline2"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightHive"",
                typeProperties:
                {
                    scriptPath: ""scripts/script.hql"",
                    scriptLinkedService: { referenceName: ""storageLinkedService1"", type: ""LinkedServiceReference"" },
                    storageLinkedServices:
                    [
                        { referenceName: ""storageLinkedService2"", type: ""LinkedServiceReference"" }
                    ]
                },
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "HDInsightMapReduce")]
        // original had propertyBagKeys for PropertyBagPropertyName1
        public const string HDInsightMapReducePipeline = @"
{
    name: ""My HDInsight MapReduce pipeline"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        activities:
        [
            {
                name: ""MapReduceActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightMapReduce"",
                typeProperties:
                {
                    className : ""MYClass"",
                    jarFilePath: ""TestData/hadoop-mapreduce-examples.jar"",
                    jarLinkedService: { referenceName: ""storageLinkedService1"", type: ""LinkedServiceReference"" },
                    arguments:
                    [
                        ""wasb:///example/data/gutenberg/davinci.txt""
                    ],
                    jarLibs:
                    [
                        ""TestData/test1.jar""
                    ],
                    storageLinkedServices:
                    [
                        { referenceName: ""storageLinkedService2"", type: ""LinkedServiceReference"" }
                    ], 
                    defines:
                    {
                        PropertyBagPropertyName1: ""PropertyBagValue1""
                    }
                },
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample("HDInsightSpark")]
        public const string HDInsightSparkPipeline = @"
{
    name: ""My HDInsightSpark pipeline"",
    properties: 
    {
        description : ""HDInsightSpark pipeline description"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightSpark"",
                typeProperties:
                {
                    rootPath: ""release\\1.0"",
                    entryFilePath: ""main.py"",
                    sparkJobLinkedService: { referenceName: ""storageLinkedService1"", type: ""LinkedServiceReference"" },
                    className:""main"",
                    arguments: 
                    [ 
                        ""arg1"",
                        ""arg2"" 
                    ],
                    sparkConfig:
                    {
                        ""spark.yarn.appMasterEnv.PYSPARK_DRIVER_PYTHON"" : ""python3""
                    },
                    proxyUser: ""user1""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyCassandraToBlob = @"{
    ""name"": ""Pipeline"",
    ""properties"": {
        ""activities"": [
            {
                ""name"": ""blob-table"",
                ""type"": ""Copy"",
                ""inputs"": [
                    {
                        ""referenceName"": ""Table-Blob"", ""type"": ""DatasetReference""
                    }
                ],
                ""outputs"": [
                    {
                        ""referenceName"": ""Table-AzureTable"", ""type"": ""DatasetReference""
                    }
                ],
                ""policy"": {
                },
                ""typeProperties"": {
                    ""source"": {
                        ""type"": ""CassandraSource"",
                        ""query"":""select * from table"",
                        ""consistencyLevel"":""TWO"",
                    },
                    ""sink"": {
                        ""type"": ""AzureTableSink"",
                        ""writeBatchSize"": 1000000,
                        ""azureTableDefaultPartitionKeyValue"": ""defaultParitionKey""
                    },
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyMongoDbToBlob = @"{
    name: ""MongoDbToBlobPipeline"",
    properties: {
        activities: [
            {
                name: ""CopyFromMongoDbToBlob"",
                type: ""Copy"",
                inputs: [
                    {
                        referenceName: ""MongoDbDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""AzureBlobOut"", type: ""DatasetReference""
                    }
                ],
                policy: {
                },
                typeProperties: {
                    source: {
                        type: ""MongoDbSource"",
                        query:""select * from collection""
                    },
                    sink: {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        // note original had internal DataInsightTranslator, removed that
        public const string CopySqlToBlobWithCopyBehaviorProperty = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL to Blob with CopyBehavior property"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlSource"",
                        sourceRetryCount: 2,
                        sourceRetryWait: ""00:00:01"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""$EncryptedString$MyEncryptedQuery"",
                        storedProcedureParameters: {
                            ""stringData"": { value: ""tr3"" },
                            ""id"": { value: ""$$MediaTypeNames.Text.Format('{0:yyyy}', SliceStart)"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        blobWriterAddHeader: true,
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        copyBehavior: ""PreserveHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputBlobDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyBlobToFileSystemSink = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Blob to Azure Queue"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""BlobSource"",
                        sourceRetryCount: 2,
                        sourceRetryWait: ""00:00:01"",
                        treatEmptyAsNull: false
                    },
                    sink: 
                    {
                        type: ""FileSystemSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""                                              
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawBlob"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""ProcessedBlob"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyAzureTableToSql = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Azure table to Sql"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""AzureTableSource"",
                        sourceRetryCount: 2,
                        sourceRetryWait: ""00:00:01"",
                        azureTableSourceQuery: ""$$Text.Format('PartitionKey eq \\'ContosoSampleDevice\\' and RowKey eq \\'{0:yyyy-MM-ddTHH:mm:ss.fffffffZ}!{1:yyyy-MM-ddTHH:mm:ss.fffffffZ}\\'', Time.AddMinutes(SliceStart, -10), Time.AddMinutes(SliceStart, -9))"",
                        azureTableSourceIgnoreTableNotFound: false
                    },
                    sink: 
                    {
                        type: ""SqlSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        sinkRetryCount: 3,
                        sinkRetryWait: ""00:00:01"",
                        sqlWriterStoredProcedureName: ""MySprocName"",
                        sqlWriterTableType: ""MyTableType""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawBlob"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""ProcessedBlob"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyBlobToAzureQueue = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Blob to Azure Queue"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""BlobSource"",
                        sourceRetryCount: 2,
                        sourceRetryWait: ""00:00:01"",
                        treatEmptyAsNull: false
                    },
                    sink: 
                    {
                        type: ""AzureQueueSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        sinkRetryCount: 3,
                        sinkRetryWait: ""00:00:01""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawBlob"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""ProcessedBlob"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlDWToSqlDW = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL DW to SQL DW"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlDWSource"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""CopyTestSrcStoredProcedureWithParameters"",
                        storedProcedureParameters: {
                            ""stringData"": { value: ""test"", type: ""String""},
                            ""id"": { value: ""3"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""SqlDWSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        allowPolyBase: true,
                        polyBaseSettings:
                        {
                            rejectType: ""percentage"",
                            rejectValue: 20.42341,
                            rejectSampleValue: 80,
                            useTypeDefault: true
                        }
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlDWToSqlDWWithIntegerRejectValue = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL DW to SQL DW"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlDWSource"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""CopyTestSrcStoredProcedureWithParameters"",
                        storedProcedureParameters: {
                            ""stringData"": { value: ""test"", type: ""String""},
                            ""id"": { value: ""3"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""SqlDWSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        allowPolyBase: true,
                        polyBaseSettings:
                        {
                            rejectType: ""percentage"",
                            rejectValue: 20,
                            rejectSampleValue: 80,
                            useTypeDefault: true
                        }
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlDWToSqlDWWithDummyZeroRejectValue = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL DW to SQL DW"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlDWSource"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""CopyTestSrcStoredProcedureWithParameters"",
                        storedProcedureParameters: {
                            ""stringData"": { value: ""test"", type: ""String""},
                            ""id"": { value: ""3"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""SqlDWSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        allowPolyBase: true,
                        polyBaseSettings:
                        {
                            rejectType: ""percentage"",
                            rejectValue: 20.0000000,
                            rejectSampleValue: 80,
                            useTypeDefault: true
                        }
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlDWToSqlDW_WithoutPolybaseSettings = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL DW to SQL DW"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SqlDWSource"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery""
                    },
                    sink:
                    {
                        type: ""SqlDWSink"",
                        preCopyScript: ""script"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputSqlDWDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string CopyAdlsToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from Azure Data Lake Store to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""AzureDataLakeStoreSource"",
                        recursive: ""true""
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string CopyHttpSourceToAzureSearchIndexSink = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from Http to Azure Search Index"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""HttpSource"",
                        httpRequestTimeout: ""01:00:00""
                    },
                    sink:
                    {
                        type: ""AzureSearchIndexSink"",
                        writeBehavior: ""Upload""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputHttpDA"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAzureSearchIndexDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "HDInsightStreaming")]
        // original had a propertyBagKeys for PropertyBagPropertyName1
        public const string StreamingWithDefines = @"
{
    name: ""HadoopStreamingPipeline"",
    properties:
    {
        description : ""Hadoop Streaming Demo"",
        activities:
        [
           {
                name: ""HadoopStreamingActivity"",
                description: ""HadoopStreamingActivity"",
                type: ""HDInsightStreaming"",
                linkedServiceName: { referenceName: ""HDInsightLinkedService"", type: ""LinkedServiceReference"" },
                typeProperties:
                {
                    mapper: ""cat.exe"",
                    reducer: ""wc.exe"",
                    input:  ""example/data/gutenberg/davinci.txt"",
                    output: ""example/data/StreamingOutput/wc.txt"",
                    filePaths: [ 
                        ""aureleu/example/apps/wc.exe"" , 
                        ""aureleu/example/apps/cat.exe"" 
                    ],
                    defines:
                    {
                        PropertyBagPropertyName1: ""PropertyBagValue1""
                    },
                    fileLinkedService : { referenceName: ""StorageLinkedService"", type: ""LinkedServiceReference"" }
                },
                policy:
                {
                    retry:	1,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyFileSystemSourceToFileSystemSink = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from File to File"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""FileSystemSource"",
                        recursive: false
                    },
                    sink: 
                    {
                        type: ""FileSystemSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        copyBehavior: ""FlattenHierarchy""                                                
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawFileSource"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""ProcessedFileSink"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyPipelineUsingStaging = @"{
    ""name"": ""Pipeline"",
    ""properties"": {
        ""activities"": [
            {
                ""name"": ""blob-table"",
                ""type"": ""Copy"",
                ""inputs"": [
                    {
                        ""referenceName"": ""Table-Blob"", type: ""DatasetReference""
                    }
                ],
                ""outputs"": [
                    {
                        ""referenceName"": ""Table-AzureTable"", type: ""DatasetReference""
                    }
                ],
                ""policy"": {
                },
                ""typeProperties"": {
                    ""source"": {
                        ""type"": ""BlobSource""
                    },
                    ""sink"": {
                        ""type"": ""AzureTableSink"",
                        ""writeBatchSize"": 1000000,
                        ""writeBatchTimeout"": ""01:00:00"",
                        ""azureTableDefaultPartitionKeyValue"": ""defaultParitionKey""
                    },
                    ""enableStaging"": true,
                    ""stagingSettings"": {
                        ""linkedServiceName"": { referenceName: ""MyStagingBlob"", type: ""LinkedServiceReference"" },
                        ""path"": ""stagingcontainer/path"",
                        ""enableCompression"": true
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyFileSystemSourceToBlobSink = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Copy from File to Blob"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""FileSystemSource"",
                        recursive: true
                    },
                    sink: 
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawFileSource"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""BlobSink"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyHdfsSourceToBlobSink = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Copy from HDFS File to Blob"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""HdfsSource"",
                        distcpSettings: {
                            resourceManagerEndpoint: ""fakeEndpoint"",
                            tempScriptPath: ""fakePath"",
                            distcpOptions: ""fakeOptions""
                        }
                    },
                    sink: 
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""RawFileSource"", type: ""DatasetReference""
                    }
                ],
                outputs:
                [
                    {
                        referenceName: ""BlobSink"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}";

        [JsonSample(version: "Lookup")]
        public const string LookupBlobSource = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Lookup data from Blob"",
        activities:
        [
            {
                type: ""Lookup"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""BlobSource""
                    },
                    dataset:
                    {
                        referenceName: ""MyDataset"", type: ""DatasetReference""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Lookup")]
        public const string LookupBlobSourceWithAllRows = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Lookup data from Blob with all rows"",
        activities:
        [
            {
                type: ""Lookup"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source:
                    {
                        type: ""BlobSource""
                    },
                    dataset:
                    {
                        referenceName: ""MyDataset"", type: ""DatasetReference""
                    },
                    firstRowOnly: false
                }
            }
        ]
    }
}";

        [JsonSample(version: "Lookup")]
        public const string LookupAzureSqlSource = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Lookup data from Azure Sql"",
        activities:
        [
            {
                type: ""Lookup"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""SqlSource"",
                        sqlReaderQuery: ""select * from MyTable""
                    },
                    dataset:
                    {
                        referenceName: ""MyDataset"", type: ""DatasetReference""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Lookup")]
        public const string LookupAzureTableSource = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Lookup data from Azure Table"",
        activities:
        [
            {
                type: ""Lookup"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""AzureTableSource"",
                        azureTableSourceQuery: ""PartitionKey eq 'SomePartition'""
                    },
                    dataset:
                    {
                        referenceName: ""MyDataset"", type: ""DatasetReference""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Lookup")]
        public const string LookupFileSource = @"
{
    name: ""MyPipelineName"",
    properties:
    { 
        description : ""Lookup data from File"",
        activities:
        [
            {
                type: ""Lookup"",
                name: ""MyActivityName"",
                typeProperties:
                {
                    source: 
                    {
                        type: ""FileSystemSource""
                    },
                    dataset:
                    {
                        referenceName: ""MyDataset"", type: ""DatasetReference""
                    }
                }
            }
        ]
    }
}
";
        [JsonSample]
        public const string GetMetadataActivity = @"
{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""GetMetadata"",
        ""typeProperties"": {
            ""fieldList"" : [""field""],
            ""dataset"": {
                ""referenceName"": ""MyDataset"",
                ""type"": ""DatasetReference""
            }
        }
    }
    ]
  }
}
";


        [JsonSample]
        public const string WebActivityNoAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebActivity"",
                typeProperties: {
                    method: ""get"",
                    url: ""http://www.bing.com""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Custom")]
        public const string CustomActivity = @"
{
    name: ""MyPipeline"",
    properties:
    { 
        description : ""Custom activity sample"",
        activities:
        [
            {
                type: ""Custom"",
                name: ""MyActivityName"",
                ""linkedServiceName"": {
                    ""referenceName"": ""HDILinkedService"",
                    ""type"": ""LinkedServiceReference""
                },
                typeProperties:
                {
                    ""command"": ""Echo Hello World!"",
                    ""folderPath"":""Test Folder"",
                    ""resourceLinkedService"": {
                        ""referenceName"": ""imagestoreLinkedService"",
                        ""type"": ""LinkedServiceReference""
                    },
                    ""referenceObjects"":{
                        ""linkedServices"":[
                        {
                            ""referenceName"": ""HDILinkedService"",
                            ""type"": ""LinkedServiceReference""
                        }
                        ],
                        ""datasets"":[
                        {
                            ""referenceName"": ""MyDataset"",
                            ""type"": ""DatasetReference""
                        }]
                    },
                    ""extendedProperties"":
                    {
                        ""PropertyBagPropertyName1"": ""PropertyBagValue1"",
                        ""propertyBagPropertyName2"": ""PropertyBagValue2"",
                        ""dateTime1"": ""2015-04-12T12:13:14Z"",
                    },
                    ""retentionTimeInDays"": 35
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebActivityWithDatasets = @"
{
  ""name"": ""MyWebPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyAnonymousWebActivity"",
        ""type"": ""WebActivity"",
        ""typeProperties"": 
            {
                ""method"": ""get"",
                ""url"": ""http://www.bing.com"",
                ""headers"": 
                    { 
                        ""Content-Type"": ""application/json"",
                        ""activityName"": ""activityName""
                    },
                ""datasets"":[                
                    {
                        ""referenceName"": ""MyDataset"", 
                        ""type"": ""DatasetReference""
                    }
                ],
                ""linkedServices"":[         
                    {
                        ""referenceName"": ""MyStagingBlob"", 
                        ""type"": ""LinkedServiceReference"" 
                    }
                ]
            }
      }
    ]
  }
}
";

        [JsonSample]
        public const string IfPipeline = @"
{
  ""name"": ""MyForeachPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyIfActivity"",
        ""type"": ""IfCondition"",
        ""typeProperties"": 
            {
                ""expression"": {
                    ""value"": ""@bool(pipeline().parameters.routeSelection)"",
                    ""type"": ""Expression""
                },
                ""ifTrueActivities"":[ 
                      {
                        ""name"": ""MyActivity"",
                        ""type"": ""GetMetadata"",
                        ""typeProperties"": {
                            ""fieldList"" : [""field""],
                            ""dataset"": {
                                ""referenceName"": ""MyDataset"",
                                ""type"": ""DatasetReference""
                            }
                        }
                    }
                ]
            }
      }
    ]
  }
}
";

        [JsonSample]
        public const string SwitchPipeline = @"
{
    ""name"": ""MySwitchPipeline"",
    ""properties"": {
        ""activities"": [
            {
                ""name"": ""MySwitchActivity"",
                ""type"": ""Switch"",
                ""typeProperties"": {
                    ""on"": {
                        ""value"": ""@bool(pipeline().parameters.routeSelection)"",
                        ""type"": ""Expression""
                    },
                    ""cases"": [
                        {
                            ""value"": ""A"",
                            ""activities"": [
                                {
                                    ""name"": ""MyCaseAActivity"",
                                    ""type"": ""GetMetadata"",
                                    ""typeProperties"": {
                                        ""fieldList"" : [""field""],
                                        ""dataset"": {
                                            ""referenceName"": ""MyDataset"",
                                            ""type"": ""DatasetReference""
                                        }
                                    }
                                }
                            ]
                        }
                    ]
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string ForeachPipeline = @"
{
  ""name"": ""MyForeachPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyForeachActivity"",
        ""type"": ""ForEach"",
        ""typeProperties"": 
            {
                ""isSequential"": true,
                ""items"": {
                    ""value"": ""@pipeline().parameters.OutputBlobNameList"",
                    ""type"": ""Expression""
                },
                ""activities"":[                      
                      {
                        ""name"": ""MyActivity"",
                        ""type"": ""GetMetadata"",
                        ""typeProperties"": {
                            ""fieldList"" : [""field""],
                            ""dataset"": {
                                ""referenceName"": ""MyDataset"",
                                ""type"": ""DatasetReference""
                            }
                        }
                    }
                ]
            }
      }
    ]
  }
}
";

        [JsonSample]
        public const string UntilWaitPipeline = @"
{
  ""name"": ""MyUntilWaitPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyUntilActivity"",
        ""type"": ""Until"",
        ""typeProperties"": {
            ""expression"": {
                ""value"": ""@bool(equals(activity('MyActivity').status, 'Succeeded'))"",
                ""type"": ""Expression""
            },
            ""activities"":[                      
                {
                    ""name"": ""MyActivity"",
                    ""type"": ""GetMetadata"",
                    ""typeProperties"": {
                        ""fieldList"" : [""field""],
                        ""dataset"": {
                            ""referenceName"": ""MyDataset"",
                            ""type"": ""DatasetReference""
                        }
                    }
                },
                {
                    ""name"": ""MyWaitActivity"",
                    ""type"": ""Wait"",
                    ""typeProperties"": {
                        ""waitTimeInSeconds"" : 300,
                    }
                }
            ]
         }
      }
    ]
  }
}
";

        [JsonSample]
        public const string AzureMLExecutePipelinePipeline = @"
{
    ""name"": ""MyAzureMLExecutePipelinePipeline"",
    ""properties"": {
        ""activities"": [
            {
                ""name"": ""MyAzureMLExecutePipelineActivity"",
                ""type"": ""AzureMLExecutePipeline"",
                ""typeProperties"": {
                    ""mlPipelineId"": ""93b9ccc4-0000-0000-8968-43a0a0fe0c44"",
                    ""experimentName"": ""myExperimentName"",
                    ""mlPipelineParameters"": {
                        ""param_name"": ""param_value""
                    }
                },
                ""linkedServiceName"": {
                    ""referenceName"": ""MyAzureMLServiceLinkedService"",
                    ""type"": ""LinkedServiceReference""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string AzureMLUpdateResourcePipeline = @"
{
    name: ""MyAzureMLUpdateResourcePipeline"",
    properties: 
    {
        description : ""MyAzureMLUpdateResourcePipeline pipeline description"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"",
                type: ""AzureMLUpdateResource"",
                typeProperties:
                {
                    ""trainedModelName"": ""Training Exp for ADF ML TiP tests[trained model]"",
                    ""trainedModelLinkedServiceName"": {
                        ""type"": ""LinkedServiceReference"",
                        ""referenceName"": ""StorageLinkedService""
                    },
                    ""trainedModelFilePath"": ""azuremltesting/testInput.ilearner""
                },
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" }
            }
        ]
    }
}";

        [JsonSample]
        public const string AzureMLBatchExecutionPipeline = @"
{
  ""name"": ""MyAzureMLPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""AzureMLBatchExecution"",
        ""typeProperties"": {
            ""webServiceInputs"": {
                ""input1"": {
                    ""linkedServiceName"":  {
                        ""type"": ""LinkedServiceReference"",
                        ""referenceName"": ""StorageLinkedService""
                    },
                    ""filePath"": ""azuremltesting/IrisInput/Two Class Data.1.arff""
                }
             },
            ""webServiceOutputs"": {
                ""output1"": {
                    ""linkedServiceName"":  {
                        ""type"": ""LinkedServiceReference"",
                        ""referenceName"": ""StorageLinkedService""
                    },
                ""filePath"": ""azuremltesting/categorized/##folderPath##/result.csv""
                }
            }
        },
        ""linkedServiceName"":{
                ""type"": ""LinkedServiceReference"",
                ""referenceName"": ""UpdatableDecisionTreeLinkedService""
            }
        }
    ]
  }
}";

        [JsonSample]
        public const string DataLakeAnalyticsUSqlnPipeline = @"
{
  ""name"": ""MyAzureDataLakeAnalyticsActivity"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""DataLakeAnalyticsU-SQL"",
        ""typeProperties"": {
            ""scriptPath"": ""fakepath"",
            ""scriptLinkedService"": {
                ""type"": ""LinkedServiceReference"",
                ""referenceName"": ""MyAzureStorageLinkedService""
            },
            ""degreeOfParallelism"": 3,
            ""priority"": 100,
            ""parameters"": {
                ""in"": ""/Samples/Data/SearchLog.tsv"",
                ""out"": ""wasb://output@sfadfteststorage.blob.core.windows.net/Result.tsv""
            }
        },
        ""linkedServiceName"":{
                ""type"": ""LinkedServiceReference"",
                ""referenceName"": ""MyAzureDataLakeAnalyticsLinkedService""
            }
        }
    ]
  }
}";

        [JsonSample(version: "Copy")]
        public const string CopyAzureMySqlToBlob = @"{
    name: ""AzureMySqlToBlobPipeline"",
    properties: {
        activities: [
            {
                name: ""CopyFromAzureMySqlToBlob"",
                type: ""Copy"",
                inputs: [
                    {
                        referenceName: ""AzureMySQLDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""AzureBlobOut"", type: ""DatasetReference""
                    }
                ],
                policy: {
                },
                typeProperties: {
                    source: {
                        type: ""AzureMySqlSource"",
                        query:""select * from azuremysqltable""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyFromSalesforceToSalesforce = @"
{
  ""name"": ""SalesforceToSalesforce"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""CopyFromSalesforceToSalesforce"",
        ""type"": ""Copy"",
        ""inputs"": [
          {
            ""referenceName"": ""SalesforceSourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SalesforceSinkDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""typeProperties"":
        {
          ""source"":
          {
            ""type"": ""SalesforceSource"",
            ""query"":""select Id from table"",
            ""readBehavior"": ""QueryAll""
          },
          ""sink"":
          {
            ""type"": ""SalesforceSink"",
            ""writeBehavior"": ""Insert"",
            ""ignoreNullValues"": false
          }
        }
      }
    ]
  }
}";

        [JsonSample(version: "Copy")]
        public const string CopyFromDynamicsToDynamics = @"{
    name: ""DynamicsToDynamicsPipeline"",
    properties: {
        activities: [
            {
                name: ""CopyFromDynamicsToDynamics"",
                type: ""Copy"",
                inputs: [
                    {
                        referenceName: ""DynamicsIn"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""DynamicsOut"", type: ""DatasetReference""
                    }
                ],
                policy: {
                },
                typeProperties: {
                    source: {
                        type: ""DynamicsSource"",
                        query:""fetchXml query""
                    },
                    sink: {
                        type: ""DynamicsSink"",
                        writeBehavior: ""Upsert"",
                        ignoreNullValues: false,
                        alternateKeyName: ""keyName""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopySapC4CToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SAP Cloud for Customer to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SapCloudForCustomerSource"",
                        query: ""$select=Column0""
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSapC4C"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyAmazonMWSToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyAmazonMWSToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""AmazonMWSSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""AmazonMWSDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyAzurePostgreSqlToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyAzurePostgreSqlToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""AzurePostgreSqlSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""AzurePostgreSqlDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyConcurToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyConcurToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""ConcurSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""ConcurDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyCouchbaseToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyCouchbaseToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""CouchbaseSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""CouchbaseDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyDrillToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyDrillToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""DrillSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""DrillDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyEloquaToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyEloquaToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""EloquaSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""EloquaDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyGoogleBigQueryToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyGoogleBigQueryToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""GoogleBigQuerySource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""GoogleBigQueryDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyGreenplumToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyGreenplumToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""GreenplumSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""GreenplumDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyHBaseToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyHBaseToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""HBaseSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""HBaseDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyHiveToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyHiveToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""HiveSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""HiveDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyHubspotToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyHubspotToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""HubspotSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""HubspotDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyImpalaToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyImpalaToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""ImpalaSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""ImpalaDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyJiraToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyJiraToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""JiraSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""JiraDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyMagentoToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyMagentoToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""MagentoSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""MagentoDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyMariaDBToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyMariaDBToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""MariaDBSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""MariaDBDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyAzureMariaDBToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyAzureMariaDBToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""AzureMariaDBSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""AzureMariaDBDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyMarketoToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyMarketoToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""MarketoSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""MarketoDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyPaypalToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyPaypalToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""PaypalSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""PaypalDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyPhoenixToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyPhoenixToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""PhoenixSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""PhoenixDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyPrestoToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyPrestoToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""PrestoSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""PrestoDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyQuickBooksToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyQuickBooksToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""QuickBooksSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""QuickBooksDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyServiceNowToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyServiceNowToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""ServiceNowSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""ServiceNowDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyShopifyToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyShopifyToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""ShopifySource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""ShopifyDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopySparkToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopySparkToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""SparkSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""SparkDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopySquareToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopySquareToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""SquareSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""SquareDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyXeroToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyXeroToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""XeroSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""XeroDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyZohoToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyZohoToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""ZohoSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""ZohoDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";
        [JsonSample]
        public const string CopyFromBlobToSapC4C = @"{
    name: ""MyPipelineName"",
    properties: 
    {
        activities:
        [
            {
                name: ""CopyBlobToSapC4c"",
                type: ""Copy"",
                typeProperties: {
                  source: {
                    type: ""BlobSource""
                  },
                  sink: {
                    type: ""SapCloudForCustomerSink"",
                    writeBehavior: ""Insert"",
                    writeBatchSize: 50
                  },
                  enableSkipIncompatibleRow: true,
                  parallelCopies: 32,
                  dataIntegrationUnits: 16,
                  enableSkipIncompatibleRow: true,
                  redirectIncompatibleRowSettings: {
                      linkedServiceName: {
                          referenceName: ""AzureBlobLinkedService"",
                          type: ""LinkedServiceReference""
                      },
                      path: ""redirectcontainer/erroroutput""
                  }
                },
                inputs: [
                  {
                    referenceName: ""SourceBlobDataset"",
                    type: ""DatasetReference""
                  }
                ],
                outputs: [
                  {
                    referenceName: ""SapC4CDataset"",
                    type: ""DatasetReference""
                  }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopySapEccToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SAP ECC to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SapEccSource"",
                        query: ""$top=1""
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSapEcc"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string CopyNetezzaToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyNetezzaToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""NetezzaSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""NetezzaDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyVerticaToBlob = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyVerticaToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""VerticaSource"",
                        query: ""select * from a table""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""VerticaDataset"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset"", type: ""DatasetReference""
                    }
                ]
            }
        ]
    }
}";
        [JsonSample]
        public const string DatabrickNotebookActivity = @"
{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""DatabricksNotebook"",
        ""typeProperties"": {
          ""notebookPath"": ""/testing"",
          ""baseParameters"":
            {
                ""test"":""test""
            }
        }, 
        ""linkedServiceName"": { ""referenceName"": ""MyLinkedServiceName"", ""type"": ""LinkedServiceReference"" }
      } 
    ]
  }
}
";
        [JsonSample(version: "Copy")]
        public const string UserProperties = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyBlobToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""BlobSource""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""BlobDataset1"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset2"", type: ""DatasetReference""
                    }
                ],
                ""userProperties"": [
                    {
                        ""name"": ""File"",
                        ""value"": ""@item().File""
                    }
                ]
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string EmptyUserProperties = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                type: ""Copy"",
                name: ""CopyBlobToBlob"",
                description: ""Test activity description"", 
                typeProperties: {
                    source: {
                        type: ""BlobSource""
                    },
                    sink: {
                        type: ""BlobSink""
                    }
                },
                inputs: [
                    {
                        referenceName: ""BlobDataset1"", type: ""DatasetReference""
                    }
                ],
                outputs: [
                    {
                        referenceName: ""BlobDataset2"", type: ""DatasetReference""
                    }
                ],
                ""userProperties"": [ ]
            }
        ]
    }
}";

        [JsonSample(version: "AzureFunctionActivity")]
        public const string AzureFunction = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                ""name"": ""Azure Function1"",
                ""type"": ""AzureFunctionActivity"",
                ""policy"": {
                    ""timeout"": ""7.00:00:00"",
                    ""retry"": 0,
                    ""retryIntervalInSeconds"": 30,
                    ""secureOutput"": false,
                    ""secureInput"": false
                },
                ""typeProperties"": {
                    ""functionName"": ""GenericWebhookCSharp1"",
                    ""method"": ""POST"",
                    ""headers"": {
                        ""Content-Type"": ""application/json"",
                    },
                    ""body"": {
                        ""first"": ""Azure"",
                        ""last"": ""Function""
                    }
                }
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopySapOpenHubToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SAP Open Hub to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SapOpenHubSource"",
                        excludeLastRequest: false,
                        baseRequestId: ""123""
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSapOpenHub"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyRestToAdls = @"
{
  ""name"": ""MyPipelineName"",
  ""properties"": {
    ""description"": ""Copy from REST to Azure Data Lake Store"",
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""name"": ""TestActivity"",
        ""description"": ""Test activity description"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""RestSource"",
            ""requestMethod"": ""POST"",
            ""requestBody"": ""{\""id\"":123}"",
            ""additionalHeaders"": {
              ""content-type"": ""application/json""
            },
            ""httpRequestTimeout"": ""00:01:00""
          },
          ""sink"": {
            ""type"": ""AzureDataLakeStoreSink"",
            ""copyBehavior"": ""FlattenHierarchy""
          },
          ""translator"": {
            ""type"": ""TabularTranslator"",
            ""collectionReference"": ""$.fakekey""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""InputRest"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""OutputAdlsDA"",
            ""type"": ""DatasetReference""
          }
        ],
        ""linkedServiceName"": {
          ""referenceName"": ""MyLinkedServiceName"",
          ""type"": ""LinkedServiceReference""
        },
        ""policy"": {
          ""retry"": 3,
          ""timeout"": ""00:00:05""
        }
      }
    ]
  }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyOffice365ToBlob = @"
{
  ""name"": ""MyPipelineName"",
  ""properties"": {
    ""description"": ""Copy from Office365 to Azure Blob"",
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""name"": ""TestActivity"",
        ""description"": ""Test activity description"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""Office365Source"",
            ""allowedGroups"": ""my_group"",
            ""userScopeFilterUri"": ""https://graph.microsoft.com/v1.0/users?$filter=Department eq 'Finance'"",
            ""dateFilterColumn"": ""CreatedDateTime"",
            ""startTime"": ""2019-04-28T16:00:00.000Z"",
            ""endTime"": ""2019-05-05T16:00:00.000Z"",
            ""outputColumns"": [
              {
                ""name"": ""Id""
              },
              {
                ""name"": ""CreatedDateTime""
              }
            ]
          },
          ""sink"": {
            ""type"": ""AzureDataLakeStoreSink"",
            ""copyBehavior"": ""FlattenHierarchy""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""InputRest"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""OutputAdlsDA"",
            ""type"": ""DatasetReference""
          }
        ],
        ""linkedServiceName"": {
          ""referenceName"": ""MyLinkedServiceName"",
          ""type"": ""LinkedServiceReference""
        },
        ""policy"": {
          ""retry"": 3,
          ""timeout"": ""00:00:05""
        }
      }
    ]
  }
}
";

        [JsonSample(version: "WebhookActivity")]
        public const string Webhook = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                ""name"": ""Webhook1"",
                ""type"": ""WebHook"",
                ""typeProperties"": {
                    ""url"": ""http://samplesample.azurewebsites.net/api/execute/webhook"",
                    ""method"": ""POST"",
                    ""headers"": {
                        ""Content-Type"": ""application/json""
                    },
                    ""body"": {
                        ""key"": ""value""
                    },
                    ""timeout"": ""00:03:00""
                }
            }
        ]
    }
}";

        [JsonSample(version: "ValidationActivity")]
        public const string Validation = @"
{
    name: ""MyPipelineName"",
    properties: {
        activities: [
            {
                ""type"": ""Validation"",
                ""name"": ""ValidationActivity"",
                ""description"": ""Test activity description"",
                ""typeProperties"": {
                    ""timeout"": ""00:03:00"",
                    ""sleep"": 10,
                    ""minimumSize"": {
                        ""type"": ""Expression"",
                        ""value"": ""@add(0,1)""
                    },
                    ""dataset"": {
                        ""referenceName"": ""FileDataset"",
                        ""type"": ""DatasetReference""
                    }
                }
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopySapTableToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SAP Table to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SapTableSource"",
                        rowCount: 3
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSapTable"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string CopyActivity_Avro_Adls = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""AvroSource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            }
          },
          ""sink"": {
            ""type"": ""AvroSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""AvroWriteSettings"",
              ""recordName"": ""testavro"",
              ""recordNamespace"": ""microsoft.datatransfer.test""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_Orc_Adls = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""OrcSource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            }
          },
          ""sink"": {
            ""type"": ""OrcSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_Adls = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
}
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_AzureBlob = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""wildcardFolderPath"":  ""abc/efg"",
              ""wildcardFileName"":  ""a.csv""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
}
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_BlobFS = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobFSReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}
";

        [JsonSample]
        public const string CopyActivity_DelimitedText_FileServer = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""FileServerReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""wildcardFolderPath"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_Ftp = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""FtpReadSettings"",
              ""recursive"": true,
              ""wildcardFolderPath"": ""A*"",
              ""wildcardFileName"":  ""*.csv"",
              ""useBinaryTransfer"":  true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_Hdfs = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""HdfsReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""wildcardFolderPath"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}
";

        [JsonSample]
        public const string CopyActivity_DelimitedText_Http = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""HttpReadSettings"",
              ""requestMethod"": ""POST"",
              ""requestBody"": ""request body"",
              ""additionalHeaders"": ""testHeaders"",
              ""requestTimeout"":  ""2400""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_S3 = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AmazonS3ReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""prefix"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}
";

        [JsonSample]
        public const string CopyActivity_DelimitedText_Sftp = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""SftpReadSettings"",
              ""recursive"": true,
              ""wildcardFileName"": ""*.csv"",
              ""wildcardFolderPath"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_CosmosDbSqlApi_CosmosDbSqlApi = @"{
    ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""CosmosDbSqlApiSource"",
            ""query"": ""select * from c"",
            ""pageSize"": 1000,
            ""preferredRegions"": [ ""West US"", ""West US 2"" ],
            ""includeSystemColumns"": false
          },
          ""sink"": {
            ""type"": ""CosmosDbSqlApiSink"",
            ""writeBehavior"": ""upsert"",
            ""writeBatchSize"": 1000
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""sourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""sinkDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_Json_AzureBlob = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""JsonSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""wildcardFolderPath"":  ""abc*g"",
              ""wildcardFileName"":  ""*.json""
            }
          },
          ""sink"": {
            ""type"": ""JsonSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""JsonWriteSettings"",
              ""filePattern"": ""arrayOfObjects""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""sourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""sinkDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_Binary_Binary = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""BinarySource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""BinarySource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy"",
              ""blockSizeInMB"": 8
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""BinarySource"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""AzureBlobFSWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy"",
              ""blockSizeInMB"": 8
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_Teradata_Binary = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""TeradataSource"",
            ""partitionOption"": ""DynamicRange"",
                        ""partitionSettings"": {
                            ""partitionColumnName"": ""EmployeeKey"",
                            ""partitionUpperBound"": ""1"",
                            ""partitionLowerBound"": ""500""
                        }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""TeradataDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_SqlMI_SqlMI = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""SqlMISource"",
            ""sqlReaderQuery"": ""select * from my_table"",
            ""queryTimeout"": ""00:00:05""
          },
          ""sink"": {
            ""type"": ""SqlMISink"",
            ""sqlWriterTableType"": ""MarketingType"",
            ""sqlWriterStoredProcedureName"": ""spOverwriteMarketing"",
            ""storedProcedureParameters"": {
              ""category"": {
                ""value"": ""ProductA""
              }
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_SalesforceServiceCloud_SalesforceServiceCloud = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""SalesforceServiceCloudSource"",
            ""query"": ""select * from my_table"",
            ""readBehavior"": ""QueryAll""
          },
          ""sink"": {
            ""type"": ""SalesforceServiceCloudSink"",
            ""writeBehavior"": ""Upsert""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_DynamicsCrm_DynamicsCrm = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DynamicsCrmSource"",
            ""query"": ""FetchXML""
          },
          ""sink"": {
            ""type"": ""DynamicsCrmSink"",
            ""writeBehavior"": ""Upsert"",
            ""writeBatchSize"": 5000,
            ""ignoreNullValues"": true,
            ""alternateKeyName"": ""keyName""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_CommonDataServiceForApps_CommonDataServiceForApps = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""CommonDataServiceForAppsSource"",
            ""query"": ""FetchXML""
          },
          ""sink"": {
            ""type"": ""CommonDataServiceForAppsSink"",
            ""writeBehavior"": ""Upsert"",
            ""writeBatchSize"": 5000,
            ""ignoreNullValues"": true,
            ""alternateKeyName"": ""keyName""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_Informix_Informix = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""InformixSource"",
            ""query"": ""fake_query""
          },
          ""sink"": {
            ""type"": ""InformixSink""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";
        [JsonSample]
        public const string CopyActivity_MicrosoftAccess_MicrosoftAccess = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""MicrosoftAccessSource"",
            ""query"": ""fake_query""
          },
          ""sink"": {
            ""type"": ""MicrosoftAccessSink""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""SourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";

        [JsonSample(version: "Copy")]
        public const string CopySapTableWithPartitionToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SAP Table to Azure Data Lake Store"",
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source:
                    {
                        type: ""SapTableSource"",
                        rowCount: 3,
                        partitionOption: ""PartitionOnCalendarDate"",
                        partitionSettings: 
                        {
                             ""partitionColumnName"": ""fakeColumn"",
                             ""partitionUpperBound"": ""20190405"",
                             ""partitionLowerBound"": ""20170809"",
                             ""maxPartitionsNumber"": 3
                        }
                    },
                    sink:
                    {
                        type: ""AzureDataLakeStoreSink"",
                        copyBehavior: ""FlattenHierarchy""
                    }
                },
                inputs: 
                [ 
                    {
                        referenceName: ""InputSapTable"", type: ""DatasetReference""
                    }
                ],
                outputs: 
                [ 
                    {
                        referenceName: ""OutputAdlsDA"", type: ""DatasetReference""
                    }
                ],
                linkedServiceName: { referenceName: ""MyLinkedServiceName"", type: ""LinkedServiceReference"" },
                policy:
                {
                    retry: 3,
                    timeout: ""00:00:05"",
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string Db2SourcePipeline = @"
{
    name: ""DataPipeline_Db2Sample"",
    properties:
    {
        activities:
        [
            {
                name: ""Db2ToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""Db2Source"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string AzurePostgreSqlSourcePipeline = @"
{
    name: ""DataPipeline_PostgreSqlSample"",
    properties:
    {
        activities:
        [
            {
                name: ""Db2ToPostgreSqlCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""Db2Source"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""AzurePostgreSqlSink"",
                        preCopyScript: ""fake script""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string OraclePartitionSourcePipeline = @"
{
    name: ""DataPipeline_OraclePartitionSample"",
    properties:
    {
        activities:
        [
            {
                name: ""OraclePartitionSourceToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""OracleSource"",
                        partitionOption: ""DynamicRange""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string NetezzaPartitionSourcePipeline = @"
{
    name: ""DataPipeline_NetezzaPartitionSample"",
    properties:
    {
        activities:
        [
            {
                name: ""NetezzaPartitionSourceToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""NetezzaSource"",
                        partitionOption: ""DataSlice""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string ODataSourcePipeline = @"
{
    name: ""DataPipeline_ODataSample"",
    properties:
    {
        activities:
        [
            {
                name: ""ODataToPostgreSqlCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""ODataSource"",
                        query: ""$top=1""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string SybaseSourcePipeline = @"
{
    name: ""DataPipeline_SybaseSample"",
    properties:
    {
        activities:
        [
            {
                name: ""SybaseToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""SybaseSource"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string MySqlSourcePipeline = @"
{
    name: ""DataPipeline_MySqlSample"",
    properties:
    {
        activities:
        [
            {
                name: ""MySqlToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""MySqlSource"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";
        [JsonSample(version: "Copy")]
        public const string AzureMySqlSinkPipeline = @"
{
    name: ""DataPipeline_AzureMySqlSinkSample"",
    properties:
    {
        activities:
        [
            {
                name: ""Db2ToPostgreSqlCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""Db2Source"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""AzureMySqlSink"",
                        preCopyScript: ""fake script""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string OdbcSourcePipeline = @"
{
    name: ""DataPipeline_OdbcSample"",
    properties:
    {
        activities:
        [
            {
                name: ""OdbcToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""MySqlSource"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string AmazonRedshiftSourcePipeline = @"
{
    name: ""DataPipeline_OdbcSample"",
    properties:
    {
        activities:
        [
            {
                name: ""AmazonRedshiftToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""AmazonRedshiftSource"",
                        query: ""select * from faketable""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string AzureDataExplorerPipeline = @"
{
    name: ""DataPipeline_AzureDataExplorerSample"",
    properties:
    {
        activities:
        [
            {
                name: ""MyAzureDataExplorerCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""AzureDataExplorerSource"",
                        query: ""CustomLogEvent | top 10 by TIMESTAMP | project TIMESTAMP, Tenant, EventId, ActivityId"",
                        noTruncation: false,
                        queryTimeout: ""00:00:15""
                    },
                    sink:
                    {
                        type: ""AzureDataExplorerSink"",
                        ingestionMappingName: ""MappingName"",
                        ingestionMappingAsJson: ""Mapping"",
                        flushImmediately: true
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string AzureDataExploreCommandActivityPipeline = @"
{
    name: ""MyKustoActivityPipeline"",
    properties: {
        activities: [
            {
                name: ""MyKustoActivity"",
                type: ""AzureDataExplorerCommand"",
                typeProperties: {
                    command: ""TestTable1 | take 10""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string AzureDataExploreCommandActivityWithTimeoutPipeline = @"
{
    name: ""MyKustoActivityPipeline"",
    properties: {
        activities: [
            {
                name: ""MyKustoActivity"",
                type: ""AzureDataExplorerCommand"",
                typeProperties: {
                    command: ""TestTable1 | take 10"",
                    commandTimeout: ""00:10:00""
                }
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string SapBwViaMdxSourcePipeline = @"
{
    name: ""DataPipeline_SapBwViaMdxSample"",
    properties:
    {
        activities:
        [
            {
                name: ""SapBwToBlobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""SapBwSource"",
                        query: ""fake query""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    }
                },
                policy:
                {
                    retry: 2,
                    timeout: ""01:00:00""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string ExecuteDataFlowActivityPipeline = @"
{
    name: ""My Execute Data Flow Activity pipeline"",
    properties: 
    {
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""ExecuteDataFlow"",
                typeProperties: {
                    dataFlow: {
                        referenceName: ""referenced1"",
                        type: ""DataFlowReference""
                    },
                    staging: {
                        linkedService: {
                            referenceName: ""referenced2"",
                            type: ""LinkedServiceReference""
                        },
                        folderPath: ""adfjobs/staging""
                    },
                    integrationRuntime: {
                        referenceName: ""dataflowIR10minTTL"",
                        type: ""IntegrationRuntimeReference""
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string CopyActivity_DelimitedText_GoogleCloudStorage = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""GoogleCloudStorageReadSettings"",
              ""recursive"": true,
              ""prefix"": ""fakeprefix"",
              ""wildcardFileName"": ""*.csv"",
              ""wildcardFolderPath"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_AzureFileStorage = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureFileStorageReadSettings"",
              ""recursive"": true,
              ""wildcardFileName"": ""*.csv"",
              ""wildcardFolderPath"": ""A*"",
              ""modifiedDatetimeStart"":  ""2019-07-02T00:00:00.000Z"",
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z"",
              ""enablePartitionDiscovery"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""skipLineCount"": 10,
              ""additionalNullValues"": [ ""\\N"", ""NULL"" ]
            }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy""
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""quoteAllText"": true,
              ""fileExtension"": "".csv""
            }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""name"": ""ExampleCopyActivity""
      }
    ]
  }
}";
    }
}
