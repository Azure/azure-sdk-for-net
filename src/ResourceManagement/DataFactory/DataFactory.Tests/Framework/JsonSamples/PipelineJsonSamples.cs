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
    public class PipelineJsonSamples : JsonSampleCollection<PipelineJsonSamples>
    {
        [JsonSample(JsonSampleType.Unregistered,
            propertyBagKeys:
                new string[]
                    {
                        "properties.activities[0].typeProperties.AssemblyName",
                        "properties.activities[0].typeProperties.SliceStart"
                    })]
        public const string ActivityTypePipeline = @"
{
    name: ""activityType pipeline name"",
    properties: 
    {
        description : ""activityType pipeline description"",
        hubName: ""ActivityHub"",
        activities:
        [
            {
                name: ""activityName"",
                description: ""activity description"", 
                type: ""MyCustomActivity"",
                typeProperties: {                    
                    AssemblyName: ""foo.dll"",
                    SliceStart: ""$$Text.Format('{0:yyyyMMddHH-mm}', Time.AddMinutes(SliceStart, 0))""
                },
                linkedServiceName: ""MyLinkedServiceName"",
                scheduler:
                {
                    offset: ""01:00:00"",
                    interval: 1,
                    anchorDateTime: ""2014-02-27T12:00:00"",
                    frequency: ""Hour""
                }
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false,
        runtimeInfo: 
        {
            deploymentTime: ""2002-01-01""
        }
    }
}
";

        [JsonSample(propertyBagKeys: new string[] 
            { 
                // Identify user-provided property names. These should always be cased exactly as the user specified, rather than converted to camel/Pascal-cased.
                "properties.activities[0].typeProperties.defines.PropertyBagPropertyName1"
            }
        )]
        public const string HDInsightPipeline = @"
{
    name: ""My HDInsight pipeline"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        hubName: ""MyHDIHub"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightHive"",
                typeProperties:
                {
                    script: ""SELECT 1"",
                    storageLinkedServices:
                    [
                        ""SA1"",
                        ""SA2""
                    ],
                    defines:
                    {
                        PropertyBagPropertyName1: ""PropertyBagValue1""
                    },
                    getDebugInfo : ""Failure""
                },
                linkedServiceName: ""MyLinkedServiceName""
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false,
        runtimeInfo: 
        {
            deploymentTime: ""2002-01-01""
        }
    }
}
";

        [JsonSample]
        public const string HDInsightPipeline2 = @"
{
    name: ""My HDInsight pipeline2"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        hubName: ""MyHDIHub"",
        activities:
        [
            {
                name: ""TestActivity"",
                description: ""Test activity description"", 
                type: ""HDInsightHive"",
                typeProperties:
                {
                    scriptPath: ""scripts/script.hql"",
                    scriptLinkedService: ""storageLinkedService1"",
                    storageLinkedServices:
                    [
                        ""storageLinkedService2""
                    ]
                },
                linkedServiceName: ""MyLinkedServiceName"",
                scheduler:
                {
                    offset: ""01:00:00"",
                    interval: 1,
                    anchorDateTime: ""2014-02-27T12:00:00"",
                    frequency: ""Hour""
                }
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false,
        runtimeInfo: 
        {
            deploymentTime: ""2002-01-01""
        }
    }
}
";

        [JsonSample(propertyBagKeys: new string[]
                        {
                            "properties.activities[0].typeProperties.defines.PropertyBagPropertyName1"                     
                        })]
        public const string HDInsightMapReducePipeline = @"
{
    name: ""My HDInsight MapReduce pipeline"",
    properties: 
    {
        description : ""HDInsight pipeline description"",
        hubName: ""MyHDIHub"",
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
                    jarLinkedService: ""storageLinkedService1"",
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
                        ""storageLinkedService2""
                    ], 
					defines:
					{
                        PropertyBagPropertyName1: ""PropertyBagValue1""
					}
                },
                linkedServiceName: ""MyLinkedServiceName"",
                scheduler:
                {
                    offset: ""01:00:00"",
                    interval: 1,
                    anchorDateTime: ""2014-02-27T12:00:00"",
                    frequency: ""Hour""
                }
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false,
        runtimeInfo: 
        {
            deploymentTime: ""2002-01-01""
        }
    }
}
";

        [JsonSample]
        public const string CopySqlToBlob = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL to Blob"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery""
                    },
                    sink:
                    {
                        type: ""BlobSink"",
                        blobWriterAddHeader: true,
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00""
                    },
                },
                inputs: 
                [ 
                    {
                        name: ""InputSqlDA""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""OutputBlobDA""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                },
                scheduler:
                {
                    offset: ""01:00:00"",
                    interval: 1,
                    anchorDateTime: ""2014-02-27T12:00:00"",
                    frequency: ""Hour""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string CopySqlDWToSqlDW = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQLDW to SQLDW"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""$EncryptedString$MyEncryptedQuery"",
                        storedProcedureParameters: {
                            stringData: { value: ""str3"" },
                            id: { value: ""$$Text.Format('{0:yyyy}', SliceStart)"", type: ""Int""}
                        }
                    },
                    sink:
                    {
                        type: ""SqlDWSink"",
                        writeBatchSize: 1000000,
                        writeBatchTimeout: ""01:00:00"",
                        sqlWriterCleanupScript: ""Script"",
                        sliceIdentifierColumnName: ""SliceID""
                    },
                },
                inputs: 
                [ 
                    {
                        name: ""InputSqlDWDA""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""OutputSqlDWDA""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string CopyAzureTableToSql = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Azure table to Sql"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        azureTableSourceQuery: ""$$Text.Format('PartitionKey eq \\'ContosoSampleDevice\\' and RowKey eq \\'{0:yyyy-MM-ddTHH:mm:ss.fffffffZ}!{1:yyyy-MM-ddTHH:mm:ss.fffffffZ}\\'', Time.AddMinutes(SliceStart, -10), Time.AddMinutes(SliceStart, -9))"",
                        azureTableSourceIgnoreTableNotFound: ""False""
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
                        name: ""RawBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""ProcessedSQL""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
";

        [JsonSample]
        public const string CopyBlobToAzureQueue = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Blob to Azure Queue"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        treatEmptyAsNull: ""False""
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
                        name: ""RawBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""ProcessedBlob""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
";

        [JsonSample]
        public const string PipelineOptionalHubName = @"
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
                    scriptLinkedService: ""storageLinkedService1"",
                    storageLinkedServices:
                    [
                        ""storageLinkedService2""
                    ]
                },
                linkedServiceName: ""MyLinkedServiceName""
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false,
        runtimeInfo: 
        {
            deploymentTime: ""2002-01-01""
        }
    }
}
";

        [JsonSample(propertyBagKeys: new string[] 
            { 
                // Identify user-provided property names. These should always be cased exactly as the user specified, rather than converted to camel/Pascal-cased.
                "properties.activities[0].typeProperties.extendedProperties.PropertyBagPropertyName1",
                "properties.activities[0].typeProperties.extendedProperties.propertyBagPropertyName2",
            }
        )]
        public const string DotNetActivityPipeline = @"
{
    name: ""DataPipeline_SamplePipeline"",
    properties:
    {
        description : ""Sample Data Pipeline"",
        hubName: ""MyHDIHub"",
        activities:
        [
            {
                name: ""DotNetActivity"",
                inputs: [ {name: ""DA_WikipediaClickEvents""} ],
                outputs: [ {name: ""DA_CuratedWikiData""} ],
                linkedServiceName: ""HDILinkedService"",
                type: ""DotNetActivity"",
                typeProperties:
                {
			        assemblyName: ""mycode.dll"",
                    entryPoint: ""myclassname"",
                    packageLinkedService: ""imagestoreLinkedService"",
                    packageFile: ""images/assembly.zip"",
                    extendedProperties:
                    {
                        PropertyBagPropertyName1: ""PropertyBagValue1"",
                        propertyBagPropertyName2: ""PropertyBagValue2""
                    }
                },
                policy:
                {
                    concurrency: 1,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 2,
                    timeout: ""01:00:00""
                },
                scheduler:
                {
                    offset: ""01:00:00"",
                    interval: 1,
                    anchorDateTime: ""2014-02-27T12:00:00"",
                    frequency: ""Hour""
                }
            },
        ]
    }
}
";

        [JsonSample]
        public const string AzureMLPipeline = @"
{
    name: ""My machine learning pipeline"",
    properties: 
    {
        description : ""ML pipeline description"",
        hubName : ""someHub"",
        activities:
        [
            {
                name: ""MLActivity"",
                description: ""Test activity description"", 
                type: ""AzureMLBatchScoring"",
                typeProperties: { },
                inputs: 
                [ 
                    {
                        name: ""csvBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""sasCopyBlob""
                    }
                ],
                linkedServiceName: ""mlLinkedService"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                        timeout: ""00:00:05"",
                        delay: ""00:00:01""
                }
            }
        ]
    }
}
";

        [JsonSample(propertyBagKeys: new string[]
                    {
                        "properties.activities[0].typeProperties.webServiceParameters.oNe",
                        "properties.activities[0].typeProperties.webServiceParameters.two NAME",
                        "properties.activities[0].typeProperties.webServiceParameters.THREE"
                    })]
        public const string AzureMLPipelineWithWebParams = @"
{
    name: ""My machine learning pipeline2"",
    properties: 
    {
        description : ""ML pipeline description"",
        hubName : ""someHub"",
        activities:
        [
            {
                name: ""MLActivity2"",
                description: ""Test activity description"", 
                type: ""AzureMLBatchScoring"",
                inputs: 
                [ 
                    {
                        name: ""csvBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""sasCopyBlob""
                    }
                ],
                linkedServiceName: ""mlLinkedService"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                },
                typeProperties:
                {
                    webServiceParameters:
                    {
                        ""oNe"": ""one value"",
                        ""two NAME"": ""$$Text.Format('macro{0:yyyyMMddHH-mm}', Time.AddMinutes(SliceStart, 0))"", 
                        ""THREE"": ""HELLO""
                    }
                }
            }
        ]
    }
}
";

