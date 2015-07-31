﻿// 
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
using System.Collections.ObjectModel;
using Xunit;
using Xunit.Extensions;
using Core = Microsoft.Azure.Management.DataFactories.Core;

namespace DataFactory.Tests.UnitTests
{
    public class ActivityConfigurationTests : UnitTestBase
    {
        private readonly PipelineConverter pipelineConverter = new PipelineConverter();
        private readonly TableConverter tableConverter = new TableConverter();
        private readonly LinkedServiceConverter linkedServiceConverter = new LinkedServiceConverter();

        [Theory, ClassData(typeof(PipelineJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ActivityConfigurationPipelineJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestPipelineJsonSample);
        }

        [Theory, ClassData(typeof(LinkedServiceJsonSamples)), ClassData(typeof(CustomLinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ActivityConfigurationLinkedServiceJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceJsonSample);
        }

        [Theory, ClassData(typeof(TableJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ActivityConfigurationTableJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestTableJsonSample);
        }

        private void TestLinkedServiceJsonSample(JsonSampleInfo sampleInfo)
        {
            Core.Models.LinkedService linkedServiceIn =
                Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(sampleInfo.Json);

            Core.Models.LinkedService linkedServiceOut =
                Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(sampleInfo.Json);

            var expectedActivityConfiguration = new ActivityConfiguration()
            {
                Inputs = new Collection<ResolvedTable>()
                {
                    new ResolvedTable()
                    {
                        LinkedService = this.linkedServiceConverter.ToWrapperType(linkedServiceIn),
                    },
                },
                Outputs = new Collection<ResolvedTable>()
                {
                    new ResolvedTable()
                    {
                        LinkedService = this.linkedServiceConverter.ToWrapperType(linkedServiceOut),
                    },
                },
            };

            this.TestJsonSample(string.Concat("{ \"inputs\" : [{ \"linkedService\":", sampleInfo.Json, "}], \"outputs\" : [{ \"linkedService\":", sampleInfo.Json, "}]}"), expectedActivityConfiguration);
        }

        private void TestTableJsonSample(JsonSampleInfo sampleInfo)
        {
            Core.Models.Table tableIn =
                Core.DataFactoryManagementClient.DeserializeInternalTableJson(sampleInfo.Json);

            Core.Models.Table tableOut =
                Core.DataFactoryManagementClient.DeserializeInternalTableJson(sampleInfo.Json);

            var expectedActivityConfiguration = new ActivityConfiguration()
            {
                Inputs = new Collection<ResolvedTable>()
                {
                    new ResolvedTable()
                    {
                        Table = this.tableConverter.ToWrapperType(tableIn),
                    },
                },
                Outputs = new Collection<ResolvedTable>()
                {
                    new ResolvedTable()
                    {
                        Table = this.tableConverter.ToWrapperType(tableOut),
                    },
                },
            };

            this.TestJsonSample(string.Concat("{ \"inputs\" : [{ \"table\":", sampleInfo.Json, "}], \"outputs\" : [{ \"table\":", sampleInfo.Json, "}]}"), expectedActivityConfiguration);
        }

        private void TestPipelineJsonSample(JsonSampleInfo sampleInfo)
        {
            Core.Models.Pipeline pipeline =
                Core.DataFactoryManagementClient.DeserializeInternalPipelineJson(sampleInfo.Json);

            var expectedActivityConfiguration = new ActivityConfiguration()
            {
                Inputs = new Collection<ResolvedTable>(),
                Outputs = new Collection<ResolvedTable>(),
                Pipeline = this.pipelineConverter.ToWrapperType(pipeline)
            };

            this.TestJsonSample(string.Concat("{ \"pipeline\" : ", sampleInfo.Json, "}"), expectedActivityConfiguration);
        }

        private void TestJsonSample(string token, ActivityConfiguration expectedActivityConfiguration)
        {
            ActivityConfiguration actualActivityConfiguration =
                JsonConvert.DeserializeObject<ActivityConfiguration>(token);
            Common.ValidateAreSame(expectedActivityConfiguration, actualActivityConfiguration);
        }
    }
}
