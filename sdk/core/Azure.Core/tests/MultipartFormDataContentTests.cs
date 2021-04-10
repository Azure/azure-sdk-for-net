// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MultipartFormDataContentTests
    {
        [Test]
        public void Ctor_NullBoundary_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MultipartFormDataContent(null));
        }

        [Test]
        public void Ctor_EmptyBoundary_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent(string.Empty));
        }

        [Test]
        public void Ctor_TooLongBoundary_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipartFormDataContent(
                "LongerThan70CharactersLongerThan70CharactersLongerThan70CharactersLongerThan70CharactersLongerThan70Characters"));
        }

        [Test]
        public void Ctor_BadBoundary_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("EndsInSpace "));

            // Invalid chars CTLs HT < > @ ; \ " [ ] { } ! # $ % & ^ ~ `
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("a\t"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("<"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("@"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("["));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("{"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("!"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("#"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("$"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("%"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("&"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("^"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("~"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("`"));
            Assert.Throws<ArgumentException>(() => new MultipartFormDataContent("\"quoted\""));
        }

        [Test]
        public void Ctor_GoodBoundary_Success()
        {
            // RFC 2046 Section 5.1.1
            // boundary := 0*69<bchars> bcharsnospace
            // bchars := bcharsnospace / " "
            // bcharsnospace := DIGIT / ALPHA / "'" / "(" / ")" / "+" / "_" / "," / "-" / "." / "/" / ":" / "=" / "?"
            new MultipartFormDataContent("09");
            new MultipartFormDataContent("az");
            new MultipartFormDataContent("AZ");
            new MultipartFormDataContent("'");
            new MultipartFormDataContent("(");
            new MultipartFormDataContent("+");
            new MultipartFormDataContent("_");
            new MultipartFormDataContent(",");
            new MultipartFormDataContent("-");
            new MultipartFormDataContent(".");
            new MultipartFormDataContent("/");
            new MultipartFormDataContent(":");
            new MultipartFormDataContent("=");
            new MultipartFormDataContent("?");
            new MultipartFormDataContent("Contains Space");
            new MultipartFormDataContent(" StartsWithSpace");
            new MultipartFormDataContent(Guid.NewGuid().ToString());
        }

        [Test]
        public void Add_NullContent_ThrowsArgumentNullException()
        {
            var content = new MultipartFormDataContent();
            Assert.Throws<ArgumentNullException>(() => content.Add(null));
        }

        [Test]
        public void Add_NullName_ThrowsArgumentNullException()
        {
            var content = new MultipartFormDataContent();
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            Assert.Throws<ArgumentNullException>(() => content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), null, headers));
        }

        [Test]
        public void Add_EmptyName_ThrowsArgumentException()
        {
            var content = new MultipartFormDataContent();
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            Assert.Throws<ArgumentException>(() => content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), string.Empty, headers));
        }

        [Test]
        public void Add_NullFileName_ThrowsNullArgumentException()
        {
            var content = new MultipartFormDataContent();
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            Assert.Throws<ArgumentNullException>(() => content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), "name", null, headers));
        }

        [Test]
        public void Add_EmptyFileName_ThrowsArgumentException()
        {
            var content = new MultipartFormDataContent();
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            Assert.Throws<ArgumentException>(() => content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), "name", string.Empty, headers));
        }

        [Test]
        public async Task Serialize_EmptyList_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual("--test_boundary\r\n\r\n--test_boundary--\r\n", result);
        }

        [Test]
        public async Task Serialize_StringContent_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), headers);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n"
                + "Content-Disposition: form-data\r\n\r\nHello World\r\n--test_boundary--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_MultipleStringContent_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World - 1")), headers);
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World - 2")), headers);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None).ConfigureAwait(false);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data\r\n\r\nHello World - 1\r\n" +
                 "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n" +
                "Content-Disposition: form-data\r\n\r\nHello World - 2\r\n--test_boundary--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_NamedStringContent_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), "test_name", headers);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n"
                + "Content-Disposition: form-data; name=test_name\r\n\r\nHello World\r\n--test_boundary--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_FileNameStringContent_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), "test_name", "test_file_name", headers);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n"
                + "Content-Disposition: form-data; name=test_name; "
                + "filename=test_file_name\r\n\r\n"
                + "Hello World\r\n--test_boundary--\r\n",
                result);
        }

        [Test]
        public async Task Serialize_QuotedName_Success()
        {
            var content = new MultipartFormDataContent("test_boundary");
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain; charset=utf-8" }
            };
            content.Add(RequestContent.Create(Encoding.UTF8.GetBytes("Hello World")), "\"test name\"", headers);

            var output = new MemoryStream();
            await content.WriteToAsync(output, CancellationToken.None);

            output.Seek(0, SeekOrigin.Begin);
            string result = new StreamReader(output).ReadToEnd();

            Assert.AreEqual(
                "--test_boundary\r\nContent-Type: text/plain; charset=utf-8\r\n"
                + "Content-Disposition: form-data; name=\"test name\"\r\n\r\nHello World\r\n--test_boundary--\r\n",
                result);
        }

        [Test]
        public void Dispose_Empty_Sucess()
        {
            var content = new MultipartFormDataContent();
            content.Dispose();
        }

        [Test]
        public void Dispose_InnerContent_InnerContentDisposed()
        {
            var content = new MultipartFormDataContent();
            var innerContent = new MockContent();
            content.Add(innerContent);
            content.Dispose();
            Assert.AreEqual(1, innerContent.DisposeCount);
            content.Dispose();
            // Inner content is discarded after first dispose.
            Assert.AreEqual(1, innerContent.DisposeCount);
        }

        [Test]
        public void Dispose_NestedContent_NestedContentDisposed()
        {
            var outer = new MultipartFormDataContent();
            var inner = new MultipartFormDataContent();
            outer.Add(inner);
            var mock = new MockContent();
            inner.Add(mock);
            outer.Dispose();
            Assert.AreEqual(1, mock.DisposeCount);
            outer.Dispose();
            // Inner content is discarded after first dispose.
            Assert.AreEqual(1, mock.DisposeCount);
        }

        private class MockContent : RequestContent
        {
            public int DisposeCount { get; private set; }

            public MockContent() { }

            public override void Dispose()
            {
                DisposeCount++;
            }

            public override void WriteTo(Stream stream, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override bool TryComputeLength(out long length)
            {
                length = 0;

                return false;
            }
        }
    }
}
