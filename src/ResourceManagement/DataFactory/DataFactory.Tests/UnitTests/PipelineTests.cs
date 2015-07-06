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

using System;
using System.Collections.Generic;
using System.Linq;
using DataFactory.Tests.Framework;
using DataFactory.Tests.Framework.JsonSamples;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;
using Core = Microsoft.Azure.Management.DataFactories.Core;
using CoreModel = Microsoft.Azure.Management.DataFactories.Core.Models;
    
namespace DataFactory.Tests.UnitTests
{
    public class PipelineTests : UnitTestBase
    {
        private PipelineOperations Operations
        {
            get
            {
                return (PipelineOperations)this.Client.Pipelines;
            } 
        }
        
        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineJsonConstsToWrappedObjectTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<PipelineJsonSamples>();
            this.TestPipelineJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineValidateJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<PipelineJsonSamples>();
            this.TestPipelineValidateSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineActivityMissingRequiredPropertiesThrowsExceptionTest()
        {
            // copySource and copySink are required for a CopyActivity
            string invalidJson = @"
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
                type: ""Copy"",
                typeProperties: { },
                linkedServiceName: ""MyLinkedServiceName""
            }
        ],
        start: ""2001-01-01"",
        end: ""2001-01-01"",
        isPaused: false
    }
}
";

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestPipelineValidation(invalidJson));
            Assert.Contains("is required", ex.Message);
        }

//        [Fact]
//        [Trait(TraitName.TestType, TestType.Unit)]
//        [Trait(TraitName.Function, TestType.Conversion)]
//        public void PipelineWithExtraPropertiesTest()
//        {
//            List<JsonSampleInfo> samples =
//                JsonSampleCommon.GetJsonSamplesFromType<PipelineJsonSamples>()
//                    .Where(s => s.Version != null && s.Version.Equals("ExtraProperties"))
//                    .ToList();

//            Assert.NotEmpty(samples);
//            this.TestPipelineJsonSamples(samples);
//        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineUnregisteredActivityTypeTest()
        {
            string unregisteredTypeJson = @"
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
                type: ""SomeUnregisteredActivityType"",
                typeProperties:
                {
                    script: ""SELECT 1""
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

            // If an activity type has not been locally registered, 
            // typeProperties should be deserialized to a CustomActivity
            Pipeline pipeline = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericActivity>(pipeline.Properties.Activities[0].TypeProperties);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineGetDebugInfoTest()
        {
            // If an activity type has not been locally registered, 
            // typeProperties should be deserialized to a CustomActivity
            string pipelineJson = PipelineJsonSamples.HDInsightPipeline;
            Assert.Contains("getDebugInfo", pipelineJson);
            Pipeline pipeline = this.ConvertToWrapper(PipelineJsonSamples.HDInsightPipeline);

            HDInsightHiveActivity hiveActivity = pipeline.Properties.Activities[0].TypeProperties as HDInsightHiveActivity;

            Assert.NotNull(hiveActivity);
            Assert.True(hiveActivity.GetDebugInfo == "Failure");
        }

        private void TestPipelineJsonSamples(IEnumerable<JsonSampleInfo> samples)
        {
            JsonSampleCommon.TestJsonSamples(samples, this.TestPipelineJson);
        }

        private void TestPipelineValidateSamples(IEnumerable<JsonSampleInfo> samples)
        {
            Action<JsonSampleInfo> testSample = sampleInfo => this.TestPipelineValidation(sampleInfo.Json);
            JsonSampleCommon.TestJsonSamples(samples, testSample);
        }

        private void TestPipelineJson(JsonSampleInfo sampleInfo)
        {
            string json = sampleInfo.Json;
            Pipeline pipeline = this.ConvertToWrapper(json);
            CoreModel.Pipeline actual = this.Operations.Converter.ToCoreType(pipeline);

            string actualJson = Core.DataFactoryManagementClient.SerializeInternalPipelineToJson(actual);

            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);
            Assert.DoesNotContain("ServiceExtraProperties", actualJson);

            if (sampleInfo.Version == null)
            {
                foreach (Activity activity in pipeline.Properties.Activities)
                {
                    Assert.IsNotType<GenericActivity>(activity.TypeProperties);
                }
            }
        }

        private void TestPipelineValidation(string json)
        {
            Pipeline pipeline = this.ConvertToWrapper(json);
            this.Operations.ValidateObject(pipeline);
        }

        private Pipeline ConvertToWrapper(string json)
        {
            CoreModel.Pipeline internalPipeline =
                Core.DataFactoryManagementClient.DeserializeInternalPipelineJson(json);

            return this.Operations.Converter.ToWrapperType(internalPipeline);
        }
    }
}
