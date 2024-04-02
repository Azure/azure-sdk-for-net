// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Emitted;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    // TODO: add async tests
    public class MultipartFormDataContentTests
    {
        [Test]
        public void Add_NullContent_ThrowsArgumentNullException()
        {
            var content = new MultipartFormDataRequestContent();

            Assert.Throws<ArgumentNullException>(() => content.Add((Stream)null, "name"));
            Assert.Throws<ArgumentNullException>(() => content.Add((string)null, "name"));
            Assert.Throws<ArgumentNullException>(() => content.Add((byte[])null, "name"));
            Assert.Throws<ArgumentNullException>(() => content.Add((BinaryData)null, "name"));
        }

        [Test]
        public void Add_NullName_ThrowsArgumentNullException()
        {
            var content = new MultipartFormDataRequestContent();

            Assert.Throws<ArgumentNullException>(() => content.Add(BinaryData.FromString("a").ToStream(), null));
            Assert.Throws<ArgumentNullException>(() => content.Add("a", null));
            Assert.Throws<ArgumentNullException>(() => content.Add(1, null));
            Assert.Throws<ArgumentNullException>(() => content.Add(1.2, null));
            Assert.Throws<ArgumentNullException>(() => content.Add(new byte[1] { 0 }, null));
            Assert.Throws<ArgumentNullException>(() => content.Add(BinaryData.FromString("a"), null));
        }

        [Test]
        public void Add_EmptyName_ThrowsArgumentException()
        {
            var content = new MultipartFormDataRequestContent();

            Assert.Throws<ArgumentException>(() => content.Add(BinaryData.FromString("a").ToStream(), string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add("a", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(1, string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(1.2, string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(new byte[1] { 0 }, string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(BinaryData.FromString("a"), string.Empty));
        }

        [Test]
        public void Add_EmptyFileName_ThrowsArgumentException()
        {
            var content = new MultipartFormDataRequestContent();

            Assert.Throws<ArgumentException>(() => content.Add(BinaryData.FromString("a").ToStream(), "name", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add("a", "name", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(1, "name", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(1.2, "name", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(new byte[1] { 0 }, "name", string.Empty));
            Assert.Throws<ArgumentException>(() => content.Add(BinaryData.FromString("a"), "name", string.Empty));
        }

        [Test]
        public async Task Serialize_EmptyList_Success()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual($"--{boundary}\r\n\r\n--{boundary}--\r\n", result);
        }

        //[Test]
        //public async Task Serialize_StringContent_Success()
        //{
        //    var content = new MultipartFormDataRequestContent();
        //    string boundary = GetBoundary(content);

        //    content.Add("Hello World", "name");

        //    var output = new MemoryStream();
        //    await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

        //    output.Seek(0, SeekOrigin.Begin);
        //    string result = new StreamReader(output).ReadToEnd();

        //    Assert.AreEqual(
        //        $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
        //        $"Content-Disposition: form-data\r\n\r\nHello World\r\n--{boundary}--\r\n",
        //        result);
        //}

        [Test]
        public async Task Serialize_MultipleStringContent_Success()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World - 1", "first");
            content.Add("Hello World - 2", "second");

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data; name=first\r\n\r\nHello World - 1\r\n" +
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                $"Content-Disposition: form-data; name=second\r\n\r\nHello World - 2\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_NamedStringContent_Success()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "test_name");

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                $"Content-Disposition: form-data; name=test_name\r\n\r\nHello World\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_FileNameStringContent_Success()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "test_name", "test_file_name");

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                 "Content-Disposition: form-data; name=test_name; " +
                 "filename=test_file_name\r\n\r\n" +
                 $"Hello World\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_QuotedName_Success()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "\"test name\"");

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                $"Content-Disposition: form-data; name=\"test name\"\r\n\r\nHello World\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_InvalidName_Encoded()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "test\u30AF\r\n nam\u00E9");

            MemoryStream output = new MemoryStream();
            await content.WriteToAsync(output);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data; name=\"=?utf-8?B?dGVzdOOCrw0KIG5hbcOp?=\"" +
                $"\r\n\r\nHello World\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_InvalidQuotedName_Encoded()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "\"test\u30AF\r\n nam\u00E9\"");

            MemoryStream output = new MemoryStream();
            await content.WriteToAsync(output);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data; name=\"=?utf-8?B?dGVzdOOCrw0KIG5hbcOp?=\"" +
                $"\r\n\r\nHello World\r\n--{boundary}--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_InvalidNamedFileName_Encoded()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("Hello World", "test\u30AF\r\n nam\u00E9", "file\u30AF\r\n nam\u00E9");

            MemoryStream output = new MemoryStream();
            await content.WriteToAsync(output);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data; name=\"=?utf-8?B?dGVzdOOCrw0KIG5hbcOp?=\";" +
                " filename=\"=?utf-8?B?ZmlsZeOCrw0KIG5hbcOp?=\"; filename*=utf-8\'\'file%E3%82%AF%0D%0A%20nam%C3%A9" +
                $"\r\n\r\nHello World\r\n--{boundary}--\r\n",
                result);
        }

        // TODO: support arbitrary header addition?
        //[Test]
        //public async Task ReadAsStringAsync_OneSubContentWithHeaders_MatchesExpected(MultipartContentToStringMode mode, bool async)
        //{
        //    byte[] subContent = "This is a ByteArrayContent"u8.ToArray();

        //    subContent.Headers.Add("someHeaderName", "andSomeHeaderValue");
        //    subContent.Headers.Add("someOtherHeaderName", new[] { "withNotOne", "ButTwoValues" });
        //    subContent.Headers.Add("oneMoreHeader", new[] { "withNotOne", "AndNotTwo", "butThreeValues" });

        //    var mc = new MultipartContent("someSubtype", "theBoundary");
        //    mc.Add(subContent);

        //    Assert.Equal(
        //        "--theBoundary\r\n" +
        //        "someHeaderName: andSomeHeaderValue\r\n" +
        //        "someOtherHeaderName: withNotOne, ButTwoValues\r\n" +
        //        "oneMoreHeader: withNotOne, AndNotTwo, butThreeValues\r\n" +
        //        "\r\n" +
        //        "This is a ByteArrayContent\r\n" +
        //        "--theBoundary--\r\n",
        //        await MultipartContentToStringAsync(mc, mode, async));
        //}

        [Theory]
        public async Task ReadAsStringAsync_TwoSubContents_MatchesExpected()
        {
            var content = new MultipartFormDataRequestContent();
            string boundary = GetBoundary(content);

            content.Add("This is a ByteArrayContent"u8.ToArray(), "bytes");
            content.Add("This is a StringContent", "string");

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                $"--{boundary}\r\n" +
                "\r\n" +
                "This is a ByteArrayContent\r\n" +
                $"--{boundary}\r\n" +
                "Content-Type: text/plain; charset=utf-8\r\n" +
                "\r\n" +
                "This is a StringContent\r\n" +
                $"--{boundary}--\r\n",
                result);
        }

        [Test]
        // TODO: add test cases
        public async Task MultipartContent_TryComputeLength_ReturnsSameLengthAsCopyToAsync()
        {
            var content = new MultipartFormDataRequestContent();

            Assert.True(content.TryComputeLength(out long length));

            var copyToStream = new MemoryStream();
            content.WriteTo(copyToStream, cancellationToken: default);
            Assert.AreEqual(length, copyToStream.Length);

            var copyToAsyncStream = new MemoryStream();
            await content.WriteToAsync(copyToAsyncStream, cancellationToken: default);
            Assert.AreEqual(length, copyToAsyncStream.Length);

            Assert.AreEqual(copyToStream.ToArray(), copyToAsyncStream.ToArray());
        }

        [Test]
        public void Dispose_Empty_Success()
        {
            var content = new MultipartFormDataRequestContent();
            content.Dispose();
        }

        [Test]
        public void Dispose_InnerContent_InnerContentDisposed()
        {
            var content = new MultipartFormDataRequestContent();
            var innerContent = new DisposeTrackingStream();
            content.Add(innerContent, "file");
            content.Dispose();
            Assert.AreEqual(1, innerContent.DisposeCount);
            content.Dispose();
            // Inner content is discarded after first dispose.
            Assert.AreEqual(1, innerContent.DisposeCount);
        }

        // TODO: Add tests to validate content length computation
        // TODO: Add tests for different content type overloads
        // - int
        // - double
        // - byte[]
        // - BinaryData

        // TODO: Vet against https://github.com/microsoft/typespec/issues/3046

        #region Helpers

        private string GetBoundary(MultipartFormDataRequestContent content)
        {
            return content.ContentType.Substring("multipart/form-data; boundary=\"".Length, 70);
        }

        private class DisposeTrackingStream : MemoryStream
        {
            public int DisposeCount { get; private set; }

            public DisposeTrackingStream() { }

            protected override void Dispose(bool disposing)
            {
                DisposeCount++;
            }
        }

        #endregion
    }
}
