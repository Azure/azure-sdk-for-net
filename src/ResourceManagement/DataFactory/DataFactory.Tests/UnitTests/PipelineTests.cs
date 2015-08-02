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
using DataFactory.Tests.Framework;
using DataFactory.Tests.Framework.JsonSamples;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions;
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
        
        [Theory, ClassData(typeof(PipelineJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineJsonConstsToWrappedObjectTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestPipelineJson);
        }

        [Theory, ClassData(typeof(PipelineJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineValidateJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestPipelineValidation);
        }

        [Theory, InlineData(@"
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
")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineActivityMissingRequiredPropertiesThrowsExceptionTest(string invalidJson)
        {
            // copySource and copySink are required for a CopyActivity
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

        [Theory, InlineData(@"
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
")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineUnregisteredActivityTypeTest(string unregisteredTypeJson)
        {
            // If an activity type has not been locally registered, 
            // typeProperties should be deserialized to a CustomActivity
            Pipeline pipeline = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericActivity>(pipeline.Properties.Activities[0].TypeProperties);
        }

        [Theory]
        [InlineData(@"
{
    name: ""MyPipelineName"",
    properties: 
    {
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                typeProperties:
                {
                    source:
                    {
                        type: ""UnknownSource"",
                        sourceRetryCount: ""2"",
                    }
                },
                inputs: [ ],
                outputs: [ ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}
")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void UnknownCopySourceDoesNotThrowExceptionTest(string json)
        {
            Pipeline pipeline = null;

            // When we try to deserialize an unknown nested polymorphic type, 
            // the behavior should be to drop the object (return null) rather than throw an exception
            Assert.DoesNotThrow(() => pipeline = this.ConvertToWrapper(json));
            Assert.Null(((CopyActivity)pipeline.Properties.Activities[0].TypeProperties).Source);
        }

        [Theory]
        [InlineData(@"{
    name: ""MyPipelineName"",
    properties: 
    {
        activities:
        [
            {
                type: ""Copy"",
                name: ""TestActivity"",
                description: ""Test activity description"", 
                typeProperties:
                {
                    source: null,
                    sink: null
                },
                inputs: [ { name: ""InputSqlDA"" } ],
                outputs: [ { name: ""OutputBlobDA"" } ],
                linkedServiceName: ""MyLinkedServiceName""
            }
        ]
    }
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]

        public void CanConvertPipelineWithNullTypePropertyValuesTest(string json)
        {
            JsonSampleInfo sample = new JsonSampleInfo("PipelineWithNullTypePropertyValues", json, null);
            this.TestPipelineJson(sample);
        }

        [Theory, InlineData(PipelineJsonSamples.HDInsightPipeline)]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void PipelineGetDebugInfoTest(string pipelineJson)
        {
            // If an activity type has not been locally registered, 
            // typeProperties should be deserialized to a CustomActivity
            Assert.Contains("getDebugInfo", pipelineJson);
            Pipeline pipeline = this.ConvertToWrapper(PipelineJsonSamples.HDInsightPipeline);

            HDInsightHiveActivity hiveActivity = pipeline.Properties.Activities[0].TypeProperties as HDInsightHiveActivity;

            Assert.NotNull(hiveActivity);
            Assert.True(hiveActivity.GetDebugInfo == "Failure");
        }

        private void TestPipelineJson(JsonSampleInfo sampleInfo)
        {
            string json = sampleInfo.Json;
            Pipeline pipeline = this.ConvertToWrapper(json);
            CoreModel.Pipeline actual = this.Operations.Converter.ToCoreType(pipeline);

            string actualJson = Core.DataFactoryManagementClient.SerializeInternalPipelineToJson(actual);

            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);
            Assert.DoesNotContain("ServiceExtraProperties", actualJson);

            if (sampleInfo.Version == null
                || !sampleInfo.Version.Equals(JsonSampleType.Unregistered, StringComparison.OrdinalIgnoreCase))
            {
                foreach (Activity activity in pipeline.Properties.Activities)
                {
                    Assert.IsNotType<GenericActivity>(activity.TypeProperties);
                }
            }

            JObject actualJObject = JObject.Parse(actualJson);
            JsonComparer.ValidatePropertyNameCasing(actualJObject, true, string.Empty, sampleInfo.PropertyBagKeys);
        }

        private void TestPipelineValidation(string json)
        {
            Pipeline pipeline = this.ConvertToWrapper(json);
            this.Operations.ValidateObject(pipeline);
        }

        private void TestPipelineValidation(JsonSampleInfo sampleInfo)
        {
            this.TestPipelineValidation(sampleInfo.Json);
        }

        private Pipeline ConvertToWrapper(string json)
        {
            CoreModel.Pipeline internalPipeline =
                Core.DataFactoryManagementClient.DeserializeInternalPipelineJson(json);

            return this.Operations.Converter.ToWrapperType(internalPipeline);
        }
    }
}
