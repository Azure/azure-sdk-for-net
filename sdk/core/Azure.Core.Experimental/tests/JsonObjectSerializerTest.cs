// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class JsonObjectSerializerTest
    {
        private static readonly JsonObjectSerializer JsonObjectSerializer = new JsonObjectSerializer(new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        [Test]
        public void CanSerializeAnObject()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", B = 2};

            JsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.AreEqual("{\"a\":\"1\",\"b\":2}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public async Task CanSerializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream();
            var o = new Model {A = "1", B = 2};

            await JsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            var aB = "{\"a\":\"1\",\"b\":2}";
            Assert.AreEqual(aB, Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2}"));

            var model = (Model)JsonObjectSerializer.Deserialize(memoryStream, typeof(Model), default);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"a\":\"1\",\"b\":2}"));

            var model = (Model)await JsonObjectSerializer.DeserializeAsync(memoryStream, typeof(Model), default).ConfigureAwait(false);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
        }

        [Test]
        public void GetTypeInfo([Values] bool camelCase)
        {
            string Name(string name) => camelCase ? JsonNamingPolicy.CamelCase.ConvertName(name) : name;

            JsonObjectSerializer serializer = new JsonObjectSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null,
            });

            SerializableTypeInfo typeInfo = serializer.GetTypeInfo(typeof(ExtendedModel));
            Assert.AreEqual(6, typeInfo.Properties.Count);

            SerializablePropertyInfo a = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.A));
            Assert.AreEqual(typeof(string), a.PropertyType);
            Assert.AreEqual(Name("A"), a.SerializedName);
            Assert.IsFalse(a.ShouldIgnore);

            SerializablePropertyInfo b = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.B));
            Assert.AreEqual(typeof(int), b.PropertyType);
            Assert.AreEqual(Name("B"), b.SerializedName);
            Assert.IsFalse(b.ShouldIgnore);

            SerializablePropertyInfo c = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.C));
            Assert.AreEqual(typeof(int), c.PropertyType);
            Assert.AreEqual(Name("C"), c.SerializedName);
            Assert.IsTrue(c.ShouldIgnore);

            SerializablePropertyInfo d = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.D));
            Assert.AreEqual(typeof(int), d.PropertyType);
            Assert.AreEqual(Name("D"), d.SerializedName);
            Assert.IsFalse(d.ShouldIgnore);

            SerializablePropertyInfo e = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.NotE));
            Assert.AreEqual(typeof(int), e.PropertyType);
            Assert.AreEqual("e", e.SerializedName);
            Assert.IsFalse(e.ShouldIgnore);

            SerializablePropertyInfo f = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.F));
            Assert.AreEqual(typeof(int), f.PropertyType);
            Assert.AreEqual(Name("F"), f.SerializedName);
            Assert.IsFalse(f.ShouldIgnore);
        }

        public class Model
        {
            public string A { get; set; }

            public int B { get; set; }

            [JsonIgnore]
            public int C { get; set; }
        }

        public class ExtendedModel : Model
        {
            public int D { get; set; }

            [JsonPropertyName("e")]
            public int NotE { get; set; }

            public int F { get; private set; }
        }
    }
}
