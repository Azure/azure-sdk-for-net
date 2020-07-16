// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public void GetSerializedMemberName([Values] bool camelCase)
        {
            DefaultContractResolver resolver = camelCase ? new CamelCasePropertyNamesContractResolver() : new DefaultContractResolver();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = resolver,
            };

            NewtonsoftJsonObjectSerializer serializer = new NewtonsoftJsonObjectSerializer(true, settings);

            IEnumerable<MemberInfo> members = typeof(ExtendedModel)
                .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(member => (member.MemberType & (MemberTypes.Property | MemberTypes.Field)) != 0);

            string Name(string name) => resolver.GetResolvedPropertyName(name);
            foreach (MemberInfo member in members)
            {
                string propertyName = serializer.GetSerializedMemberName(member);
                switch (member.Name)
                {
                    case nameof(ExtendedModel.A):
                        Assert.AreEqual(Name("A"), propertyName);
                        break;

                    case nameof(ExtendedModel.ActuallyB):
                        Assert.AreEqual("b", propertyName);
                        break;

                    case nameof(ExtendedModel.Type):
                        Assert.AreEqual(Name("Type"), propertyName);
                        break;

                    case nameof(ExtendedModel.ReadOnlyD):
                        Assert.AreEqual("d", propertyName);
                        break;

                    case nameof(ExtendedModel.F):
                        Assert.AreEqual(Name("F"), propertyName);
                        break;

                    case "H":
                        Assert.AreEqual("h", propertyName);
                        break;

                    default:
                        Assert.IsNull(propertyName, $"Unexpected serialized name '{propertyName}' for member {member.DeclaringType}.{member.Name}");
                        break;
                }
            }
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
            [JsonProperty("d")]
            public int ReadOnlyD { get; }

            internal int IgnoredE { get; set; }

            public int F;

#pragma warning disable CS0649 // Field 'NewtonsoftJsonObjectSerializerTest.ExtendedModel.G' is never assigned to, and will always have its default value 0
            internal int G;
#pragma warning restore CS0649

#pragma warning disable CS0169 // The field 'NewtonsoftJsonObjectSerializerTest.ExtendedModel.H' is never used
            [JsonProperty("h")]
            private int H;
#pragma warning restore CS0169
        }

        public enum ModelType
        {
            Unknown = 0,
            One = 1,
            Two = 2,
        }
    }
}