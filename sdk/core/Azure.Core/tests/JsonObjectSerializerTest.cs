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
            Assert.That(ex.ParamName, Is.EqualTo("options"));
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
                IgnoredG = 7,
                H = "8",
            };

            _jsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.That(Encoding.UTF8.GetString(memoryStream.ToArray()), Is.EqualTo($"{{\"d\":4,\"{SerializedName("H")}\":\"8\",\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));
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
                IgnoredG = 7,
                H = "8",
            };

            await _jsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            Assert.That(Encoding.UTF8.GetString(memoryStream.ToArray()), Is.EqualTo($"{{\"d\":4,\"{SerializedName("H")}\":\"8\",\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes($"{{\"d\":4,\"{SerializedName("H")}\":\"8\",\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));

            var model = (ExtendedModel)_jsonObjectSerializer.Deserialize(memoryStream, typeof(ExtendedModel), default);

            Assert.That(model.A, Is.EqualTo("1"));
            Assert.That(model.B, Is.EqualTo(2));
            Assert.That(model.C, Is.EqualTo(0));
            Assert.That(model.ReadOnlyD, Is.EqualTo(0));
            Assert.That(model.IgnoredE, Is.EqualTo(0));
            Assert.That(model.F, Is.EqualTo(0));
            Assert.That(model.IgnoredG, Is.EqualTo(0));
            Assert.That(model.H, Is.EqualTo("8"));
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes($"{{\"d\":4,\"{SerializedName("H")}\":\"8\",\"{SerializedName("A")}\":\"1\",\"{SerializedName("B")}\":2}}"));

            var model = (ExtendedModel)await _jsonObjectSerializer.DeserializeAsync(memoryStream, typeof(ExtendedModel), default).ConfigureAwait(false);

            Assert.That(model.A, Is.EqualTo("1"));
            Assert.That(model.B, Is.EqualTo(2));
            Assert.That(model.C, Is.EqualTo(0));
            Assert.That(model.ReadOnlyD, Is.EqualTo(0));
            Assert.That(model.IgnoredE, Is.EqualTo(0));
            Assert.That(model.F, Is.EqualTo(0));
            Assert.That(model.IgnoredG, Is.EqualTo(0));
            Assert.That(model.H, Is.EqualTo("8"));
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
                        Assert.That(propertyName, Is.EqualTo(SerializedName("A")));
                        break;

                    case nameof(ExtendedModel.B):
                        Assert.That(propertyName, Is.EqualTo(SerializedName("B")));
                        break;

                    case nameof(ExtendedModel.ReadOnlyD):
                        Assert.That(propertyName, Is.EqualTo("d"));
                        break;

                    case nameof(ExtendedModel.H):
                        Assert.That(propertyName, Is.EqualTo(SerializedName("H")));
                        break;

                    default:
                        Assert.That(propertyName, Is.Null, $"Unexpected serialized name '{propertyName}' for member {member.DeclaringType}.{member.Name}");
                        break;
                }
            }
        }

        public class Model
        {
#if NET5_0_OR_GREATER
            [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
#endif
            public string A { get; set; }

#if NET5_0_OR_GREATER
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
#endif
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

#if NET5_0_OR_GREATER
            [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
#else
            [JsonIgnore]
#endif
            public int IgnoredG { get; set; }

#if NET5_0_OR_GREATER
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
#endif
            public string H { get; set; }
        }
    }
}
