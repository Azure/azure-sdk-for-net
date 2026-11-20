// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageRequestFailedDetailsParserTests
    {
        private readonly StorageRequestFailedDetailsParser _parser = new StorageRequestFailedDetailsParser();

        [Test]
        public void TryParseXml()
        {
            var response = new MockResponse(400)
                .WithHeader("Content-Type", "application/xml")
                .WithContent("<Error><Code>AuthenticationFailed</Code><Message>Invalid authentication</Message><Detail>More information</Detail></Error>");
            response.ContentStream.Position = 3;

            bool result = _parser.TryParse(response, out ResponseError error, out IDictionary<string, string> data);

            Assert.IsTrue(result);
            Assert.AreEqual("AuthenticationFailed", error.Code);
            Assert.AreEqual("Invalid authentication", error.Message);
            Assert.AreEqual("More information", data["Detail"]);
            Assert.AreEqual(3, response.ContentStream.Position);
        }

        [Test]
        public void TryParseXmlWithLowercaseProperties()
        {
            var response = CreateResponse("application/xml", "<Error><code>InvalidHeaderValue</code><message>Invalid version</message></Error>");

            bool result = _parser.TryParse(response, out ResponseError error, out IDictionary<string, string> data);

            Assert.IsTrue(result);
            Assert.AreEqual("InvalidHeaderValue", error.Code);
            Assert.AreEqual("Invalid version", error.Message);
            Assert.AreEqual("InvalidHeaderValue", data["code"]);
            Assert.AreEqual("Invalid version", data["message"]);
        }

        [Test]
        public void TryParseXmlWithInvalidVersionHeader()
        {
            var response = CreateResponse("application/xml", "<Error><Code>InvalidHeaderValue</Code><Message>Original message</Message><HeaderName>x-ms-version</HeaderName></Error>");

            bool result = _parser.TryParse(response, out ResponseError error, out _);

            Assert.IsTrue(result);
            Assert.AreEqual("InvalidHeaderValue", error.Code);
            Assert.AreEqual(Constants.Errors.InvalidVersionHeaderMessage, error.Message);
        }

        [TestCase("{\"error\":{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"detail\":{\"target\":\"name\"}}}", "name")]
        [TestCase("{\"error\":{\"code\":\"BadRequest\",\"message\":\"Invalid request\",\"detail\":\"not an object\"}}", null)]
        public void TryParseJson(string content, string expectedDetail)
        {
            var response = CreateResponse("application/json", content);

            bool result = _parser.TryParse(response, out ResponseError error, out IDictionary<string, string> data);

            Assert.IsTrue(result);
            Assert.AreEqual("BadRequest", error.Code);
            Assert.AreEqual("Invalid request", error.Message);
            if (expectedDetail is null)
            {
                Assert.IsNull(data);
            }
            else
            {
                Assert.AreEqual(expectedDetail, data["target"]);
            }
        }

        [Test]
        public void TryParseWithoutSeekableContentStream()
        {
            var response = CreateResponse("application/json", "{\"error\":{\"code\":\"BadRequest\",\"message\":\"Invalid request\"}}");
            response.ContentStream = new NonSeekableStream(response.ContentStream);

            bool result = _parser.TryParse(response, out ResponseError error, out _);

            Assert.IsTrue(result);
            Assert.AreEqual("BadRequest", error.Code);
        }

        [Test]
        public void TryParseHeaderOnlyResponse()
        {
            var response = new MockResponse(400).WithHeader(Constants.HeaderNames.ErrorCode, "BadRequest");

            bool result = _parser.TryParse(response, out ResponseError error, out IDictionary<string, string> data);

            Assert.IsTrue(result);
            Assert.AreEqual("BadRequest", error.Code);
            Assert.IsNull(error.Message);
            Assert.IsNull(data);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void TryParseUnsupportedOrMissingResponse(bool includeContent)
        {
            var response = includeContent
                ? CreateResponse("text/plain", "not an error document")
                : new MockResponse(400);

            bool result = _parser.TryParse(response, out ResponseError error, out IDictionary<string, string> data);

            Assert.IsFalse(result);
            Assert.IsNull(error);
            Assert.IsNull(data);
        }

        private static MockResponse CreateResponse(string contentType, string content)
        {
            return new MockResponse(400)
                .WithHeader("Content-Type", contentType)
                .WithContent(content);
        }

        private sealed class NonSeekableStream : Stream
        {
            private readonly Stream _inner;

            public NonSeekableStream(Stream inner) => _inner = inner;

            public override bool CanRead => _inner.CanRead;
            public override bool CanSeek => false;
            public override bool CanWrite => _inner.CanWrite;
            public override long Length => _inner.Length;
            public override long Position { get => _inner.Position; set => _inner.Position = value; }
            public override void Flush() => _inner.Flush();
            public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);
            public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);
            public override void SetLength(long value) => _inner.SetLength(value);
            public override void Write(byte[] buffer, int offset, int count) => _inner.Write(buffer, offset, count);
        }
    }
}
