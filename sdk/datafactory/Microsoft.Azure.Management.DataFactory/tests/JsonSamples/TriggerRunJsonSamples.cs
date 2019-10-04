// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;

namespace DataFactory.Tests.JsonSamples
{
    public class TriggerRunJsonSamples : JsonSampleCollection<TriggerRunJsonSamples>
    {
        [JsonSample]
        public const string ChainingTriggerRunSample = @"
    {
        ""value"": [
          {
            ""triggerName"": ""chainingTrigger"",
            ""triggerRunId"": ""8e2dc34d-2c0d-455a-a339-c48531129f1d"",
            ""triggerType"": ""ChainingTrigger"",
            ""triggerRunTimestamp"": ""2019-09-03T19:21:25.696491Z"",
            ""status"": ""Succeeded"",
            ""message"": null,
            ""properties"": {
              ""TriggerTime"": ""9/3/2019 7:23:44 PM""
            },
            ""triggeredPipelines"": {
              ""childPipeline"": ""d93fc338-d2ac-4e81-9f2a-0af9d1347d5b""
            },
            ""groupId"": ""8e2dc34d-2c0d-455a-a339-c48531129f1d"",
            ""dependencyStatus"": {
              ""parentPipeline1"": {
                ""Id"": ""46e0c003-e1c5-4d44-abd3-433177c41684"",
                ""Status"": ""Succeeded"",
                ""RunStart"": ""2019-09-03T19:21:25.696491Z""
              },
              ""parentPipeline2"": {
                ""Id"": ""9353ea77-4ce0-458c-8431-21033494475e"",
                ""Status"": ""Succeeded"",
                ""RunStart"": ""2019-09-03T19:23:31.8215466Z""
              }
            },
            ""runDimension"": {
              ""JobId"": ""bc5df11f-1e94-4d86-b0bf-d99c786f1419""
            }
          }
        ]
      }";

    }
}
