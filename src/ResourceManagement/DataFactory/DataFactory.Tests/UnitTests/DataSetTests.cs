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
using System;
using System.Collections.Generic;
using Xunit;
using Core = Microsoft.Azure.Management.DataFactories.Core;

namespace DataFactory.Tests.UnitTests
{
    public class DataSetTests : UnitTestBase
    {
        private TableConverter tableConverter = new TableConverter();
        private LinkedServiceConverter linkedServiceConverter = new LinkedServiceConverter();

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void DataSetLinkedServiceJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<LinkedServiceJsonSamples>();
            this.TestLinkedServiceJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void DataSetCustomLinkedServiceJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<CustomLinkedServiceJsonSamples>();
            this.TestLinkedServiceJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void DataSetTableJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<TableJsonSamples>();
            this.TestTableJsonSamples(samples);
        }

        private void TestTableJsonSamples(IEnumerable<JsonSampleInfo> samples)
        {
            TestJsonSamples(samples, "table", json =>
            {
                Core.Models.Table table = Core.DataFactoryManagementClient.DeserializeInternalTableJson(json);

                return new DataSet()
                {
                    Table = this.tableConverter.ToWrapperType(table)
                };
            });
        }

        private void TestLinkedServiceJsonSamples(IEnumerable<JsonSampleInfo> samples)
        {
            TestJsonSamples(samples, "linkedService", json =>
            {
                Core.Models.LinkedService linkedService = Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(json);

                return new DataSet()
                {
                    LinkedService = this.linkedServiceConverter.ToWrapperType(linkedService)
                };
            });
        }

        private void TestJsonSamples(IEnumerable<JsonSampleInfo> samples, string token, Func<string, DataSet> getDataSet)
        {
            foreach (JsonSampleInfo sample in samples)
            {
                DataSet expectedDataSet = getDataSet(sample.Json);
                DataSet actualDataSet = JsonConvert.DeserializeObject<DataSet>(string.Concat("{ \"", token, "\" : ", sample.Json, "}"));

                Common.ValidateAreSame(expectedDataSet, actualDataSet);
            }
        }
    }
}
