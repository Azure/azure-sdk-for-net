// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Xml;
using _Type.Property.Optional;
using Azure.Generator.Tests.Common;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Property.Optionality
{
    internal class OptionalityTests : SpectorTestBase
    {
        [SpectorTest]
        public Task BooleanLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().GetAllAsync();
            Assert.AreEqual(true, response.Value.Property);
        });

        [SpectorTest]
        public Task BooleanLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task BooleanLiteralPutAll() => Test(async (host) =>
        {
            BooleanLiteralProperty data = new()
            {
                Property = true
            };
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BooleanLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutDefaultAsync(new BooleanLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetAllAsync();
            Assert.AreEqual("hello", response.Value.Property);
        });

        [SpectorTest]
        public Task StringGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task StringPutAll() => Test(async (host) =>
        {
            StringProperty data = new()
            {
                Property = "hello"
            };
            var response = await new OptionalClient(host, null).GetStringClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().PutDefaultAsync(new StringProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BytesGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property);
        });

        [SpectorTest]
        public Task BytesGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task BytesPutAll() => Test(async (host) =>
        {
            BytesProperty data = new()
            {
                Property = BinaryData.FromString("hello, world!")
            };
            var response = await new OptionalClient(host, null).GetBytesClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BytesPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().PutDefaultAsync(new BytesProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DatetimeGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetAllAsync();
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.Property);
        });

        [SpectorTest]
        public Task DatetimeGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task DatetimePutAll() => Test(async (host) =>
        {
            DatetimeProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-08-26T18:38:00Z")
            };
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DatetimePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutDefaultAsync(new DatetimeProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PlaindateGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().GetAllAsync();
            var expectedDate = new DateTimeOffset(2022, 12, 12, 8, 0, 0, TimeSpan.FromHours(8));
            Assert.AreEqual(expectedDate, response.Value.Property!.Value.ToOffset(TimeSpan.FromHours(8)));
        });

        [SpectorTest]
        public Task PlaindateGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task PlaindatePutAll() => Test(async (host) =>
        {
            PlainDateProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-12-12")
            };
            var response = await new OptionalClient(host, null).GetPlainDateClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PlaindatePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().PutDefaultAsync(new PlainDateProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PlaintimeGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().GetAllAsync();
            Assert.AreEqual(TimeSpan.Parse("13:06:12"), response.Value.Property);
        });

        [SpectorTest]
        public Task PlaintimeGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task PlaintimePutAll() => Test(async (host) =>
        {
            PlainTimeProperty data = new()
            {
                Property = TimeSpan.Parse("13:06:12")
            };
            var response = await new OptionalClient(host, null).GetPlainTimeClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PlaintimePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().PutDefaultAsync(new PlainTimeProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetAllAsync();
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.Property);
        });

        [SpectorTest]
        public Task DurationGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task DurationPutAll() => Test(async (host) =>
        {
            DurationProperty data = new()
            {
                Property = XmlConvert.ToTimeSpan("P123DT22H14M12.011S")
            };
            var response = await new OptionalClient(host, null).GetDurationClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().PutDefaultAsync(new DurationProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsByteGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().GetAllAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property[0]);
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.Property[1]);
        });

        [SpectorTest]
        public Task CollectionsByteGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().GetDefaultAsync();
            Assert.AreEqual(0, response.Value.Property.Count);
        });

        [SpectorTest]
        public Task CollectionsBytePutAll() => Test(async (host) =>
        {
            CollectionsByteProperty data = new();
            data.Property.Add(BinaryData.FromString("hello, world!"));
            data.Property.Add(BinaryData.FromString("hello, world!"));

            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsBytePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutDefaultAsync(new CollectionsByteProperty());
            Assert.AreEqual(204, response.Status);
        });


        [SpectorTest]
        public Task CollectionsModelGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetAllAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.Property[0].Property);
            Assert.AreEqual("world", result.Property[1].Property);
            Assert.AreEqual(2, result.Property.Count);
        });

        [SpectorTest]
        public Task CollectionsModelGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetDefaultAsync();
            Assert.AreEqual(0, response.Value.Property.Count);
        });

        [SpectorTest]
        public Task CollectionsModelPutAll() => Test(async (host) =>
        {
            CollectionsModelProperty data = new();
            data.Property.Add(new StringProperty()
            {
                Property = "hello"
            });
            data.Property.Add(new StringProperty()
            {
                Property = "world"
            });

            var response = await new OptionalClient(host, null).GetCollectionsModelClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsModelPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().PutDefaultAsync(new CollectionsModelProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RequiredAndOptionalGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetAllAsync();
            var result = response.Value;
            Assert.AreEqual("hello", result.OptionalProperty);
            Assert.AreEqual(42, result.RequiredProperty);
        });

        [SpectorTest]
        public Task RequiredAndOptionalGetRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetRequiredOnlyAsync();
            var result = response.Value;
            Assert.AreEqual(null, result.OptionalProperty);
            Assert.AreEqual(42, result.RequiredProperty);
        });

        [SpectorTest]
        public Task RequiredAndOptionalPutAll() => Test(async (host) =>
        {
            var content = new RequiredAndOptionalProperty(42)
            {
                OptionalProperty = "hello"
            };

            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutAllAsync(content);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RequiredAndOptionalPutRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutRequiredOnlyAsync(new RequiredAndOptionalProperty(42));
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task FloatLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetAllAsync();
            Assert.AreEqual(1.25f, response.Value.Property);
        });

        [SpectorTest]
        public Task FloatLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task FloatLiteralPutAll() => Test(async (host) =>
        {
            FloatLiteralProperty data = new()
            {
                Property = 1.25f
            };
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task FloatLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutDefaultAsync(new FloatLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IntLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetAllAsync();
            Assert.AreEqual(1, response.Value.Property);
        });

        [SpectorTest]
        public Task IntLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task IntLiteralPutAll() => Test(async (host) =>
        {
            IntLiteralProperty data = new()
            {
                Property = 1
            };
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task IntLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutDefaultAsync(new IntLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetAllAsync();
            Assert.AreEqual("hello", response.Value.Property);
        });

        [SpectorTest]
        public Task StringLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task StringLiteralPutAll() => Test(async (host) =>
        {
            StringLiteralProperty data = new()
            {
                Property = "hello"
            };
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutDefaultAsync(new StringLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionFloatLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetAllAsync();
            Assert.AreEqual(UnionFloatLiteralPropertyProperty._2375, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionFloatLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionFloatLiteralPutAll() => Test(async (host) =>
        {
            UnionFloatLiteralProperty data = new()
            {
                Property = UnionFloatLiteralPropertyProperty._2375
            };
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionFloatLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutDefaultAsync(new UnionFloatLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionIntLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetAllAsync();
            Assert.AreEqual(UnionIntLiteralPropertyProperty._2, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionIntLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionIntLiteralGutAll() => Test(async (host) =>
        {
            UnionIntLiteralProperty data = new()
            {
                Property = UnionIntLiteralPropertyProperty._2
            };
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionIntLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutDefaultAsync(new UnionIntLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionStringLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetAllAsync();
            Assert.AreEqual(UnionStringLiteralPropertyProperty.World, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionStringLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetDefaultAsync();
            Assert.AreEqual(null, response.Value.Property);
        });

        [SpectorTest]
        public Task UnionStringLiteralPutAll() => Test(async (host) =>
        {
            UnionStringLiteralProperty data = new()
            {
                Property = UnionStringLiteralPropertyProperty.World,
            };
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutAllAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnionStringLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutDefaultAsync(new UnionStringLiteralProperty());
            Assert.AreEqual(204, response.Status);
        });
    }
}
