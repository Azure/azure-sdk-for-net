// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
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


        [Test]
        public void GetTypeInfo([Values] bool camelCase)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = camelCase ? new CamelCasePropertyNamesContractResolver() : new DefaultContractResolver(),
            };

            NewtonsoftJsonObjectSerializer serializer = new NewtonsoftJsonObjectSerializer(true, settings);

            string Name(string name) => settings.ContractResolver is DefaultContractResolver resolver ? resolver.GetResolvedPropertyName(name) : name;

            SerializableTypeInfo typeInfo = serializer.GetTypeInfo(typeof(ExtendedModel));
            Assert.AreEqual(7, typeInfo.Properties.Count);

            SerializablePropertyInfo a = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.A));
            Assert.AreEqual(typeof(string), a.PropertyType);
            Assert.AreEqual(Name("A"), a.SerializedName);
            Assert.IsFalse(a.ShouldIgnore);

            SerializablePropertyInfo b = typeInfo.Properties.Single(property => property.PropertyName == nameof(ExtendedModel.ActuallyB));
            Assert.AreEqual(typeof(int), b.PropertyType);
            Assert.AreEqual("b", b.SerializedName);
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

            [JsonProperty("b")]
            public int ActuallyB { get; set; }

            [JsonIgnore]
            public int C { get; set; }

            public ModelType Type { get; set; }
        }

        public class ExtendedModel : Model
        {
            public int D { get; set; }

            [JsonProperty("e")]
            public int NotE { get; set; }

            public int F { get; private set; }
        }

        public enum ModelType
        {
            Unknown = 0,
            One = 1,
            Two = 2,
        }
    }
}