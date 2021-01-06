// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class PipelineJsonSamples : JsonSampleCollection<PipelineJsonSamples>
    {
        [JsonSample]
        public const string AzureDatabricksDeltaLakeCopyActivity = @"
{
  ""name"": ""ExampleCopyActivity"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""AzureDatabricksDeltaLakeSource"",
            ""query"": ""abc"",
            ""exportSettings"": {
               ""type"": ""AzureDatabricksDeltaLakeExportCommand"",
               ""dateFormat"": ""xxx"",
               ""timestampFormat"": ""xxx""
             }
          },
          ""sink"": {
            ""type"": ""AzureDatabricksDeltaLakeSink"",
            ""preCopyScript"": ""123"",
            ""importSettings"": {
               ""type"": ""AzureDatabricksDeltaLakeImportCommand"",
               ""dateFormat"": ""xxx"",
               ""timestampFormat"": ""xxx""
             }
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleSourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleSinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}
";

        [JsonSample]
        public const string MongoDbAtlasCopyActivity = @"
{
  ""name"": ""ExampleCopyActivity"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyActivity"",
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""MongoDbAtlasSource"",
            ""filter"": {
                ""value"": ""@dataset().MyFilter""
             },
            ""cursorMethods"": {
                ""project"": {
                  ""value"": ""@dataset().MyProject"",
                  ""type"": ""Expression""
                },
                ""sort"": ""{ age : 1 }"",
                ""skip"": ""3"",
                ""limit"": ""3""
              },
             ""batchSize"": ""5""
          },
          ""sink"": {
            ""type"": ""CosmosDbMongoDbApiSink"",
            ""writeBehavior"": ""upsert"",
            ""writeBatchSize"": ""5000""
          }
        },
        ""inputs"": [
          {
            ""referenceName"": ""exampleSourceDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""exampleSinkDataset"",
            ""type"": ""DatasetReference""
          }
        ]
       }
    ],
    ""parameters"": {
        ""MyFilter"": {
          ""type"": ""String""
        },
        ""MyProject"": {
          ""type"": ""String""
        }
      }
}
}
";

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
        public const string CopySqlToBlobWithPartitionOption = @"
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
                        type: ""AzureSqlSource"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        partitionOption: {
                            ""value"": ""pipeline().parameters.parallelOption"",
                            ""type"": ""Expression""
                        },
                        partitionSettings: 
                        {
                            partitionColumnName: ""partitionColumnName"",
                            partitionUpperBound: ""10"",
                            partitionLowerBound: ""1""
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
                        },
                        isolationLevel: ""ReadCommitted""
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

        [JsonSample]
        public const string WebActivityCertAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebActivity"",
                typeProperties: {
                    method: ""get"",
                    url: ""http://www.test.com"",
                    headers: { 
                        ""Content-Type"": ""application/json"",
                        ""activityName"": ""activityName""
                    },
                    authentication : {
                        type: ""ClientCertificate"",
                        pfx: {
                            type: ""SecureString"",
                            value: ""testcertpfx""
                        },
                        password: {
                            type: ""SecureString"",
                            value: ""testpwd""
                        }
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebActivityBasicAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebActivity"",
                typeProperties: {
                    method: ""get"",
                    url: ""http://www.bing.com"",
                    headers: { 
                        ""Content-Type"": ""application/json"",
                        ""activityName"": ""activityName""
                    },
                    authentication : {
                        type: ""Basic"",
                        username: ""user"",
                        password: {
                            type: ""SecureString"",
                            value: ""testpwd""
                        }
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebActivityAKVBasicAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebActivity"",
                typeProperties: {
                    method: ""get"",
                    url: ""http://www.bing.com"",
                    linkedServices: [],
                    datasets: [],
                    authentication: {
                        type: ""Basic"",
                        username: ""testuser"",
                        password: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                              },
                            secretName: ""pfxpwd""
                      }
                   }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebActivityAKVCertAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebActivity"",
                typeProperties: {
                    method: ""POST"",
                    url: ""https://testwebactivitynnara.azurewebsites.net/api/readpayload"",
                    headers: { 
                        ""Content-Type"": ""application/json"",
                    },
                    authentication : {
                        type: ""ClientCertificate"",
                        pfx: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                            },
                            secretName: ""FrontEndCert""
                        },
                        password: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                            },
                            secretName: ""FrontEndCertPwd""
                        }
                    }
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
        public const string WebActivityWithIR = @"
{
  ""name"": ""MyWebPipelineWithIR"",
  ""properties"": {
    ""activities"": [
      {
        ""name"": ""MyWebActivityIR"",
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
                ],
                ""connectVia"": {
                    referenceName : ""TestIR"",
                    type : ""IntegrationRuntimeReference""
                }
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
                        query: ""$select=Column0"",
                        httpRequestTimeout: ""00:05:00""
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
                    writeBatchSize: 50,
                    httpRequestTimeout: ""00:05:00""
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
                        query: ""$top=1"",
                        httpRequestTimeout: ""00:05:00""
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
        public const string CopyDynamicsAXToAdls = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from DynamicsAX to Azure Data Lake Store"",
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
                        type: ""DynamicsAXSource"",
                        query: ""$top=1"",
                        httpRequestTimeout: ""00:05:00""
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
                        referenceName: ""InputDynamicsAX"", type: ""DatasetReference""
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
                        baseRequestId: ""123"",
                        customRfcReadTableFunctionModule: ""fakecustomRfcReadTableFunctionModule"",
                        sapDataColumnDelimiter: ""|""
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

        [JsonSample]
        public const string WebhookActivityCertAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""Webhook1"",
                type: ""WebHook"",
                typeProperties: {
                    ""url"": ""http://samplesample.azurewebsites.net/api/execute/webhook"",
                    ""method"": ""POST"",
                    ""headers"": {
                        ""Content-Type"": ""application/json""
                    },
                    authentication : {
                        type: ""ClientCertificate"",
                        pfx: {
                            type: ""SecureString"",
                            value: ""testcertpfx""
                        },
                        password: {
                            type: ""SecureString"",
                            value: ""testpwd""
                        }
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebhookActivityBasicAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""Webhook1"",
                type: ""WebHook"",
                typeProperties: {
                    ""url"": ""http://samplesample.azurewebsites.net/api/execute/webhook"",
                    ""method"": ""POST"",
                    ""headers"": {
                        ""Content-Type"": ""application/json""
                    },
                    authentication : {
                        type: ""Basic"",
                        username: ""user"",
                        password: {
                            type: ""SecureString"",
                            value: ""testpwd""
                        }
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebhookActivityAKVBasicAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebHook"",
                typeProperties: {
                    method: ""get"",
                    url: ""http://www.bing.com"",
                    authentication: {
                        type: ""Basic"",
                        username: ""testuser"",
                        password: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                              },
                            secretName: ""pfxpwd""
                      }
                   }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string WebhookActivityAKVCertAuth = @"
{
    name: ""MyWebPipeline"",
    properties: {
        activities: [
            {
                name: ""MyAnonymousWebActivity"",
                type: ""WebHook"",
                typeProperties: {
                    method: ""POST"",
                    url: ""https://testwebactivitynnara.azurewebsites.net/api/readpayload"",
                    headers: { 
                        ""Content-Type"": ""application/json"",
                    },
                    authentication : {
                        type: ""ClientCertificate"",
                        pfx: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                            },
                            secretName: ""FrontEndCert""
                        },
                        password: {
                            type: ""AzureKeyVaultSecret"",
                            store: {
                                referenceName: ""AKVCredens"",
                                type: ""LinkedServiceReference""
                            },
                            secretName: ""FrontEndCertPwd""
                        }
                    }
                }
            }
        ]
    }
}
";

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
        public const string CopyActivity_Excel_Adls = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""ExcelSource"",
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
            },
            ""additionalColumns"": [
              {
                ""name"": ""clmn"",
                ""value"": ""$$FILEPATH""
              }
            ]
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
              ""fileExtension"": "".csv"",
              ""maxRowsPerFile"": 10,
              ""fileNamePrefix"": ""orcSinkFile""
            }
          },
          ""validateDataConsistency"": true,
          ""skipErrorFile"": {
            ""fileMissing"": true,
            ""dataInconsistency"": true
          },
          ""logStorageSettings"": {
            ""linkedServiceName"": {
              ""referenceName"": ""exampleLinkedService"",
              ""type"": ""LinkedServiceReference""
            },
            ""path"": ""test"",
            ""logLevel"": ""exampleLogLevel"",
            ""enableReliableLogging"": true
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
        public const string CopyActivity_DelimitedText_AdlsWithlogSettings = @"{
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
            },
            ""additionalColumns"": [
              {
                ""name"": ""clmn"",
                ""value"": ""$$FILEPATH""
              }
            ]
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
              ""fileExtension"": "".csv"",
              ""maxRowsPerFile"": 10,
              ""fileNamePrefix"": ""orcSinkFile""
            }
          },
          ""validateDataConsistency"": true,
          ""skipErrorFile"": {
            ""fileMissing"": true,
            ""dataInconsistency"": true
          },
          ""logSettings"": {
             ""enableCopyActivityLog"": true,
             ""copyActivityLogSettings"": {
                 ""logLevel"": ""Info"",
                 ""enableReliableLogging"": true
              },
             ""logLocationSettings"": {
                 ""linkedServiceName"": {
                    ""referenceName"": ""exampleLinkedService"",
                    ""type"": ""LinkedServiceReference""
                  },
                ""path"": ""test"" 
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
              ""partitionRootPath"": ""abc/"",
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
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
            ""source"": {
                ""type"": ""DelimitedTextSource"",
                ""storeSettings"": {
                    ""type"": ""AzureBlobStorageReadSettings"",
                    ""recursive"": true
                },
                ""formatSettings"": {
                    ""type"": ""DelimitedTextReadSettings"",
                    ""compressionProperties"": {
                        ""type"": ""ZipDeflateReadSettings"",
                        ""preserveZipFileNameAsFolder"": false
                    }
                }
            },
            ""sink"": {
                ""type"": ""DelimitedTextSink"",
                ""storeSettings"": {
                    ""type"": ""AzureBlobStorageWriteSettings"",
                    ""recursive"": true
                },
                ""formatSettings"": {
                ""type"": ""DelimitedTextWriteSettings"",
                ""fileExtension"": "".txt""
                }
            }
        },
        ""name"": ""DelimitedTextToBlob_Unzip"",
        ""inputs"": [
            {
                ""referenceName"": ""SourceBlobDataset"",
                ""type"": ""DatasetReference""
            }
        ],
        ""outputs"": [
            {
                ""referenceName"": ""SinkBlobDataset"",
                ""type"": ""DatasetReference""
            }
        ]
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_DelimitedText_AzureBlob_UntarGZip = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""compressionProperties"": {
                   ""type"": ""TarGZipReadSettings"",
                   ""preserveCompressionFileNameAsFolder"": false
                 }
             }
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
               ""type"": ""AzureDataLakeStoreWriteSettings"",
               ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""fileExtension"": "".txt""
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
        ""name"": ""DelimitedTextToBlob_UntarGZip""
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
            ""source"": {
                ""type"": ""DelimitedTextSource"",
                ""storeSettings"": {
                    ""type"": ""AzureBlobStorageReadSettings"",
                    ""recursive"": true
                },
                ""formatSettings"": {
                    ""type"": ""DelimitedTextReadSettings"",
                    ""compressionProperties"": {
                        ""type"": ""ZipDeflateReadSettings"",
                        ""preserveZipFileNameAsFolder"": false
                    }
                }
            },
            ""sink"": {
                ""type"": ""DelimitedTextSink"",
                ""storeSettings"": {
                    ""type"": ""AzureBlobStorageWriteSettings"",
                    ""recursive"": true
                },
                ""formatSettings"": {
                    ""type"": ""DelimitedTextWriteSettings"",
                    ""fileExtension"": "".txt""
                }
            }
        },
        ""name"": ""DelimitedTextToBlob_Unzip"",
        ""inputs"": [
            {
                ""referenceName"": ""SourceBlobDataset"",
                ""type"": ""DatasetReference""
            }
        ],
        ""outputs"": [
            {
                ""referenceName"": ""SinkBlobDataset"",
                ""type"": ""DatasetReference""
            }
        ]
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
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z"",
              ""fileFilter"":  ""*.log""
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
              ""modifiedDatetimeEnd"":  ""2019-07-03T00:00:00.000Z"",
              ""deleteFilesAfterCompletion"": true
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
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""JsonSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""JsonReadSettings"",
              ""compressionProperties"": {
                ""type"": ""ZipDeflateReadSettings"",
                ""preserveZipFileNameAsFolder"": false
              }
            },
            ""additionalColumns"": [
              {
                ""name"": ""clmn"",
                ""value"": ""$$FILEPATH""
              }
            ]
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageWriteSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""fileExtension"": "".txt""
            }
          }
        },
        ""name"": ""JsonBlobToBlob_Unzip"",
        ""inputs"": [
          {
            ""referenceName"": ""SourceBlobDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkBlobDataset"",
            ""type"": ""DatasetReference""
          }
        ]
      }
    ]
  }
}";

        [JsonSample]
        public const string CopyActivity_Xml_AzureBlob = @"{
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""XmlSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""wildcardFolderPath"":  ""abc*d"",
              ""wildcardFileName"":  ""*.xml""
            },
            ""formatSettings"": {
              ""type"": ""XmlReadSettings"",
              ""validationMode"": ""xsd""
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
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""XmlSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""XmlReadSettings"",
              ""compressionProperties"": {
                ""type"": ""ZipDeflateReadSettings"",
                ""preserveZipFileNameAsFolder"": false
              }
            },
            ""additionalColumns"": [
              {
                ""name"": ""clmn"",
                ""value"": ""$$FILEPATH""
              }
            ]
          },
          ""sink"": {
            ""type"": ""DelimitedTextSink"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageWriteSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextWriteSettings"",
              ""fileExtension"": "".txt""
            }
          }
        },
        ""name"": ""XmlBlobToBlob_Unzip"",
        ""inputs"": [
          {
            ""referenceName"": ""SourceBlobDataset"",
            ""type"": ""DatasetReference""
          }
        ],
        ""outputs"": [
          {
            ""referenceName"": ""SinkBlobDataset"",
            ""type"": ""DatasetReference""
          }
        ]
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
              ""enablePartitionDiscovery"": true,
              ""fileListPath"": ""test.txt""
            }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""AzureDataLakeStoreWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy"",
              ""expiryDateTime"": ""2018-12-01T05:00:00Z""
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
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""BinarySource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true,
              ""prefix"": ""test""
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
              ""type"": ""FileServerReadSettings"",
              ""recursive"": true,
              ""enablePartitionDiscovery"": true
            },
            ""formatSettings"": {
              ""type"": ""BinaryReadSettings"",
              ""compressionProperties"": {
                ""type"": ""ZipDeflateReadSettings"",
                ""preserveZipFileNameAsFolder"": false
              }
            }
          },
          ""sink"": {
            ""type"": ""BinarySink"",
            ""storeSettings"": {
              ""type"": ""SftpWriteSettings"",
              ""maxConcurrentConnections"": 3,
              ""copyBehavior"": ""PreserveHierarchy"",
              ""operationTimeout"": ""01:00:00"",
              ""useTempFileRename"": false
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
        public const string CopyActivity_Teradata_Binary = @"{
  ""name"": ""MyPipeline"",
  ""properties"": {
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""TeradataSource"",
            ""partitionOption"": {
                            ""value"": ""pipeline().parameters.parallelOption"",
                            ""type"": ""Expression""
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
                        sapDataColumnDelimiter: ""|"",
                        partitionOption: {
                            ""value"": ""pipeline().parameters.parallelOption"",
                            ""type"": ""Expression""
                        },
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
                        partitionOption: {
                            ""value"": ""pipeline().parameters.parallelOption"",
                            ""type"": ""Expression""
                        },
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
                        query: ""$top=1"",
                        httpRequestTimeout: ""00:05:00""
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
                    },
                    compute: {
                        computeType: ""MemoryOptimized"",
                        coreCount: 8                         
                    }
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string ExecuteDataFlowActivityPipelineWithExpression = @"
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
                    },
                    compute: {
                        computeType:  {
                            value: ""@parameters('MemoryOptimized')"",
                            type: ""Expression""
                        },
                        coreCount: {
                           value: ""@parameters('8')"",
                           type: ""Expression""
                        },                       
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
      },
      {
        ""type"": ""Copy"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureFileStorageReadSettings"",
              ""recursive"": true,
              ""prefix"": ""prefix"",
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

        [JsonSample]
        public const string ExecuteSSISPackageEmbeddedPackagePipeline = @"{
    ""name"": ""SSISEmbeddPackage"",
    ""properties"": {
        ""activities"": [
            {
                ""name"": ""Execute SSIS package1"",
                ""type"": ""ExecuteSSISPackage"",
                ""typeProperties"": {
                    ""packageLocation"": {
                        ""type"": ""InlinePackage"",
                        ""typeProperties"": {
                            ""packagePassword"": {
                                type: ""SecureString"",
                                value: ""microsoft123!""
                            },
                            ""packageName"": ""funcInlinePackage.dtsx"",
                            ""packageContent"": ""VER001_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"",
                            ""packageLastModifiedDate"": ""2019-04-26T18:32:46.260Z UTC+08:00""
                        }
                    },
                    ""connectVia"": {
                        ""referenceName"": ""integrationRuntime1"",
                        ""type"": ""IntegrationRuntimeReference""
                    }
                }
            }
        ]
    }
}";

        [JsonSample(version: "Copy")]
        public const string CopyCsvToSqlDW_WithCopyCommand = @"
{
  ""name"": ""MyPipelineName"",
  ""properties"": {
    ""description"" : ""Copy from CSV to SQL DW with Copy Command"",
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""name"": ""TestActivity"",
        ""description"": ""Test activity description"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""rowDelimiter"": ""\n"",
              ""quoteChar"": ""\"""",
              ""escapeChar"": ""\""""
            }
          },
          ""sink"": {
            ""type"": ""SqlDWSink"",
            ""allowCopyCommand"": true,
            ""copyCommandSettings"": {
              ""defaultValues"": [
                {
                  ""columnName"": ""col_string"",
                  ""defaultValue"": ""Cincinnati""
                },
                {
                  ""columnName"": ""col_binary"",
                  ""defaultValue"": ""0xAE""
                },
                {
                  ""columnName"": ""col_datetime"",
                  ""defaultValue"": ""December 5, 1985""
                },
                {
                  ""columnName"": ""col_integer"",
                  ""defaultValue"": ""1894""
                },
                {
                  ""columnName"": ""col_decimal"",
                  ""defaultValue"": ""12.345000000""
                },
                {
                  ""columnName"": ""col_float"",
                  ""defaultValue"": ""0.5E-2""
                },
                {
                  ""columnName"": ""col_money"",
                  ""defaultValue"": ""$542023.14""
                },
                {
                  ""columnName"": ""col_uniqueidentifier1"",
                  ""defaultValue"": ""6F9619FF-8B86-D011-B42D-00C04FC964FF""
                }
              ],
              ""additionalOptions"": {
                ""MAXERRORS"": ""10000"",
                ""DATEFORMAT"": ""'ymd'""
              }
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
}
";

        [JsonSample(version: "Copy")]
        public const string CopySapHanaToCsvWithPartition = @"
{
    ""name"": ""MyPipelineName"",
    ""properties"": 
    {
        ""description"" : ""Copy from SAP HANA for Customer to Azure Data Lake Store"",
        ""activities"":
        [
            {
                ""type"": ""Copy"",
                ""name"": ""TestActivity"",
                ""description"": ""Test activity description"", 
                ""typeProperties"":
                {
                    ""source"":
                    {
                        ""type"": ""SapHanaSource"",
                        ""query"": ""$select=Column0"",
                        ""partitionOption"": {
                            ""value"": ""pipeline().parameters.parallelOption"",
                            ""type"": ""Expression""
                        },
                        ""partitionSettings"": {
                            ""partitionColumnName"": ""INTEGERTYPE""
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
                ]
            }
        ]
    }
}
";

        [JsonSample(version: "Copy")]
        public const string CopyBlobToSftp = @"
{
    ""name"": ""MyPipelineName"",
    ""properties"":
    {
        ""description"" : ""Copy from SAP HANA for Customer to Azure Data Lake Store"",
        ""activities"":
        [
            {
                  ""type"": ""Copy"",
                  ""typeProperties"": {
                    ""source"": {
                      ""type"": ""BinarySource"",
                      ""storeSettings"": {
                        ""type"": ""FileServerReadSettings"",
                        ""recursive"": true,
                        ""enablePartitionDiscovery"": true
                      }
                    },
                    ""sink"": {
                      ""type"": ""BinarySink"",
                      ""storeSettings"": {
                        ""type"": ""SftpWriteSettings"",
                        ""maxConcurrentConnections"": 3,
                        ""copyBehavior"": ""PreserveHierarchy"",
                        ""operationTimeout"": ""01:00:00"",
                        ""useTempFileRename"": true
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

        [JsonSample(version: "Copy")]
        public const string SharePointOnlineListPipeline = @"
{
    name: ""DataPipeline_SharePointOnlineListSample"",
    properties:
    {
        activities:
        [
            {
                name: ""SharePointOnlineListToblobCopyActivity"",
                inputs: [ {referenceName: ""DA_Input"", type: ""DatasetReference""} ],
                outputs: [ {referenceName: ""DA_Output"", type: ""DatasetReference""} ],
                type: ""Copy"",
                typeProperties:
                {
                    source:
                    {                               
                        type: ""SharePointOnlineListSource"",
                        query: ""$top=1"",
                        httpRequestTimeout: ""00:05:00""
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
        public const string CopyWithTypeConversion = @"
{
  ""name"": ""MyPipelineName"",
  ""properties"": {
    ""description"" : ""Copy from CSV to SQL DW with Copy Command"",
    ""activities"": [
      {
        ""type"": ""Copy"",
        ""name"": ""TestActivity"",
        ""description"": ""Test activity description"",
        ""typeProperties"": {
          ""source"": {
            ""type"": ""DelimitedTextSource"",
            ""storeSettings"": {
              ""type"": ""AzureBlobStorageReadSettings"",
              ""recursive"": true
            },
            ""formatSettings"": {
              ""type"": ""DelimitedTextReadSettings"",
              ""rowDelimiter"": ""\n"",
              ""quoteChar"": ""\"""",
              ""escapeChar"": ""\""""
            }
          },
          ""sink"": {
            ""type"": ""SqlSink""
          },
          ""translator"": {
            ""type"": ""TabularTranslator"",
            ""mappings"": [
              {
                ""source"": {
                  ""ordinal"": 3
                },
                ""sink"": {
                  ""name"": ""CustomerName""
                }
              },
              {
                ""source"": {
                  ""ordinal"": 2
                },
                ""sink"": {
                  ""name"": ""CustomerAddress""
                }
              },
              {
                ""source"": {
                  ""ordinal"": 1
                },
                ""sink"": {
                  ""name"": ""CustomerDate""
                }
              }
            ],
            ""typeConversion"": true,
            ""typeConversionSettings"": {
              ""allowDataTruncation"": false,
              ""dateTimeFormat"": ""MM/dd/yyyy HH:mm""
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
}
";

        [JsonSample(version: "Copy")]
        public const string CopySqlToRest = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL to Rest"",
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
                        },
                        isolationLevel: ""ReadCommitted""
                    },
                    sink:
                    {
                        type: ""RestSink"",
                        requestMethod: ""POST"",
                        requestInterval: ""00:01:40"",
                        httpRequestTimeout: ""00:01:40"",
                        additionalHeaders:{
                            ""Key"":""Value""
                        },
                        writeBatchSize: 1000,
                        writeBatchTimeout: ""01:00:00"",
                        httpCompressionType: ""gzip""
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
                        referenceName: ""OutputRestDA"", type: ""DatasetReference""
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
    }
}
