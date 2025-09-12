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
            Assert.AreEqual(true, response.Value.Property);
        });

        [SpectorTest]
        public Task BooleanPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanClient().PutAsync(new BooleanProperty(true));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BooleanLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().GetAsync();
            Assert.AreEqual(true, response.Value.Property);
        });

        [SpectorTest]
        public Task BooleanLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetBooleanLiteralClient().PutAsync(new BooleanLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringClient().GetAsync();
            Assert.AreEqual("hello", response.Value.Property);
        });

        [SpectorTest]
        public Task StringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringClient().PutAsync(new StringProperty("hello"));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringLiteralClient().GetAsync();
            Assert.AreEqual(new StringLiteralProperty().Property, response.Value.Property);
        });

        [SpectorTest]
        public Task StringLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetStringLiteralClient().PutAsync(new StringLiteralProperty());
            Assert.AreEqual(204, response.Status);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntClient().GetAsync();
            Assert.AreEqual(42, response.Value.Property);
        });

        [SpectorTest]
        public Task IntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntClient().PutAsync(new IntProperty(42));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IntLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntLiteralClient().GetAsync();
            Assert.AreEqual(new IntLiteralProperty().Property, response.Value.Property);
        });

        [SpectorTest]
        public Task IntLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetIntLiteralClient().PutAsync(new IntLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task FloatGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatClient().GetAsync();
            Assert.AreEqual(43.125f, response.Value.Property);
        });

        [SpectorTest]
        public Task FloatPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatClient().PutAsync(new FloatProperty((float)43.125));
            Assert.AreEqual(204, response.Status);
        });
        [SpectorTest]
        public Task FloatLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatLiteralClient().GetAsync();
            Assert.AreEqual(new FloatLiteralProperty().Property, response.Value.Property);
        });

        [SpectorTest]
        public Task FloatLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetFloatLiteralClient().PutAsync(new FloatLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DatetimeGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDatetimeClient().GetAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.Property);
        });

        [SpectorTest]
        public Task DatetimePut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDatetimeClient().PutAsync(new DatetimeProperty(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDurationClient().GetAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.Property);
        });

        [SpectorTest]
        public Task DurationPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDurationClient().PutAsync(new DurationProperty(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task EnumGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetEnumClient().GetAsync();
            Assert.AreEqual(FixedInnerEnum.ValueOne, response.Value.Property);
        });

        [SpectorTest]
        public Task EnumPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetEnumClient().PutAsync(new EnumProperty(FixedInnerEnum.ValueOne));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ExtensibleEnumGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().GetAsync();
            Assert.AreEqual(new InnerEnum("UnknownValue"), response.Value.Property);
        });

        [SpectorTest]
        public Task ExtensibleEnumPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetExtensibleEnumClient().PutAsync(new ExtensibleEnumProperty(new InnerEnum("UnknownValue")));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetModelClient().GetAsync();
            Assert.AreEqual("hello", response.Value.Property.Property);
        });

        [SpectorTest]
        public Task ModelPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetModelClient().PutAsync(new ModelProperty(new InnerModel("hello")));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsStringClient().GetAsync();
            CollectionAssert.AreEqual(new[] { "hello", "world" }, response.Value.Property);
        });

        [SpectorTest]
        public Task CollectionsStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsStringClient().PutAsync(new CollectionsStringProperty(new[] { "hello", "world" }));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsIntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsIntClient().GetAsync();
            CollectionAssert.AreEqual(new[] { 1, 2 }, response.Value.Property);
        });

        [SpectorTest]
        public Task CollectionsIntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsIntClient().PutAsync(new CollectionsIntProperty(new[] { 1, 2 }));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsModelGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsModelClient().GetAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
            Assert.AreEqual(2, result.Property.Count);
        });

        [SpectorTest]
        public Task CollectionsModelPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetCollectionsModelClient().PutAsync(new CollectionsModelProperty(new[] { new InnerModel("hello"), new InnerModel("world") }));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DictionaryStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDictionaryStringClient().GetAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property["k1"]);
            Assert.AreEqual("world", result.Property["k2"]);
            Assert.AreEqual(2, result.Property.Count);
        });

        [SpectorTest]
        public Task DictionaryStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDictionaryStringClient().PutAsync(new DictionaryStringProperty(new Dictionary<string, string> { ["k1"] = "hello", ["k2"] = "world" }));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task NeverGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetNeverClient().GetAsync();
            var result = response.Value;
            Assert.NotNull(result);
        });

        [SpectorTest]
        public Task NeverPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetNeverClient().PutAsync(new NeverProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnknownStringGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownStringClient().GetAsync();
            Assert.AreEqual("hello", response.Value.Property.ToObjectFromJson<string>());
        });

        [SpectorTest]
        public Task UnknownStringPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownStringClient().PutAsync(new UnknownStringProperty(new BinaryData("\"hello\"")));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnknownIntGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownIntClient().GetAsync();
            Assert.AreEqual(42, response.Value.Property.ToObjectFromJson<int>());
        });

        [SpectorTest]
        public Task UnknownIntPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownIntClient().PutAsync(new UnknownIntProperty(new BinaryData(42)));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnknownDictGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownDictClient().GetAsync();
            var result = response.Value.Property.ToObjectFromJson<Dictionary<string, object>>();
            Assert.IsNotNull(result);
            Assert.AreEqual("hello", result?["k1"].ToString());
            Assert.IsTrue(result?.ContainsKey("k2"));
            if (result?["k2"] is JsonElement jsonElement)
            {
                Assert.AreEqual(JsonValueKind.Number, jsonElement.ValueKind);
                Assert.AreEqual(42, jsonElement.GetInt32());
            }
            Assert.AreEqual(2, result?.Count);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnknownArrayGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnknownArrayClient().GetAsync();
            var result = response.Value.Property.ToObjectFromJson<object[]>();
            Assert.AreEqual("hello", result?[0].ToString());
            Assert.AreEqual("world", result?[1].ToString());
            Assert.AreEqual(2, result?.Length);
        });

        [SpectorTest]
        public Task UnknownArrayPut() => Test(async (host) =>
        {
            var input = new[] { "hello", "world" };

            var response = await new ValueTypesClient(host, null).GetUnknownArrayClient().PutAsync(new UnknownArrayProperty(new BinaryData(input)));
            Assert.AreEqual(204, response.Status);
        });
        [SpectorTest]
        public Task DecimalGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimalClient().GetAsync();
            Assert.AreEqual(0.33333m, response.Value.Property);
        });

        [SpectorTest]
        public Task DecimalPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimalClient().PutAsync(new DecimalProperty(0.33333m));
            Assert.AreEqual(204, response.Status);
        });
        [SpectorTest]
        public Task Decimal128Get() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimal128Client().GetAsync();
            Assert.AreEqual(0.33333m, response.Value.Property);
        });

        [SpectorTest]
        public Task Decimal128Put() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetDecimal128Client().PutAsync(new Decimal128Property(0.33333m));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionEnumValueGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().GetAsync();
            Assert.AreEqual(ExtendedEnum.EnumValue2, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionEnumValuePut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionEnumValueClient().PutAsync(new UnionEnumValueProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionFloatLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().GetAsync();
            var actual = response.Value.Property;
            Assert.AreEqual(UnionFloatLiteralPropertyProperty._46875, actual);
        });

        [SpectorTest]
        public Task UnionFloatLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionFloatLiteralClient().PutAsync(new UnionFloatLiteralProperty(UnionFloatLiteralPropertyProperty._46875));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionIntLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().GetAsync();
            Assert.AreEqual(UnionIntLiteralPropertyProperty._42, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionIntLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionIntLiteralClient().PutAsync(new UnionIntLiteralProperty(UnionIntLiteralPropertyProperty._42));
            Assert.AreEqual(204, response.Status);
        });
        [SpectorTest]
        public Task UnionStringLiteralGet() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().GetAsync();
            Assert.AreEqual(UnionStringLiteralPropertyProperty.World, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionStringLiteralPut() => Test(async (host) =>
        {
            var response = await new ValueTypesClient(host, null).GetUnionStringLiteralClient().PutAsync(new UnionStringLiteralProperty(UnionStringLiteralPropertyProperty.World));
            Assert.AreEqual(204, response.Status);
        });
    }
}
