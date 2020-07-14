// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NewtonsoftJsonObjectSerializerTest
    {
        private static readonly NewtonsoftJsonObjectSerializer JsonObjectSerializer = new NewtonsoftJsonObjectSerializer(true, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new[]
            {
                new StringEnumConverter(true),
            },
        });

        [Test]
        public void CanSerializeAnObject()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", ActuallyB = 2, Type = ModelType.One};

            JsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.AreEqual("{\"a\":\"1\",\"b\":2,\"type\":\"one\"}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public async Task CanSerializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", ActuallyB = 2, Type = ModelType.One};

            await JsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            Assert.AreEqual("{\"a\":\"1\",\"b\":2,\"type\":\"one\"}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2,\"type\":\"two\"}"));

            var model = (Model)JsonObjectSerializer.Deserialize(memoryStream, typeof(Model), default);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.ActuallyB);
            Assert.AreEqual(ModelType.Two, model.Type);
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2,\"type\":\"two\"}"));

            var model = (Model)await JsonObjectSerializer.DeserializeAsync(memoryStream, typeof(Model), default).ConfigureAwait(false);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.ActuallyB);
            Assert.AreEqual(ModelType.Two, model.Type);
        }

        public class Model
        {
            public string A { get; set; }

            [JsonProperty("b")]
            public int ActuallyB { get; set; }

            public ModelType Type { get; set; }
        }

        public enum ModelType
        {
            Unknown = 0,
            One = 1,
            Two = 2,
        }
    }
}