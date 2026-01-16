// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using _Type.Property.Nullable;
using Azure.Core;
using Azure.Generator.Tests.Common;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Property.Nullable
{
    internal class NullableTests : SpectorTestBase
    {
        [SpectorTest]
        public Task StringGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetStringClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.EqualTo("hello"));
        });

        [SpectorTest]
        public Task StringGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetStringClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Null);
        });

        [SpectorTest]
        public Task StringPatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                nullableProperty = "hello"
            };
            var response = await new NullableClient(host, null).GetStringClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetStringClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BytesGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetBytesClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty);
        });

        [SpectorTest]
        public Task BytesGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetBytesClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Null);
        });

        [SpectorTest]
        public Task BytesPatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                // cspell: disable-next-line
                nullableProperty = "aGVsbG8sIHdvcmxkIQ=="
            };
            var response = await new NullableClient(host, null).GetBytesClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BytesPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetBytesClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimeTetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDatetimeClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.EqualTo(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
        });

        [SpectorTest]
        public Task DatetimeGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDatetimeClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Null);
        });

        [SpectorTest]
        public Task DatetimePatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                nullableProperty = DateTimeOffset.Parse("2022-08-26T18:38:00Z")
            };
            var response = await new NullableClient(host, null).GetDatetimeClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Datetime_patchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetDatetimeClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDurationClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.EqualTo(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
        });

        [SpectorTest]
        public Task Type_Property_Nullable_Duration_getNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDurationClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Null);
        });

        [SpectorTest]
        public Task DurationPatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                nullableProperty = "P123DT22H14M12.011S"
            };
            var response = await new NullableClient(host, null).GetDurationClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetDurationClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsByteGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty.Count, Is.EqualTo(2));
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty.First());
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty.Last());
        });

        [SpectorTest]
        public Task CollectionsByteGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Not.Null);
        });

        [SpectorTest]
        public Task CollectionsBytePatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                // cspell: disable-next-line
                nullableProperty = new[] { "aGVsbG8sIHdvcmxkIQ==", "aGVsbG8sIHdvcmxkIQ==" }
            };
            var response = await new NullableClient(host, null).GetCollectionsByteClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsBytePatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsByteClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsModelGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty.Count, Is.EqualTo(2));
            Assert.That(response.Value.NullableProperty.First().Property, Is.EqualTo("hello"));
            Assert.That(response.Value.NullableProperty.Last().Property, Is.EqualTo("world"));
        });

        [SpectorTest]
        public Task CollectionsModelGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));
            Assert.That(response.Value.NullableProperty, Is.Not.Null);
        });

        [SpectorTest]
        public Task CollectionsModelPatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                nullableProperty = new[]
                {
                    new
                    {
                        property = "hello"
                    },
                    new
                    {
                        property = "world"
                    }
                }
            };
            var response = await new NullableClient(host, null).GetCollectionsModelClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsModelPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsModelClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsStringGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsStringClient().GetNonNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));

            var nullableProperty = response.Value.NullableProperty;
            Assert.That(nullableProperty, Is.Not.Null);
            Assert.That(nullableProperty.Count, Is.EqualTo(2));
            Assert.That(response.Value.NullableProperty[0], Is.EqualTo("hello"));
            Assert.That(response.Value.NullableProperty[1], Is.EqualTo("world"));
        });

        [SpectorTest]
        public Task CollectionsStringGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsStringClient().GetNullAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.RequiredProperty, Is.EqualTo("foo"));

            var nullableProperty = response.Value.NullableProperty;
            Assert.That(nullableProperty is null or [], Is.True);
        });

        [SpectorTest]
        public Task CollectionsStringPatchNonNull() => Test(async (host) =>
        {
            var value = new
            {
                requiredProperty = "foo",
                nullableProperty = new[]
                {
                    "hello",
                    "world"
                }
            };
            var response = await new NullableClient(host, null).GetCollectionsStringClient().PatchNonNullAsync(RequestContent.Create(BinaryData.FromObjectAsJson(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task CollectionsStringPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsStringClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
