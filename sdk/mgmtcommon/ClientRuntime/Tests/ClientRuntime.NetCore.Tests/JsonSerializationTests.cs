// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Globalization;
using System.Net.Http;
using Microsoft.Rest.ClientRuntime.Tests.Resources;
using Microsoft.Rest.ClientRuntime.Tests.Serialization;
using Microsoft.Rest.Serialization;
using Microsoft.Rest.TransientFaultHandling;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Xunit;
using System.Collections.Generic;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    [Collection("Serialization Tests")]
    public class JsonSerializationTests
    {
        private const string JsonErrorMessage = "Inappropriate use of JsonConvert.DefaultSettings detected!";

        [Fact]
        public void PolymorphicSerializeWorks()
        {
            Zoo zoo = new Zoo() { Id = 1 };
            zoo.Animals.Add(new Dog() {
                Name = "Fido",
                LikesDogfood = true
            });
            zoo.Animals.Add(new Cat() {
                Name = "Felix",
                LikesMice = false,
                Dislikes = new Dog() {
                    Name = "Angry",
                    LikesDogfood = true
                },
                BestFriend = new Animal() {
                    Name = "Rudy the Rabbit",
                    BestFriend = new Cat()
                    {
                        Name = "Jango",
                        LikesMice = true
                    }
                }
            });
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));

            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Animal>("dType"));

            var serializedJson = JsonConvert.SerializeObject(zoo, Formatting.Indented, serializeSettings);
            var zoo2 = JsonConvert.DeserializeObject<Zoo>(serializedJson, deserializeSettings);

            Assert.Equal(zoo.Animals[0].GetType(), zoo2.Animals[0].GetType());
            Assert.Equal(zoo.Animals[1].GetType(), zoo2.Animals[1].GetType());
            Assert.Equal(((Cat)zoo.Animals[1]).Dislikes.GetType(), ((Cat)zoo2.Animals[1]).Dislikes.GetType());
            Assert.Equal(zoo.Animals[1].BestFriend.GetType(), zoo2.Animals[1].BestFriend.GetType());
            Assert.Equal(zoo.Animals[1].BestFriend.BestFriend.GetType(), zoo2.Animals[1].BestFriend.BestFriend.GetType());
            Assert.Contains("dType", serializedJson);
        }

        [Fact]
        public void PolymorphicSerializeWithPropertyConverter()
        {
            var dog = new Dog
            {
                Name = "Doug",
                Birthday = new DateTime(2020, 2, 29),
                LikesDogfood = true,
            };

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));

            var serializedJson = JsonConvert.SerializeObject(dog, Formatting.Indented, serializeSettings);

            string dougJson = @"{
  ""dType"": ""dog"",
  ""likesDogfood"": true,
  ""bestFriend"": null,
  ""name"": ""Doug"",
  ""birthday"": 1582934400
}";
            Assert.Equal(dougJson, serializedJson);

            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Animal>("dType"));

            var deserializedDog = (Dog)JsonConvert.DeserializeObject<Animal>(serializedJson, deserializeSettings);
            Assert.Equal(dog.Birthday, deserializedDog.Birthday);
        }

        [Fact]
        public void PolymorphicSerializeCanReadWrite()
        {
            var data = new OneWayConvertibleData
            {
                ReadConverted = "InitialRead",
                WriteConverted = "InitialWrite",
            };
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.Converters.Add(
                new PolymorphicSerializeJsonConverter<OneWayConvertibleData>("dType"));
            var serializedJson = JsonConvert.SerializeObject(data, Formatting.Indented, serializeSettings);

            string dataJson = @"{
  ""dType"": ""owcd"",
  ""readConverted"": ""InitialRead"",
  ""writeConverted"": ""StaticWriteOnlyJsonConverter""
}";
            Assert.Equal(dataJson, serializedJson);
        }

        [Fact]
        public void PolymorphicDeserializeCanReadWrite()
        {
            string dataJson = @"{
  ""dType"": ""owcd"",
  ""readConverted"": ""InitialRead"",
  ""writeConverted"": ""InitialWrite""
}";

            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<OneWayConvertibleData>("dType"));
            var deserializedData = JsonConvert.DeserializeObject<OneWayConvertibleData>(dataJson, deserializeSettings);

            Assert.Equal("StaticReadOnlyJsonConverter", deserializedData.ReadConverted);
            Assert.Equal("InitialWrite", deserializedData.WriteConverted);
        }

        [Fact]
        public void PolymorphicSerializeNullWithPropertyConverter()
        {
            var dog = new Dog
            {
                Name = "Doug",
                LikesDogfood = true,
            };

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));

            var serializedJson = JsonConvert.SerializeObject(dog, Formatting.Indented, serializeSettings);

            string dougJson = @"{
  ""dType"": ""dog"",
  ""likesDogfood"": true,
  ""bestFriend"": null,
  ""name"": ""Doug"",
  ""birthday"": null
}";
            Assert.Equal(dougJson, serializedJson);
        }

        [Fact]
        public void PolymorphismWorksWithReadOnlyProperties()
        {
            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.NullValueHandling = NullValueHandling.Ignore;
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Animal>("dType"));

            string zooWithPrivateSet = @"{
  ""Id"": 1,
  ""Animals"": [
    {
      ""dType"": ""dog"",
      ""likesDogfood"": true,
      ""name"": ""Fido""
    },
    {
      ""dType"": ""cat"",
      ""likesMice"": false,
      ""dislikes"": {
        ""dType"": ""dog"",
        ""likesDogfood"": true,
        ""name"": ""Angry""
      },
      ""name"": ""Felix""
    },
    {
      ""dType"": ""siamese"",
      ""color"": ""grey"",
      ""likesMice"": false,
      ""name"": ""Felix""
    }
  ]
}";

            var zoo2 = JsonConvert.DeserializeObject<Zoo>(zooWithPrivateSet, deserializeSettings);

            Assert.Equal("grey", ((Siamese)zoo2.Animals[2]).Color);

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));
            var zooReserialized = JsonConvert.SerializeObject(zoo2, serializeSettings);

            Assert.Equal(zooWithPrivateSet, zooReserialized);
        }

        [Fact]
        public void RawJsonIsSerialized()
        {
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.ContractResolver = new ReadOnlyJsonContractResolver();

            var firstAlienJson = JsonConvert.SerializeObject(new Alien("green", "quite decent") { Name = "autorest", Planet = "Mars", Body = JObject.Parse(@"{ ""custom"" : ""json"" }") },
                Formatting.Indented, serializeSettings);

            Assert.DoesNotContain(@"""color""", firstAlienJson);
            Assert.DoesNotContain(@"""smell""", firstAlienJson);

            var firstAlien = JsonConvert.DeserializeObject<Alien>(firstAlienJson, serializeSettings);

            string secondAlienJson = @"{
                    ""color"": ""green"",
                    ""planet"": ""Mars"",
                    ""name"": ""autorest"",
                    ""body"": { ""custom"" : ""json"" },
                }";

            var secondAlien = JsonConvert.DeserializeObject<Alien>(secondAlienJson, serializeSettings);

            Assert.Equal("autorest", firstAlien.Name);
            Assert.Null(firstAlien.Color);
            Assert.Null(firstAlien.GetPlanetName());
            Assert.Equal("json", firstAlien.Body.custom.ToString());

            Assert.Equal("autorest", secondAlien.Name);
            Assert.Equal("green", secondAlien.Color);
            Assert.Equal("json", secondAlien.Body.custom.ToString());
        }

        [Fact]
        public void ReadOnlyPropertiesWorkStandalone()
        {
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.ContractResolver = new ReadOnlyJsonContractResolver();

            var firstAlienJson = JsonConvert.SerializeObject(new Alien("green", "quite decent") { Name = "autorest", Planet = "Mars" },
                Formatting.Indented, serializeSettings);

            var firstAlien = JsonConvert.DeserializeObject<Alien>(firstAlienJson, serializeSettings);

            string secondAlienJson = @"{
                    ""color"": ""green"",
                    ""planet"": ""Mars"",
                    ""name"": ""autorest""
                }";

            var secondAlien = JsonConvert.DeserializeObject<Alien>(secondAlienJson, serializeSettings);

            Assert.Equal("autorest", firstAlien.Name);
            Assert.Null(firstAlien.Color);
            Assert.Null(firstAlien.GetPlanetName());

            Assert.Equal("autorest", secondAlien.Name);
            Assert.Equal("green", secondAlien.Color);
            Assert.Equal("Mars", secondAlien.GetPlanetName());
        }

        [Fact]
        public void DateSerializationWithoutNulls()
        {
            var localDateTimeOffset = new DateTimeOffset(2015, 6, 1, 16, 10, 08, 121, new TimeSpan(-7, 0, 0));
            var utcDate = DateTime.Parse("2015-06-01T00:00:00.0", CultureInfo.InvariantCulture);
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializeSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            DateTestObject test = new DateTestObject();
            test.Date = localDateTimeOffset.LocalDateTime;
            test.DateNullable = localDateTimeOffset.LocalDateTime;
            test.DateTime = localDateTimeOffset.LocalDateTime;
            test.DateTimeNullable = localDateTimeOffset.LocalDateTime;
            test.DateTimeOffset = localDateTimeOffset;
            test.DateTimeOffsetNullable = localDateTimeOffset;
            test.DateTimeOffsetWithConverter = localDateTimeOffset;
            test.DateTimeOffsetNullableWithConverter = localDateTimeOffset;

            var expectedJson = @"{
  ""d"": ""2015-06-01"",
  ""dt"": ""2015-06-01T23:10:08.121Z"",
  ""dn"": ""2015-06-01T23:10:08.121Z"",
  ""dtn"": ""2015-06-01"",
  ""dtoc"": ""2015-06-01"",
  ""dtonc"": ""2015-06-01"",
  ""dto"": ""2015-06-01T16:10:08.121-07:00"",
  ""dton"": ""2015-06-01T16:10:08.121-07:00""
}";
            var json = JsonConvert.SerializeObject(test, serializeSettings);

            DateTestObject testRoundtrip = JsonConvert.DeserializeObject<DateTestObject>(json, serializeSettings);
            Assert.Equal(expectedJson, json);
            Assert.Equal(utcDate, testRoundtrip.Date);
            Assert.Equal(localDateTimeOffset, testRoundtrip.DateTime.ToLocalTime());
            Assert.Equal(test.DateTimeOffset, testRoundtrip.DateTimeOffset);
        }

        [Fact]
        public void DateSerializationWithNulls()
        {
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializeSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;

            DateTestObject test = new DateTestObject();

            var expectedJson = @"{
  ""d"": ""0001-01-01"",
  ""dt"": ""0001-01-01T00:00:00Z"",
  ""dtoc"": ""0001-01-01"",
  ""dto"": ""0001-01-01T00:00:00+00:00""
}";
            var json = JsonConvert.SerializeObject(test, serializeSettings);

            DateTestObject testRoundtrip = JsonConvert.DeserializeObject<DateTestObject>(json, serializeSettings);

            Assert.Equal(expectedJson, json);
            Assert.Null(testRoundtrip.DateNullable);
            Assert.Null(testRoundtrip.DateTimeNullable);
        }

        [Fact]
        public void DateSerializationWithMaxValue()
        {
            var localDateTime = DateTime.Parse("9999-12-31T22:59:59-01:00", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            serializeSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            DateTestObject test = new DateTestObject();
            test.Date = localDateTime;
            test.DateNullable = localDateTime;
            test.DateTime = localDateTime;
            test.DateTimeNullable = localDateTime;
            test.DateTimeOffsetNullable = localDateTime;
            test.DateTimeOffsetNullableWithConverter = localDateTime;
            test.DateTimeOffsetWithConverter = localDateTime;

            var expectedJson = @"{
  ""d"": ""9999-12-31"",
  ""dt"": ""9999-12-31T23:59:59Z"",
  ""dn"": ""9999-12-31T23:59:59Z"",
  ""dtn"": ""9999-12-31"",
  ""dtoc"": ""9999-12-31"",
  ""dtonc"": ""9999-12-31"",
  ""dto"": ""0001-01-01T00:00:00+00:00"",
  ""dton"": """ + localDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz") + @"""
}";
            var json = JsonConvert.SerializeObject(test, serializeSettings);

            DateTestObject testRoundtrip = JsonConvert.DeserializeObject<DateTestObject>(json, serializeSettings);
            Assert.Equal(localDateTime, testRoundtrip.DateTime.ToLocalTime());
            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void HeaderGetsSerializedToJson()
        {
            var message = new HttpResponseMessage();
            message.Headers.Add("h1", "value");
            message.Headers.Add("h2", "");
            message.Headers.Add("h3", new string[] {"value1", "value2"});
            var json = message.Headers.ToJson().ToString();
            var expectedJsonString = string.Format("{{{0}  \"h1\": \"value\",{0}  \"h2\": \"\",{0}  \"h3\": [{0}    \"value1\",{0}    \"value2\"{0}  ]{0}}}", 
                Environment.NewLine);
            Assert.Equal(expectedJsonString, json);
        }

        [Fact]
        public void HeaderKnownValuesGetSerializedToJson()
        {
            var message = new HttpResponseMessage();
            message.Content = new StringContent("Test");
            message.Headers.Add("h1", "value");
            message.Headers.Add("h2", "");
            message.Headers.Add("h3", new string[] { "value1", "value2" });

            var json = message.GetHeadersAsJson().ToString();

            var expectedJsonString = string.Format("{{{0}  \"h1\": \"value\",{0}  \"h2\": \"\",{0}  \"h3\": [{0}    \"value1\",{0}    \"value2\"{0}  ],{0}  \"Content-Type\": \"text/plain; charset=utf-8\"{0}}}",
                Environment.NewLine);
            Assert.Equal(expectedJsonString, json);
        }
     
        [Fact]   
        public void SafeSerializeIgnoresDefaultSettings()
        {
            TestWithBadJsonSerializerSettings(() =>
            {
                const string ExpectedJson = @"{""Name"":""Bob"",""Rating"":5}";
                var model = new Model() { Name = "Bob", Rating = 5 };
                
                string actualJson = SafeJsonConvert.SerializeObject(model, new JsonSerializerSettings());

                Assert.Equal(ExpectedJson, actualJson); 
            });
        }

        [Fact]        
        public void SafeDeserializeIgnoresDefaultSettings()
        {
            TestWithBadJsonSerializerSettings(() =>
            {
                const string Json = @"{""Name"":""Bob"",""Rating"":5}";
                
                Model model = SafeJsonConvert.DeserializeObject<Model>(Json, new JsonSerializerSettings()); 
                
                Assert.Equal("Bob", model.Name);
                Assert.Equal(5, model.Rating); 
            });
        }

        [Fact]
        public void SerializeConstants()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            var json = SafeJsonConvert.SerializeObject(new ModelWithConst(), settings);
            Assert.Contains("foo", json);
        }

        [Fact]
        public void PolymorphicDeserializationConsidersOnlyOwnDerivedTypes()
        {
            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.NullValueHandling = NullValueHandling.Ignore;
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Animal>("dType"));

            string zooWithPrivateSetHalf1 = @"{
  ""Id"": 1,
  ""Animals"": [
    {
      ""dType"": ""dog"",
      ""likesDogfood"": true,
      ""name"": ""Fido""
    },
    {
      ""dType"": ""cat"",
      ""likesMice"": false,
      ""dislikes"": {
        ""dType"": ""dog"",
        ""likesDogfood"": true,
        ""name"": ""Angry""
      },
      ""name"": ""Felix""
    },
    {
      ""dType"": ""siamese"",
      ""color"": ""grey"",
      ""likesMice"": false,
      ""name"": ""Felix""
    }
  ]";
            string zooWithPrivateSetHalf2 = @"
}";
            string alienPart = @",
  ""Alien"" : [
    {
      ""dType"": ""siamese"",
      ""name"": ""martian""
    }
  ]";

            string zooWithPrivateSet = zooWithPrivateSetHalf1 + alienPart + zooWithPrivateSetHalf2;

            var zoo2 = JsonConvert.DeserializeObject<Zoo>(zooWithPrivateSet, deserializeSettings);

            Assert.Equal("grey", ((Siamese)zoo2.Animals[2]).Color);

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));
            var zooReserialized = JsonConvert.SerializeObject(zoo2, serializeSettings);

            Assert.Equal(zooReserialized, zooWithPrivateSetHalf1 + zooWithPrivateSetHalf2);
        }

        [Fact]
        public void PolymorphicDeserializationConsidersAdditionalPropertiesBaseline()
        {
            // non-polymorhpic version of PolymorphicDeserializationConsidersAdditionalProperties,
            // to validate that behavior tested for there actually matches non-polymorphic behavior

            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.NullValueHandling = NullValueHandling.Ignore;

            string animalsWithAdditionalProperties = @"[
    {
      ""dType"": ""dog"",
      ""likesDogfood"": true,
      ""name"": ""Fido"",
      ""favoriteDogfood"": ""cats""
    },
    {
      ""dType"": ""cat"",
      ""likesMice"": false,
      ""dislikes"": {
        ""dType"": ""dog"",
        ""likesDogfood"": true,
        ""name"": ""Angry""
      },
      ""name"": ""Felix"",
      ""likesSquirrels"": false,
      ""likesCowbell"": 42
    },
    {
      ""dType"": ""siamese"",
      ""color"": ""grey"",
      ""likesMice"": false,
      ""name"": ""Felix"",
      ""likesSquirrels"": true
    }
  ]";

            // see if it round trips
            var tmpAnimals = JsonConvert.DeserializeObject<Animal[]>(animalsWithAdditionalProperties, deserializeSettings);
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;
            serializeSettings.Formatting = Formatting.Indented;
            animalsWithAdditionalProperties = JsonConvert.SerializeObject(tmpAnimals, serializeSettings);

            // deserialize and check
            var animals = JsonConvert.DeserializeObject<Animal[]>(animalsWithAdditionalProperties, deserializeSettings);

            Assert.Equal("cats", animals[0].AdditionalProperties["favoriteDogfood"]);
            Assert.Equal(false, animals[1].AdditionalProperties["likesSquirrels"]);
            Assert.Equal(true, animals[2].AdditionalProperties["likesSquirrels"]);
        }

        [Fact]
        public void PolymorphicDeserializationConsidersAdditionalProperties()
        {
            var deserializeSettings = new JsonSerializerSettings();
            deserializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            deserializeSettings.NullValueHandling = NullValueHandling.Ignore;
            deserializeSettings.Converters.Add(new PolymorphicDeserializeJsonConverter<Animal>("dType"));

            string animalsWithAdditionalProperties = @"[
    {
      ""dType"": ""dog"",
      ""likesDogfood"": true,
      ""name"": ""Fido"",
      ""favoriteDogfood"": ""cats""
    },
    {
      ""dType"": ""cat"",
      ""likesMice"": false,
      ""dislikes"": {
        ""dType"": ""dog"",
        ""likesDogfood"": true,
        ""name"": ""Angry""
      },
      ""name"": ""Felix"",
      ""likesSquirrels"": false,
      ""likesCowbell"": 42
    },
    {
      ""dType"": ""siamese"",
      ""color"": ""grey"",
      ""likesMice"": false,
      ""name"": ""Felix"",
      ""likesSquirrels"": true
    }
  ]";

            // see if it round trips
            var tmpAnimals = JsonConvert.DeserializeObject<Animal[]>(animalsWithAdditionalProperties, deserializeSettings);
            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializeSettings.NullValueHandling = NullValueHandling.Ignore;
            serializeSettings.Formatting = Formatting.Indented;
            serializeSettings.Converters.Add(new PolymorphicSerializeJsonConverter<Animal>("dType"));
            animalsWithAdditionalProperties = JsonConvert.SerializeObject(tmpAnimals, serializeSettings);

            // deserialize and check
            var animals = JsonConvert.DeserializeObject<Animal[]>(animalsWithAdditionalProperties, deserializeSettings);

            Assert.Equal("cats", animals[0].AdditionalProperties["favoriteDogfood"]);
            Assert.Equal(false, animals[1].AdditionalProperties["likesSquirrels"]);
            Assert.Equal(true, animals[2].AdditionalProperties["likesSquirrels"]);
            Assert.Equal(true, (animals[2] as Siamese).AdditionalProperties2["likesSquirrels"]);
            Assert.Equal(1, animals[0].AdditionalProperties.Count);
            Assert.Equal(2, animals[1].AdditionalProperties.Count);
            Assert.Equal(1, animals[2].AdditionalProperties.Count);
            Assert.Equal(1, (animals[2] as Siamese).AdditionalProperties2.Count);
        }

        private static void TestWithBadJsonSerializerSettings(Action callback)
        {
            Func<JsonSerializerSettings> oldDefault = JsonConvert.DefaultSettings;
            JsonConvert.DefaultSettings = () =>
                new JsonSerializerSettings() 
                {
                    Converters = new[] { new ModelConverter() }
                };

            try
            {
                callback();
            }
            finally
            {
                JsonConvert.DefaultSettings = oldDefault;
            }
        }

        [JsonObject("owcd")]
        private class OneWayConvertibleData
        {
            [JsonConverter(typeof(StaticReadOnlyJsonConverter))]
            [JsonProperty("readConverted")]
            public string ReadConverted { get; set; }

            [JsonConverter(typeof(StaticWriteOnlyJsonConverter))]
            [JsonProperty("writeConverted")]
            public string WriteConverted { get; set; }
        }

        private class Model
        {
            public string Name { get; set; }
            
            public int Rating { get; set; }
        }

        private class ModelWithConst
        {
            [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Include)]
            public static string Name { get { return "foo"; } }

            public int Rating { get; set; }
        }

 
        private class ModelConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType) => objectType == typeof(Model);

            public override object ReadJson(
                JsonReader reader,
                Type objectType,
                object existingValue,
                JsonSerializer serializer)
            {
                var model = new Model();

                ExpectAndAdvance(reader, JsonToken.StartObject);

                ExpectProperty(reader, "Name");
                model.Name = reader.ReadAsString().ToUpper();
                reader.Read();

                ExpectProperty(reader, "Rating");
                model.Rating = reader.ReadAsInt32().Value;
                reader.Read();

                Expect(reader, JsonToken.EndObject);

                return model;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var model = (Model)value;

                writer.WriteStartObject();

                writer.WritePropertyName("Name");
                writer.WriteValue(model.Name.ToUpper());

                writer.WritePropertyName("Rating");
                writer.WriteValue(model.Rating);

                writer.WriteEndObject();

            }

            private static void Expect(JsonReader reader, JsonToken tokenType)
            {
                if (reader.TokenType != tokenType)
                {
                    throw new JsonSerializationException($"Found unexpected token: {tokenType}.");
                }
            }

            private static void ExpectAndAdvance(JsonReader reader, JsonToken tokenType)
            {
                Expect(reader, tokenType);
                reader.Read();
            }

            private static void ExpectProperty(JsonReader reader, string name)
            {
                Expect(reader, JsonToken.PropertyName);
                string propertyName = reader.Value as string;
                if (propertyName != name)
                {
                    throw new JsonSerializationException($"Found unexpected property. Expected: {name}. Actual: {propertyName}.");
                }
            }
        }
    }
}
