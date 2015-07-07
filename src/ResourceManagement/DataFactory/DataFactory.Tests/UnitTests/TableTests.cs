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
    public class TableTests : UnitTestBase
    {
        private TableOperations Operations
        {
            get 
            {
                return (TableOperations)this.Client.Tables;
            }
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableJsonConstsToWrappedObjectTest()
        {
            IEnumerable<JsonSampleInfo> samples =
                JsonSampleCommon.GetJsonSamplesFromType<TableJsonSamples>();

            this.TestTableJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableValidateJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples =
                JsonSampleCommon.GetJsonSamplesFromType<TableJsonSamples>();

            this.TestTableValidateSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableMissingRequiredPropertiesThrowsExceptionTest()
        {
            // tableName is required
            string invalidJson = @"{
    name: ""Test-BYOC-HDInsight-Table"",
    properties:
    {
        type: ""AzureSqlTable"",
        typeProperties: { }
    }
}";

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestTableValidation(invalidJson));
            Assert.Contains("is required", ex.Message);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableWithExtraPropertiesTest()
        {
            IEnumerable<JsonSampleInfo> samples =
                JsonSampleCommon.GetJsonSamplesFromType<TableJsonSamples>()
                    .Where(s => s.Version != null && s.Version.Equals(JsonSampleType.ExtraProperties));

            this.TestTableJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void TableUnregisteredTypeTest()
        {
            string unregisteredTypeJson = @"
{
    name: ""Test-Unregistered-Table"",
    properties:
    {
        type: ""MyUnregisteredCustomType"",
        typeProperties:
        {
            endpoint: ""https://some.endpoint.com/"",
            apiKey:""testApiKey""
        }
    }
}";

            // If a table type has not been locally registered, 
            // typeProperties should be deserialized to a GenericTableInstance
            Table table = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericDataset>(table.Properties.TypeProperties);
        }

        private void TestTableJsonSamples(IEnumerable<JsonSampleInfo> samples)
        {
            JsonSampleCommon.TestJsonSamples(samples, this.TestTableJson);
        }

        private void TestTableValidateSamples(IEnumerable<JsonSampleInfo> samples)
        {
            Action<JsonSampleInfo> testSample = sampleInfo => this.TestTableValidation(sampleInfo.Json);
            JsonSampleCommon.TestJsonSamples(samples, testSample);
        }

        private void TestTableJson(JsonSampleInfo info)
        {
            string json = info.Json;
            Table table = this.ConvertToWrapper(json);
            CoreModel.Table actual = this.Operations.Converter.ToCoreType(table);
            string actualJson = Core.DataFactoryManagementClient.SerializeInternalTableToJson(actual);
            
            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);

            if (info.Version == null
                || !info.Version.Equals(JsonSampleType.Unregistered, StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsNotType<GenericDataset>(table.Properties.TypeProperties);
            }
        }

        private void TestTableValidation(string json)
        {
            Table table = this.ConvertToWrapper(json);
            this.Operations.Converter.ValidateWrappedObject(table);
        }

        private Table ConvertToWrapper(string json)
        {
            CoreModel.Table internalTable =
                Core.DataFactoryManagementClient.DeserializeInternalTableJson(json);

            return this.Operations.Converter.ToWrapperType(internalTable);
        }
    }
}
