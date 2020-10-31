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
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(false)]
    [TestFixture(true)]
    public class JsonObjectSerializerTest
    {
        private readonly JsonObjectSerializer _jsonObjectSerializer;

        public JsonObjectSerializerTest(bool camelCase)
        {
            _jsonObjectSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = camelCase ? JsonNamingPolicy.CamelCase : null,
                });

            IsCamelCase = camelCase;
        }

        public bool IsCamelCase { get; }

        private string SerializedName(string name) => IsCamelCase ? JsonNamingPolicy.CamelCase.ConvertName(name) : name;

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
            var o = new ExtendedModel(readOnlyD: 4)
            {
                A = "1",
                B = 2,
                C = 3,
                IgnoredE = 5,
                F = 6,
            };

            _jsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.AreEqual($"{{\"d\":4,\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public async Task CanSerializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream();
            var o = new ExtendedModel(readOnlyD: 4)
            {
                A = "1",
                B = 2,
                C = 3,
                IgnoredE = 5,
                F = 6,
            };

            await _jsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            Assert.AreEqual($"{{\"d\":4,\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes($"{{\"d\":4,\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));

            var model = (ExtendedModel)_jsonObjectSerializer.Deserialize(memoryStream, typeof(ExtendedModel), default);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
            Assert.AreEqual(0, model.C);
            Assert.AreEqual(0, model.ReadOnlyD);
            Assert.AreEqual(0, model.IgnoredE);
            Assert.AreEqual(0, model.F);
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes($"{{\"d\":4,\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));

            var model = (ExtendedModel)await _jsonObjectSerializer.DeserializeAsync(memoryStream, typeof(ExtendedModel), default).ConfigureAwait(false);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.B);
            Assert.AreEqual(0, model.C);
            Assert.AreEqual(0, model.ReadOnlyD);
            Assert.AreEqual(0, model.IgnoredE);
            Assert.AreEqual(0, model.F);
        }

        [Test]
        public void ConvertMemberName()
        {
            IEnumerable<MemberInfo> members = typeof(ExtendedModel)
                .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(member => (member.MemberType & (MemberTypes.Property | MemberTypes.Field)) != 0);

            IMemberNameConverter converter = _jsonObjectSerializer;

            foreach (MemberInfo member in members)
            {
                string propertyName = converter.ConvertMemberName(member);

                // The following should be null for any property that does not serialized (compare to assertions above).
                switch (member.Name)
                {
                    case nameof(ExtendedModel.A):
                        Assert.AreEqual(SerializedName("A"), propertyName);
                        break;

                    case nameof(ExtendedModel.B):
                        Assert.AreEqual(SerializedName("B"), propertyName);
                        break;

                    case nameof(ExtendedModel.ReadOnlyD):
                        Assert.AreEqual("d", propertyName);
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
            public ExtendedModel()
            {
            }

            internal ExtendedModel(int readOnlyD)
            {
                ReadOnlyD = readOnlyD;
            }

            [JsonPropertyName("d")]
            public int ReadOnlyD { get; }

            internal int IgnoredE { get; set; }

            public int F;
        }
    }
}
