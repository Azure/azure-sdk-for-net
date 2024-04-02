// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Emitted;
using NUnit.Framework;

namespace Azure.Core.Tests
{
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
                 "Content-Disposition: form-data; name=test_name; "+
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