//        [JsonSample("ExtraProperties")]
//        public const string ExtraPropertiesPipeline = @"
//{
//    name: ""My machine learning pipeline"",
//    properties: 
//    {
//        description : ""ML pipeline description"",
//        hubName : ""someHub"",
//        activities:
//        [
//            {
//                name: ""MLActivity"",
//                description: ""Test activity description"", 
//                type: ""AzureMLBatchScoringActivity"",
//                typeProperties: { 
//                    extraProp1: ""extraValue1"", 
//                    extraProp2: 5
//                },
//                inputs: 
//                [ 
//                    {
//                        name: ""csvBlob""
//                    }
//                ],
//                outputs: 
//                [ 
//                    {
//                        name: ""sasCopyBlob""
//                    }
//                ],
//                linkedServiceName: ""mlLinkedService"",
//                policy:
//                {
//                    concurrency: 3,
//                    executionPriorityOrder: ""NewestFirst"",
//                    retry: 3,
//                    timeout: ""00:00:05"",
//                    delay: ""00:00:01""
//                }
//            }
//        ]
//    }
//}";

        [JsonSample(propertyBagKeys: new string[]
                {
                        "properties.activities[0].typeProperties.globalParameters.oNe",
                        "properties.activities[0].typeProperties.globalParameters.two NAME",
                        "properties.activities[0].typeProperties.webServiceOutputs.output 1",
                        "properties.activities[0].typeProperties.webServiceInput"
                })]
        public const string AzureMLBatchExecutionPipelineWithAllParams = @"
{
    name: ""My machine learning pipeline3"",
    properties: 
    {
        description : ""ML pipeline description"",
        hubName : ""someHub"",
        activities:
        [
            {
                name: ""MLActivity3"",
                description: ""Test activity description"", 
                type: ""AzureMLBatchExecution"",
                inputs: 
                [ 
                    {
                        name: ""csvBlob"",
                        name: ""someOtherInput""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""someOtherOutput"",
                        name: ""sasCopyBlob""
                    }
                ],
                linkedServiceName: ""mlLinkedService"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                },
                typeProperties:
                {
                    globalParameters:
                    {
                        ""oNe"": ""one value"",
                        ""two NAME"": ""$$Text.Format('macro{0:yyyyMMddHH-mm}', Time.AddMinutes(SliceStart, 0))""
                    },
                    webServiceOutputs:
                    {
                        ""output 1"": ""sasCopyBlob"",
                    },
                    webServiceInput: ""csvBlob""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string AzureMLBatchExecutionPipelineWithNoParams = @"
{
    name: ""My machine learning pipeline3"",
    properties: 
    {
        description : ""ML pipeline description"",
        hubName : ""someHub"",
        activities:
        [
            {
                name: ""MLActivity3"",
                description: ""Test activity description"", 
                type: ""AzureMLBatchExecution"",
                inputs: 
                [ 
                    {
                        name: ""csvBlob"",
                        name: ""someOtherInput""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""someOtherOutput"",
                        name: ""sasCopyBlob""
                    }
                ],
                linkedServiceName: ""mlLinkedService"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                },
            }
        ]
    }
}
";

        [JsonSample(propertyBagKeys: new string[] 
            { 
                // Identify user-provided property names. These should always be cased exactly as the user specified, rather than converted to camel/Pascal-cased.
                "properties.activities[0].typeproperties.defines.PropertyBagPropertyName1"
            }
)]
        public const string StreamingWithExtendedProperties = @"
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
				outputs: [ {""name"": ""OutputTable""} ],
				linkedServiceName: ""HDInsightLinkedService"",
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
					fileLinkedService : ""StorageLinkedService"",
				},
				policy:
				{
					concurrency: 1,
					retry:	1,
					timeout: ""01:00:00""
				}
            }
        ]
    }
}
";

        [JsonSample]
        public const string StoredProcedureActivityPipeline = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Run a SQL stored procedure activity."",
        hubName: ""MyHDIHub"",
        activities:
        [
            {
                type: ""SqlServerStoredProcedure"",
                name: ""MyProcActivity"",
                typeProperties:
                {
                    storedProcedureName: ""StoredProcName"", 
                    storedProcedureParameters: {
                        ""param1"": ""value1"",
                        ""param2"": ""value2"",
                        ""param3"": ""value3"",
                    }
                },
                inputs: 
                [ 
                    {
                        name: ""RawBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""ProcessedBlob""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
";
        [JsonSample]
        public const string CopySqlToBlobWithCopyBehaviorProperty = @"
{
    name: ""MyPipelineName"",
    properties: 
    {
        description : ""Copy from SQL to Blob with CopyBehavior property"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        sqlReaderQuery: ""$EncryptedString$MyEncryptedQuery"",
                        sqlReaderStoredProcedureName: ""$EncryptedString$MyEncryptedQuery"",
                        storedProcedureParameters: {
                            stringData: { value: ""str3"" },
                            id: { value: ""$$Text.Format('{0:yyyy}', SliceStart)"", type: ""Int""}
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
                        name: ""InputSqlDA""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""OutputBlobDA""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName"",
                policy:
                {
                    concurrency: 3,
                    executionPriorityOrder: ""NewestFirst"",
                    retry: 3,
                    timeout: ""00:00:05"",
                    delay: ""00:00:01""
                }
            }
        ]
    }
}
";
        [JsonSample]
        public const string CopyBlobToFileSystemSink = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from Blob to File"",
        hubName: ""MyHDIHub"",
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
                        sourceRetryCount: ""2"",
                        sourceRetryWait: ""00:00:01"",
                        recursive: true,
                        treatEmptyAsNull: ""False""
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
                        name: ""RawBlob""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""ProcessedFileSink""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
";
        [JsonSample]
        public const string CopyFileSystemSourceToFileSystemSink = @"
{
    name: ""MyPipelineName"",
    properties:
    {
        description : ""Copy from File to File"",
        hubName: ""MyHDIHub"",
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
                        name: ""RawFileSource""
                    }
                ],
                outputs: 
                [ 
                    {
                        name: ""ProcessedFileSink""
                    }
                ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
";
    }
}
