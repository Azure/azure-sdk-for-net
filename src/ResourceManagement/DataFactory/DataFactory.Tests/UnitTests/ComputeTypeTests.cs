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
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Registration.Models;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions;
using Core = Microsoft.Azure.Management.DataFactories.Core;
using CoreRegistrationModel = Microsoft.Azure.Management.DataFactories.Core.Registration.Models;

namespace DataFactory.Tests.UnitTests
{
    public class ComputeTypeTests : UnitTestBase
    {
        private ComputeTypeOperations Operations
        {
            get 
            {
                return (ComputeTypeOperations)this.Client.ComputeTypes;
            }
        }

        [Theory, ClassData(typeof(RegisteredComputeTypeJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ComputeTypeJsonConstsToWrappedObjectTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestComputeTypeJson);
        }

        private void TestComputeTypeJson(JsonSampleInfo sampleInfo)
        {
            string json = sampleInfo.Json;
            ComputeType computeType = this.ConvertToWrapper(json);
            CoreRegistrationModel.ComputeType actual = this.Operations.Converter.ToCoreType(computeType);

            string actualJson = Core.DataFactoryManagementClient.SerializeInternalComputeTypeToJson(actual);

            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);
            Assert.False(actualJson.Contains("ServiceExtraProperties"));

            JObject actualJObject = JObject.Parse(actualJson);
            JsonComparer.ValidatePropertyNameCasing(actualJObject, true, string.Empty, sampleInfo.PropertyBagKeys);
        }

        private ComputeType ConvertToWrapper(string json)
        {
            CoreRegistrationModel.ComputeType internalComputeType =
                Core.DataFactoryManagementClient.DeserializeInternalComputeTypeJson(json);

            return this.Operations.Converter.ToWrapperType(internalComputeType);
        }
    }
}
