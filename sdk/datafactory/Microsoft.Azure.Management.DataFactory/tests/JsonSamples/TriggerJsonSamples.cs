// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class TriggerJsonSamples : JsonSampleCollection<TriggerJsonSamples>
    {
        [JsonSample]
        public const string BlobTriggerSample = @"
{
  name: ""myDemoTrigger"",
  properties: {
    type: ""BlobTrigger"",
    typeProperties: {
      maxConcurrency: 10,
      folderPath: ""blobtriggertestpath"",
      linkedService: {
        referenceName: ""StorageLinkedService"",
        type: ""LinkedServiceReference""
      }
    },
    pipelines: [
      {
        pipelineReference: {
          type: ""PipelineReference"",
          referenceName: ""DemoPipeline""
        },
        parameters: {
          mySinkDatasetFolderPath: ""blobtriggertestoutput"",
          mySourceDatasetFolderPath: {
            type: ""Expression"",
            value: ""@split(triggerBody().path, '/')[1]""
          },
          mySourceDatasetFilePath: {
            type: ""Expression"",
            value: ""@split(triggerBody().path, '/')[2]""
          }
        }
      }
    ]
  }
}";

        [JsonSample]
        public const string BlobEventsTriggerSample = @"
{
  name: ""myDemoBlobEventsTrigger"",
  properties: {
    type: ""BlobEventsTrigger"",
    typeProperties: {
      blobPathBeginsWith: ""/containerName/blobs/folderName"",
      events: [
        ""Microsoft.Storage.BlobCreated""
      ],
      scope: ""/subscriptions/297556dc-ea2f-4d52-b390-084a6fc53194/resourceGroups/testresourcegroup/providers/Microsoft.Storage/storageAccounts/teststorageaccount"",
    },
    pipelines: [
      {
        pipelineReference: {
          type: ""PipelineReference"",
          referenceName: ""myCopyPipeline""
        },
        parameters: {
          mySinkDatasetFolderPath: ""sinkcontainer"",
          mySourceDatasetFolderPath: {
            type: ""Expression"",
            value: ""@triggerBody().folderPath""
          },
          mySourceDatasetFilePath: {
            type: ""Expression"",
            value: ""@triggerBody().fileName""
          }
        }
      }
    ]
  }
}";

        [JsonSample]
        public const string ScheduleTriggerSample = @"
{
    name: ""myDemoScheduleTrigger"",
    properties: {
        type: ""ScheduleTrigger"",
        typeProperties: {
            recurrence: {
                frequency: ""Month"",
                interval: 1,
                timeZone: ""UTC"",
                startTime: ""2017-04-14T13:00:00Z"",
                endTime: ""2018-04-14T13:00:00Z""
            }
        },
        pipelines: [
            {
                pipelineReference: {
                    type: ""PipelineReference"",
                    referenceName: ""myPipeline""
                },
                parameters: {
                    mySinkDatasetFolderPath: {
                        type: ""Expression"",
                        value: ""@{concat('output',formatDateTime(trigger().startTime,'-dd-MM-yyyy-HH-mm-ss-ffff'))}""
                    },
                    mySourceDatasetFolderPath: ""input/""
                }
            }
        ]
    }
}
";

        [JsonSample]
        public const string TumblingWindowTriggerSample = @"
{
  name: ""myDemoTWTrigger"",
  properties: {
    type: ""TumblingWindowTrigger"",
    typeProperties: {
      frequency: ""Hour"",
      interval: 24,
      startTime: ""2017-04-14T13:00:00Z"",
      endTime: ""2018-04-14T13:00:00Z"",
      delay: ""00:00:01"",
      retryPolicy: {
        count: 3,
        intervalInSeconds: 30
      },
      maxConcurrency: 10
    },
    pipeline: {
      pipelineReference: {
        type: ""PipelineReference"",
        referenceName: ""myPipeline""
      },
      parameters: {
        windowStart: {
          type: ""Expression"",
          value: ""@{trigger().outputs.windowStartTime}""
        },
        windowEnd: {
          type: ""Expression"",
          value: ""@{trigger().outputs.windowEndTime}""
        },
      }
    }
  }
}
";

        [JsonSample]
        public const string TumblingWindowTriggerWithDependencySample = @"
{
  name: ""myDemoTWTriggerWithDependency"",
  properties: {
    type: ""TumblingWindowTrigger"",
    typeProperties: {
      frequency: ""Hour"",
      interval: 24,
      startTime: ""2017-04-14T13:00:00Z"",
      endTime: ""2018-04-14T13:00:00Z"",
      delay: ""00:00:01"",
      retryPolicy: {
        count: 3,
        intervalInSeconds: 30
      },
      maxConcurrency: 10,
      dependsOn: [{
        type: ""TumblingWindowTriggerDependencyReference"",
        referenceTrigger: {
          type: ""TriggerReference"",
          referenceName: ""myDemoTWTrigger1""
        },
        offset: ""00:00:00"",
        size: ""02:00:00""
      },
      {
        type: ""TumblingWindowTriggerDependencyReference"",
        referenceTrigger: {
          type: ""TriggerReference"",
          referenceName: ""myDemoTWTrigger2""
        },
        offset: ""-00:30:00"",
        size: ""00:30:00""
      }]
    },
    pipeline: {
      pipelineReference: {
        type: ""PipelineReference"",
        referenceName: ""myPipeline""
      },
      parameters: {
        windowStart: {
          type: ""Expression"",
          value: ""@{trigger().outputs.windowStartTime}""
        },
        windowEnd: {
          type: ""Expression"",
          value: ""@{trigger().outputs.windowEndTime}""
        },
      }
    }
  }
}
";

    }
}
