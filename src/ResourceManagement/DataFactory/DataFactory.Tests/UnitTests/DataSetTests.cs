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
using DataFactory.Tests.Framework.JsonSamples;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Runtime;
using Newtonsoft.Json;
using Xunit;
using Xunit.Extensions;
using Core = Microsoft.Azure.Management.DataFactories.Core;

namespace DataFactory.Tests.UnitTests
{
    public class DataSetTests : UnitTestBase
    {
        private readonly TableConverter tableConverter = new TableConverter();
        private readonly LinkedServiceConverter linkedServiceConverter = new LinkedServiceConverter();

        [Theory, ClassData(typeof(LinkedServiceJsonSamples)), ClassData(typeof(CustomLinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void DataSetLinkedServiceJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceJsonSample);
        }

        [Theory, ClassData(typeof(DatasetJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void DataSetTableJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestTableJsonSample);
        }

        private void TestLinkedServiceJsonSample(JsonSampleInfo sampleInfo)
        {
            Core.Models.LinkedService linkedService =
                Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(sampleInfo.Json);

            var expectedDataSet = new DataSet()
            {
                LinkedService = this.linkedServiceConverter.ToWrapperType(linkedService)
            };

            this.TestDataSetJsonSample("linkedService", expectedDataSet, sampleInfo);
        }

        private void TestTableJsonSample(JsonSampleInfo sampleInfo)
        {
            Core.Models.Dataset table =
                Core.DataFactoryManagementClient.DeserializeInternalDatasetJson(sampleInfo.Json);

            var expectedDataSet = new DataSet()
            {
                Table = this.tableConverter.ToWrapperType(table)
            };

            this.TestDataSetJsonSample("table", expectedDataSet, sampleInfo);
        }

        private void TestDataSetJsonSample(string token, DataSet expectedDataSet, JsonSampleInfo sampleInfo)
        {
            DataSet actualDataSet =
                JsonConvert.DeserializeObject<DataSet>(string.Concat("{ \"", token, "\" : ", sampleInfo.Json, "}"));
            Common.ValidateAreSame(expectedDataSet, actualDataSet); 
        }
    }
}
