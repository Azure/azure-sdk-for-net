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
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.AreEqual("hello", response.Value.NullableProperty);
        });

        [SpectorTest]
        public Task StringGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetStringClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetStringClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BytesGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetBytesClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty);
        });

        [SpectorTest]
        public Task BytesGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetBytesClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BytesPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetBytesClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DatetimeTetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDatetimeClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value.NullableProperty);
        });

        [SpectorTest]
        public Task DatetimeGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDatetimeClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Datetime_patchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetDatetimeClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDurationClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value.NullableProperty);
        });

        [SpectorTest]
        public Task Type_Property_Nullable_Duration_getNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetDurationClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetDurationClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsByteGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.AreEqual(2, response.Value.NullableProperty.Count);
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty.First());
            BinaryDataAssert.AreEqual(BinaryData.FromString("hello, world!"), response.Value.NullableProperty.Last());
        });

        [SpectorTest]
        public Task CollectionsByteGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsByteClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNotNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsBytePatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsByteClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsModelGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.AreEqual(2, response.Value.NullableProperty.Count);
            Assert.AreEqual("hello", response.Value.NullableProperty.First().Property);
            Assert.AreEqual("world", response.Value.NullableProperty.Last().Property);
        });

        [SpectorTest]
        public Task CollectionsModelGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsModelClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);
            Assert.IsNotNull(response.Value.NullableProperty);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsModelPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsModelClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsStringGetNonNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsStringClient().GetNonNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);

            var nullableProperty = response.Value.NullableProperty;
            Assert.IsNotNull(nullableProperty);
            Assert.AreEqual(2, nullableProperty.Count);
            Assert.AreEqual("hello", response.Value.NullableProperty[0]);
            Assert.AreEqual("world", response.Value.NullableProperty[1]);
        });

        [SpectorTest]
        public Task CollectionsStringGetNull() => Test(async (host) =>
        {
            var response = await new NullableClient(host, null).GetCollectionsStringClient().GetNullAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.RequiredProperty);

            var nullableProperty = response.Value.NullableProperty;
            Assert.IsTrue(nullableProperty is null or []);
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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task CollectionsStringPatchNull() => Test(async (host) =>
        {
            string value = "{ \"requiredProperty\": \"foo\", \"nullableProperty\": null }";
            var response = await new NullableClient(host, null).GetCollectionsStringClient().PatchNullAsync(RequestContent.Create(BinaryData.FromString(value)), null);
            Assert.AreEqual(204, response.Status);
        });
    }
}
