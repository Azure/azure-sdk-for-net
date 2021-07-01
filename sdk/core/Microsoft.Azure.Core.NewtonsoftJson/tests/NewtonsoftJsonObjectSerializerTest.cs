// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [TestFixture(false)]
    [TestFixture(true)]
    public class NewtonsoftJsonObjectSerializerTest
    {
        private readonly NewtonsoftJsonObjectSerializer _jsonObjectSerializer;
        private readonly DefaultContractResolver _resolver;

        public NewtonsoftJsonObjectSerializerTest(bool camelCase)
        {
            // Use contract resolvers that sort the serialized properties case-insensitively for deterministic assertions.
            _resolver = camelCase ? (DefaultContractResolver)new SortedCamelCasePropertyNamesContractResolver() : new SortedDefaultContractResolver();

            _jsonObjectSerializer = new NewtonsoftJsonObjectSerializer(new JsonSerializerSettings
            {
                ContractResolver = _resolver,
                Converters = new[]
                {
                    new StringEnumConverter(true),
                },
            });

            IsCamelCase = camelCase;
        }

        public bool IsCamelCase { get; }

        private string SerializedName(string name) => _resolver.GetResolvedPropertyName(name);

        [Test]
        public void ConstructorRequiresArgument()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new NewtonsoftJsonObjectSerializer(null));
            Assert.AreEqual("settings", ex.ParamName);
        }

        [Test]
        public void CanSerializeAnObject()
        {
            using var memoryStream = new MemoryStream();
            var o = new ExtendedModel(4, 8)
            {
                A = "1",
                ActuallyB = 2,
                C = 3,
                Type = ModelType.One,
                IgnoredE = 5,
                F = 6,
                G = 7,
            };

            _jsonObjectSerializer.Serialize(memoryStream, o, o.GetType(), default);

            Assert.AreEqual($"{{\"{SerializedName("A")}\":\"1\",\"b\":2,\"d\":4,\"{SerializedName("F")}\":6,\"h\":8,\"{SerializedName("Type")}\":\"one\"}}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public async Task CanSerializeAnObjectAsync()
        {
            using var memoryStream = new MemoryStream();
            var o = new ExtendedModel(4, 8)
            {
                A = "1",
                ActuallyB = 2,
                C = 3,
                Type = ModelType.One,
                IgnoredE = 5,
                F = 6,
                G = 7,
            };

            await _jsonObjectSerializer.SerializeAsync(memoryStream, o, o.GetType(), default);

            Assert.AreEqual($"{{\"{SerializedName("A")}\":\"1\",\"b\":2,\"d\":4,\"{SerializedName("F")}\":6,\"h\":8,\"{SerializedName("Type")}\":\"one\"}}", Encoding.UTF8.GetString(memoryStream.ToArray()));
        }

        [Test]
        public void CanDeserializeAnObject()
        {
            var json = $@"{{
    ""{SerializedName("A")}"": ""1"",
    ""b"": 2,
    ""{SerializedName("C")}"": 3,
    ""{SerializedName("Type")}"": ""one"",
    ""d"": 4,
    ""{SerializedName("IgnoredE")}"": 5,
    ""{SerializedName("F")}"": 6,
    ""{SerializedName("G")}"": 7,
    ""h"": 8
}}";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            var model = (ExtendedModel)_jsonObjectSerializer.Deserialize(memoryStream, typeof(ExtendedModel), default);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.ActuallyB);
            Assert.AreEqual(0, model.C);
            Assert.AreEqual(ModelType.One, model.Type);
            Assert.AreEqual(0, model.ReadOnlyD);
            Assert.AreEqual(0, model.IgnoredE);
            Assert.AreEqual(6, model.F);
            Assert.AreEqual(0, model.G);
            Assert.AreEqual(8, model.GetH());
        }

        [Test]
        public async Task CanDeserializeAnObjectAsync()
        {
            var json = $@"{{
    ""{SerializedName("A")}"": ""1"",
    ""b"": 2,
    ""{SerializedName("C")}"": 3,
    ""{SerializedName("Type")}"": ""one"",
    ""d"": 4,
    ""{SerializedName("IgnoredE")}"": 5,
    ""{SerializedName("F")}"": 6,
    ""{SerializedName("G")}"": 7,
    ""h"": 8
}}";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            var model = (ExtendedModel)await _jsonObjectSerializer.DeserializeAsync(memoryStream, typeof(ExtendedModel), default).ConfigureAwait(false);

            Assert.AreEqual("1", model.A);
            Assert.AreEqual(2, model.ActuallyB);
            Assert.AreEqual(0, model.C);
            Assert.AreEqual(ModelType.One, model.Type);
            Assert.AreEqual(0, model.ReadOnlyD);
            Assert.AreEqual(0, model.IgnoredE);
            Assert.AreEqual(6, model.F);
            Assert.AreEqual(0, model.G);
            Assert.AreEqual(8, model.GetH());
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

                    case nameof(ExtendedModel.ActuallyB):
                        Assert.AreEqual("b", propertyName);
                        break;

                    case nameof(ExtendedModel.Type):
                        Assert.AreEqual(SerializedName("Type"), propertyName);
                        break;

                    case nameof(ExtendedModel.ReadOnlyD):
                        Assert.AreEqual("d", propertyName);
                        break;

                    case nameof(ExtendedModel.F):
                        Assert.AreEqual(SerializedName("F"), propertyName);
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
            public ExtendedModel()
            {
            }

            internal ExtendedModel(int readOnlyD, int h)
            {
                ReadOnlyD = readOnlyD;
                H = h;
            }

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

            internal int GetH() => H;
        }

        public enum ModelType
        {
            Unknown = 0,
            One = 1,
            Two = 2,
        }

        private class SortedCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
        {
            // Make sure all properties and fields are sorted case-insensitively for deterministic assertions.
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) =>
                base.CreateProperties(type, memberSerialization)
                    .OrderBy(property => property.PropertyName, StringComparer.OrdinalIgnoreCase)
                    .ToList();
        }

        private class SortedDefaultContractResolver : DefaultContractResolver
        {
            // Make sure all properties and fields are sorted case-insensitively for deterministic assertions.
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) =>
                base.CreateProperties(type, memberSerialization)
                    .OrderBy(property => property.PropertyName, StringComparer.OrdinalIgnoreCase)
                    .ToList();
        }
    }
}