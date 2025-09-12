// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Encode.Bytes;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Bytes
{
    public class EncodeBytesTests : SpectorTestBase
    {
        private string SamplePngPath = Path.Combine(SpectorServer.GetSpecDirectory(), "assets", "image.png");

        [SpectorTest]
        public Task QueryDefault() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");

            Response result = await new BytesClient(host, null).GetQueryClient().DefaultAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task QueryBase64() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetQueryClient().Base64Async(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task QueryBase64url() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetQueryClient().Base64urlAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task QueryBase64urlArray() => Test(async (host) =>
        {
            BinaryData data1 = BinaryData.FromString("test");
            BinaryData data2 = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetQueryClient().Base64urlArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task PropertyDefault() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            var body = new DefaultBytesProperty(data);
            DefaultBytesProperty response = await new BytesClient(host, null).GetPropertyClient().DefaultAsync(body);
            BinaryDataAssert.AreEqual(body.Value, response.Value);
        });

        [SpectorTest]
        public Task PropertyBase64() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            var body = new Base64BytesProperty(data);
            Base64BytesProperty response = await new BytesClient(host, null).GetPropertyClient().Base64Async(body);
            BinaryDataAssert.AreEqual(body.Value, response.Value);
        });

        [SpectorTest]
        public Task PropertyBase64url() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            var body = new Base64urlBytesProperty(data);
            Base64urlBytesProperty response = await new BytesClient(host, null).GetPropertyClient().Base64urlAsync(body);
            BinaryDataAssert.AreEqual(body.Value, response.Value);
        });

        [SpectorTest]
        public Task Base64urlArrayBytesProperty() => Test(async (host) =>
        {
            BinaryData data1 = BinaryData.FromString("test");
            BinaryData data2 = BinaryData.FromString("test");
            var body = new Base64urlArrayBytesProperty(new[] {data1,data2});
            Base64urlArrayBytesProperty response = await new BytesClient(host, null).GetPropertyClient().Base64urlArrayAsync(body);
            BinaryDataAssert.AreEqual(body.Value[0], response.Value[0]);
            BinaryDataAssert.AreEqual(body.Value[1], response.Value[1]);
        });

        [SpectorTest]
        public Task HeaderDefault() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");

            Response result = await new BytesClient(host, null).GetHeaderClient().DefaultAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task HeaderBase64() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetHeaderClient().Base64Async(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task HeaderBase64url() => Test(async (host) =>
        {
            BinaryData data = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetHeaderClient().Base64urlAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task HeaderBase64urlArray() => Test(async (host) =>
        {
            BinaryData data1 = BinaryData.FromString("test");
            BinaryData data2 = BinaryData.FromString("test");
            Response result = await new BytesClient(host, null).GetHeaderClient().Base64urlArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task RequestBodyDefault() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            Response result = await new BytesClient(host, null).GetRequestBodyClient().DefaultAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task RequestBodyOctetStream() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            Response result = await new BytesClient(host, null).GetRequestBodyClient().OctetStreamAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task RequestBodyCustomContentType() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            Response result = await new BytesClient(host, null).GetRequestBodyClient().CustomContentTypeAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task RequestBodyBase64() => Test(async (host) =>
        {
            BinaryData data = new BinaryData($"\"{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("test"))}\"");
            Response result = await new BytesClient(host, null).GetRequestBodyClient().Base64Async(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task RequestBodyBase64url() => Test(async (host) =>
        {
            BinaryData data = new BinaryData($"\"{Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("test")).Replace('+', '-').Replace('/', '_').Replace("=", "")}\"");
            Response result = await new BytesClient(host, null).GetRequestBodyClient().Base64urlAsync(data);
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task ResponseBodyDefault() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            BinaryData result = await new BytesClient(host, null).GetResponseBodyClient().DefaultAsync();
            BinaryDataAssert.AreEqual(data, result);
        });

        [SpectorTest]
        public Task ResponseBodyOctetStream() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            BinaryData result = await new BytesClient(host, null).GetResponseBodyClient().OctetStreamAsync();
            BinaryDataAssert.AreEqual(data, result);
        });

        [SpectorTest]
        public Task ResponseBodyCustomContentType() => Test(async (host) =>
        {
            BinaryData data = new BinaryData(File.ReadAllBytes(SamplePngPath));
            BinaryData result = await new BytesClient(host, null).GetResponseBodyClient().CustomContentTypeAsync();
            BinaryDataAssert.AreEqual(data, result);
        });

        [SpectorTest]
        public Task ResponseBodyBase64() => Test(async (host) =>
        {
            BinaryData result = await new BytesClient(host, null).GetResponseBodyClient().Base64Async();
            BinaryDataAssert.AreEqual(BinaryData.FromObjectAsJson("dGVzdA=="), result);
        });

        [SpectorTest]
        public Task ResponseBodyBase64url() => Test(async (host) =>
        {
            BinaryData result = await new BytesClient(host, null).GetResponseBodyClient().Base64urlAsync();
            BinaryDataAssert.AreEqual(BinaryData.FromObjectAsJson("dGVzdA"), result);
        });
    }
}
