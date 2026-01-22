// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineMessageTest
    {
        private static ResponseClassifier _classifier = new ResponseClassifier();

        [Test]
        public void DisposeNoopsForNullResponse()
        {
            var requestMock = new Mock<Request>();
            HttpMessage message = new HttpMessage(requestMock.Object, _classifier);
            message.Dispose();
            requestMock.Verify(r => r.Dispose(), Times.Once);
        }

        [Test]
        public void DisposingMessageDisposesTheRequestAndResponse()
        {
            var requestMock = new Mock<Request>();
            var responseMock = new Mock<Response>();
            HttpMessage message = new HttpMessage(requestMock.Object, _classifier);
            message.Response = responseMock.Object;
            message.Dispose();
            requestMock.Verify(r => r.Dispose(), Times.Once);
            responseMock.Verify(r => r.Dispose(), Times.Once);
        }

        [Test]
        public void PreserveReturnsResponseStream()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(200);
            response.ContentStream = mockStream.Object;

            HttpMessage message = new HttpMessage(new MockRequest(), _classifier);
            message.Response = response;

            Stream stream = message.ExtractResponseContent();
            Stream stream2 = message.ExtractResponseContent();

            Assert.That(stream, Is.SameAs(mockStream.Object));
            Assert.That(stream, Is.SameAs(stream2));
        }

        [Test]
        public void PreserveReturnsNullWhenContentIsNull()
        {
            var response = new MockResponse(200);
            response.ContentStream = null;

            HttpMessage message = new HttpMessage(new MockRequest(), _classifier);
            message.Response = response;

            Stream stream = message.ExtractResponseContent();

            Assert.That(stream, Is.SameAs(null));
        }

        [Test]
        public void PreserveSetsResponseContentToThrowingStream()
        {
            var mockStream = new Mock<Stream>();
            var response = new MockResponse(200);
            response.ContentStream = mockStream.Object;

            HttpMessage message = new HttpMessage(new MockRequest(), _classifier);
            message.Response = response;

            Stream stream = message.ExtractResponseContent();

            Assert.That(stream, Is.SameAs(mockStream.Object));
#pragma warning disable CA2022 // The return value of ReadAsync is not needed for this test
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => response.ContentStream.Read(Array.Empty<byte>(), 0, 0));
#pragma warning restore CA2022
            Assert.That(exception.Message, Is.EqualTo("The operation has called ExtractResponseContent and will provide the stream as part of its response type."));
        }

        [Test]
        public void ContentPropertyThrowsResponseIsExtracted()
        {
            var memoryStream = new MemoryStream();
            var response = new MockResponse(200);
            response.ContentStream = memoryStream;

            HttpMessage message = new HttpMessage(new MockRequest(), _classifier);
            message.Response = response;

            Assert.That(message.Response.Content.ToArray(), Is.EqualTo(memoryStream.ToArray()));

            Stream stream = message.ExtractResponseContent();

            Assert.That(stream, Is.SameAs(memoryStream));
            Assert.Throws<InvalidOperationException>(() => { var x = response.Content; });
        }
    }
}
