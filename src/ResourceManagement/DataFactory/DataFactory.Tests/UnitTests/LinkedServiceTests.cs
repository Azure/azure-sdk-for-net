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
using DataFactory.Tests.Framework;
using DataFactory.Tests.Framework.JsonSamples;
using DataFactory.Tests.UnitTests.TestClasses;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions;
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

        [Theory, ClassData(typeof(LinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceJsonConstsToWrappedObjectTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceJson);
        }

        [Theory, ClassData(typeof(LinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceValidateJsonConstsTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceValidation);
        }

        [Theory, ClassData(typeof(CustomLinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void CustomLinkedServiceJsonConstsToWrappedObjectTest(JsonSampleInfo sampleInfo)
        {
            JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceCustomJson);
        }

        [Theory, InlineData(@"{
    name: ""Test-BYOC-HDInsight-linkedService"",
    properties:
    {
        type: ""HDInsight"",
        typeProperties:
        {
            linkedServiceName: ""MyStorageAssetName""
        }
    }
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceMissingRequiredPropertiesThrowsExceptionTest(string invalidJson)
        {
            // clusterUri, userName and password are required
            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(invalidJson));
            Assert.Contains("is required", ex.Message);
        }

        [Theory, ClassData(typeof(LinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceWithExtraPropertiesTest(JsonSampleInfo sampleInfo)
        {
            if (sampleInfo.Version != null
                && sampleInfo.Version.Equals("ExtraProperties", StringComparison.Ordinal))
            {
                JsonSampleCommon.TestJsonSample(sampleInfo, this.TestLinkedServiceJson);
            }
        }

        [Theory, InlineData(@"
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
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void LinkedServiceUnregisteredTypeTest(string unregisteredTypeJson)
        {
            // If a linked service type has not been locally registered, 
            // typeProperties should be deserialized to a GenericLinkedServiceInstance
            LinkedService linkedService = this.ConvertToWrapper(unregisteredTypeJson);
            Assert.IsType<GenericLinkedService>(linkedService.Properties.TypeProperties);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void CreatingGenericLinkedServiceWithoutTypeNameThrowsExceptionTest()
        {
            string expectedError =
                "cannot be used if its value is GenericLinkedService, GenericDataset or GenericActivity";

            var genericLinkedService = new GenericLinkedService();
            ArgumentException ex =
                Assert.Throws<ArgumentException>(() => new LinkedServiceProperties(genericLinkedService));
            
            Assert.Contains(expectedError, ex.Message);

            ex = Assert.Throws<ArgumentException>(
                () =>
                    {
                        var ls = new LinkedServiceProperties(genericLinkedService, "somename");
                        ls.TypeProperties = genericLinkedService;
                    });

            Assert.Contains(expectedError, ex.Message);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void CanSetNonGenericTypePropertiesWithoutTypeName()
        {
            var storageLinkedService = new AzureStorageLinkedService();
            Assert.DoesNotThrow(
                () =>
                    {
                        var ls = new LinkedServiceProperties(storageLinkedService);
                        ls.TypeProperties = storageLinkedService;
                    });
        }

#if NET45
        [Theory, InlineData(@"
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
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithListProperty(string json)
        {
            this.Client.RegisterType<MyLinkedServiceTypeWithListProperty>(true);
            this.TestLinkedServiceJson(json);
            this.TestLinkedServiceValidation(json);
        }

        [Theory, InlineData(@"
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
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithListPropertyThrowsForMissingRequiredProperty(string json)
        {
            this.Client.RegisterType<MyLinkedServiceTypeWithListProperty>(true);
            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(json));
            Assert.Contains("is required", ex.Message);
        }

        [Theory, InlineData(@"
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
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithDictionaryProperty(string json)
        {
            this.Client.RegisterType<MyLinkedServiceTypeWithDictionaryProperty>(true);
            this.TestLinkedServiceJson(json);
            this.TestLinkedServiceValidation(json);
        }

        [Theory, InlineData(@"
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
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]
        public void ValidateLinkedServiceWithDictionaryPropertyThrowsForMissingRequiredProperty(string json)
        {
            this.Client.RegisterType<MyLinkedServiceTypeWithDictionaryProperty>(true);

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.TestLinkedServiceValidation(json));
            Assert.Contains("is required", ex.Message);
        }

        [Theory]
        [InlineData(@"{
    name: ""MyLinkedService"",
    properties: 
    {
        type: ""AzureSqlDatabase"", 
        typeProperties: {
            connectionString: null
        }
    }
}")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Conversion)]

        public void CanConvertLinkedServiceWithNullTypePropertyValuesTest(string json)
        {
            JsonSampleInfo sample = new JsonSampleInfo("LinkedServiceWithNullTypePropertyValues", json, null);
            this.TestLinkedServiceJson(sample);
        }
#endif 

        #endregion Tests

        #region Test helpers

        private LinkedService ConvertAndTestJson(string json, bool customTest = false, HashSet<string> propertyBagKeys = null)
        {
            LinkedService linkedService = this.ConvertToWrapper(json);
            CoreModel.LinkedService actual = this.Operations.Converter.ToCoreType(linkedService);

            // after converting to intermediate object, ensure that ServiceExtraProperties is still set
            if (customTest)
            {
                IGenericTypeProperties typeProperties =
                    linkedService.Properties.TypeProperties as IGenericTypeProperties;

                Assert.NotNull(typeProperties);
            }

            string actualJson = Core.DataFactoryManagementClient.SerializeInternalLinkedServiceToJson(actual);

            JsonComparer.ValidateAreSame(json, actualJson, ignoreDefaultValues: true);
            Assert.DoesNotContain("ServiceExtraProperties", actualJson);

            JObject actualJObject = JObject.Parse(actualJson);
            JsonComparer.ValidatePropertyNameCasing(actualJObject, true, string.Empty, propertyBagKeys);
            
            return linkedService;
        }

        private void TestLinkedServiceJson(string json)
        {
            LinkedService linkedService = this.ConvertAndTestJson(json);
            Assert.IsNotType<GenericLinkedService>(linkedService.Properties.TypeProperties);
        }

        private void TestLinkedServiceJson(JsonSampleInfo sampleInfo)
        {
            this.TestLinkedServiceJson(sampleInfo.Json);
        }

        private void TestLinkedServiceCustomJson(JsonSampleInfo sampleInfo)
        {
            this.ConvertAndTestJson(sampleInfo.Json, true); 
        }

        private void TestLinkedServiceValidation(string json)
        {
            LinkedService linkedService = this.ConvertToWrapper(json);
            this.Operations.ValidateObject(linkedService);
        }

        private void TestLinkedServiceValidation(JsonSampleInfo sampleInfo)
        {
            this.TestLinkedServiceValidation(sampleInfo.Json);
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
