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


using DataFactory.Tests.Framework;
using Microsoft.Azure.Management.DataFactories.Core;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;
using Xunit.Extensions;

namespace DataFactory.Tests.UnitTests
{
    public class ActivityWindowOperationsTests : UnitTestBase
    {
        [Theory, InlineData(
@"{
  ""resourceGroupName"": ""3d704657-08fe-4de4-b842-8b3e7fff9d93"",
  ""dataFactoryName"": ""8fc9f7be-741d-4520-b72d-5df8215edbb9"",
  ""top"": 4,
  ""runStart"": ""2016-01-01T00:00:00"",
  ""runEnd"": ""2016-02-01T00:00:00"",
  ""windowStart"": ""2016-03-01T00:00:00"",
  ""windowEnd"": ""2016-03-02T00:00:00"",
  ""windowState"": ""pending"",
  ""orderBy"": ""WindowState"",
  ""filter"": ""WindowState eq Pending""
}",

@"{
  ""value"": {
    activityWindows: [
      {
        ""resourceGroupName"": ""rgName"",
        ""dataFactoryName"": ""dfName"",
        ""pipelineName"": ""DA_WikipediaClickEvents"",
        ""activityName"": ""DA_WikipediaClickEvents"",
        ""linkedServiceName"": ""LS_Wikipedia"",
        ""activityType"": ""Copy"",
        ""runAttempts"": 1,
        ""runStart"": ""2016-01-26T21:41:48.636Z"",
        ""runEnd"": ""2016-01-26T21:41:48.886Z"",
        ""duration"": ""00:00:00.0000250"",
        ""percentComplete"": 100,
        ""windowStart"": ""2016-01-25T12:00:00Z"",
        ""windowEnd"": ""2016-01-25T13:00:00Z"",
        ""windowState"": ""Pending"",
        ""windowSubstate"": ""Validating"",
        ""inputDatasets"": [""DA_WikipediaEvents""],
        ""outputDatasets"": [
          ""DA_WikipediaClickEvents""
        ],
        ""inputDatasetIds"": [""308F5E07-5B0C-4AE9-95EB-9CEF26CFDD21""],
        ""outputDatasetIds"": [
          ""1e4a0e42-5df3-4a7e-9860-7f75d306ff75""
        ]
      }
    ],
    ""lastUpdate"": ""2016-01-26T21:43:45.6837301+00:00"",
    ""aggregates"": {}
  },
    ""nextLink"": ""https://localhost:86/subscriptions/32345F5E07-5B0C-4AE9-95EB-9CEF26CFDD321/resourcegroups/rgName/datafactories/dfName/activitywindows/skip=FG154H?ApiVerion01012015""}
")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TestListActivityWindowsDeserialize(string jsonRequest, string jsonResponse)
        {
            ActivityWindowListResponse response = ConvertToWrapper(jsonRequest, jsonResponse);
            Assert.NotNull(response);
            Assert.NotNull(response.ActivityWindowListResponseValue);
            Assert.NotNull(response.NextLink);
            Assert.NotNull(response.ActivityWindowListResponseValue.ActivityWindows);
            Assert.NotNull(response.ActivityWindowListResponseValue.LastUpdate);
        }

        private ActivityWindowListResponse ConvertToWrapper(string jsonRequest, string jsonResponse)
        {
            ActivityWindowListResponse listActivityWindows =
                DataFactoryManagementClient.DeserializeActivityWindow(jsonRequest, jsonResponse);

            return listActivityWindows;
        }
    }
}
