// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public void ConstructorRequiresArgument()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new JsonObjectSerializer(null));
            Assert.AreEqual("options", ex.ParamName);
        }

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
        public void GetSerializedMemberName([Values] bool camelCase)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null,
            };

            JsonObjectSerializer serializer = new JsonObjectSerializer(options);

            IEnumerable<MemberInfo> members = typeof(ExtendedModel)
                .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(member => (member.MemberType & (MemberTypes.Property | MemberTypes.Field)) != 0);

            string Name(string name) => camelCase ? options.PropertyNamingPolicy.ConvertName(name) : name;
            foreach (MemberInfo member in members)
            {
                string propertyName = serializer.GetSerializedMemberName(member);
                switch (member.Name)
                {
                    case nameof(ExtendedModel.A):
                        Assert.AreEqual(Name("A"), propertyName);
                        break;

                    case nameof(ExtendedModel.B):
                        Assert.AreEqual(Name("B"), propertyName);
                        break;

                    case nameof(ExtendedModel.C):
                        Assert.IsNull(propertyName);
                        break;

                    case nameof(ExtendedModel.ReadOnlyD):
                        Assert.AreEqual("d", propertyName);
                        break;

                    case nameof(ExtendedModel.IgnoredE):
                        Assert.IsNull(propertyName);
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

            public int B { get; set; }

            [JsonIgnore]
            public int C { get; set; }
        }

        public class ExtendedModel : Model
        {
            [JsonPropertyName("d")]
            public int ReadOnlyD { get; }

            internal int IgnoredE { get; set; }

            public int F;
        }
    }
}
