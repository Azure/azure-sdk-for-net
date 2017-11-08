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
        
    }
}
