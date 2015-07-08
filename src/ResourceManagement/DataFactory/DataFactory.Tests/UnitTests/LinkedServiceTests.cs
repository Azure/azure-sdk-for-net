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
using DataFactory.Tests.UnitTests.TestClasses;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;
using Core = Microsoft.Azure.Management.DataFactories.Core;
using CoreModel = Microsoft.Azure.Management.DataFactories.Core.Models;

namespace DataFactory.Tests.UnitTests
{
    public class LinkedServiceTests : UnitTestBase
    {
        private LinkedServiceOperations Operations
        {
            get
            {
                return (LinkedServiceOperations)this.Client.LinkedServices;
            }
        }

        #region Tests

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceJsonConstsToWrappedObjectTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<LinkedServiceJsonSamples>();
            this.TestLinkedServiceJsonSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceValidateJsonConstsTest()
        {
            IEnumerable<JsonSampleInfo> samples = JsonSampleCommon.GetJsonSamplesFromType<LinkedServiceJsonSamples>();
            this.TestLinkedServiceValidateSamples(samples);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void CustomLinkedServiceJsonConstsToWrappedObjectTest()
        {
            IEnumerable<JsonSampleInfo> samples =
                JsonSampleCommon.GetJsonSamplesFromType<CustomLinkedServiceJsonSamples>();
            this.TestLinkedServiceJsonSamples(samples, true);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceMissingRequiredPropertiesThrowsExceptionTest()
        {
            // clusterUri, userName and password are required
            string invalidJson = @"{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        typeProperties:
        {
            linkedServiceName: ""MyStorageAssetName""
        }
    }
}
";

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(invalidJson));
            Assert.Contains("is required", ex.Message);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceWithExtraPropertiesTest()
        {
            IEnumerable<JsonSampleInfo> samples =
                JsonSampleCommon.GetJsonSamplesFromType<LinkedServiceJsonSamples>()
                    .Where(s => s.Version != null && s.Version.Equals("ExtraProperties"));

            this.TestLinkedServiceJsonSamples(samples); 
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceUnregisteredTypeTest()
        {
            string unregisteredTypeJson = @"
{
    name: ""Test-Unregistered-Linked-Service"",
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

            // If a linked service type has not been locally registered, 
            // typeProperties should be deserialized to a GenericLinkedServiceInstance
            LinkedService linkedService = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericLinkedService>(linkedService.Properties.TypeProperties);
        }

#if NET45
        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithListProperty()
        {
            string json = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""MyLinkedServiceTypeWithListProperty"",
        typeProperties:
        { 
            list: [
                { number: 1 }, 
                { number: 5 }
            ]
        }
    }
}";

            this.Client.RegisterType<MyLinkedServiceTypeWithListProperty>(true);
            this.TestLinkedServiceJson(json);
            this.TestLinkedServiceValidation(json);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithListPropertyThrowsForMissingRequiredProperty()
        {
            string json = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""MyLinkedServiceTypeWithListProperty"",
        typeProperties:
        { 
            list: [
                { number: 1 }, 
                { }
            ]
        }
    }
}";

            this.Client.RegisterType<MyLinkedServiceTypeWithListProperty>(true);
            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(json));
            Assert.Contains("is required", ex.Message);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithDictionaryProperty()
        {
            string json = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""MyLinkedServiceTypeWithDictionaryProperty"",
        typeProperties:
        { 
            dictionary: {
                item1: { 
                    number: 1 
                }, 
                item2: { 
                    number: 5 
                }
            }
        }
    }
}";

            this.Client.RegisterType<MyLinkedServiceTypeWithDictionaryProperty>(true);
            this.TestLinkedServiceJson(json);
            this.TestLinkedServiceValidation(json);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithDictionaryPropertyThrowsForMissingRequiredProperty()
        {
            string json = @"
{
    name: ""Test-ML-LinkedService"",
    properties:
    {
        type: ""MyLinkedServiceTypeWithDictionaryProperty"",
        typeProperties:
        { 
            dictionary: {
                item1: { }
            }
        }
    }
}";

            this.Client.RegisterType<MyLinkedServiceTypeWithDictionaryProperty>(true);

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(json));
            Assert.Contains("is required", ex.Message);
        }
#endif 

        #endregion Tests

        #region Test helpers

        private void TestLinkedServiceJsonSamples(IEnumerable<JsonSampleInfo> samples, bool customTest = false)
        {
            Action<JsonSampleInfo> testSample;
            if (customTest)
            {
                testSample = sampleInfo => this.TestLinkedServiceCustomJson(sampleInfo.Json);
            }
            else
            {
                testSample = sampleInfo => this.TestLinkedServiceJson(sampleInfo.Json);
            }

            JsonSampleCommon.TestJsonSamples(samples, testSample);       
        }

        private void TestLinkedServiceValidateSamples(IEnumerable<JsonSampleInfo> samples)
        {
            Action<JsonSampleInfo> testSample = sampleInfo => this.TestLinkedServiceValidation(sampleInfo.Json);
            JsonSampleCommon.TestJsonSamples(samples, testSample);
        }

        private LinkedService ConvertAndTestJson(string json)
        {
            LinkedService linkedService = this.ConvertToWrapper(json);
            CoreModel.LinkedService actual = this.Operations.Converter.ToCoreType(linkedService);
            string actualJson = Core.DataFactoryManagementClient.SerializeInternalLinkedServiceToJson(actual);

            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);
            Assert.DoesNotContain("ServiceExtraProperties", actualJson);

            return linkedService;
        }

        private void TestLinkedServiceJson(string json)
        {
            LinkedService linkedService = this.ConvertAndTestJson(json);
            Assert.IsNotType<GenericLinkedService>(linkedService.Properties.TypeProperties);
        }

        private void TestLinkedServiceCustomJson(string json)
        {
            this.ConvertAndTestJson(json);
        }

        private void TestLinkedServiceValidation(string json)
        {
            LinkedService linkedService = this.ConvertToWrapper(json);
            this.Operations.ValidateObject(linkedService);
        }

        private LinkedService ConvertToWrapper(string json)
        {
            CoreModel.LinkedService internalLinkedService =
                Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(json);

            return this.Operations.Converter.ToWrapperType(internalLinkedService);
        }

        #endregion Test helpers
    }
}
