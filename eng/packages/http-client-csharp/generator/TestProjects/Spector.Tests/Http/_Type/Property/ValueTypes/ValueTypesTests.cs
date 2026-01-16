// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using _Type.Property.ValueTypes;
using Azure.Generator.Tests.Common;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Property.ValueTypes
{
    internal class ValueTypesTests : SpectorTestBase
    {

        [SpectorTest]
        public Task BooleanGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(true));
        });

        [SpectorTest]
        public Task BooleanPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanClient().PutAsync(new BooleanProperty(true));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BooleanLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(true));
        });

        [SpectorTest]
        public Task BooleanLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().PutAsync(new BooleanLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo("hello"));
        });

        [SpectorTest]
        public Task StringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringClient().PutAsync(new StringProperty("hello"));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new StringLiteralProperty().Property));
        });

        [SpectorTest]
        public Task StringLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringLiteralClient().PutAsync(new StringLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BytesGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBytesClient().GetAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property);
        });

        [SpectorTest]
        public Task BytesPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBytesClient().PutAsync(new BytesProperty(BinaryData.FromString("hello, world!")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(42));
        });

        [SpectorTest]
        public Task IntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntClient().PutAsync(new IntProperty(42));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IntLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new IntLiteralProperty().Property));
        });

        [SpectorTest]
        public Task IntLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntLiteralClient().PutAsync(new IntLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task FloatGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(43.125f));
        });

        [SpectorTest]
        public Task FloatPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatClient().PutAsync(new FloatProperty((float)43.125));
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task FloatLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new FloatLiteralProperty().Property));
        });

        [SpectorTest]
        public Task FloatLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatLiteralClient().PutAsync(new FloatLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimeGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDatetimeClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
        });

        [SpectorTest]
        public Task DatetimePut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDatetimeClient().PutAsync(new DatetimeProperty(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDurationClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
        });

        [SpectorTest]
        public Task DurationPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDurationClient().PutAsync(new DurationProperty(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task EnumGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetEnumClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(FixedInnerEnum.ValueOne));
        });

        [SpectorTest]
        public Task EnumPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetEnumClient().PutAsync(new EnumProperty(FixedInnerEnum.ValueOne));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ExtensibleEnumGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new InnerEnum("UnknownValue")));
        });

        [SpectorTest]
        public Task ExtensibleEnumPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().PutAsync(new ExtensibleEnumProperty(new InnerEnum("UnknownValue")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ModelGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetModelClient().GetAsync();
            Assert.That(response.Value.Property.Property, Is.EqualTo("hello"));
        });

        [SpectorTest]
        public Task ModelPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetModelClient().PutAsync(new ModelProperty(new InnerModel("hello")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsStringClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new[] { "hello", "world" }).AsCollection);
        });

        [SpectorTest]
        public Task CollectionsStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsStringClient().PutAsync(new CollectionsStringProperty(new[] { "hello", "world" }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsIntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsIntClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(new[] { 1, 2 }).AsCollection);
        });

        [SpectorTest]
        public Task CollectionsIntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsIntClient().PutAsync(new CollectionsIntProperty(new[] { 1, 2 }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsModelGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsModelClient().GetAsync();
            var result = response.Value;
            Assert.That(result.Property[0].Property, Is.EqualTo("hello"));
            Assert.That(result.Property[1].Property, Is.EqualTo("world"));
            Assert.That(result.Property.Count, Is.EqualTo(2));
        });

        [SpectorTest]
        public Task CollectionsModelPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsModelClient().PutAsync(new CollectionsModelProperty(new[] { new InnerModel("hello"), new InnerModel("world") }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DictionaryStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDictionaryStringClient().GetAsync();
            var result = response.Value;
            Assert.That(result.Property["k1"], Is.EqualTo("hello"));
            Assert.That(result.Property["k2"], Is.EqualTo("world"));
            Assert.That(result.Property.Count, Is.EqualTo(2));
        });

        [SpectorTest]
        public Task DictionaryStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDictionaryStringClient().PutAsync(new DictionaryStringProperty(new Dictionary<string, string> { ["k1"] = "hello", ["k2"] = "world" }));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NeverGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetNeverClient().GetAsync();
            var result = response.Value;
            Assert.That(result, Is.Not.Null);
        });

        [SpectorTest]
        public Task NeverPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetNeverClient().PutAsync(new NeverProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownStringClient().GetAsync();
            Assert.That(response.Value.Property.ToObjectFromJson<string>(), Is.EqualTo("hello"));
        });

        [SpectorTest]
        public Task UnknownStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownStringClient().PutAsync(new UnknownStringProperty(new BinaryData("\"hello\"")));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownIntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownIntClient().GetAsync();
            Assert.That(response.Value.Property.ToObjectFromJson<int>(), Is.EqualTo(42));
        });

        [SpectorTest]
        public Task UnknownIntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownIntClient().PutAsync(new UnknownIntProperty(new BinaryData(42)));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownDictGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownDictClient().GetAsync();
            var result = response.Value.Property.ToObjectFromJson<Dictionary<string, object>>();
            Assert.That(result, Is.Not.Null);
            Assert.That(result?["k1"].ToString(), Is.EqualTo("hello"));
            Assert.That(result?.ContainsKey("k2"), Is.True);
            if (result?["k2"] is JsonElement jsonElement)
            {
                Assert.That(jsonElement.ValueKind, Is.EqualTo(JsonValueKind.Number));
                Assert.That(jsonElement.GetInt32(), Is.EqualTo(42));
            }
            Assert.That(result?.Count, Is.EqualTo(2));
        });

        [SpectorTest]
        public Task UnknownDictPut() => Test(async (host) =>
        {
            var input = new Dictionary<string, object>()
            {
                {"k1", "hello" },
                {"k2", 42 }
            };

            var response = await new ValueTypesClient(host, null).GetUnknownDictClient().PutAsync(new UnknownDictProperty(new BinaryData(input)));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownArrayGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownArrayClient().GetAsync();
            var result = response.Value.Property.ToObjectFromJson<object[]>();
            Assert.That(result?[0].ToString(), Is.EqualTo("hello"));
            Assert.That(result?[1].ToString(), Is.EqualTo("world"));
            Assert.That(result?.Length, Is.EqualTo(2));
        });

        [SpectorTest]
        public Task UnknownArrayPut() => Test(async (host) =>
        {
            var input = new[] { "hello", "world" };

            var response = await new ValueTypesClient(host, null).GetUnknownArrayClient().PutAsync(new UnknownArrayProperty(new BinaryData(input)));
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task DecimalGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimalClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(0.33333m));
        });

        [SpectorTest]
        public Task DecimalPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimalClient().PutAsync(new DecimalProperty(0.33333m));
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task Decimal128Get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimal128Client().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(0.33333m));
        });

        [SpectorTest]
        public Task Decimal128Put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimal128Client().PutAsync(new Decimal128Property(0.33333m));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionEnumValueGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(ExtendedEnum.EnumValue2));
        });

        [SpectorTest]
        public Task UnionEnumValuePut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().PutAsync(new UnionEnumValueProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionFloatLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().GetAsync();
            var actual = response.Value.Property;
            Assert.That(actual, Is.EqualTo(UnionFloatLiteralPropertyProperty._46875));
        });

        [SpectorTest]
        public Task UnionFloatLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().PutAsync(new UnionFloatLiteralProperty(UnionFloatLiteralPropertyProperty._46875));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionIntLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(UnionIntLiteralPropertyProperty._42));
        });

        [SpectorTest]
        public Task UnionIntLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().PutAsync(new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42));
            Assert.That(response.Status, Is.EqualTo(204));
        });
        [SpectorTest]
        public Task UnionStringLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().GetAsync();
            Assert.That(response.Value.Property, Is.EqualTo(UnionStringLiteralPropertyProperty.World));
        });

        [SpectorTest]
        public Task UnionStringLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().PutAsync(new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.World));
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
