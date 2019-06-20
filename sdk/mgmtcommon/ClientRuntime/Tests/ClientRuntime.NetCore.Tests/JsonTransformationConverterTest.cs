// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Tests.Resources.PolymorphicJsonConverterTest;

namespace Microsoft.Rest.ClientRuntime.Azure.Test
{
    [Collection("Serialization Tests")]
    public class JsonTransformationConverterTest
    {
        [Fact]
        public void TestResourceDeserializationException()
        {
            var sampleJson = @"{
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""size"": ""String that should throw"",
    ""child1"": {
      ""@child.key"": ""key""
    },
    ""child"": {
      ""dType"": ""SampleResourceChild1"",
      ""properties"": {
        ""name1"": ""name1""
      }
    }
  },
  ""plan"": ""testPlan""
}";
            var sampleResource = new SampleResource()
            {
                Size = 3,
                ChildKey = "key",
                Child = new SampleResourceChild1()
                {
                    ChildName1 = "name1"
                },
                Location = "EastUS",
                Plan = "testPlan",
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new TransformationJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            bool exceptionThrown = false;

            try
            {
                JsonConvert.DeserializeObject<SampleResource>(sampleJson, deserializeSettings);
            }
            catch(JsonException ex)
            {
                Assert.True(ex.Message.Contains("String that should throw"));
                Assert.True(ex.Message.Contains("Could not convert string to integer"));
                exceptionThrown = true;
            }

            Assert.True(exceptionThrown, "JsonConverter should throw if the payload is non-serializable.");
        }

        [Fact]
        public void TestResourceSerialization()
        {
            var sampleJson = @"{
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""size"": 3,
    ""child1"": {
      ""@child.key"": ""key""
    },
    ""child"": {
      ""dType"": ""SampleResourceChild1"",
      ""properties"": {
        ""name1"": ""name1""
      }
    }
  },
  ""plan"": ""testPlan""
}";
            var sampleResource = new SampleResource()
            {
                Size = 3,
                ChildKey = "key",
                Child = new SampleResourceChild1()
                {
                    ChildName1 = "name1"
                },
                Location = "EastUS",
                Plan = "testPlan",
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new TransformationJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));

            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(sampleJson, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(sampleJson, jsonoverProcessed);

            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(sampleJson, json);
        }

        [Fact]
        public void TestResourceSerializationWithPolymorphism()
        {
            var sampleResource = new SampleResource()
            {
                Size = 3,
                Child = new SampleResourceChild1(),
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new TransformationJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResource>("dType"));
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""dType"": ""SampleResource"",
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""size"": 3,
    ""child"": {
      ""dType"": ""SampleResourceChild1""
    }
  }
}", json);
        }

        [Fact]
        public void TestResourceWithNullPropertiesSerialization()
        {
            var sampleResource = new SampleResource()
            {
                Location = "EastUS"
            };
            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new TransformationJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  }
}", json);

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(json, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);

            Assert.Equal(json, jsonoverProcessed);
        }

        [Fact]
        public void TestResourceWithNullPropertiesDeserialization()
        {
            var sampleResource = new SampleResource()
            {
                Location = "EastUS"
            };

            sampleResource.Tags = new Dictionary<string, string>();
            sampleResource.Tags["tag1"] = "value1";
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };

            serializeSettings.Converters.Add(new TransformationJsonConverter());
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<SampleResourceChild>("dType"));
            string json = JsonConvert.SerializeObject(sampleResource, serializeSettings);
            Assert.Equal(@"{
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  }
}", json);
            string jsonWithNull = @"{
  ""id"": null,
  ""name"": null,
  ""size"": null,
  ""properties"": {""name"": null, ""child"": null},
  ""Location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  }
}";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };

            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(jsonWithNull, deserializeSettings);
            var jsonoverProcessed = JsonConvert.SerializeObject(deserializedResource, serializeSettings);
            Assert.Equal(json, jsonoverProcessed);
        }

        [Fact]
        public void TestProvisioningStateDeserialization()
        {
            var expected = @"{
                              ""Location"": ""EastUS"",
                              ""tags"": {
                                ""tag1"": ""value1""
                              },
                              ""properties"": {
                                ""size"": ""3"",
                                ""provisioningState"": ""some string"",
                                ""child"": {
                                  ""dType"": ""SampleResourceChild1"",
                                  ""name1"": ""name1"",
                                  ""id"": ""child""
                                }
                              }
                            }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<SampleResourceChild>("dType"));
            var deserializedResource = JsonConvert.DeserializeObject<SampleResource>(expected, deserializeSettings);

            Assert.Equal("some string", deserializedResource.ProvisioningState);
        }

        [Fact]
        public void TestDeserializationOfResourceWithConflictingProperties()
        {
            var expected = @"{
                ""id"": ""123"",
                ""location"": ""EastUS"",
                ""tags"": {
                ""tag1"": ""value1""
                },
                ""properties"": {
                   ""size"": ""3"",
                   ""provisioningState"": ""some string"",
                   ""location"": ""Special Location"",
                   ""id"": ""Special Id""
                }
            }";

            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new TransformationJsonConverter());
            var deserializedResource = JsonConvert.DeserializeObject<SampleResourceWithConflict>(expected, deserializeSettings);

            Assert.Equal("Special Location", deserializedResource.SampleResourceWithConflictLocation);
            Assert.Equal("Special Id", deserializedResource.SampleResourceWithConflictId);
            Assert.Equal("123", deserializedResource.Id);

            var expectedSerializedJson = @"{
  ""location"": ""EastUS"",
  ""tags"": {
    ""tag1"": ""value1""
  },
  ""properties"": {
    ""location"": ""Special Location"",
    ""id"": ""Special Id""
  }
}";
            var newJson = JsonConvert.SerializeObject(deserializedResource, deserializeSettings);
            Assert.Equal(expectedSerializedJson, newJson);
        }

        [Fact]
        public void TestPolymorphicJsonDeserializer()
        {
            var testJson = @"{
                                ""speed"": 100,
                                ""name"": ""Chester"",
                                ""PetType"":""Horse""
                             }";
            var deserializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Pet>("PetType"));
            var pet = SafeJsonConvert.DeserializeObject<Pet>(testJson, deserializeSettings);
            Assert.Equal(pet.GetType().ToString(), "Microsoft.Rest.ClientRuntime.Tests.Resources.PolymorphicJsonConverterTest.Horse");

        }

        [Fact]
        public void TestPolymorphicJsonSerializer()
        {
            var horseyText = "{  \"PetType\": \"Horse\",  \"speed\": 21,  \"name\": \"Spike\"}";
            var horsey = new Horse() { Name="Spike", Speed=21 };
            var serializeSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Pet>("PetType"));
            var horseyJson = SafeJsonConvert.SerializeObject(horsey, serializeSettings);
            Assert.Equal(horseyJson.Replace("\n", "").Replace("\r", ""), horseyText);
        }

    }
}
