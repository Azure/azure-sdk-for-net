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
    public class TableTests : UnitTestBase
    {
        private DatasetOperations Operations
        {
            get 
            {
                return (DatasetOperations)this.Client.Datasets;
            }
        }

        [Theory, ClassData(typeof(DatasetJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableJsonConstsToWrappedObjectTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestTableJson);
        }

        [Theory, ClassData(typeof(DatasetJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableValidateJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestTableValidation);
        }

        [Theory, InlineData(@"{
    name: ""Test-BYOC-HDInsight-Dataset"",
    properties:
    {
        type: ""AzureSqlTable"",
        typeProperties: { }
    }
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableMissingRequiredPropertiesThrowsExceptionTest(string invalidJson)
        {
            // tableName is required
            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestTableValidation(invalidJson));
            Assert.Contains("is required", ex.Message);
        }

        [Theory, ClassData(typeof(DatasetJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableWithExtraPropertiesTest(JsonSampleInfo sampleInfo)
        {
            if (sampleInfo.Version != null 
                && sampleInfo.Version.Equals(JsonSampleType.ExtraProperties, StringComparison.Ordinal))
            {
                JsonSampleCommon.TestJsonSample(sampleInfo, this.TestTableJson);
            }
        }

        [Theory, InlineData(@"
{
    name: ""Test-Unregistered-Dataset"",
    properties:
    {
        type: ""MyUnregisteredCustomType"",
        typeProperties:
        {
            endpoint: ""https://some.endpoint.com/"",
            apiKey:""testApiKey""
        }
    }
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableUnregisteredTypeTest(string unregisteredTypeJson)
        {
            // If a Dataset type has not been locally registered, 
            // typeProperties should be deserialized to a GenericTableInstance
            Dataset dataset = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericDataset>(dataset.Properties.TypeProperties);
        }

        private void TestTableJson(JsonSampleInfo info)
        {
            string json = info.Json;
            Dataset dataset = this.ConvertToWrapper(json);
            CoreModel.Dataset actual = this.Operations.Converter.ToCoreType(dataset);
            string actualJson = Core.DataFactoryManagementClient.SerializeInternalDatasetToJson(actual);
            
            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);

            if (info.Version == null
                || !info.Version.Equals(JsonSampleType.Unregistered, StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsNotType<GenericDataset>(dataset.Properties.TypeProperties);
            }

            JObject actualJObject = JObject.Parse(actualJson);
            JsonComparer.ValidatePropertyNameCasing(actualJObject, true, string.Empty, info.PropertyBagKeys);
        }

        private void TestTableValidation(JsonSampleInfo sampleInfo)
        {
            this.TestTableValidation(sampleInfo.Json);
        }
        
        private void TestTableValidation(string json)
        {
            Dataset dataset = this.ConvertToWrapper(json);
            this.Operations.ValidateObject(dataset);
        }

        private Dataset ConvertToWrapper(string json)
        {
            CoreModel.Dataset internalTable =
                Core.DataFactoryManagementClient.DeserializeInternalDatasetJson(json);

            return this.Operations.Converter.ToWrapperType(internalTable);
        }
    }
}
