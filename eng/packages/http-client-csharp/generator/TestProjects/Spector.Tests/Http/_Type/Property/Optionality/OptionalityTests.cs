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
            Assert.That(response.Value.Property, Is.EqualTo(true));
        });

        [SpectorTest]
        public Task BooleanLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task BooleanLiteralPutAll() => Test(async (host) =>
        {
            BooleanLiteralProperty data = new()
            {
                Property = true
            };
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BooleanLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBooleanLiteralClient().PutDefaultAsync(new BooleanLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo("hello"));
        });

        [SpectorTest]
        public Task StringGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task StringPutAll() => Test(async (host) =>
        {
            StringProperty data = new()
            {
                Property = "hello"
            };
            var response = await new OptionalClient(host, null).GetStringClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringClient().PutDefaultAsync(new StringProperty());
            Assert.That(response.Status, Is.EqualTo(204));
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
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task BytesPutAll() => Test(async (host) =>
        {
            BytesProperty data = new()
            {
                Property = BinaryData.FromString("hello, world!")
            };
            var response = await new OptionalClient(host, null).GetBytesClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BytesPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetBytesClient().PutDefaultAsync(new BytesProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimeGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
        });

        [SpectorTest]
        public Task DatetimeGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task DatetimePutAll() => Test(async (host) =>
        {
            DatetimeProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-08-26T18:38:00Z")
            };
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDatetimeClient().PutDefaultAsync(new DatetimeProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PlaindateGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().GetAllAsync();
            var expectedDate = new DateTimeOffset(2022, 12, 12, 8, 0, 0, TimeSpan.FromHours(8));
            Assert.That(response.Value.Property!.Value.ToOffset(TimeSpan.FromHours(8)), Is.EqualTo(expectedDate));
        });

        [SpectorTest]
        public Task PlaindateGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task PlaindatePutAll() => Test(async (host) =>
        {
            PlainDateProperty data = new()
            {
                Property = DateTimeOffset.Parse("2022-12-12")
            };
            var response = await new OptionalClient(host, null).GetPlainDateClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PlaindatePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainDateClient().PutDefaultAsync(new PlainDateProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PlaintimeGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(TimeSpan.Parse("13:06:12")));
        });

        [SpectorTest]
        public Task PlaintimeGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task PlaintimePutAll() => Test(async (host) =>
        {
            PlainTimeProperty data = new()
            {
                Property = TimeSpan.Parse("13:06:12")
            };
            var response = await new OptionalClient(host, null).GetPlainTimeClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PlaintimePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetPlainTimeClient().PutDefaultAsync(new PlainTimeProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
        });

        [SpectorTest]
        public Task DurationGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task DurationPutAll() => Test(async (host) =>
        {
            DurationProperty data = new()
            {
                Property = XmlConvert.ToTimeSpan("P123DT22H14M12.011S")
            };
            var response = await new OptionalClient(host, null).GetDurationClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetDurationClient().PutDefaultAsync(new DurationProperty());
            Assert.That(response.Status, Is.EqualTo(204));
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
            Assert.That(response.Value.Property.Count, Is.EqualTo(0));
        });

        [SpectorTest]
        public Task CollectionsBytePutAll() => Test(async (host) =>
        {
            CollectionsByteProperty data = new();
            data.Property.Add(BinaryData.FromString("hello, world!"));
            data.Property.Add(BinaryData.FromString("hello, world!"));

            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsBytePutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsByteClient().PutDefaultAsync(new CollectionsByteProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });


        [SpectorTest]
        public Task CollectionsModelGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetAllAsync();
            var result = response.Value;
            Assert.That(result.Property[0].Property, Is.EqualTo("hello"));
            Assert.That(result.Property[1].Property, Is.EqualTo("world"));
            Assert.That(result.Property.Count, Is.EqualTo(2));
        });

        [SpectorTest]
        public Task CollectionsModelGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().GetDefaultAsync();
            Assert.That(response.Value.Property.Count, Is.EqualTo(0));
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsModelPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetCollectionsModelClient().PutDefaultAsync(new CollectionsModelProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RequiredAndOptionalGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetAllAsync();
            var result = response.Value;
            Assert.That(result.OptionalProperty, Is.EqualTo("hello"));
            Assert.That(result.RequiredProperty, Is.EqualTo(42));
        });

        [SpectorTest]
        public Task RequiredAndOptionalGetRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().GetRequiredOnlyAsync();
            var result = response.Value;
            Assert.That(result.OptionalProperty, Is.EqualTo(null));
            Assert.That(result.RequiredProperty, Is.EqualTo(42));
        });

        [SpectorTest]
        public Task RequiredAndOptionalPutAll() => Test(async (host) =>
        {
            var content = new RequiredAndOptionalProperty(42)
            {
                OptionalProperty = "hello"
            };

            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutAllAsync(content);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RequiredAndOptionalPutRequiredOnly() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetRequiredAndOptionalClient().PutRequiredOnlyAsync(new RequiredAndOptionalProperty(42));
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task FloatLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(FloatLiteralPropertyProperty._125));
        });

        [SpectorTest]
        public Task FloatLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task FloatLiteralPutAll() => Test(async (host) =>
        {
            FloatLiteralProperty data = new()
            {
                Property = 1.25f
            };
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task FloatLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetFloatLiteralClient().PutDefaultAsync(new FloatLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IntLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(IntLiteralPropertyProperty._1));
        });

        [SpectorTest]
        public Task IntLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task IntLiteralPutAll() => Test(async (host) =>
        {
            IntLiteralProperty data = new()
            {
                Property = 1
            };
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task IntLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetIntLiteralClient().PutDefaultAsync(new IntLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(StringLiteralPropertyProperty.Hello));
        });

        [SpectorTest]
        public Task StringLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task StringLiteralPutAll() => Test(async (host) =>
        {
            StringLiteralProperty data = new()
            {
                Property = "hello"
            };
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetStringLiteralClient().PutDefaultAsync(new StringLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionFloatLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(UnionFloatLiteralPropertyProperty._2375));
        });

        [SpectorTest]
        public Task UnionFloatLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task UnionFloatLiteralPutAll() => Test(async (host) =>
        {
            UnionFloatLiteralProperty data = new()
            {
                Property = UnionFloatLiteralPropertyProperty._2375
            };
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionFloatLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionFloatLiteralClient().PutDefaultAsync(new UnionFloatLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionIntLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(UnionIntLiteralPropertyProperty._2));
        });

        [SpectorTest]
        public Task UnionIntLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task UnionIntLiteralGutAll() => Test(async (host) =>
        {
            UnionIntLiteralProperty data = new()
            {
                Property = UnionIntLiteralPropertyProperty._2
            };
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionIntLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionIntLiteralClient().PutDefaultAsync(new UnionIntLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionStringLiteralGetAll() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetAllAsync();
            Assert.That(response.Value.Property, Is.EqualTo(UnionStringLiteralPropertyProperty.World));
        });

        [SpectorTest]
        public Task UnionStringLiteralGetDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().GetDefaultAsync();
            Assert.That(response.Value.Property, Is.EqualTo(null));
        });

        [SpectorTest]
        public Task UnionStringLiteralPutAll() => Test(async (host) =>
        {
            UnionStringLiteralProperty data = new()
            {
                Property = UnionStringLiteralPropertyProperty.World,
            };
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutAllAsync(data);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnionStringLiteralPutDefault() => Test(async (host) =>
        {
            var response = await new OptionalClient(host, null).GetUnionStringLiteralClient().PutDefaultAsync(new UnionStringLiteralProperty());
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
