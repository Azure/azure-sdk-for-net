// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Globalization;
using System.Net.Http;
using Microsoft.Rest.ClientRuntime.Tests.Resources;
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
            zoo.Animals.Add(new Dog() { Name = "Fido", LikesDogfood = true });
            zoo.Animals.Add(new Cat() { Name = "Felix", LikesMice = false, Dislikes = new Dog() { Name = "Angry", LikesDogfood = true } });
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
            Assert.Contains("dType", serializedJson);
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

            var firstAlienJson = JsonConvert.SerializeObject(new Alien("green") { Name = "autorest", Planet = "Mars", Body = JObject.Parse(@"{ ""custom"" : ""json"" }") },
                Formatting.Indented, serializeSettings);

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

            var firstAlienJson = JsonConvert.SerializeObject(new Alien("green") { Name = "autorest", Planet = "Mars" },
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

        private static void TestWithBadJsonSerializerSettings(Action callback)
        {
            Func<JsonSerializerSettings> oldDefault = JsonConvert.DefaultSettings;
            JsonConvert.DefaultSettings = () =>
                new JsonSerializerSettings() 
                {
                    Converters = new[] { new InvalidJsonConverter() },
                    ContractResolver = new InvalidContractResolver()
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

        private class InvalidContractResolver : IContractResolver
        {
            public JsonContract ResolveContract(Type type)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }
        }

        private class InvalidJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new InvalidOperationException(JsonErrorMessage);
            }
        }
    }
}
